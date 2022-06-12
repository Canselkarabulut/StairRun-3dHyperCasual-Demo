using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static Animator animator;
    bool isMainCamera = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("MainCamera");
    }
    void Update()
    {
        if (PlayerController._sCamera)
        {
            CameraChange();
        }
        else
        {
            DefaultCamera();
        }
             
    }
    public void CameraChange()
    {
        animator.Play("winCamera");
    }
    public void DefaultCamera()
    {
        animator.Play("MainCamera");
    }
}
