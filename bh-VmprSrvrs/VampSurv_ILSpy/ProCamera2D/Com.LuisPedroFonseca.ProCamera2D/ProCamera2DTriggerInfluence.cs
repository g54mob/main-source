using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DTriggerInfluence : BaseTrigger
{
	public enum TriggerInfluenceMode
	{
		BothAxis,
		HorizontalAxis,
		VerticalAxis
	}

	private sealed class _003CInsideTriggerRoutine_003Ed__13(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DTriggerInfluence _003C_003E4__this;

		private float _003CpreviousDistancePercentage_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_1062: Expected I4, but got I8
			//IL_001d: Expected O, but got I4
			//IL_0098: Expected I4, but got I8
			//IL_0065: Expected I4, but got I8
			//IL_05a5: Expected O, but got I
			//IL_060d: Expected O, but got I
			//IL_0680: Invalid comparison between F4 and I4
			//IL_08f3: Invalid comparison between F4 and I4
			//IL_1454: Unknown result type (might be due to invalid IL or missing references)
			//IL_1459: Expected Ref, but got Unknown
			//IL_147e: Expected F4, but got I
			//IL_06a7: Expected O, but got I
			//IL_070a: Expected O, but got I
			//IL_138f: Expected O, but got F4
			//IL_139a: Unknown result type (might be due to invalid IL or missing references)
			//IL_139f: Expected Ref, but got Unknown
			//IL_13bc: Expected O, but got Ref
			//IL_13bc: Expected O, but got Ref
			//IL_079e: Expected O, but got I4
			//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_07fd: Expected O, but got Unknown
			//IL_080d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0812: Expected O, but got Unknown
			//IL_0fc3: Expected O, but got I
			//IL_1233->IL1164: Incompatible stack heights: 1 vs 0
			//IL_01da->IL1164: Incompatible stack heights: 1 vs 0
			//IL_0208->IL116b: Incompatible stack heights: 1 vs 0
			//IL_1285->IL1164: Incompatible stack heights: 1 vs 0
			//IL_063a->IL1164: Incompatible stack heights: 1 vs 0
			//IL_12dd->IL1164: Incompatible stack heights: 2 vs 0
			//IL_06e1->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0939->IL1164: Incompatible stack heights: 2 vs 0
			//IL_14ed->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0965->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0de1->IL1164: Incompatible stack heights: 2 vs 0
			//IL_099e->IL1164: Incompatible stack heights: 2 vs 0
			//IL_132f->IL1164: Incompatible stack heights: 3 vs 0
			//IL_0e03->IL1164: Incompatible stack heights: 2 vs 0
			//IL_09c0->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0737->IL1164: Incompatible stack heights: 3 vs 0
			//IL_0e46->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0a03->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0e68->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0a25->IL1164: Incompatible stack heights: 2 vs 0
			//IL_1381->IL1164: Incompatible stack heights: 4 vs 0
			//IL_0e94->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0a68->IL1164: Incompatible stack heights: 2 vs 0
			//IL_076d->IL1164: Incompatible stack heights: 4 vs 0
			//IL_0ee4->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0a8a->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0f06->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0acd->IL1164: Incompatible stack heights: 2 vs 0
			//IL_13d8->IL1164: Incompatible stack heights: 4 vs 0
			//IL_0f49->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0aef->IL1164: Incompatible stack heights: 2 vs 0
			//IL_07c5->IL1164: Incompatible stack heights: 4 vs 0
			//IL_0f6b->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0b32->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0f97->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0b54->IL1164: Incompatible stack heights: 2 vs 0
			//IL_1404->IL1164: Incompatible stack heights: 5 vs 0
			//IL_0b97->IL1164: Incompatible stack heights: 2 vs 0
			//IL_143a->IL1164: Incompatible stack heights: 2 vs 0
			//IL_08de->IL1409: Incompatible stack heights: 5 vs 2
			//IL_0bb9->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0c76->IL1164: Incompatible stack heights: 2 vs 0
			//IL_1053->IL1510: Incompatible stack heights: 2 vs 0
			//IL_0c98->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0cdb->IL1164: Incompatible stack heights: 2 vs 0
			//IL_0cfd->IL1164: Incompatible stack heights: 2 vs 0
			object obj2 = default(object);
			object obj = (object)(&obj2);
			BasePC2D basePC2D = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			Vector3 ret;
			Vector3 vector = default(Vector3);
			if (!flag)
			{
				object obj3 = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj3 != 1)
					{
						goto IL_0048;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						goto IL_116b;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					_003CpreviousDistancePercentage_003E5__2 = 1f;
					if ((object)_003C_003E4__this != null)
					{
						Func<float, float, Vector3> vectorHV = basePC2D.VectorHV;
						Transform vector3H = (Transform)(object)basePC2D.Vector3H;
						ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D != null)
						{
							Transform transform = proCamera2D.transform;
							if ((object)transform != null)
							{
								if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
								{
									UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
								}
								else
								{
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
									if (basePC2D.Vector3H != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v471 @ r14_v29 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
										Transform vector3V = (Transform)(object)basePC2D.Vector3V;
										ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
										if ((object)proCamera2D2 != null)
										{
											Transform transform2 = proCamera2D2.transform;
											if ((object)transform2 != null)
											{
												bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
												if (basePC2D.Vector3V != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v446 @ rdi_v51 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
													if (basePC2D.VectorHV != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v532 @ r15_v26 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1701 @ rax_v194+8]");
														_ = 0;
														vector = ret;
														goto IL_116b;
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
			else
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					ProCamera2D proCamera2D3 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D3 != null)
					{
						WaitForFixedUpdate waitForFixedUpdate = ((proCamera2D3.UpdateType != UpdateType.FixedUpdate) ? null : ((!proCamera2D3.IgnoreTimeScale) ? proCamera2D3._waitForFixedUpdate : null));
						_003C_003E2__current = waitForFixedUpdate;
						_003C_003E1__state = 1;
						goto IL_1510;
					}
				}
			}
			goto IL_1164;
			IL_1409:
			float distanceToCenterPercentage;
			_003CpreviousDistancePercentage_003E5__2 = distanceToCenterPercentage;
			ProCamera2D proCamera2D4 = _003C_003E4__this.ProCamera2D;
			if ((object)proCamera2D4 == null)
			{
				goto IL_1164;
			}
			bool flag3 = proCamera2D4.UpdateType != UpdateType.FixedUpdate;
			Transform transform3;
			WaitForFixedUpdate waitForFixedUpdate2 = (WaitForFixedUpdate)(object)transform3;
			if (!flag3)
			{
				bool flag4 = proCamera2D4.IgnoreTimeScale;
				waitForFixedUpdate2 = (WaitForFixedUpdate)(object)transform3;
				if (!flag4)
				{
					waitForFixedUpdate2 = proCamera2D4._waitForFixedUpdate;
				}
			}
			_003C_003E2__current = waitForFixedUpdate2;
			_003C_003E1__state = 2;
			goto IL_1510;
			IL_1164:
			throw new NullReferenceException();
			IL_143f:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
			ref Vector2 currentVelocity = ref *(Vector2*)(_003C_003E4__this + 204);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B8]");
			Vector2 vector3 = default(Vector2);
			float num = default(float);
			float num2 = default(float);
			Vector2 vector2 = Vector2.SmoothDamp(vector3, vector3, ref currentVelocity, 0f, num, num2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
			bool flag5 = (nint)0 == 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+44]");
			_ = 0;
			if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
				if ((nint)0 == 2)
				{
					_ = 0;
				}
			}
			else
			{
				_ = 0;
			}
			ProCamera2D proCamera2D5 = _003C_003E4__this.ProCamera2D;
			if ((object)proCamera2D5 != null)
			{
				proCamera2D5.ApplyInfluence(vector3);
				Func<float, float, Vector3> vectorHV2 = basePC2D.VectorHV;
				Transform vector3H2 = (Transform)(object)basePC2D.Vector3H;
				ProCamera2D proCamera2D6 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D6 != null && basePC2D.Vector3H != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v479 @ r14_v22 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
					Transform vector3V2 = (Transform)(object)basePC2D.Vector3V;
					ProCamera2D proCamera2D7 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D7 != null && basePC2D.Vector3V != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v480 @ r14_v23 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
						if (basePC2D.VectorHV != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v538 @ r15_v22 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
							Func<float, float, Vector3> vectorHV3 = basePC2D.VectorHV;
							Transform vector3H3 = (Transform)(object)basePC2D.Vector3H;
							ProCamera2D proCamera2D8 = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D8 != null && basePC2D.Vector3H != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v481 @ r14_v24 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
								ProCamera2D vector3V3 = (ProCamera2D)(object)basePC2D.Vector3V;
								ProCamera2D proCamera2D9 = _003C_003E4__this.ProCamera2D;
								if ((object)proCamera2D9 != null && basePC2D.Vector3V != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v482.m_CancellationTokenSource (System.Threading.CancellationTokenSource) (should have been resolved before IL gen)");
									if (basePC2D.VectorHV != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v539 @ r15_v23 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3033 @ rax_v104+8]");
										nint num3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3100 @ rax_v112+8]");
										object obj4 = num3 + 0;
										transform3 = null;
										goto IL_1409;
									}
								}
							}
						}
					}
				}
			}
			goto IL_1164;
			IL_116b:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+98]");
			if ((nint)0 == 0)
			{
				goto IL_0048;
			}
			Transform vector3H4 = (Transform)(object)basePC2D.Vector3H;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+BC]");
			_ = 0;
			ProCamera2D proCamera2D10 = _003C_003E4__this.ProCamera2D;
			if ((object)proCamera2D10 != null && basePC2D.Vector3H != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v447 @ rdi_v23 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
				Transform vector3V4 = (Transform)(object)basePC2D.Vector3V;
				ProCamera2D proCamera2D11 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D11 != null && basePC2D.Vector3V != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v448 @ rdi_v24 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
					distanceToCenterPercentage = _003C_003E4__this.GetDistanceToCenterPercentage(vector3);
					Transform vector3H5 = (Transform)(object)basePC2D.Vector3H;
					ProCamera2D proCamera2D12 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D12 != null && basePC2D.Vector3H != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v449 @ rdi_v25 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
						Transform vector3H6 = (Transform)(object)basePC2D.Vector3H;
						ProCamera2D proCamera2D13 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D13 != null && basePC2D.Vector3H != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v450 @ rdi_v26 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
							Transform vector3H7 = (Transform)(object)basePC2D.Vector3H;
							ProCamera2D proCamera2D14 = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D14 != null && basePC2D.Vector3H != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v451 @ rdi_v27 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
								Transform vector3V5 = (Transform)(object)basePC2D.Vector3V;
								ProCamera2D proCamera2D15 = _003C_003E4__this.ProCamera2D;
								if ((object)proCamera2D15 != null && basePC2D.Vector3V != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v452 @ rdi_v28 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
									Transform vector3V6 = (Transform)(object)basePC2D.Vector3V;
									ProCamera2D proCamera2D16 = _003C_003E4__this.ProCamera2D;
									if ((object)proCamera2D16 != null && basePC2D.Vector3V != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v453 @ rdi_v29 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
										Transform vector3V7 = (Transform)(object)basePC2D.Vector3V;
										ProCamera2D proCamera2D17 = _003C_003E4__this.ProCamera2D;
										if ((object)proCamera2D17 != null && basePC2D.Vector3V != null)
										{
											object obj5 = proCamera2D13._003CTargetsMidPoint_003Ek__BackingField + proCamera2D12._003CTargetsMidPoint_003Ek__BackingField;
											object obj6 = proCamera2D16._003CTargetsMidPoint_003Ek__BackingField + proCamera2D15._003CTargetsMidPoint_003Ek__BackingField;
											object obj7 = obj5 - (object)proCamera2D14._003CPreviousTargetsMidPoint_003Ek__BackingField;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v454 @ rdi_v30 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
											Transform transform4 = (Transform)0;
											object obj8 = obj6 - (object)proCamera2D17._003CPreviousTargetsMidPoint_003Ek__BackingField;
											Transform vector3H8 = (Transform)(object)basePC2D.Vector3H;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
											if ((nint)0 != 0)
											{
												bool flag6 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
												if (basePC2D.Vector3H != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v455 @ rdi_v31 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
													object obj9 = 0;
													object vector3V8 = basePC2D.Vector3V;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rdi_v32 (System.Object)+10]");
														bool flag7 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rdi_v32 (System.Object)+10]");
														Transform.get_position_Injected((IntPtr)0, out ret);
														if (basePC2D.Vector3V != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v475 @ r14_v20 (System.Object)+18] (should have been resolved before IL gen)");
															object obj10 = obj8 - (object)ret;
															object obj11 = obj7 - (object)ret;
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001851D2DFFh\"");
															if (distanceToCenterPercentage == 0f)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
																Transform transform5 = (Transform)0;
																Func<float, float, Vector3> vectorHV4 = basePC2D.VectorHV;
																object vector3H9 = basePC2D.Vector3H;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
																if ((nint)0 != 0)
																{
																	bool flag8 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
																	Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out ret);
																	if (basePC2D.Vector3H != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v476 @ r14_v26 (System.Object)+18] (should have been resolved before IL gen)");
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
																		Transform transform6 = (Transform)0;
																		Transform vector3V9 = (Transform)(object)basePC2D.Vector3V;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
																		if ((nint)0 != 0)
																		{
																			bool flag9 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
																			Transform.get_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out ret);
																			if (basePC2D.Vector3V != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v458 @ rdi_v47 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																				if (basePC2D.VectorHV != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v189 @ r13_v19 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
																					ProCamera2D proCamera2D18 = _003C_003E4__this.ProCamera2D;
																					object obj12 = Time.deltaTime;
																					float deltaTime = default(float);
																					Vector3 vector4 = Vector3.SmoothDamp((Vector3)(&ret), (Vector3)(&vector), ref *(Vector3*)(_003C_003E4__this + 212), num, num2, deltaTime);
																					if ((object)proCamera2D18 != null)
																					{
																						proCamera2D18.ExclusiveTargetPosition = (Vector3?)(object)1;
																						ProCamera2D proCamera2D19 = _003C_003E4__this.ProCamera2D;
																						if ((object)proCamera2D19 != null)
																						{
																							bool flag10 = (object)proCamera2D19.ExclusiveTargetPosition == null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
																							object obj13 = obj11 ^ 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
																							object obj14 = obj10 ^ 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rax_v161 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+DC]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rax_v161 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+E4]");
																							_ = 0;
																							float num4 = 1f - distanceToCenterPercentage;
																							float num5 = num4 * (float)obj14;
																							float num6 = num4 * (float)obj13;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
																							if ((nint)0 != 1)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
																								if ((nint)0 == 2)
																								{
																									_ = 0;
																								}
																							}
																							else
																							{
																								_ = 0;
																							}
																							ProCamera2D proCamera2D20 = _003C_003E4__this.ProCamera2D;
																							if ((object)proCamera2D20 != null)
																							{
																								proCamera2D20.ApplyInfluence(vector3);
																								transform3 = null;
																								goto IL_1409;
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001851D30CBh\"");
																bool flag11 = _003CpreviousDistancePercentage_003E5__2 != 0f;
																vector = ret;
																if (flag11)
																{
																	goto IL_143f;
																}
																ProCamera2D proCamera2D21 = _003C_003E4__this.ProCamera2D;
																if ((object)proCamera2D21 != null)
																{
																	ProCamera2D proCamera2D22 = _003C_003E4__this.ProCamera2D;
																	if ((object)proCamera2D22 != null)
																	{
																		Transform vector3H10 = (Transform)(object)basePC2D.Vector3H;
																		ProCamera2D proCamera2D23 = _003C_003E4__this.ProCamera2D;
																		if ((object)proCamera2D23 != null && basePC2D.Vector3H != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v460 @ rdi_v38 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																			Transform vector3H11 = (Transform)(object)basePC2D.Vector3H;
																			ProCamera2D proCamera2D24 = _003C_003E4__this.ProCamera2D;
																			if ((object)proCamera2D24 != null && basePC2D.Vector3H != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v461 @ rdi_v39 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																				Transform vector3H12 = (Transform)(object)basePC2D.Vector3H;
																				ProCamera2D proCamera2D25 = _003C_003E4__this.ProCamera2D;
																				if ((object)proCamera2D25 != null && basePC2D.Vector3H != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v462 @ rdi_v40 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																					Transform vector3V10 = (Transform)(object)basePC2D.Vector3V;
																					ProCamera2D proCamera2D26 = _003C_003E4__this.ProCamera2D;
																					if ((object)proCamera2D26 != null && basePC2D.Vector3V != null)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v463 @ rdi_v41 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																						Transform vector3V11 = (Transform)(object)basePC2D.Vector3V;
																						ProCamera2D proCamera2D27 = _003C_003E4__this.ProCamera2D;
																						if ((object)proCamera2D27 != null && basePC2D.Vector3V != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v464 @ rdi_v42 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																							Transform vector3V12 = (Transform)(object)basePC2D.Vector3V;
																							ProCamera2D proCamera2D28 = _003C_003E4__this.ProCamera2D;
																							if ((object)proCamera2D28 != null && basePC2D.Vector3V != null)
																							{
																								object obj15 = proCamera2D24._003CTargetsMidPoint_003Ek__BackingField + proCamera2D23._003CTargetsMidPoint_003Ek__BackingField;
																								object obj16 = proCamera2D27._003CTargetsMidPoint_003Ek__BackingField + proCamera2D26._003CTargetsMidPoint_003Ek__BackingField;
																								object obj17 = obj15 - (object)proCamera2D25._003CPreviousTargetsMidPoint_003Ek__BackingField;
																								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v465 @ rdi_v43 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																								object obj18 = obj16 - (object)proCamera2D28._003CPreviousTargetsMidPoint_003Ek__BackingField;
																								float num7 = proCamera2D21._cameraTargetHorizontalPositionSmoothed - (float)obj17;
																								float num8 = proCamera2D22._cameraTargetVerticalPositionSmoothed - (float)obj18;
																								Transform vector3H13 = (Transform)(object)basePC2D.Vector3H;
																								ProCamera2D proCamera2D29 = _003C_003E4__this.ProCamera2D;
																								if ((object)proCamera2D29 != null && basePC2D.Vector3H != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v466 @ rdi_v44 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																									Transform vector3V13 = (Transform)(object)basePC2D.Vector3V;
																									ProCamera2D proCamera2D30 = _003C_003E4__this.ProCamera2D;
																									if ((object)proCamera2D30 != null && basePC2D.Vector3V != null)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v467 @ rdi_v45 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
																										float num9 = num8 + (float)proCamera2D30._003CParentPosition_003Ek__BackingField;
																										float num10 = (float)proCamera2D29._003CParentPosition_003Ek__BackingField + num7;
																										vector = proCamera2D30._003CParentPosition_003Ek__BackingField;
																										goto IL_143f;
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
									}
								}
							}
						}
					}
				}
			}
			goto IL_1164;
			IL_0048:
			return false;
			IL_1510:
			return true;
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

	private sealed class _003COutsideTriggerRoutine_003Ed__14(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DTriggerInfluence _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_027f: Expected I4, but got I8
			//IL_0352: Expected I4, but got O
			//IL_0039: Expected O, but got I4
			//IL_0081: Expected I4, but got I8
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Expected O, but got Unknown
			//IL_0126: Invalid comparison between F4 and O
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Expected Ref, but got Unknown
			ProCamera2DTriggerInfluence proCamera2DTriggerInfluence = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag || (nint)obj == 1)
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this == null)
					{
						goto IL_0344;
					}
					if (!proCamera2DTriggerInfluence._insideTrigger)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
						object obj3 = default(object);
						object obj2 = (object)proCamera2DTriggerInfluence._influence - obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rsi_v1 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DTriggerInfluence)+C8]");
						object obj5 = default(object);
						object obj4 = 0 - obj5;
						object obj6 = obj4 * obj4;
						object obj7 = obj2 * obj2;
						object obj8 = obj6 + obj7;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
							Vector2 vector = default(Vector2);
							Vector2 target = default(Vector2);
							float maxSpeed = default(float);
							float deltaTime = default(float);
							Vector2 influence = Vector2.SmoothDamp(vector, target, ref *(Vector2*)(_003C_003E4__this + 204), proCamera2DTriggerInfluence.InfluenceSmoothness, maxSpeed, deltaTime);
							proCamera2DTriggerInfluence._influence = influence;
							ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D != null)
							{
								proCamera2D.ApplyInfluence(vector);
								ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
								if ((object)proCamera2D2 != null)
								{
									bool flag2 = proCamera2D2.UpdateType != UpdateType.FixedUpdate;
									WaitForFixedUpdate waitForFixedUpdate = null;
									if (!flag2)
									{
										bool flag3 = proCamera2D2.IgnoreTimeScale;
										waitForFixedUpdate = null;
										if (!flag3)
										{
											waitForFixedUpdate = proCamera2D2._waitForFixedUpdate;
										}
									}
									_003C_003E2__current = waitForFixedUpdate;
									_003C_003E1__state = 2;
									goto IL_0380;
								}
							}
							goto IL_0344;
						}
					}
				}
				return false;
			}
			_003C_003E1__state = -1;
			if ((object)_003C_003E4__this != null)
			{
				ProCamera2D proCamera2D3 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D3 != null)
				{
					WaitForFixedUpdate waitForFixedUpdate2 = ((proCamera2D3.UpdateType != UpdateType.FixedUpdate) ? null : ((!proCamera2D3.IgnoreTimeScale) ? proCamera2D3._waitForFixedUpdate : null));
					_003C_003E2__current = waitForFixedUpdate2;
					_003C_003E1__state = 1;
					goto IL_0380;
				}
			}
			goto IL_0344;
			IL_0380:
			return true;
			IL_0344:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
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

	public static string TriggerName = "Influence Trigger";

	public Transform FocusPoint;

	public float InfluenceSmoothness;

	public float ExclusiveInfluencePercentage;

	public TriggerInfluenceMode Mode;

	private Vector2 _influence;

	private Vector2 _velocity;

	private Vector3 _exclusivePointVelocity;

	private Vector3 _tempExclusivePoint;

	private void Start()
	{
		Transform focusPoint = FocusPoint;
		if ((object)FocusPoint == null || ((UnityEngine.Object)focusPoint).m_CachedPtr == (IntPtr)0)
		{
			Transform transform = base.transform;
			if ("FocusPoint" == null)
			{
				ArgumentNullException ex = new ArgumentNullException("Name cannot be null");
				ex._002Ector("Name cannot be null");
				throw ex;
			}
			Transform focusPoint2 = transform.FindRelativeTransformWithPath("FocusPoint", false);
			FocusPoint = focusPoint2;
		}
		Transform focusPoint3 = FocusPoint;
		if ((object)FocusPoint == null || ((UnityEngine.Object)focusPoint3).m_CachedPtr == (IntPtr)0)
		{
			Transform focusPoint4 = base.transform;
			FocusPoint = focusPoint4;
		}
	}

	protected override void EnteredTrigger()
	{
		bool flag = OnEnteredTrigger == null;
		_insideTrigger = true;
		if (!flag)
		{
			Action onEnteredTrigger = OnEnteredTrigger;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v14.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		_003CInsideTriggerRoutine_003Ed__13 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	protected override void ExitedTrigger()
	{
		bool flag = OnExitedTrigger == null;
		_insideTrigger = false;
		if (!flag)
		{
			Action onExitedTrigger = OnExitedTrigger;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v14.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		_003COutsideTriggerRoutine_003Ed__14 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator InsideTriggerRoutine()
	{
		_003CInsideTriggerRoutine_003Ed__13 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator OutsideTriggerRoutine()
	{
		_003COutsideTriggerRoutine_003Ed__14 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public ProCamera2DTriggerInfluence()
	{
		//IL_0041: Expected I, but got O
		InfluenceSmoothness = 0.3f;
		ExclusiveInfluencePercentage = 0.25f;
		UpdateInterval = 0.1f;
		UseTargetsMidPoint = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
