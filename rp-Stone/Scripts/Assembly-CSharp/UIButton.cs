using System.Collections.Generic;
using Stonescript;
using Stonescript.Runtime;
using UnityEngine;

public class UIButton : UIControl
{
	public IFunction pressedCallback;

	public IFunction downCallback;

	public IFunction upCallback;

	public DialogButton button { get; private set; }

	public override void ResetControl()
	{
		base.ResetControl();
		button.ResetButton();
		Width = button.Width;
		Height = button.Height;
		pressedCallback = null;
		downCallback = null;
		upCallback = null;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		button.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (IsVisibleInHierarchy())
		{
			offsetX += PositionX;
			offsetY += PositionY;
			button.Width = Width;
			button.Height = Height;
			button.label.PositionX = Width >> 1;
			button.label.PositionY = Height >> 1;
			button.Draw(r, offsetX, offsetY);
		}
	}

	public override void Awake()
	{
		button = GetComponent<DialogButton>();
		button.OnPressed += HandleButtonPressed;
		button.OnDown += HandleButtonDown;
		button.OnUp += HandleButtonUp;
		base.Awake();
	}

	[StonescriptNativeGetter("text")]
	public object Property_GetText()
	{
		return button.label.Value;
	}

	[StonescriptNativeSetter("text")]
	public void Property_SetText(object value)
	{
		button.label.SetValue((string)value);
	}

	[StonescriptNativeGetter("tcolor")]
	public object Property_GetTextColor()
	{
		string text = ColorUtility.ToHtmlStringRGB(button.label.color);
		return "#" + text;
	}

	[StonescriptNativeSetter("tcolor")]
	public void Property_SetTextColor(object value)
	{
		string colorStr = value as string;
		button.label.color = Utils.ConvertColor(colorStr);
	}

	[StonescriptNativeGetter("bcolor")]
	public object Property_GetBorderColor()
	{
		string text = ColorUtility.ToHtmlStringRGB(button.edgeSymbols.color);
		return "#" + text;
	}

	[StonescriptNativeSetter("bcolor")]
	public void Property_SetBorderColor(object value)
	{
		string colorStr = value as string;
		button.edgeSymbols.color = Utils.ConvertColor(colorStr);
	}

	[StonescriptNativeGetter("hcolor")]
	public object Property_GetHighlightColor()
	{
		string text = ColorUtility.ToHtmlStringRGB(button.highlightColor);
		return "#" + text;
	}

	[StonescriptNativeSetter("hcolor")]
	public void Property_SetHighlightColor(object value)
	{
		string colorStr = value as string;
		button.highlightColor = Utils.ConvertColor(colorStr);
	}

	[StonescriptNativeGetter("sound")]
	public object Property_GetSound()
	{
		return button.pressedSfxId;
	}

	[StonescriptNativeSetter("sound")]
	public void Property_SetSound(object value)
	{
		button.pressedSfxId = (string)value;
	}

	[StonescriptNativeGetter("style")]
	public object Property_GetStyle()
	{
		return button.customBorderStyle;
	}

	[StonescriptNativeSetter("style")]
	public void Property_SetStyle(object value)
	{
		button.customBorderStyle = (int)value;
	}

	[StonescriptNativeMethod]
	public object SetPressed(List<object> parameters, InvocationContext ctx)
	{
		if (!(parameters[0] is IFunction))
		{
			throw new RuntimeException(ctx, "SetPressed expects parameter to be a function but it received something else.");
		}
		pressedCallback = (IFunction)parameters[0];
		return null;
	}

	[StonescriptNativeMethod]
	public object SetDown(List<object> parameters, InvocationContext ctx)
	{
		if (!(parameters[0] is IFunction))
		{
			throw new RuntimeException(ctx, "SetDown expects parameter to be a function but it received something else.");
		}
		downCallback = (IFunction)parameters[0];
		return null;
	}

	[StonescriptNativeMethod]
	public object SetUp(List<object> parameters, InvocationContext ctx)
	{
		if (!(parameters[0] is IFunction))
		{
			throw new RuntimeException(ctx, "SetUp expects parameter to be a function but it received something else.");
		}
		upCallback = (IFunction)parameters[0];
		return null;
	}

	private void HandleButtonPressed(DialogButton btn)
	{
		EvalCallback(pressedCallback);
	}

	private void HandleButtonDown(DialogButton btn)
	{
		EvalCallback(downCallback);
	}

	private void HandleButtonUp(DialogButton btn)
	{
		EvalCallback(upCallback);
	}

	private void EvalCallback(IFunction callbackFunction)
	{
		if (callbackFunction == null)
		{
			return;
		}
		if (callbackFunction.ParameterNames == null || callbackFunction.ParameterNames.Count == 0)
		{
			callbackFunction.Invoke();
			return;
		}
		if (callbackFunction.ParameterNames.Count == 1)
		{
			callbackFunction.Invoke(new List<object> { base.ssObject });
			return;
		}
		List<object> list = new List<object> { base.ssObject };
		for (int i = 1; i < callbackFunction.ParameterNames.Count; i++)
		{
			list.Add(null);
		}
		callbackFunction.Invoke(list);
	}
}
