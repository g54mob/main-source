using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using QFSW.MOP2;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Framework.Cursors;

public class CursorIndicator : PoolableMonoBehaviour
{
	private SpriteRenderer _CursorRenderer;

	private SpriteRenderer _IconRenderer;

	private SpriteAnimation _CursorAnimation;

	private TextMeshPro _Text;

	private CursorData _003CData_003Ek__BackingField;

	private GameObject _003CTarget_003Ek__BackingField;

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

	public GameObject Target
	{
		get
		{
			return _003CTarget_003Ek__BackingField;
		}
		private set
		{
			_003CTarget_003Ek__BackingField = value;
		}
	}

	public SpriteRenderer CursorRenderer => _CursorRenderer;

	public unsafe void Init(CursorData cursorData, GameObject target)
	{
		//IL_0330: Expected F4, but got I
		//IL_06af: Expected O, but got Ref
		//IL_0648->IL04cc: Incompatible stack heights: 4 vs 0
		//IL_0201->IL04cc: Incompatible stack heights: 4 vs 0
		//IL_0155->IL04cc: Incompatible stack heights: 4 vs 0
		//IL_0181->IL04cc: Incompatible stack heights: 4 vs 0
		//IL_01ae->IL04cc: Incompatible stack heights: 4 vs 0
		//IL_0722->IL04cc: Incompatible stack heights: 6 vs 0
		//IL_06c9->IL04cc: Incompatible stack heights: 6 vs 0
		//IL_02f1->IL06a2: Incompatible stack heights: 7 vs 6
		//IL_073f->IL04cc: Incompatible stack heights: 6 vs 0
		//IL_03db->IL04cc: Incompatible stack heights: 6 vs 0
		//IL_046a->IL04cc: Incompatible stack heights: 6 vs 0
		//IL_0494->IL04cc: Incompatible stack heights: 6 vs 0
		_003CData_003Ek__BackingField = cursorData;
		_003CTarget_003Ek__BackingField = target;
		CursorData cursorData2 = _003CData_003Ek__BackingField;
		float value = default(float);
		float value2 = default(float);
		if (_003CData_003Ek__BackingField != null)
		{
			cursorData2._CursorInstanceReference = this;
			if (cursorData != null && (object)_CursorRenderer != null)
			{
				_CursorRenderer.sprite = cursorData.CursorSprite;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_CursorRenderer, cursorData.CursorAlpha);
				if ((object)_CursorRenderer != null)
				{
					Transform transform = _CursorRenderer.transform;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
					GameObject cursorRenderer = (GameObject)(object)_CursorRenderer;
					bool flag2 = ((UnityEngine.Object)cursorRenderer).m_CachedPtr == (IntPtr)0;
					Renderer.set_sortingOrder_Injected(((UnityEngine.Object)cursorRenderer).m_CachedPtr, 10008);
					_IconRenderer.sprite = cursorData.IconSprite;
					GameObject iconRenderer = (GameObject)(object)_IconRenderer;
					bool flag3 = ((UnityEngine.Object)iconRenderer).m_CachedPtr == (IntPtr)0;
					SpriteRenderer.set_color_Injected(((UnityEngine.Object)iconRenderer).m_CachedPtr, ref *(Color*)(&value2));
					GameObject iconRenderer2 = (GameObject)(object)_IconRenderer;
					bool flag4 = ((UnityEngine.Object)iconRenderer2).m_CachedPtr == (IntPtr)0;
					Renderer.set_sortingOrder_Injected(((UnityEngine.Object)iconRenderer2).m_CachedPtr, 10009);
					GameObject iconSprite = (GameObject)(object)cursorData.IconSprite;
					Component iconRenderer3;
					if ((object)cursorData.IconSprite != null)
					{
						bool flag5 = ((UnityEngine.Object)iconSprite).m_CachedPtr == (IntPtr)0;
						iconRenderer3 = _IconRenderer;
						if (!flag5)
						{
							if ((object)_IconRenderer != null)
							{
								GameObject gameObject = _IconRenderer.gameObject;
								if ((object)gameObject != null)
								{
									gameObject.SetActive(value: true);
									if ((object)_IconRenderer != null)
									{
										_IconRenderer.sprite = cursorData.IconSprite;
										goto IL_021a;
									}
								}
							}
							goto IL_04cc;
						}
					}
					else
					{
						iconRenderer3 = _IconRenderer;
					}
					if ((object)iconRenderer3 != null)
					{
						GameObject gameObject2 = iconRenderer3.gameObject;
						if ((object)gameObject2 != null)
						{
							gameObject2.SetActive(value: false);
							goto IL_021a;
						}
					}
				}
			}
		}
		goto IL_04cc;
		IL_04cc:
		throw new NullReferenceException();
		IL_021a:
		string cursorColorHex = cursorData.CursorColorHex;
		TextMeshPro text;
		if (cursorData.CursorColorHex != null && cursorColorHex._stringLength > 0)
		{
			bool flag6 = ColorUtility.DoTryParseHtmlColor(cursorData.CursorColorHex, out Color32 color);
			float num = (float)color / 255f;
			if (flag6)
			{
				GameObject cursorRenderer2 = (GameObject)(object)_CursorRenderer;
				bool flag7 = (object)_CursorRenderer == null;
				bool flag8 = ((UnityEngine.Object)cursorRenderer2).m_CachedPtr == (IntPtr)0;
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)cursorRenderer2).m_CachedPtr, ref *(Color*)(&value2));
				text = _Text;
				bool flag9 = (object)_Text == null;
				value = num;
				goto IL_06a2;
			}
		}
		GameObject cursorRenderer3 = (GameObject)(object)_CursorRenderer;
		bool flag10 = (object)_CursorRenderer == null;
		bool flag11 = ((UnityEngine.Object)cursorRenderer3).m_CachedPtr == (IntPtr)0;
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)cursorRenderer3).m_CachedPtr, ref *(Color*)(&value2));
		text = _Text;
		if ((object)_Text == null)
		{
			goto IL_04cc;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		value = 0f;
		goto IL_06a2;
		IL_06a2:
		text.color = (Color)(&value);
		if ((object)_Text != null)
		{
			GameObject gameObject3 = _Text.gameObject;
			string text2 = cursorData.Text;
			bool active = ((cursorData.Text != null && text2._stringLength > 0) ? true : false);
			if ((object)gameObject3 != null)
			{
				gameObject3.SetActive(active);
				if ((object)_Text != null)
				{
					_Text.text = cursorData.Text;
					string animationName = cursorData.AnimationName;
					if (cursorData.AnimationName == null || animationName._stringLength <= 0)
					{
						return;
					}
					bool flag12 = default(bool);
					List<Sprite> animation = SpriteManager.GetAnimation(cursorData.AnimationName, cursorData.AnimationStartingFrame, cursorData.AnimationFramesCount, "UI", flag12);
					if ((object)_CursorAnimation != null)
					{
						_CursorAnimation.CleanAnimations();
						if ((object)_CursorAnimation != null)
						{
							bool startRandomFrame = default(bool);
							Action onComplete = default(Action);
							bool autoSetAnimation = default(bool);
							_CursorAnimation.AddAnimation("Idle", animation, cursorData.AnimationFrameRate, flag12, startRandomFrame, onComplete, autoSetAnimation);
							return;
						}
					}
				}
			}
		}
		goto IL_04cc;
	}

	public void Despawn()
	{
		CursorData cursorData = _003CData_003Ek__BackingField;
		cursorData._CursorInstanceReference = null;
		GameObject obj = base.gameObject;
		base._parentPool.Release(obj);
	}

	private void InitAnimation(CursorData cursorData)
	{
		string animationName = cursorData.AnimationName;
		if (cursorData.AnimationName != null && animationName._stringLength > 0)
		{
			bool flag = default(bool);
			List<Sprite> animation = SpriteManager.GetAnimation(cursorData.AnimationName, cursorData.AnimationStartingFrame, cursorData.AnimationFramesCount, "UI", flag);
			_CursorAnimation.CleanAnimations();
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_CursorAnimation.AddAnimation("Idle", animation, cursorData.AnimationFrameRate, flag, startRandomFrame, onComplete, autoSetAnimation);
		}
	}

	public void SetVisible(bool visible)
	{
		_CursorRenderer.enabled = visible;
		_IconRenderer.enabled = visible;
	}

	public CursorIndicator()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
