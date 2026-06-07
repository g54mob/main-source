using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Props
{
	public class TP_PropDoor : Destructible
	{
		private bool _hasFired;

		private MultiTargetTween _alphaTween;

		private TPBiomeType BiomeType;

		private ItemType linkedRelicType;

		private int doorType;

		[Sync]
		public int LinkedRelicType
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync]
		[OnValueSynced("OnDoorTypeChanged")]
		public int DoorType
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected virtual void OnRecycle()
		{
		}

		public void SetRelicFromBiomeType(TPBiomeType biomeType)
		{
		}

		public void SetType(int type)
		{
		}

		protected override void SetupAnimations()
		{
		}

		public override void Init(PropType destructibleType)
		{
		}

		public override void Despawn()
		{
		}

		public void ManualUpdate()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected void OnTriggeredByPlayer()
		{
		}

		public override bool DoesAllowVenting()
		{
			return false;
		}

		private void OnDoorTypeChanged(int old, int newDoor)
		{
		}
	}
}
