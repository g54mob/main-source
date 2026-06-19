using System.Collections.Generic;
using Aggro.Core;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

[UpdateInGroup(typeof(SimulationLateSystemGroup), UpdatePriority.Normal)]
public class NetworkBoxWanderSystem : EntitySystemBase
{
	private ObjectQuery<VehicleController> _controllers;

	private ObjectQuery<BoxWander> _wanders;

	private static List<Vector3> _playerPositions = new List<Vector3>();

	protected override void OnCreateSystem()
	{
		_controllers = base.entityManager.CreateObjectQuery<VehicleController>();
		_wanders = base.entityManager.CreateObjectQuery<BoxWander>();
	}

	protected override void OnUpdateSystem()
	{
		if (!NetworkServer.active || !GameUtil.isRun)
		{
			return;
		}
		_playerPositions.Clear();
		_controllers.Run();
		_wanders.Run();
		for (int i = 0; i < _controllers.count; i++)
		{
			_playerPositions.Add(_controllers[i].rb.position);
		}
		if (_playerPositions.Count == 0)
		{
			return;
		}
		for (int j = 0; j < _wanders.count; j++)
		{
			BoxWander boxWander = _wanders[j];
			PredictedRigidbodyGroup predictedRigidbodyGroup = boxWander.entity.predictedRigidbodyGroup;
			if (predictedRigidbodyGroup.serverGroup.Count > 0 && predictedRigidbodyGroup.IsMoving() && boxWander.isWandering)
			{
				Vector3 position = predictedRigidbodyGroup.entity.rigidbody.position;
				float num = float.MaxValue;
				for (int k = 0; k < _playerPositions.Count; k++)
				{
					float sqrMagnitude = (_playerPositions[k] - position).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
					}
				}
				if (num <= 9f)
				{
					predictedRigidbodyGroup.dynamicMinSyncInterval = 0f;
					continue;
				}
				if (num >= 225f)
				{
					predictedRigidbodyGroup.dynamicMinSyncInterval = 0.5f;
					continue;
				}
				float num2 = math.sqrt(num);
				predictedRigidbodyGroup.dynamicMinSyncInterval = math.lerp(0f, 0.5f, (num2 - 3f) / 12f);
			}
			else
			{
				predictedRigidbodyGroup.dynamicMinSyncInterval = 0.5f;
			}
		}
	}
}
