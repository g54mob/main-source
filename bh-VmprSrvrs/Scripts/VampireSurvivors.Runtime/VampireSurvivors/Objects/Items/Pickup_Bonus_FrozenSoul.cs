namespace VampireSurvivors.Objects.Items
{
	public class Pickup_Bonus_FrozenSoul : NetworkPickup, ICountedPickup
	{
		private static int _sfxIndex;

		private static float[] _detuneValues;

		protected float _MaxHpMul;

		protected float _RegenMul;

		protected float _GrowthMul;

		private int _prevDepth;

		public int AmountOnCollection { get; set; }

		private static float GetDetune()
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		public override void GetTaken()
		{
		}

		public override void UpdateDepth()
		{
		}

		public override void Despawn()
		{
		}

		protected override void ReturnPickupToPool()
		{
		}

		protected override void PreOnlineVacuum()
		{
		}

		protected override void PreOnlineTake()
		{
		}
	}
}
