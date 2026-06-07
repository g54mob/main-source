using Noesis;

namespace NoesisApp
{
	public class StoryboardCompletedTrigger : StoryboardTrigger
	{
		public new StoryboardCompletedTrigger Clone()
		{
			return null;
		}

		public new StoryboardCompletedTrigger CloneCurrentValue()
		{
			return null;
		}

		protected override void OnDetaching()
		{
		}

		protected override void OnStoryboardChanged(DependencyPropertyChangedEventArgs e)
		{
		}

		private void OnStoryboardCompleted(object sender, EventArgs e)
		{
		}
	}
}
