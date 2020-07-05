/*===============================================================================
Copyright (c) 2015-2017 PTC Inc. All Rights Reserved.

Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using System.Collections;

public class AperturaScrigni : MonoBehaviour
{
    
	public Animator myAnimator;

    void Start()
    {
        if (myAnimator == null) {
			Debug.LogError ("myAnimator nullo!");
		}
        apriScrigno();

    }

	

    void Update()
    {
        //apriScrigno();

    }

    public void apriScrigno()
    {
        Debug.Log("apri scrigno chiamata");
        myAnimator.SetBool("aperto", true);
    }

    
}

