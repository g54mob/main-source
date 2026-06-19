using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Unity.Mathematics;
using UnityEngine;

public class ModifierHaunted : ModifierBase
{
	public float delayAfterShiftStart = 5f;

	[Space]
	public Vector2 hauntTimeRange = new Vector2(5f, 10f);

	public Vector2Int hauntCountRange = new Vector2Int(1, 4);

	private Timer _serverTimer;

	private static List<BoxHaunted> _haunteds = new List<BoxHaunted>();

	private const float SPEED_THRESHOLD_SQR = 0.010000001f;

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		if (NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() != ShiftPhase.Shift)
		{
			_serverTimer.SetTimer(delayAfterShiftStart);
			return;
		}
		_serverTimer.DecrementTimer();
		if (!_serverTimer.IsFinished())
		{
			return;
		}
		Unity.Mathematics.Random random = GetRandom();
		_serverTimer.SetTimer(random.NextFloat(hauntTimeRange.x, hauntTimeRange.y));
		_haunteds.Clear();
		base.entityManager.GetAllObjects(_haunteds);
		int num = Mathf.CeilToInt((float)random.NextInt(hauntCountRange.x, hauntCountRange.y + 1) * GameUtil.GetDifficultyMultiplier());
		_haunteds.Randomize(random.NextInt());
		int num2 = 0;
		for (int i = 0; i < _haunteds.Count; i++)
		{
			if (num2 >= num)
			{
				break;
			}
			BoxHaunted boxHaunted = _haunteds[i];
			if (!boxHaunted.isHaunted && !boxHaunted.entity.rigidbody.isKinematic && !boxHaunted.entity.GetObject<BoxProps>().serverIsSafe && !boxHaunted.entity.GetObject<Grabbable>().isInStackAndNotBase && !(boxHaunted.entity.rigidbody.velocity.sqrMagnitude >= 0.010000001f) && boxHaunted.entity.GetStruct<EntityContextComp>().roomType == RoomType.Warehouse)
			{
				num2++;
				boxHaunted.ServerStartHaunted(random.NextInt());
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
