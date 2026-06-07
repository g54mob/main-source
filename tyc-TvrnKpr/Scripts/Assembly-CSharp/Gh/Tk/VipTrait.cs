namespace Gh.Tk
{
	public class VipTrait : PriorityTrait, INameTagAIComponent
	{
		protected VipTrait()
		{
		}

		public VipTrait(Actor owner)
		{
		}

		public bool ShouldShowNameTag()
		{
			return false;
		}

		public virtual string GetNameModifier()
		{
			return null;
		}
	}
}
