using Factory.Pools;

public class NullInGameDevToolsRegistry : IInGameDevToolsRegistry, IReusable
{
	public void RegisterTools()
	{
	}

	public void RespondToInGameToolUse()
	{
	}

	public IInGameDevTool GetDevToolByCommandSerializationName(string commandSerializationName)
	{
		return null;
	}

	public IInGameModelDevTool GetModelDevToolByCommandSerializationName(string commandSerializationName)
	{
		return null;
	}

	public void UpdateEditorIfPresent()
	{
	}

	public void Reset()
	{
	}
}
