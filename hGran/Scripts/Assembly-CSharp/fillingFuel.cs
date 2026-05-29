using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class fillingFuel : MonoBehaviour
{
	public int layerMask;

	public GameObject gameController;

	public bool playerHoldButton;

	public GameObject fillFuelButton;

	public GameObject fillFuelMeter;

	public Image fillFuealBar;

	public GameObject doorRay;

	public bool playerTaken;

	public bool playSound;

	public bool noMoreFill;

	public GameObject tanklockAnim;

	public GameObject fillingGasSoundHolder;

	public bool tanklockAnimPlayed;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
