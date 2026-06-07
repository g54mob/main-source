namespace Gh.Tk.Story.Conversations
{
	public class ConversationTestAnimationNode : ConversationAnimationNode
	{
		public EmotionalState state;

		public string animation;

		public override (EmotionalState, string, bool) GetAnimationSetting()
		{
			return default((EmotionalState, string, bool));
		}
	}
}
