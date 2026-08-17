using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DForwardFocus : BasePC2D, IPreMover
{
	private sealed class _003CEnable_003Ed__28(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DForwardFocus _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_006e: Expected I4, but got I8
			//IL_00af: Expected I4, but got O
			ProCamera2DForwardFocus proCamera2DForwardFocus = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				proCamera2DForwardFocus.__enabled = (byte)_003C_003E1__state != 0;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public static string ExtensionName = "Forward Focus";

	private const float EPSILON = 0.001f;

	public bool Progressive;

	public float SpeedMultiplier;

	public float TransitionSmoothness;

	public bool MaintainInfluenceOnStop;

	public Vector2 MovementThreshold;

	public float LeftFocus;

	public float RightFocus;

	public float TopFocus;

	public float BottomFocus;

	private float _hVel;

	private float _hVelSmooth;

	private float _vVel;

	private float _vVelSmooth;

	private float _targetHVel;

	private float _targetVVel;

	private bool _isFirstHorizontalCameraMovement;

	private bool _isFirstVerticalCameraMovement;

	private bool __enabled;

	private int _prmOrder;

	public int PrMOrder
	{
		get
		{
			return _prmOrder;
		}
		set
		{
			_prmOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		IEnumerator routine = Enable();
		Coroutine coroutine = StartCoroutine(routine);
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.AddPreMover(this);
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._preMovers).Remove((object)this);
		}
	}

	public void PreMove(float deltaTime)
	{
		if (__enabled && base.enabled)
		{
			ApplyInfluence(deltaTime);
		}
	}

	public override void OnReset()
	{
		_hVel = 0f;
		_vVel = 0f;
		_targetHVel = 0f;
		_isFirstHorizontalCameraMovement = false;
		__enabled = false;
		IEnumerator routine = Enable();
		Coroutine coroutine = StartCoroutine(routine);
	}

	private IEnumerator Enable()
	{
		_003CEnable_003Ed__28 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void ApplyInfluence(float deltaTime)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00da: Expected F4, but got I4
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0179: Expected F4, but got I4
		//IL_055f: Expected O, but got F4
		//IL_0336: Invalid comparison between F4 and I4
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		//IL_01be: Invalid comparison between F4 and O
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0300: Invalid comparison between F4 and O
		//IL_01ec: Invalid comparison between I4 and F4
		//IL_09f3: Invalid comparison between F4 and I4
		//IL_01de: Expected F4, but got I4
		//IL_05f8: Expected O, but got F4
		//IL_0328: Expected O, but got I4
		//IL_0996: Unknown result type (might be due to invalid IL or missing references)
		//IL_099b: Expected O, but got Unknown
		//IL_09a4: Invalid comparison between F4 and O
		//IL_0a28: Expected O, but got I4
		//IL_0a31: Expected O, but got I4
		//IL_0a3a: Expected O, but got I4
		//IL_0260: Invalid comparison between I4 and F4
		//IL_0bf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf6: Expected O, but got Unknown
		//IL_0bff: Invalid comparison between F4 and O
		//IL_0252: Expected F4, but got I4
		//IL_0697: Invalid comparison between F4 and I4
		//IL_03a0: Expected O, but got I4
		//IL_081b: Expected O, but got F4
		//IL_0457: Invalid comparison between F4 and I4
		//IL_03ae: Invalid comparison between I4 and F4
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Expected O, but got Unknown
		//IL_042a: Invalid comparison between F4 and O
		//IL_0b3b: Invalid comparison between F4 and I4
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Expected O, but got Unknown
		//IL_0725: Invalid comparison between F4 and O
		//IL_0ab4: Invalid comparison between F4 and I4
		//IL_06d2: Invalid comparison between F4 and I4
		//IL_08b8: Expected O, but got F4
		//IL_0a84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a89: Expected O, but got Unknown
		//IL_0a92: Invalid comparison between F4 and O
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Expected O, but got Unknown
		//IL_07c5: Invalid comparison between F4 and O
		//IL_049e: Expected O, but got I4
		//IL_0b64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b69: Expected Ref, but got Unknown
		//IL_0b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b99: Expected Ref, but got Unknown
		//IL_0772: Invalid comparison between F4 and I4
		//IL_04ac: Expected O, but got I4
		//IL_04ba: Invalid comparison between I4 and F4
		Func<Vector3, float> vector3H = Vector3H;
		ProCamera2D proCamera2D = base.ProCamera2D;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v6 @ rdi_v1 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Func<Vector3, float> vector3H2 = Vector3H;
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v408 @ rdi_v3 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		object obj = proCamera2D._003CTargetsMidPoint_003Ek__BackingField - proCamera2D2._003CPreviousTargetsMidPoint_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = obj & 0;
		Vector2 movementThreshold = MovementThreshold;
		float num = ((System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref movementThreshold) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2)) ? 0f : ((float)obj / deltaTime));
		Func<Vector3, float> vector3V = Vector3V;
		ProCamera2D proCamera2D3 = base.ProCamera2D;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v409 @ rdi_v4 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Func<Vector3, float> vector3V2 = Vector3V;
		ProCamera2D proCamera2D4 = base.ProCamera2D;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v410 @ rdi_v5 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		object obj3 = proCamera2D3._003CTargetsMidPoint_003Ek__BackingField - proCamera2D4._003CPreviousTargetsMidPoint_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = obj3 & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DForwardFocus)+74]");
		float num2 = ((0 > (nint)obj4) ? 0f : ((float)obj3 / deltaTime));
		object obj6;
		object obj7;
		object obj8;
		float num5;
		float num7;
		float num8;
		if (!Progressive)
		{
			if (MaintainInfluenceOnStop)
			{
				if (!_isFirstHorizontalCameraMovement)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj5 = num & 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
					{
						_isFirstHorizontalCameraMovement = true;
						obj6 = 1;
						goto IL_0382;
					}
				}
				float num3 = ((num < 0f) ? (-1f) : 1f);
				float num4 = ((_targetHVel < 0f) ? (-1f) : 1f);
				bool flag = num3 == num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851B393Ah\"");
				obj6 = 1;
				obj7 = 1;
				obj8 = 0;
				if (!flag)
				{
					goto IL_0382;
				}
				goto IL_0be1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj9 = num & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9))
			{
				num5 = 0f;
			}
			else
			{
				float num6 = ((!(0f > num)) ? RightFocus : (LeftFocus ^ -0f));
				ProCamera2D proCamera2D5 = base.ProCamera2D;
				num5 = (float)proCamera2D5._003CScreenSizeInWorldCoordinates_003Ek__BackingField * num6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj10 = num2 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10))
			{
				num7 = -0f;
				num8 = 0f;
			}
			else
			{
				float num9 = ((!(0f > num2)) ? TopFocus : (BottomFocus ^ -0f));
				ProCamera2D proCamera2D6 = base.ProCamera2D;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v38 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				num8 = 0f * num9;
				num7 = -0f;
			}
		}
		else
		{
			ProCamera2D proCamera2D7 = base.ProCamera2D;
			ProCamera2D proCamera2D8 = base.ProCamera2D;
			float num10 = (float)proCamera2D8._003CScreenSizeInWorldCoordinates_003Ek__BackingField * RightFocus;
			object obj11 = LeftFocus ^ -0f;
			num5 = SpeedMultiplier * num;
			float num11 = (float)obj11 * (float)proCamera2D7._003CScreenSizeInWorldCoordinates_003Ek__BackingField;
			if (!(num11 > num5))
			{
				if (num5 > num10)
				{
					num5 = num10;
				}
			}
			else
			{
				num5 = num11;
			}
			ProCamera2D proCamera2D9 = base.ProCamera2D;
			ProCamera2D proCamera2D10 = base.ProCamera2D;
			object obj12 = BottomFocus ^ -0f;
			float num12 = (float)obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v25 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			float num13 = num12 * 0f;
			num8 = SpeedMultiplier * num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rax_v26 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			float num14 = 0f * TopFocus;
			if (!(num13 > num8))
			{
				if (num8 > num14)
				{
					num8 = num14;
				}
			}
			else
			{
				num8 = num13;
			}
			bool flag2 = !MaintainInfluenceOnStop;
			num7 = -0f;
			if (!flag2)
			{
				if (!(num5 < 0f))
				{
					if (_hVel > num5)
					{
						goto IL_073c;
					}
					if (!(num5 < 0f))
					{
						goto IL_0707;
					}
				}
				if (!(num5 > _hVel))
				{
					goto IL_0707;
				}
				goto IL_073c;
			}
		}
		goto IL_09ca;
		IL_07a7:
		float num15 = num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj13 = num15 & 0;
		bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13);
		num7 = -0f;
		if (!flag3)
		{
			goto IL_07e5;
		}
		goto IL_09ca;
		IL_0be1:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj14 = num & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14))
		{
			obj8 = 0;
		}
		if (obj8 != null)
		{
			float num16 = ((!(0f > num)) ? RightFocus : (LeftFocus ^ -0f));
			ProCamera2D proCamera2D11 = base.ProCamera2D;
			float targetHVel = (float)proCamera2D11._003CScreenSizeInWorldCoordinates_003Ek__BackingField * num16;
			_targetHVel = targetHVel;
		}
		num5 = _targetHVel;
		if (!_isFirstVerticalCameraMovement)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj15 = num2 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15))
			{
				_isFirstVerticalCameraMovement = true;
				goto IL_0a74;
			}
		}
		float num17 = ((num2 < 0f) ? (-1f) : 1f);
		bool flag4 = !(_targetVVel < 0f);
		float num18 = 1f;
		if (!flag4)
		{
			num18 = -1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851B39E4h\"");
		if (num17 == num18)
		{
			obj7 = 0;
		}
		goto IL_0a74;
		IL_0b32:
		if (!(num8 < 0f))
		{
			if (_vVel > num8)
			{
				goto IL_07e5;
			}
			if (!(num8 < 0f))
			{
				goto IL_07a7;
			}
		}
		if (!(num8 > _vVel))
		{
			goto IL_07a7;
		}
		goto IL_07e5;
		IL_0707:
		float num19 = num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj16 = num19 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16))
		{
			goto IL_073c;
		}
		goto IL_0b32;
		IL_073c:
		num5 = _hVel;
		goto IL_0b32;
		IL_09ca:
		ProCamera2D proCamera2D12 = base.ProCamera2D;
		ProCamera2D proCamera2D13 = base.ProCamera2D;
		object obj17 = LeftFocus ^ num7;
		float num20 = (float)obj17 * (float)proCamera2D12._003CScreenSizeInWorldCoordinates_003Ek__BackingField;
		float num21 = (float)proCamera2D13._003CScreenSizeInWorldCoordinates_003Ek__BackingField * RightFocus;
		if (!(num20 > num5))
		{
			if (num5 > num21)
			{
				num5 = num21;
			}
		}
		else
		{
			num5 = num20;
		}
		ProCamera2D proCamera2D14 = base.ProCamera2D;
		ProCamera2D proCamera2D15 = base.ProCamera2D;
		object obj18 = BottomFocus ^ num7;
		float num22 = (float)obj18;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v19 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
		float num23 = num22 * 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v20 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
		float num24 = 0f * TopFocus;
		if (!(num23 > num8))
		{
			if (num8 > num24)
			{
				num8 = num24;
			}
		}
		else
		{
			num8 = num23;
		}
		float maxSpeed = default(float);
		float deltaTime2 = default(float);
		float hVel = Mathf.SmoothDamp(_hVel, num5, ref *(float*)(this + 140), TransitionSmoothness, maxSpeed, deltaTime2);
		ref float currentVelocity = ref *(float*)(this + 148);
		_hVel = hVel;
		float vVel = Mathf.SmoothDamp(_vVel, num8, ref currentVelocity, TransitionSmoothness, maxSpeed, deltaTime2);
		_vVel = vVel;
		ProCamera2D proCamera2D16 = base.ProCamera2D;
		Vector2 influence = default(Vector2);
		proCamera2D16.ApplyInfluence(influence);
		return;
		IL_0382:
		obj7 = obj6;
		obj8 = obj6;
		goto IL_0be1;
		IL_07e5:
		num8 = _vVel;
		num7 = -0f;
		goto IL_09ca;
		IL_0a74:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj19 = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj19))
		{
			obj7 = 0;
		}
		if (obj7 != null)
		{
			float num25 = ((!(0f > num2)) ? TopFocus : (BottomFocus ^ -0f));
			ProCamera2D proCamera2D17 = base.ProCamera2D;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rax_v31 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			float targetVVel = 0f * num25;
			_targetVVel = targetVVel;
		}
		num8 = _targetVVel;
		num7 = -0f;
		goto IL_09ca;
	}

	public ProCamera2DForwardFocus()
	{
		//IL_0041: Expected I, but got O
		//IL_00b3: Expected I, but got O
		Progressive = true;
		SpeedMultiplier = 1f;
		TransitionSmoothness = 0.5f;
		MaintainInfluenceOnStop = true;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		MovementThreshold = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		LeftFocus = 0.25f;
		RightFocus = 0.25f;
		TopFocus = 0.25f;
		BottomFocus = 0.25f;
		_prmOrder = 2000;
		nint num3 = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
