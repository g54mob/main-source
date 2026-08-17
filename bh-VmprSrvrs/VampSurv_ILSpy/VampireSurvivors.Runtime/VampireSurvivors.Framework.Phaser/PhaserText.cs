using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework;

namespace VampireSurvivors.Framework.Phaser;

public class PhaserText : GameMonoBehaviour
{
	private TextMeshPro _textRenderer;

	public float _originX;

	public float _originY;

	public TextMeshPro TextRenderer => _textRenderer;

	private void Start()
	{
		EnsureTextRenderer();
	}

	public void InternalForceInit()
	{
		EnsureTextRenderer();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A29ED]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserText phaserText = SetFont("Courier_HintedSmooth SDF8");
	}

	public PhaserText SetText(string text)
	{
		//IL_002f: Expected O, but got I4
		if ((object)_textRenderer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
			PhaserText phaserText = UpdateDisplaySize();
			PhaserText phaserText2 = setOrigin(_originX, (float?)(object)1);
			return this;
		}
		return (PhaserText)(object)new NullReferenceException();
	}

	public PhaserText UpdateDisplaySize()
	{
		//IL_013d->IL00ec: Incompatible stack heights: 1 vs 0
		//IL_007e->IL00ec: Incompatible stack heights: 1 vs 0
		//IL_00ac->IL00ec: Incompatible stack heights: 1 vs 0
		//IL_00d8->IL00ec: Incompatible stack heights: 1 vs 0
		if ((object)_textRenderer != null)
		{
			Transform transform = _textRenderer.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_textRenderer != null)
				{
					float preferredWidth = _textRenderer.preferredWidth;
					if ((object)_textRenderer != null)
					{
						float preferredHeight = _textRenderer.preferredHeight;
						if ((object)_textRenderer != null)
						{
							RectTransform rectTransform = _textRenderer.rectTransform;
							if ((object)rectTransform != null)
							{
								Vector2 sizeDelta = default(Vector2);
								rectTransform.sizeDelta = sizeDelta;
								return this;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe PhaserText SetAlpha(float alpha)
	{
		//IL_0042: Expected O, but got Ref
		if ((object)_textRenderer != null)
		{
			Color color = _textRenderer.color;
			object obj = default(object);
			_textRenderer.color = (Color)(&obj);
			return this;
		}
		return (PhaserText)(object)new NullReferenceException();
	}

	public unsafe PhaserText SetColor(Color color)
	{
		//IL_002e: Expected O, but got Ref
		if ((object)_textRenderer != null)
		{
			object obj = default(object);
			_textRenderer.color = (Color)(&obj);
			return this;
		}
		return (PhaserText)(object)new NullReferenceException();
	}

	public PhaserText SetTint(uint tint)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
		return this;
	}

	public PhaserText SetFont(string fontPath)
	{
		TextMeshPro textRenderer = _textRenderer;
		if ((object)_textRenderer != null && ((UnityEngine.Object)textRenderer).m_CachedPtr != (IntPtr)0)
		{
			GameManager core = GM.Core;
			FontFactory fontFactory = core._fontFactory;
			bool flag = fontFactory._TMPFonts == null;
			TMP_FontAsset tMP_FontAsset = null;
			if (!flag)
			{
				bool flag2 = ((Dictionary<object, object>)(object)fontFactory._TMPFonts).TryGetValue((object)fontPath, out object value);
				bool flag3 = !flag2;
				tMP_FontAsset = null;
				if (!flag3)
				{
					if (value == null)
					{
						return (PhaserText)(object)new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F94830");
					TMP_FontAsset tMP_FontAsset2 = default(TMP_FontAsset);
					tMP_FontAsset = tMP_FontAsset2;
				}
			}
			if ((object)tMP_FontAsset != null && ((UnityEngine.Object)tMP_FontAsset).m_CachedPtr != (IntPtr)0)
			{
				_textRenderer.font = tMP_FontAsset;
				Renderer component = _textRenderer.GetComponent<Renderer>();
				component.SetMaterial(((TMP_Asset)tMP_FontAsset).m_Material);
			}
		}
		return this;
	}

	public PhaserText SetFontSize(float fontSize)
	{
		if ((object)_textRenderer != null)
		{
			_textRenderer.fontSize = fontSize;
			return this;
		}
		return (PhaserText)(object)new NullReferenceException();
	}

	public PhaserText SetDepth(int depth)
	{
		if ((object)_textRenderer != null)
		{
			_textRenderer.sortingOrder = depth;
			return this;
		}
		return (PhaserText)(object)new NullReferenceException();
	}

	public PhaserText setOrigin(float2 origin)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 32 Invalid \"Jump target not found in method: 0x186B4D1D0\"");
		PhaserText result = default(PhaserText);
		return result;
	}

	public PhaserText setOrigin(float originX = 0.5f, float? originY = null)
	{
		//IL_0071: Expected O, but got I4
		EnsureTextRenderer();
		TextMeshPro textRenderer = _textRenderer;
		if ((object)_textRenderer != null && ((UnityEngine.Object)textRenderer).m_CachedPtr != (IntPtr)0)
		{
			PhaserText phaserText = UpdateDisplaySize();
			float originY2;
			float? num;
			if ((object)originY == null)
			{
				originY2 = originX;
				num = (float?)(object)1;
			}
			else
			{
				float num2 = default(float);
				originY2 = num2;
				num = originY;
			}
			_originX = originX;
			bool flag = (object)num == null;
			_originY = originY2;
			RectTransform rectTransform = _textRenderer.rectTransform;
			Vector2 sizeDelta = rectTransform.sizeDelta;
			Transform transform = _textRenderer.transform;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			return this;
		}
		return this;
	}

	public PhaserText SetTextAlignments(HorizontalAlignmentOptions x, VerticalAlignmentOptions y)
	{
		TextMeshPro textRenderer = _textRenderer;
		if ((object)_textRenderer != null)
		{
			if (((TMP_Text)textRenderer).m_HorizontalAlignment != x)
			{
				((TMP_Text)textRenderer).m_HorizontalAlignment = x;
				((TMP_Text)textRenderer).m_havePropertiesChanged = true;
				_textRenderer.SetVerticesDirty();
			}
			TextMeshPro textRenderer2 = _textRenderer;
			if ((object)_textRenderer != null)
			{
				if (((TMP_Text)textRenderer2).m_VerticalAlignment != y)
				{
					((TMP_Text)textRenderer2).m_VerticalAlignment = y;
					((TMP_Text)textRenderer2).m_havePropertiesChanged = true;
					_textRenderer.SetVerticesDirty();
				}
				return this;
			}
		}
		return (PhaserText)(object)new NullReferenceException();
	}

	public PhaserText setName(string newName)
	{
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			((UnityEngine.Object)gameObject).SetName(newName);
			return this;
		}
		return (PhaserText)(object)new NullReferenceException();
	}

	public PhaserText setVisible(bool visible)
	{
		EnsureTextRenderer();
		TextMeshPro textRenderer = _textRenderer;
		if ((object)_textRenderer != null && ((UnityEngine.Object)textRenderer).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_textRenderer == null)
			{
				return (PhaserText)(object)new NullReferenceException();
			}
			_textRenderer.enabled = visible;
		}
		return this;
	}

	public void destroy()
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}

	private unsafe void EnsureTextRenderer()
	{
		//IL_018c->IL029e: Incompatible stack heights: 2 vs 0
		//IL_01b6->IL029e: Incompatible stack heights: 2 vs 0
		//IL_029e->IL02d8: Incompatible stack heights: 7 vs 0
		//IL_025f->IL02d8: Incompatible stack heights: 7 vs 0
		TextMeshPro textRenderer = _textRenderer;
		if ((object)_textRenderer != null && ((UnityEngine.Object)textRenderer).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			int childCount = transform.childCount;
			if (childCount > 0)
			{
				TextMeshPro componentInChildren = GetComponentInChildren<TextMeshPro>();
				_textRenderer = componentInChildren;
				TextMeshPro textRenderer2 = _textRenderer;
				if ((object)_textRenderer != null && ((UnityEngine.Object)textRenderer2).m_CachedPtr != (IntPtr)0)
				{
					return;
				}
			}
			GameObject gameObject = new GameObject("Scale");
			if ((object)gameObject != null)
			{
				RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
				Transform parent = base.transform;
				if ((object)rectTransform != null)
				{
					rectTransform.SetParent(parent, worldPositionStays: true);
					bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
					Vector2 value2 = default(Vector2);
					Transform.set_localScale_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref *(Vector3*)(&value2));
					Vector2 sizeDelta = default(Vector2);
					rectTransform.sizeDelta = sizeDelta;
					GameObject gameObject2 = new GameObject("PhaserTextRenderer");
					if ((object)gameObject2 != null)
					{
						Transform transform2 = gameObject2.transform;
						if ((object)transform2 != null)
						{
							transform2.SetParent(rectTransform, worldPositionStays: true);
							Transform transform3 = gameObject2.transform;
							bool flag3 = (object)transform3 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1242 @ rax_v60 (UnityEngine.Transform)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1242 @ rax_v60 (UnityEngine.Transform)+10]");
							Vector3 value3 = default(Vector3);
							Transform.set_localPosition_Injected((IntPtr)0, ref value3);
							Transform transform4 = gameObject2.transform;
							bool flag5 = (object)transform4 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1300 @ rax_v68 (UnityEngine.Transform)+10]");
							bool flag6 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1300 @ rax_v68 (UnityEngine.Transform)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref value);
							TextMeshPro textRenderer3 = gameObject2.AddComponent<TextMeshPro>();
							_textRenderer = textRenderer3;
							TextMeshPro textRenderer4 = _textRenderer;
							bool flag7 = (object)_textRenderer == null;
							if (((TMP_Text)textRenderer4).m_HorizontalAlignment != HorizontalAlignmentOptions.Center || ((TMP_Text)textRenderer4).m_VerticalAlignment != VerticalAlignmentOptions.Geometry)
							{
								((TMP_Text)textRenderer4).m_HorizontalAlignment = HorizontalAlignmentOptions.Center;
								((TMP_Text)textRenderer4).m_VerticalAlignment = VerticalAlignmentOptions.Geometry;
								((TMP_Text)textRenderer4).m_havePropertiesChanged = true;
								_textRenderer.SetVerticesDirty();
							}
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void AssignDefaultFont()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A29ED]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserText phaserText = SetFont("Courier_HintedSmooth SDF8");
	}

	public PhaserText()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
