using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public class WaypointInitializationSystem : SystemBase
{
	public struct CableEndpoint
	{
		public CableLink.TypeOfLink Type;

		public Vector3 Position;

		public int CustomerID;

		public string SwitchID;

		public string ServerID;
	}

	public struct CableInfo
	{
		public int CableID;

		public CableEndpoint StartPoint;

		public CableEndpoint EndPoint;

		public List<Vector3> Waypoints;

		public float MaxSpeed;

		public Entity ForwardSpawner;

		public Entity BackwardSpawner;
	}

	private struct CustomerNetworkInfo
	{
		public HashSet<string> Bases;

		public HashSet<string> Servers;

		public CustomerNetworkInfo(bool initialize)
		{
			Bases = null;
			Servers = null;
		}
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	private struct TypeHandle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadNetworkStateCoroutine_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WaypointInitializationSystem _003C_003E4__this;

		public NetworkSaveData networkData;

		public List<RackPosition> allRackPositions;

		public int saveVersion;

		private PacketSpawnerComponent _003CprefabComponent_003E5__2;

		private List<NetworkSwitch> _003CnetworkSwitches_003E5__3;

		private CableLink[] _003CallCableLinks_003E5__4;

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
		public _003CLoadNetworkStateCoroutine_003Ed__12(int _003C_003E1__state)
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

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private CablePositions cablePositions;

	private bool isLoading;

	private bool needsToEvaluateRoutes;

	private readonly Dictionary<int, float> lastFinalCableSpeeds;

	private Dictionary<int, CableInfo> cables;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1822386706_0;

	private EntityQuery __query_1822386706_1;

	private EntityQuery __query_1822386706_2;

	private EntityQuery __query_1822386706_3;

	public static WaypointInitializationSystem Instance { get; private set; }

	public float GetCableCurrentSpeed(int cableId)
	{
		return 0f;
	}

	public List<CableInfo> GetAllCables()
	{
		return null;
	}

	public CableInfo? GetCableInfo(int cableId)
	{
		return null;
	}

	public void LoadNetworkState(NetworkSaveData networkData, List<RackPosition> allRackPositions, int saveVersion)
	{
	}

	[IteratorStateMachine(typeof(_003CLoadNetworkStateCoroutine_003Ed__12))]
	private IEnumerator LoadNetworkStateCoroutine(NetworkSaveData networkData, List<RackPosition> allRackPositions, int saveVersion)
	{
		return null;
	}

	private void ClearNetworkState()
	{
	}

	[Preserve]
	protected override void OnCreate()
	{
	}

	[Preserve]
	protected override void OnUpdate()
	{
	}

	private void CreateCableWithSpawners(int cableId, List<Vector3> positions)
	{
	}

	private void CreateSpawnersForCable(ref CableInfo cableInfo)
	{
	}

	private void CreateSpawnersForCable(ref CableInfo cableInfo, PacketSpawnerComponent prefabComponent)
	{
	}

	private Entity CreateSpawner(List<Vector3> waypoints, Vector3 spawnerPos, int cableId, int customerID, PacketSpawnerComponent prefabComponent, bool isForward)
	{
		return default(Entity);
	}

	public void UpdateServerCustomerID(string serverID, int customerID)
	{
	}

	public void EvaluateAllRoutes()
	{
	}

	private void ActivateSpawnersForCable(CableInfo cable, float finalSpeed, List<(int customerId, List<string> path)> allRoutes)
	{
	}

	private void UpdateAllUI(Dictionary<int, CustomerNetworkInfo> customerInfo, List<(int customerId, List<string> path)> allRoutes, Dictionary<int, float> finalCableSpeeds, Dictionary<int, float> cableLoad)
	{
	}

	private bool IsCableConnecting(CableInfo cable, string from, string to)
	{
		return false;
	}

	private CableInfo? FindCableConnecting(int cableId)
	{
		return null;
	}

	private CableInfo? FindCableForDevice(string deviceName)
	{
		return null;
	}

	private float GetServerProcessingSpeed(string serverName)
	{
		return 0f;
	}

	private void ActivateSpawnerOnCable(Entity spawnerEntity, float speed, int customerId)
	{
	}

	private Dictionary<int, CustomerNetworkInfo> GetCustomerRoutes()
	{
		return null;
	}

	private void ResetAllSpawners()
	{
	}

	private CableInfo? FindCableConnecting(string from, string to)
	{
		return null;
	}

	private string GetDeviceName(CableEndpoint endpoint)
	{
		return null;
	}

	private void RegisterCableInNetworkMap(CableInfo cableInfo)
	{
	}

	public void OnCableRemoved(int cableId)
	{
	}

	private void SafelyDisposeSpawner(Entity spawnerEntity, int cableId, string direction)
	{
	}

	public bool DoesCableServeMultipleCustomers(int cableId)
	{
		return false;
	}

	private HashSet<int> GetCustomersUsingCable(CableInfo cable)
	{
		return null;
	}

	private bool IsCableInRoute(CableInfo cable, List<string> route)
	{
		return false;
	}

	public void CleanUpSystem()
	{
	}

	[Preserve]
	protected override void OnDestroy()
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
	}

	protected override void OnCreateForCompiler()
	{
	}

	[Preserve]
	public WaypointInitializationSystem()
	{
	}
}
