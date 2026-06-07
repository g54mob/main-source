public class IngameDevToolBoolParameter : InGameDevToolParameter<bool, IngameDevToolBoolParameter>
{
	public static IngameDevToolBoolParameter DefineBoolParameter(string withParameterName)
	{
		return new IngameDevToolBoolParameter().SetParameterName(withParameterName);
	}

	protected IngameDevToolBoolParameter()
		: base(InGameDevToolParameterType.Bool)
	{
	}
}
