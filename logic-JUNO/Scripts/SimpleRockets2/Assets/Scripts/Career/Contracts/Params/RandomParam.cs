using System;
using System.Xml.Linq;
using Assets.Scripts.DebugScripts;
using ModApi;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Params
{
	public class RandomParam : ContractParam
	{
		private const string DistributionAttribute = "distribution";

		private static int _seed;

		private AnimationCurve _distributionCurve;

		private float _distributionScale;

		private double _maxValue;

		private double _minValue;

		private int _round;

		private bool _stretch;

		private string _value;

		public override string Value => _value;

		public RandomParam(XElement xml, ContractParamContext context)
			: base(xml)
		{
			_minValue = xml.GetDoubleAttribute("min");
			_maxValue = xml.GetDoubleAttribute("max", 1.0);
			_stretch = xml.GetBoolAttribute("stretch", defaultValue: true);
			string stringAttribute = xml.GetStringAttribute("debugValue");
			if (_minValue > _maxValue)
			{
				throw new ArgumentException("minValue cannot be greater than maxValue");
			}
			_round = (int)xml.GetFloatAttribute("round");
			if (xml.Attribute("distribution") != null)
			{
				_distributionCurve = Utilities.GetAnimationCurveAttribute(xml, "distribution");
				_distributionScale = xml.GetFloatAttribute("distributionScale", 1f);
				if (Device.IsDebugBuild && xml.GetBoolAttribute("debug"))
				{
					new GameObject("Debug-" + base.Name).AddComponent<ViewAnimationCurveScript>().Curve = _distributionCurve;
				}
			}
			if (stringAttribute != null && context.ContractTemplate.IsDebug)
			{
				_value = stringAttribute;
			}
			else
			{
				GenerateValue();
			}
		}

		public static double RoundToNearest(double value, int nearest)
		{
			return Math.Round(value / (double)nearest, 0, MidpointRounding.AwayFromZero) * (double)nearest;
		}

		private void GenerateValue()
		{
			if (_minValue == _maxValue)
			{
				_value = _minValue.ToString();
				return;
			}
			if (_seed == 0)
			{
				_seed = (int)DateTime.UtcNow.Ticks;
			}
			System.Random random = new System.Random(++_seed);
			double value = ((_distributionCurve == null) ? random.NextDouble() : ((double)_distributionCurve.Evaluate((float)random.NextDouble() * _distributionScale)));
			value = ((!_stretch) ? Mathd.Clamp(value, _minValue, _maxValue) : (_minValue + Mathd.Clamp01(value) * (_maxValue - _minValue)));
			if (_round > 0)
			{
				value = RoundToNearest(value, _round);
			}
			_value = value.ToString();
		}
	}
}
