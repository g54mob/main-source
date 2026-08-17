using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DTriggerBoundaries : BaseTrigger, IPositionOverrider
{
	private sealed class _003CMoveCameraToTarget_003Ed__43(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DTriggerBoundaries _003C_003E4__this;

		private float _003CinitialCamPosH_003E5__2;

		private float _003CinitialCamPosV_003E5__3;

		private float _003Ct_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_01fe: Expected I4, but got I8
			//IL_04c1: Expected I4, but got O
			ProCamera2DTriggerBoundaries proCamera2DTriggerBoundaries = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Func<Vector3, float> vector3H = proCamera2DTriggerBoundaries.Vector3H;
					ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D != null)
					{
						Vector3 localPosition = proCamera2D.LocalPosition;
						if (proCamera2DTriggerBoundaries.Vector3H != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ rbp_v6 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							_003CinitialCamPosH_003E5__2 = localPosition.x;
							Func<Vector3, float> vector3V = proCamera2DTriggerBoundaries.Vector3V;
							ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D2 != null)
							{
								Vector3 localPosition2 = proCamera2D2.LocalPosition;
								if (proCamera2DTriggerBoundaries.Vector3V != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v149 @ rbp_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									_003CinitialCamPosV_003E5__3 = localPosition2.x;
									Func<float, float, float, Vector3> vectorHVD = proCamera2DTriggerBoundaries.VectorHVD;
									if (proCamera2DTriggerBoundaries.VectorHVD != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v141 @ rdx_v23 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
										object newPos = default(object);
										proCamera2DTriggerBoundaries._newPos = (Vector3)newPos;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rax_v35+8]");
										_ = 0;
										proCamera2DTriggerBoundaries._transitioning = true;
										_003Ct_003E5__4 = 0f;
										goto IL_04c1;
									}
								}
							}
						}
					}
				}
				goto IL_04b3;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				goto IL_04c1;
			}
			goto IL_04e0;
			IL_04e0:
			return false;
			IL_04b3:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_04c1:
			if (!(1f < _003Ct_003E5__4))
			{
				if ((object)_003C_003E4__this != null)
				{
					ProCamera2D proCamera2D3 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D3 != null)
					{
						float num = proCamera2D3._003CDeltaTime_003Ek__BackingField / proCamera2DTriggerBoundaries.TransitionDuration;
						float num2 = num + _003Ct_003E5__4;
						_003Ct_003E5__4 = num2;
						ProCamera2D proCamera2D4 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D4 != null)
						{
							float num3 = Utils.EaseFromTo(_003CinitialCamPosH_003E5__2, proCamera2D4._cameraTargetHorizontalPositionSmoothed, _003Ct_003E5__4, proCamera2DTriggerBoundaries.TransitionEaseType);
							ProCamera2D proCamera2D5 = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D5 != null)
							{
								float num4 = Utils.EaseFromTo(_003CinitialCamPosV_003E5__3, proCamera2D5._cameraTargetVerticalPositionSmoothed, _003Ct_003E5__4, proCamera2DTriggerBoundaries.TransitionEaseType);
								float horizontalPos = default(float);
								float verticalPos = default(float);
								_003C_003E4__this.LimitToNumericBoundaries(ref horizontalPos, ref verticalPos);
								Func<float, float, float, Vector3> vectorHVD2 = proCamera2DTriggerBoundaries.VectorHVD;
								if (proCamera2DTriggerBoundaries.VectorHVD != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v146 @ rdx_v10 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
									object newPos2 = default(object);
									proCamera2DTriggerBoundaries._newPos = (Vector3)newPos2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rax_v16+8]");
									_ = 0;
									ProCamera2D proCamera2D6 = _003C_003E4__this.ProCamera2D;
									if ((object)proCamera2D6 != null)
									{
										bool flag = proCamera2D6.UpdateType != UpdateType.FixedUpdate;
										WaitForFixedUpdate waitForFixedUpdate = null;
										if (!flag)
										{
											bool flag2 = proCamera2D6.IgnoreTimeScale;
											waitForFixedUpdate = null;
											if (!flag2)
											{
												waitForFixedUpdate = proCamera2D6._waitForFixedUpdate;
											}
										}
										_003C_003E2__current = waitForFixedUpdate;
										_003C_003E1__state = 1;
										return true;
									}
								}
							}
						}
					}
				}
			}
			else if ((object)_003C_003E4__this != null)
			{
				ProCamera2DNumericBoundaries numericBoundaries = proCamera2DTriggerBoundaries.NumericBoundaries;
				if ((object)proCamera2DTriggerBoundaries.NumericBoundaries != null)
				{
					numericBoundaries.MoveCameraToTargetRoutine = null;
					proCamera2DTriggerBoundaries._transitioning = false;
					goto IL_04e0;
				}
			}
			goto IL_04b3;
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

	private sealed class _003CTransition_003Ed__42(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DTriggerBoundaries _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0d5d: Expected I4, but got I8
			//IL_0db2: Expected O, but got I
			//IL_0227: Expected O, but got I
			//IL_0237: Expected O, but got I
			//IL_0247: Expected O, but got I
			//IL_0257: Expected O, but got I
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Expected O, but got Unknown
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Expected O, but got Unknown
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Expected O, but got Unknown
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Expected O, but got Unknown
			//IL_026c: Expected O, but got I
			//IL_0332: Expected O, but got I
			//IL_03f8: Expected O, but got I
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a6: Expected O, but got Unknown
			//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bb: Expected O, but got Unknown
			//IL_02c4: Invalid comparison between O and F4
			//IL_04be: Expected O, but got I
			//IL_0367: Unknown result type (might be due to invalid IL or missing references)
			//IL_036c: Expected O, but got Unknown
			//IL_037c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0381: Expected O, but got Unknown
			//IL_038a: Invalid comparison between O and F4
			//IL_042d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0432: Expected O, but got Unknown
			//IL_0442: Unknown result type (might be due to invalid IL or missing references)
			//IL_0447: Expected O, but got Unknown
			//IL_0450: Invalid comparison between O and F4
			//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f8: Expected O, but got Unknown
			//IL_0508: Unknown result type (might be due to invalid IL or missing references)
			//IL_050d: Expected O, but got Unknown
			//IL_0516: Invalid comparison between O and F4
			//IL_0882: Expected O, but got I
			//IL_09af: Expected O, but got I4
			//IL_07d7: Expected O, but got I
			//IL_07df: Invalid comparison between O and F4
			//IL_08df: Expected O, but got I
			//IL_0a83: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a88: Expected O, but got Unknown
			//IL_09c4: Expected O, but got I
			//IL_0924: Expected O, but got I4
			//IL_0b5f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b64: Expected O, but got Unknown
			//IL_086d: Expected F4, but got I
			//IL_0a9d: Expected O, but got I
			//IL_0952: Expected O, but got I4
			//IL_0c28: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c2d: Expected O, but got Unknown
			//IL_0b79: Expected O, but got I
			//IL_098a: Expected O, but got I4
			//IL_0c42: Expected O, but got I
			//IL_09a1: Expected O, but got I4
			//IL_0ca9: Expected O, but got I
			//IL_0ca9: Expected O, but got I
			//IL_0b4c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b51: Expected O, but got Unknown
			//IL_0ced: Expected O, but got I
			//IL_028c->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_04a9->IL0e64: Incompatible stack heights: 1 vs 0
			//IL_0352->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_0418->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_04de->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_057d->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_05af->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_054d->IL0e64: Incompatible stack heights: 1 vs 0
			//IL_05e1->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_0613->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_0645->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_0677->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_06a9->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_06db->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_070d->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_073f->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_08a2->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_079d->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_08ff->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_0824->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_09e4->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_0abd->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_0b99->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_0d2c->IL0f39: Incompatible stack heights: 1 vs 0
			//IL_0c62->IL0db7: Incompatible stack heights: 1 vs 0
			//IL_0cd3->IL0db7: Incompatible stack heights: 1 vs 0
			Component component = _003C_003E4__this;
			object obj3;
			object obj4;
			object obj5;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B9]");
					if ((nint)0 == _003C_003E1__state)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+C0]");
						if ((nint)0 == _003C_003E1__state)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+C8]");
							if ((nint)0 == _003C_003E1__state)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+D0]");
								if ((nint)0 == _003C_003E1__state)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
									if ((nint)0 != 0)
									{
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
										if ((nint)0 != 0)
										{
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
											if ((nint)0 != 0)
											{
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
												if ((nint)0 != 0)
												{
													_ = 0;
													goto IL_0e64;
												}
											}
										}
									}
									goto IL_0db7;
								}
							}
						}
					}
					Transform transform = _003C_003E4__this.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B8]");
						object obj;
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+BC]");
							object obj2 = default(object);
							obj = obj2 + 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+C4]");
							obj3 = obj2 + 0;
							Vector3 vector = ret;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+CC]");
							obj4 = vector + 0;
							Vector3 vector2 = ret;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+D4]");
							obj5 = vector2 + 0;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+C4]");
							obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+CC]");
							obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+D4]");
							obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+BC]");
							obj = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B9]");
						if ((nint)0 == 0)
						{
							goto IL_02fd;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v74+74]");
							object obj7 = 0 - obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
							object obj8 = obj7 & 0;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v74+71]");
								if ((nint)0 != 0)
								{
									goto IL_02fd;
								}
							}
							goto IL_0552;
						}
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0e64;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
						((BoundariesAnimator)0).Transition();
						goto IL_0e64;
					}
				}
			}
			goto IL_0db7;
			IL_0489:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+D0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v71+98]");
					object obj10 = 0 - obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj11 = obj10 & 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v71+94]");
						if ((nint)0 != 0)
						{
							goto IL_0e64;
						}
					}
					goto IL_0552;
				}
				goto IL_0db7;
			}
			goto IL_0e64;
			IL_0db7:
			throw new NullReferenceException();
			IL_0c1f:
			object obj13;
			object obj12 = obj13 + 1;
			goto IL_0ef2;
			IL_0e64:
			return false;
			IL_0a7a:
			object obj14;
			obj12 = obj14 + 1;
			goto IL_0e9a;
			IL_0cfb:
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			_003C_003E2__current = waitForEndOfFrame;
			_003C_003E1__state = 1;
			return true;
			IL_0ef2:
			if ((nint)obj12 <= 1)
			{
				goto IL_0cfb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
			MonoBehaviour monoBehaviour = (MonoBehaviour)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v43 (UnityEngine.MonoBehaviour)+D0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v43 (UnityEngine.MonoBehaviour)+D0]");
					((MonoBehaviour)num).StopCoroutine((Coroutine)0);
				}
				_003CMoveCameraToTarget_003Ed__43 obj15 = null;
				obj15._003C_003E1__state = 0;
				obj15._003C_003E4__this = _003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
					Coroutine coroutine = ((MonoBehaviour)0).StartCoroutine(obj15);
					goto IL_0cfb;
				}
			}
			goto IL_0db7;
			IL_02fd:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+C0]");
			if ((nint)0 == 0)
			{
				goto IL_03c3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v73+80]");
				object obj17 = 0 - obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				object obj18 = obj17 & 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v73+7C]");
					if ((nint)0 != 0)
					{
						goto IL_03c3;
					}
				}
				goto IL_0552;
			}
			goto IL_0db7;
			IL_0b69:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+50]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+50]");
			if ((nint)0 == 0)
			{
				goto IL_0db7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v59+7C]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+20]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v59+84]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+24]");
					bool flag2 = num2 <= 0;
					obj13 = obj12;
					if (!flag2)
					{
						goto IL_0c1f;
					}
				}
			}
			goto IL_0ef2;
			IL_0552:
			_003C_003E4__this.GetTargetBoundaries();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B9]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+100]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+C0]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+104]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+C8]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+108]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+D0]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+10C]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+D8]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+DC]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+E0]");
													if ((nint)0 != 0)
													{
														ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
														if ((object)proCamera2D == null)
														{
															goto IL_0db7;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v65 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
														float num3 = 0f * 0.5f;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F0]");
														nint num4 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+E4]");
														object obj20 = num4 / 0;
														bool flag3 = obj20 == (object)num3;
														Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851D18EBh\"");
														if (!flag3)
														{
															ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
															if ((object)proCamera2D2 == null)
															{
																goto IL_0db7;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F0]");
															float num5 = 0f;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+E4]");
															float newSize = num5 / 0f;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+E8]");
															nint num6 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+DC]");
															proCamera2D2.UpdateScreenSize(newSize, num6);
														}
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
													object obj21 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+F8]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+30]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+50]");
															object obj22 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+50]");
															if ((nint)0 == 0)
															{
																goto IL_0db7;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v64+88]");
															bool flag4 = (nint)0 == 0;
															obj14 = 0;
															if (!flag4)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+38]");
																bool flag5 = (nint)0 == 0;
																obj14 = 0;
																if (!flag5)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v64+90]");
																	nint num7 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+3C]");
																	bool flag6 = num7 <= 0;
																	obj14 = 0;
																	if (!flag6)
																	{
																		obj14 = 1;
																	}
																	goto IL_0a7a;
																}
															}
														}
														else
														{
															obj14 = 1;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+38]");
														if ((nint)0 != 0)
														{
															goto IL_0a7a;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+50]");
														object obj23 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+50]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v62+94]");
															bool flag7 = (nint)0 == 0;
															obj12 = obj14;
															if (!flag7)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+30]");
																bool flag8 = (nint)0 == 0;
																obj12 = obj14;
																if (!flag8)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+34]");
																	nint num8 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v62+9C]");
																	bool flag9 = num8 <= 0;
																	obj12 = obj14;
																	if (!flag9)
																	{
																		goto IL_0a7a;
																	}
																}
															}
															goto IL_0e9a;
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
			goto IL_0db7;
			IL_0e9a:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+20]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+50]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+50]");
				if ((nint)0 == 0)
				{
					goto IL_0db7;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v60+71]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+28]");
					if ((nint)0 == 0)
					{
						goto IL_0b69;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+2C]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v60+78]");
					bool flag10 = num9 <= 0;
					obj13 = obj12;
					if (!flag10)
					{
						obj13 = obj12 + 1;
					}
					goto IL_0c1f;
				}
			}
			else
			{
				obj12++;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v27+28]");
			bool flag11 = (nint)0 != 0;
			obj13 = obj12;
			if (!flag11)
			{
				goto IL_0b69;
			}
			goto IL_0c1f;
			IL_03c3:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+C8]");
			if ((nint)0 == 0)
			{
				goto IL_0489;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
			object obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (UnityEngine.Component)+B0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v72+8C]");
				object obj26 = 0 - obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				object obj27 = obj26 & 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj27) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v72+88]");
					if ((nint)0 != 0)
					{
						goto IL_0489;
					}
				}
				goto IL_0552;
			}
			goto IL_0db7;
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

	private sealed class _003CTurnOffPreviousTrigger_003Ed__39(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DTriggerBoundaries trigger;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0078: Expected I4, but got I8
			//IL_00b8: Expected I4, but got O
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
				ProCamera2DTriggerBoundaries proCamera2DTriggerBoundaries = trigger;
				_003C_003E1__state = -1;
				if ((object)trigger == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				proCamera2DTriggerBoundaries._transitioning = false;
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

	public static string TriggerName = "Boundaries Trigger";

	public ProCamera2DNumericBoundaries NumericBoundaries;

	public bool AreBoundariesRelative;

	public bool UseTopBoundary;

	public float TopBoundary;

	public bool UseBottomBoundary;

	public float BottomBoundary;

	public bool UseLeftBoundary;

	public float LeftBoundary;

	public bool UseRightBoundary;

	public float RightBoundary;

	public float TransitionDuration;

	public EaseType TransitionEaseType;

	public bool ChangeZoom;

	public float TargetZoom;

	public float ZoomSmoothness;

	public bool _setAsStartingBoundaries;

	private float _initialCamSize;

	private BoundariesAnimator _boundsAnim;

	private float _targetTopBoundary;

	private float _targetBottomBoundary;

	private float _targetLeftBoundary;

	private float _targetRightBoundary;

	private bool _transitioning;

	private Vector3 _newPos;

	private int _poOrder;

	public bool IsCurrentTrigger
	{
		get
		{
			//IL_008e: Expected I4, but got O
			//IL_006c: Expected O, but got I4
			ProCamera2DNumericBoundaries numericBoundaries = NumericBoundaries;
			if ((object)NumericBoundaries != null)
			{
				ProCamera2DTriggerBoundaries currentBoundariesTrigger = numericBoundaries.CurrentBoundariesTrigger;
				if ((object)numericBoundaries.CurrentBoundariesTrigger != null)
				{
					object obj = currentBoundariesTrigger._instanceID - _instanceID;
					return obj == null;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool SetAsStartingBoundaries
	{
		get
		{
			return _setAsStartingBoundaries;
		}
		set
		{
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_00ba: Expected I, but got O
			//IL_00d8: Expected I, but got O
			//IL_00e8: Expected O, but got I
			//IL_0124: Expected O, but got I
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Expected O, but got Unknown
			if (value && !_setAsStartingBoundaries)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj2 = default(object);
				object obj = obj2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type type2 = default(Type);
				Type type = type2;
				UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(type);
				Type type3 = null;
				Type type4 = null;
				while ((nint)type4 < array.Length)
				{
					nint num = (nint)typeof(ProCamera2DTriggerBoundaries);
					ProCamera2DTriggerBoundaries proCamera2DTriggerBoundaries = (ProCamera2DTriggerBoundaries)array[(object)type3];
					nint num2 = (nint)proCamera2DTriggerBoundaries;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r8_v5 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ProCamera2DTriggerBoundaries>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r9_v5 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ProCamera2DTriggerBoundaries>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r8_v5 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ProCamera2DTriggerBoundaries>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r9_v5 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ProCamera2DTriggerBoundaries>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v17+FFFFFFF8+v314 @ rax_v14*8]");
						if (0 == (nint)typeof(ProCamera2DTriggerBoundaries))
						{
							proCamera2DTriggerBoundaries.SetAsStartingBoundaries = false;
							type3 = (Type)(type3 + 1);
							type4 = type3;
							continue;
						}
					}
					throw new InvalidCastException();
				}
			}
			_setAsStartingBoundaries = value;
		}
	}

	public int POOrder
	{
		get
		{
			return _poOrder;
		}
		set
		{
			_poOrder = value;
		}
	}

	protected override void Awake()
	{
		//IL_005a: Expected O, but got I
		//IL_00c0: Expected O, but got I8
		((BasePC2D)this).Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			int instanceID = GetInstanceID();
			_instanceID = instanceID;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			UnityEngine.Object obj2 = this;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				obj2 = (UnityEngine.Object)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v208 @ rax_v18 (should have been resolved before IL gen)");
			float updateInterval = -0.02f + UpdateInterval;
			UpdateInterval = updateInterval;
			Toggle(value: true);
		}
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		proCamera2D2.AddPositionOverrider(this);
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._positionOverriders).Remove((object)this);
		}
	}

	private void Start()
	{
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D == null || ((UnityEngine.Object)proCamera2D).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		ProCamera2DNumericBoundaries numericBoundaries = NumericBoundaries;
		if ((object)NumericBoundaries != null && ((UnityEngine.Object)numericBoundaries).m_CachedPtr != (IntPtr)0)
		{
			goto IL_012e;
		}
		ProCamera2DNumericBoundaries proCamera2DNumericBoundaries = UnityEngine.Object.FindObjectOfType<ProCamera2DNumericBoundaries>();
		ProCamera2DNumericBoundaries numericBoundaries2;
		if ((object)proCamera2DNumericBoundaries != null)
		{
			bool flag = ((UnityEngine.Object)proCamera2DNumericBoundaries).m_CachedPtr != (IntPtr)0;
			numericBoundaries2 = proCamera2DNumericBoundaries;
			if (flag)
			{
				goto IL_0481;
			}
		}
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		if ((object)proCamera2D2 != null)
		{
			GameObject gameObject = proCamera2D2.gameObject;
			if ((object)gameObject != null)
			{
				ProCamera2DNumericBoundaries proCamera2DNumericBoundaries2 = gameObject.AddComponent<ProCamera2DNumericBoundaries>();
				numericBoundaries2 = proCamera2DNumericBoundaries2;
				goto IL_0481;
			}
		}
		goto IL_03fa;
		IL_012e:
		ProCamera2D proCamera2D3 = base.ProCamera2D;
		BoundariesAnimator boundsAnim = new BoundariesAnimator(proCamera2D3, NumericBoundaries);
		_boundsAnim = boundsAnim;
		BoundariesAnimator boundsAnim2 = _boundsAnim;
		if (_boundsAnim != null)
		{
			Action b = delegate
			{
				ProCamera2DNumericBoundaries numericBoundaries3 = NumericBoundaries;
				if (numericBoundaries3.OnBoundariesTransitionStarted != null)
				{
					Action onBoundariesTransitionStarted = numericBoundaries3.OnBoundariesTransitionStarted;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v30.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			Delegate obj = Delegate.Combine(boundsAnim2.OnTransitionStarted, b);
			if ((object)obj == null)
			{
				boundsAnim2.OnTransitionStarted = null;
			}
			else
			{
				bool flag2 = (object)obj.GetType() != typeof(Action);
				Delegate obj2 = null;
				if (!flag2)
				{
					obj2 = obj;
				}
				if ((object)obj2 == null)
				{
					throw new InvalidCastException();
				}
				boundsAnim2.OnTransitionStarted = (Action)obj2;
				bool flag3 = (object)obj.GetType() != typeof(Action);
				Delegate obj3 = null;
				if (!flag3)
				{
					obj3 = obj;
				}
				if ((object)obj3 == null)
				{
					throw new InvalidCastException();
				}
			}
			BoundariesAnimator boundsAnim3 = _boundsAnim;
			if (_boundsAnim != null)
			{
				Action b2 = delegate
				{
					ProCamera2DNumericBoundaries numericBoundaries3 = NumericBoundaries;
					if (numericBoundaries3.OnBoundariesTransitionFinished != null)
					{
						Action onBoundariesTransitionFinished = numericBoundaries3.OnBoundariesTransitionFinished;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v30.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				Delegate obj4 = Delegate.Combine(boundsAnim3.OnTransitionFinished, b2);
				if ((object)obj4 == null)
				{
					boundsAnim3.OnTransitionFinished = null;
				}
				else
				{
					bool flag4 = (object)obj4.GetType() != typeof(Action);
					Delegate obj5 = null;
					if (!flag4)
					{
						obj5 = obj4;
					}
					if ((object)obj5 == null)
					{
						goto IL_0517;
					}
					boundsAnim3.OnTransitionFinished = (Action)obj5;
					bool flag5 = (object)obj4.GetType() != typeof(Action);
					Delegate obj6 = null;
					if (!flag5)
					{
						obj6 = obj4;
					}
					if ((object)obj6 == null)
					{
						goto IL_0523;
					}
				}
				GetTargetBoundaries();
				if (_setAsStartingBoundaries)
				{
					SetBoundaries();
				}
				ProCamera2D proCamera2D4 = base.ProCamera2D;
				if ((object)proCamera2D4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v39 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
					float initialCamSize = 0f * 0.5f;
					_initialCamSize = initialCamSize;
					return;
				}
			}
		}
		goto IL_03fa;
		IL_0523:
		InvalidCastException ex = new InvalidCastException();
		goto IL_0517;
		IL_0481:
		NumericBoundaries = numericBoundaries2;
		goto IL_012e;
		IL_0517:
		throw new InvalidCastException();
		IL_03fa:
		NullReferenceException ex2 = new NullReferenceException();
		goto IL_0523;
	}

	public unsafe Vector3 OverridePosition(float deltaTime, Vector3 originalPosition)
	{
		//IL_009b: Expected O, but got I4
		//IL_0082: Expected native int or pointer, but got O
		//IL_00c0: Expected native int or pointer, but got O
		//IL_0054: Expected F4, but got I
		//IL_0063: Expected F4, but got O
		//IL_005e: Expected native int or pointer, but got O
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		float z;
		Vector3 vector = default(Vector3);
		if (obj != null && _transitioning)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DTriggerBoundaries)+11C]");
			z = 0f;
			((Vector3*)(nint)vector)->x = (float)_newPos;
		}
		else
		{
			z = originalPosition.z;
			((Vector3*)(nint)vector)->x = originalPosition.x;
		}
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	protected override void EnteredTrigger()
	{
		bool flag = OnEnteredTrigger == null;
		_insideTrigger = true;
		if (!flag)
		{
			Action onEnteredTrigger = OnEnteredTrigger;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v40.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		ProCamera2DNumericBoundaries numericBoundaries = NumericBoundaries;
		ProCamera2DTriggerBoundaries currentBoundariesTrigger = numericBoundaries.CurrentBoundariesTrigger;
		if ((object)numericBoundaries.CurrentBoundariesTrigger != null && ((UnityEngine.Object)currentBoundariesTrigger).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2DNumericBoundaries numericBoundaries2 = NumericBoundaries;
			_003CTurnOffPreviousTrigger_003Ed__39 obj = null;
			obj._003C_003E1__state = 0;
			obj.trigger = numericBoundaries2.CurrentBoundariesTrigger;
			Coroutine coroutine = StartCoroutine(obj);
		}
		ProCamera2DNumericBoundaries numericBoundaries3 = NumericBoundaries;
		ProCamera2DTriggerBoundaries currentBoundariesTrigger2 = numericBoundaries3.CurrentBoundariesTrigger;
		if ((object)numericBoundaries3.CurrentBoundariesTrigger != null && ((UnityEngine.Object)currentBoundariesTrigger2).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2DNumericBoundaries numericBoundaries4 = NumericBoundaries;
			ProCamera2DTriggerBoundaries currentBoundariesTrigger3 = numericBoundaries4.CurrentBoundariesTrigger;
			if (currentBoundariesTrigger3._instanceID != _instanceID)
			{
				goto IL_0176;
			}
		}
		ProCamera2DNumericBoundaries numericBoundaries5 = NumericBoundaries;
		ProCamera2DTriggerBoundaries currentBoundariesTrigger4 = numericBoundaries5.CurrentBoundariesTrigger;
		if ((object)numericBoundaries5.CurrentBoundariesTrigger == null || ((UnityEngine.Object)currentBoundariesTrigger4).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0176;
		}
		return;
		IL_0176:
		ProCamera2DNumericBoundaries numericBoundaries6 = NumericBoundaries;
		numericBoundaries6.CurrentBoundariesTrigger = this;
		_003CTransition_003Ed__42 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine coroutine2 = StartCoroutine(obj2);
	}

	private IEnumerator TurnOffPreviousTrigger(ProCamera2DTriggerBoundaries trigger)
	{
		_003CTurnOffPreviousTrigger_003Ed__39 obj = null;
		obj._003C_003E1__state = 0;
		obj.trigger = trigger;
		return obj;
	}

	public void SetBoundaries()
	{
		ProCamera2DNumericBoundaries numericBoundaries = NumericBoundaries;
		if ((object)NumericBoundaries != null && ((UnityEngine.Object)numericBoundaries).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2DNumericBoundaries numericBoundaries2 = NumericBoundaries;
			numericBoundaries2.CurrentBoundariesTrigger = this;
			ProCamera2DNumericBoundaries numericBoundaries3 = NumericBoundaries;
			numericBoundaries3.UseLeftBoundary = UseLeftBoundary;
			if (UseLeftBoundary)
			{
				ProCamera2DNumericBoundaries numericBoundaries4 = NumericBoundaries;
				numericBoundaries4.TargetLeftBoundary = _targetLeftBoundary;
				numericBoundaries4.LeftBoundary = _targetLeftBoundary;
			}
			ProCamera2DNumericBoundaries numericBoundaries5 = NumericBoundaries;
			numericBoundaries5.UseRightBoundary = UseRightBoundary;
			if (UseRightBoundary)
			{
				ProCamera2DNumericBoundaries numericBoundaries6 = NumericBoundaries;
				numericBoundaries6.TargetRightBoundary = _targetRightBoundary;
				numericBoundaries6.RightBoundary = _targetRightBoundary;
			}
			ProCamera2DNumericBoundaries numericBoundaries7 = NumericBoundaries;
			numericBoundaries7.UseTopBoundary = UseTopBoundary;
			if (UseTopBoundary)
			{
				ProCamera2DNumericBoundaries numericBoundaries8 = NumericBoundaries;
				numericBoundaries8.TargetTopBoundary = _targetTopBoundary;
				numericBoundaries8.TopBoundary = _targetTopBoundary;
			}
			ProCamera2DNumericBoundaries numericBoundaries9 = NumericBoundaries;
			numericBoundaries9.UseBottomBoundary = UseBottomBoundary;
			if (UseBottomBoundary)
			{
				ProCamera2DNumericBoundaries numericBoundaries10 = NumericBoundaries;
				numericBoundaries10.TargetBottomBoundary = _targetBottomBoundary;
				numericBoundaries10.BottomBoundary = _targetBottomBoundary;
			}
		}
	}

	private unsafe void GetTargetBoundaries()
	{
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_02ff->IL0294: Incompatible stack heights: 1 vs 0
		//IL_010f->IL0294: Incompatible stack heights: 1 vs 0
		//IL_0368->IL0294: Incompatible stack heights: 2 vs 0
		//IL_019f->IL0294: Incompatible stack heights: 2 vs 0
		//IL_03d1->IL0294: Incompatible stack heights: 3 vs 0
		//IL_022f->IL0294: Incompatible stack heights: 3 vs 0
		//IL_0440->IL0294: Incompatible stack heights: 4 vs 0
		if (!AreBoundariesRelative)
		{
			_targetTopBoundary = TopBoundary;
			_targetBottomBoundary = BottomBoundary;
			_targetLeftBoundary = LeftBoundary;
			_targetRightBoundary = RightBoundary;
			return;
		}
		Func<Vector3, float> vector3V = Vector3V;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj2 = default(object);
			object obj = obj2 - 32;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
			if (Vector3V != null)
			{
				object obj3 = obj2 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v32 @ r14_v1 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
				float targetTopBoundary = 0f + TopBoundary;
				Func<Vector3, float> vector3V2 = Vector3V;
				_targetTopBoundary = targetTopBoundary;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					_ = 0;
					_ = 0;
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					object obj4 = obj2 - 32;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj4);
					if (Vector3V != null)
					{
						object obj5 = obj2 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v168 @ r14_v11 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
						float targetBottomBoundary = 0f + BottomBoundary;
						Func<Vector3, float> vector3H = Vector3H;
						_targetBottomBoundary = targetBottomBoundary;
						Transform transform3 = base.transform;
						if ((object)transform3 != null)
						{
							_ = 0;
							_ = 0;
							bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
							object obj6 = obj2 - 32;
							Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj6);
							if (Vector3H != null)
							{
								object obj7 = obj2 - 16;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v169 @ r14_v12 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
								float targetLeftBoundary = 0f + LeftBoundary;
								Transform vector3H2 = (Transform)(object)Vector3H;
								_targetLeftBoundary = targetLeftBoundary;
								Transform transform4 = base.transform;
								if ((object)transform4 != null)
								{
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v47 (UnityEngine.Transform)+10]");
									bool flag4 = (nint)0 == 0;
									object obj8 = obj2 - 32;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v47 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj8);
									if (Vector3H != null)
									{
										object obj9 = obj2 - 16;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v165 @ rdi_v13 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
										float targetRightBoundary = 0f + RightBoundary;
										_targetRightBoundary = targetRightBoundary;
										return;
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

	private IEnumerator Transition()
	{
		_003CTransition_003Ed__42 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator MoveCameraToTarget()
	{
		_003CMoveCameraToTarget_003Ed__43 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void LimitToNumericBoundaries(ref float horizontalPos, ref float verticalPos)
	{
		//IL_00dc: Expected Ref, but got F4
		//IL_01bd: Expected Ref, but got F4
		//IL_0295: Expected Ref, but got F4
		//IL_037c: Expected Ref, but got F4
		ProCamera2DNumericBoundaries numericBoundaries = NumericBoundaries;
		if (numericBoundaries.UseLeftBoundary)
		{
			ProCamera2D proCamera2D = base.ProCamera2D;
			ProCamera2DNumericBoundaries numericBoundaries2 = NumericBoundaries;
			float num = (float)proCamera2D._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 0.5f;
			float num2 = horizontalPos - num;
			if (numericBoundaries2.LeftBoundary > num2)
			{
				ProCamera2D proCamera2D2 = base.ProCamera2D;
				float num3 = (float)proCamera2D2._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 0.5f;
				float num4 = num3 + numericBoundaries2.LeftBoundary;
				ref float reference = ref *(float*)num4;
				goto IL_0381;
			}
		}
		ProCamera2DNumericBoundaries numericBoundaries3 = NumericBoundaries;
		if (numericBoundaries3.UseRightBoundary)
		{
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			ProCamera2DNumericBoundaries numericBoundaries4 = NumericBoundaries;
			float num5 = (float)proCamera2D3._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 0.5f;
			float num6 = num5 + horizontalPos;
			if (num6 > numericBoundaries4.RightBoundary)
			{
				ProCamera2D proCamera2D4 = base.ProCamera2D;
				float num7 = (float)proCamera2D4._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 0.5f;
				float num8 = numericBoundaries4.RightBoundary - num7;
				ref float reference = ref *(float*)num8;
			}
		}
		goto IL_0381;
		IL_0381:
		ProCamera2DNumericBoundaries numericBoundaries5 = NumericBoundaries;
		if (numericBoundaries5.UseBottomBoundary)
		{
			ProCamera2D proCamera2D5 = base.ProCamera2D;
			ProCamera2DNumericBoundaries numericBoundaries6 = NumericBoundaries;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v12 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			float num9 = 0f * 0.5f;
			float num10 = verticalPos - num9;
			if (numericBoundaries6.BottomBoundary > num10)
			{
				ProCamera2D proCamera2D6 = base.ProCamera2D;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v14 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				float num11 = 0f * 0.5f;
				float num12 = num11 + numericBoundaries6.BottomBoundary;
				ref float reference2 = ref *(float*)num12;
				return;
			}
		}
		ProCamera2DNumericBoundaries numericBoundaries7 = NumericBoundaries;
		if (numericBoundaries7.UseTopBoundary)
		{
			ProCamera2D proCamera2D7 = base.ProCamera2D;
			ProCamera2DNumericBoundaries numericBoundaries8 = NumericBoundaries;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rax_v9 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			float num13 = 0f * 0.5f;
			float num14 = num13 + verticalPos;
			if (num14 > numericBoundaries8.TopBoundary)
			{
				ProCamera2D proCamera2D8 = base.ProCamera2D;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v11 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				float num15 = 0f * 0.5f;
				float num16 = numericBoundaries8.TopBoundary - num15;
				ref float reference2 = ref *(float*)num16;
			}
		}
	}

	public ProCamera2DTriggerBoundaries()
	{
		//IL_00af: Expected I, but got O
		AreBoundariesRelative = true;
		TopBoundary = 10f;
		UseBottomBoundary = true;
		BottomBoundary = -10f;
		UseLeftBoundary = true;
		LeftBoundary = -10f;
		UseRightBoundary = true;
		RightBoundary = 10f;
		TransitionDuration = 1f;
		TargetZoom = 1.5f;
		ZoomSmoothness = 1f;
		_poOrder = 1000;
		UpdateInterval = 0.1f;
		UseTargetsMidPoint = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CStart_003Eb__32_0()
	{
		ProCamera2DNumericBoundaries numericBoundaries = NumericBoundaries;
		if (numericBoundaries.OnBoundariesTransitionStarted != null)
		{
			Action onBoundariesTransitionStarted = numericBoundaries.OnBoundariesTransitionStarted;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v30.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void _003CStart_003Eb__32_1()
	{
		ProCamera2DNumericBoundaries numericBoundaries = NumericBoundaries;
		if (numericBoundaries.OnBoundariesTransitionFinished != null)
		{
			Action onBoundariesTransitionFinished = numericBoundaries.OnBoundariesTransitionFinished;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v30.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}
}
