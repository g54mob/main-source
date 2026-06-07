using System;
using UnityEngine;

[Serializable]
public class teddyFalls : MonoBehaviour
{
	public Transform objectResetPos;

	public GameObject ParentObject;

	public Transform player;

	public virtual void Start()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
