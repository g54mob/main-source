using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
	public bool fadeUp;

	public bool fadeDown;

	public AudioSource audio;

	public AudioClip knappLjud;

	public AudioClip HouseNoice;

	public AudioClip SpiderNoice;

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
