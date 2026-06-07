using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Battle
{
	public record HpLuggageAbility(int effectiveHp, eAbilityEffectId id, float value, string tag, int isSum)
	{
		[CompilerGenerated]
		protected virtual Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public int effectiveHp { get; set; }

		public eAbilityEffectId id { get; set; }

		public float value { get; set; }

		public string tag { get; set; }

		public int isSum { get; set; }

		public bool ApplyFinish
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private bool _applyFinish;

		[CompilerGenerated]
		public override string ToString()
		{
			return null;
		}

		[CompilerGenerated]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			return false;
		}

		[CompilerGenerated]
		public virtual bool Equals(HpLuggageAbility? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected HpLuggageAbility(HpLuggageAbility original)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out int effectiveHp, out eAbilityEffectId id, out float value, out string tag, out int isSum)
		{
			effectiveHp = default(int);
			id = default(eAbilityEffectId);
			value = default(float);
			tag = null;
			isSum = default(int);
		}
	}
}
