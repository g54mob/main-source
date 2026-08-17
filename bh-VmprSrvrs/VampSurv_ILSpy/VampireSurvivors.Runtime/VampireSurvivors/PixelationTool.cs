using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors;

public class PixelationTool : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public float v;

		public PixelationTool _003C_003E4__this;

		internal float _003CAnimate_003Eb__0()
		{
			return v;
		}

		internal void _003CAnimate_003Eb__1(float x)
		{
			v = x;
		}

		internal void _003CAnimate_003Eb__2()
		{
			_003C_003E4__this.SetPixels(v);
		}
	}

	public float PixelationFactor;

	private Renderer rend;

	private Image image;

	private void Start()
	{
		Renderer component = GetComponent<Renderer>();
		rend = component;
		Image component2 = GetComponent<Image>();
		image = component2;
	}

	private void Update()
	{
	}

	private void SetPixels(float v)
	{
		Renderer renderer = rend;
		if ((object)rend != null && ((UnityEngine.Object)renderer).m_CachedPtr != (IntPtr)0)
		{
			Material material = rend.GetMaterial();
			int num = Shader.PropertyToID("Vector1_B7523AFA");
			material.SetFloatImpl(num, v);
		}
		Image image = this.image;
		if ((object)this.image != null && ((UnityEngine.Object)image).m_CachedPtr != (IntPtr)0)
		{
			Material material2 = this.image.material;
			int num2 = Shader.PropertyToID("Vector1_B7523AFA");
			material2.SetFloatImpl(num2, v);
		}
	}

	public void AnimateIn()
	{
		Ease ease = default(Ease);
		Animate(12f, 140f, 2f, ease);
	}

	public void Animate(float start, float end, float duration, Ease ease)
	{
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		SetPixels(start);
		CS_0024_003C_003E8__locals4.v = start;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((_003C_003Ec__DisplayClass7_0)(object)dOSetter)._003CAnimate_003Eb__1(start);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, end, duration);
		TweenCallback tweenCallback = delegate
		{
			CS_0024_003C_003E8__locals4._003C_003E4__this.SetPixels(CS_0024_003C_003E8__locals4.v);
		};
		if (tweenerCore == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
			object obj2 = default(object);
			object obj = obj2 + -32;
			if ((nint)obj <= 3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rbx+0C0h]\"");
			}
			_ = 0;
		}
	}

	public PixelationTool()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
