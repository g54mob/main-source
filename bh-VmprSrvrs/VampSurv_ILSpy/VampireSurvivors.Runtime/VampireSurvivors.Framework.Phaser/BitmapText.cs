using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.Framework.Phaser;

public class BitmapText : GameMonoBehaviour
{
	private TextMesh _textRenderer;

	public float _originX;

	public float _originY;

	public TextMesh TextRenderer => _textRenderer;

	private void Start()
	{
		EnsureTextRenderer();
	}

	public void InternalForceInit()
	{
		EnsureTextRenderer();
	}

	public BitmapText setName(string newName)
	{
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			((UnityEngine.Object)gameObject).SetName(newName);
			return this;
		}
		return (BitmapText)(object)new NullReferenceException();
	}

	public BitmapText SetText(string text)
	{
		if ((object)_textRenderer != null)
		{
			_textRenderer.text = text;
			return this;
		}
		return (BitmapText)(object)new NullReferenceException();
	}

	public BitmapText SetAlpha(float alpha)
	{
		object textRenderer = _textRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v1 (System.Object)+10]");
		TextMesh.get_color_Injected((IntPtr)0, out Color _);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v1 (System.Object)+10]");
		bool flag2 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v1 (System.Object)+10]");
		Color value = default(Color);
		TextMesh.set_color_Injected((IntPtr)0, ref value);
		return this;
	}

	public unsafe BitmapText SetColor(Color color)
	{
		TextMesh textRenderer = _textRenderer;
		bool flag = ((UnityEngine.Object)textRenderer).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		TextMesh.set_color_Injected(((UnityEngine.Object)textRenderer).m_CachedPtr, ref *(Color*)(&value));
		return this;
	}

	public BitmapText SetTint(uint tint)
	{
		TextMesh textMesh = RenderingExtensions.SetTint(_textRenderer, tint);
		return this;
	}

	public BitmapText SetFontSize(int fontSize)
	{
		TextMesh textRenderer = _textRenderer;
		bool flag = ((UnityEngine.Object)textRenderer).m_CachedPtr == (IntPtr)0;
		TextMesh.set_fontSize_Injected(((UnityEngine.Object)textRenderer).m_CachedPtr, fontSize);
		return this;
	}

	public BitmapText SetDepth(int depth)
	{
		if ((object)_textRenderer != null)
		{
			Renderer component = _textRenderer.GetComponent<Renderer>();
			if ((object)component != null)
			{
				component.sortingOrder = depth;
				return this;
			}
		}
		return (BitmapText)(object)new NullReferenceException();
	}

	public BitmapText SetFont(string fontPath)
	{
		GameManager core = GM.Core;
		FontFactory fontFactory = core._fontFactory;
		bool flag = fontFactory._Fonts == null;
		Font font = null;
		if (!flag)
		{
			bool flag2 = ((Dictionary<object, object>)(object)fontFactory._Fonts).TryGetValue((object)fontPath, out object value);
			bool flag3 = !flag2;
			font = null;
			if (!flag3)
			{
				if (value == null)
				{
					return (BitmapText)(object)new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F94830");
				Font font2 = default(Font);
				font = font2;
			}
		}
		if ((object)font != null && ((UnityEngine.Object)font).m_CachedPtr != (IntPtr)0)
		{
			_textRenderer.font = font;
			Renderer component = _textRenderer.GetComponent<Renderer>();
			Material material = font.material;
			component.SetMaterial(material);
		}
		return this;
	}

	public BitmapText setOrigin(float2 origin)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 32 Invalid \"Jump target not found in method: 0x186B48380\"");
		BitmapText result = default(BitmapText);
		return result;
	}

	public BitmapText setOrigin(float originX = 0.5f, float? originY = null)
	{
		//IL_0067: Expected O, but got I4
		EnsureTextRenderer();
		TextMesh textRenderer = _textRenderer;
		if ((object)_textRenderer != null && ((UnityEngine.Object)textRenderer).m_CachedPtr != (IntPtr)0)
		{
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
			Transform transform = _textRenderer.transform;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			Transform transform2 = _textRenderer.transform;
			bool flag3 = (object)transform2 == null;
			bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
			return this;
		}
		return this;
	}

	public BitmapText SetTextAlignments(TextAlignment textAlignment, TextAnchor textAnchor)
	{
		if ((object)_textRenderer != null)
		{
			_textRenderer.alignment = textAlignment;
			TextMesh textRenderer = _textRenderer;
			if ((object)_textRenderer != null)
			{
				bool flag = ((UnityEngine.Object)textRenderer).m_CachedPtr == (IntPtr)0;
				TextMesh.set_anchor_Injected(((UnityEngine.Object)textRenderer).m_CachedPtr, textAnchor);
				return this;
			}
		}
		throw new NullReferenceException();
	}

	public void destroy()
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}

	private unsafe void EnsureTextRenderer()
	{
		//IL_018c->IL0228: Incompatible stack heights: 2 vs 0
		//IL_01b6->IL0228: Incompatible stack heights: 2 vs 0
		//IL_0228->IL0262: Incompatible stack heights: 7 vs 0
		TextMesh textRenderer = _textRenderer;
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
				TextMesh componentInChildren = GetComponentInChildren<TextMesh>();
				_textRenderer = componentInChildren;
				TextMesh textRenderer2 = _textRenderer;
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
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1222 @ rax_v60 (UnityEngine.Transform)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1222 @ rax_v60 (UnityEngine.Transform)+10]");
							Vector3 value3 = default(Vector3);
							Transform.set_localPosition_Injected((IntPtr)0, ref value3);
							Transform transform4 = gameObject2.transform;
							bool flag5 = (object)transform4 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1280 @ rax_v68 (UnityEngine.Transform)+10]");
							bool flag6 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1280 @ rax_v68 (UnityEngine.Transform)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref value);
							TextMesh textRenderer3 = gameObject2.AddComponent<TextMesh>();
							_textRenderer = textRenderer3;
							bool flag7 = (object)_textRenderer == null;
							_textRenderer.alignment = TextAlignment.Center;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public BitmapText()
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
