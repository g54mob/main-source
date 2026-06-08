using System;
using System.Collections.Generic;
using Stonescript;
using UnityEngine;

public class AsciiSprite : MonoBehaviour, IAsciiObject
{
	public enum ColorMode
	{
		Normal = 0,
		Dark = 1,
		Darker = 2
	}

	private static bool WARN_NOT_LOADED;

	public ColorMode colorMode;

	public Color colorOverride = Color.white;

	public TextAsset source;

	public bool blackBackground;

	public int pageLoadStartIndex;

	public int pageLoadCount = -1;

	public int pivotX;

	public int pivotY;

	public int width;

	public int height;

	[SerializeField]
	protected bool _flipX;

	[SerializeField]
	protected bool _flipY;

	[SerializeField]
	private int frameIndex;

	public List<AsciiData.StringReplacement> stringReplacements;

	public bool reload;

	public bool includeInQuestBG = true;

	public AsciiData data;

	private int _lastDrawX;

	private int _lastDrawY;

	protected Dictionary<AsciiAnimation, IFunction> animationEndedCallbacks = new Dictionary<AsciiAnimation, IFunction>();

	public virtual bool flipX
	{
		get
		{
			return _flipX;
		}
		set
		{
			_flipX = value;
		}
	}

	public virtual bool flipY
	{
		get
		{
			return _flipY;
		}
		set
		{
			_flipY = value;
		}
	}

	public int FrameCount
	{
		get
		{
			EnsureLoaded();
			if (data != null)
			{
				return data.Pages.Count;
			}
			return 0;
		}
	}

	public bool loaded { get; protected set; }

	public int lastDrawX => _lastDrawX;

	public int lastDrawY => _lastDrawY;

	public float lastColorMultiply { get; private set; }

	public StonescriptObject SSObject
	{
		get
		{
			SSScriptableObject sSScriptableObject = GetComponent<SSScriptableObject>();
			if (sSScriptableObject == null)
			{
				sSScriptableObject = base.gameObject.AddComponent<SSScriptableObject>();
			}
			return sSScriptableObject.Target;
		}
	}

	public event Action<AsciiSprite, AsciiRenderProcedural, int, int> OnDraw;

	public virtual int GetFrameIndex()
	{
		return frameIndex;
	}

	public virtual void SetFrameIndex(int index)
	{
		frameIndex = index;
	}

	public virtual void Load()
	{
		if (!loaded)
		{
			if (source != null)
			{
				Load(source.text);
			}
			loaded = true;
		}
	}

	public virtual void Load(string sourceText)
	{
		data = AsciiLoader.Load(sourceText, stringReplacements, pageLoadStartIndex, pageLoadCount);
		if (data != null)
		{
			if (data.Pages.Count == 0)
			{
				data = null;
				width = 0;
				height = 0;
			}
			else
			{
				width = data.ComputeWidth();
				height = data.ComputeHeight();
			}
		}
		loaded = true;
	}

	public virtual void Reload()
	{
		loaded = false;
		Load();
	}

	public virtual void UpdateTic()
	{
	}

	public virtual void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		EnsureLoaded();
		bool num = IsClipped(r, offsetX - pivotX, offsetY - pivotY);
		offsetX -= (flipX ? (-pivotX) : pivotX);
		offsetY -= (flipY ? (-pivotY) : pivotY);
		_lastDrawX = offsetX;
		_lastDrawY = offsetY;
		lastColorMultiply = 1f;
		if (!num)
		{
			Color overrideForeground = r.defaultForegroundColor;
			if (colorOverride != Color.white)
			{
				overrideForeground = colorOverride;
			}
			else if (colorMode == ColorMode.Darker)
			{
				overrideForeground = ColorConstants.darkGrey;
			}
			else if (colorMode == ColorMode.Dark)
			{
				overrideForeground = ColorConstants.grey;
			}
			if (blackBackground)
			{
				DrawCurrentPage(r, offsetX, offsetY, overrideForeground, ColorConstants.black);
			}
			else
			{
				DrawCurrentPage(r, offsetX, offsetY, overrideForeground);
			}
		}
		FireOnDraw(r, offsetX, offsetY);
	}

	public virtual void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply)
	{
		Draw(r, offsetX, offsetY, colorMultiply, ColorConstants.white);
	}

	public virtual void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		EnsureLoaded();
		bool num = IsClipped(r, offsetX - pivotX, offsetY - pivotY);
		offsetX -= (flipX ? (-pivotX) : pivotX);
		offsetY -= (flipY ? (-pivotY) : pivotY);
		_lastDrawX = offsetX;
		_lastDrawY = offsetY;
		lastColorMultiply = colorMultiply;
		if (!num)
		{
			Color overrideForeground = r.defaultForegroundColor;
			if (colorOverride != Color.white)
			{
				overrideForeground = colorOverride;
			}
			else if (colorMode == ColorMode.Darker)
			{
				overrideForeground = ColorConstants.darkGrey;
			}
			else if (colorMode == ColorMode.Dark)
			{
				overrideForeground = ColorConstants.grey;
			}
			overrideForeground *= colorMultiply * tint;
			DrawCurrentPage(r, offsetX, offsetY, overrideForeground);
		}
		FireOnDraw(r, offsetX, offsetY);
	}

	public virtual void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground)
	{
		EnsureLoaded();
		bool num = IsClipped(r, offsetX - pivotX, offsetY - pivotY);
		offsetX -= (flipX ? (-pivotX) : pivotX);
		offsetY -= (flipY ? (-pivotY) : pivotY);
		lastColorMultiply = 1f;
		if (!num)
		{
			DrawCurrentPage(r, offsetX, offsetY, overrideForeground);
		}
		FireOnDraw(r, offsetX, offsetY);
	}

	public virtual void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground, Color overrideBackground)
	{
		EnsureLoaded();
		bool num = IsClipped(r, offsetX - pivotX, offsetY - pivotY);
		offsetX -= (flipX ? (-pivotX) : pivotX);
		offsetY -= (flipY ? (-pivotY) : pivotY);
		lastColorMultiply = 1f;
		if (!num)
		{
			DrawCurrentPage(r, offsetX, offsetY, overrideForeground, overrideBackground);
		}
		FireOnDraw(r, offsetX, offsetY);
	}

	public virtual void DrawColorAdd(AsciiRenderProcedural r, int offsetX, int offsetY, Color colorAdd)
	{
		EnsureLoaded();
		bool num = IsClipped(r, offsetX - pivotX, offsetY - pivotY);
		offsetX -= (flipX ? (-pivotX) : pivotX);
		offsetY -= (flipY ? (-pivotY) : pivotY);
		_lastDrawX = offsetX;
		_lastDrawY = offsetY;
		if (!num)
		{
			Color overrideForeground = r.defaultForegroundColor;
			if (colorOverride != Color.white)
			{
				overrideForeground = colorOverride;
			}
			else if (colorMode == ColorMode.Darker)
			{
				overrideForeground = ColorConstants.darkGrey;
			}
			else if (colorMode == ColorMode.Dark)
			{
				overrideForeground = ColorConstants.grey;
			}
			overrideForeground += colorAdd;
			DrawCurrentPage(r, offsetX, offsetY, overrideForeground);
		}
		FireOnDraw(r, offsetX, offsetY);
	}

	protected void FireOnDraw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (this.OnDraw != null)
		{
			this.OnDraw(this, r, offsetX, offsetY);
		}
	}

	public AsciiData.Page GetCurrentPage()
	{
		if (data == null)
		{
			return null;
		}
		int index = frameIndex % data.Pages.Count;
		return data.Pages[index];
	}

	private void DrawCurrentPage(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (data != null)
		{
			int index = frameIndex % data.Pages.Count;
			AsciiData.Page page = data.Pages[index];
			page.flipX = flipX;
			page.flipY = flipY;
			page.Draw(r, offsetX, offsetY);
		}
	}

	private void DrawCurrentPage(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground)
	{
		if (data != null)
		{
			int index = Mathf.Max(frameIndex, 0) % data.Pages.Count;
			AsciiData.Page page = data.Pages[index];
			page.flipX = flipX;
			page.flipY = flipY;
			page.Draw(r, offsetX, offsetY, overrideForeground);
		}
	}

	private void DrawCurrentPage(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground, Color overrideBackground)
	{
		if (data != null)
		{
			int index = frameIndex % data.Pages.Count;
			AsciiData.Page page = data.Pages[index];
			page.flipX = flipX;
			page.flipY = flipY;
			page.Draw(r, offsetX, offsetY, overrideForeground, overrideBackground);
		}
	}

	private bool IsClipped(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (offsetX < r.width - r.clip.right && offsetX + width > r.clip.left && offsetY < r.height - r.clip.bottom)
		{
			return offsetY + height <= r.clip.top;
		}
		return true;
	}

	private void EnsureLoaded()
	{
		if (!loaded)
		{
			if (WARN_NOT_LOADED)
			{
				Utils.LogWarning("Trying to use ascii sprite which was not loaded. Loading now. Prefer to do this in a loading phase.", base.gameObject);
			}
			Load();
		}
	}

	[StonescriptNativeGetter("frame")]
	public object Property_GetFrameIndex()
	{
		return frameIndex;
	}

	[StonescriptNativeSetter("frame")]
	public void Property_SetFrameIndex(object value)
	{
		SetFrameIndex((int)value);
	}

	[StonescriptNativeGetter("pivotX")]
	public object Property_GetPivotX()
	{
		return pivotX;
	}

	[StonescriptNativeSetter("pivotX")]
	public void Property_SetPivotX(object value)
	{
		pivotX = (int)value;
	}

	[StonescriptNativeGetter("pivotY")]
	public object Property_GetPivotY()
	{
		return pivotY;
	}

	[StonescriptNativeSetter("pivotY")]
	public void Property_SetPivotY(object value)
	{
		pivotY = (int)value;
	}

	[StonescriptNativeGetter("flipX")]
	public object Property_GetFlipX()
	{
		return flipX;
	}

	[StonescriptNativeSetter("flipX")]
	public void Property_SetFlipX(object value)
	{
		flipX = (bool)value;
	}

	[StonescriptNativeGetter("flipY")]
	public object Property_GetFlipY()
	{
		return flipY;
	}

	[StonescriptNativeSetter("flipY")]
	public void Property_SetFlipY(object value)
	{
		flipY = (bool)value;
	}

	[StonescriptNativeGetter("width")]
	public object Property_GetWidth()
	{
		return width;
	}

	[StonescriptNativeGetter("height")]
	public object Property_GetHeight()
	{
		return height;
	}

	[StonescriptNativeGetter("color")]
	public object Property_GetColor()
	{
		return colorOverride;
	}

	[StonescriptNativeSetter("color")]
	public void Property_SetColor(object value)
	{
		string text = value as string;
		AsciiSpritePPRainbow component = GetComponent<AsciiSpritePPRainbow>();
		if (text.StartsWith("#rain"))
		{
			if (component == null)
			{
				base.gameObject.AddComponent<AsciiSpritePPRainbow>();
			}
			return;
		}
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
		colorOverride = Utils.ConvertColor(text);
	}

	[StonescriptNativeMethod]
	public object Load(List<object> parameters, InvocationContext ctx)
	{
		string text = parameters[0] as string;
		text = text.Replace("\\n", "\n");
		Load(text);
		return null;
	}

	[StonescriptNativeMethod]
	public object SetColorOverride(List<object> parameters, InvocationContext ctx)
	{
		string colorStr = parameters[0] as string;
		colorOverride = Utils.ConvertColor(colorStr);
		return null;
	}

	[StonescriptNativeMethod]
	public object PlayAnimation(List<object> parameters, InvocationContext ctx)
	{
		return PlayAnimation_Impl(parameters, ctx);
	}

	protected virtual object PlayAnimation_Impl(List<object> parameters, InvocationContext ctx)
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
		Character component2 = GetComponent<Character>();
		AsciiSprite asciiSprite = null;
		AsciiAnimation asciiAnimation2 = null;
		if (component2 != null)
		{
			asciiSprite = component2.MySprite;
			asciiAnimation2 = ((asciiSprite != null) ? asciiSprite.GetComponent<AsciiAnimation>() : null);
		}
		if (asciiAnimation2 != null && animationEndedCallbacks.ContainsKey(asciiAnimation2))
		{
			if (asciiAnimation2.looping)
			{
				asciiAnimation2.OnLoop -= OnAnimationEnded;
			}
			else
			{
				asciiAnimation2.OnEnded -= OnAnimationEnded;
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
				asciiAnimation.OnLoop += OnAnimationEnded;
			}
			else
			{
				asciiAnimation.OnEnded += OnAnimationEnded;
			}
		}
		if (component2 != null)
		{
			component2.MySprite = component;
		}
		asciiAnimation.Play();
		return null;
	}

	protected void OnAnimationEnded(AsciiAnimation animation)
	{
		if (animationEndedCallbacks.ContainsKey(animation))
		{
			IFunction function = animationEndedCallbacks[animation];
			if (!animation.looping)
			{
				animation.OnEnded -= OnAnimationEnded;
				animationEndedCallbacks.Remove(animation);
			}
			if (GameStates.Singleton.CanCustomQuestInvokeScriptCallbacks())
			{
				function.Invoke();
			}
		}
	}

	[StonescriptNativeMethod]
	public object CloneAsDecoration(List<object> parameters, InvocationContext ctx)
	{
		GameObject gameObject = new GameObject(base.name + " copy");
		AsciiSprite asciiSprite = gameObject.AddComponent<AsciiSprite>();
		asciiSprite.source = source;
		asciiSprite.pageLoadStartIndex = pageLoadStartIndex;
		asciiSprite.pageLoadCount = pageLoadCount;
		asciiSprite.pivotX = pivotX;
		asciiSprite.pivotY = pivotY;
		asciiSprite.stringReplacements = stringReplacements;
		asciiSprite.frameIndex = frameIndex;
		asciiSprite.flipX = flipX;
		asciiSprite.flipY = flipY;
		asciiSprite.colorMode = colorMode;
		asciiSprite.colorOverride = colorOverride;
		Character component = GetComponent<Character>();
		if (component != null)
		{
			Decoration decoration = gameObject.AddComponent<Decoration>();
			decoration.PositionX = component.PositionX;
			decoration.PositionY = component.PositionY;
			decoration.PositionZ = component.PositionZ;
			decoration.MySprite = asciiSprite;
			GameStates.Singleton.level.AddCharacter(decoration);
		}
		else
		{
			GameStates.Singleton.level.AddObject(asciiSprite);
		}
		return gameObject.AddComponent<SSScriptableObject>().Target;
	}

	[StonescriptNativeMethod]
	public object AddShiny(List<object> parameters, InvocationContext ctx)
	{
		AsciiSpritePPShiny asciiSpritePPShiny = GetComponent<AsciiSpritePPShiny>();
		if (asciiSpritePPShiny == null)
		{
			asciiSpritePPShiny = base.gameObject.AddComponent<AsciiSpritePPShiny>();
		}
		if (parameters.Count > 0 && parameters[0] is float)
		{
			asciiSpritePPShiny.velocity = (float)parameters[0];
		}
		return null;
	}
}
