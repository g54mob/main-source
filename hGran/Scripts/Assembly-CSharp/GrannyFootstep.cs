using System;
using UnityEngine;

[Serializable]
public class GrannyFootstep : MonoBehaviour
{
	public AudioClip[] footstepGranny;

	public AudioClip[] footstepGrusGranny;

	public AudioClip[] footstepSnowGranny;

	public bool walkGrus;

	public bool walkSnow;

	[Header("Pitch")]
	public float pitch;

	private AudioSource audioSource;

	private void Start()
	{
	}

	public virtual void step()
	{
	}
}
