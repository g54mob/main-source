using System;
using UnityEngine;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class VectorExpression : ProgramExpression
	{
		private ExpressionResult _result;

		public override bool IsBoolean => false;

		public VectorExpression()
		{
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			Vector3d vectorValue = default(Vector3d);
			vectorValue.x = GetExpression(0).Evaluate(context).NumberValue;
			vectorValue.y = GetExpression(1).Evaluate(context).NumberValue;
			vectorValue.z = GetExpression(2).Evaluate(context).NumberValue;
			_result.VectorValue = vectorValue;
			return _result;
		}
	}
}
