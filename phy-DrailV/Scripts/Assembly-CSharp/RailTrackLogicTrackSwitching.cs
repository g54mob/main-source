using System.Collections.Generic;
using System.Linq;
using DV.Logic.Job;
using UnityEngine;

public class RailTrackLogicTrackSwitching : MonoBehaviour
{
	private Track logicTrack;

	private RailTrack railTrack;

	private bool initialized;

	public void Init()
	{
		if (initialized)
		{
			return;
		}
		initialized = true;
		railTrack = GetComponent<RailTrack>();
		logicTrack = railTrack.LogicTrack();
		UpdateLogicOutTrackConnection();
		if (railTrack.outJunction != null)
		{
			railTrack.outJunction.Switched += delegate
			{
				logicTrack.ConnectOutTrack(railTrack.GetOutBranch()?.track?.LogicTrack());
			};
		}
		UpdateLogicInTrackConnection();
		if (railTrack.inJunction != null)
		{
			railTrack.inJunction.Switched += delegate
			{
				logicTrack.ConnectInTrack(railTrack.GetInBranch()?.track?.LogicTrack());
			};
		}
	}

	private void Start()
	{
		Init();
	}

	public void UpdateLogicOutTrackConnection()
	{
		Track outTrack = railTrack.GetOutBranch()?.track?.LogicTrack();
		logicTrack.ConnectOutTrack(outTrack);
		List<Junction.Branch> allOutBranches = railTrack.GetAllOutBranches();
		logicTrack.InitializePossibleOutTracks((allOutBranches != null) ? new HashSet<Track>(allOutBranches.Select((Junction.Branch b) => b?.track?.LogicTrack())) : new HashSet<Track>());
	}

	public void UpdateLogicInTrackConnection()
	{
		Track inTrack = railTrack.GetInBranch()?.track?.LogicTrack();
		logicTrack.ConnectInTrack(inTrack);
		List<Junction.Branch> allInBranches = railTrack.GetAllInBranches();
		logicTrack.InitializePossibleInTracks((allInBranches != null) ? new HashSet<Track>(allInBranches.Select((Junction.Branch b) => b?.track?.LogicTrack())) : new HashSet<Track>());
	}
}
