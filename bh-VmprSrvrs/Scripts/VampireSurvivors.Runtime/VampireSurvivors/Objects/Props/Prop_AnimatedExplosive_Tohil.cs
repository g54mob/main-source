using Coherence;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Objects.Props
{
	public class Prop_AnimatedExplosive_Tohil : Destructible
	{
		private float TreasureChance;

		private float GraceTimes;

		private float MaxGrace;

		public int BreakAnimationFramesNumber;

		private Stage _stage;

		private bool _hasFired;

		private bool hasAnimations;

		public virtual WeaponType MyWeaponType => default(WeaponType);

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

		public override void RemoteDestroy()
		{
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

		private void ReceiveDamage(float value, HitVfxType showHitVfx = HitVfxType.Default)
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void DestroyTohil()
		{
		}

		protected override void RestoreTint()
		{
		}

		public virtual void AfterDestroyed()
		{
		}

		private void SpawnTreasure()
		{
		}
	}
}
