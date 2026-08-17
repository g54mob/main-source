using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DCameraWindow : BasePC2D, IPositionDeltaChanger
{
	public static string ExtensionName = "Camera Window";

	public Rect CameraWindowRect;

	private Rect _cameraWindowRectInWorldCoords;

	public bool IsRelativeSizeAndPosition;

	private int _pdcOrder;

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

	protected override void Awake()
	{
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.AddPositionDeltaChanger(this);
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._positionDeltaChangers).Remove((object)this);
		}
	}

	public unsafe Vector3 AdjustDelta(float deltaTime, Vector3 originalDelta)
	{
		//IL_0008: Expected O, but got Ref
		//IL_06f8: Expected O, but got I4
		//IL_06be: Expected native int or pointer, but got O
		//IL_0ac5: Expected native int or pointer, but got O
		//IL_0062: Expected O, but got Ref
		//IL_0092: Expected O, but got F4
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00e2: Invalid comparison between F4 and O
		//IL_012f: Invalid comparison between O and F4
		//IL_013e: Expected F4, but got I4
		//IL_03a9: Expected O, but got I
		//IL_03b6: Invalid comparison between F4 and O
		//IL_084e: Expected O, but got Ref
		//IL_02e2: Expected O, but got Ref
		//IL_02f2: Expected O, but got I
		//IL_0302: Expected O, but got I
		//IL_0404: Expected O, but got I
		//IL_0419: Invalid comparison between I and F4
		//IL_0428: Expected F4, but got I4
		//IL_0777: Expected O, but got Ref
		//IL_0379: Expected F4, but got O
		//IL_0678: Expected O, but got Ref
		//IL_0692: Expected F4, but got I
		//IL_069f: Expected F4, but got O
		//IL_069a: Expected native int or pointer, but got O
		//IL_0a23: Expected O, but got Ref
		//IL_01c6: Expected O, but got Ref
		//IL_01d6: Expected O, but got I
		//IL_01e6: Expected O, but got I
		//IL_05c4: Expected O, but got I
		//IL_05d2: Expected O, but got Ref
		//IL_05e2: Expected O, but got I
		//IL_025d: Expected F4, but got O
		//IL_094e: Expected O, but got Ref
		//IL_0665: Expected F4, but got I
		//IL_04aa: Expected O, but got I
		//IL_04b8: Expected O, but got Ref
		//IL_04c8: Expected O, but got I
		//IL_054b: Expected F4, but got I
		//IL_004f->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_00b9->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_0292->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_011b->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_02c5->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_0737->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_0176->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_087d->IL06c8: Incompatible stack heights: 2 vs 0
		//IL_0572->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_01a9->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_03ef->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_05a5->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_08ea->IL0715: Incompatible stack heights: 2 vs 1
		//IL_0367->IL06c8: Incompatible stack heights: 2 vs 0
		//IL_090e->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_0458->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_07a6->IL06c8: Incompatible stack heights: 2 vs 0
		//IL_0a52->IL06c8: Incompatible stack heights: 2 vs 0
		//IL_048b->IL06c8: Incompatible stack heights: 1 vs 0
		//IL_0813->IL0715: Incompatible stack heights: 2 vs 1
		//IL_024b->IL06c8: Incompatible stack heights: 2 vs 0
		//IL_0abd->IL08ea: Incompatible stack heights: 2 vs 1
		//IL_0650->IL06c8: Incompatible stack heights: 2 vs 0
		//IL_097d->IL06c8: Incompatible stack heights: 2 vs 0
		//IL_09e8->IL08ea: Incompatible stack heights: 2 vs 1
		//IL_0536->IL06c8: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float z;
		Vector3 vector = default(Vector3);
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			object obj3 = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
			if (obj3 == null)
			{
				z = originalDelta.z;
				((Vector3*)(nint)vector)->x = originalDelta.x;
				goto IL_0abd;
			}
			ProCamera2D proCamera2D = base.ProCamera2D;
			if ((object)proCamera2D != null)
			{
				Rect rectNormalized = (Rect)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
				_ = CameraWindowRect;
				Vector2 vector2 = default(Vector2);
				Transform transf = default(Transform);
				bool isRelative = default(bool);
				_cameraWindowRectInWorldCoords = (Rect)GetRectAroundTransf(rectNormalized, vector2, transf, isRelative).m_XMin;
				ProCamera2D proCamera2D2 = base.ProCamera2D;
				if ((object)proCamera2D2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCameraWindow)+78]");
					object obj4 = 0 + _cameraWindowRectInWorldCoords;
					float cameraTargetHorizontalPositionSmoothed = proCamera2D2._cameraTargetHorizontalPositionSmoothed;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)cameraTargetHorizontalPositionSmoothed) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
					{
						ProCamera2D proCamera2D3 = base.ProCamera2D;
						if ((object)proCamera2D3 != null)
						{
							bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref _cameraWindowRectInWorldCoords) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)proCamera2D3._cameraTargetHorizontalPositionSmoothed);
							float num = 0f;
							Vector2 vector3 = vector2;
							if (flag2)
							{
								goto IL_0715;
							}
							ProCamera2D proCamera2D4 = base.ProCamera2D;
							if ((object)proCamera2D4 != null)
							{
								object obj5 = _transform;
								Func<Vector3, float> vector3H = Vector3H;
								if ((object)_transform != null)
								{
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v20 (System.Object)+10]");
									bool flag3 = (nint)0 == 0;
									object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v20 (System.Object)+10]");
									Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj6);
									if (Vector3H != null)
									{
										object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rsi_v20 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
										vector3 = (Vector2)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rsi_v20 (System.Func`2<UnityEngine.Vector3, System.Single>)+28]");
										rectNormalized = (Rect)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v256 @ rsi_v20 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
										float num2;
										if (IsRelativeSizeAndPosition)
										{
											ProCamera2D proCamera2D5 = base.ProCamera2D;
											if ((object)proCamera2D5 == null)
											{
												goto IL_06c8;
											}
											num2 = (float)proCamera2D5._003CScreenSizeInWorldCoordinates_003Ek__BackingField;
										}
										else
										{
											num2 = 1f;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCameraWindow)+78]");
										float num3 = 0f * 0.5f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
										float num4 = 0f - num3;
										float num5 = (float)CameraWindowRect * num2;
										float num6 = num5 + num4;
										num = proCamera2D4._cameraTargetHorizontalPositionSmoothed - num6;
										goto IL_0715;
									}
								}
							}
						}
					}
					else
					{
						ProCamera2D proCamera2D6 = base.ProCamera2D;
						if ((object)proCamera2D6 != null)
						{
							object obj8 = _transform;
							Func<Vector3, float> vector3H2 = Vector3H;
							if ((object)_transform != null)
							{
								_ = 0;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v19 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v19 (System.Object)+10]");
								Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj9);
								if (Vector3H != null)
								{
									object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rsi_v19 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
									Vector2 vector3 = (Vector2)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rsi_v19 (System.Func`2<UnityEngine.Vector3, System.Single>)+28]");
									rectNormalized = (Rect)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v257 @ rsi_v19 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									float num7;
									if (IsRelativeSizeAndPosition)
									{
										ProCamera2D proCamera2D7 = base.ProCamera2D;
										if ((object)proCamera2D7 == null)
										{
											goto IL_06c8;
										}
										num7 = (float)proCamera2D7._003CScreenSizeInWorldCoordinates_003Ek__BackingField;
									}
									else
									{
										num7 = 1f;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCameraWindow)+78]");
									float num8 = 0f * 0.5f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
									float num9 = 0f + num8;
									float num10 = (float)CameraWindowRect * num7;
									float num11 = num10 + num9;
									float num = proCamera2D6._cameraTargetHorizontalPositionSmoothed - num11;
									goto IL_0715;
								}
							}
						}
					}
				}
			}
		}
		goto IL_06c8;
		IL_06c8:
		throw new NullReferenceException();
		IL_0abd:
		((Vector3*)(nint)vector)->z = z;
		return vector;
		IL_08ea:
		Func<float, float, Vector3> vectorHV = VectorHV;
		if (VectorHV == null)
		{
			goto IL_06c8;
		}
		object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v182 @ rdx_v32 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1396 @ rax_v43+8]");
		z = 0f;
		object obj12 = default(object);
		((Vector3*)(nint)vector)->x = (float)obj12;
		goto IL_0abd;
		IL_0715:
		ProCamera2D proCamera2D8 = base.ProCamera2D;
		if ((object)proCamera2D8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCameraWindow)+7C]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCameraWindow)+74]");
			object obj13 = num12 + 0;
			float cameraTargetVerticalPositionSmoothed = proCamera2D8._cameraTargetVerticalPositionSmoothed;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)cameraTargetVerticalPositionSmoothed) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
			{
				ProCamera2D proCamera2D9 = base.ProCamera2D;
				if ((object)proCamera2D9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCameraWindow)+74]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCameraWindow)+74]");
					bool flag5 = 0f < proCamera2D9._cameraTargetVerticalPositionSmoothed;
					float num13 = 0f;
					if (flag5)
					{
						goto IL_08ea;
					}
					ProCamera2D proCamera2D10 = base.ProCamera2D;
					if ((object)proCamera2D10 != null)
					{
						object obj15 = _transform;
						Func<Vector3, float> vector3V = Vector3V;
						if ((object)_transform != null)
						{
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdi_v18 (System.Object)+10]");
							bool flag6 = (nint)0 == 0;
							object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdi_v18 (System.Object)+10]");
							Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj16);
							if (Vector3V != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
								obj14 = 0;
								object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rsi_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
								Vector2 vector3 = (Vector2)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v259 @ rsi_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
								bool flag7 = !IsRelativeSizeAndPosition;
								float num14 = 1f;
								if (!flag7)
								{
									ProCamera2D proCamera2D11 = base.ProCamera2D;
									if ((object)proCamera2D11 == null)
									{
										goto IL_06c8;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v67 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
									num14 = 0f;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCameraWindow)+7C]");
								float num15 = 0f * 0.5f;
								float num16 = (float)obj14 - num15;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCameraWindow)+64]");
								float num17 = 0f * num14;
								float num18 = num17 + num16;
								num13 = proCamera2D10._cameraTargetVerticalPositionSmoothed - num18;
								goto IL_08ea;
							}
						}
					}
				}
			}
			else
			{
				ProCamera2D proCamera2D12 = base.ProCamera2D;
				if ((object)proCamera2D12 != null)
				{
					object obj18 = _transform;
					Func<Vector3, float> vector3V2 = Vector3V;
					if ((object)_transform != null)
					{
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdi_v17 (System.Object)+10]");
						bool flag8 = (nint)0 == 0;
						object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdi_v17 (System.Object)+10]");
						Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj19);
						if (Vector3V != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
							object obj14 = 0;
							object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rsi_v17 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
							Vector2 vector3 = (Vector2)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v260 @ rsi_v17 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							bool flag9 = !IsRelativeSizeAndPosition;
							float num19 = 1f;
							if (!flag9)
							{
								ProCamera2D proCamera2D13 = base.ProCamera2D;
								if ((object)proCamera2D13 == null)
								{
									goto IL_06c8;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v54 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
								num19 = 0f;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCameraWindow)+7C]");
							float num20 = 0f * 0.5f;
							float num21 = (float)obj14 + num20;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCameraWindow)+64]");
							float num22 = 0f * num19;
							float num23 = num22 + num21;
							float num13 = proCamera2D12._cameraTargetVerticalPositionSmoothed - num23;
							goto IL_08ea;
						}
					}
				}
			}
		}
		goto IL_06c8;
	}

	private unsafe Rect GetRectAroundTransf(Rect rectNormalized, Vector2 rectSize, Transform transf, bool isRelative)
	{
		//IL_0154: Expected I, but got O
		//IL_0087: Expected F4, but got O
		//IL_0200: Expected native int or pointer, but got O
		//IL_021c: Expected native int or pointer, but got O
		//IL_0229: Expected native int or pointer, but got O
		//IL_0236: Expected native int or pointer, but got O
		object obj = default(object);
		Vector2 vector;
		if (obj != null)
		{
			vector = rectSize;
		}
		else
		{
			nint num = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v35 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num2 = 0;
			Vector2 vector2 = default(Vector2);
			vector = vector2;
		}
		float num3 = (float)vector * rectNormalized.m_Width;
		object obj2 = default(object);
		float num4 = (float)obj2 * rectNormalized.m_Height;
		Func<Vector3, float> vector3H = Vector3H;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_28 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_28 (System.Object)+10]");
		Transform.get_localPosition_Injected((IntPtr)0, out Vector3 ret);
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v102 @ r14_v1 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		bool flag2 = obj == null;
		float num5 = num3 * 0.5f;
		float num6 = (float)ret - num5;
		float num7 = (flag2 ? 1f : ((float)rectSize));
		Func<Vector3, float> vector3V = Vector3V;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_28 (System.Object)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_28 (System.Object)+10]");
		Transform.get_localPosition_Injected((IntPtr)0, out ret);
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v149 @ r14_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		bool flag4 = obj == null;
		float num8 = num4 * 0.5f;
		float num9 = rectNormalized.m_XMin * num7;
		float num10 = (float)ret - num8;
		float num11 = 1f;
		if (!flag4)
		{
			float num12 = default(float);
			num11 = num12;
		}
		float xMin = num9 + num6;
		float num13 = rectNormalized.m_YMin * num11;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = xMin;
		float yMin = num13 + num10;
		((Rect*)(nint)rect)->m_Width = num3;
		((Rect*)(nint)rect)->m_Height = num4;
		((Rect*)(nint)rect)->m_YMin = yMin;
		return rect;
	}

	public ProCamera2DCameraWindow()
	{
		//IL_0012: Expected O, but got I
		//IL_0032: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11D70]");
		CameraWindowRect = (Rect)0;
		IsRelativeSizeAndPosition = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
