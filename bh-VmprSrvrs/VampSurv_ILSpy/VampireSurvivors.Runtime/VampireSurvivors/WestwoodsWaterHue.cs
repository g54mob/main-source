using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors;

public class WestwoodsWaterHue : MonoBehaviour
{
	private enum HueChangeState
	{
		Intro,
		Loop
	}

	[Serializable]
	private struct WestwoodsHueChange
	{
		public Gradient HueChangeOverTime;

		public float Duration;

		public float HueLoopDuration;
	}

	private Gradient _introHueGradient;

	private float _introHueIncrease;

	private float _introDuration;

	private float _introHueChangeDuration;

	private float _hueChangeTransitionTime;

	private TileSprite _waterTileSprite;

	private HueChangeState _currentHueChangeState;

	private float _hueTimer;

	private float _hueChangeTimer;

	private int _currentHueChangeIndex;

	private bool _transitioning;

	private float _transitionTimer;

	private Color _transitionStartColour;

	private WestwoodsHueChange[] _hueChanges;

	public void SetWaterTileSprite(TileSprite waterTileSprite)
	{
		_waterTileSprite = waterTileSprite;
	}

	private unsafe void Update()
	{
		//IL_046b: Expected O, but got F4
		//IL_0174: Expected O, but got I4
		//IL_0191: Expected O, but got I
		//IL_0199: Invalid comparison between F4 and O
		//IL_0783: Expected O, but got F4
		//IL_05b4: Invalid comparison between F4 and O
		//IL_0609: Expected F4, but got I
		//IL_024d: Expected O, but got I4
		//IL_026a: Expected O, but got I
		//IL_0523: Expected F4, but got I
		//IL_0371: Invalid comparison between I4 and F4
		//IL_022b: Expected O, but got F4
		//IL_0238: Expected I, but got O
		//IL_03bc: Expected F4, but got I4
		//IL_0551: Expected O, but got I
		//IL_010e: Expected O, but got I
		//IL_011e: Expected O, but got Ref
		//IL_057a: Expected O, but got Ref
		//IL_0759: Expected O, but got I
		//IL_0311: Expected O, but got I
		//IL_03cc: Expected O, but got I
		//IL_03e4: Expected O, but got Ref
		//IL_0657: Expected O, but got Ref
		//IL_065f: Expected O, but got Ref
		//IL_0674: Expected O, but got I
		//IL_04fb->IL04a8: Incompatible stack heights: 1 vs 0
		//IL_07ce->IL0461: Incompatible stack heights: 3 vs 0
		//IL_0679->IL07bf: Incompatible stack heights: 4 vs 3
		//IL_0414->IL0414: Incompatible stack heights: 4 vs 0
		TileSprite waterTileSprite = _waterTileSprite;
		if ((object)_waterTileSprite == null || ((UnityEngine.Object)waterTileSprite).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		object obj = Time.deltaTime;
		Color color = default(Color);
		float num = (_hueTimer = (float)color + _hueTimer);
		nint num2 = default(nint);
		bool num3;
		bool num5;
		WestwoodsWaterHue westwoodsWaterHue;
		bool num6;
		float num8 = default(float);
		if (_currentHueChangeState == HueChangeState.Intro)
		{
			Color ret = default(Color);
			if (num > _introDuration)
			{
				TileSprite waterTileSprite2 = _waterTileSprite;
				_hueTimer = 0f;
				_currentHueChangeState = HueChangeState.Loop;
				object spriteRenderer = waterTileSprite2._spriteRenderer;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rsi_v27 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rsi_v27 (System.Object)+10]");
				SpriteRenderer.get_color_Injected((IntPtr)0, out ret);
				_transitionStartColour = ret;
				num2 = (nint)(&ret);
			}
			object obj2 = Time.deltaTime;
			if ((_hueChangeTimer = (float)ret + _hueChangeTimer) > _introHueChangeDuration)
			{
				_hueChangeTimer = 0f;
			}
			TileSprite waterTileSprite3 = _waterTileSprite;
			object introHueGradient = _introHueGradient;
			object spriteRenderer2 = waterTileSprite3._spriteRenderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rcx_v78 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			num3 = flag2;
			float num4 = _hueChangeTimer / _introHueChangeDuration;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rcx_v78 (System.Object)+10]");
			float ret2;
			Gradient.Evaluate_Injected((IntPtr)0, (float)num2, out *(Color*)(&ret2));
			bool flag3 = (object)waterTileSprite3._spriteRenderer == null;
			num5 = flag3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rdi_v32 (System.Object)+10]");
			westwoodsWaterHue = (WestwoodsWaterHue)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rdi_v32 (System.Object)+10]");
			bool flag4 = (nint)0 == 0;
			num6 = flag4;
			object obj3 = 0;
			float num7 = num4;
			object obj4 = (object)(&ret2);
			num8 = ret2;
			float num9 = ret2;
			goto IL_0572;
		}
		object obj11;
		WestwoodsWaterHue westwoodsWaterHue2;
		if (_currentHueChangeState == HueChangeState.Loop)
		{
			WestwoodsHueChange[] hueChanges = _hueChanges;
			object obj5 = _currentHueChangeIndex + 2;
			object obj6 = obj5 + obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rcx_v57 (WestwoodsHueChange[])+v732 @ rax_v69*8]");
			WestwoodsHueChange westwoodsHueChange = (WestwoodsHueChange)0;
			object obj7 = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
			{
				if (++_currentHueChangeIndex == hueChanges.Length)
				{
					TileSprite waterTileSprite4 = _waterTileSprite;
					_currentHueChangeIndex = 0;
					_transitionStartColour = (Color)waterTileSprite4._spriteRenderer.color.r;
					num2 = (nint)waterTileSprite4._spriteRenderer;
				}
				WestwoodsHueChange[] hueChanges2 = _hueChanges;
				_transitionTimer = 0f;
				_hueTimer = 0f;
				object obj8 = _currentHueChangeIndex + 2;
				object obj9 = obj8 + obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rcx_v74 (WestwoodsHueChange[])+v894 @ rax_v89*8]");
				westwoodsHueChange = (WestwoodsHueChange)0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
			object obj10 = default(object);
			float num10 = (_hueChangeTimer = (float)obj10 + _hueChangeTimer);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num10) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
			{
				_hueChangeTimer = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ xmm7_v17 (VampireSurvivors.WestwoodsWaterHue+WestwoodsHueChange)+10]");
			bool flag5 = (nint)0 == 0;
			num3 = flag5;
			float num11 = _hueChangeTimer / (float)obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ xmm7_v17 (VampireSurvivors.WestwoodsWaterHue+WestwoodsHueChange)+10]");
			float ret3;
			Gradient.Evaluate_Injected((IntPtr)0, (float)num2, out *(Color*)(&ret3));
			float num7;
			object obj3;
			object obj4;
			float num9;
			if (!(_hueChangeTransitionTime > _transitionTimer))
			{
				TileSprite waterTileSprite5 = _waterTileSprite;
				bool flag6 = (object)_waterTileSprite == null;
				WestwoodsWaterHue spriteRenderer3 = (WestwoodsWaterHue)(object)waterTileSprite5._spriteRenderer;
				bool flag7 = (object)waterTileSprite5._spriteRenderer == null;
				bool flag8 = ((UnityEngine.Object)spriteRenderer3).m_CachedPtr == (IntPtr)0;
				obj3 = 0;
				num7 = num11;
				obj4 = (object)(&ret3);
				obj11 = (object)(&num8);
				num9 = ret3;
				westwoodsWaterHue2 = (WestwoodsWaterHue)(nint)((UnityEngine.Object)spriteRenderer3).m_CachedPtr;
				goto IL_07bf;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
			TileSprite waterTileSprite6 = _waterTileSprite;
			object obj12 = default(object);
			float num12 = (_transitionTimer = (float)obj12 + _transitionTimer) / _hueChangeTransitionTime;
			object spriteRenderer4 = waterTileSprite6._spriteRenderer;
			if (!(0f > num12))
			{
				if (num12 > 1f)
				{
					num12 = 1f;
				}
			}
			else
			{
				num12 = 0f;
			}
			float num13 = ret3 - (float)_transitionStartColour;
			object obj14 = default(object);
			object obj13 = obj14 - obj7;
			float num14 = num13 * num12;
			float num15 = (float)obj13 * num12;
			float num16 = num14 + (float)_transitionStartColour;
			float num17 = num15 + (float)obj7;
			object obj16 = default(object);
			object obj15 = obj16 - obj7;
			object obj18 = default(object);
			object obj17 = obj18 - obj7;
			float num18 = (float)obj15 * num12;
			float num19 = (float)obj17 * num12;
			float num20 = num18 + (float)obj7;
			num7 = num19 + (float)obj7;
			bool flag9 = (object)waterTileSprite6._spriteRenderer == null;
			num5 = flag9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1484 @ rdi_v28 (System.Object)+10]");
			westwoodsWaterHue = (WestwoodsWaterHue)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1484 @ rdi_v28 (System.Object)+10]");
			bool flag10 = (nint)0 == 0;
			num6 = flag10;
			obj3 = 0;
			bool flag11 = (nint)0 != 0;
			obj4 = (object)(&ret3);
			num8 = num16;
			num9 = num16;
			if (flag11)
			{
				goto IL_0572;
			}
			bool flag12 = (nint)0 == 0;
		}
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
		throw ex;
		IL_07bf:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1671 @ rax_v58 (should have been resolved before IL gen)");
		return;
		IL_0572:
		obj11 = (object)(&num8);
		westwoodsWaterHue2 = westwoodsWaterHue;
		goto IL_07bf;
	}

	public WestwoodsWaterHue()
	{
		//IL_002b: Expected I, but got O
		_introDuration = 32f;
		_introHueChangeDuration = 1f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
