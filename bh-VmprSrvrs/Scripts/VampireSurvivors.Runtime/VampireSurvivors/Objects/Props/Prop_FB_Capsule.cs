using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loot;

namespace VampireSurvivors.Objects.Props
{
	public class Prop_FB_Capsule : Destructible
	{
		private float2 _startingPosition;

		private float _repeats;

		private float _repeated;

		private float _life;

		private float _travelDuration;

		private bool _hasFired;

		private static WeightedStore WEIGHTEDSTORE;

		private float StartingX;

		private float FinishingXOffset;

		private float OffsetFromPlayerY;

		private float WaveMaxHeight;

		private float _oscillations;

		private float _accumulatedTime;

		public override void Init(PropType destructibleType)
		{
		}

		protected override bool CanEmitLight()
		{
			return false;
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void SetupAnimations()
		{
		}

		protected override void OnDestroyed()
		{
		}

		protected void CustomLoot()
		{
		}

		private void UpdatePosition()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
