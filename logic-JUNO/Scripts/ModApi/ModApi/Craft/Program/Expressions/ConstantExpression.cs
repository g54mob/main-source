using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class ConstantExpression : ProgramExpression
	{
		public ExpressionResult ExpressionResult { get; private set; }

		public override bool IsBoolean => ExpressionResult.ExpressionType == ExpressionType.Boolean;

		public ConstantExpression()
		{
			ExpressionResult = new ExpressionResult();
		}

		public ConstantExpression(bool value)
		{
			ExpressionResult = new ExpressionResult();
			ExpressionResult.BoolValue = value;
		}

		public ConstantExpression(double number)
		{
			ExpressionResult = new ExpressionResult();
			ExpressionResult.NumberValue = number;
		}

		public ConstantExpression(string text)
		{
			ExpressionResult = new ExpressionResult();
			ExpressionResult.TextValue = text;
		}

		public ConstantExpression(Vector3d vector)
		{
			ExpressionResult = new ExpressionResult();
			ExpressionResult.VectorValue = vector;
		}

		public ConstantExpression(List<ExpressionListItem> list)
		{
			ExpressionResult = new ExpressionResult(list);
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			return ExpressionResult;
		}

		public override void OnDeserialized(XElement xml)
		{
			base.OnDeserialized(xml);
			ExpressionResult = new ExpressionResult(xml);
		}

		public override void OnSerialized(XElement xml)
		{
			base.OnSerialized(xml);
			ExpressionResult.SaveXml(xml);
		}
	}
}
