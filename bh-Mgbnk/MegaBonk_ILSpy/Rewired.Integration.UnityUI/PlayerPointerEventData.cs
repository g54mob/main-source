using System;
using System.Text;
using Cpp2ILInjected;
using Rewired.UI;
using UnityEngine.EventSystems;

namespace Rewired.Integration.UnityUI;

public class PlayerPointerEventData : PointerEventData
{
	private int _003CplayerId_003Ek__BackingField;

	private int _003CinputSourceIndex_003Ek__BackingField;

	private IMouseInputSource _003CmouseSource_003Ek__BackingField;

	private ITouchInputSource _003CtouchSource_003Ek__BackingField;

	private PointerEventType _003CsourceType_003Ek__BackingField;

	private int _003CbuttonIndex_003Ek__BackingField;

	public int playerId
	{
		get
		{
			return _003CplayerId_003Ek__BackingField;
		}
		set
		{
			_003CplayerId_003Ek__BackingField = value;
		}
	}

	public int inputSourceIndex
	{
		get
		{
			return _003CinputSourceIndex_003Ek__BackingField;
		}
		set
		{
			_003CinputSourceIndex_003Ek__BackingField = value;
		}
	}

	public IMouseInputSource mouseSource
	{
		get
		{
			return _003CmouseSource_003Ek__BackingField;
		}
		set
		{
			_003CmouseSource_003Ek__BackingField = value;
		}
	}

	public ITouchInputSource touchSource
	{
		get
		{
			return _003CtouchSource_003Ek__BackingField;
		}
		set
		{
			_003CtouchSource_003Ek__BackingField = value;
		}
	}

	public PointerEventType sourceType
	{
		get
		{
			return _003CsourceType_003Ek__BackingField;
		}
		set
		{
			_003CsourceType_003Ek__BackingField = value;
		}
	}

	public int buttonIndex
	{
		get
		{
			return _003CbuttonIndex_003Ek__BackingField;
		}
		set
		{
			_003CbuttonIndex_003Ek__BackingField = value;
		}
	}

	public PlayerPointerEventData(EventSystem eventSystem)
	{
		//IL_0024: Expected I4, but got I8
		base._002Ector(eventSystem);
		_003CplayerId_003Ek__BackingField = -1;
		_003CbuttonIndex_003Ek__BackingField = -1;
	}

	public unsafe override string ToString()
	{
		//IL_0076: Expected I, but got O
		//IL_021d: Expected O, but got Ref
		//IL_00e8: Expected I, but got O
		StringBuilder stringBuilder = new StringBuilder();
		int num = default(int);
		string text = num.ToString();
		string value = "<b>Player Id</b>: " + text;
		if (stringBuilder != null)
		{
			StringBuilder stringBuilder2 = stringBuilder.AppendLine(value);
			IMouseInputSource mouseInputSource = _003CmouseSource_003Ek__BackingField;
			string text2 = default(string);
			if (_003CmouseSource_003Ek__BackingField != null)
			{
				nint num2 = (nint)mouseInputSource;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v86 @ rax_v35 (Il2CppClass<Rewired.UI.IMouseInputSource>)+168] (should have been resolved before IL gen)");
			}
			else
			{
				text2 = null;
			}
			string value2 = "<b>Mouse Source</b>: " + text2;
			StringBuilder stringBuilder3 = stringBuilder.AppendLine(value2);
			string text3 = num.ToString();
			string value3 = "<b>Input Source Index</b>: " + text3;
			StringBuilder stringBuilder4 = stringBuilder.AppendLine(value3);
			ITouchInputSource touchInputSource = _003CtouchSource_003Ek__BackingField;
			string text4 = default(string);
			if (_003CtouchSource_003Ek__BackingField != null)
			{
				nint num3 = (nint)touchInputSource;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v162 @ rax_v32 (Il2CppClass<Rewired.UI.ITouchInputSource>)+168] (should have been resolved before IL gen)");
			}
			else
			{
				text4 = null;
			}
			string value4 = "<b>Touch Source/b>: " + text4;
			StringBuilder stringBuilder5 = stringBuilder.AppendLine(value4);
			object obj = default(object);
			string text5 = ((Enum)(&obj)).ToString();
			string value5 = "<b>Source Type</b>: " + text5;
			StringBuilder stringBuilder6 = stringBuilder.AppendLine(value5);
			string text6 = num.ToString();
			string value6 = "<b>Button Index</b>: " + text6;
			StringBuilder stringBuilder7 = stringBuilder.AppendLine(value6);
			string value7 = base.ToString();
			StringBuilder stringBuilder8 = stringBuilder.Append(value7);
			return stringBuilder.ToString();
		}
		return (string)(object)new NullReferenceException();
	}
}
