using System;

public class GameEventField
{
	public enum FieldType
	{
		STRING = 0,
		GUID = 1,
		INT = 2,
		FLOAT = 3,
		BOOL = 4,
		TIME = 5
	}

	public string Name { get; private set; }

	public object Value { get; private set; }

	public FieldType Type { get; private set; }

	public string StringValue { get; private set; }

	public int IntValue { get; private set; }

	public float FloatValue { get; private set; }

	public bool BoolValue { get; private set; }

	public DateTime TimeValue { get; private set; }

	public GameEventField(string name, string value)
	{
		Name = name;
		Value = value;
		Type = FieldType.STRING;
		StringValue = value;
	}

	public GameEventField(string name, int value)
	{
		Name = name;
		Value = value;
		Type = FieldType.INT;
		IntValue = value;
	}

	public GameEventField(string name, float value)
	{
		Name = name;
		Value = value;
		Type = FieldType.FLOAT;
		FloatValue = value;
	}

	public GameEventField(string name, bool value)
	{
		Name = name;
		Value = value;
		Type = FieldType.BOOL;
		BoolValue = value;
	}

	public GameEventField(string name, DateTime value)
	{
		Name = name;
		Value = value;
		Type = FieldType.TIME;
		TimeValue = value;
	}

	public override string ToString()
	{
		return Name + "( " + Type.ToString() + " )";
	}
}
