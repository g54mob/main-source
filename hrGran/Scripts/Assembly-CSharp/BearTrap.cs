using System;
using UnityEngine;

[Serializable]
public class BearTrap : MonoBehaviour
{
	public bool beartrapOn;

	public bool beartrapShot;

	public GameObject Granny;

	public Transform spawnObject;

	public GameObject joystick;

	public AudioClip ObjectLjud;

	public AudioClip BeartrapOnFloor;

	public GameObject footstepScriptHolder;

	public GameObject player;

	public GameObject playerHead;

	public GameObject GrannyEye;

	public GameObject optionButton;

	public GameObject crawlButton;

	public GameObject allBedButtons;

	public float timer;

	public bool timerStart;

	public bool playerStuck;

	public GameObject gameController;

	public GameObject littleSanta;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}

	public virtual void beartrapDestroyed()
	{
	}
}
