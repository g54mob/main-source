using System;
using UnityEngine;

[Serializable]
public class maniacBreath : MonoBehaviour
{
	public AudioClip breathSlow;

	public AudioClip breathFast;

	public AudioClip hurt;

	public AudioClip freezed;

	public virtual void Start()
	{
	}

	public virtual void stopAudio()
	{
	}

	public virtual void maniacBreathSlow()
	{
	}

	public virtual void maniacBreathFast()
	{
	}

	public virtual void maniachurt()
	{
	}

	public virtual void maniafreezed()
	{
	}
}
