using System;
using UnityEngine;

[Serializable]
public class GrannyHear : MonoBehaviour
{
	public GameObject Granny;

	public Transform spawnObject;

	public AudioClip PlayerLjud;

	[Header("Cooldown Settings")]
	[Tooltip("Time in seconds before the trigger can be activated again.")]
	public float cooldownDuration;

	private float nextTriggerTime;

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
