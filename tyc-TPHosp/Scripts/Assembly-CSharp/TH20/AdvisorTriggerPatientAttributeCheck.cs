using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerPatientAttributeCheck : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerPatientAttributeCheckDefinition _definition;

		public AdvisorTriggerPatientAttributeCheck(AdvisorTriggerPatientAttributeCheckDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			int count = Level.CharacterManager.Patients.Count;
			if (count < _definition.MinPatientThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				AttributeFloat attribute = Level.CharacterManager.Patients[i].GetCharacterAttributes().GetAttribute(_definition.Attribute);
				if (attribute != null)
				{
					if (_definition.LessThan && attribute.Value() < _definition.CountThreshold)
					{
						num++;
					}
					else if (!_definition.LessThan && attribute.Value() > _definition.CountThreshold)
					{
						num++;
					}
				}
			}
			float num2 = (float)num / (float)count;
			if (num2 < _definition.LowPriPercentage)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num2 < _definition.MedPriPercentage)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num2 < _definition.HighPriPercentage)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
