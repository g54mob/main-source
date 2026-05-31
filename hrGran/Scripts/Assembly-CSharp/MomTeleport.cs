using System;
using UnityEngine;

[Serializable]
public class MomTeleport : MonoBehaviour
{
	public GameObject mom;

	public Transform teleportPoint;

	public virtual void Start()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
