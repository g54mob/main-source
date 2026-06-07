public interface IInGameModelDevTool : IInGameDevTool
{
	ToolModelType GetToolModelType();

	void OnModelActivation();
}
