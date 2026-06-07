using System;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Jundroo.Common.Math;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	public abstract class TargetValueRequirement : TutorialRequirement
	{
		private float _lowerLimit;

		private float _originalTargetValue;

		private float _originalTargetValueTolerance;

		private string _unitSystemName;

		private float _upperLimit;

		[field: SerializeField]
		public ComparisonOperatorType ComparisonOperator { get; set; }

		public float DistanceToTarget { get; private set; }

		[field: SerializeField]
		public float TargetValue { get; protected set; }

		[field: SerializeField]
		public float TargetValueTolerance { get; private set; }

		protected virtual UnitType? UnitType => null;

		public void SetTargetValue(float targetValue, float tolerance, ComparisonOperatorType op, string unitSystemName = null)
		{
			TargetValue = targetValue;
			TargetValueTolerance = tolerance;
			ComparisonOperator = op;
			_originalTargetValue = targetValue;
			_originalTargetValueTolerance = tolerance;
			_unitSystemName = unitSystemName;
			if (UnitType.HasValue && !string.IsNullOrWhiteSpace(unitSystemName))
			{
				UnitSystem unitSystem = Game.Instance.Settings.Gameplay.General.UnitSystems.FirstOrDefault((UnitSystem x) => x.Name == unitSystemName);
				if (unitSystem == null)
				{
					Debug.LogError("Unit system '" + unitSystemName + "' not supported");
					return;
				}
				TargetValue /= unitSystem.Units[UnitType.Value].Factor;
				TargetValueTolerance /= unitSystem.Units[UnitType.Value].Factor;
			}
		}

		protected virtual float ConvertValueForDisplay(float value)
		{
			return value;
		}

		protected override string FormatMessage(string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				return message;
			}
			if (UnitType.HasValue)
			{
				UnitType value = UnitType.Value;
				if (value == Jundroo.Common.Math.UnitType.Mass || value == Jundroo.Common.Math.UnitType.Force)
				{
					return string.Format(message, ConvertValueForDisplay(TargetValue / 0.01f).Format(value), ConvertValueForDisplay(TargetValueTolerance / 0.01f).Format(value), ConvertValueForDisplay(_lowerLimit / 0.01f).Format(value), ConvertValueForDisplay(_upperLimit / 0.01f).Format(value), ConvertValueForDisplay(DistanceToTarget / 0.01f).Format(value));
				}
				return string.Format(message, ConvertValueForDisplay(TargetValue).Format(value), ConvertValueForDisplay(TargetValueTolerance).Format(value), ConvertValueForDisplay(_lowerLimit).Format(value), ConvertValueForDisplay(_upperLimit).Format(value), ConvertValueForDisplay(DistanceToTarget).Format(value));
			}
			return string.Format(message, ConvertValueForDisplay(TargetValue), ConvertValueForDisplay(TargetValueTolerance), ConvertValueForDisplay(_lowerLimit), ConvertValueForDisplay(_upperLimit), ConvertValueForDisplay(DistanceToTarget));
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("value", _originalTargetValue);
			xml.SetAttributeValue("tolerance", (_originalTargetValueTolerance != 0f) ? new float?(_originalTargetValueTolerance) : ((float?)null));
			xml.SetAttributeValue("op", ComparisonOperator);
			xml.SetAttributeValue("unitSystem", string.IsNullOrEmpty(_unitSystemName) ? null : _unitSystemName);
			base.GenerateXml(xml);
		}

		protected abstract float? GetValue(AircraftScript playerAircraft);

		protected override void OnInitialized()
		{
			base.OnInitialized();
			RefreshTargetLimits();
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			AircraftScript playerAircraft = base.PlayerAircraft;
			if (playerAircraft == null)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			float? value = GetValue(playerAircraft);
			if (!value.HasValue)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			bool flag = false;
			float num = 0f;
			float value2 = value.Value;
			switch (ComparisonOperator)
			{
			case ComparisonOperatorType.Equal:
				num = Mathf.Max(_lowerLimit - value2, value2 - _upperLimit);
				flag = num <= 0f;
				break;
			case ComparisonOperatorType.NotEqual:
				num = Mathf.Min(value2 - _lowerLimit, _upperLimit - value2);
				flag = num < 0f;
				break;
			case ComparisonOperatorType.LessThan:
				num = value2 - _upperLimit;
				flag = num < 0f;
				break;
			case ComparisonOperatorType.LessThanOrEqual:
				num = value2 - _upperLimit;
				flag = num <= 0f;
				break;
			case ComparisonOperatorType.GreaterThan:
				num = _lowerLimit - value2;
				flag = num < 0f;
				break;
			case ComparisonOperatorType.GreaterThanOrEqual:
				num = _lowerLimit - value2;
				flag = num <= 0f;
				break;
			}
			DistanceToTarget = Mathf.Max(0f, num);
			if (!flag)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected void RefreshTargetLimits()
		{
			switch (ComparisonOperator)
			{
			case ComparisonOperatorType.Equal:
			case ComparisonOperatorType.NotEqual:
				_lowerLimit = TargetValue - TargetValueTolerance;
				_upperLimit = TargetValue + TargetValueTolerance;
				break;
			case ComparisonOperatorType.LessThan:
			case ComparisonOperatorType.LessThanOrEqual:
				_lowerLimit = float.MinValue;
				_upperLimit = TargetValue + TargetValueTolerance;
				break;
			case ComparisonOperatorType.GreaterThan:
			case ComparisonOperatorType.GreaterThanOrEqual:
				_lowerLimit = TargetValue - TargetValueTolerance;
				_upperLimit = float.MaxValue;
				break;
			default:
				throw new NotSupportedException($"Comparison operator '{ComparisonOperator}' not supported by {GetType().Name}");
			}
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			float valueOrDefault = ((float?)xml.Attribute("value")).GetValueOrDefault();
			float valueOrDefault2 = ((float?)xml.Attribute("tolerance")).GetValueOrDefault();
			ComparisonOperatorType comparisonOperator = GetComparisonOperator(xml);
			string unitSystemName = (string)xml.Attribute("unitSystem");
			SetTargetValue(valueOrDefault, valueOrDefault2, comparisonOperator, unitSystemName);
		}
	}
}
