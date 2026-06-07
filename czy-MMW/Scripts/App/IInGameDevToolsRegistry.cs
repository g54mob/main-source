using Factory.Pools;

public interface IInGameDevToolsRegistry : IReusable
{
	void RegisterTools();

	void RespondToInGameToolUse();

	IInGameDevTool GetDevToolByCommandSerializationName(string commandSerializationName);

	IInGameModelDevTool GetModelDevToolByCommandSerializationName(string commandSerializationName);

	void UpdateEditorIfPresent();
}
