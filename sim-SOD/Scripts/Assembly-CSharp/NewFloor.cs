using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

public class NewFloor : Controller
{
	public delegate void SaveDataComplete(NewFloor floor, FloorSaveData data);

	[CompilerGenerated]
	private sealed class _003CGenerateFloorSaveData_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NewFloor _003C_003E4__this;

		private List<NewAddress>.Enumerator _003C_003E7__wrap1;

		private NewAddress _003Cad_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CGenerateFloorSaveData_003Ed__44(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("ID")]
	public int floorID;

	public static int assignID;

	[Header("Location")]
	public NewBuilding building;

	public int floor;

	public int assignResidence;

	[Header("Floor Contents")]
	public List<NewAddress> addresses;

	public NewAddress lobbyAddress;

	public NewAddress outsideAddress;

	public Dictionary<Vector2Int, NewTile> tileMap;

	public Dictionary<Vector2Int, NewNode> nodeMap;

	public List<NewWall> buildingEntrances;

	public List<Interactable> securityDoors;

	public bool alarmLockdown;

	public int layoutIndex;

	public int breakerSecurityID;

	public int breakerDoorsID;

	public int breakerLightsID;

	[NonSerialized]
	public Interactable breakerSecurity;

	[NonSerialized]
	public Interactable breakerDoors;

	[NonSerialized]
	public Interactable breakerLights;

	public float breakerSecurityState;

	public float breakerLightsState;

	public float breakerDoorsState;

	[Header("Details")]
	[Tooltip("The name of the floor data")]
	public string floorName;

	[Tooltip("The size of this configuration in 7x7 cells")]
	public Vector2 size;

	[Tooltip("The default floor height (voxel units == 0.1)")]
	public int defaultFloorHeight;

	[Tooltip("The default ceiling height (voxel units == 0.1)")]
	public int defaultCeilingHeight;

	public bool isEchelons;

	[Header("Map")]
	public MapDuctsButtonController mapDucts;

	[Header("Save Data")]
	public int maxDuctExtrusion;

	private FloorSaveData saveData;

	[Header("Debug")]
	public List<NewRoom> frontWindowDebug;

	public List<NewRoom> rearWindowDebug;

	public List<NewRoom> leftWindowDebug;

	public List<NewRoom> rightWindowDebug;

	public event SaveDataComplete OnSaveDataComplete
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Setup(int newFloor, NewBuilding newBuilding, string newName, Vector2 newSize, int newFloorHeight, int newCeilingHeight)
	{
	}

	public void Load(CitySaveData.FloorCitySave data, NewBuilding newBuilding)
	{
	}

	public void AddNewAddress(NewAddress newAddress)
	{
	}

	public void RemoveAddress(NewAddress newAddress)
	{
	}

	public void GetSaveData()
	{
	}

	[IteratorStateMachine(typeof(_003CGenerateFloorSaveData_003Ed__44))]
	private IEnumerator GenerateFloorSaveData()
	{
		return null;
	}

	public void LoadDataToFloor(FloorSaveData savedData)
	{
	}

	public void LoadVariation(NewAddress currentAdd, AddressLayoutVariation newVar)
	{
	}

	public void FinalizeLoadingIn()
	{
	}

	public NewAddress CreateNewAddress(LayoutConfiguration newRoomConfig, DesignStylePreset newDesign)
	{
		return null;
	}

	public void ConnectNodesOnFloor()
	{
	}

	public void AssignWindowUVData(bool debug = false)
	{
	}

	public void GenerateAirDucts()
	{
	}

	public void AddSecurityDoor(Interactable newInteractable)
	{
	}

	public NewAddress GetLobbyAddress()
	{
		return null;
	}

	public void SetAlarmLockdown(bool newVal, NewAddress addressOnly = null)
	{
	}

	public CitySaveData.FloorCitySave GenerateSaveData()
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugWindowUVAssign()
	{
	}

	public void SetBreakerSecurity(Interactable newObject)
	{
	}

	public void SetBreakerLights(Interactable newObject)
	{
	}

	public void SetBreakerDoors(Interactable newObject)
	{
	}

	public Interactable GetBreakerSecurity()
	{
		return null;
	}

	public Interactable GetBreakerLights()
	{
		return null;
	}

	public Interactable GetBreakerDoors()
	{
		return null;
	}
}
