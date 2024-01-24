using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class SocketManger : MonoBehaviour
{
    [SerializeField] XRSocketInteractor[] _socket;
    [SerializeField] GameObject[] _object_part;
    [SerializeField] GameObject _Car;
    bool[] _check_if_it_right;
    Vector3 _original_part_position;
    public bool IsAllPartAssembled;
    #region unity method
    void Start()
    {
        _check_if_it_right = new bool[_socket.Length];
    }
    void Update()
    {
        CheckPartValidation(_object_part, _socket);
    }
    #endregion
    #region private method
    IEnumerator DisableAllIntraction(GameObject _object)
    {
        yield return new WaitForSeconds(0.5f);
        _object.GetComponent<XRGrabInteractable>().enabled = false;
        _object.GetComponent<Rigidbody>().isKinematic = true;
        _object.transform.SetParent(_Car.transform);
    }
    bool CheckAllPaetIsAssembled(bool[] check)
    {
        for (int i = 0; i < check.Length; i++)
        {
            if (!check[i])
            {
                return false;
            }
        }
        return true;
    }
    void CheckPartValidation(GameObject[] _object, XRSocketInteractor[] _socket)
    {
        for (int i = 0; i < _object.Length; i++)
        {
            if (!_check_if_it_right[i] && _socket[i].hasSelection)
            {
                IXRSelectInteractable xRSelect = _socket[i].GetOldestInteractableSelected();
                if (xRSelect.transform.GetInstanceID() == _object[i].transform.GetInstanceID()) //116948   116574
                {
                    _socket[i].showInteractableHoverMeshes = false;
                    StartCoroutine(DisableAllIntraction(_object[i].gameObject));
                    _check_if_it_right[i] = true;
                    IsAllPartAssembled = CheckAllPaetIsAssembled(_check_if_it_right);
                }
                else
                {
                    _socket[i].enabled = false;
                    xRSelect.transform.position = _original_part_position;
                    _socket[i].enabled = true;
                }
            }
        }
    }
    void assing_all_grab_object(GameObject _object)
    {
        _original_part_position = _object.transform.position;
    }
    #endregion
    #region public method
    public void GetPartPosition(GameObject _object)
    {
        _original_part_position = _object.transform.position;
    }
    #endregion
}
