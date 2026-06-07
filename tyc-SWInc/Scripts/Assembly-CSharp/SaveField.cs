using System;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class SaveField : Attribute
{
	public string SerializedAs;

	public object DefaultValue;

	public GameReader.NewLoadMode LoadFor = GameReader.NewLoadMode.Any;

	public bool Undo = true;

	public bool HasDefault = true;

	public bool NetworkMode = true;

	public SaveField(string serializedAs, object defaultValue)
	{
		SerializedAs = serializedAs;
		DefaultValue = defaultValue;
	}

	public SaveField(object defaultValue)
	{
		DefaultValue = defaultValue;
	}

	public SaveField()
	{
		HasDefault = false;
	}
}
