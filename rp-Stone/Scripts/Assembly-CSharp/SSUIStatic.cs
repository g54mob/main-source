using System.Collections.Generic;

public class SSUIStatic : StonescriptObject
{
	public SSUIStatic()
		: base("ui")
	{
		SSScriptableObject.Bind(this, this);
	}

	[StonescriptNativeGetter("root")]
	public object Property_GetRoot()
	{
		return SSUILayer.singleton.uiRootPanel.ssObject;
	}

	[StonescriptNativeMethod]
	public object Clear(List<object> parameters, InvocationContext ctx)
	{
		SSUILayer.singleton.Clear();
		return null;
	}

	[StonescriptNativeMethod]
	public object AddStyle(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters ui.AddStyle(string)");
		}
		string text = parameters[0] as string;
		if (text.Length != 9)
		{
			throw new StonescriptRuntimeException("ui.AddStyle(string) requires exactly 9 glyphs");
		}
		return SSUILayer.singleton.AddStyle(text);
	}

	[StonescriptNativeMethod]
	public object AddButton(List<object> parameters, InvocationContext ctx)
	{
		return SSUILayer.singleton.AddButton().ssObject;
	}

	[StonescriptNativeMethod]
	public object AddPanel(List<object> parameters, InvocationContext ctx)
	{
		return SSUILayer.singleton.AddPanel().ssObject;
	}

	[StonescriptNativeMethod]
	public object AddText(List<object> parameters, InvocationContext ctx)
	{
		UITextBox uITextBox = SSUILayer.singleton.AddText();
		if (parameters.Count > 0 && parameters[0] is string)
		{
			uITextBox.Property_SetText(parameters[0]);
		}
		return uITextBox.ssObject;
	}

	[StonescriptNativeMethod]
	public object AddAnim(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 0 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters ui.AddAnim(string)");
		}
		string text = parameters[0] as string;
		text = text.Replace("\\n", "\n");
		return SSUILayer.singleton.AddAnim(text).ssObject;
	}

	[StonescriptNativeMethod]
	public object AddCanvas(List<object> parameters, InvocationContext ctx)
	{
		return SSUILayer.singleton.AddCanvas().ssObject;
	}

	[StonescriptNativeMethod]
	public object ShowBanner(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters ui.ShowBanner(string)");
		}
		string message = parameters[0] as string;
		string message2 = null;
		if (parameters.Count >= 2 && parameters[1] is string)
		{
			message2 = parameters[1] as string;
		}
		GameStates.Singleton.ShowBanner(message, message2);
		return null;
	}

	[StonescriptNativeMethod]
	public object OpenInv(List<object> parameters, InvocationContext ctx)
	{
		GameStates.Singleton.OpenPlayItemScreen();
		return null;
	}

	[StonescriptNativeMethod]
	public object OpenMind(List<object> parameters, InvocationContext ctx)
	{
		GameStates.Singleton.OpenPlayMindStoneScreen();
		return null;
	}
}
