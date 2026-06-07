using System;
using UnityEngine;

[Serializable]
public class disableKinematic : MonoBehaviour
{
	public AudioClip sound;

	public bool done;

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
