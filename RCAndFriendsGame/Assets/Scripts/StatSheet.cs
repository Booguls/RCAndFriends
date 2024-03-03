using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSheet
{
    private float _health;
    private float _speed;
    
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
}
