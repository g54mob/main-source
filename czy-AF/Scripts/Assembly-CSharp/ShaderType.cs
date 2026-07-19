public class ShaderType
{
	public string name;

	public string[] values;

	public string[] valueNames;

	public float[] defaultValues;

	public ShaderType(string _name, string[] _values, string[] _valueNames, float[] _defaultValues)
	{
		name = _name;
		values = _values;
		valueNames = _valueNames;
		defaultValues = _defaultValues;
	}

	public ShaderType(string _name)
	{
		name = _name;
	}
}
