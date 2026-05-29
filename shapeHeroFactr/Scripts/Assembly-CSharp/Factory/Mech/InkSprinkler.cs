using Factory.FieldData;
using Models;
using UnityEngine;

namespace Factory.Mech
{
	public class InkSprinkler : MechBase
	{
		private readonly StructureAddr[] fromAddrs;

		private ILiquidCarrier fromPipeStr;

		private Structure[] toCatchers;

		private new double Sprinkler_UseInk_SpeedUp;

		public Vector2 medianPoint;

		private bool _isAnimation;

		private eLuggage animeInk;

		private GameObject _effectObject;

		private ParticleSystem _particleSystemRain;

		private ParticleSystem _particleSystemShower;

		private MiniLiquidCarrier InkTank => null;

		public eLuggage Ink => default(eLuggage);

		public InkSprinkler(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdateAttachmentData()
		{
		}

		private void _UpdateCircuitData()
		{
		}

		public override void UpdateCircuitData(bool updateAttachment = false)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override void Update(double deltaTime)
		{
		}

		private void PlayAnimation(bool play, eLuggage? ink = null, bool force = false)
		{
		}

		private void ChangeRainScale()
		{
		}

		private void VanishEffect()
		{
		}

		public override void Vanish()
		{
		}

		public static int GetSprinklerRadius()
		{
			return 0;
		}

		public static RectInt GetSprinklerCoverage(Vector2Int center)
		{
			return default(RectInt);
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
