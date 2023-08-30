using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name = string.Empty;
    public KeyCode ForwardKeyCode = KeyCode.Z;
    public KeyCode BackwardKeyCode = KeyCode.S;
    public KeyCode RotateLeftKeyCode = KeyCode.Q;
    public KeyCode RotateRightKeyCode = KeyCode.D;
    public KeyCode BoostKeyCode = KeyCode.Space;
    public int Score = 0;

    private float _forwardSpeed = 5f;
    private float _rotateSpeed = 180f;
    private float _addRotateSpeed = 170f;
    private float _boostSpeed = 6f;
    private float _slowRotateSpeed = 68f;
    //private float _lastBoostTime = -1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var forward = 0f;
        var rotate = 0f;
        var addrotate = 0f;
        var boost = 0f;
        var slowrotate = 0f;

        //var isBoost = (_lastBoostTime + 1 > Time.time) && Input.GetKey(BoostKeyCode);

        //if (isBoost)
        //{
            //_lastBoostTime = Time.time;
            //Debug.Log("Boost");
        //}

        if (Input.GetKey(ForwardKeyCode))
        {
            forward += _forwardSpeed * Time.deltaTime;
        }

        if (Input.GetKey(BackwardKeyCode))
        {
            forward -= _forwardSpeed * Time.deltaTime;
        }

        //if (isBoost)
        if (Input.GetKey(BoostKeyCode))
        {
            if (Input.GetKey(RotateLeftKeyCode))
            {
                slowrotate += _slowRotateSpeed * Time.deltaTime;
            }

            if (Input.GetKey(RotateRightKeyCode))
            {
                slowrotate -= _slowRotateSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKey(RotateLeftKeyCode))
            {
                rotate += _rotateSpeed * Time.deltaTime;
            }

            if (Input.GetKey(RotateRightKeyCode))
            {
                rotate -= _rotateSpeed * Time.deltaTime;
            }
        }

        if(forward == 0f)
        {
            if (Input.GetKey(RotateLeftKeyCode))
            {
                addrotate += _addRotateSpeed * Time.deltaTime;
            }

            if (Input.GetKey(RotateRightKeyCode))
            {
                addrotate -= _addRotateSpeed * Time.deltaTime;
            }
        }

        if (Input.GetKey(BoostKeyCode))
        {
            if (Input.GetKey(ForwardKeyCode))// && isBoost)
            {
                boost += _boostSpeed * Time.deltaTime;
            }

            if (Input.GetKey(BackwardKeyCode))// && isBoost)
            {
                boost -= _boostSpeed * Time.deltaTime;

            }
        }
        transform.Translate(0, forward + boost, 0);
        
        transform.Rotate(0, 0, rotate + addrotate + slowrotate);
    }
}
