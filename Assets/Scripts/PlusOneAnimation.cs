using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOneAnimation : MonoBehaviour
{

    private void OnEnable()
    {
        Animation anim=gameObject.GetComponent<Animation>();
        anim.Play();
    }


}
