using System;
using System.ComponentModel;
using Noesis;

namespace NoesisApp
{
	public class ComparisonCondition : Animatable
	{
		public static readonly DependencyProperty LeftOperandProperty;

		public static readonly DependencyProperty OperatorProperty;

		public static readonly DependencyProperty RightOperandProperty;

		private Type _sourceType;

		private TypeConverter _converter;

		private object _left;

		private object _right;

		public object LeftOperand
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ComparisonConditionType Operator
		{
			get
			{
				return default(ComparisonConditionType);
			}
			set
			{
			}
		}

		public object RightOperand
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool Evaluate()
		{
			return false;
		}

		private void EnsureBindingValues()
		{
		}

		private void EnsureOperands()
		{
		}

		public ComparisonCondition()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
