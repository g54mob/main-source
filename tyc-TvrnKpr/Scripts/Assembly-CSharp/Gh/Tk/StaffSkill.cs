using System;
using System.Collections.Generic;
using System.Text;

namespace Gh.Tk
{
	public abstract class StaffSkill : ActorSkill
	{
		private static readonly Dictionary<Type, Type[]> _cachedTraitList;

		[PersistenceOptIn]
		public string JobRole { get; set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new Staff Owner
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		protected StaffSkill()
		{
		}

		public StaffSkill(Staff owner, string role)
		{
		}

		public override void Init()
		{
		}

		public override void OnRemoving()
		{
		}

		private void InvalidateMovementSpeed(object sender, EventArgs<string> e)
		{
		}

		private float GetMovementSpeedBonusModifierFactor()
		{
			return 0f;
		}

		private int GetMovementSpeedModifierPercentage()
		{
			return 0;
		}

		private void UpdateMovementSpeed()
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		protected bool IsWearingSkillUniform()
		{
			return false;
		}

		public IEnumerable<Type> GetAllAvailableSkillTraits()
		{
			return null;
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}

		protected override string GetTooltipTextKey()
		{
			return null;
		}

		protected virtual void AppendUniformBonusDetails(StringBuilder sb, bool isWearingUniform)
		{
		}

		protected void AppendUniformCheckboxLine(StringBuilder sb, string textKey)
		{
		}

		protected abstract void AppendEffectDetailsForTooltip(StringBuilder sb);
	}
}
