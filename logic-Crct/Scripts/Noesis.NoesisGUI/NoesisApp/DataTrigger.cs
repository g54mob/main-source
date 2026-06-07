using System;
using System.ComponentModel;
using Noesis;

namespace NoesisApp
{
	public class DataTrigger : PropertyChangedTrigger
	{
		public static readonly DependencyProperty ValueProperty;

		public static readonly DependencyProperty ComparisonProperty;

		private Type _sourceType;

		private TypeConverter _converter;

		private object _binding;

		private object _value;

		private ComparisonConditionType _comparison;

		public object Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ComparisonConditionType Comparison
		{
			get
			{
				return default(ComparisonConditionType);
			}
			set
			{
			}
		}

		public new DataTrigger Clone()
		{
			return null;
		}

		public new DataTrigger CloneCurrentValue()
		{
			return null;
		}

		private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnComparisonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		protected override void OnAttached()
		{
		}

		protected override void EvaluateBindingChange(object args)
		{
		}

		private void Evaluate(object args)
		{
		}

		private void EnsureBindingValues()
		{
		}

		private bool UpdateSourceType()
		{
			return false;
		}

		private bool UpdateTriggerValue()
		{
			return false;
		}

		private bool UpdateComparison()
		{
			return false;
		}

		private bool Compare()
		{
			return false;
		}
	}
}
