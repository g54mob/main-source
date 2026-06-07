using Noesis;

namespace NoesisApp
{
	public abstract class StoryboardTrigger : TriggerBase<DependencyObject>
	{
		public static readonly DependencyProperty StoryboardProperty;

		public Storyboard Storyboard
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public new StoryboardTrigger Clone()
		{
			return null;
		}

		public new StoryboardTrigger CloneCurrentValue()
		{
			return null;
		}

		private static void OnStoryboardChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		protected virtual void OnStoryboardChanged(DependencyPropertyChangedEventArgs e)
		{
		}
	}
}
