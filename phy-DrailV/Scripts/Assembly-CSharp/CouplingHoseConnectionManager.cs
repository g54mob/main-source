using DV.Util.EventWrapper;

public class CouplingHoseConnectionManager
{
	public event_ ConnectionStateChanged;

	internal CouplingHoseRig rig;

	public bool IsConnected => ConnectedTo != null;

	public bool IsMaster
	{
		get
		{
			if (IsConnected)
			{
				return GetMaster(rig, ConnectedTo) == rig;
			}
			return false;
		}
	}

	public CouplingHoseRig ConnectedTo { get; private set; }

	public CouplingHoseRig PreviouslyConnectedTo { get; private set; }

	public CouplingHoseConnectionManager(CouplingHoseRig rig)
	{
		this.rig = rig;
	}

	public void OnDestroy()
	{
	}

	public static CouplingHoseRig GetMaster(CouplingHoseRig a, CouplingHoseRig b)
	{
		if (a.GetInstanceID() >= b.GetInstanceID())
		{
			return b;
		}
		return a;
	}

	public bool IsConnectionAllowed(CouplingHoseRig other, out string reason)
	{
		if (other == null)
		{
			reason = "Got null other";
			return false;
		}
		if (other == rig)
		{
			reason = "Requested connection to self";
			return false;
		}
		if (IsConnected)
		{
			reason = "Already connected";
			return false;
		}
		if (other.ConnectionManager.IsConnected)
		{
			reason = "Other already connected";
			return false;
		}
		reason = string.Empty;
		return true;
	}

	public void Connect(CouplingHoseRig other)
	{
		CouplingHoseRig master = GetMaster(rig, other);
		if (master != rig)
		{
			master.ConnectionManager.Connect(rig);
			return;
		}
		ConnectedTo = other;
		other.ConnectionManager.ConnectedTo = rig;
		ConnectionStateChanged.Invoke();
		other.ConnectionManager.ConnectionStateChanged.Invoke();
		PreviouslyConnectedTo = other;
	}

	public void Disconnect()
	{
		CouplingHoseRig master = GetMaster(rig, ConnectedTo);
		if (master != rig)
		{
			master.ConnectionManager.Disconnect();
			return;
		}
		CouplingHoseRig connectedTo = ConnectedTo;
		ConnectedTo.ConnectionManager.ConnectedTo = null;
		ConnectedTo = null;
		ConnectionStateChanged.Invoke();
		connectedTo.ConnectionManager.ConnectionStateChanged.Invoke();
	}
}
