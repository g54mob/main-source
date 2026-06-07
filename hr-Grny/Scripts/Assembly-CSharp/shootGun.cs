using System;
using UnityEngine;

[Serializable]
public class shootGun : MonoBehaviour
{
	public LayerMask layerMask;

	public GameObject SeeRay1;

	public GameObject Granny;

	public GameObject momSpider;

	public GameObject player;

	public GameObject playerShootAnim;

	public bool shooting;

	public GameObject shootButton;

	public int power;

	public GameObject ammoCheckHolder;

	public GameObject shotgunAnim;

	public GameObject soundHolder;

	public Transform grannyHearSound;

	public GameObject noiceDP;

	public Vector3 velocity;

	public GameObject Spider;

	public GameObject rat1;

	public GameObject rat2;

	public GameObject crow;

	public GameObject crowBurDead;

	public GameObject crowEatDead;

	public GameObject Skjutplatta;

	public bool shootingOnGascan;

	public GameObject littleSanta;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
