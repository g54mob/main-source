using System;
using UnityEngine;

[Serializable]
public class playerFallingSound : MonoBehaviour
{
	public AudioClip fallWindSound;

	public bool soundPlaying;

	public bool fadingSound;

	public virtual void Update()
	{
	}

	public virtual void playerFalling()
	{
	}

	public virtual void playerFallingNot()
	{
	}
}
