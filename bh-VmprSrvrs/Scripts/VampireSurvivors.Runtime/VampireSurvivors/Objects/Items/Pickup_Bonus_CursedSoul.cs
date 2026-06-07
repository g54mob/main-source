using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items
{
	public class Pickup_Bonus_CursedSoul : Pickup
	{
		public float _Volume;

		private static float[] _detuneValues;

		private static int _sfxIndex;

		protected float _MaxHpVal;

		protected float _CurseVal;

		protected float _GreedVal;

		protected override void Awake()
		{
		}

		private static float GetDetune()
		{
			return 0f;
		}

		public override void GetTaken()
		{
		}
	}
}
