using System;
using UnityEngine;

[Serializable]
public class hideTrigger : MonoBehaviour
{
	public GameObject granny;

	public GameObject grannyEye;

	public virtual void Start()
	{
	}

	public virtual void OnTriggerStay(Collider other)
	{
	}

	public virtual void OnTriggerExit(Collider other)
	{
	}
}
