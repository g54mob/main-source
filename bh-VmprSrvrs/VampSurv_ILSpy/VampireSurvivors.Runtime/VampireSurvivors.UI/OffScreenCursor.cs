using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class OffScreenCursor : MonoBehaviour
{
	private Image _CursorRenderer;

	private UISpriteAnimation _ImageSpriteAnimation;

	private Image _IconRenderer;

	private GameObject _Target;

	private CursorData _003CData_003Ek__BackingField;

	public CursorData Data
	{
		get
		{
			return _003CData_003Ek__BackingField;
		}
		private set
		{
			_003CData_003Ek__BackingField = value;
		}
	}

	private unsafe void Update()
	{
		//IL_0021: Expected O, but got Ref
		Transform transform = _IconRenderer.transform;
		object obj = default(object);
		transform.eulerAngles = (Vector3)(&obj);
	}

	public unsafe void Init(CursorData cursorData, GameObject target)
	{
		//IL_008b: Expected I, but got O
		//IL_009d: Expected I, but got O
		//IL_0202: Expected O, but got Ref
		//IL_02b6->IL0216: Incompatible stack heights: 1 vs 0
		//IL_01ee->IL0216: Incompatible stack heights: 1 vs 0
		_003CData_003Ek__BackingField = cursorData;
		if (cursorData != null && (object)_CursorRenderer != null)
		{
			_CursorRenderer.sprite = cursorData.CursorSprite;
			Transform cursorRenderer = (Transform)(object)_CursorRenderer;
			if ((object)_CursorRenderer != null)
			{
				nint num = (nint)cursorRenderer;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v394 @ r8_v7 (Il2CppClass<UnityEngine.Transform>)+298] (should have been resolved before IL gen)");
				nint num2 = (nint)cursorRenderer;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v402 @ rax_v16 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
				if ((object)_IconRenderer != null)
				{
					GameObject gameObject = _IconRenderer.gameObject;
					Transform iconSprite = (Transform)(object)cursorData.IconSprite;
					bool active;
					if ((object)cursorData.IconSprite != null)
					{
						bool flag = ((UnityEngine.Object)iconSprite).m_CachedPtr == (IntPtr)0;
						active = !flag;
					}
					else
					{
						active = false;
					}
					if ((object)gameObject != null)
					{
						gameObject.SetActive(active);
						if ((object)_IconRenderer != null)
						{
							_IconRenderer.sprite = cursorData.IconSprite;
							if ((object)_CursorRenderer != null)
							{
								Transform transform = _CursorRenderer.transform;
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
								_Target = target;
								if (ColorUtility.DoTryParseHtmlColor(cursorData.CursorColorHex, out Color32 _))
								{
									if ((object)_CursorRenderer == null)
									{
										goto IL_0216;
									}
									_CursorRenderer.color = (Color)(&value);
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 566 Invalid \"Jump target not found in method: 0x186D28940\"");
							}
						}
					}
				}
			}
		}
		goto IL_0216;
		IL_0216:
		throw new NullReferenceException();
	}

	private void InitAnimation(CursorData cursorData)
	{
		string animationName = cursorData.AnimationName;
		if (cursorData.AnimationName != null && animationName._stringLength > 0)
		{
			bool addLeadingZeros = default(bool);
			List<Sprite> animation = SpriteManager.GetAnimation(cursorData.AnimationName, cursorData.AnimationStartingFrame, cursorData.AnimationFramesCount, "UI", addLeadingZeros);
			UISpriteAnimation imageSpriteAnimation = _ImageSpriteAnimation;
			if (animation == null)
			{
				Exception ex = System.Linq.Error.ArgumentNull("source");
				throw ex;
			}
			List<object> sprites = new List<object>(animation);
			imageSpriteAnimation.sprites = (List<Sprite>)(object)sprites;
			UISpriteAnimation imageSpriteAnimation2 = _ImageSpriteAnimation;
			imageSpriteAnimation2.FPS = cursorData.AnimationFrameRate;
		}
	}

	public OffScreenCursor()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
