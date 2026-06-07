namespace Gh.Tk
{
	public class NestedButton3DUIView : Button3DUIView, ITooltipProviderOverrider
	{
		public ITooltipProvider ParentTooltipProvider { get; set; }

		protected override void Awake()
		{
		}

		public ITooltipProvider GetTooltipProvider()
		{
			return null;
		}
	}
}
