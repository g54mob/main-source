using System;
using UnityEngine;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class EvaluationExpression : ProgramExpression
	{
		private ExpressionResult _result;

		private Func<double> _compiledFunctionNumeric;

		private Func<Vector3d> _compiledFunctionVector;

		private Func<bool> _compiledFunctionBoolean;

		private Func<string> _compiledFunctionString;

		private string _compiledText;

		private Delegate CurrentDelegate
		{
			get
			{
				Delegate compiledFunctionNumeric = _compiledFunctionNumeric;
				if ((object)compiledFunctionNumeric != null)
				{
					return compiledFunctionNumeric;
				}
				compiledFunctionNumeric = _compiledFunctionVector;
				if ((object)compiledFunctionNumeric != null)
				{
					return compiledFunctionNumeric;
				}
				compiledFunctionNumeric = _compiledFunctionBoolean;
				if ((object)compiledFunctionNumeric != null)
				{
					return compiledFunctionNumeric;
				}
				return _compiledFunctionString;
			}
			set
			{
				_compiledFunctionNumeric = null;
				_compiledFunctionVector = null;
				_compiledFunctionBoolean = null;
				_compiledFunctionString = null;
				if ((object)value == null)
				{
					return;
				}
				if (value is Func<double> compiledFunctionNumeric)
				{
					_compiledFunctionNumeric = compiledFunctionNumeric;
					return;
				}
				if (value is Func<Vector3d> compiledFunctionVector)
				{
					_compiledFunctionVector = compiledFunctionVector;
					return;
				}
				if (value is Func<bool> compiledFunctionBoolean)
				{
					_compiledFunctionBoolean = compiledFunctionBoolean;
					return;
				}
				if (value is Func<string> compiledFunctionString)
				{
					_compiledFunctionString = compiledFunctionString;
					return;
				}
				object[] args = new object[value.Method.GetParameters().Length];
				_compiledFunctionString = () => value.DynamicInvoke(args).ToString();
			}
		}

		public override bool IsBoolean => false;

		public EvaluationExpression()
		{
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			string textValue = GetExpression(0).Evaluate(context).TextValue;
			Delegate currentDelegate = CurrentDelegate;
			if (textValue != _compiledText || (object)currentDelegate == null)
			{
				if ((object)currentDelegate != null)
				{
					context.Craft.ReleaseInputExpression(currentDelegate);
				}
				CurrentDelegate = context.Craft.GetInputExpression(textValue);
				_compiledText = textValue;
			}
			if (_compiledFunctionNumeric != null)
			{
				_result.NumberValue = _compiledFunctionNumeric();
			}
			else if (_compiledFunctionBoolean != null)
			{
				_result.BoolValue = _compiledFunctionBoolean();
			}
			else if (_compiledFunctionVector != null)
			{
				_result.VectorValue = _compiledFunctionVector();
			}
			else if (_compiledFunctionString != null)
			{
				_result.TextValue = _compiledFunctionString();
			}
			return _result;
		}
	}
}
