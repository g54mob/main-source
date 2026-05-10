using System;
using CTS.BBT;
using CTS.Core;
using CTS.GridSystem;
using Unity.AI.Navigation;
using UnityEngine;

namespace CTS
{
	public class Room : MonoBehaviour
	{
		public enum EStatus
		{
			Unavailable = 0,
			Disabled = 1,
			Enabled = 2
		}

		[SerializeField]
		private bool _rebakeNavmesh = true;

		[SerializeField]
		private bool _selectable = true;

		[SerializeField]
		private bool _requiredToOpenBar;

		private NavMeshSurface _navmesh;

		private SelectableObject _selectionData;

		private LockToggle _barOpenToggle;

		private LockToggle _selectionToggle;

		public string Name { get; private set; }

		[field: SerializeField]
		public bool IsExterior { get; private set; }

		[field: SerializeField]
		[field: NavArea(false)]
		public int RoomPriority { get; private set; }

		[field: SerializeField]
		public EStatus Status { get; private set; }

		[field: SerializeField]
		public bool VisibleRoom { get; private set; }

		[field: SerializeField]
		public bool VisibleRoomGrid { get; private set; }

		public Floor AssignedFloor { get; private set; }

		public RoomAppeal Appeal { get; private set; }

		public RoomVisuals Visuals { get; private set; }

		public GridController[] GridControllers { get; private set; }

		public bool Active => Status == EStatus.Enabled;

		public bool Available => Status != EStatus.Unavailable;

		public static event Action AnyRoomChange;

		public event Action<bool> ActivatingRoom;

		public event Action<bool> SettingRoomVisibility;

		public event Action<EStatus> OnStatusChange;

		private void Awake()
		{
			Name = base.name;
			Appeal = GetComponent<RoomAppeal>();
			Visuals = GetComponent<RoomVisuals>();
			_navmesh = GetComponent<NavMeshSurface>();
			GridControllers = GetComponentsInChildren<GridController>(includeInactive: true);
			if ((bool)_selectionData)
			{
				_selectionToggle = new LockToggle(_selectionData);
			}
			DoSetRoomStatus(Status);
			SetRoomGridVisibility(Available && VisibleRoom && FurnitureShop.IsOpen);
			if ((bool)AssignedFloor)
			{
				if ((bool)_selectionData)
				{
					_selectionToggle.SetLock(!AssignedFloor.VisibleFloor);
				}
				SetRoomVisibility(AssignedFloor.VisibleFloor);
				AssignedFloor.ChangingFloorVisibility += SetRoomVisibility;
				AssignedFloor.ChangingFloorGridVisibility += SetRoomGridVisibility;
			}
		}

		private void Start()
		{
			if (_requiredToOpenBar)
			{
				_barOpenToggle = new LockToggle(CTSSingleton<LevelParameters>.Instance);
			}
		}

		private void OnDisable()
		{
			if ((bool)AssignedFloor)
			{
				AssignedFloor.ChangingFloorVisibility -= SetRoomVisibility;
			}
			if ((bool)AssignedFloor)
			{
				AssignedFloor.ChangingFloorGridVisibility -= SetRoomGridVisibility;
			}
		}

		public void AssignFloor(Floor p_floor)
		{
			if ((bool)AssignedFloor)
			{
				AssignedFloor.ChangingFloorVisibility -= SetRoomVisibility;
			}
			if ((bool)AssignedFloor)
			{
				AssignedFloor.ChangingFloorGridVisibility -= SetRoomGridVisibility;
			}
			AssignedFloor = p_floor;
			SetRoomVisibility(p_floor.VisibleFloor);
			if ((bool)AssignedFloor)
			{
				AssignedFloor.ChangingFloorVisibility += SetRoomVisibility;
			}
			if ((bool)AssignedFloor)
			{
				AssignedFloor.ChangingFloorGridVisibility += SetRoomGridVisibility;
			}
		}

		public void SetRoomVisibility(bool visible)
		{
			if (VisibleRoom != visible)
			{
				VisibleRoom = visible;
				if ((bool)_selectionData)
				{
					_selectionToggle.SetLock(!visible);
				}
				this.SettingRoomVisibility?.Invoke(visible);
				SetRoomGridVisibility(visible && FurnitureShop.IsOpen);
			}
		}

		public void SetRoomGridVisibility(bool p_visible)
		{
			GridController[] gridControllers = GridControllers;
			for (int i = 0; i < gridControllers.Length; i++)
			{
				gridControllers[i].ShowGrid(Available && p_visible);
			}
		}

		public Vector3 GetClosestVerticeOnRoomGrid(Vector3 p_worldPosition)
		{
			float num = float.PositiveInfinity;
			Vector3 result = Vector3.zero;
			GridController[] gridControllers = GridControllers;
			for (int i = 0; i < gridControllers.Length; i++)
			{
				Vector3 closestVerticeOnGrid = gridControllers[i].GetClosestVerticeOnGrid(p_worldPosition);
				float sqrMagnitude = (p_worldPosition - closestVerticeOnGrid).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = closestVerticeOnGrid;
				}
			}
			return result;
		}

		public void SetRoomStatus(EStatus status)
		{
			if (Status != status)
			{
				DoSetRoomStatus(status);
			}
		}

		private void DoSetRoomStatus(EStatus status)
		{
			if (Status == EStatus.Enabled)
			{
				this.ActivatingRoom?.Invoke(obj: false);
			}
			else if (status == EStatus.Enabled)
			{
				this.ActivatingRoom?.Invoke(obj: true);
			}
			Status = status;
			if ((bool)AssignedFloor)
			{
				SetRoomGridVisibility(AssignedFloor.VisibleFloorGrid);
			}
			if (_rebakeNavmesh && (bool)_navmesh)
			{
				_navmesh.defaultArea = ((!Active) ? 1 : RoomPriority);
				_navmesh.UpdateNavMesh(_navmesh.navMeshData);
			}
			if (_requiredToOpenBar && _barOpenToggle != null)
			{
				_barOpenToggle.SetLock(!Active);
			}
			this.OnStatusChange?.Invoke(Status);
		}
	}
}
