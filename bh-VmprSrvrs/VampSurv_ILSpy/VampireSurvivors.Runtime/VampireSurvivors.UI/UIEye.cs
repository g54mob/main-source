using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.UI;

public class UIEye : MonoBehaviour
{
	private UISpriteAnimation _anim;

	private Vector3 _baseScale;

	private void Start()
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		_baseScale = ret;
		_ = 0;
		Transform transform2 = base.transform;
		bool flag2 = (object)transform2 == null;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
		ArcanaMainSelectionPage.OnArcanaModeChange value = Toggle;
		ArcanaMainSelectionPage.ArcanaModeChanged += value;
	}

	private void OnDestroy()
	{
		ArcanaMainSelectionPage.OnArcanaModeChange value = Toggle;
		ArcanaMainSelectionPage.ArcanaModeChanged -= value;
	}

	private unsafe void Update()
	{
		//IL_0012: Expected O, but got Ref
		//IL_004f: Expected O, but got Ref
		RectTransform component = GetComponent<RectTransform>();
		Vector3 screenPosFromAnchorPos = VampireSurvivors.App.Tools.Extensions.GetScreenPosFromAnchorPos(component);
		Input.get_mousePosition_Injected(out Vector3 _);
		Transform transform = base.transform;
		float num = default(float);
		transform.right = (Vector3)(&num);
		Transform transform2 = base.transform;
		Transform transform3 = base.transform;
		Vector3 localEulerAngles = transform3.localEulerAngles;
		transform2.localEulerAngles = (Vector3)(&num);
	}

	private unsafe void Toggle(ArcanaMainSelectionPage.ArcanaMode mode)
	{
		//IL_001f: Expected O, but got I
		//IL_024b: Expected O, but got Ref
		//IL_0267: Expected O, but got I4
		//IL_026f: Expected O, but got Ref
		//IL_01bd: Expected O, but got Ref
		//IL_0102: Expected O, but got I
		//IL_00aa: Expected O, but got I4
		//IL_00b2: Expected O, but got Ref
		//IL_0085: Expected O, but got I8
		//IL_00dd: Expected O, but got I4
		//IL_00e5: Expected O, but got Ref
		//IL_0163: Expected O, but got I8
		Vector3 vector = default(Vector3);
		switch (mode)
		{
		case ArcanaMainSelectionPage.ArcanaMode.LIGHT:
		{
			Transform transform = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			Component component = this;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				component = (Component)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v146 @ rax_v17 (should have been resolved before IL gen)");
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(transform, (Vector3)(&vector), 0.2f);
			bool flag2 = tweenerCore3 == null;
			object obj2 = 0;
			Vector3 vector2 = (Vector3)(&vector);
			Transform transform2 = transform;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				bool flag3 = (nint)0 == 0;
				obj2 = 0;
				vector2 = (Vector3)(&vector);
				transform2 = transform;
				if (!flag3)
				{
					_ = 26;
					_ = 0;
					obj2 = 0;
					vector2 = (Vector3)(&vector);
					transform2 = transform;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
				transform2 = (Transform)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v386 @ rax_v22 (should have been resolved before IL gen)");
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = TweenSettingsExtensions.SetDelay(tweenerCore3, 0f);
			break;
		}
		case ArcanaMainSelectionPage.ArcanaMode.DARK:
		{
			Transform target = base.transform;
			float duration = UnityEngine.Random.Range(0.2f, 0.5f);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&vector), duration);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			float delay = UnityEngine.Random.Range(0f, 0.2f);
			TweenerCore<Vector3, Vector3, VectorOptions> t = default(TweenerCore<Vector3, Vector3, VectorOptions>);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, delay);
			_anim.Play(hideWhenDone: true);
			break;
		}
		}
	}

	public UIEye()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
