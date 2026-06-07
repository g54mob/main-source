using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class SplitCircleSpawn : CircleSpawn
	{
		public class SplitCircleCounter<T> where T : BaseUnit
		{
			private class CounterModel
			{
				public int aliveCount;

				public List<T> battleObjects;

				public void UpdateAliveCount()
				{
				}
			}

			private CounterModel[] _counter;

			private const int _defaultSplitCount = 8;

			public SplitCircleCounter(int splitCount)
			{
			}

			public int GetTargetIndex(T battleObj)
			{
				return 0;
			}

			public void ReleaseBattleObj(int areaIdx, T battleObj)
			{
			}
		}

		[Label("円分割数")]
		public int splitCount;

		private float _radRange;

		private float[] _centerRad;

		private bool _isInitialize;

		public int AreaIdx { get; set; }

		public override void InitParameter(SallyPoint sallyPoint)
		{
		}

		public void Init()
		{
		}

		public SplitCircleCounter<T> GetCounterInstance<T>() where T : BaseUnit
		{
			return null;
		}

		public override Vector2 GetSallyPosition()
		{
			return default(Vector2);
		}
	}
}
