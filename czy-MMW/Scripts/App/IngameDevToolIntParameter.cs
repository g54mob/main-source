public class IngameDevToolIntParameter : InGameDevToolNumericParameter<int, IngameDevToolIntParameter>
{
	public static IngameDevToolIntParameter DefineIntParameter(string withParameterName)
	{
		return new IngameDevToolIntParameter().SetParameterName(withParameterName);
	}

	public static IngameDevToolIntParameter DefineIntParameter(string withParameterName, string modelFieldName)
	{
		return new IngameDevToolIntParameter().SetParameterName(withParameterName).SetModelParameterFieldName(modelFieldName);
	}

	protected IngameDevToolIntParameter()
		: base(InGameDevToolParameterType.Int)
	{
	}
}
