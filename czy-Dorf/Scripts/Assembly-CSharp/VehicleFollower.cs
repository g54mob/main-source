using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VehicleFollower : Vehicle
{
	[SerializeField]
	private Vehicle followedVehicle;

	[SerializeField]
	public float followDistance;

	private Vector3 lastPathPoint = Vector3.zero;

	protected void Update()
	{
		float num = 0f;
		List<Vector3> list = Enumerable.ToList(followedVehicle.lastPositions);
		list.Add(followedVehicle.transform.position);
		list.Reverse();
		base.Speed = followedVehicle.Speed;
		for (int i = 1; i < list.Count; i++)
		{
			float num2 = num + Vector3.Distance(list[i], list[i - 1]);
			if (num2 >= followDistance)
			{
				Vector3 nextPathPointPosition = Vector3.MoveTowards(list[i - 1], list[i], followDistance - num);
				MoveAndRotateTowards(nextPathPointPosition);
				if (list[i] != lastPathPoint)
				{
					lastPathPoint = list[i];
					StoreLastPathPosition(lastPathPoint);
				}
				break;
			}
			num = num2;
		}
	}

	public void Follow(Vehicle vehicle)
	{
		followedVehicle = vehicle;
		initialTile = followedVehicle.initialTile;
		Vehicle vehicle2 = followedVehicle;
		vehicle2.OnCurrentTileUpdated = (Action<Tile>)Delegate.Combine(vehicle2.OnCurrentTileUpdated, new Action<Tile>(base.UpdateCurrentTile));
	}
}
