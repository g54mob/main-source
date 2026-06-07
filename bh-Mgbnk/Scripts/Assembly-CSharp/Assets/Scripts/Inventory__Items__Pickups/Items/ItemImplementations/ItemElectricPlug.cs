using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations
{
	public class ItemElectricPlug : ItemBase
	{
		public static string damageSource;

		private DamageContainer reuseDc;

		private float radius;

		private float radiusPerAmount;

		private int targets;

		private int targetsPerAmount;

		private int targetsDefault;

		protected override void OnInitOrAmountChanged()
		{
		}

		private float GetDamage()
		{
			return 0f;
		}

		public override void Init()
		{
		}

		public override void Cleanup()
		{
		}

		private void OnPlayerHit()
		{
		}

		public override void ProcOnHitEffects(DamageContainer dc)
		{
		}

		public override bool HasOnHitEffectProc()
		{
			return false;
		}

		public ItemElectricPlug(ItemInventory itemInventoryRef)
			: base(null)
		{
		}

		public override void Tick()
		{
		}

		public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
		{
		}

		public override bool HasPreAttackProc()
		{
			return false;
		}
	}
}
