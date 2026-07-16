using System;
using System.Collections.Generic;
using System.Globalization;

public static class ConditionEvaluator
{
	public static bool Evaluate(string expression, Dictionary<string, object> context)
	{
		expression = expression.Trim();
		if (expression.Contains(">="))
		{
			return Compare(expression, context, ">=");
		}
		if (expression.Contains("<="))
		{
			return Compare(expression, context, "<=");
		}
		if (expression.Contains("=="))
		{
			return Compare(expression, context, "==");
		}
		if (expression.Contains("!="))
		{
			return Compare(expression, context, "!=");
		}
		if (expression.Contains(">"))
		{
			return Compare(expression, context, ">");
		}
		if (expression.Contains("<"))
		{
			return Compare(expression, context, "<");
		}
		throw new Exception("Unsupported expression: " + expression);
	}

	private static bool Compare(string expr, Dictionary<string, object> context, string op)
	{
		string[] array = expr.Split(new string[1] { op }, StringSplitOptions.None);
		if (array.Length != 2)
		{
			throw new Exception("Invalid expression: " + expr);
		}
		string name = array[0].Trim();
		string s = array[1].Trim();
		object obj = ResolveValue(name, context);
		object obj2 = ParseValue(s);
		return op switch
		{
			"==" => object.Equals(obj, obj2), 
			"!=" => !object.Equals(obj, obj2), 
			">" => Convert.ToSingle(obj) > Convert.ToSingle(obj2), 
			"<" => Convert.ToSingle(obj) < Convert.ToSingle(obj2), 
			">=" => Convert.ToSingle(obj) >= Convert.ToSingle(obj2), 
			"<=" => Convert.ToSingle(obj) <= Convert.ToSingle(obj2), 
			_ => throw new Exception("Unsupported operator: " + op), 
		};
	}

	private static object ResolveValue(string name, Dictionary<string, object> context)
	{
		if (context.TryGetValue(name, out var value))
		{
			return value;
		}
		throw new Exception("Variable not found in context: " + name);
	}

	private static object ParseValue(string s)
	{
		if (int.TryParse(s, out var result))
		{
			return result;
		}
		if (float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var result2))
		{
			return result2;
		}
		if (bool.TryParse(s, out var result3))
		{
			return result3;
		}
		return s.Trim('"');
	}
}
