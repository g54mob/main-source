using System;
using UnityEngine;

[Serializable]
public class playerResetFloor : MonoBehaviour
{
	public GameObject player;

	public Transform playerResetPos;

	public GameObject Sound1;

	public GameObject Sound2;

	public virtual void Start()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
