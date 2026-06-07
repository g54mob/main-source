using System;
using System.Collections.Generic;
using UnityEngine;

namespace LightTower
{
	public class EnemyMovement : MovementComponent, ISavable
	{
		private const float PATH_WAYPOINT_SQRDISTANCE_TRESHOLD = 0.01f;

		public Action onPathEndReached;

		[SerializeField]
		private PathTile currentPathTile;

		private Enemy enemy;

		private StatsComponent statsComponent;

		[Savable("currentPath", true, false)]
		private Path currentPath;

		[Savable("currentPathIdx", true, false)]
		private int currentPathIdx;

		[Savable("alreadyMovedDistance", true, false)]
		private float alreadyMovedDistance;

		[Savable("savedPathTilePosition", true, false)]
		private Vector2 savedPathTilePosition;

		public PathTile CurrentPathTile
		{
			get
			{
				return currentPathTile;
			}
			set
			{
				if ((bool)currentPathTile)
				{
					currentPathTile.CurrentEnemies.Remove(enemy);
				}
				currentPathTile = value;
				if ((bool)currentPathTile)
				{
					currentPathTile.CurrentEnemies.Add(enemy);
				}
			}
		}

		private Path CurrentPath
		{
			get
			{
				return currentPath;
			}
			set
			{
				currentPath = value;
				currentPathIdx = 1;
				alreadyMovedDistance = 0f;
			}
		}

		public override float Speed
		{
			get
			{
				return statsComponent.GetStat(EStats.MovementSpeed);
			}
			set
			{
				statsComponent.SetStat(EStats.MovementSpeed, value);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			enemy = GetComponent<Enemy>();
			statsComponent = GetComponent<StatsComponent>();
		}

		private void OnDestroy()
		{
			CurrentPathTile = null;
		}

		public override void Move(Vector3 direction, float tickTime, bool normalizeDirection = true)
		{
			if (!MovementEnabled)
			{
				return;
			}
			if (!currentPathTile)
			{
				Debug.LogWarning(base.name + " doesn't have a path tile assigned!");
				return;
			}
			if (CurrentPath == null)
			{
				CurrentPath = GetPath();
			}
			float num = Speed * tickTime;
			while (num >= currentPath.distanceToPosition[currentPathIdx] - alreadyMovedDistance)
			{
				num -= currentPath.distanceToPosition[currentPathIdx] - alreadyMovedDistance;
				alreadyMovedDistance = 0f;
				currentPathIdx++;
				if (CurrentPath.positions.Length <= currentPathIdx)
				{
					Vector3 position = currentPathTile.transform.position;
					CurrentPathTile = GetNextPathTile();
					CurrentPath = GetPath(position);
					if (CurrentPathTile == null)
					{
						onPathEndReached?.Invoke();
						return;
					}
				}
			}
			base.transform.position = currentPath.positions[currentPathIdx - 1] + (currentPath.positions[currentPathIdx] - currentPath.positions[currentPathIdx - 1]).normalized.XZ().XZ() * (num + alreadyMovedDistance);
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.LookRotation((currentPath.positions[currentPathIdx] - currentPath.positions[currentPathIdx - 1]).XZ().XZ()), base.RotationSpeed * Time.deltaTime);
			alreadyMovedDistance += num;
		}

		private Path GetPath()
		{
			return GetPath(null);
		}

		private Path GetPath(Vector3? referencePosition)
		{
			if (!currentPathTile)
			{
				return null;
			}
			if (referencePosition.HasValue)
			{
				return currentPathTile.GetPath(LTFunctionLibrary.GetOrientationBetweenPositions(currentPathTile.transform.position, referencePosition.Value));
			}
			return currentPathTile.GetPath(LTFunctionLibrary.GetOrientationBetweenPositions(currentPathTile.transform.position, base.transform.position));
		}

		private PathTile GetNextPathTile()
		{
			if (!currentPathTile)
			{
				return null;
			}
			return currentPathTile.GetNextPathTile(base.transform.position);
		}

		public void OnSave()
		{
			savedPathTilePosition = new Vector2(currentPathTile.transform.position.x, currentPathTile.transform.position.z);
		}

		public void OnPreLoad()
		{
		}

		public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
		{
			CurrentPathTile = LTFunctionLibrary.GetGrid().GetGridCell(Mathf.RoundToInt(savedPathTilePosition.x), Mathf.RoundToInt(savedPathTilePosition.y)).Tile as PathTile;
			if (data.ContainsKey("currentPath") && data["currentPath"] != null)
			{
				currentPath = new Path();
				currentPath.positions = (data["currentPath"] as Dictionary<string, object>)["positions"] as Vector3[];
				currentPath.distanceToPosition = (data["currentPath"] as Dictionary<string, object>)["distanceToPosition"] as float[];
			}
		}
	}
}
