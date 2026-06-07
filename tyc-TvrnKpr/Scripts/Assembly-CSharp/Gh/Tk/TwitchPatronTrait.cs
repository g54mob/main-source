namespace Gh.Tk
{
	public class TwitchPatronTrait : ActorTrait, INameTagAIComponent
	{
		protected TwitchPatronTrait()
		{
		}

		public TwitchPatronTrait(Actor owner)
		{
		}

		public string GetNameModifier()
		{
			return null;
		}

		public bool ShouldShowNameTag()
		{
			return false;
		}
	}
}
