using XNode;

namespace Gh.Tk.Story.GameModifiers
{
	public abstract class TemporaryGameModifierNode : GameModifierNode
	{
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection output;

		public float durationInDaysF;

		protected string GetEndTimeKey()
		{
			return null;
		}

		protected float GetEndTime(ActiveStory story)
		{
			return 0f;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}
	}
}
