namespace Gh.Tk
{
	public interface INestedTooltipProvider : ITooltipProvider
	{
		int GetId();

		Tooltip3DUIView GetParent();
	}
}
