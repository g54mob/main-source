using Noesis;

namespace NoesisGUIExtensions
{
	public static class StyleInteraction
	{
		private static readonly DependencyProperty BehaviorsProperty;

		private static readonly DependencyProperty TriggersProperty;

		public static StyleBehaviorCollection GetBehaviors(DependencyObject d)
		{
			return null;
		}

		public static void SetBehaviors(DependencyObject d, StyleBehaviorCollection value)
		{
		}

		private static void OnBehaviorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		public static StyleTriggerCollection GetTriggers(DependencyObject d)
		{
			return null;
		}

		public static void SetTriggers(DependencyObject d, StyleTriggerCollection value)
		{
		}

		private static void OnTriggersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}
	}
}
