using System;
using System.Collections.Generic;
using UnityEngine;

public class Obj_TrainSystem : MonoBehaviour
{
	[Serializable]
	public class CartData
	{
		public Obj_TrainCart trainCart;

		[Range(0f, 1f)]
		public float startT;

		[HideInInspector]
		public float speed;

		[HideInInspector]
		public int currentIndex;

		[HideInInspector]
		public float t;

		public CartData()
		{
		}

		public CartData(Obj_TrainCart cart)
		{
		}
	}

	[SerializeField]
	private bool isTrainActivated;

	[SerializeField]
	private List<CartData> list_CartData;

	[SerializeField]
	private List<Obj_TrainRail> trainRails;

	[SerializeField]
	private bool doStopAtBase;

	[SerializeField]
	private float accleration;

	[SerializeField]
	private float maxSpeed;

	[SerializeField]
	private float stopLerpSpeed;

	private List<int> list_StartIndex;

	private bool isTrainRunning;

	private bool isLastFrameInBattle;

	public List<CartData> List_CartData => null;

	public List<Obj_TrainRail> TrainRails => null;

	public bool IsTrainRunning => false;

	private void Start()
	{
	}

	public void ToggleTrainActivate(bool isActive)
	{
	}

	private void Update()
	{
	}

	private void UpdateCartMovement(CartData cart, float deltaTime)
	{
	}

	private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
	{
		return default(Vector3);
	}

	private Obj_TrainRail GetClosestRail(Vector3 position, List<Obj_TrainRail> rails)
	{
		return null;
	}
}
