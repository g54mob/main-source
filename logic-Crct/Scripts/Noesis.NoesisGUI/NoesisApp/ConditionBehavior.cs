using Noesis;

namespace NoesisApp
{
	[ContentProperty("Condition")]
	public class ConditionBehavior : Behavior<TriggerBase>
	{
		public static readonly DependencyProperty ConditionProperty;

		public ICondition Condition
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public new ConditionBehavior Clone()
		{
			return null;
		}

		public new ConditionBehavior CloneCurrentValue()
		{
			return null;
		}

		protected override void OnAttached()
		{
		}

		protected override void OnDetaching()
		{
		}

		private void OnPreviewInvoke(object sender, PreviewInvokeEventArgs e)
		{
		}
	}
}
