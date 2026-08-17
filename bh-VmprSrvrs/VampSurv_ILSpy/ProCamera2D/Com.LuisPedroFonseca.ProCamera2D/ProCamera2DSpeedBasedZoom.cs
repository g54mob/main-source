using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DSpeedBasedZoom : BasePC2D, ISizeDeltaChanger
{
	public static string ExtensionName = "Speed Based Zoom";

	public float CamVelocityForZoomOut;

	public float CamVelocityForZoomIn;

	public float ZoomInSmoothness;

	public float ZoomOutSmoothness;

	public float MaxZoomInAmount;

	public float MaxZoomOutAmount;

	private float _zoomVelocity;

	private float _initialCamSize;

	private float _previousCamSize;

	private Vector3 _previousCameraPosition;

	public float CurrentVelocity;

	private int _sdcOrder;

	public int SDCOrder
	{
		get
		{
			return _sdcOrder;
		}
		set
		{
			_sdcOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v10 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			float num = 0f * 0.5f;
			Func<float, float, Vector3> vectorHV = VectorHV;
			Func<Vector3, float> vector3H = Vector3H;
			_initialCamSize = num;
			_previousCamSize = num;
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			Vector3 localPosition = proCamera2D3.LocalPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v272 @ rdi_v5 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3V = Vector3V;
			ProCamera2D proCamera2D4 = base.ProCamera2D;
			Vector3 localPosition2 = proCamera2D4.LocalPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v287 @ rdi_v6 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v271 @ rsi_v3 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
			object previousCameraPosition = default(object);
			_previousCameraPosition = (Vector3)previousCameraPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rax_v22+8]");
			_ = 0;
			ProCamera2D proCamera2D5 = base.ProCamera2D;
			List<object> sizeDeltaChangers = (List<object>)(object)proCamera2D5._sizeDeltaChangers;
			int version = sizeDeltaChangers._version + 1;
			sizeDeltaChangers._version = version;
			object[] items = sizeDeltaChangers._items;
			if (sizeDeltaChangers._size >= items.Length)
			{
				sizeDeltaChangers.AddWithResize((object)this);
				return;
			}
			int size = sizeDeltaChangers._size + 1;
			sizeDeltaChangers._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._sizeDeltaChangers).Remove((object)this);
		}
	}

	public unsafe float AdjustSize(float deltaTime, float originalDelta)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0647: Expected O, but got I4
		//IL_0089: Invalid comparison between F4 and I
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_01ff: Expected O, but got I
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Expected O, but got Unknown
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_04ef: Invalid comparison between I4 and F4
		//IL_053a: Expected F4, but got I4
		//IL_0715: Unknown result type (might be due to invalid IL or missing references)
		//IL_071a: Expected F4, but got Unknown
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ae: Expected Ref, but got Unknown
		//IL_05da: Expected F4, but got I
		object obj2 = default(object);
		object obj = obj2 - 95;
		if ((object)this != null)
		{
			if (((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(this);
			}
			else
			{
				object obj3 = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
				if (obj3 == null)
				{
					return originalDelta;
				}
				ProCamera2D proCamera2D = base.ProCamera2D;
				if ((object)proCamera2D != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851CA8E6h\"");
					float previousCamSize = _previousCamSize;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rax_v13 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
					if (previousCamSize == 0f)
					{
						_zoomVelocity = 0f;
					}
					Func<float, float, Vector3> vectorHV = VectorHV;
					Func<Vector3, float> vector3H = Vector3H;
					_ = _previousCameraPosition;
					ProCamera2D proCamera2D2 = base.ProCamera2D;
					if ((object)proCamera2D2 != null)
					{
						Vector3 localPosition = proCamera2D2.LocalPosition;
						if (Vector3H != null)
						{
							object obj4 = obj - 25;
							_ = localPosition.x;
							_ = localPosition.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v160 @ rdi_v6 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							Func<Vector3, float> vector3V = Vector3V;
							ProCamera2D proCamera2D3 = base.ProCamera2D;
							if ((object)proCamera2D3 != null)
							{
								Vector3 localPosition2 = proCamera2D3.LocalPosition;
								if (Vector3V != null)
								{
									object obj5 = obj - 25;
									_ = localPosition2.x;
									_ = localPosition2.z;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v161 @ rdi_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									if (VectorHV != null)
									{
										object obj6 = obj + 7;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v82 @ rsi_v5 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-5]");
										object obj8 = default(object);
										object obj7 = 0 - obj8;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DSpeedBasedZoom)+8C]");
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v23+8]");
										object obj9 = num - 0;
										object obj10 = obj - 9;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A8670");
										Func<float, float, Vector3> vectorHV2 = VectorHV;
										Func<Vector3, float> vector3H2 = Vector3H;
										float currentVelocity = (float)obj8 / deltaTime;
										CurrentVelocity = currentVelocity;
										ProCamera2D proCamera2D4 = base.ProCamera2D;
										if ((object)proCamera2D4 != null)
										{
											Vector3 localPosition3 = proCamera2D4.LocalPosition;
											if (Vector3H != null)
											{
												object obj11 = obj - 9;
												_ = localPosition3.x;
												_ = localPosition3.z;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v162 @ rdi_v8 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
												Func<Vector3, float> vector3V2 = Vector3V;
												ProCamera2D proCamera2D5 = base.ProCamera2D;
												if ((object)proCamera2D5 != null)
												{
													Vector3 localPosition4 = proCamera2D5.LocalPosition;
													if (Vector3V != null)
													{
														object obj12 = obj - 9;
														_ = localPosition4.x;
														_ = localPosition4.z;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v163 @ rdi_v9 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
														if (VectorHV != null)
														{
															object obj13 = obj + 7;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v83 @ rsi_v6 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
															object previousCameraPosition = default(object);
															_previousCameraPosition = (Vector3)previousCameraPosition;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rax_v34+8]");
															_ = 0;
															ProCamera2D proCamera2D6 = base.ProCamera2D;
															if ((object)proCamera2D6 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v35 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
																float num2 = 0f * 0.5f;
																float num9;
																if (!(CurrentVelocity > CamVelocityForZoomIn))
																{
																	float num3 = CurrentVelocity / CamVelocityForZoomIn;
																	float num4 = 1f - num3;
																	float num5 = num4 * 0.5f;
																	float num6 = num5 + 0.5f;
																	if (!(0.5f > num6))
																	{
																		if (num6 > 1f)
																		{
																			num6 = 1f;
																		}
																	}
																	else
																	{
																		num6 = 0.5f;
																	}
																	float num7 = num6 * MaxZoomInAmount;
																	float num8 = _initialCamSize / num7;
																	bool flag = !(num2 > num8);
																	num9 = num2;
																	if (!flag)
																	{
																		num9 = num8;
																	}
																}
																else
																{
																	float num10 = CurrentVelocity - CamVelocityForZoomIn;
																	float num11 = CamVelocityForZoomOut - CamVelocityForZoomIn;
																	float num12 = num10 / num11;
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
																	float num13 = MaxZoomOutAmount + 1f;
																	float num14 = num13 - 1f;
																	float num15 = num14 * _initialCamSize;
																	float num16 = num15 * num12;
																	bool flag2 = !(num16 > num2);
																	num9 = num2;
																	if (!flag2)
																	{
																		num9 = num16;
																	}
																}
																float num17 = num2 - num9;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
																float num18 = num17 & 0;
																if (num18 > 0.0001f)
																{
																	float smoothTime = ((!(num2 > num9)) ? ZoomOutSmoothness : ZoomInSmoothness);
																	float maxSpeed = default(float);
																	float deltaTime2 = default(float);
																	float num19 = Mathf.SmoothDamp(num2, num9, ref *(float*)(this + 120), smoothTime, maxSpeed, deltaTime2);
																	num9 = num19;
																}
																ProCamera2D proCamera2D7 = base.ProCamera2D;
																if ((object)proCamera2D7 != null)
																{
																	ProCamera2D proCamera2D8 = base.ProCamera2D;
																	if ((object)proCamera2D8 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v36 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
																		float num20 = 0f * 0.5f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v37 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
																		_previousCamSize = 0f;
																		float num21 = num9 - num20;
																		return num21 + originalDelta;
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void OnReset()
	{
		Func<float, float, Vector3> vectorHV = VectorHV;
		Func<Vector3, float> vector3H = Vector3H;
		_previousCamSize = _initialCamSize;
		ProCamera2D proCamera2D = base.ProCamera2D;
		Vector3 localPosition = proCamera2D.LocalPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ rdi_v1 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Func<Vector3, float> vector3V = Vector3V;
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		Vector3 localPosition2 = proCamera2D2.LocalPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v108 @ rdi_v3 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v9 @ rsi_v1 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
		object previousCameraPosition = default(object);
		_previousCameraPosition = (Vector3)previousCameraPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v13+8]");
		_ = 0;
		_zoomVelocity = 0f;
	}

	public ProCamera2DSpeedBasedZoom()
	{
		//IL_0062: Expected I, but got O
		CamVelocityForZoomOut = 5f;
		CamVelocityForZoomIn = 2f;
		ZoomInSmoothness = 1f;
		ZoomOutSmoothness = 1f;
		MaxZoomInAmount = 2f;
		MaxZoomOutAmount = 2f;
		_sdcOrder = 1000;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
