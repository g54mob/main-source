using Assets.Scripts.Actors;

namespace Assets.Scripts.Inventory__Items__Pickups.Items
{
	public class ItemAttackModifier
	{
		public float flatValues;

		public float additiveValues;

		public float multiplicativeValues;

		public float damageMultiplier { get; private set; }

		public void Recycle()
		{
		}

		public void Apply(DamageContainer dc)
		{
		}

		public void AddMultiplier(float multiplier)
		{
		}
	}
}
