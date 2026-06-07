using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Flight.Sim;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class OrbitRequirement : ContractRequirement
	{
		public enum ComparisonType
		{
			Equal = 0,
			Less = 1,
			Greater = 2
		}

		public enum PropertyType
		{
			Apoapsis = 0,
			Periapsis = 1,
			Inclination = 2,
			Eccentricity = 3
		}

		private ComparisonType _comparisonType;

		private string _displayValue;

		private string _flightDescription;

		private double _minValue;

		private double _maxValue;

		private string _planetName;

		private PropertyType _property;

		private double _tolerance = 10000.0;

		private double _value;

		public override string DisplayValue => _displayValue;

		public override string FlightDescription
		{
			get
			{
				if (!string.IsNullOrEmpty(_flightDescription))
				{
					return _flightDescription;
				}
				return base.Description;
			}
		}

		public OrbitRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			double? doubleAttributeOrNull = xml.GetDoubleAttributeOrNull("value");
			PropertyType? enumAttributeOrNull = xml.GetEnumAttributeOrNull<PropertyType>("property");
			if (!doubleAttributeOrNull.HasValue)
			{
				throw new ContractException("Orbit requirement is missing required attribute 'value'");
			}
			if (!enumAttributeOrNull.HasValue)
			{
				throw new ContractException("Orbit requirement is missing required attribute 'property'");
			}
			_value = doubleAttributeOrNull.Value;
			_property = enumAttributeOrNull.Value;
			_tolerance = xml.GetDoubleAttribute("tolerance");
			_comparisonType = xml.GetEnumAttribute("op", ComparisonType.Equal);
			if (base.Description == null)
			{
				UpdateDescription();
			}
		}

		public override void OnFlightEnd()
		{
			base.OnFlightEnd();
			_planetName = null;
			_displayValue = null;
		}

		public override void OnTheFlyUpdateFromTargetRequirement(ContractRequirement target)
		{
			base.OnTheFlyUpdateFromTargetRequirement(target);
			if (target is OrbitRequirement orbitRequirement)
			{
				_value = orbitRequirement._value;
				_planetName = null;
				_tolerance = orbitRequirement._tolerance;
				_comparisonType = orbitRequirement._comparisonType;
				_property = orbitRequirement._property;
			}
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			double num;
			if (_property == PropertyType.Inclination)
			{
				num = craftNode.Orbit.Inclination * 57.29578;
				_displayValue = Units.GetAngleString((float)num, 2);
			}
			else if (_property == PropertyType.Eccentricity)
			{
				num = craftNode.Orbit.Eccentricity;
				_displayValue = $"{num:n2}";
			}
			else
			{
				IPlanetNode parent = craftNode.Parent;
				if (_planetName != parent.Name)
				{
					_planetName = parent.Name;
					_minValue = Mathd.Max(parent.PlanetData.MaxEstimatedTerrainElevation + 15000.0, parent.PlanetData.AtmosphereData?.Height ?? 0.0);
					_maxValue = 0.949999988079071 * parent.SphereOfInfluence;
					_value = Mathd.Clamp(_value, _minValue, _maxValue);
					UpdateDescription();
				}
				num = ((_property == PropertyType.Periapsis) ? craftNode.Orbit.PeriapsisDistance : craftNode.Orbit.ApoapsisDistance);
				num -= parent.PlanetData.Radius;
				_displayValue = Units.GetDistanceString((float)num, useAbsoluteValue: false);
				if (_comparisonType != ComparisonType.Less && num < _minValue)
				{
					return false;
				}
			}
			if (_comparisonType == ComparisonType.Equal)
			{
				return Math.Abs(num - _value) < _tolerance;
			}
			if (_comparisonType != ComparisonType.Greater)
			{
				return num < _value;
			}
			return num > _value;
		}

		private void UpdateDescription()
		{
			string arg = ((_comparisonType == ComparisonType.Less) ? "<" : ((_comparisonType == ComparisonType.Greater) ? ">" : "="));
			if (_property == PropertyType.Inclination)
			{
				base.Description = $"{_property} {arg} {Units.GetAngleString((float)_value, 0)}";
				if (_tolerance > 0.0 && _comparisonType == ComparisonType.Equal)
				{
					base.Description = base.Description + " (±" + Units.GetAngleString((float)_tolerance, 0) + ")";
				}
				return;
			}
			if (_property == PropertyType.Eccentricity)
			{
				base.Description = $"{_property} {arg} {$"{_value:n2}"}";
				if (_tolerance > 0.0 && _comparisonType == ComparisonType.Equal)
				{
					base.Description += $" (±{(float)_tolerance:0.00})";
				}
				return;
			}
			base.Description = $"{_property} {arg} {Units.GetDistanceString((float)_value)}";
			if (_tolerance > 0.0 && _comparisonType == ComparisonType.Equal)
			{
				base.Description = $"{_property} between {Units.GetDistanceString((float)Mathd.Max(_minValue, _value - _tolerance))} & {Units.GetDistanceString((float)Mathd.Min(_maxValue, _value + _tolerance))}";
				_flightDescription = base.Description + " (±" + Units.GetDistanceString((float)_tolerance) + ")";
			}
		}
	}
}
