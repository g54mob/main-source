using Noesis;

namespace NoesisApp
{
	public class PropertyChangedTrigger : TriggerBase<DependencyObject>
	{
		public static readonly DependencyProperty BindingProperty;

		public object Binding
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public new PropertyChangedTrigger Clone()
		{
			return null;
		}

		public new PropertyChangedTrigger CloneCurrentValue()
		{
			return null;
		}

		private static void OnBindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		protected override void OnAttached()
		{
		}

		protected virtual void EvaluateBindingChange(object args)
		{
		}
	}
}
