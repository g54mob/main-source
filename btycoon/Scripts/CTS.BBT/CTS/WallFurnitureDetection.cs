using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.Furnitures;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class WallFurnitureDetection : MonoBehaviour
	{
		private Furniture _furniture;

		[SerializeField]
		private LayerMask _wallLayer;

		[SerializeField]
		private LayerMask _obstaclePlacementLayer = 16384;

		private Transform[] _wallDetectionPoints;

		[SerializeField]
		private bool _testSendAlwaysTrue;

		public bool OnWall { get; private set; }

		public event Action<bool> OnWallChanged;

		private void Awake()
		{
			_furniture = GetComponentInParent<Furniture>();
			_wallDetectionPoints = new Transform[base.transform.childCount];
			for (int i = 0; i < base.transform.childCount; i++)
			{
				_wallDetectionPoints[i] = base.transform.GetChild(i);
			}
		}

		public bool TryGetWalls(out List<BuildingWall> walls)
		{
			bool walls2 = GetWalls(out walls);
			OnWall = walls2;
			return OnWall;
		}

		private bool GetWalls(out List<BuildingWall> walls)
		{
			walls = new List<BuildingWall>();
			if (_testSendAlwaysTrue)
			{
				return true;
			}
			SetDirection();
			for (int i = 0; i < _wallDetectionPoints.Length; i++)
			{
				if (Physics.Raycast(_wallDetectionPoints[i].position, _wallDetectionPoints[i].forward, 0.1f, _obstaclePlacementLayer))
				{
					return false;
				}
				if (!Physics.Raycast(_wallDetectionPoints[i].position, _wallDetectionPoints[i].forward, out var hitInfo, 0.1f, _wallLayer))
				{
					return false;
				}
				if (hitInfo.collider.TryGetComponent<BuildingWall>(out var component) && !walls.Contains(component))
				{
					walls.Add(component);
				}
			}
			return true;
		}

		private void SetDirection()
		{
			if (!MonoSingleton<FurniturePlacer>.InstanceExists())
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < _wallDetectionPoints.Length; j++)
				{
					if (Physics.Raycast(_wallDetectionPoints[j].position, _wallDetectionPoints[j].forward, 0.1f, _wallLayer))
					{
						return;
					}
				}
				MonoSingleton<FurniturePlacer>.Instance.RotateClockwiseNoSound();
			}
		}

		[Button("UpdatePointVisualGizmos", EButtonEnableMode.Editor)]
		private void UpdatePointVisualGizmos()
		{
			Transform[] array = new Transform[base.transform.childCount];
			for (int i = 0; i < base.transform.childCount; i++)
			{
				array[i] = base.transform.GetChild(i);
				if (!array[i].gameObject.TryGetComponent<WallFurnitureDetectionPoint>(out var _))
				{
					array[i].gameObject.AddComponent<WallFurnitureDetectionPoint>();
				}
			}
		}
	}
}
