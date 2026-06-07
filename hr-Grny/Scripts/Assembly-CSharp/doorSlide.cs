using System;
using UnityEngine;

[Serializable]
public class doorSlide : MonoBehaviour
{
	public bool plattaTryck;

	public bool maxH;

	public bool maxV;

	public AudioClip slidingDoor;

	public bool stopsound;

	public bool startsound;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void StartSound()
	{
	}

	public virtual void StopSound()
	{
	}
}
