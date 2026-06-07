using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Props
{
	public class PropFoscariSeal1 : Destructible
	{
		private bool _alreadyDestroyed;

		private MultiTargetTween _floatTween;

		private PhaserSprite _sDarkness;

		private PhaserSprite _sFog;

		public MeshRenderer magicWaterImage;

		private MapToken _mapToken;

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

		protected override void OnDestroyed()
		{
		}

		private void ShakeEarth()
		{
		}

		private void RemoveWater()
		{
		}

		private void ChangeStage()
		{
		}

		private void ScreenShake(int repeats = 6)
		{
		}

		private void EditorBreakSeal()
		{
		}
	}
}
