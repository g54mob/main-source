using UnityEngine;

namespace Battle
{
	public class LoopEffect : BaseBattleEffect
	{
		[Label("有効：フリップ")]
		public bool isFlip;

		[Label("有効：Z回転")]
		[Tooltip("方向数2では無効")]
		public bool isRotation;

		[Label("退場エフェクト")]
		public HitEffect outEffect;

		protected override void Update()
		{
		}

		public void UpdateRotation(string animationName, Vector2 dirVec)
		{
		}

		public void UpdateRotation(Vector2 dirVec)
		{
		}

		public override void StopEffect(bool withChildren = true, ParticleSystemStopBehavior behavior = ParticleSystemStopBehavior.StopEmitting)
		{
		}
	}
}
