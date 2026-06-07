using System;
using System.Collections.Generic;
using DV.OriginShift;
using DV.Utils;
using UnityEngine;

public class WorldMover : SingletonBehaviour<WorldMover>
{
	private static readonly int shaderProperty = Shader.PropertyToID("_OriginShiftOffset");

	public bool movingEnabled = true;

	public AWorldMoverPlayerTracker playerTracker;

	[Tooltip("Distance of playerTracker from world origin after which origin shift is triggered")]
	public float moveRange = 100f;

	[HideInInspector]
	public List<Transform> objectsToMove = new List<Transform>();

	[SerializeField]
	private Transform originShiftParent;

	private int lastFrameMoved;

	public static Vector3 currentMove => OriginShift.currentMove;

	public static Transform OriginShiftParent
	{
		get
		{
			if (!(SingletonBehaviour<WorldMover>.Instance == null))
			{
				return OriginShift.parentContainer;
			}
			return null;
		}
	}

	public bool MovedThisFrame => Time.frameCount == lastFrameMoved;

	public event Action<Vector3, Vector3> AboutToMoveWorld;

	public event Action<WorldMover, Vector3> WorldMoved;

	public new static string AllowAutoCreate()
	{
		return null;
	}

	protected override void Initialize()
	{
		OriginShift.currentMove = Vector3.zero;
		OriginShift.parentContainer = originShiftParent;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		OriginShift.currentMove = Vector3.zero;
	}

	private void Update()
	{
		if (movingEnabled && !(playerTracker == null) && playerTracker.IsSynced())
		{
			ForceMove();
		}
	}

	public void SetOriginShiftParent(Transform newParent)
	{
		originShiftParent = newParent;
		OriginShift.parentContainer = newParent;
	}

	public void AddObjectToMove(Transform objectToMove)
	{
		objectsToMove.Add(objectToMove);
	}

	public void ForceMove()
	{
		Vector3 position = playerTracker.GetTrackerTransform().position;
		if (Mathf.Abs(position.x) > moveRange || Mathf.Abs(position.z) > moveRange)
		{
			float x = Mathf.Floor(position.x / moveRange) * moveRange;
			float z = Mathf.Floor(position.z / moveRange) * moveRange;
			Vector3 moveVector = new Vector3(x, 0f, z);
			MoveWorld(moveVector);
		}
	}

	public void MoveObject(Transform t, Vector3 moveVector)
	{
		t.position -= moveVector;
	}

	public void MoveWorld(Vector3 moveVector)
	{
		Vector3 arg = currentMove - moveVector;
		this.AboutToMoveWorld?.Invoke(arg, moveVector);
		OriginShift.currentMove = arg;
		if (playerTracker != null && (bool)playerTracker.GetActualPlayer() && playerTracker.ShouldApplyOriginShift())
		{
			MoveObject(playerTracker.GetActualPlayer(), moveVector);
		}
		foreach (Transform item in objectsToMove)
		{
			if (item != null)
			{
				MoveObject(item, moveVector);
			}
		}
		if ((bool)originShiftParent)
		{
			MoveObject(originShiftParent, moveVector);
		}
		Shader.SetGlobalVector(shaderProperty, new Vector4(currentMove.x, currentMove.z, 0f, 0f));
		Physics.SyncTransforms();
		lastFrameMoved = Time.frameCount;
		this.WorldMoved?.Invoke(this, moveVector);
	}
}
