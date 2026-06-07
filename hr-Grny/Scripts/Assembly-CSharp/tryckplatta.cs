using System;
using UnityEngine;

[Serializable]
public class tryckplatta : MonoBehaviour
{
	public GameObject slideDoor;

	public bool ironKlumpOnPlace;

	public Texture bildVit;

	public Texture bildGreen;

	public GameObject standOnPlatta;

	public AudioClip tryckplattaLjud;

	public GameObject soundHolder;

	public virtual void Update()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}

	public virtual void OnTriggerExit(Collider other)
	{
	}
}
