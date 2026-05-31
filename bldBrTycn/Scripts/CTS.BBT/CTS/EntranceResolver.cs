using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class EntranceResolver : CTSBehaviour
	{
		private static readonly HashSet<BuildableDoor> _foundEntrances = new HashSet<BuildableDoor>();

		private static readonly HashSet<BuildableDoor> _doors = new HashSet<BuildableDoor>();

		private static readonly HashSet<BuildableDoor> _deletedDoors = new HashSet<BuildableDoor>();

		[SerializeField]
		private Transform _exitNavMeshCheck;

		[SerializeField]
		[NavArea(false)]
		private int _streetArea;

		[SerializeField]
		[NavArea(false)]
		private int _exteriorArea;

		[SerializeField]
		[NavArea(true)]
		private int _validEntranceAreas;

		[SerializeField]
		private bool _debug;

		private static int ExteriorArea;

		private static int ValidEntranceAreas;

		private NavMeshPath _dummyPath;

		private Coroutine _recalculationCoroutine;

		public static Transform ExitNavMeshCheck { get; private set; }

		public static event Action<int> EntranceCountChanged;

		public static event Action EntrancesChecked;

		public static bool EntranceExists(int areaMask)
		{
			_deletedDoors.Clear();
			bool result = false;
			foreach (BuildableDoor foundEntrance in _foundEntrances)
			{
				if (foundEntrance == null)
				{
					_deletedDoors.Add(foundEntrance);
				}
				else if (IsDoorValid(foundEntrance, areaMask))
				{
					result = true;
					break;
				}
			}
			ClearDeletedDoors();
			return result;
		}

		private static void ClearDeletedDoors()
		{
			int count = _foundEntrances.Count;
			foreach (BuildableDoor deletedDoor in _deletedDoors)
			{
				_doors.Remove(deletedDoor);
				_foundEntrances.Remove(deletedDoor);
			}
			if (count != _foundEntrances.Count)
			{
				EntranceResolver.EntranceCountChanged?.Invoke(_foundEntrances.Count);
			}
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			ExitNavMeshCheck = _exitNavMeshCheck;
			ExteriorArea = _exteriorArea;
			ValidEntranceAreas = _validEntranceAreas;
			_doors.Clear();
			_foundEntrances.Clear();
		}

		private static bool IsDoorValid(BuildableDoor door, int navMesh)
		{
			if (door.MainCell.LinkedRoom.NavArea.IsInMask(navMesh))
			{
				return true;
			}
			ConstructionCell neighborCellFromBuildable = door.MainCell.GetNeighborCellFromBuildable();
			if (!neighborCellFromBuildable)
			{
				return false;
			}
			return neighborCellFromBuildable.LinkedRoom.NavArea.IsInMask(navMesh);
		}

		public static Vector3 GetEntrancePoint(Vector3 position, int navMesh)
		{
			if (_foundEntrances.Count <= 0)
			{
				return Vector3.zero;
			}
			BuildableDoor nearest = _foundEntrances.GetNearest(position.ToHorizontal2D(), IsDoorValid, navMesh);
			ConstructionCell constructionCell = ((!(1 << nearest.MainCell.LinkedRoom.NavArea.Area).ExistsInMask(ValidEntranceAreas)) ? nearest.MainCell.GetNeighborCellFromBuildable() : nearest.MainCell);
			if (NavMesh.SamplePosition(constructionCell.transform.position, out var hit, 0.5f, -1))
			{
				return hit.position;
			}
			return Vector3.zero;
		}

		protected override void OnEnabled()
		{
			BuildablePlacementSystem.OnBuildablePlaced += OnBuildablePlaced;
			BuildableElement.Destroyed += OnBuildableDestroyed;
			NavMeshRebuilder.NavMeshRebuilt += OnNavMeshRebuilt;
		}

		protected override void OnDisabled()
		{
			BuildablePlacementSystem.OnBuildablePlaced -= OnBuildablePlaced;
			BuildableElement.Destroyed -= OnBuildableDestroyed;
			NavMeshRebuilder.NavMeshRebuilt -= OnNavMeshRebuilt;
		}

		private void OnDestroy()
		{
			_doors.Clear();
			_foundEntrances.Clear();
		}

		private void OnBuildablePlaced(BuildableElement element)
		{
			if (element is BuildableDoor { IsExteriorDoor: not false } buildableDoor)
			{
				_doors.Add(buildableDoor);
			}
			RecalculateAll();
		}

		private void OnBuildableDestroyed(BuildableElement element)
		{
			if (element is BuildableDoor buildableDoor)
			{
				_doors.Remove(buildableDoor);
				RemoveEntrance(buildableDoor);
			}
		}

		private void OnNavMeshRebuilt(NavMeshRebuildInfo rebuildInfo)
		{
			RecalculateAll();
		}

		private void RecalculateAll()
		{
			if (!base.gameObject.scene.isLoaded)
			{
				return;
			}
			if (_recalculationCoroutine != null)
			{
				base.gameObject.scene.StopCoroutine(_recalculationCoroutine);
			}
			_deletedDoors.Clear();
			foreach (BuildableDoor door in _doors)
			{
				UpdateDoorObstacle(door);
			}
			ClearDeletedDoors();
			_recalculationCoroutine = base.gameObject.scene.StartCoroutine(DelayedRecalculation());
		}

		private static void UpdateDoorObstacle(BuildableDoor door)
		{
			if (door == null || door.MainCell == null)
			{
				_deletedDoors.Clear();
				return;
			}
			door.SetBackObstacleActive(HasObstacle(door.MainCell));
			if ((bool)door.MainCell.GetNeighborCellFromBuildable())
			{
				door.SetFrontObstacleActive(HasObstacle(door.MainCell.GetNeighborCellFromBuildable()));
			}
			static bool HasObstacle(ConstructionCell cell)
			{
				if ((bool)cell.GetOppositeCellFromBuildable())
				{
					return cell.GetOppositeWallFromRotation(cell.BuildableRotation) == null;
				}
				return false;
			}
		}

		private IEnumerator DelayedRecalculation()
		{
			yield return Coroutines.WaitForSecondsUnscaled(0.6f);
			BuildableLinks.UpdateAll();
			_deletedDoors.Clear();
			foreach (BuildableDoor door in _doors)
			{
				if (door == null)
				{
					_deletedDoors.Add(door);
				}
				if (IsBuildableValidEntrance(door))
				{
					AddEntrance(door);
				}
				else
				{
					RemoveEntrance(door);
				}
			}
			ClearDeletedDoors();
			EntranceResolver.EntrancesChecked?.Invoke();
		}

		private void AddEntrance(BuildableDoor element)
		{
			int count = _foundEntrances.Count;
			_foundEntrances.Add(element);
			element.IsEntrance = true;
			if (count != _foundEntrances.Count)
			{
				EntranceResolver.EntranceCountChanged?.Invoke(_foundEntrances.Count);
			}
		}

		private void RemoveEntrance(BuildableDoor element)
		{
			int count = _foundEntrances.Count;
			_foundEntrances.Remove(element);
			element.IsEntrance = false;
			if (count != _foundEntrances.Count)
			{
				EntranceResolver.EntranceCountChanged?.Invoke(_foundEntrances.Count);
			}
		}

		private bool IsBuildableValidEntrance(BuildableDoor element)
		{
			if (element == null)
			{
				return false;
			}
			if (!element.IsExteriorDoor)
			{
				return false;
			}
			if (element.MainCell == null)
			{
				return false;
			}
			BuildingWall oppositeWallFromRotation = element.MainCell.GetNeighborCellFromBuildable().GetOppositeWallFromRotation(element.MainCell.BuildableRotation);
			if (oppositeWallFromRotation == null)
			{
				return false;
			}
			ConstructionCell constructionCell;
			if (element.MainCell.LinkedRoom.NavArea == _exteriorArea)
			{
				constructionCell = element.MainCell;
			}
			else
			{
				if (!(oppositeWallFromRotation.LinkedRoom.NavArea == _exteriorArea))
				{
					return false;
				}
				constructionCell = oppositeWallFromRotation.LinkedCell;
			}
			if (!(1 << element.MainCell.LinkedRoom.NavArea.Area).ExistsInMask(ValidEntranceAreas) && !(1 << oppositeWallFromRotation.LinkedRoom.NavArea.Area).ExistsInMask(ValidEntranceAreas))
			{
				return false;
			}
			Vector3 position = constructionCell.transform.position;
			Vector3 position2 = _exitNavMeshCheck.position;
			if (_debug)
			{
				Debug.DrawRay(position, Vector3.up, Color.blue, 5f);
				Debug.DrawRay(position2, Vector3.up, Color.red, 5f);
			}
			if (_dummyPath == null)
			{
				_dummyPath = new NavMeshPath();
			}
			if (!NavMesh.CalculatePath(position, position2, (1 << _exteriorArea) | (1 << _streetArea), _dummyPath))
			{
				return false;
			}
			if (_dummyPath.status != NavMeshPathStatus.PathComplete)
			{
				return false;
			}
			return true;
		}
	}
}
