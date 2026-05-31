using System;
using UnityEngine;

[Serializable]
public class teleportAwayTrigger : MonoBehaviour
{
	public Transform teleportPointNOS;

	public GameObject NOS;

	public virtual void Start()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
