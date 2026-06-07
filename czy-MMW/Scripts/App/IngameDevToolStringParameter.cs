public class IngameDevToolStringParameter : InGameDevToolParameter<string, IngameDevToolStringParameter>
{
	public static IngameDevToolStringParameter DefineStringParameter(string withParameterName)
	{
		return new IngameDevToolStringParameter().SetParameterName(withParameterName);
	}

	protected IngameDevToolStringParameter()
		: base(InGameDevToolParameterType.String)
	{
	}
}
