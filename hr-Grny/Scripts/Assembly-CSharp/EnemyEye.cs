using System;
using UnityEngine;

[Serializable]
public class EnemyEye : MonoBehaviour
{
	public LayerMask layerMask;

	public Transform myTransform;

	public Transform target;

	public Camera cam;

	public GameObject granny;

	public float seeRange;

	public GameObject playerCrouch;

	public bool seePlayer;

	public Transform targetR;

	public bool seePlayerR;

	public Transform targetL;

	public bool seePlayerL;

	public float SeeAngle;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
