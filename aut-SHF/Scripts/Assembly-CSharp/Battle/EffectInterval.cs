using System;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class EffectInterval
	{
		[Label("インターバル(s)")]
		[Tooltip("次攻撃までの間隔")]
		public float interval;

		[Label("遅延")]
		[Tooltip("最初の1発のみ")]
		public float delay;

		[Label("出撃時詳細出力")]
		[Tooltip("デバッグ用。攻撃回数計算を出力する。発動系は時間内に打ち始めることができるなら打ち終わるまで消えないので+n回が付いている")]
		public bool logDetail;

		protected double nextShootTime;

		protected bool initializeDelay;

		private double overTime;

		public int MinValue { get; private set; }

		public bool IsPlaying { get; protected set; }

		public bool MinComplete => false;

		public void SetupMinCount(double lifetime, float other)
		{
		}

		public virtual void InitParameter(EffectInterval bulletSetting)
		{
		}

		public void SetNextShotTimer(bool count = true)
		{
		}

		public void SetNextShotTimer(double timer, bool count = true)
		{
		}

		public virtual bool IsEffectable()
		{
			return false;
		}

		public int IsEffectableCount()
		{
			return 0;
		}

		public virtual void ReleasePlaying()
		{
		}
	}
}
