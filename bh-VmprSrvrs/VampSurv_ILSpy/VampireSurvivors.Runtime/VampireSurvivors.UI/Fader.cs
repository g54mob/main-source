using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class Fader : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public UISignals.FadeScreenSignal sig;

		internal void _003CFade_003Eb__0()
		{
			//IL_0035: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.Fader+<>c__DisplayClass6_0)+20]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.Fader+<>c__DisplayClass6_0)+20]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ rax_v1+18] (should have been resolved before IL gen)");
			}
		}
	}

	private Image _image;

	private SignalBus _signalBus;

	private void Construct(SignalBus signal)
	{
		_signalBus = signal;
	}

	private void OnEnable()
	{
		//IL_0085: Expected O, but got I4
		//IL_0085: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00ea: Expected O, but got I
		Action<UISignals.FadeScreenSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E280");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.FadeScreenSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.FadeScreenSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v12 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Action<UISignals.FadeScreenSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E280");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
	}

	private void Awake()
	{
		Image component = GetComponent<Image>();
		_image = component;
	}

	private unsafe void Fade(UISignals.FadeScreenSignal sig)
	{
		//IL_0012: Expected O, but got I8
		//IL_0024: Expected O, but got F4
		//IL_0079: Expected O, but got Ref
		//IL_009c: Expected F4, but got I
		//IL_009c: Expected F4, but got I
		//IL_0105: Expected O, but got I
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0295: Expected O, but got I4
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass6_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals1.sig = (UISignals.FadeScreenSignal)sig.From;
		_ = sig.OnComplete;
		Color color = _image.color;
		Color color2 = _image.color;
		Color color3 = _image.color;
		object obj2 = default(object);
		_image.color = (Color)(&obj2);
		Image image = _image;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (VampireSurvivors.UI.Fader+<>c__DisplayClass6_0)+14]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (VampireSurvivors.UI.Fader+<>c__DisplayClass6_0)+18]");
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(image, num, 0f);
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (VampireSurvivors.UI.Fader+<>c__DisplayClass6_0)+1C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (VampireSurvivors.UI.Fader+<>c__DisplayClass6_0)+1C]");
				object obj3 = (nint)0 + (nint)(-32);
				if ((nint)obj3 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
				{
					object obj4 = tweenerCore + 184;
					object obj5 = obj4 >> 12;
					object obj6 = obj5 & 0x1FFFFF;
					object obj7 = obj6 >> 6;
					object obj8 = obj6 & 0x3F;
					nint num3;
					do
					{
						object obj9 = 1 << (int)obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rbp_v2+462E0+v395 @ rdx_v13*8]");
						object obj10 = 0 | obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rbp_v2+462E0+v395 @ rdx_v13*8]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rbp_v2+462E0+v395 @ rdx_v13*8]");
						if (num2 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rbp_v2+462E0+v395 @ rdx_v13*8]");
						num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rbp_v2+462E0+v395 @ rdx_v13*8]");
					}
					while (num3 != 0);
					TweenCallback tweenCallback = delegate
					{
						//IL_0035: Expected O, but got I
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.Fader+<>c__DisplayClass6_0)+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.Fader+<>c__DisplayClass6_0)+20]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ rax_v1+18] (should have been resolved before IL gen)");
						}
					};
					tweenCallback2 = tweenCallback;
					goto IL_01ef;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			//IL_0035: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.Fader+<>c__DisplayClass6_0)+20]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.Fader+<>c__DisplayClass6_0)+20]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ rax_v1+18] (should have been resolved before IL gen)");
			}
		};
		bool flag2 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag2)
		{
			goto IL_01ef;
		}
		return;
		IL_01ef:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
	}

	public Fader()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
