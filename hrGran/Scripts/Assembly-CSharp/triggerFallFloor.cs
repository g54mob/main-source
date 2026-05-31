using System;
using UnityEngine;

[Serializable]
public class triggerFallFloor : MonoBehaviour
{
	public GameObject bit1;

	public GameObject bit2;

	public GameObject bit3;

	public GameObject bit4;

	public GameObject soundHolder;

	public GameObject placePlankTrigger;

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
