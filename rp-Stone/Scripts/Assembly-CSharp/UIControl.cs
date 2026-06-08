using System;
using System.Collections.Generic;

public class UIControl : AsciiObject, IAsciiObject
{
	public enum AnchorX
	{
		left = 0,
		center = 1,
		right = 2
	}

	public enum AnchorY
	{
		top = 0,
		center = 1,
		bottom = 2
	}

	public AnchorX anchorX;

	public AnchorY anchorY;

	public AnchorX dockX;

	public AnchorY dockY;

	public UIPanel parent;

	public bool isVisible = true;

	public bool isVisibilityInherited = true;

	public StonescriptObject ssObject => GetComponent<SSScriptableObject>().Target;

	public virtual void ResetControl()
	{
		PositionX = 0;
		PositionY = 0;
		Width = 9;
		Height = 5;
		anchorX = AnchorX.center;
		anchorY = AnchorY.center;
		dockX = AnchorX.center;
		dockY = AnchorY.center;
		parent = null;
		isVisible = true;
		isVisibilityInherited = true;
	}

	public int GetAbsoluteX()
	{
		if (this == SSUILayer.singleton.uiRootPanel)
		{
			return 0;
		}
		int absoluteX = parent.GetAbsoluteX();
		absoluteX += PositionX;
		if (anchorX == AnchorX.right)
		{
			absoluteX -= Width;
		}
		else if (anchorX == AnchorX.center)
		{
			absoluteX -= Width >> 1;
		}
		if (dockX == AnchorX.right)
		{
			absoluteX += parent.Width;
		}
		else if (dockX == AnchorX.center)
		{
			absoluteX += parent.Width >> 1;
		}
		return absoluteX;
	}

	public int GetAbsoluteY()
	{
		if (this == SSUILayer.singleton.uiRootPanel)
		{
			return 0;
		}
		int absoluteY = parent.GetAbsoluteY();
		absoluteY += PositionY;
		if (anchorY == AnchorY.bottom)
		{
			absoluteY -= Height;
		}
		else if (anchorY == AnchorY.center)
		{
			absoluteY -= Height >> 1;
		}
		if (dockY == AnchorY.bottom)
		{
			absoluteY += parent.Height;
		}
		else if (dockY == AnchorY.center)
		{
			absoluteY += parent.Height >> 1;
		}
		return absoluteY;
	}

	public bool IsVisibleInHierarchy()
	{
		if (!isVisible)
		{
			return false;
		}
		if (isVisibilityInherited && parent != null && parent != SSUILayer.singleton.uiRootPanel)
		{
			return parent.IsVisibleInHierarchy();
		}
		return true;
	}

	public virtual void Awake()
	{
		ResetControl();
	}

	public virtual void Recycle()
	{
		if (this == SSUILayer.singleton.uiRootPanel)
		{
			throw new StonescriptRuntimeException("ui.root cannot be recycled.");
		}
		if (parent != null)
		{
			parent.RemoveChild(this);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
	}

	public override void UpdateTic()
	{
	}

	[StonescriptNativeGetter("x")]
	public object Property_GetX()
	{
		return PositionX;
	}

	[StonescriptNativeSetter("x")]
	public void Property_SetX(object value)
	{
		PositionX = (int)value;
	}

	[StonescriptNativeGetter("y")]
	public object Property_GetY()
	{
		return PositionY;
	}

	[StonescriptNativeSetter("y")]
	public void Property_SetY(object value)
	{
		PositionY = (int)value;
	}

	[StonescriptNativeGetter("w")]
	public object Property_GetWidth()
	{
		return Width;
	}

	[StonescriptNativeSetter("w")]
	public void Property_SetWidth(object value)
	{
		Width = (int)value;
	}

	[StonescriptNativeGetter("h")]
	public object Property_GetHeight()
	{
		return Height;
	}

	[StonescriptNativeSetter("h")]
	public void Property_SetHeight(object value)
	{
		Height = (int)value;
	}

	[StonescriptNativeGetter("absoluteX")]
	public object Property_GetAbsoluteX()
	{
		return GetAbsoluteX();
	}

	[StonescriptNativeGetter("absoluteY")]
	public object Property_GetAbsoluteY()
	{
		return GetAbsoluteY();
	}

	[StonescriptNativeSetter("anchor")]
	public void Property_SetAnchorBoth(object value)
	{
		string[] array = (value as string).Split(new char[1] { '_' });
		if (array.Length != 2)
		{
			throw new StonescriptRuntimeException("Component.anchor expects \"a_b\", e.g.\"top_left\"");
		}
		try
		{
			AnchorY anchorY = (AnchorY)Enum.Parse(typeof(AnchorY), array[0], ignoreCase: true);
			AnchorX anchorX = (AnchorX)Enum.Parse(typeof(AnchorX), array[1], ignoreCase: true);
			this.anchorX = anchorX;
			this.anchorY = anchorY;
		}
		catch
		{
			AnchorY anchorY2 = (AnchorY)Enum.Parse(typeof(AnchorY), array[1], ignoreCase: true);
			AnchorX anchorX2 = (AnchorX)Enum.Parse(typeof(AnchorX), array[0], ignoreCase: true);
			this.anchorX = anchorX2;
			this.anchorY = anchorY2;
		}
	}

	[StonescriptNativeSetter("dock")]
	public void Property_SetDockBoth(object value)
	{
		string[] array = (value as string).Split(new char[1] { '_' });
		if (array.Length != 2)
		{
			throw new StonescriptRuntimeException("Component.dock expects \"a_b\", e.g. \"top_left\"");
		}
		try
		{
			AnchorY anchorY = (AnchorY)Enum.Parse(typeof(AnchorY), array[0], ignoreCase: true);
			AnchorX anchorX = (AnchorX)Enum.Parse(typeof(AnchorX), array[1], ignoreCase: true);
			dockX = anchorX;
			dockY = anchorY;
		}
		catch
		{
			AnchorY anchorY2 = (AnchorY)Enum.Parse(typeof(AnchorY), array[1], ignoreCase: true);
			AnchorX anchorX2 = (AnchorX)Enum.Parse(typeof(AnchorX), array[0], ignoreCase: true);
			dockX = anchorX2;
			dockY = anchorY2;
		}
	}

	[StonescriptNativeGetter("ax")]
	public object Property_GetAnchorX()
	{
		return anchorX.ToString();
	}

	[StonescriptNativeSetter("ax")]
	public void Property_SetAnchorX(object value)
	{
		anchorX = (AnchorX)Enum.Parse(typeof(AnchorX), value.ToString(), ignoreCase: true);
	}

	[StonescriptNativeGetter("ay")]
	public object Property_GetAnchorY()
	{
		return anchorY.ToString();
	}

	[StonescriptNativeSetter("ay")]
	public void Property_SetAnchorY(object value)
	{
		anchorY = (AnchorY)Enum.Parse(typeof(AnchorY), value.ToString(), ignoreCase: true);
	}

	[StonescriptNativeGetter("dx")]
	public object Property_GetDockX()
	{
		return dockX.ToString();
	}

	[StonescriptNativeSetter("dx")]
	public void Property_SetDockX(object value)
	{
		dockX = (AnchorX)Enum.Parse(typeof(AnchorX), value.ToString(), ignoreCase: true);
	}

	[StonescriptNativeGetter("dy")]
	public object Property_GetDockY()
	{
		return dockY.ToString();
	}

	[StonescriptNativeSetter("dy")]
	public void Property_SetDockY(object value)
	{
		dockY = (AnchorY)Enum.Parse(typeof(AnchorY), value.ToString(), ignoreCase: true);
	}

	[StonescriptNativeGetter("parent")]
	public object Property_GetParent()
	{
		if (!parent)
		{
			return null;
		}
		return parent.ssObject;
	}

	[StonescriptNativeGetter("visible")]
	public object Property_GetVisible()
	{
		if (isVisibilityInherited)
		{
			return "inherit";
		}
		return isVisible;
	}

	[StonescriptNativeSetter("visible")]
	public void Property_SetVisible(object value)
	{
		if (value == null)
		{
			isVisible = false;
			isVisibilityInherited = false;
		}
		else if (value is bool)
		{
			isVisible = (bool)value;
			isVisibilityInherited = false;
		}
		else
		{
			isVisible = true;
			isVisibilityInherited = true;
		}
	}

	[StonescriptNativeMethod("Recycle")]
	public object Method_Recycle(List<object> parameters, InvocationContext ctx)
	{
		Recycle();
		return null;
	}
}
