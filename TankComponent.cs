using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankComponent : Armor
{

public enum components
{
    barrel,
    optics
}

    public components representitiveComponent;
    public void damageComponent()
    {
        Debug.Log("Damaged component: " + representitiveComponent.ToString());
    }
}

