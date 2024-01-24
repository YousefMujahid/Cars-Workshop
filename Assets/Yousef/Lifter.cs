using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifter : MonoBehaviour
{
    [SerializeField] GameObject _lifter;
    [SerializeField] GameObject _dodge_charger;
    [SerializeField] Vector3 _top_position; 
    Vector3 _lifter_position;
    Vector3 _dodge_charger_position;
    Vector3 _lifter_last_position;
    Vector3 _dodge_charger_last_position;
    public bool isUpperButtonClicked;
    public bool isLowerButtonClicked;



    public float raising_time;
    public float raising_offset;
    public float lowering_offest;
    
    void Start()
    {
        _lifter_position = _lifter.transform.position;
        _dodge_charger_position = _dodge_charger.transform.position;

    }

    public bool check_if_button_is_clicked()
    {

        return isUpperButtonClicked = true;
    }
    void RaiseTheCar(float offest)
    {

        _lifter.transform.position = Vector3.Lerp(_lifter_position, 
            new Vector3(_lifter_position.x, _lifter_position.y+ offest, _lifter_position.z),
            raising_time);

        _dodge_charger.transform.position = Vector3.Lerp(_dodge_charger_position, 
            new Vector3(_dodge_charger_position.x, _dodge_charger_position.y+ offest, _dodge_charger_position.z),
            raising_time);

        _lifter_last_position = _lifter.transform.position;
        _dodge_charger_last_position = _dodge_charger.transform.position;
    }
    void LowerTheCar(float offest)
    {
        

        _lifter.transform.position = Vector3.Lerp(_lifter_last_position,
            new Vector3(_lifter_last_position.x, _lifter_last_position.y + offest, _lifter_last_position.z),
            raising_time);

        _dodge_charger.transform.position = Vector3.Lerp(_dodge_charger_last_position,
            new Vector3(_dodge_charger_last_position.x, _dodge_charger_last_position.y + offest, _dodge_charger_last_position.z),
            raising_time);
    }

    void Update()
    {
       
        if (isUpperButtonClicked)
        {
            if (raising_offset < 5f)
            {
                raising_offset += Time.deltaTime * 2f;
            }
            
            RaiseTheCar(raising_offset);

        }
        if (isLowerButtonClicked)
        {
            if (_lifter_last_position != _lifter_position)
            {
                raising_offset -= Time.deltaTime * 2f;

            }

            if (raising_offset < 0.02f)
            {
                raising_offset = 0.02f;
            }
            LowerTheCar(raising_offset-5);
        }
    }
}
