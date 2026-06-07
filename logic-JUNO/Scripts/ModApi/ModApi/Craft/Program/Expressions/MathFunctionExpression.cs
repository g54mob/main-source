using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class MathFunctionExpression : ProgramExpression
	{
		private class MathFunction
		{
			public Func<double, double> Execute { get; set; }

			public ListItemInfoType ItemType { get; }

			public string Name { get; set; }

			public string Tooltip { get; }

			public MathFunction(string name, ListItemInfoType itemType, string tooltip, Func<double, double> execute)
			{
				Name = name;
				ItemType = itemType;
				Tooltip = tooltip;
				Execute = execute;
			}
		}

		private static Dictionary<string, MathFunction> _functions;

		[ProgramNodeProperty]
		private string _function;

		private MathFunction _mathFunction;

		private ExpressionResult _result;

		public ProgramExpression Expression => GetExpression(0);

		public string FunctionName
		{
			get
			{
				return _function;
			}
			set
			{
				SetFunction(value);
			}
		}

		public IEnumerable<string> FunctionNames => _functions.Keys;

		public override bool IsBoolean => false;

		static MathFunctionExpression()
		{
			_functions = new Dictionary<string, MathFunction>();
			AddMathFunction("abs", ListItemInfoType.Number, "Returns the absolute value of the number.", (double x) => Mathd.Abs(x));
			AddMathFunction("floor", ListItemInfoType.Number, "Returns largest integer smaller than or equal to the number.", (double x) => Mathd.Floor(x));
			AddMathFunction("ceiling", ListItemInfoType.Number, "Returns smallest integer larger than or equal to the number.", (double x) => Mathd.Ceil(x));
			AddMathFunction("round", ListItemInfoType.Number, "Rounds the number to the closest integer.", (double x) => Mathd.Round(x));
			AddMathFunction("sqrt", ListItemInfoType.Number, "Calculates the square root of the number.", (double x) => Mathd.Sqrt(x));
			AddMathFunction("sin", ListItemInfoType.Number, "Calculates the sine of the number.", (double x) => Mathd.Sin(x));
			AddMathFunction("cos", ListItemInfoType.Number, "Calculates the cosine of the number.", (double x) => Mathd.Cos(x));
			AddMathFunction("tan", ListItemInfoType.Number, "Calculates the tangent of the number.", (double x) => Mathd.Tan(x));
			AddMathFunction("asin", ListItemInfoType.Radians, "Calculates the arc-sine of the number, in radians.", (double x) => Mathd.Asin(x));
			AddMathFunction("acos", ListItemInfoType.Radians, "Calculates the arc-cosine of the number, in radians.", (double x) => Mathd.Acos(x));
			AddMathFunction("atan", ListItemInfoType.Radians, "Calculates the arc-tangent of the number, in radians.", (double x) => Mathd.Atan(x));
			AddMathFunction("ln", ListItemInfoType.Number, "Calculates the natural log of the number.", (double x) => Mathd.Log(x));
			AddMathFunction("log", ListItemInfoType.Number, "Calculates the log base 10 of the number.", (double x) => Mathd.Log10(x));
			AddMathFunction("deg2rad", ListItemInfoType.Number, "Converts the number from degrees to radians.", (double x) => x * 0.01745329);
			AddMathFunction("rad2deg", ListItemInfoType.Number, "Converts the number from radians to degrees.", (double x) => x * 57.29578);
		}

		public MathFunctionExpression()
		{
			if (_function == null)
			{
				_function = _functions.Values.First().Name;
			}
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			if (_mathFunction != null)
			{
				_result.NumberValue = _mathFunction.Execute(Expression.Evaluate(context).NumberValue);
			}
			else
			{
				context.Log.LogError($"Unsupported math function: '{_function}'", context);
			}
			return _result;
		}

		public override List<ListItemInfo> GetListItems(string listId)
		{
			List<ListItemInfo> list = new List<ListItemInfo>();
			foreach (MathFunction value in _functions.Values)
			{
				list.Add(new ListItemInfo(value.Name, value.Name, value.Tooltip, value.ItemType));
			}
			return list;
		}

		public override string GetListValue(string listId)
		{
			return _mathFunction?.Name;
		}

		public override void OnDeserialized(XElement xml)
		{
			base.OnDeserialized(xml);
			SetFunction(_function);
		}

		public override void SetListValue(string listId, string value)
		{
			SetFunction(value);
		}

		private static void AddMathFunction(string name, ListItemInfoType itemType, string tooltip, Func<double, double> function)
		{
			_functions[name] = new MathFunction(name, itemType, tooltip, function);
		}

		private void SetFunction(string function)
		{
			_functions.TryGetValue(function, out _mathFunction);
			_function = function;
		}
	}
}
