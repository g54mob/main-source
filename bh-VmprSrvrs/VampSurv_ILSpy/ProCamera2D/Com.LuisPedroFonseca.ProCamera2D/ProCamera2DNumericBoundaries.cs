using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DNumericBoundaries : BasePC2D, IPositionDeltaChanger, ISizeOverrider
{
	public static string ExtensionName = "Numeric Boundaries";

	public Action OnBoundariesTransitionStarted;

	public Action OnBoundariesTransitionFinished;

	public bool UseNumericBoundaries;

	public bool UseTopBoundary;

	public float TopBoundary;

	public float TargetTopBoundary;

	public bool UseBottomBoundary;

	public float BottomBoundary;

	public float TargetBottomBoundary;

	public bool UseLeftBoundary;

	public float LeftBoundary;

	public float TargetLeftBoundary;

	public bool UseRightBoundary;

	public float RightBoundary;

	public float TargetRightBoundary;

	public bool IsCameraPositionHorizontallyBounded;

	public bool IsCameraPositionVerticallyBounded;

	public Coroutine TopBoundaryAnimRoutine;

	public Coroutine BottomBoundaryAnimRoutine;

	public Coroutine LeftBoundaryAnimRoutine;

	public Coroutine RightBoundaryAnimRoutine;

	public ProCamera2DTriggerBoundaries CurrentBoundariesTrigger;

	public Coroutine MoveCameraToTargetRoutine;

	public bool HasFiredTransitionStarted;

	public bool HasFiredTransitionFinished;

	public bool UseSoftBoundaries;

	public float Softness;

	public float SoftAreaSize;

	private float _smoothnessVelX;

	private float _smoothnessVelY;

	private int _pdcOrder;

	private int _soOrder;

	public unsafe NumericBoundariesSettings Settings
	{
		get
		{
			//IL_0009: Expected native int or pointer, but got O
			//IL_0017: Expected native int or pointer, but got O
			//IL_0026: Expected native int or pointer, but got O
			//IL_0035: Expected native int or pointer, but got O
			//IL_0044: Expected native int or pointer, but got O
			//IL_0053: Expected native int or pointer, but got O
			//IL_0062: Expected native int or pointer, but got O
			//IL_0071: Expected native int or pointer, but got O
			//IL_0080: Expected native int or pointer, but got O
			//IL_008f: Expected native int or pointer, but got O
			//IL_009e: Expected native int or pointer, but got O
			NumericBoundariesSettings numericBoundariesSettings = default(NumericBoundariesSettings);
			((NumericBoundariesSettings*)(nint)numericBoundariesSettings)->UseNumericBoundaries = false;
			((NumericBoundariesSettings*)(nint)numericBoundariesSettings)->UseLeftBoundary = false;
			((NumericBoundariesSettings*)(nint)numericBoundariesSettings)->UseNumericBoundaries = UseNumericBoundaries;
			((NumericBoundariesSettings*)(nint)numericBoundariesSettings)->UseTopBoundary = UseTopBoundary;
			((NumericBoundariesSettings*)(nint)numericBoundariesSettings)->TopBoundary = TopBoundary;
			((NumericBoundariesSettings*)(nint)numericBoundariesSettings)->UseBottomBoundary = UseBottomBoundary;
			((NumericBoundariesSettings*)(nint)numericBoundariesSettings)->BottomBoundary = BottomBoundary;
			((NumericBoundariesSettings*)(nint)numericBoundariesSettings)->UseLeftBoundary = UseLeftBoundary;
			((NumericBoundariesSettings*)(nint)numericBoundariesSettings)->LeftBoundary = LeftBoundary;
			((NumericBoundariesSettings*)(nint)numericBoundariesSettings)->UseRightBoundary = UseRightBoundary;
			((NumericBoundariesSettings*)(nint)numericBoundariesSettings)->RightBoundary = RightBoundary;
			return numericBoundariesSettings;
		}
		set
		{
			UseNumericBoundaries = value.UseNumericBoundaries;
			UseTopBoundary = value.UseTopBoundary;
			TopBoundary = value.TopBoundary;
			UseBottomBoundary = value.UseBottomBoundary;
			BottomBoundary = value.BottomBoundary;
			UseLeftBoundary = value.UseLeftBoundary;
			LeftBoundary = value.LeftBoundary;
			UseRightBoundary = value.UseRightBoundary;
			RightBoundary = value.RightBoundary;
		}
	}

	public int PDCOrder
	{
		get
		{
			return _pdcOrder;
		}
		set
		{
			_pdcOrder = value;
		}
	}

	public int SOOrder
	{
		get
		{
			return _soOrder;
		}
		set
		{
			_soOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.AddPositionDeltaChanger(this);
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		proCamera2D2.AddSizeOverrider(this);
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._positionDeltaChangers).Remove((object)this);
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			bool flag2 = ((List<object>)(object)proCamera2D3._sizeOverriders).Remove((object)this);
		}
	}

	public unsafe Vector3 AdjustDelta(float deltaTime, Vector3 originalDelta)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0ed1: Expected O, but got I4
		//IL_0eb8: Expected native int or pointer, but got O
		//IL_1110: Expected native int or pointer, but got O
		//IL_010f: Expected O, but got Ref
		//IL_014a: Expected O, but got Ref
		//IL_01ba: Expected O, but got Ref
		//IL_01f5: Expected O, but got Ref
		//IL_02d4: Expected O, but got I4
		//IL_030d: Expected O, but got I4
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_0338: Invalid comparison between O and F4
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_0869: Expected O, but got Unknown
		//IL_0880: Invalid comparison between O and F4
		//IL_0dc2: Expected O, but got Ref
		//IL_03a4: Expected O, but got Ref
		//IL_03d0: Invalid comparison between I4 and F4
		//IL_0649: Expected O, but got Ref
		//IL_0675: Invalid comparison between F4 and I4
		//IL_0e19: Expected O, but got Ref
		//IL_08ec: Expected O, but got Ref
		//IL_0918: Invalid comparison between I4 and F4
		//IL_0e72: Expected O, but got Ref
		//IL_0e8c: Expected F4, but got I
		//IL_0e99: Expected F4, but got O
		//IL_0e94: Expected native int or pointer, but got O
		//IL_0b91: Expected O, but got Ref
		//IL_0bbd: Invalid comparison between F4 and I4
		//IL_0471: Expected O, but got Ref
		//IL_0716: Expected O, but got Ref
		//IL_09b9: Expected O, but got Ref
		//IL_0c5e: Expected O, but got Ref
		//IL_04ef: Expected O, but got Ref
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Expected Ref, but got Unknown
		//IL_0794: Expected O, but got Ref
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bd: Expected Ref, but got Unknown
		//IL_0a37: Expected O, but got Ref
		//IL_0a6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a71: Expected Ref, but got Unknown
		//IL_0cdc: Expected O, but got Ref
		//IL_0d00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d05: Expected Ref, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj3 = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		float z;
		Vector3 vector = default(Vector3);
		if (obj3 != null && UseNumericBoundaries)
		{
			IsCameraPositionHorizontallyBounded = false;
			ProCamera2D proCamera2D = base.ProCamera2D;
			proCamera2D.IsCameraPositionLeftBounded = false;
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			proCamera2D2.IsCameraPositionRightBounded = false;
			IsCameraPositionVerticallyBounded = false;
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			proCamera2D3.IsCameraPositionTopBounded = false;
			ProCamera2D proCamera2D4 = base.ProCamera2D;
			proCamera2D4.IsCameraPositionBottomBounded = false;
			Func<Vector3, float> vector3H = Vector3H;
			ProCamera2D proCamera2D5 = base.ProCamera2D;
			Vector3 localPosition = proCamera2D5.LocalPosition;
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
			_ = localPosition.x;
			_ = localPosition.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v290 @ rsi_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3H2 = Vector3H;
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
			_ = originalDelta.x;
			_ = originalDelta.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v356 @ rcx_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3V = Vector3V;
			float num = localPosition.x + localPosition.x;
			ProCamera2D proCamera2D6 = base.ProCamera2D;
			Vector3 localPosition2 = proCamera2D6.LocalPosition;
			object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
			_ = localPosition2.x;
			_ = localPosition2.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v291 @ rsi_v8 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3V2 = Vector3V;
			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
			float x = originalDelta.x;
			_ = originalDelta.x;
			_ = originalDelta.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v359 @ rcx_v23 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			float num2 = localPosition2.x + localPosition2.x;
			ProCamera2D proCamera2D7 = base.ProCamera2D;
			float num3 = (float)proCamera2D7._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 0.5f;
			ProCamera2D proCamera2D8 = base.ProCamera2D;
			bool flag2 = !UseSoftBoundaries;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rax_v32 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			float num4 = 0f * 0.5f;
			object obj8;
			if (!flag2)
			{
				ProCamera2D proCamera2D9 = base.ProCamera2D;
				obj8 = proCamera2D9._003CScreenSizeInWorldCoordinates_003Ek__BackingField * SoftAreaSize;
			}
			else
			{
				obj8 = 0;
			}
			object obj9;
			if (UseSoftBoundaries)
			{
				ProCamera2D proCamera2D10 = base.ProCamera2D;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v98 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				obj9 = 0 * SoftAreaSize;
			}
			else
			{
				obj9 = 0;
			}
			if (UseLeftBoundary)
			{
				object obj10 = obj8 + LeftBoundary;
				x = num - num3;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x))
				{
					if (!UseSoftBoundaries)
					{
						num = num3 + LeftBoundary;
					}
					else
					{
						Func<Vector3, float> vector3H3 = Vector3H;
						object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
						_ = originalDelta.x;
						_ = originalDelta.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v364 @ rcx_v72 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						if (0f < originalDelta.x)
						{
							float num5 = LeftBoundary + num3;
							if (num5 < num)
							{
								num5 = num;
							}
							num = num5;
						}
						else
						{
							Func<Vector3, float> vector3H4 = Vector3H;
							ProCamera2D proCamera2D11 = base.ProCamera2D;
							Vector3 localPosition3 = proCamera2D11.LocalPosition;
							_ = localPosition3.x;
							_ = localPosition3.z;
							object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
							float num6 = LeftBoundary + num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v292 @ rsi_v20 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							if (num6 < localPosition3.x)
							{
								num6 = localPosition3.x;
							}
							float num7 = num3 + LeftBoundary;
							if (num7 < num)
							{
								num7 = num;
							}
							Func<Vector3, float> vector3H5 = Vector3H;
							ProCamera2D proCamera2D12 = base.ProCamera2D;
							Vector3 localPosition4 = proCamera2D12.LocalPosition;
							object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
							_ = localPosition4.x;
							_ = localPosition4.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v293 @ rsi_v21 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							float num8 = LeftBoundary + num3;
							ref float currentVelocity = ref *(float*)(this + 228);
							float num9 = num8 - localPosition4.x;
							float num10 = num9 + (float)obj8;
							float num11 = num10 / (float)obj8;
							float num12 = num11 * Softness;
							float num13 = Mathf.SmoothDamp(num6, num7, ref currentVelocity, num12);
							float num14 = num12;
							num = num13;
							x = num7;
						}
					}
					IsCameraPositionHorizontallyBounded = true;
					ProCamera2D proCamera2D13 = base.ProCamera2D;
					proCamera2D13.IsCameraPositionLeftBounded = true;
				}
			}
			if (UseRightBoundary)
			{
				x = num3 + num;
				float num15 = RightBoundary - (float)obj8;
				if (x > num15)
				{
					if (!UseSoftBoundaries)
					{
						num = RightBoundary - num3;
					}
					else
					{
						Func<Vector3, float> vector3H6 = Vector3H;
						object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
						_ = originalDelta.x;
						_ = originalDelta.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v370 @ rcx_v62 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						if (originalDelta.x < 0f)
						{
							float num16 = RightBoundary - num3;
							if (num16 > num)
							{
								num16 = num;
							}
							num = num16;
						}
						else
						{
							Func<Vector3, float> vector3H7 = Vector3H;
							ProCamera2D proCamera2D14 = base.ProCamera2D;
							Vector3 localPosition5 = proCamera2D14.LocalPosition;
							_ = localPosition5.x;
							_ = localPosition5.z;
							object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
							float num17 = RightBoundary - num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v296 @ rsi_v17 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							if (num17 > localPosition5.x)
							{
								num17 = localPosition5.x;
							}
							float num18 = RightBoundary - num3;
							if (num18 > num)
							{
								num18 = num;
							}
							Func<Vector3, float> vector3H8 = Vector3H;
							ProCamera2D proCamera2D15 = base.ProCamera2D;
							Vector3 localPosition6 = proCamera2D15.LocalPosition;
							object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
							_ = localPosition6.x;
							_ = localPosition6.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v297 @ rsi_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							ref float currentVelocity2 = ref *(float*)(this + 228);
							float num19 = RightBoundary - num3;
							float num20 = localPosition6.x - num19;
							float num21 = num20 + (float)obj8;
							float num22 = num21 / (float)obj8;
							float num23 = num22 * Softness;
							float num24 = Mathf.SmoothDamp(num17, num18, ref currentVelocity2, num23);
							float num14 = num23;
							num = num24;
							x = num18;
						}
					}
					IsCameraPositionHorizontallyBounded = true;
					ProCamera2D proCamera2D16 = base.ProCamera2D;
					proCamera2D16.IsCameraPositionRightBounded = true;
				}
			}
			if (UseBottomBoundary)
			{
				object obj17 = obj9 + BottomBoundary;
				x = num2 - num4;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj17) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x))
				{
					if (!UseSoftBoundaries)
					{
						num2 = num4 + BottomBoundary;
					}
					else
					{
						Func<Vector3, float> vector3V3 = Vector3V;
						object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
						_ = originalDelta.x;
						_ = originalDelta.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v376 @ rcx_v52 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						if (0f < originalDelta.x)
						{
							float num25 = BottomBoundary + num4;
							if (num25 < num2)
							{
								num25 = num2;
							}
							num2 = num25;
						}
						else
						{
							Func<Vector3, float> vector3V4 = Vector3V;
							ProCamera2D proCamera2D17 = base.ProCamera2D;
							Vector3 localPosition7 = proCamera2D17.LocalPosition;
							_ = localPosition7.x;
							_ = localPosition7.z;
							object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
							float num26 = BottomBoundary + num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v300 @ rsi_v14 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							if (num26 < localPosition7.x)
							{
								num26 = localPosition7.x;
							}
							float num27 = num4 + BottomBoundary;
							if (num27 < num2)
							{
								num27 = num2;
							}
							Func<Vector3, float> vector3V5 = Vector3V;
							ProCamera2D proCamera2D18 = base.ProCamera2D;
							Vector3 localPosition8 = proCamera2D18.LocalPosition;
							object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
							_ = localPosition8.x;
							_ = localPosition8.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v301 @ rsi_v15 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							float num28 = BottomBoundary + num4;
							ref float currentVelocity3 = ref *(float*)(this + 232);
							float num29 = num28 + (float)obj9;
							float num30 = num29 - localPosition8.x;
							float num31 = num30 / (float)obj8;
							float num32 = num31 * Softness;
							float num33 = Mathf.SmoothDamp(num26, num27, ref currentVelocity3, num32);
							float num14 = num32;
							x = num27;
							num2 = num33;
						}
					}
					IsCameraPositionVerticallyBounded = true;
					ProCamera2D proCamera2D19 = base.ProCamera2D;
					proCamera2D19.IsCameraPositionBottomBounded = true;
				}
			}
			if (UseTopBoundary)
			{
				x = num4 + num2;
				float num34 = TopBoundary - (float)obj9;
				if (x > num34)
				{
					if (!UseSoftBoundaries)
					{
						num2 = TopBoundary - num4;
					}
					else
					{
						Func<Vector3, float> vector3V6 = Vector3V;
						object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
						_ = originalDelta.x;
						_ = originalDelta.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v382 @ rcx_v42 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						if (originalDelta.x < 0f)
						{
							float num35 = TopBoundary - num4;
							if (num35 > num2)
							{
								num35 = num2;
							}
							num2 = num35;
						}
						else
						{
							Func<Vector3, float> vector3V7 = Vector3V;
							ProCamera2D proCamera2D20 = base.ProCamera2D;
							Vector3 localPosition9 = proCamera2D20.LocalPosition;
							_ = localPosition9.x;
							_ = localPosition9.z;
							object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
							float num36 = TopBoundary - num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v413 @ rdi_v11 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							if (num36 > localPosition9.x)
							{
								num36 = localPosition9.x;
							}
							float num37 = TopBoundary - num4;
							if (num37 > num2)
							{
								num37 = num2;
							}
							Func<Vector3, float> vector3V8 = Vector3V;
							ProCamera2D proCamera2D21 = base.ProCamera2D;
							Vector3 localPosition10 = proCamera2D21.LocalPosition;
							object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
							_ = localPosition10.x;
							_ = localPosition10.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v414 @ rdi_v12 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							ref float currentVelocity4 = ref *(float*)(this + 232);
							float num19 = TopBoundary - num4;
							float num38 = localPosition10.x - num19;
							float num39 = num38 + (float)obj9;
							float num40 = num39 / (float)obj8;
							float num41 = num40 * Softness;
							float num42 = Mathf.SmoothDamp(num36, num37, ref currentVelocity4, num41);
							float num14 = num41;
							x = num37;
							num2 = num42;
						}
					}
					IsCameraPositionVerticallyBounded = true;
					ProCamera2D proCamera2D22 = base.ProCamera2D;
					proCamera2D22.IsCameraPositionTopBounded = true;
				}
			}
			Func<float, float, Vector3> vectorHV = VectorHV;
			Func<Vector3, float> vector3H9 = Vector3H;
			ProCamera2D proCamera2D23 = base.ProCamera2D;
			Vector3 localPosition11 = proCamera2D23.LocalPosition;
			object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
			_ = localPosition11.x;
			_ = localPosition11.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v416 @ rdi_v8 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3V9 = Vector3V;
			ProCamera2D proCamera2D24 = base.ProCamera2D;
			Vector3 localPosition12 = proCamera2D24.LocalPosition;
			object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
			_ = localPosition12.x;
			_ = localPosition12.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v417 @ rdi_v9 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			float num43 = num2 - localPosition12.x;
			float num44 = num - localPosition11.x;
			object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v304 @ rsi_v12 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1710 @ rax_v48+8]");
			z = 0f;
			object obj27 = default(object);
			((Vector3*)(nint)vector)->x = (float)obj27;
		}
		else
		{
			z = originalDelta.z;
			((Vector3*)(nint)vector)->x = originalDelta.x;
		}
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	public float OverrideSize(float deltaTime, float originalSize)
	{
		//IL_0271: Expected O, but got I4
		//IL_00e2->IL0241: Incompatible stack heights: 1 vs 0
		//IL_0104->IL0241: Incompatible stack heights: 1 vs 0
		//IL_0182->IL0241: Incompatible stack heights: 1 vs 0
		//IL_01a4->IL0241: Incompatible stack heights: 1 vs 0
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
			bool flag2 = obj == null;
			float num = originalSize;
			if (!flag2)
			{
				bool flag3 = !UseNumericBoundaries;
				num = originalSize;
				if (!flag3)
				{
					bool flag4 = !UseRightBoundary;
					float num2 = RightBoundary - LeftBoundary;
					float num3 = TopBoundary - BottomBoundary;
					num = originalSize;
					if (!flag4)
					{
						bool flag5 = !UseLeftBoundary;
						num = originalSize;
						if (!flag5)
						{
							ProCamera2D proCamera2D = base.ProCamera2D;
							if ((object)proCamera2D == null || (object)proCamera2D.GameCamera == null)
							{
								goto IL_0241;
							}
							float aspect = proCamera2D.GameCamera.aspect;
							float num4 = aspect * originalSize;
							float num5 = num4 + num4;
							bool flag6 = !(num5 > num2);
							num = originalSize;
							if (!flag6)
							{
								ProCamera2D proCamera2D2 = base.ProCamera2D;
								if ((object)proCamera2D2 == null || (object)proCamera2D2.GameCamera == null)
								{
									goto IL_0241;
								}
								float aspect2 = proCamera2D2.GameCamera.aspect;
								float num6 = num2 / aspect2;
								num = num6 * 0.5f;
							}
						}
					}
					if (UseTopBoundary && UseBottomBoundary)
					{
						float num7 = num + num;
						if (num7 > num3)
						{
							num = num3 * 0.5f;
						}
					}
				}
			}
			return num;
		}
		goto IL_0241;
		IL_0241:
		throw new NullReferenceException();
	}

	public ProCamera2DNumericBoundaries()
	{
		//IL_008e: Expected I, but got O
		UseNumericBoundaries = true;
		TopBoundary = 10f;
		UseBottomBoundary = true;
		BottomBoundary = -10f;
		LeftBoundary = -10f;
		RightBoundary = 10f;
		UseSoftBoundaries = true;
		Softness = 0.5f;
		SoftAreaSize = 0.1f;
		_pdcOrder = 4000;
		_soOrder = 2000;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
