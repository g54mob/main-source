using System;
using UnityEngine;

[Serializable]
public class backgroundSound : MonoBehaviour
{
	public bool fadeUp;

	public bool fadeDown;

	public AudioSource audio;

	public AudioClip knappLjud;

	public AudioClip HouseNoice;

	public AudioClip SpiderNoice;

	public AudioClip HalloweenNoice;

	public AudioClip ChristmasNoice;

	public float topVol;

	public float fadeSpeed;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void changeBackgroundSpider()
	{
	}

	public virtual void changeBackgroundHouse()
	{
	}

	public virtual void buttonClick()
	{
	}
}
