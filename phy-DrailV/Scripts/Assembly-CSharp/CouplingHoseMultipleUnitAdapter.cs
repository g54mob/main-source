using System;
using DV.MultipleUnit;
using UnityEngine;

public class CouplingHoseMultipleUnitAdapter : CouplingHoseAdapterBase
{
	public MultipleUnitHoseAudio hoseAudio;

	[NonSerialized]
	public MultipleUnitCable muCable;

	public override bool IsConnected => muCable.IsConnected;

	public override bool IsInitialized => muCable != null;

	private void Start()
	{
		if (muCable == null)
		{
			Debug.LogError("muCable is not initialized! Something is bad with setup!");
			return;
		}
		muCable.ConnectionChanged += OnHoseConnectionChangedExternally;
		HandleIfAlreadyConnectedOnSpawn();
		muCable.muModule.train.InteriorAboutToBeDestroyed += base.OnCarInteriorAboutToBeDestroyed;
	}

	public override HoseType GetHoseType()
	{
		return HoseType.MultipleUnit;
	}

	public override void RequestConnectImplementation(CouplingHoseRig other)
	{
		CouplingHoseMultipleUnitAdapter couplingHoseMultipleUnitAdapter = other.adapter as CouplingHoseMultipleUnitAdapter;
		if (couplingHoseMultipleUnitAdapter == null)
		{
			Debug.LogError("Attempted to connect different type of adapters!", this);
		}
		else
		{
			muCable.Connect(couplingHoseMultipleUnitAdapter.muCable, playAudio: true);
		}
	}

	public override void RequestDisconnectImplementation()
	{
		muCable.Disconnect(playAudio: true);
	}

	private void OnDestroy()
	{
		if (muCable != null)
		{
			muCable.ConnectionChanged -= OnHoseConnectionChangedExternally;
		}
	}

	private void HandleIfAlreadyConnectedOnSpawn()
	{
		if (!rig.ConnectionManager.IsConnected && muCable.IsConnected)
		{
			CouplingHoseMultipleUnitAdapter hoseAdapter = muCable.connectedTo.HoseAdapter;
			if (!hoseAdapter)
			{
				Debug.LogError("CouplingHoseMultipleUnitAdapter couldn't find other adapter", this);
			}
			else
			{
				rig.ConnectionManager.Connect(hoseAdapter.rig);
			}
		}
	}

	private void OnHoseConnectionChangedExternally(bool connected, bool playAudio)
	{
		if (connected)
		{
			CouplingHoseMultipleUnitAdapter hoseAdapter = muCable.connectedTo.HoseAdapter;
			if (hoseAdapter != null)
			{
				CouplingHoseRig couplingHoseRig = hoseAdapter.rig;
				if (CouplingHoseConnectionManager.GetMaster(rig, couplingHoseRig) == rig)
				{
					rig.ConnectionManager.Connect(couplingHoseRig);
					if (playAudio)
					{
						hoseAudio.PlayConnectSound();
					}
				}
			}
			else
			{
				Debug.LogError("Unexpected state: otherAdapter was null! Ignoring request");
			}
		}
		else if (rig.ConnectionManager.IsMaster)
		{
			rig.ConnectionManager.Disconnect();
			if (playAudio)
			{
				hoseAudio.PlayDisconnectSound();
			}
		}
	}
}
