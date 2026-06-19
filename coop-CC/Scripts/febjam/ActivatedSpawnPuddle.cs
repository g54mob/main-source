using Aggro.Core.Networking;
using UnityEngine;
using UnityEngine.Serialization;

public class ActivatedSpawnPuddle : NetworkEntityBehaviourBase, IBoxActivated
{
	public bool spawnOverTime;

	[Min(0f)]
	public float overTimeDuration = 3f;

	[Min(0f)]
	public float overTimeSpawnEvery = 0.5f;

	[FormerlySerializedAs("prefab")]
	public GameObject puddlePrefab;

	private Timer _serverOverTimeTimer;

	private Timer _serverSpawnEveryTimer;

	public void ServerBoxActivated(ActivationContext context)
	{
		if (spawnOverTime)
		{
			_serverOverTimeTimer.SetTimer(overTimeDuration);
		}
		else
		{
			NetworkAggroManagerBase<PuddleManager>.instance.ServerSpawnPuddle(puddlePrefab, base.entity.transform.position);
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer || !spawnOverTime)
		{
			return;
		}
		_serverOverTimeTimer.DecrementTimer();
		if (!_serverOverTimeTimer.IsFinished())
		{
			_serverSpawnEveryTimer.DecrementTimer();
			if (_serverSpawnEveryTimer.IsFinished())
			{
				NetworkAggroManagerBase<PuddleManager>.instance.ServerSpawnPuddle(puddlePrefab, base.entity.transform.position);
				_serverSpawnEveryTimer.SetTimer(overTimeSpawnEvery);
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
