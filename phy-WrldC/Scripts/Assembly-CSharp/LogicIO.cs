using System.Collections.Generic;
using UnityEngine;

public class LogicIO
{
	private float signal;

	private KeyCode defaultKey;

	private AxisCode defaultAxis;

	public BlockBodyView ParentBlockBodyView { get; set; }

	public HingeJointView ParentHingeJointView { get; set; }

	public int BlockId => ParentBlockBodyView.ParentBlockView.Id;

	public int BodyIndex => ParentBlockBodyView.Index;

	public int HingeJointIndex => ParentHingeJointView.Index;

	public string Name { get; private set; }

	public List<SocketIO> SocketIOs { get; private set; }

	public KeyCode DefaultKey
	{
		get
		{
			return defaultKey;
		}
		set
		{
			defaultKey = value;
			if (defaultKey != KeyCode.None)
			{
				defaultAxis = AxisCode.None;
			}
		}
	}

	public LogicIODefaultKeyType DefaultKeyType { get; set; }

	public AxisCode DefaultAxis
	{
		get
		{
			return defaultAxis;
		}
		set
		{
			defaultAxis = value;
			if (defaultAxis != AxisCode.None)
			{
				defaultKey = KeyCode.None;
			}
		}
	}

	public bool IsKeyAssignmented => DefaultKey != KeyCode.None;

	public bool IsAxisAssigmented => DefaultAxis != AxisCode.None;

	public LogicIODirection Direction { get; private set; }

	public LogicIOPlace Place { get; private set; }

	public LogicIOType Type { get; private set; }

	public LogicIOValueType ValueType { get; set; }

	public bool IsInputWithoutKey { get; set; }

	public LogicIO(string name, LogicIODirection direction, float analogSignal, LogicIOPlace place = LogicIOPlace.Component)
	{
		signal = analogSignal;
		Name = name;
		Direction = direction;
		Place = place;
		Type = LogicIOType.Float;
		ValueType = LogicIOValueType.Normalized;
		DefaultKey = KeyCode.None;
		DefaultKeyType = LogicIODefaultKeyType.Down;
		DefaultAxis = AxisCode.None;
		IsInputWithoutKey = false;
		SocketIOs = new List<SocketIO>();
	}

	public LogicIO(string name, LogicIODirection direction, bool digitalSignal, LogicIOPlace place = LogicIOPlace.Component)
	{
		signal = (digitalSignal ? 1f : 0f);
		Name = name;
		Direction = direction;
		Place = place;
		Type = LogicIOType.Bool;
		ValueType = LogicIOValueType.Normalized;
		DefaultKey = KeyCode.None;
		DefaultKeyType = LogicIODefaultKeyType.Down;
		DefaultAxis = AxisCode.None;
		IsInputWithoutKey = false;
		SocketIOs = new List<SocketIO>();
	}

	public bool HasWritableAndActiveSocketIOs()
	{
		for (int i = 0; i < SocketIOs.Count; i++)
		{
			if (SocketIOs[i].Accessibility == SocketIOAccessibility.Writable && SocketIOs[i].ParentInstruction.ParentLogic.Active)
			{
				return true;
			}
		}
		return false;
	}

	public void RemoveSocketIO(SocketIO socketIO)
	{
		SocketIOs.Remove(socketIO);
	}

	public void DetachAllSocketIOs()
	{
		SocketIOs.RemoveAll((SocketIO item) => item == null);
		SocketIO[] array = SocketIOs.ToArray();
		for (int num = 0; num < array.Length; num++)
		{
			array[num].DetachIO();
		}
		SocketIOs.Clear();
	}

	private void UpdateSignalFromDefaultKey()
	{
		if ((DefaultKey == KeyCode.None && DefaultAxis == AxisCode.None) || HasWritableAndActiveSocketIOs() || !IsPlayableCreation() || IsCreationBrainDestroyed() || Direction != LogicIODirection.Input)
		{
			return;
		}
		if (DefaultKey != KeyCode.None)
		{
			switch (DefaultKeyType)
			{
			case LogicIODefaultKeyType.Down:
				if (Input.GetKey(DefaultKey))
				{
					signal = 1f;
				}
				else
				{
					signal = 0f;
				}
				break;
			case LogicIODefaultKeyType.Up:
				if (!Input.GetKey(DefaultKey))
				{
					signal = 1f;
				}
				else
				{
					signal = 0f;
				}
				break;
			case LogicIODefaultKeyType.UpToDown:
				if (Input.GetKeyDown(DefaultKey))
				{
					signal = 1f;
				}
				else
				{
					signal = 0f;
				}
				break;
			case LogicIODefaultKeyType.DownToUp:
				if (Input.GetKeyUp(DefaultKey))
				{
					signal = 1f;
				}
				else
				{
					signal = 0f;
				}
				break;
			}
		}
		else if (DefaultAxis != AxisCode.None)
		{
			signal = Input.GetAxis(DefaultAxis.ToString());
			if (Util.IsAxisCodePositive(DefaultAxis))
			{
				signal = Mathf.Clamp(signal, 0f, 1f);
			}
			else
			{
				signal = Mathf.Abs(Mathf.Clamp(signal, -1f, 0f));
			}
		}
	}

	private bool IsPlayableCreation()
	{
		if (ParentBlockBodyView != null)
		{
			return ParentBlockBodyView.ParentBlockView.ParentCreationView.IsPlayable;
		}
		return false;
	}

	private bool IsCreationBrainDestroyed()
	{
		if (ParentBlockBodyView != null)
		{
			return ParentBlockBodyView.ParentBlockView.ParentCreationView.IsBrainBlockDestroyed;
		}
		return false;
	}

	public void SetSignal(float analogSignal)
	{
		signal = ((ValueType == LogicIOValueType.Normalized) ? Mathf.Clamp(analogSignal, 0f, 1f) : analogSignal);
	}

	public void SetSignal(bool digitalSignal)
	{
		signal = (digitalSignal ? 1f : 0f);
	}

	public float ReadAnalogSignal()
	{
		UpdateSignalFromDefaultKey();
		return signal;
	}

	public bool ReadDigitalSignal()
	{
		UpdateSignalFromDefaultKey();
		return IsHigh(signal);
	}

	public static bool IsHigh(float value)
	{
		return value > 0.5f;
	}

	public static bool IsLow(float value)
	{
		return value <= 0.5f;
	}
}
