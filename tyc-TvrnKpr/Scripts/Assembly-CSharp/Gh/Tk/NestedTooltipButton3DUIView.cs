namespace Gh.Tk
{
	public class NestedTooltipButton3DUIView : Button3DUIView, INestedTooltipProvider, ITooltipProvider, ITooltipDelayOverrider
	{
		private Tooltip3DUIView _parent;

		public int GetId()
		{
			return 0;
		}

		protected override void Start()
		{
		}

		public Tooltip3DUIView GetParent()
		{
			return null;
		}

		public float GetTooltipDelay()
		{
			return 0f;
		}
	}
}
