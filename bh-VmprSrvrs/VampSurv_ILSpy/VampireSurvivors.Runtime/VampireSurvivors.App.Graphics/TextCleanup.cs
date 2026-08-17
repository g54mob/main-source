using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.App.Graphics;

public class TextCleanup : MonoBehaviour
{
	protected TextMeshProUGUI _text;

	protected RectTransform _rectTransform;

	protected Color _currentCol;

	private void Awake()
	{
		//IL_0052: Expected I, but got O
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			TextMeshProUGUI component = gameObject.GetComponent<TextMeshProUGUI>();
			_text = component;
			TextMeshProUGUI text = _text;
			if ((object)_text != null)
			{
				nint num = (nint)text;
				Material material = _text.GetMaterial(((TMP_Text)text).m_sharedMaterial);
				GameObject gameObject2 = base.gameObject;
				if ((object)gameObject2 != null)
				{
					RectTransform component2 = gameObject2.GetComponent<RectTransform>();
					_rectTransform = component2;
					if ((object)_text != null)
					{
						Canvas canvas = _text.canvas;
						if ((object)canvas != null)
						{
							bool flag = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 219 ConditionalJump @-1, v249 @ ZF_v15 (System.Boolean) --- -1 Nop");
							/*Error: End of method reached without returning.*/;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Update()
	{
		CleanupPosition();
	}

	private void CleanupPosition()
	{
		//IL_00ee->IL0093: Incompatible stack heights: 1 vs 0
		//IL_0151->IL0093: Incompatible stack heights: 2 vs 0
		TextMeshProUGUI text = _text;
		if ((object)_text != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			_text.fontSize = ((TMP_Text)text).m_fontSize;
			TextMeshProUGUI rectTransform = (TextMeshProUGUI)(object)_rectTransform;
			if ((object)_rectTransform != null)
			{
				bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
				RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Rect _);
				TextMeshProUGUI rectTransform2 = (TextMeshProUGUI)(object)_rectTransform;
				if ((object)_rectTransform != null)
				{
					bool flag2 = ((UnityEngine.Object)rectTransform2).m_CachedPtr == (IntPtr)0;
					RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform2).m_CachedPtr, out Rect ret2);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
					TextCleanup rectTransform3 = (TextCleanup)(object)_rectTransform;
					if ((object)_rectTransform != null)
					{
						bool flag3 = ((UnityEngine.Object)rectTransform3).m_CachedPtr == (IntPtr)0;
						RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform3).m_CachedPtr, out ret2);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void MatchColour()
	{
		//IL_0095: Expected O, but got Ref
		//IL_00d4: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2DFC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Material materialForRendering = _text.materialForRendering;
		materialForRendering.EnableKeyword("UNDERLAY_ON");
		Material materialForRendering2 = _text.materialForRendering;
		Color color = _text.color;
		float num = default(float);
		materialForRendering2.SetColor("_UnderlayColor", (Color)(&num));
		Material materialForRendering3 = _text.materialForRendering;
		Color color2 = _text.color;
		materialForRendering3.SetColor("_OutlineColor", (Color)(&num));
	}

	public TextCleanup()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
