using Noesis;

namespace NoesisApp
{
	public static class Interaction
	{
		private static readonly DependencyProperty BehaviorsProperty;

		private static readonly DependencyProperty TriggersProperty;

		public static BehaviorCollection GetBehaviors(DependencyObject d)
		{
			return null;
		}

		private static void OnBehaviorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		public static TriggerCollection GetTriggers(DependencyObject d)
		{
			return null;
		}

		private static void OnTriggersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}
	}
}
