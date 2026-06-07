using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items
{
	public class Pickup_TP_EnemySoul : Pickup
	{
		private TP_Soma_Character character;

		private int[] soulTypes;

		private string[] soulNames;

		private int _soulType;

		private bool _isUnset;

		public float _Volume;

		private static float[] _detuneValues;

		private static int _sfxIndex;

		protected float _MaxHpVal;

		protected float _MightVal;

		protected float _GreedVal;

		protected override void Awake()
		{
		}

		private static float GetDetune()
		{
			return 0f;
		}

		public override void SetData(ItemType itemType)
		{
		}

		protected virtual void OnRecycle()
		{
		}

		public override void GetTaken()
		{
		}

		public void StartSpiralToPlayer(CharacterController cc)
		{
		}
	}
}
