using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

[AddComponentMenu("Factory/Production Belt")]
public class T_ConveyorBelt : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class ConveyorBeltSaveData
	{
	}

	[CompilerGenerated]
	private sealed class _003CServer_WaitAndExit_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public T_Item item;

		public T_ConveyorBelt _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CServer_WaitAndExit_003Ed__21(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			T_ConveyorBelt t_ConveyorBelt = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(duration);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (item == null || item.currentBelt != t_ConveyorBelt)
				{
					return false;
				}
				t_ConveyorBelt.itemsOnBelt.Remove(item);
				if (t_ConveyorBelt.nextBelt != null)
				{
					Vector3 pointWorld = t_ConveyorBelt.GetPointWorld(item.currentBeltLaneIndex, 1f);
					t_ConveyorBelt.nextBelt.GetClosestLaneAndT(pointWorld, xzOnly: true, out var laneIndex, out var tOnLane);
					t_ConveyorBelt.nextBelt.Server_RegisterItem(item, tOnLane, laneIndex);
					return false;
				}
				item.Server_RemoveFromBelt();
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[Header("Spline Container")]
	public SplineContainer spline;

	[Header("Settings")]
	[Min(0.01f)]
	public float speed = 2f;

	[Header("Connection Points")]
	[Tooltip("Çıkış noktaları (genelde 1 tane)")]
	public Transform[] exitPoints;

	[Tooltip("Giriş noktaları (birden fazla olabilir)")]
	public Transform[] entryPoints;

	[Header("Auto Connection")]
	public float connectionRadius = 0.2f;

	private readonly List<T_Item> itemsOnBelt = new List<T_Item>();

	public static readonly List<T_ConveyorBelt> AllBelts = new List<T_ConveyorBelt>();

	private T_ConveyorBelt nextBelt;

	private int nextBeltEntryIndex;

	private readonly List<T_ConveyorBelt> previousBelts = new List<T_ConveyorBelt>();

	private string UniqueConveyorBeltId
	{
		get
		{
			BuildingObject component = GetComponent<BuildingObject>();
			if (!(component != null))
			{
				return string.Empty;
			}
			return component.UniqueBuildingId;
		}
	}

	public string SaveID => "conveyor-belt-" + UniqueConveyorBeltId;

	public bool IsShared => false;

	public Type SaveType => typeof(ConveyorBeltSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	private void OnEnable()
	{
		if (!AllBelts.Contains(this))
		{
			AllBelts.Add(this);
		}
		RefreshAllConnections();
	}

	private void OnDisable()
	{
		AllBelts.Remove(this);
		foreach (T_ConveyorBelt allBelt in AllBelts)
		{
			if (allBelt != null && allBelt.nextBelt == this)
			{
				allBelt.nextBelt = null;
				allBelt.nextBeltEntryIndex = 0;
			}
		}
		foreach (T_ConveyorBelt allBelt2 in AllBelts)
		{
			if (allBelt2 != null)
			{
				allBelt2.previousBelts.Remove(this);
			}
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		StartCoroutine(Co_SubscribeToSaveSystem());
	}

	private IEnumerator Co_SubscribeToSaveSystem()
	{
		BuildingObject buildingObj = GetComponent<BuildingObject>();
		while (buildingObj == null || string.IsNullOrEmpty(buildingObj.UniqueBuildingId))
		{
			if (buildingObj == null)
			{
				buildingObj = GetComponent<BuildingObject>();
			}
			yield return null;
		}
		SaveLoadManager.Subscribe(this, 50);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		SaveLoadManager.Unsubscribe(this);
	}

	public void OnPlaced()
	{
		spline.gameObject.SetActive(value: true);
		RefreshAllConnections();
	}

	public void OnLifted()
	{
		spline.gameObject.SetActive(value: false);
	}

	private static void RefreshAllConnections()
	{
		foreach (T_ConveyorBelt allBelt in AllBelts)
		{
			if (!(allBelt == null))
			{
				allBelt.nextBelt = null;
				allBelt.nextBeltEntryIndex = 0;
				allBelt.previousBelts.Clear();
			}
		}
		foreach (T_ConveyorBelt allBelt2 in AllBelts)
		{
			if (!(allBelt2 == null))
			{
				allBelt2.FindNextBelt();
			}
		}
	}

	private void FindNextBelt()
	{
		nextBelt = null;
		nextBeltEntryIndex = 0;
		if (exitPoints == null || exitPoints.Length == 0)
		{
			return;
		}
		float num = connectionRadius * connectionRadius;
		Transform[] array = exitPoints;
		foreach (Transform transform in array)
		{
			if (transform == null)
			{
				continue;
			}
			Vector3 position = transform.position;
			foreach (T_ConveyorBelt allBelt in AllBelts)
			{
				if (allBelt == this || allBelt.entryPoints == null)
				{
					continue;
				}
				BuildingObject component = allBelt.GetComponent<BuildingObject>();
				if (component != null && !component.IsPlaced)
				{
					continue;
				}
				for (int j = 0; j < allBelt.entryPoints.Length; j++)
				{
					Transform transform2 = allBelt.entryPoints[j];
					if (!(transform2 == null))
					{
						Vector3 position2 = transform2.position;
						float sqrMagnitude = (new Vector2(position.x, position.z) - new Vector2(position2.x, position2.z)).sqrMagnitude;
						if (sqrMagnitude < num)
						{
							num = sqrMagnitude;
							nextBelt = allBelt;
							nextBeltEntryIndex = j;
						}
					}
				}
			}
		}
		if (nextBelt != null && !nextBelt.previousBelts.Contains(this))
		{
			nextBelt.previousBelts.Add(this);
		}
	}

	[Server]
	public void Server_RegisterItem(T_Item item, float startT = 0f, int laneIndex = 0)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_ConveyorBelt::Server_RegisterItem(T_Item,System.Single,System.Int32)' called when server was not active");
		}
		else if (!(item == null))
		{
			if (!itemsOnBelt.Contains(item))
			{
				itemsOnBelt.Add(item);
			}
			item.currentBelt = this;
			item.currentBeltLaneIndex = laneIndex;
			item.currentT = startT;
			item.NetworkcurrentBeltNetId = base.netIdentity.netId;
			float duration = (1f - startT) / speed;
			double time = NetworkTime.time;
			item.Rpc_StartConveyorMove(base.netIdentity.netId, laneIndex, startT, 1f, time, duration);
			StartCoroutine(Server_WaitAndExit(item, duration));
		}
	}

	[IteratorStateMachine(typeof(_003CServer_WaitAndExit_003Ed__21))]
	[Server]
	private IEnumerator Server_WaitAndExit(T_Item item, float duration)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator T_ConveyorBelt::Server_WaitAndExit(T_Item,System.Single)' called when server was not active");
			return null;
		}
		return new _003CServer_WaitAndExit_003Ed__21(0)
		{
			_003C_003E4__this = this,
			item = item,
			duration = duration
		};
	}

	public T_ConveyorBelt GetNextBelt()
	{
		return nextBelt;
	}

	public List<T_ConveyorBelt> GetPreviousBelts()
	{
		return previousBelts;
	}

	public bool HasNextBelt()
	{
		return nextBelt != null;
	}

	public bool HasPreviousBelts()
	{
		return previousBelts.Count > 0;
	}

	public int GetLaneCount()
	{
		if (spline == null)
		{
			return 0;
		}
		if (spline.Splines != null && spline.Splines.Count > 0)
		{
			return spline.Splines.Count;
		}
		if (spline.Spline == null)
		{
			return 0;
		}
		return 1;
	}

	public bool EvaluateOnSpline(int laneIndex, float t, out float3 pos, out float3 tan)
	{
		pos = float3.zero;
		tan = float3.zero;
		if (spline == null)
		{
			return false;
		}
		Spline lane = GetLane(laneIndex);
		if (lane == null)
		{
			return false;
		}
		lane.Evaluate(t, out var position, out var tangent, out var _);
		pos = spline.transform.TransformPoint(position);
		tan = spline.transform.TransformDirection(tangent).normalized;
		return true;
	}

	public Vector3 GetPointWorld(int laneIndex, float t)
	{
		Spline lane = GetLane(laneIndex);
		if (lane == null)
		{
			return base.transform.position;
		}
		lane.Evaluate(t, out var position, out var _, out var _);
		return spline.transform.TransformPoint(position);
	}

	private Spline GetLane(int laneIndex)
	{
		IReadOnlyList<Spline> splines = spline.Splines;
		if (splines != null && splines.Count > 0)
		{
			return splines[Mathf.Clamp(laneIndex, 0, splines.Count - 1)];
		}
		return spline.Spline;
	}

	public static T_ConveyorBelt FindClosestBelt(Vector3 worldPos, float maxDistance, out float tOnSpline, out int laneIndex)
	{
		tOnSpline = 0f;
		laneIndex = 0;
		T_ConveyorBelt result = null;
		float num = maxDistance * maxDistance;
		foreach (T_ConveyorBelt allBelt in AllBelts)
		{
			if (allBelt == null)
			{
				continue;
			}
			BuildingObject component = allBelt.GetComponent<BuildingObject>();
			if (!(component != null) || component.IsPlaced)
			{
				allBelt.GetClosestLaneAndT(worldPos, xzOnly: false, out var laneIndex2, out var tOnLane);
				float sqrMagnitude = (allBelt.GetPointWorld(laneIndex2, tOnLane) - worldPos).sqrMagnitude;
				if (sqrMagnitude <= num)
				{
					num = sqrMagnitude;
					result = allBelt;
					tOnSpline = tOnLane;
					laneIndex = laneIndex2;
				}
			}
		}
		return result;
	}

	public void GetClosestLaneAndT(Vector3 worldPos, bool xzOnly, out int laneIndex, out float tOnLane)
	{
		laneIndex = 0;
		tOnLane = 0f;
		float num = float.MaxValue;
		int laneCount = GetLaneCount();
		if (laneCount == 0)
		{
			return;
		}
		for (int i = 0; i < laneCount; i++)
		{
			Spline lane = GetLane(i);
			if (lane == null)
			{
				continue;
			}
			float num2 = float.MaxValue;
			float num3 = 0f;
			for (int j = 0; j < 32; j++)
			{
				float num4 = (float)j / 31f;
				lane.Evaluate(num4, out var position, out var _, out var _);
				Vector3 vector = spline.transform.TransformPoint(position);
				float num5 = (xzOnly ? (new Vector2(vector.x, vector.z) - new Vector2(worldPos.x, worldPos.z)).sqrMagnitude : (vector - worldPos).sqrMagnitude);
				if (num5 < num2)
				{
					num2 = num5;
					num3 = num4;
				}
			}
			if (num2 < num)
			{
				num = num2;
				laneIndex = i;
				tOnLane = num3;
			}
		}
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		ConveyorBeltSaveData result = new ConveyorBeltSaveData();
		UnityEngine.Debug.Log("[T_ConveyorBelt] Save - ID: " + UniqueConveyorBeltId);
		return result;
	}

	public Task OnLoad(object value)
	{
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		if (!(value is ConveyorBeltSaveData))
		{
			UnityEngine.Debug.LogWarning("[T_ConveyorBelt] OnLoad - Invalid data type for conveyor belt: " + UniqueConveyorBeltId);
			return Task.CompletedTask;
		}
		UnityEngine.Debug.Log("[T_ConveyorBelt] Load - ID: " + UniqueConveyorBeltId);
		return Task.CompletedTask;
	}

	public override bool Weaved()
	{
		return true;
	}
}
