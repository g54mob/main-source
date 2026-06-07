using System;
using Coherence.Toolkit;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Props
{
	public class PropFoscariSeal2 : Destructible
	{
		private bool _alreadyDestroyed;

		private MultiTargetTween _floatTween;

		private MapToken _mapToken;

		public Action DestroyedCallback { get; set; }

		public override void Awake()
		{
		}

		public override void Init(PropType destructibleType)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVFX, float knockbackMul, WeaponType damageType, bool hasKnockback = true)
		{
		}

		public override void RemoteDestroy()
		{
		}

		[Command]
		public void DestroySeal(long startingSimFrame)
		{
		}

		public override void Despawn()
		{
		}

		private void KillIt()
		{
		}

		protected override void OnDestroyed()
		{
		}

		private void ScreenShake(int repeats = 6)
		{
		}
	}
}
