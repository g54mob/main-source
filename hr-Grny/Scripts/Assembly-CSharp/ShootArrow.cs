using System;
using UnityEngine;

[Serializable]
public class ShootArrow : MonoBehaviour
{
	public GameObject SeeRay;

	public GameObject player;

	public GameObject gameController;

	public Rigidbody arrow;

	public Transform bulletSpawn;

	public bool shooting;

	public GameObject shootButton;

	public GameObject arrowCheckHolder;

	public GameObject laddad;

	public GameObject Oladdad;

	public GameObject Arrow;

	public GameObject soundHolder;

	public Vector3 velocity;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
