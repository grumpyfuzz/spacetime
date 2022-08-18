using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoInstance : MonoBehaviour
{
    public static MonoInstance instance;

    public void Start()
    {
        MonoInstance.instance = this;
    }
 }