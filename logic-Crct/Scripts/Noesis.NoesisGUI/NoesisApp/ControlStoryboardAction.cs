using Noesis;

namespace NoesisApp
{
	public class ControlStoryboardAction : StoryboardAction
	{
		public static readonly DependencyProperty ControlStoryboardOptionProperty;

		public ControlStoryboardOption ControlStoryboardOption
		{
			get
			{
				return default(ControlStoryboardOption);
			}
			set
			{
			}
		}

		public new ControlStoryboardAction Clone()
		{
			return null;
		}

		public new ControlStoryboardAction CloneCurrentValue()
		{
			return null;
		}

		protected override void Invoke(object parameter)
		{
		}
	}
}
