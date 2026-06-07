using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Career
{
	public class StringProcessor
	{
		private Dictionary<string, IStringProcessorParam> _params = new Dictionary<string, IStringProcessorParam>();

		public Dictionary<string, IStringProcessorParam> Params => _params;

		public static string FormatDouble(double value, string format)
		{
			switch (format)
			{
			case "bool":
				if (!(value > 0.0))
				{
					return "false";
				}
				return "true";
			case "distance":
				return Units.GetDistanceString((float)value);
			case "altitude":
				return Units.GetDistanceString((float)value, useAbsoluteValue: false);
			case "mass":
				return Units.GetMassString((float)(value * 0.009999999776482582));
			case "money":
				return Units.GetMoneyString((long)value);
			case "s":
				if (value != 1.0)
				{
					return "s";
				}
				return string.Empty;
			case "time":
				return Units.GetRelativeTimeString(value);
			case "velocity":
				return Units.GetVelocityString((float)value);
			case "mach":
				return "Mach " + $"{value:n1}";
			case "acceleration":
				return Units.GetAccelerationString((float)value);
			case "angle":
				return Units.GetAngleString((float)value, 2);
			default:
				return string.Format("{0:" + format + "}", value);
			}
		}

		public static string FormatValue(string value, string format)
		{
			if (format == "coords")
			{
				return FormatLatLon(value);
			}
			return FormatDouble(double.Parse(value), format);
		}

		public static string FormatVector(Vector3 value, string format)
		{
			if (format == "coords")
			{
				return Units.GetCoordinatesString(value);
			}
			return value.ToString();
		}

		public string ProcessString(string s)
		{
			if (!string.IsNullOrWhiteSpace(s))
			{
				Regex regex = new Regex("\\@([\\w:]+)");
				regex.Matches(s);
				return regex.Replace(s, delegate(Match m)
				{
					string[] array = m.Groups[1].Value.Split(new char[1] { ':' }, StringSplitOptions.RemoveEmptyEntries);
					string text = array[0];
					if (!_params.TryGetValue(text, out var value))
					{
						throw new KeyNotFoundException("Could not find param with name " + text + ".");
					}
					if (array.Length == 1)
					{
						return value.Value;
					}
					if (array.Length == 2)
					{
						return FormatValue(value.Value, array[1]);
					}
					throw new InvalidOperationException("Invalid parameter syntax: " + s);
				});
			}
			return s;
		}

		public void SetParam(string name, IStringProcessorParam param)
		{
			_params[name] = param;
		}

		private static string FormatLatLon(string value)
		{
			string[] array = value.Split(',');
			double num = double.Parse(array[0]);
			double num2 = double.Parse(array[1]);
			string text = "N";
			string text2 = "E";
			if (num < 0.0)
			{
				text = "S";
				num = 0.0 - num;
			}
			if (num2 < 0.0)
			{
				text2 = "W";
				num2 = 0.0 - num2;
			}
			return $"{num:00.00}{text} {num2:00.00}{text2}";
		}
	}
}
