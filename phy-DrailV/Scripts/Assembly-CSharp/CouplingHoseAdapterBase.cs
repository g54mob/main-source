using UnityEngine;

public abstract class CouplingHoseAdapterBase : MonoBehaviour
{
	public CouplingHoseRig rig;

	public abstract bool IsConnected { get; }

	public abstract bool IsInitialized { get; }

	public abstract void RequestConnectImplementation(CouplingHoseRig other);

	public abstract void RequestDisconnectImplementation();

	public abstract HoseType GetHoseType();

	public void RequestConnect(CouplingHoseRig other)
	{
		if (IsConnected)
		{
			Debug.LogError("hose already connected", this);
		}
		else if ((bool)other && (bool)other.adapter && other.adapter.IsInitialized)
		{
			RequestConnectImplementation(other);
		}
		else
		{
			Debug.LogWarning("Couldn't access other hose adapter properly, something is null", this);
		}
	}

	public void RequestDisconnect()
	{
		if (!IsConnected)
		{
			Debug.LogError("hose already disconnected", this);
		}
		else
		{
			RequestDisconnectImplementation();
		}
	}

	protected void OnCarInteriorAboutToBeDestroyed(TrainCar _)
	{
		rig.AboutToBeDestroyed();
	}
}
