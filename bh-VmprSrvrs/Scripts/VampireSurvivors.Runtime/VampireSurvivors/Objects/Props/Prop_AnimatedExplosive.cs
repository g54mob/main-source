using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Objects.Props
{
	public class Prop_AnimatedExplosive : Destructible
	{
		public WeaponType MyWeaponType;

		public int BreakAnimationFramesNumber;

		private Stage _stage;

		private bool _hasFired;

		private bool hasAnimations;

		[Inject]
		private void Construct(Stage stage)
		{
		}

		public void InternalUpdate()
		{
		}

		public void UpdateDepth()
		{
		}

		public override void Init(PropType destructibleType)
		{
		}

		protected override bool CanEmitLight()
		{
			return false;
		}

		protected override void SetupAnimations()
		{
		}

		protected override void OnDestroyed()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void RestoreTint()
		{
		}
	}
}
