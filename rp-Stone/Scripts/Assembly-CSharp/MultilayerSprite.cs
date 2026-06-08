using System;
using System.Collections.Generic;
using Stonescript;
using UnityEngine;

public class MultilayerSprite : AsciiSprite
{
	public bool flipAllLayers;

	public bool syncFrames = true;

	public bool nestedPosition;

	public List<AsciiSprite> additionalLayers = new List<AsciiSprite>();

	public override bool flipX
	{
		get
		{
			return _flipX;
		}
		set
		{
			if (_flipX == value)
			{
				return;
			}
			_flipX = value;
			if (!flipAllLayers)
			{
				return;
			}
			for (int i = 0; i < additionalLayers.Count; i++)
			{
				AsciiSprite asciiSprite = additionalLayers[i];
				if (!(asciiSprite == null))
				{
					asciiSprite.flipX = _flipX;
				}
			}
		}
	}

	public override bool flipY
	{
		get
		{
			return _flipY;
		}
		set
		{
			if (_flipY == value)
			{
				return;
			}
			_flipY = value;
			if (!flipAllLayers)
			{
				return;
			}
			for (int i = 0; i < additionalLayers.Count; i++)
			{
				AsciiSprite asciiSprite = additionalLayers[i];
				if (!(asciiSprite == null))
				{
					asciiSprite.flipY = _flipY;
				}
			}
		}
	}

	public override void SetFrameIndex(int index)
	{
		base.SetFrameIndex(index);
		if (!syncFrames)
		{
			return;
		}
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			if ((bool)additionalLayers[i])
			{
				additionalLayers[i].SetFrameIndex(index);
			}
		}
	}

	public override void Load()
	{
		base.Load();
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			if ((bool)additionalLayers[i])
			{
				additionalLayers[i].Load();
			}
		}
	}

	public override void Reload()
	{
		base.Reload();
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			if ((bool)additionalLayers[i])
			{
				additionalLayers[i].Reload();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (nestedPosition)
		{
			offsetX -= (flipX ? (-pivotX) : pivotX);
			offsetY -= (flipY ? (-pivotY) : pivotY);
		}
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			if ((bool)additionalLayers[i])
			{
				additionalLayers[i].Draw(r, offsetX, offsetY);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply)
	{
		Draw(r, offsetX, offsetY, colorMultiply, ColorConstants.white);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		base.Draw(r, offsetX, offsetY, colorMultiply, tint);
		if (nestedPosition)
		{
			offsetX -= (flipX ? (-pivotX) : pivotX);
			offsetY -= (flipY ? (-pivotY) : pivotY);
		}
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			if ((bool)additionalLayers[i])
			{
				additionalLayers[i].Draw(r, offsetX, offsetY, colorMultiply, tint);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground)
	{
		base.Draw(r, offsetX, offsetY, overrideForeground);
		if (nestedPosition)
		{
			offsetX -= (flipX ? (-pivotX) : pivotX);
			offsetY -= (flipY ? (-pivotY) : pivotY);
		}
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			if ((bool)additionalLayers[i])
			{
				additionalLayers[i].Draw(r, offsetX, offsetY, overrideForeground);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground, Color overrideBackground)
	{
		base.Draw(r, offsetX, offsetY, overrideForeground, overrideBackground);
		if (nestedPosition)
		{
			offsetX -= (flipX ? (-pivotX) : pivotX);
			offsetY -= (flipY ? (-pivotY) : pivotY);
		}
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			if ((bool)additionalLayers[i])
			{
				additionalLayers[i].Draw(r, offsetX, offsetY, overrideForeground, overrideBackground);
			}
		}
	}

	public override void DrawColorAdd(AsciiRenderProcedural r, int offsetX, int offsetY, Color colorAdd)
	{
		base.DrawColorAdd(r, offsetX, offsetY, colorAdd);
		if (nestedPosition)
		{
			offsetX -= (flipX ? (-pivotX) : pivotX);
			offsetY -= (flipY ? (-pivotY) : pivotY);
		}
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			if ((bool)additionalLayers[i])
			{
				additionalLayers[i].DrawColorAdd(r, offsetX, offsetY, colorAdd);
			}
		}
	}

	[StonescriptNativeMethod]
	public object GetLayer(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || !(parameters[0] is int))
		{
			throw new Exception("GetLayer requires an index parameter.");
		}
		int num = (int)parameters[0];
		if (num >= additionalLayers.Count)
		{
			throw new Exception("GetLayer layer index is out of bounds.");
		}
		return additionalLayers[num].SSObject;
	}

	[StonescriptNativeMethod]
	public object AddLayer(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("AddLayer requires a sprite or ascii art string parameter.");
		}
		AsciiSprite asciiSprite;
		SSScriptableObject sSScriptableObject;
		if (parameters[0] is string)
		{
			GameObject obj = new GameObject("Sprite");
			obj.transform.SetParent(base.transform);
			asciiSprite = obj.AddComponent<AsciiSprite>();
			string text = parameters[0] as string;
			text = text.Replace("\\n", "\n");
			asciiSprite.Load(text);
			sSScriptableObject = obj.AddComponent<SSScriptableObject>();
		}
		else
		{
			if (!(parameters[0] is StonescriptObject))
			{
				throw new StonescriptRuntimeException("AddLayer requires a sprite or ascii art string parameter.");
			}
			sSScriptableObject = (parameters[0] as StonescriptObject).Scriptable;
			asciiSprite = sSScriptableObject.GetComponent<AsciiSprite>();
		}
		additionalLayers.Add(asciiSprite);
		return sSScriptableObject.Target;
	}

	[StonescriptNativeMethod]
	public object RemoveLayer(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("RemoveLayer requires a sprite parameter.");
		}
		if (parameters[0] is StonescriptObject)
		{
			AsciiSprite component = (parameters[0] as StonescriptObject).Scriptable.GetComponent<AsciiSprite>();
			additionalLayers.Remove(component);
		}
		else
		{
			if (!(parameters[0] is int))
			{
				throw new StonescriptRuntimeException("Invalid layer parameter for RemoveLayer.");
			}
			int index = (int)parameters[0];
			additionalLayers.RemoveAt(index);
		}
		return null;
	}

	protected override object PlayAnimation_Impl(List<object> parameters, InvocationContext ctx)
	{
		int num = 0;
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("PlayAnimation requires an animation parameter (string or object).");
		}
		AsciiAnimation asciiAnimation = null;
		if (parameters[num] is string)
		{
			string text = parameters[num] as string;
			Transform obj = base.transform.Find(text);
			if (obj == null)
			{
				throw new StonescriptRuntimeException("\"" + text + "\" is not the name of an animation.");
			}
			asciiAnimation = obj.GetComponent<AsciiAnimation>();
			if (asciiAnimation == null)
			{
				throw new StonescriptRuntimeException("\"" + text + "\" is not the name of an animation.");
			}
		}
		else
		{
			if (!(parameters[num] is StonescriptObject))
			{
				throw new StonescriptRuntimeException("Object passed to PlayAnimation is not an animation.");
			}
			SSScriptableObject scriptable = (parameters[num] as StonescriptObject).Scriptable;
			if (scriptable != null)
			{
				asciiAnimation = scriptable.GetComponent<AsciiAnimation>();
			}
			if (asciiAnimation == null)
			{
				throw new StonescriptRuntimeException("Object passed to PlayAnimation is not an animation.");
			}
		}
		AsciiSprite component = asciiAnimation.GetComponent<AsciiSprite>();
		num++;
		int num2 = 0;
		if (parameters.Count > num && parameters[num] is int)
		{
			num2 = (int)parameters[num++];
		}
		AsciiAnimation asciiAnimation2 = null;
		if (num2 < additionalLayers.Count)
		{
			AsciiSprite asciiSprite = additionalLayers[num2];
			asciiAnimation2 = ((asciiSprite != null) ? asciiSprite.GetComponent<AsciiAnimation>() : null);
			additionalLayers[num2] = component;
		}
		if (flipAllLayers)
		{
			component.flipX = _flipX;
			component.flipY = _flipY;
		}
		if (asciiAnimation2 != null && animationEndedCallbacks.ContainsKey(asciiAnimation2))
		{
			if (asciiAnimation2.looping)
			{
				asciiAnimation2.OnLoop -= base.OnAnimationEnded;
			}
			else
			{
				asciiAnimation2.OnEnded -= base.OnAnimationEnded;
			}
			animationEndedCallbacks.Remove(asciiAnimation2);
		}
		if (parameters.Count > num)
		{
			IFunction function = parameters[num++] as IFunction;
			if (function == null)
			{
				Debug.LogWarning($"{ctx.ScriptName} line {ctx.LineNumber}: Invalid callback for PlayAnimation");
			}
			animationEndedCallbacks.Add(asciiAnimation, function);
			if (asciiAnimation.looping)
			{
				asciiAnimation.OnLoop += base.OnAnimationEnded;
			}
			else
			{
				asciiAnimation.OnEnded += base.OnAnimationEnded;
			}
		}
		Character component2 = GetComponent<Character>();
		if (component2 != null)
		{
			component2.MySprite = this;
		}
		asciiAnimation.Play();
		return null;
	}

	[StonescriptNativeMethod]
	public object GetChild(List<object> parameters, InvocationContext ctx)
	{
		string n = parameters[0] as string;
		Transform transform = base.transform.Find(n);
		SSScriptableObject sSScriptableObject = null;
		if (transform != null)
		{
			sSScriptableObject = transform.GetComponent<SSScriptableObject>();
			if (sSScriptableObject == null)
			{
				sSScriptableObject = transform.gameObject.AddComponent<SSScriptableObject>();
			}
		}
		if (sSScriptableObject != null)
		{
			return sSScriptableObject.Target;
		}
		return null;
	}
}
