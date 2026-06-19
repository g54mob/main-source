using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerPatientEnvironmentCheck : AdviceTrigger
	{
		private enum EnvironmentalCheck
		{
			Temperature = 0,
			Attractiveness = 1
		}

		[InspectorMargin(8)]
		[InspectorHeader("Patient Enviornment Check")]
		[InspectorTooltip("The patient environment stat we are checking")]
		[SerializeField]
		private EnvironmentalCheck _environmentCheck;

		[InspectorTooltip("Minimum number of patients before we bother checking this attribute...")]
		[SerializeField]
		private int _minPatientThreshold = 8;

		[InspectorTooltip("If we are looking for the attribute to be 'LessThan' or 'GreaterThan' the 'Count Threshold'")]
		[SerializeField]
		private bool _lessThan;

		[InspectorTooltip("The Count Threshold is the percentage the attribute must be 'LessThan' or 'GreaterThan' to be counted")]
		[SerializeField]
		private float _countThreshold = 70f;

		[InspectorTooltip("If count makes up over this percentage then trigger a low priority message")]
		[SerializeField]
		private float _lowPriPercentage = 0.3f;

		[InspectorTooltip("If count makes up over this percentage then trigger a medium priority message")]
		[SerializeField]
		private float _medPriPercentage = 0.45f;

		[InspectorTooltip("If count makes up over this percentage then trigger a high priority message")]
		[SerializeField]
		private float _highPriPercentage = 0.6f;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			int count = Level.CharacterManager.Patients.Count;
			if (count < _minPatientThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				Patient patient = Level.CharacterManager.Patients[i];
				float num2;
				switch (_environmentCheck)
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
				if (_lessThan && num2 < _countThreshold)
				{
					num++;
				}
				else if (!_lessThan && num2 > _countThreshold)
				{
					num++;
				}
			}
			float num3 = (float)num / (float)count;
			if (num3 < _lowPriPercentage)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num3 < _medPriPercentage)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num3 < _highPriPercentage)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
