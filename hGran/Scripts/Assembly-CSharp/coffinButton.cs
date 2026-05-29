using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class coffinButton : MonoBehaviour
{
	public GameObject player;

	public GameObject granny;

	public GameObject inCoffin;

	public GameObject underBedCam;

	public GameObject coffinLock;

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

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
