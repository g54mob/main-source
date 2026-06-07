using System;
using UnityEngine;

[Serializable]
public class TeleportMonster : MonoBehaviour
{
	public GameObject monster;

	public Transform teleportPoint;

	public virtual void Start()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
