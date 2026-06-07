using System;
using System.Collections.Generic;
using ModApi.Math;
using UnityEngine;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class StringOperatorExpression : ProgramExpression
	{
		[ProgramNodeProperty]
		private string _op = "join";

		private ExpressionResult _result;

		[ProgramNodeProperty]
		private string _subOp;

		public override bool IsBoolean => _op == "contains";

		public string Operator
		{
			get
			{
				return _op;
			}
			set
			{
				_op = value;
			}
		}

		public StringOperatorExpression()
		{
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			switch (_op)
			{
			case "contains":
				EvaluateContainsOp(context);
				break;
			case "format":
				EvaluateFormatOp(context);
				break;
			case "join":
				EvaluateJoinOp(context);
				break;
			case "length":
				EvaluateLengthOp(context);
				break;
			case "letter":
				EvaluateLetterOp(context);
				break;
			case "substring":
				EvaluateSubstringOp(context);
				break;
			case "friendly":
				EvaluateFriendlyOp(context);
				break;
			}
			return _result;
		}

		public override List<ListItemInfo> GetListItems(string listId)
		{
			List<ListItemInfo> list = new List<ListItemInfo>();
			if (listId == "friendly")
			{
				list.Add(new ListItemInfo("acceleration", "Acceleration", "The acceleration in m/s2 as text formatted in a user friendly way.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("angularvelocity", "Angular Velocity", "The angular velocity in degrees per second as text formatted in a user friendly way.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("coordinate", "Coordinate", "The latitude and longitude given a lat,lon,agl vector. AGL will be included if not 0.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("density", "Density", "The density in kg/m3 as text formatted in a user friendly way.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("distance", "Distance", "The distance in meters as text formatted in a user friendly way.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("energy", "Energy", "The energy in Joules as text formatted in a user friendly way.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("force", "Force", "The force in Newtons as text formatted in a user friendly way.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("isp", "Specific Impulse", "The Isp in seconds as text formatted in a user friendly way.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("mass", "Mass", "The mass in kg as text formatted in a user friendly way.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("power", "Power", "The power in Watts as text formatted in a user friendly way.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("pressure", "Pressure", "The pressure in Pascals as text formatted in a user friendly way.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("temperature", "Temperature", "The temperature in Kelvin as text formatted in a user friendly way.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("time", "Time", "The time as text formatted in a user friendly way showing a unique unit with decimal values.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("date", "Time (date)", "The time as text formatted in a user friendly way, separating days, hours, minutes and seconds.", ListItemInfoType.Text));
				list.Add(new ListItemInfo("velocity", "Velocity", "The velocity in m/s as text formatted in a user friendly way.", ListItemInfoType.Text));
			}
			return list;
		}

		public override string GetListValue(string listId)
		{
			return _subOp;
		}

		public override void SetListValue(string listId, string value)
		{
			_subOp = value;
		}

		private void EvaluateContainsOp(IThreadContext context)
		{
			string text = LeftText(context).ToLower();
			string value = RightText(context).ToLower();
			_result.BoolValue = text.Contains(value);
		}

		private void EvaluateFormatOp(IThreadContext context)
		{
			try
			{
				string textValue = GetExpression(0).Evaluate(context).TextValue;
				object[] array = new object[base.Expressions.Count - 1];
				for (int i = 1; i < base.Expressions.Count; i++)
				{
					ExpressionResult expressionResult = GetExpression(i).Evaluate(context);
					if (expressionResult.IsNumberOrNumberAsText)
					{
						array[i - 1] = expressionResult.NumberValue;
					}
					else
					{
						array[i - 1] = expressionResult.TextValue;
					}
				}
				_result.TextValue = string.Format(textValue, array);
			}
			catch (Exception ex)
			{
				context.Log.LogError("Invalid string format: " + ex.ToString());
				_result.TextValue = string.Empty;
			}
		}

		private void EvaluateFriendlyOp(IThreadContext context)
		{
			string textValue = string.Empty;
			double numberValue = GetExpression(0).Evaluate(context).NumberValue;
			switch (_subOp)
			{
			case "acceleration":
				textValue = Units.GetAccelerationString((float)numberValue);
				break;
			case "angularvelocity":
				textValue = Units.GetAngularVelocityString((float)numberValue);
				break;
			case "coordinate":
				textValue = Units.GetCoordinatesString((Vector3)GetExpression(0).Evaluate(context).VectorValue);
				break;
			case "density":
				textValue = Units.GetDensityString((float)numberValue);
				break;
			case "distance":
				textValue = Units.GetDistanceString((float)numberValue);
				break;
			case "energy":
				textValue = Units.GetEnergyString((float)numberValue);
				break;
			case "force":
				textValue = Units.GetForceString((float)numberValue);
				break;
			case "isp":
				textValue = Units.GetIspString((float)numberValue);
				break;
			case "mass":
				textValue = Units.GetMassString((float)numberValue * 0.01f);
				break;
			case "power":
				textValue = Units.GetPowerString((float)numberValue);
				break;
			case "pressure":
				textValue = Units.GetPressureString((float)numberValue);
				break;
			case "time":
				textValue = Units.GetRelativeTimeString(numberValue);
				break;
			case "date":
				textValue = Units.GetStopwatchTimeString(numberValue);
				break;
			case "temperature":
				textValue = Units.GetTemperatureString((float)numberValue);
				break;
			case "velocity":
				textValue = Units.GetVelocityString((float)numberValue);
				break;
			}
			_result.TextValue = textValue;
		}

		private void EvaluateJoinOp(IThreadContext context)
		{
			string text = string.Empty;
			for (int i = 0; i < base.Expressions.Count; i++)
			{
				text += GetExpression(i).Evaluate(context).TextValue;
			}
			_result.TextValue = text;
		}

		private void EvaluateLengthOp(IThreadContext context)
		{
			string text = LeftText(context);
			_result.NumberValue = text.Length;
		}

		private void EvaluateLetterOp(IThreadContext context)
		{
			int num = LeftInt(context) - 1;
			string text = RightText(context);
			if (num >= 0 && num < text.Length)
			{
				_result.TextValue = text[num].ToString();
			}
		}

		private void EvaluateSubstringOp(IThreadContext context)
		{
			int num = (int)GetExpression(0).Evaluate(context).NumberValue - 1;
			int num2 = (int)GetExpression(1).Evaluate(context).NumberValue;
			string textValue = GetExpression(2).Evaluate(context).TextValue;
			if (num == -1)
			{
				num = 0;
			}
			if (num2 == 0)
			{
				num2 = textValue.Length;
			}
			if (num2 < num)
			{
				num2 = num;
			}
			num = Mathf.Clamp(num, 0, textValue.Length - 1);
			num2 = Mathf.Clamp(num2, 0, textValue.Length);
			_result.TextValue = textValue.Substring(num, num2 - num);
		}

		private string GetText(IThreadContext context, int expressionIndex)
		{
			return GetExpression(expressionIndex).Evaluate(context).TextValue;
		}

		private int LeftInt(IThreadContext context)
		{
			return (int)GetExpression(0).Evaluate(context).NumberValue;
		}

		private string LeftText(IThreadContext context)
		{
			return GetText(context, 0);
		}

		private string RightText(IThreadContext context)
		{
			return GetText(context, 1);
		}
	}
}
