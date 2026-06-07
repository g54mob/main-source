using System;
using UnityEngine;

[Serializable]
public class FadeHuntMusic : MonoBehaviour
{
	public AudioClip huntingMusic;

	public AudioClip fightSlendrinaMusic;

	public AudioClip headHuntMusic;

	public AudioClip bookMusic;

	public float volume;

	public bool fading;

	public bool playMusic;

	public bool musicOn;

	public bool momHunt;

	public bool stopFade;

	public GameObject musicHolder;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void fightSlendrina()
	{
	}

	public virtual void NotfightSlendrina()
	{
	}

	public virtual void headHuntStarts()
	{
	}

	public virtual void bookMusicStarts()
	{
	}
}
