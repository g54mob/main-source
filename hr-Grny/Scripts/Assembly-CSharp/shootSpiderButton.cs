using System;
using UnityEngine;

[Serializable]
public class shootSpiderButton : MonoBehaviour
{
	public bool buttonShot;

	public GameObject luckaAnim;

	public GameObject spider;

	public GameObject spiderTrigger1;

	public GameObject spiderTrigger2;

	public GameObject leaveTrigger;

	public GameObject shootbutton;

	public GameObject foodPos;

	public GameObject spiderNestpos;

	public GameObject spiderStartpos;

	public AudioClip luckaFaller;

	public virtual void Start()
	{
	}

	public virtual void closeSpiderlucka()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
