using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Weapons
{
	public class FourSeasonsWeapon : Weapon
	{
		private PhaserSprite[] _orbs;

		private MultiTargetTween[] _orbTweens;

		private bool _canSpin;

		public float2[] _positions;

		private float _angleUnit;

		private float[] _angles;

		private float[] _cornerOffsets;

		public override float PPower()
		{
			return 0f;
		}

		protected override void FakeConstruct()
		{
		}

		private void Set4Positions()
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

		public override void Cleanup()
		{
		}
	}
}
