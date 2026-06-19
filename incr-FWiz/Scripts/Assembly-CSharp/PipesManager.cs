using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using OUSystems.Basics.DataStructures;
using UnityEngine;

public class PipesManager : MonoBehaviour
{
	public static PipesManager Instance;

	public static Dictionary<int, Pipe> Pipes;

	public List<PipeConnection> PipeConnections;

	public int LastPipeID;

	public BoolContainer HasPlacedPipelineBuilding;

	public event Action<PipeConnection> AnnounceAddPipeConnection
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

	public event Action<PipeConnection> AnnounceRemovePipeConnection
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

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void RegisterPipe(Pipe pipe)
	{
	}

	public void UnregisterPipe(Pipe pipe)
	{
	}

	public Pipe GetPipe(int pipeID)
	{
		return null;
	}

	public bool TryMakeConnection(Pipe pipe1, Pipe pipe2)
	{
		return false;
	}

	public void ClearConnection(Pipe pipe1, Pipe pipe2)
	{
	}

	public void ClearConnection(int pipe1, int pipe2)
	{
	}

	public void OnBuildBuilding(Building building)
	{
	}
}
