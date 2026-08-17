using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors;

public class RuneStripUI : MonoBehaviour
{
	private RawImage _image;

	private float speed;

	private float color;

	public unsafe void Initialize()
	{
		//IL_0015: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_00c8: Expected O, but got Ref
		//IL_0076: Expected O, but got I8
		//IL_00b4: Expected O, but got I8
		RawImage component = GetComponent<RawImage>();
		_image = component;
		Component component2 = this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			component2 = (Component)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v115 @ rax_v11 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		speed = -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			component2 = (Component)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v155 @ rax_v14 (should have been resolved before IL gen)");
		color = 0.4f;
		object obj3 = default(object);
		_image.color = (Color)(&obj3);
		MonoBehaviour.InvokeDelayed((MonoBehaviour)this, "Hide", 2f, 0f);
	}

	private void LateUpdate()
	{
		//IL_0111: Expected O, but got F4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_00fa: Expected O, but got I4
		RawImage image = _image;
		object obj = Time.deltaTime;
		RawImage image2 = _image;
		object obj3 = default(object);
		object obj2 = obj3 * speed;
		Rect rect = default(Rect);
		object obj4 = obj2 + (object)rect;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018735F68Bh\"");
		if ((object)image.m_UVRect == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018735F68Bh\"");
			if ((object)rect == obj4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018735F68Bh\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v10 (UnityEngine.UI.RawImage)+F0]");
				if ((object)rect == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v10 (UnityEngine.UI.RawImage)+F4]");
					bool flag = (object)rect == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018735F68Bh\"");
					if (flag)
					{
						return;
					}
				}
			}
		}
		image.m_UVRect = (Rect)0;
		image.SetVerticesDirty();
	}

	private void Hide()
	{
		//IL_00fa: Expected O, but got I
		//IL_01fa: Invalid comparison between I4 and F4
		//IL_003e: Expected O, but got I8
		//IL_0194: Expected O, but got I
		//IL_0246: Expected O, but got I
		//IL_00ab: Expected I, but got I8
		//IL_00e5: Expected O, but got I8
		//IL_00b0->IL0211: Incompatible stack heights: 2 vs 1
		//IL_00ea->IL01c9: Incompatible stack heights: 2 vs 1
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		RuneStripUI runeStripUI = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			runeStripUI = (RuneStripUI)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v47 @ rax_v5 (should have been resolved before IL gen)");
		float num = ((!(0f > 0.5f)) ? (-2f) : 2f);
		RectTransform component = GetComponent<RectTransform>();
		Vector2 anchoredPosition = component.anchoredPosition;
		bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)component).m_CachedPtr, out Rect _);
		object obj2 = default(object);
		float num2 = (float)obj2 * num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag3 = (nint)0 != 0;
		nint cachedPtr = ((UnityEngine.Object)component).m_CachedPtr;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag4 = obj3 == null;
			cachedPtr = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v390 @ rax_v15 (should have been resolved before IL gen)");
		Vector2 endValue = default(Vector2);
		TweenerCore<Vector2, Vector2, VectorOptions> t = DOTweenModuleUI.DOAnchorPos(component, endValue, 0.6f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag5 = (nint)0 != 0;
		RectTransform rectTransform = component;
		if (!flag5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag6 = obj4 == null;
			rectTransform = (RectTransform)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v508 @ rax_v19 (should have been resolved before IL gen)");
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 0f);
	}

	public RuneStripUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
