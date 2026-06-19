using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerPatientEnvironmentCheck : AdvisorTrigger
	{
		public enum EnvironmentalCheck
		{
			Temperature = 0,
			Attractiveness = 1
		}

		[SerializeField]
		private AdvisorTriggerPatientEnvironmentCheckDefinition _definition;

		public AdvisorTriggerPatientEnvironmentCheck(AdvisorTriggerPatientEnvironmentCheckDefinition definition)
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
				Patient patient = Level.CharacterManager.Patients[i];
				float num2;
				switch (_definition.EnvironmentCheck)
				{
				case EnvironmentalCheck.Temperature:
					num2 = patient.TemperatureValue;
					break;
				case EnvironmentalCheck.Attractiveness:
					num2 = patient.AttractivenessValue;
					break;
				default:
					return Advisor.PriorityLevel.DontShow;
				}
				if (_definition.LessThan && num2 < _definition.CountThreshold)
				{
					num++;
				}
				else if (!_definition.LessThan && num2 > _definition.CountThreshold)
				{
					num++;
				}
			}
			float num3 = (float)num / (float)count;
			if (num3 < _definition.LowPriPercentage)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num3 < _definition.MedPriPercentage)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num3 < _definition.HighPriPercentage)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
