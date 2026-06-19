using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public abstract class Pipe : BuildingBehaviour
{
	public List<int> Connections;

	public BuildingStructure BuildingStructure;

	public int ID;

	public PipeGroup Group;

	public bool UseMyOwnRange;

	public RadiusProvider RadiusProvider => null;

	public abstract bool CanStartConnection { get; }

	public virtual bool Many { get; }

	public bool PipeInitiated { get; private set; }

	public bool HasAConnection => false;

	public event Action<int> AnnounceConnected
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

	public event Action<int> AnnounceDisconnected
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

	public void SetBuildingStructure(BuildingStructure structure)
	{
	}

	public bool CanMakeConnection(Pipe pipe)
	{
		return false;
	}

	public bool InRangeOf(Pipe pipe)
	{
		return false;
	}

	protected abstract bool CanConnect(Pipe pipe);

	public bool HasConnection(int pipeID)
	{
		return false;
	}

	public void ApplyConnection(int pipeID)
	{
	}

	public void ApplyDisconnection(int pipeID)
	{
	}

	private void OnDestroy()
	{
	}

	public override void Initiate()
	{
	}

	public void RegisterExistence()
	{
	}

	public void UnregisterExistence()
	{
	}
}
