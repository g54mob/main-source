using System;
using UnityEngine;

[Serializable]
public class ragdollFallSound : MonoBehaviour
{
	public AudioClip ObjectLjud;

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
