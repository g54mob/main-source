using Noesis;

namespace NoesisApp
{
	public abstract class StoryboardAction : TriggerAction<DependencyObject>
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

		public new StoryboardAction Clone()
		{
			return null;
		}

		public new StoryboardAction CloneCurrentValue()
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
