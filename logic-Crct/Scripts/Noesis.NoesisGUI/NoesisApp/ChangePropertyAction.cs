using System.ComponentModel;
using System.Reflection;
using Noesis;

namespace NoesisApp
{
	public class ChangePropertyAction : TargetedTriggerAction<object>
	{
		public static readonly DependencyProperty PropertyNameProperty;

		public static readonly DependencyProperty ValueProperty;

		public static readonly DependencyProperty DurationProperty;

		public static readonly DependencyProperty IncrementProperty;

		private PropertyInfo _property;

		private TypeConverter _converter;

		private object _convertedValue;

		public string PropertyName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public Duration Duration
		{
			get
			{
				return default(Duration);
			}
			set
			{
			}
		}

		public bool Increment
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public new ChangePropertyAction Clone()
		{
			return null;
		}

		public new ChangePropertyAction CloneCurrentValue()
		{
			return null;
		}

		private static void OnPropertyNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnDurationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnIncrementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		protected override void Invoke(object parameter)
		{
		}

		private bool UpdateProperty()
		{
			return false;
		}

		private void UpdateConvertedValue()
		{
		}

		private void SetPropertyValue()
		{
		}
	}
}
