using System;
using UnityEngine;

[Serializable]
public class fadeUpDownGrannyHunt : MonoBehaviour
{
	public bool playerCaught;

	public bool grannySmackPlayer;

	public bool grannyDead;

	public bool playerSpiderCellar;

	public bool startFade;

	public bool musicOn;

	public bool startMusic;

	public bool stopMusic;

	public float volume;

	public float MaxVolumeHunt;

	public float MaxVolumeMusic;

	public GameObject MusicHolder;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
