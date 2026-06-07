using UnityEngine;

public class DefaultKeyIO
{
	private KeyCode keyValue;

	private AxisCode axisValue;

	public BlockBodyModel ParentBlockBodyModel { get; set; }

	public string Name { get; private set; }

	public string BaseName
	{
		get
		{
			if (Name.Contains("-"))
			{
				return Name.Substring(0, Name.LastIndexOf('-'));
			}
			return Name;
		}
	}

	public KeyCode KeyValue
	{
		get
		{
			return keyValue;
		}
		set
		{
			keyValue = value;
			if (keyValue != KeyCode.None)
			{
				axisValue = AxisCode.None;
			}
		}
	}

	public AxisCode AxisValue
	{
		get
		{
			return axisValue;
		}
		set
		{
			axisValue = value;
			if (axisValue != AxisCode.None)
			{
				keyValue = KeyCode.None;
			}
		}
	}

	public DefaultKeyIOPlace Place { get; private set; }

	public DefaultKeyIODirection Direction { get; private set; }

	public bool IsAxisSensitive { get; private set; }

	public bool IsInputWithoutKey { get; private set; }

	public bool IsOverwriteByOtherInput { get; set; }

	public bool IsHiddenInLogic { get; set; }

	public DefaultKeyIO(string name, KeyCode keyValue, DefaultKeyIOPlace place = DefaultKeyIOPlace.Component, bool isAxisSensitive = false, DefaultKeyIODirection direction = DefaultKeyIODirection.Input, bool isInputWithoutKey = false)
	{
		Name = name;
		KeyValue = keyValue;
		AxisValue = AxisCode.None;
		Place = place;
		Direction = direction;
		IsAxisSensitive = isAxisSensitive;
		IsInputWithoutKey = isInputWithoutKey;
		IsOverwriteByOtherInput = false;
		IsHiddenInLogic = false;
	}

	public bool IsAttachedInWritableSocketIO()
	{
		return ParentBlockBodyModel.ParentBlockModel.ParentCreationModel.LogicSystemModel.IsKeyAttachedInWritableSocketIO(this);
	}
}
