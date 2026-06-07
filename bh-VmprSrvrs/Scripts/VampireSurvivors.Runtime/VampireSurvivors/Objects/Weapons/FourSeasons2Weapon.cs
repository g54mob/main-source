using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Weapons
{
	public class FourSeasons2Weapon : Weapon
	{
		private PhaserSprite[] _orbs;

		private bool _canSpin;

		public float2[] _positions;

		private float _angleUnit;

		private float[] _angles;

		public override float PPower()
		{
			return 0f;
		}

		protected override void FakeConstruct()
		{
		}

		private void Set5Positions()
		{
		}

		protected override void MakeLevelOne()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
