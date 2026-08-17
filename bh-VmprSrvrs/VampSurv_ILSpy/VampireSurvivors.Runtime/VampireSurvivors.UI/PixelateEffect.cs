using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.Graphics.RenderPass;

namespace VampireSurvivors.UI;

public class PixelateEffect : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<ScriptableRendererFeature> _003C_003E9__6_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe bool _003CPixelate_003Eb__6_0(ScriptableRendererFeature f)
		{
			//IL_0135: Expected I4, but got O
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected Ref, but got Unknown
			//IL_00f2: Expected I8, but got I4
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3444]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)f != null)
			{
				string name = ((UnityEngine.Object)f).GetName();
				object obj = "PixelateRenderFeature";
				if ((object)name != "PixelateRenderFeature")
				{
					if (name != null && "PixelateRenderFeature" != null)
					{
						int stringLength = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2+10]");
						if ((nint)stringLength == 0)
						{
							ref byte first = ref *(byte*)(name + 20);
							ulong length = (ulong)(name._stringLength + name._stringLength);
							return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("PixelateRenderFeature" + 20), length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public float startSize;

		public PixelateEffect _003C_003E4__this;

		public PixelateRenderFeature blit;

		public bool disableWhenFinished;

		internal float _003CPixelate_003Eb__1()
		{
			return startSize;
		}

		internal void _003CPixelate_003Eb__2(float x)
		{
			startSize = x;
		}

		internal void _003CPixelate_003Eb__3()
		{
			PixelateEffect pixelateEffect = _003C_003E4__this;
			pixelateEffect._pixelizer.SetFloatImpl(CellSizeX, startSize);
			PixelateEffect pixelateEffect2 = _003C_003E4__this;
			pixelateEffect2._pixelizer.SetFloatImpl(CellSizeY, startSize);
		}

		internal void _003CPixelate_003Eb__4()
		{
			PixelateRenderFeature pixelateRenderFeature = blit;
			((ScriptableRendererFeature)pixelateRenderFeature).m_Active = true;
		}

		internal void _003CPixelate_003Eb__5()
		{
			if (disableWhenFinished)
			{
				PixelateRenderFeature pixelateRenderFeature = blit;
				((ScriptableRendererFeature)pixelateRenderFeature).m_Active = false;
			}
		}
	}

	private Renderer2DData _forwardRendererData;

	private Material _pixelizer;

	private static readonly int CellSizeX;

	private static readonly int CellSizeY;

	private static readonly int PixelSize;

	private static readonly int TexSize;

	public unsafe Tween Pixelate(float startSize, float endSize, float duration = 1f, bool disableWhenFinished = true)
	{
		//IL_0012: Expected O, but got I8
		//IL_0097: Expected I, but got O
		//IL_00a5: Expected I, but got O
		//IL_00b5: Expected O, but got I
		//IL_0135: Expected O, but got I4
		//IL_00f1: Expected O, but got I
		//IL_0127: Expected O, but got I4
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected O, but got Unknown
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_06cd: Expected O, but got I4
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e2: Expected O, but got Unknown
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_067b: Expected O, but got I4
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0690: Expected O, but got Unknown
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass6_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals20.startSize = startSize;
		CS_0024_003C_003E8__locals20._003C_003E4__this = this;
		bool disableWhenFinished2 = default(bool);
		CS_0024_003C_003E8__locals20.disableWhenFinished = disableWhenFinished2;
		Renderer2DData forwardRendererData = _forwardRendererData;
		Predicate<ScriptableRendererFeature> match = _003C_003Ec._003C_003E9__6_0;
		if (_003C_003Ec._003C_003E9__6_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__6_0 = delegate(ScriptableRendererFeature f)
			{
				//IL_0135: Expected I4, but got O
				//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00db: Expected Ref, but got Unknown
				//IL_00f2: Expected I8, but got I4
				//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
				//IL_0101: Expected Ref, but got Unknown
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3444]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if ((object)f == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				string text = ((UnityEngine.Object)f).GetName();
				object obj19 = "PixelateRenderFeature";
				if ((object)text != "PixelateRenderFeature")
				{
					if (text != null && "PixelateRenderFeature" != null)
					{
						int stringLength = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2+10]");
						if ((nint)stringLength == 0)
						{
							ref byte first = ref *(byte*)(text + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("PixelateRenderFeature" + 20), length);
						}
					}
					return false;
				}
				return true;
			});
		}
		ScriptableRendererFeature scriptableRendererFeature = ((ScriptableRendererData)forwardRendererData).m_RendererFeatures.Find(match);
		bool flag = (object)scriptableRendererFeature == null;
		ScriptableRendererFeature blit = scriptableRendererFeature;
		if (flag)
		{
			goto IL_058f;
		}
		nint num = (nint)scriptableRendererFeature;
		nint num2 = (nint)typeof(PixelateRenderFeature);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rdx_v48 (Il2CppClass<VampireSurvivors.Graphics.RenderPass.PixelateRenderFeature>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ r9_v16 (Il2CppClass<UnityEngine.Rendering.Universal.ScriptableRendererFeature>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rdx_v48 (Il2CppClass<VampireSurvivors.Graphics.RenderPass.PixelateRenderFeature>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ r9_v16 (Il2CppClass<UnityEngine.Rendering.Universal.ScriptableRendererFeature>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v99+FFFFFFF8+v442 @ rax_v94*8]");
			if (0 == (nint)typeof(PixelateRenderFeature))
			{
				obj4 = 1;
				goto IL_05a1;
			}
		}
		obj4 = 0;
		goto IL_05a1;
		IL_050a:
		TweenerCore<float, float, FloatOptions> tweenerCore;
		return tweenerCore;
		IL_05a1:
		bool flag2 = obj4 == null;
		blit = null;
		if (!flag2)
		{
			blit = scriptableRendererFeature;
		}
		goto IL_058f;
		IL_058f:
		CS_0024_003C_003E8__locals20.blit = (PixelateRenderFeature)blit;
		PixelateRenderFeature blit2 = CS_0024_003C_003E8__locals20.blit;
		if ((object)CS_0024_003C_003E8__locals20.blit != null && ((UnityEngine.Object)blit2).m_CachedPtr != (IntPtr)0)
		{
			PixelateRenderFeature blit3 = CS_0024_003C_003E8__locals20.blit;
			Material passMaterial = new Material(blit3._BlitMaterial);
			blit3.passMaterial = passMaterial;
			PixelateRenderFeature blit4 = CS_0024_003C_003E8__locals20.blit;
			_pixelizer = blit4.passMaterial;
			_pixelizer.SetFloatImpl(CellSizeX, CS_0024_003C_003E8__locals20.startSize);
			_pixelizer.SetFloatImpl(CellSizeY, CS_0024_003C_003E8__locals20.startSize);
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((_003C_003Ec__DisplayClass6_0)(object)dOSetter)._003CPixelate_003Eb__2(startSize);
			tweenerCore = DOTween.To(getter, dOSetter, endSize, duration);
			TweenCallback tweenCallback = delegate
			{
				PixelateEffect pixelateEffect = CS_0024_003C_003E8__locals20._003C_003E4__this;
				pixelateEffect._pixelizer.SetFloatImpl(CellSizeX, CS_0024_003C_003E8__locals20.startSize);
				PixelateEffect pixelateEffect2 = CS_0024_003C_003E8__locals20._003C_003E4__this;
				pixelateEffect2._pixelizer.SetFloatImpl(CellSizeY, CS_0024_003C_003E8__locals20.startSize);
			};
			TweenCallback tweenCallback3;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
						bool flag3 = (nint)0 == 0;
						_ = 0;
						if (!flag3)
						{
							object obj5 = tweenerCore + 184;
							object obj6 = obj5 >> 12;
							object obj7 = obj6 & 0x1FFFFF;
							object obj8 = obj7 >> 6;
							object obj9 = obj7 & 0x3F;
							nint num5;
							do
							{
								object obj10 = 1 << (int)obj9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v3+462E0+v1181 @ rdx_v37*8]");
								object obj11 = 0 | obj10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v3+462E0+v1181 @ rdx_v37*8]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v3+462E0+v1181 @ rdx_v37*8]");
								if (num4 == 0)
								{
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v3+462E0+v1181 @ rdx_v37*8]");
								num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v3+462E0+v1181 @ rdx_v37*8]");
							}
							while (num5 != 0);
							TweenCallback tweenCallback2 = delegate
							{
								PixelateRenderFeature blit5 = CS_0024_003C_003E8__locals20.blit;
								((ScriptableRendererFeature)blit5).m_Active = true;
							};
							tweenCallback3 = tweenCallback2;
							goto IL_03d3;
						}
					}
				}
			}
			TweenCallback tweenCallback4 = delegate
			{
				PixelateRenderFeature blit5 = CS_0024_003C_003E8__locals20.blit;
				((ScriptableRendererFeature)blit5).m_Active = true;
			};
			bool flag4 = tweenerCore == null;
			tweenCallback3 = tweenCallback4;
			if (!flag4)
			{
				goto IL_03d3;
			}
			goto IL_049d;
		}
		NullReferenceException ex = new NullReferenceException("Blit render feature is invalid, please check");
		ex._002Ector("Blit render feature is invalid, please check");
		throw ex;
		IL_04db:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_050a;
		IL_049d:
		TweenCallback tweenCallback5 = delegate
		{
			if (CS_0024_003C_003E8__locals20.disableWhenFinished)
			{
				PixelateRenderFeature blit5 = CS_0024_003C_003E8__locals20.blit;
				((ScriptableRendererFeature)blit5).m_Active = false;
			}
		};
		bool flag5 = tweenerCore == null;
		TweenCallback tweenCallback6 = tweenCallback5;
		if (!flag5)
		{
			goto IL_04db;
		}
		goto IL_050a;
		IL_03d3:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			if ((nint)0 != 0)
			{
				object obj12 = tweenerCore + 32;
				object obj13 = obj12 >> 12;
				object obj14 = obj13 & 0x1FFFFF;
				object obj15 = obj14 >> 6;
				object obj16 = obj14 & 0x3F;
				nint num7;
				do
				{
					object obj17 = 1 << (int)obj16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v3+462E0+v1213 @ rdx_v31*8]");
					object obj18 = 0 | obj17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v3+462E0+v1213 @ rdx_v31*8]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v3+462E0+v1213 @ rdx_v31*8]");
					if (num6 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v3+462E0+v1213 @ rdx_v31*8]");
					num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v3+462E0+v1213 @ rdx_v31*8]");
				}
				while (num7 != 0);
				TweenCallback tweenCallback7 = delegate
				{
					if (CS_0024_003C_003E8__locals20.disableWhenFinished)
					{
						PixelateRenderFeature blit5 = CS_0024_003C_003E8__locals20.blit;
						((ScriptableRendererFeature)blit5).m_Active = false;
					}
				};
				tweenCallback6 = tweenCallback7;
				goto IL_04db;
			}
		}
		goto IL_049d;
	}

	public PixelateEffect()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static PixelateEffect()
	{
		int cellSizeX = Shader.PropertyToID("_CellSizeX");
		CellSizeX = cellSizeX;
		int cellSizeY = Shader.PropertyToID("_CellSizeY");
		CellSizeY = cellSizeY;
		int pixelSize = Shader.PropertyToID("_PixelSize");
		PixelSize = pixelSize;
		int texSize = Shader.PropertyToID("_TexSize");
		TexSize = texSize;
	}
}
