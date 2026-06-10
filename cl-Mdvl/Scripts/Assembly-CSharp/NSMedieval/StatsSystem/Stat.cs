using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class Stat : NSEipix.Base.Model
	{
		[SerializeField]
		private StatType type;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private bool hideInScenarioEditor;

		[SerializeField]
		private float initialValue;

		[SerializeField]
		private FloatRange initialValueRange;

		[SerializeField]
		private StatAttributeModifiers attributes;

		[SerializeField]
		private StatThresholdTrigger[] thresholds;

		[SerializeField]
		private bool isDisabled;

		[SerializeField]
		private bool hideIfDisabled;

		public List<StatAttributeElement> Min => attributes.Min;

		public List<StatAttributeElement> Max => attributes.Max;

		public List<StatAttributeElement> Step => attributes.Step;

		public List<StatAttributeElement> ThresholdAttributes => attributes.Threshold;

		public List<StatAttributeElement> Target => attributes.Target;

		public float InitialValue
		{
			get
			{
				if (InitialValueRange != null && InitialValueRange.Max > 0f)
				{
					return InitialValueRange.Random();
				}
				return initialValue;
			}
		}

		public StatType Type => type;

		public StatThresholdTrigger[] ThresholdTriggers => thresholds;

		public FloatRange InitialValueRange => initialValueRange;

		public bool HideInScenarioEditor => hideInScenarioEditor;

		public bool IsDisabled => isDisabled;

		public bool HideIfDisabled => hideIfDisabled;

		public LocKeys[] LocKeys => locKeys;

		public Stat(StatType type, float min, float max, float step, float initialValue)
		{
			this.type = type;
			this.initialValue = initialValue;
			attributes = new StatAttributeModifiers(GenerateEmptyAttributeModBase(min), GenerateEmptyAttributeModBase(max), GenerateEmptyAttributeModBase(step), null);
		}

		public Stat(StatType type, float initialValue, StatAttributeModifiers attributes)
		{
			this.type = type;
			this.initialValue = initialValue;
			this.attributes = attributes;
		}

		public override string GetID()
		{
			return type.ToString();
		}

		private List<StatAttributeElement> GenerateEmptyAttributeModBase(float value)
		{
			StatAttributeElement item = new StatAttributeElement(value);
			return new List<StatAttributeElement> { item };
		}
	}
}
