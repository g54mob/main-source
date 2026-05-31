using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class insideCarButton : MonoBehaviour
{
	public GameObject player;

	public GameObject granny;

	public GameObject inCoffin;

	public GameObject underBedCam;

	public GameObject playerPosition;

	public bool PlayerHiding;

	public GameObject playerCam;

	public GameObject crouchButton;

	public GameObject soundHolder;

	public GameObject dropButtonHolder;

	public GameObject hidingSoundHolder;

	public GameObject shootGunButtonHolder;

	public GameObject pickupButton;

	public GameObject openDoorButton;

	public GameObject mittenRing;

	public Sprite hideTexture;

	public Sprite UnhideTexture;

	public Image button;

	public float lockRotXNer;

	public float lockRotXUpp;

	public GameObject startButton;

	public GameObject reverseButton;

	public GameObject forwardButton;

	public GameObject gameController;

	public GameObject engineOffSound;

	public GameObject engineOnSound;

	public GameObject engineStartSound;

	public GameObject objectsHolder;

	public bool drivingCar;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
