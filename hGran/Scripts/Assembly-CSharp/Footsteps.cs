using System;
using UnityEngine;

[Serializable]
public class Footsteps : MonoBehaviour
{
	public GameObject gameController;

	public AudioClip[] footstepConcrete;

	public AudioClip[] footstepConcreteSticky;

	public AudioClip[] footstepGrus;

	public AudioClip[] footstepWater;

	public AudioClip[] footstepSnow;

	public bool isWalking;

	public bool walkFloor;

	public bool walkGrus;

	public bool walkWater;

	public bool walkSnow;

	public GameObject headBob;

	public bool day2;

	public bool day3;

	public bool playerCrouching;

	public GameObject soundPosition;

	public float volume;

	public virtual void step()
	{
	}

	public virtual void walk()
	{
	}

	public virtual void stopwalk()
	{
	}
}
