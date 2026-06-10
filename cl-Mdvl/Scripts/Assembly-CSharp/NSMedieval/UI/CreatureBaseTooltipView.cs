using System;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.UI
{
	public abstract class CreatureBaseTooltipView : TooltipViewNew
	{
		[NonSerialized]
		private CreatureBase creatureBase;

		[field: NonSerialized]
		protected string KeyId { get; private set; }

		protected CreatureBase CreatureBase
		{
			get
			{
				CreatureBase creatureBase = this.creatureBase;
				if (!(creatureBase is HumanoidInstance result))
				{
					if (creatureBase is AnimalInstance result2)
					{
						return result2;
					}
					return this.creatureBase;
				}
				return result;
			}
		}

		[field: NonSerialized]
		protected HumanoidInstance Humanoid { get; private set; }

		[field: NonSerialized]
		protected AnimalInstance Animal { get; private set; }

		public void SetTooltipData(CreatureBase creatureBase)
		{
			SetTooltipData(string.Empty, creatureBase);
		}

		public void SetTooltipData(string keyId, CreatureBase creatureBase)
		{
			KeyId = keyId;
			this.creatureBase = creatureBase;
			if (!(creatureBase is HumanoidInstance humanoid))
			{
				if (creatureBase is AnimalInstance animal)
				{
					Animal = animal;
					Humanoid = null;
				}
				else
				{
					Humanoid = null;
					Animal = null;
				}
			}
			else
			{
				Humanoid = humanoid;
				Animal = null;
			}
			RefreshTooltip();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Humanoid = null;
			Animal = null;
			creatureBase = null;
		}

		protected StatsInstance GetStats()
		{
			if (Humanoid != null)
			{
				return Humanoid.Stats;
			}
			if (Animal != null)
			{
				return Animal.Stats;
			}
			return null;
		}

		protected BodyType GetBodyType()
		{
			if (Humanoid != null)
			{
				return Humanoid.Info.BodyType;
			}
			if (Animal != null)
			{
				return Animal.Gender;
			}
			return BodyType.None;
		}
	}
}
