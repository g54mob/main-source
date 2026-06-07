using System;
using System.Runtime.CompilerServices;

namespace Gh.Tk.Story.Logic
{
	public class GuideNode : ChallengeBaseNode
	{
		public GuidePriority displayPriority;

		public bool automaticallyReTriggerWhenRequirementsNoLongerMatch;

		private string IsVisibleKey => null;

		public static event EventHandler OnVisibleChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override string GetDefaultGroupKey()
		{
			return null;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void Complete(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		protected override void OnInitializingUINotificationData(ActiveStory story, UINotificationData data)
		{
		}

		protected override int GetNotificationGroupPriority()
		{
			return 0;
		}

		public bool IsVisible(ActiveStory story)
		{
			return false;
		}
	}
}
