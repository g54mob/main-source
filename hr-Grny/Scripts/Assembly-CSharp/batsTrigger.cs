using System;
using UnityEngine;

[Serializable]
public class batsTrigger : MonoBehaviour
{
	public GameObject NOS;

	public GameObject nextTrigger;

	public GameObject bats;

	public virtual void Start()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
