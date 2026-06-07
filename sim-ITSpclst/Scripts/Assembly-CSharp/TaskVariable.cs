using System;

[Serializable]
public class TaskVariable
{
	public string name;

	public string typeName;

	public string valueAsString;

	public object GetValue()
	{
		return null;
	}

	public void SetValue(object value)
	{
	}
}
