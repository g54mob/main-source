using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public class ThirdStageGimmick : BaseStageGimmick
	{
		public ParticleSystem inkEffect;

		public ParticleSystem[] batsEffect;

		public float minInterval;

		public float maxInterval;

		private double _effectTimer;

		public double GetInterval => 0.0;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public override void SetFirstGimmick()
		{
		}

		public override Sequence PlayBossBattleGimmick()
		{
			return null;
		}

		public override Sequence PlayBattleGimmick()
		{
			return null;
		}
	}
}
