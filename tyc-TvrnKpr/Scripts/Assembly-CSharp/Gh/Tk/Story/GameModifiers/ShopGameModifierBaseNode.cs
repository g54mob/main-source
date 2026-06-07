namespace Gh.Tk.Story.GameModifiers
{
	public abstract class ShopGameModifierBaseNode : GameModifierNode
	{
		public float durationInDaysF;

		public float GetEndsAtGameTime(ActiveStory story)
		{
			return 0f;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
