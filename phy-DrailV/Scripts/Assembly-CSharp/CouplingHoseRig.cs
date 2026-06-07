using UnityEngine;

public class CouplingHoseRig : MonoBehaviour
{
	public CouplingHoseAdapterBase adapter;

	public Transform ropeAnchor;

	private CouplingHoseConnectionManager _connectionManager;

	private CouplingHoseDataSyncManager _syncManager;

	private CouplingHoseLODManager _lodManager;

	internal CouplingHoseConnectionManager ConnectionManager
	{
		get
		{
			if (_connectionManager == null)
			{
				_connectionManager = new CouplingHoseConnectionManager(this);
			}
			return _connectionManager;
		}
	}

	internal CouplingHoseDataSyncManager SyncManager
	{
		get
		{
			if (_syncManager == null)
			{
				_syncManager = new CouplingHoseDataSyncManager(this);
			}
			return _syncManager;
		}
	}

	internal CouplingHoseLODManager LODManager
	{
		get
		{
			if (_lodManager == null)
			{
				_lodManager = new CouplingHoseLODManager(this, ConnectionManager, SyncManager);
			}
			return _lodManager;
		}
	}

	private void OnDestroy()
	{
		if (_lodManager != null)
		{
			_lodManager.OnDestroy();
		}
		if (_syncManager != null)
		{
			_syncManager.OnDestroy();
		}
		if (_connectionManager != null)
		{
			_connectionManager.OnDestroy();
		}
	}

	public void RequestConnect(CouplingHoseRig other)
	{
		if (!ConnectionManager.IsConnectionAllowed(other, out var reason))
		{
			Debug.LogWarning("Ignoring connection request, reason: " + reason, this);
		}
		else if (adapter.IsConnected)
		{
			Debug.LogWarning("Ignoring connection request, adapter already connected", this);
		}
		else
		{
			adapter.RequestConnect(other);
		}
	}

	public void RequestDisconnect()
	{
		if (!ConnectionManager.IsConnected)
		{
			Debug.LogWarning("Hose connection manager is not connected, ignoring disconnect request", this);
		}
		else if (!adapter.IsConnected)
		{
			Debug.LogWarning("Hose adapter is not connected, ignoring disconnect request", this);
		}
		else
		{
			adapter.RequestDisconnect();
		}
	}

	public void AboutToBeDestroyed()
	{
		if (LODManager.CurrentLODLevel != CouplingHoseLODManager.LODLevel.Unloaded)
		{
			SetLOD(CouplingHoseLODManager.LODLevel.Unloaded);
			if (ConnectionManager.IsConnected)
			{
				ConnectionManager.Disconnect();
			}
		}
	}

	public void SetLODForDistance(float distanceFromCamera)
	{
		CouplingHoseLODManager.LODLevel lODLevelForDistance = CouplingHoseLODManager.GetLODLevelForDistance(distanceFromCamera);
		if (lODLevelForDistance != LODManager.CurrentLODLevel)
		{
			SetLOD(lODLevelForDistance);
		}
	}

	public void SetLOD(CouplingHoseLODManager.LODLevel newLODLevel)
	{
		LODManager.SetLOD(newLODLevel);
	}

	public static CouplingHoseRig GetRig(Coupler c)
	{
		CouplingHoseRig result = null;
		if ((bool)c && (bool)c.visualCoupler && (bool)c.visualCoupler.hoseAdapter && (bool)c.visualCoupler.hoseAdapter.rig)
		{
			result = c.visualCoupler.hoseAdapter.rig;
		}
		return result;
	}
}
