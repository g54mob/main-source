using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Game.Spawning.New.Timelines;

[Serializable]
public class StageTimeline
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Comparison<TimelineEvent> _003C_003E9__7_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe int _003CSort_003Eb__7_0(TimelineEvent x, TimelineEvent y)
		{
			//IL_0073: Expected I4, but got O
			//IL_005c: Expected Ref, but got F4
			if (x != null && y != null)
			{
				float num = (float)x + 32f;
				return ((float*)num)->CompareTo(y.timeMinutes);
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public float stageTime = 600f;

	public float checkNewEnemyInterval = 60f;

	public List<EEnemy> startEnemies;

	public List<TimelineEvent> events;

	public EnemyData boss;

	public List<EEnemy> minibosses;

	public float GetStageTime()
	{
		if (!MapController.isFinalBossStage)
		{
			return stageTime;
		}
		return 600f;
	}

	public unsafe void Sort()
	{
		Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__7_0;
		if (_003C_003Ec._003C_003E9__7_0 == null)
		{
			comparison = (Comparison<object>)(_003C_003Ec._003C_003E9__7_0 = delegate(TimelineEvent x, TimelineEvent y)
			{
				//IL_0073: Expected I4, but got O
				//IL_005c: Expected Ref, but got F4
				if (x == null || y == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
				float num = (float)x + 32f;
				return ((float*)num)->CompareTo(y.timeMinutes);
			});
		}
		((List<object>)(object)events).Sort(comparison);
	}
}
