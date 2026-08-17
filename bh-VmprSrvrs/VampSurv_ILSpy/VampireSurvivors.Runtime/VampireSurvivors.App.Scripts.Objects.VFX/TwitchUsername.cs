using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.App.Scripts.Objects.VFX;

public class TwitchUsername : MonoBehaviour
{
	private Text _UsernameText;

	public unsafe void Init(string username, Vector2 spawnPos)
	{
		//IL_034c: Expected O, but got F4
		//IL_04e3: Expected O, but got F4
		//IL_035a: Expected O, but got F4
		//IL_002b: Expected I, but got O
		//IL_0038: Expected O, but got Ref
		//IL_0410: Expected O, but got I
		//IL_008b: Expected I, but got I8
		//IL_0483: Expected O, but got F4
		//IL_0090->IL0506: Incompatible stack heights: 3 vs 2
		//IL_02d3->IL030e: Incompatible stack heights: 4 vs 3
		_UsernameText.text = username;
		Text usernameText = _UsernameText;
		object obj = UnityEngine.Random.value;
		object obj2 = UnityEngine.Random.value;
		object obj3 = UnityEngine.Random.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm6\"");
		object obj4 = obj3 >> 8;
		object obj5 = obj3 >> 16;
		float num = (float)obj5 / 255f;
		float num2 = (float)obj4 / 255f;
		nint num3 = (nint)usernameText;
		object obj6 = default(object);
		usernameText.color = (Color)(&obj6);
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag3 = (nint)0 != 0;
		nint cachedPtr = ((UnityEngine.Object)transform).m_CachedPtr;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag4 = obj7 == null;
			cachedPtr = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v966 @ rax_v65 (should have been resolved before IL gen)");
		object obj8 = default(object);
		float num4 = (float)obj8 + 0.16f;
		bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Sequence sequence = DOTween.Sequence();
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, 0.5f, 0.3f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1228 @ rax_v73 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
		object obj9 = UnityEngine.Random.value;
		object obj10 = default(object);
		float num5 = (float)obj10 * 24f;
		float endValue = num5 + num4;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOLocalMoveY(transform, endValue, 0.3f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1452 @ rax_v80 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore2, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)tweenerCore2, 0f);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(transform, 1f, 0.6f);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1545 @ rax_v84 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		TweenCallback onComplete;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore3, false))
		{
			bool flag6 = sequence == null;
			Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)tweenerCore3, ((Tween)sequence).duration);
			TweenCallback tweenCallback = delegate
			{
				GameObject obj11 = base.gameObject;
				UnityEngine.Object.Destroy(obj11, 0f);
			};
			onComplete = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				GameObject obj11 = base.gameObject;
				UnityEngine.Object.Destroy(obj11, 0f);
			};
			bool flag7 = sequence == null;
			onComplete = tweenCallback2;
			if (flag7)
			{
				return;
			}
		}
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onComplete = onComplete;
		}
	}

	public TwitchUsername()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CInit_003Eb__1_0()
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}
}
