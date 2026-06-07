using XNode;

namespace Gh.Tk.Story.SpecialUseCase
{
	public class GuildCompetitionStateCheckNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection tkGuildIsLeading;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection tkGuildIsLast;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection other;

		[DropDownChoice(typeof(StoryHelper), "GetAllStoryFlags")]
		public string[] competitors;

		[DropDownChoice(typeof(StoryHelper), "GetAllStoryFlags")]
		public string tkGuildKey;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
