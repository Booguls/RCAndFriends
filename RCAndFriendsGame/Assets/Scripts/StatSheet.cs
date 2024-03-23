using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSheet
{
    private float _health;
    private float _speed;
    private float _jumpPower;
    
    public StatSheet() 
    {
        _health = 0;
        _speed = 0;
        _jumpPower = 0;
    }

    public StatSheet(float health, float speed, float jump)
    {
        _health=health;
        _speed=speed;
        _jumpPower=jump;
    }

    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public float Jump
    {
        get { return _jumpPower; }
        set { _jumpPower = value; }
    }
}
