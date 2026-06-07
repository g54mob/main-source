using System;
using System.Xml.Linq;
using Assets.Scripts.DebugScripts;
using ModApi;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Params
{
	public class RandomListParam : ContractParam
	{
		private const string DistributionAttribute = "distribution";

		private static int _seed;

		private AnimationCurve _distributionCurve;

		private float _distributionScale;

		private string _value;

		private string[] _values;

		public override string Value => _value;

		public RandomListParam(XElement xml)
			: base(xml)
		{
			string stringAttribute = xml.GetStringAttribute("values");
			_values = stringAttribute.Split(new char[1] { ';' });
			if (xml.Attribute("distribution") != null)
			{
				_distributionCurve = Utilities.GetAnimationCurveAttribute(xml, "distribution");
				_distributionScale = xml.GetFloatAttribute("distributionScale", 1f);
				if (Device.IsDebugBuild && xml.GetBoolAttribute("debug"))
				{
					new GameObject("Debug-" + base.Name).AddComponent<ViewAnimationCurveScript>().Curve = _distributionCurve;
				}
			}
			GenerateValue();
		}

		public static double RoundToNearest(double value, int nearest)
		{
			return Math.Round(value / (double)nearest, 0, MidpointRounding.AwayFromZero) * (double)nearest;
		}

		private void GenerateValue()
		{
			if (_seed == 0)
			{
				_seed = (int)DateTime.UtcNow.Ticks;
			}
			System.Random random = new System.Random(++_seed);
			int num = 0;
			num = ((_distributionCurve == null) ? random.Next(0, _values.Length) : ((int)_distributionCurve.Evaluate((float)random.NextDouble())));
			_value = _values[Mathf.Clamp(num, 0, _values.Length - 1)];
		}
	}
}
