using System;
using UnityEngine;

public class Workall : UnitManager
{
	public enum STATE
	{
		IDLE = 0,
		ACQUIRING = 1,
		DELIVERING = 2
	}

	public class DispatchRequest
	{
		public WareRequestOld wareRequest;

		public Ware ware;

		public DispatchRequest(WareRequestOld wareRequest, Ware ware)
		{
		}
	}

	[NonSerialized]
	public STATE currentState;

	[NonSerialized]
	public DispatchRequest dispatchRequest;

	[NonSerialized]
	public Ware carriedWare;

	private Vector3 currentVelocity;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void GameUpdate()
	{
	}

	private void SetCurrentState(STATE state)
	{
	}

	private float GetHeightOfTarget(Vector3 targetPos)
	{
		return 0f;
	}

	public void Dispatch(WareRequestOld wareRequest, Ware ware)
	{
	}

	protected override void OnMoveComplete()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}
}
