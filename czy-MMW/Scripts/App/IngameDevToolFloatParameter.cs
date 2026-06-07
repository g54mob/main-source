using FixMath;

public class IngameDevToolFloatParameter : InGameDevToolNumericParameter<Fix64, IngameDevToolFloatParameter>
{
	public static IngameDevToolFloatParameter DefineFloatParameter(string withParameterName)
	{
		return new IngameDevToolFloatParameter().SetParameterName(withParameterName);
	}

	public static IngameDevToolFloatParameter DefineFloatParameter(string withParameterName, string modelFieldName)
	{
		return new IngameDevToolFloatParameter().SetParameterName(withParameterName).SetModelParameterFieldName(modelFieldName);
	}

	protected IngameDevToolFloatParameter()
		: base(InGameDevToolParameterType.Float)
	{
	}
}
