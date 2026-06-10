using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class MoodBasicModifierInstance : ModifierInstance
	{
		[SerializeField]
		private float baseValue;

		[SerializeField]
		private List<AttributeType> attributes;

		[SerializeField]
		private string description;

		private List<string> infoList = new List<string>();

		private List<AttributeInstance> attributeInstances = new List<AttributeInstance>();

		private AttributeInstance moodAttribute;

		private KeyValuePair<string, float> modifierValuePair;

		public KeyValuePair<string, float> ModifierValuePair => modifierValuePair;

		public MoodBasicModifierInstance(MoodModifyEffect effect, string tag)
			: base(ModifierType.MoodBasic, tag)
		{
			baseValue = effect.GetBaseValue();
			attributes = effect.GetAttributes();
			description = effect.GetDescription();
		}

		public MoodBasicModifierInstance(float baseValue, string tag)
			: base(ModifierType.MoodBasic, tag)
		{
			this.baseValue = baseValue;
			description = tag;
		}

		public MoodBasicModifierInstance(float baseValue, List<AttributeType> attributes)
			: base(ModifierType.MoodBasic)
		{
			this.baseValue = baseValue;
			this.attributes = attributes;
		}

		public override bool PreInitChecks(StatsInstance instance, ModifierInstanceStack stack)
		{
			return true;
		}

		public override void Init(StatsInstance instance)
		{
			base.Init(instance);
			moodAttribute = instance.GetAttributeInstance(AttributeType.MoodTarget);
			if (attributes != null && attributes.Count > 0)
			{
				foreach (AttributeType attribute in attributes)
				{
					attributeInstances.Add(instance.GetAttributeInstance(attribute));
				}
			}
			infoList.Add((description != null) ? description : string.Empty);
		}

		public override void Apply()
		{
			float num = CalculateValue();
			modifierValuePair = new KeyValuePair<string, float>(description, num * base.StackMultiplier);
			float num2 = Mathf.Abs(num);
			float value = moodAttribute.Value;
			value += num2 * base.StackMultiplier * (float)Math.Sign(num);
			if (!Mathf.Approximately(moodAttribute.Value, 0f))
			{
				value /= moodAttribute.Value;
			}
			float num3 = moodAttribute.Multiplier * value;
			if (Mathf.Approximately(num3, 0f))
			{
				num3 = 0.01f;
			}
			moodAttribute.SetMultiplier(num3);
		}

		public float CalculateValue()
		{
			float num = baseValue + 1E-07f;
			if (attributeInstances != null && attributeInstances.Count > 0)
			{
				foreach (AttributeInstance attributeInstance in attributeInstances)
				{
					num *= attributeInstance.Value;
				}
			}
			return num;
		}

		public override List<string> GetInfo()
		{
			return infoList;
		}

		public int GetStackCount()
		{
			return attributeInstances.Count;
		}
	}
}
