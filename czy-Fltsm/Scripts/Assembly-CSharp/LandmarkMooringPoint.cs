using System;
using System.Collections.Generic;
using PajamaLlama.Extensions;
using PajamaLlama.Math;
using PajamaLlama.Utilities;
using UnityEngine;

public class LandmarkMooringPoint : MooringPointBase
{
	[Header("Landmark mooring point")]
	[SerializeField]
	[Tooltip("Target the agent needs to move to to embark with a moored boat.")]
	private Target _embarkTarget;

	public Transform EntranceTransform => _entranceTransform;

	public Transform RopeAttachmentTransform => _ropeAttachmentPoint;

	public override bool IsAvailableForMooring => ReturnIsAvailableForMooring(Community.PlayerCommunity.ReturnAllBoats());

	public override bool IsInTown => false;

	private void Start()
	{
		base.EmbarkTarget = _embarkTarget;
		FinalUpdate.RegisterOneShot(ValidateClearence);
		if ((bool)base.EmbarkTarget && (bool)base.EmbarkTarget.PrimaryMarker)
		{
			base.EmbarkTarget.PrimaryMarker.AddToConstructionGraph(logWarning: false);
		}
	}

	protected override void FixedUpdate()
	{
		if (base.MooredBoat != null)
		{
			base.MooredBoat.transform.position = ReturnBoatPosition();
			base.MooredBoat.transform.rotation = MooringTransform.rotation;
		}
		base.FixedUpdate();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (base.EmbarkTarget != null && GameManager.GraphManager != null)
		{
			base.EmbarkTarget.PrimaryMarker.RemoveFromConstructionGraph();
		}
	}

	private void ValidateClearence()
	{
		if (!(base.MooringTarget.ReturnNode(Graph.Type.WaterSurface) is GridNode gridNode))
		{
			return;
		}
		byte b = 0;
		Boat[] boats = GameManager.Settings.BoatSettings.Boats;
		foreach (Boat obj in boats)
		{
			byte b2 = obj.Navigator.ComputeRequiredClearance();
			if (obj.Type == BoatType.SalvagingBoat && b < b2)
			{
				b = b2;
			}
		}
		if (b > gridNode.Clearance)
		{
			if (gridNode.TryReturnClosedNodeWithClearance(out var nodeWithClearence, b, GameManager.Settings.BoatSettings.MooringTargetClearanceSearchRange))
			{
				Vector3 position = base.MooringTarget.transform.position;
				position.x = nodeWithClearence.RootPosition2D.x;
				position.z = nodeWithClearence.RootPosition2D.y;
				base.MooringTarget.transform.position = position;
				Debug.LogException(new Exception($"LandmarkMooringPoint '{base.transform.HierarchyPathToString()}' MooringTarget position was updated to accomodate a clearance of {b}"));
			}
			else
			{
				Debug.LogException(new Exception($"LandmarkMooringPoint '{base.transform.HierarchyPathToString()}' does not fit the requiredClearance of {b}"));
			}
		}
	}

	private Vector3 ReturnBoatPosition()
	{
		return (MooringTransform.position + base.MooredBoat.MooringOffset).SetY(base.MooredBoat.transform.position.y);
	}

	private bool ReturnIsAvailableForMooring(List<Boat> boats)
	{
		bool flag = false;
		if (base.MooringTarget.ReturnNode(Graph.Type.WaterSurface) is GridNode gridNode)
		{
			foreach (Boat boat in boats)
			{
				if (gridNode.CanFitNavigator(boat.Navigator))
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			return base.IsAvailableForMooring;
		}
		return false;
	}

	public bool ReturnIsAvailableForMooring(Boat boat)
	{
		if (base.MooringTarget.ReturnNode(Graph.Type.WaterSurface) is GridNode gridNode && gridNode.CanFitNavigator(boat.Navigator))
		{
			return base.IsAvailableForMooring;
		}
		return false;
	}

	protected override void OnDrawGizmos()
	{
		base.OnDrawGizmos();
		GizmoHelper.DrawSphereWithLabel(_embarkTarget.transform.position, 0.1f, "Embark Position");
	}
}
