using System;
using System.Collections.Generic;
using UnityEngine;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class VectorOperatorExpression : ProgramExpression
	{
		[ProgramNodeProperty]
		private string _op;

		private ExpressionResult _result;

		public override bool IsBoolean => false;

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

		public VectorOperatorExpression()
		{
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			ExpressionResult expressionResult = GetExpression(0).Evaluate(context);
			ExpressionResult expressionResult2 = ((base.Expressions.Count >= 2) ? GetExpression(1).Evaluate(context) : null);
			switch (_op)
			{
			case "angle":
				_result.NumberValue = Vector3d.Angle(expressionResult.VectorValue, expressionResult2.VectorValue);
				break;
			case "clamp":
				_result.VectorValue = Vector3d.ClampMagnitude(expressionResult.VectorValue, expressionResult2.NumberValue);
				break;
			case "cross":
				_result.VectorValue = Vector3d.Cross(expressionResult.VectorValue, expressionResult2.VectorValue);
				break;
			case "dot":
				_result.NumberValue = Vector3d.Dot(expressionResult.VectorValue, expressionResult2.VectorValue);
				break;
			case "dist":
				_result.NumberValue = (expressionResult.VectorValue - expressionResult2.VectorValue).magnitude;
				break;
			case "min":
				_result.VectorValue = Vector3d.Min(expressionResult.VectorValue, expressionResult2.VectorValue);
				break;
			case "max":
				_result.VectorValue = Vector3d.Max(expressionResult.VectorValue, expressionResult2.VectorValue);
				break;
			case "project":
				_result.VectorValue = Vector3d.Project(expressionResult.VectorValue, expressionResult2.VectorValue);
				break;
			case "length":
				_result.NumberValue = expressionResult.VectorValue.magnitude;
				break;
			case "norm":
				_result.VectorValue = expressionResult.VectorValue.normalized;
				break;
			case "x":
				_result.NumberValue = expressionResult.VectorValue.x;
				break;
			case "y":
				_result.NumberValue = expressionResult.VectorValue.y;
				break;
			case "z":
				_result.NumberValue = expressionResult.VectorValue.z;
				break;
			case "hex":
				_result.VectorValue = GetColorFromHex(expressionResult?.TextValue);
				break;
			case "scale":
				_result.VectorValue = Vector3d.Scale(expressionResult.VectorValue, expressionResult2.VectorValue);
				break;
			default:
				_result.VectorValue = Vector3d.zero;
				break;
			}
			return _result;
		}

		public override List<ListItemInfo> GetListItems(string listId)
		{
			List<ListItemInfo> list = new List<ListItemInfo>();
			if (base.Expressions.Count == 1)
			{
				list.Add(new ListItemInfo("x", "x", "Returns the x component of the vector.", ListItemInfoType.Number));
				list.Add(new ListItemInfo("y", "y", "Returns the y component of the vector.", ListItemInfoType.Number));
				list.Add(new ListItemInfo("z", "z", "Returns the z component of the vector.", ListItemInfoType.Number));
				list.Add(new ListItemInfo("length", "length", "Returns the magnitude/length of the vector.", ListItemInfoType.Number));
				list.Add(new ListItemInfo("norm", "norm", "Returns a vector in the same direction, but ensures its length is 1.", ListItemInfoType.Vector));
			}
			else if (base.Expressions.Count == 2)
			{
				list.Add(new ListItemInfo("angle", "angle", "Calculates the angle between two vectors, in degrees.", ListItemInfoType.Degrees));
				list.Add(new ListItemInfo("clamp", "clamp", "Clamps the magnitude of the left vector to the magnitude of the right vector or constant number.", ListItemInfoType.Number));
				list.Add(new ListItemInfo("cross", "cross", "Calculates the cross product of the two vectors.", ListItemInfoType.Vector));
				list.Add(new ListItemInfo("dot", "dot", "Calculates the dot product of the two vectors.", ListItemInfoType.Number));
				list.Add(new ListItemInfo("dist", "dist", "Calculates the distance between the two vectors.", ListItemInfoType.Number));
				list.Add(new ListItemInfo("min", "min", "Returns a vector made of the minimum components of each vector.", ListItemInfoType.Vector));
				list.Add(new ListItemInfo("max", "max", "Returns a vector made of the maximum components of each vector.", ListItemInfoType.Vector));
				list.Add(new ListItemInfo("project", "project", "Projects the left vector onto the right vector.", ListItemInfoType.Vector));
				list.Add(new ListItemInfo("scale", "scale", "Multiplies two vectors component-wise.", ListItemInfoType.Vector));
			}
			return list;
		}

		public override string GetListValue(string listId)
		{
			return _op;
		}

		public override void SetListValue(string listId, string value)
		{
			_op = value;
		}

		private static Vector3d GetColorFromHex(string s)
		{
			s = "#" + s?.Trim(' ', '#');
			if (ColorUtility.TryParseHtmlString(s, out var color))
			{
				return new Vector3d(color.r, color.g, color.b);
			}
			return Vector3d.zero;
		}
	}
}
