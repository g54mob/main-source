using System.Collections.Generic;
using UnityEngine;

public class UIPanel : UIControl, IAsciiObject
{
	private List<UIControl> children = new List<UIControl>();

	private StonescriptArray ssChildren = new StonescriptArray();

	public bool clipEnabled;

	public AsciiRenderProcedural.Clip clip;

	public BoxDrawing.Command boxDrawCommand;

	public override void ResetControl()
	{
		base.ResetControl();
		children.Clear();
		ssChildren.Clear();
		clipEnabled = false;
		clip = default(AsciiRenderProcedural.Clip);
		boxDrawCommand.x = 0;
		boxDrawCommand.y = 0;
		boxDrawCommand.w = 0;
		boxDrawCommand.h = 0;
		boxDrawCommand.color = ColorConstants.white;
		boxDrawCommand.style = 1;
	}

	public List<UIControl> GetChildren()
	{
		return children;
	}

	public void Clear()
	{
		for (int i = 0; i < children.Count; i++)
		{
			UIControl control = children[i];
			SSUILayer.singleton.Recycle(control);
		}
		children.Clear();
		ssChildren.Clear();
	}

	public void AddChild(UIControl child)
	{
		_PreAddCommon(child);
		children.Add(child);
		ssChildren.Add(child.ssObject);
		child.parent = this;
	}

	public void AddAt(UIControl child, int index)
	{
		_PreAddCommon(child);
		if (index < 0)
		{
			children.Insert(0, child);
			ssChildren.Insert(0, child.ssObject);
		}
		else if (index < children.Count)
		{
			children.Insert(index, child);
			ssChildren.Insert(index, child.ssObject);
		}
		else
		{
			children.Add(child);
			ssChildren.Add(child.ssObject);
		}
		child.parent = this;
	}

	private void _PreAddCommon(UIControl child)
	{
		if (child == SSUILayer.singleton.uiRootPanel)
		{
			throw new StonescriptRuntimeException("The UI root cannot be added as child of a Panel.");
		}
		if (child.parent != null)
		{
			child.parent.children.Remove(child);
			child.parent.ssChildren.Remove(child.ssObject);
		}
	}

	public void RemoveChild(UIControl child)
	{
		if (child.parent == this)
		{
			children.Remove(child);
			ssChildren.Remove(child.ssObject);
			child.parent = null;
			SSUILayer.singleton.Recycle(child);
		}
	}

	public void RemoveAt(int index)
	{
		if (index < children.Count && index >= 0)
		{
			UIControl uIControl = children[index];
			children.RemoveAt(index);
			ssChildren.RemoveAt(index);
			uIControl.parent = null;
			SSUILayer.singleton.Recycle(uIControl);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (clipEnabled)
		{
			clip.left = GetAbsoluteX();
			clip.right = r.width - clip.left - Width;
			clip.top = GetAbsoluteY();
			clip.bottom = r.height - clip.top - Height;
			r.PushClip(clip);
		}
		offsetX += PositionX;
		offsetY += PositionY;
		if (IsVisibleInHierarchy())
		{
			boxDrawCommand.x = offsetX;
			boxDrawCommand.y = offsetY;
			boxDrawCommand.w = Width;
			boxDrawCommand.h = Height;
			BoxDrawing.Draw(r, boxDrawCommand);
		}
		for (int i = 0; i < children.Count; i++)
		{
			UIControl uIControl = children[i];
			int num = offsetX;
			if (uIControl.anchorX == AnchorX.center)
			{
				num -= uIControl.Width >> 1;
			}
			else if (uIControl.anchorX == AnchorX.right)
			{
				num -= uIControl.Width;
			}
			if (uIControl.dockX == AnchorX.center)
			{
				num += Width >> 1;
			}
			else if (uIControl.dockX == AnchorX.right)
			{
				num += Width;
			}
			int num2 = offsetY;
			if (uIControl.anchorY == AnchorY.center)
			{
				num2 -= uIControl.Height >> 1;
			}
			else if (uIControl.anchorY == AnchorY.bottom)
			{
				num2 -= uIControl.Height;
			}
			if (uIControl.dockY == AnchorY.center)
			{
				num2 += Height >> 1;
			}
			else if (uIControl.dockY == AnchorY.bottom)
			{
				num2 += Height;
			}
			uIControl.Draw(r, num, num2);
		}
		if (clipEnabled)
		{
			r.PopClip();
		}
	}

	public override void UpdateTic()
	{
		for (int i = 0; i < children.Count; i++)
		{
			children[i].UpdateTic();
		}
	}

	[StonescriptNativeGetter("children")]
	public object Property_GetChildren()
	{
		return ssChildren;
	}

	[StonescriptNativeGetter("clip")]
	public object Property_GetClipEnabled()
	{
		return clipEnabled;
	}

	[StonescriptNativeSetter("clip")]
	public void Property_SetClipEnabled(object value)
	{
		if (value is bool)
		{
			clipEnabled = (bool)value;
			if (!clipEnabled)
			{
				clip = default(AsciiRenderProcedural.Clip);
			}
		}
	}

	[StonescriptNativeGetter("color")]
	public object Property_GetColor()
	{
		string text = ColorUtility.ToHtmlStringRGB(boxDrawCommand.color);
		return "#" + text;
	}

	[StonescriptNativeSetter("color")]
	public void Property_SetColor(object value)
	{
		string colorStr = value as string;
		boxDrawCommand.color = Utils.ConvertColor(colorStr);
	}

	[StonescriptNativeGetter("style")]
	public object Property_GetStyle()
	{
		return boxDrawCommand.style;
	}

	[StonescriptNativeSetter("style")]
	public void Property_SetStyle(object value)
	{
		boxDrawCommand.style = (int)value;
	}

	[StonescriptNativeMethod("Clear")]
	public object Method_Clear(List<object> parameters, InvocationContext ctx)
	{
		Clear();
		return null;
	}

	[StonescriptNativeMethod("Add")]
	public object Method_Add(List<object> parameters, InvocationContext ctx)
	{
		UIControl child = ParseControlParam(parameters, "Panel.Add() requires UIControl parameter.");
		if (parameters.Count > 1)
		{
			if (!(parameters[1] is int))
			{
				throw new StonescriptRuntimeException("Panel.Add() optional second param must be integer.");
			}
			int index = (int)parameters[1];
			AddAt(child, index);
		}
		else
		{
			AddChild(child);
		}
		return null;
	}

	[StonescriptNativeMethod("Remove")]
	public object Method_Remove(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count > 0 && parameters[0] is int)
		{
			int index = (int)parameters[0];
			RemoveAt(index);
		}
		else
		{
			UIControl child = ParseControlParam(parameters, "Panel.Remove() requires UIControl or integer parameter.");
			RemoveChild(child);
		}
		return null;
	}

	private UIControl ParseControlParam(List<object> parameters, string exceptionMessage)
	{
		if (parameters.Count == 0 || !(parameters[0] is StonescriptObject))
		{
			throw new StonescriptRuntimeException(exceptionMessage);
		}
		SSScriptableObject scriptable = (parameters[0] as StonescriptObject).Scriptable;
		if (scriptable == null)
		{
			throw new StonescriptRuntimeException(exceptionMessage);
		}
		UIControl component = scriptable.GetComponent<UIControl>();
		if (component == null)
		{
			throw new StonescriptRuntimeException(exceptionMessage);
		}
		return component;
	}
}
