using System;
using UnityEngine;
using UnityEngine.PostProcessing;

[Serializable]
public class ButtonClicks : MonoBehaviour
{
	public PostProcessingProfile CC;

	public GameObject Beartrap;

	public GameObject BeartrapNightmare;

	public GameObject PumpkinHalloween;

	public GameObject SantaChristmas;

	public GameObject SantahatTeddy;

	public AudioClip buttonclick;

	public AudioClip bearTrap;

	public virtual void Start()
	{
	}

	public virtual void clickButton()
	{
	}

	public virtual void checkPostProcessing()
	{
	}
}
