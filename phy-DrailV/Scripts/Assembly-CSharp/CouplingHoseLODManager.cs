using UnityEngine;

public class CouplingHoseLODManager
{
	public enum LODLevel
	{
		Unloaded = 0,
		Visible_And_Reduced_Simulation = 1,
		Visible_And_Full_Simulation = 2
	}

	public const int DISTANCE_LOD0 = 15;

	public const int DISTANCE_LOD1 = 60;

	private const string FREE_COUPLER_HOSE_PREFAB_NAME = "[coupling_hose_free]";

	private const string CONNECTED_COUPLER_HOSE_PREFAB_NAME = "[coupling_hose_connected]";

	private const string FREE_MU_HOSE_PREFAB_NAME = "[mu_hose_free]";

	private const string CONNECTED_MU_HOSE_PREFAB_NAME = "[mu_hose_connected]";

	private static CouplingHosePool _couplerFreeHosePool;

	private static CouplingHosePool _couplerConnectedHosePool;

	private static CouplingHosePool _multipleUnitFreeHosePool;

	private static CouplingHosePool _multipleUnitConnectedHosePool;

	private readonly CouplingHoseRig rig;

	private readonly CouplingHoseConnectionManager connectionManager;

	private readonly CouplingHoseDataSyncManager syncManager;

	internal CouplingHosePool.IPoolItemComponent ownFreeHose;

	internal CouplingHosePool.IPoolItemComponent connectedHose;

	public bool IsLODLocked { get; private set; }

	private static CouplingHosePool CouplerFreeHosePool
	{
		get
		{
			if (_couplerFreeHosePool == null)
			{
				_couplerFreeHosePool = CouplingHosePool.MakePool("[coupling_hose_free]");
			}
			return _couplerFreeHosePool;
		}
	}

	private static CouplingHosePool CouplerConnectedHosePool
	{
		get
		{
			if (_couplerConnectedHosePool == null)
			{
				_couplerConnectedHosePool = CouplingHosePool.MakePool("[coupling_hose_connected]");
			}
			return _couplerConnectedHosePool;
		}
	}

	private static CouplingHosePool MultipleUnitFreeHosePool
	{
		get
		{
			if (_multipleUnitFreeHosePool == null)
			{
				_multipleUnitFreeHosePool = CouplingHosePool.MakePool("[mu_hose_free]");
			}
			return _multipleUnitFreeHosePool;
		}
	}

	private static CouplingHosePool MultipleUnitConnectedHosePool
	{
		get
		{
			if (_multipleUnitConnectedHosePool == null)
			{
				_multipleUnitConnectedHosePool = CouplingHosePool.MakePool("[mu_hose_connected]");
			}
			return _multipleUnitConnectedHosePool;
		}
	}

	public LODLevel CurrentLODLevel { get; private set; }

	private CouplingHosePool GetRequiredPool(bool isFreeHose)
	{
		HoseType hoseType = rig.adapter.GetHoseType();
		switch (hoseType)
		{
		case HoseType.Brake:
			if (!isFreeHose)
			{
				return CouplerConnectedHosePool;
			}
			return CouplerFreeHosePool;
		case HoseType.MultipleUnit:
			if (!isFreeHose)
			{
				return MultipleUnitConnectedHosePool;
			}
			return MultipleUnitFreeHosePool;
		default:
			Debug.LogError($"Unespected state: Unhandled hose type {hoseType}! Returning null");
			return null;
		}
	}

	public CouplingHoseLODManager(CouplingHoseRig rig, CouplingHoseConnectionManager connectionManager, CouplingHoseDataSyncManager syncManager)
	{
		this.rig = rig;
		this.connectionManager = connectionManager;
		this.connectionManager.ConnectionStateChanged.Register(OnConnectionStateChanged);
		this.syncManager = syncManager;
	}

	public void OnDestroy()
	{
		connectionManager.ConnectionStateChanged.Unregister(OnConnectionStateChanged);
	}

	private void OnConnectionStateChanged()
	{
		if (connectionManager.IsConnected)
		{
			if (ownFreeHose != null)
			{
				UnloadFreeHose();
			}
			if (connectionManager.IsMaster && CurrentLODLevel >= LODLevel.Visible_And_Reduced_Simulation)
			{
				LoadConnectedHose();
			}
		}
		else
		{
			if (connectedHose != null)
			{
				UnloadConnectedHose();
			}
			if (CurrentLODLevel >= LODLevel.Visible_And_Reduced_Simulation)
			{
				LoadFreeHose();
			}
		}
	}

	private void LoadConnectedHose()
	{
		connectedHose = GetRequiredPool(isFreeHose: false).GetFromPool(connectionManager.rig.transform);
		CouplingHoseRopeInstance ropeInstance = (CouplingHoseRopeInstance)connectedHose;
		syncManager.HandleLoaded(ropeInstance, isConnectedRope: true, scheduleJob: false);
		connectionManager.ConnectedTo.SyncManager.HandleLoaded(ropeInstance, isConnectedRope: true, scheduleJob: true);
	}

	private void LoadFreeHose()
	{
		ownFreeHose = GetRequiredPool(isFreeHose: true).GetFromPool(connectionManager.rig.transform);
		syncManager.HandleLoaded((CouplingHoseRopeInstance)ownFreeHose, isConnectedRope: false, scheduleJob: true);
	}

	private void UnloadConnectedHose()
	{
		GetRequiredPool(isFreeHose: false).ReturnToPool(connectedHose);
		CouplingHoseRopeInstance ropeInstance = (CouplingHoseRopeInstance)connectedHose;
		syncManager.HandleUnloaded(ropeInstance);
		connectionManager.PreviouslyConnectedTo.SyncManager.HandleUnloaded(ropeInstance);
		connectedHose = null;
	}

	private void UnloadFreeHose()
	{
		GetRequiredPool(isFreeHose: true).ReturnToPool(ownFreeHose);
		syncManager.HandleUnloaded((CouplingHoseRopeInstance)ownFreeHose);
		ownFreeHose = null;
	}

	public void SetLOD(LODLevel newLODLevel)
	{
		if (IsLODLocked && newLODLevel < LODLevel.Visible_And_Full_Simulation)
		{
			return;
		}
		if (newLODLevel == CurrentLODLevel)
		{
			Debug.LogWarning($"Passed same LODLevel {newLODLevel} as current, doing nothing.", rig);
		}
		else if (!connectionManager.IsConnected || connectionManager.IsMaster)
		{
			int num = (int)CurrentLODLevel;
			bool flag = (int)newLODLevel > num;
			while (CurrentLODLevel != newLODLevel)
			{
				num += (flag ? 1 : (-1));
				if (CurrentLODLevel == LODLevel.Unloaded)
				{
					if (flag)
					{
						Load();
					}
					else
					{
						Debug.LogError($"Should never get here (current LOD level: {CurrentLODLevel}, target LOD level: {newLODLevel}, temp: {num})", rig);
					}
				}
				else if (CurrentLODLevel == LODLevel.Visible_And_Reduced_Simulation)
				{
					if (flag)
					{
						SetHoseLOD((LODLevel)num);
					}
					else
					{
						Unload();
					}
				}
				else if (CurrentLODLevel == LODLevel.Visible_And_Full_Simulation)
				{
					if (flag)
					{
						Debug.LogError($"Should never get here (current LOD level: {CurrentLODLevel}, target LOD level: {newLODLevel}, temp: {num})", rig);
					}
					else
					{
						SetHoseLOD((LODLevel)num);
					}
				}
				else
				{
					Debug.LogError($"Unhandled LODLevel value (current LOD level: {CurrentLODLevel}, target LOD level: {newLODLevel}, temp: {num})", rig);
				}
				CurrentLODLevel = (LODLevel)num;
			}
		}
		else
		{
			CurrentLODLevel = newLODLevel;
		}
	}

	private void Load()
	{
		if (connectionManager.IsConnected)
		{
			LoadConnectedHose();
		}
		else
		{
			LoadFreeHose();
		}
	}

	private void Unload()
	{
		if (connectionManager.IsConnected)
		{
			UnloadConnectedHose();
		}
		else
		{
			UnloadFreeHose();
		}
	}

	private void SetHoseLOD(LODLevel lodLevel)
	{
		if (CurrentLODLevel == LODLevel.Unloaded)
		{
			Debug.LogError("Shouldn't ever call this while nothing's loaded", rig);
		}
		else if (connectionManager.IsConnected)
		{
			connectedHose.SetLOD(lodLevel);
		}
		else
		{
			ownFreeHose.SetLOD(lodLevel);
		}
	}

	public static LODLevel GetLODLevelForDistance(float distance)
	{
		if (distance < 15f)
		{
			return LODLevel.Visible_And_Full_Simulation;
		}
		if (distance < 60f)
		{
			return LODLevel.Visible_And_Reduced_Simulation;
		}
		return LODLevel.Unloaded;
	}

	public void LockLOD()
	{
		if (!IsLODLocked)
		{
			IsLODLocked = true;
			if (CurrentLODLevel != LODLevel.Visible_And_Full_Simulation)
			{
				SetLOD(LODLevel.Visible_And_Full_Simulation);
			}
		}
	}

	public void UnlockLOD()
	{
		IsLODLocked = false;
	}
}
