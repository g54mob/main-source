using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class BoundariesAnimator
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Vector3, float> _003C_003E9__16_0;

		public static Func<Vector3, float> _003C_003E9__16_1;

		public static Func<Vector3, float> _003C_003E9__16_2;

		public static Func<Vector3, float> _003C_003E9__16_3;

		public static Func<Vector3, float> _003C_003E9__16_4;

		public static Func<Vector3, float> _003C_003E9__16_5;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003C_002Ector_003Eb__16_0(Vector3 vector)
		{
			return vector.x;
		}

		internal float _003C_002Ector_003Eb__16_1(Vector3 vector)
		{
			return vector.y;
		}

		internal float _003C_002Ector_003Eb__16_2(Vector3 vector)
		{
			return vector.x;
		}

		internal float _003C_002Ector_003Eb__16_3(Vector3 vector)
		{
			return vector.z;
		}

		internal float _003C_002Ector_003Eb__16_4(Vector3 vector)
		{
			return vector.z;
		}

		internal float _003C_002Ector_003Eb__16_5(Vector3 vector)
		{
			return vector.y;
		}
	}

	private sealed class _003CBottomTransitionRoutine_003Ed__22(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BoundariesAnimator _003C_003E4__this;

		public float duration;

		public bool turnOffBoundaryAfterwards;

		private float _003CinitialBottomBoundary_003E5__2;

		private float _003Ct_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_01bb: Expected I4, but got I8
			//IL_06b6: Expected I4, but got O
			//IL_04e3: Expected F4, but got I4
			//IL_071c: Expected O, but got F4
			//IL_0511: Expected F4, but got I4
			//IL_052c: Expected F4, but got O
			BoundariesAnimator boundariesAnimator = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this != null)
				{
					Func<Vector3, float> vector3V = boundariesAnimator.Vector3V;
					if ((object)boundariesAnimator.ProCamera2D != null)
					{
						Vector3 localPosition = boundariesAnimator.ProCamera2D.LocalPosition;
						if (boundariesAnimator.Vector3V != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ rbp_v9 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							ProCamera2D proCamera2D = boundariesAnimator.ProCamera2D;
							if ((object)boundariesAnimator.ProCamera2D != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v32 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
								float num = 0f * 0.5f;
								float num2 = localPosition.x - num;
								_003CinitialBottomBoundary_003E5__2 = num2;
								ProCamera2DNumericBoundaries numericBoundaries = boundariesAnimator.NumericBoundaries;
								if ((object)boundariesAnimator.NumericBoundaries != null)
								{
									numericBoundaries.TargetBottomBoundary = boundariesAnimator.BottomBoundary;
									_003Ct_003E5__3 = 0f;
									float x = localPosition.x;
									goto IL_06b6;
								}
							}
						}
					}
				}
				goto IL_06a8;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				goto IL_06b6;
			}
			goto IL_06d5;
			IL_0311:
			ProCamera2DNumericBoundaries numericBoundaries2 = boundariesAnimator.NumericBoundaries;
			float value;
			if ((object)boundariesAnimator.NumericBoundaries != null)
			{
				float bottomBoundary = Utils.EaseFromTo(_003CinitialBottomBoundary_003E5__2, boundariesAnimator.BottomBoundary, value, boundariesAnimator.TransitionEaseType);
				numericBoundaries2.BottomBoundary = bottomBoundary;
				Func<Vector3, float> vector3V2 = boundariesAnimator.Vector3V;
				if ((object)boundariesAnimator.ProCamera2D != null)
				{
					Vector3 localPosition2 = boundariesAnimator.ProCamera2D.LocalPosition;
					if (boundariesAnimator.Vector3V != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v123 @ rbp_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						ProCamera2D proCamera2D2 = boundariesAnimator.ProCamera2D;
						if ((object)boundariesAnimator.ProCamera2D != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rax_v24 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
							float num3 = 0f * 0.5f;
							ProCamera2DNumericBoundaries numericBoundaries3 = boundariesAnimator.NumericBoundaries;
							float num4 = localPosition2.x - num3;
							if ((object)boundariesAnimator.NumericBoundaries != null)
							{
								if (numericBoundaries3.TargetBottomBoundary > num4 && num4 > numericBoundaries3.BottomBoundary)
								{
									numericBoundaries3.BottomBoundary = num4;
								}
								goto IL_06e3;
							}
						}
					}
				}
			}
			goto IL_06a8;
			IL_06e3:
			ProCamera2D proCamera2D3 = boundariesAnimator.ProCamera2D;
			if ((object)boundariesAnimator.ProCamera2D != null)
			{
				bool flag = proCamera2D3.UpdateType != UpdateType.FixedUpdate;
				float num5 = 0f;
				if (!flag)
				{
					bool flag2 = proCamera2D3.IgnoreTimeScale;
					num5 = 0f;
					if (!flag2)
					{
						num5 = (float)proCamera2D3._waitForFixedUpdate;
					}
				}
				_003C_003E2__current = num5;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_06a8;
			IL_06a8:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_06d5:
			return false;
			IL_06b6:
			if (!(1f < _003Ct_003E5__3))
			{
				if (_003C_003E4__this != null)
				{
					ProCamera2D proCamera2D4 = boundariesAnimator.ProCamera2D;
					if ((object)boundariesAnimator.ProCamera2D != null)
					{
						float num6 = proCamera2D4._003CDeltaTime_003Ek__BackingField / duration;
						value = (_003Ct_003E5__3 = num6 + _003Ct_003E5__3);
						if (boundariesAnimator.UseBottomBoundary)
						{
							if (!boundariesAnimator.UseTopBoundary)
							{
								goto IL_0311;
							}
							if (_003CinitialBottomBoundary_003E5__2 > boundariesAnimator.BottomBoundary)
							{
								ProCamera2DNumericBoundaries numericBoundaries4 = boundariesAnimator.NumericBoundaries;
								if ((object)boundariesAnimator.NumericBoundaries == null)
								{
									goto IL_06a8;
								}
								numericBoundaries4.BottomBoundary = boundariesAnimator.BottomBoundary;
							}
							else if (boundariesAnimator.UseBottomBoundary)
							{
								goto IL_0311;
							}
						}
						goto IL_06e3;
					}
				}
			}
			else if (_003C_003E4__this != null)
			{
				if (turnOffBoundaryAfterwards)
				{
					ProCamera2DNumericBoundaries numericBoundaries5 = boundariesAnimator.NumericBoundaries;
					if ((object)boundariesAnimator.NumericBoundaries == null)
					{
						goto IL_06a8;
					}
					numericBoundaries5.UseBottomBoundary = false;
					boundariesAnimator.UseBottomBoundary = false;
				}
				ProCamera2DNumericBoundaries numericBoundaries6 = boundariesAnimator.NumericBoundaries;
				if ((object)boundariesAnimator.NumericBoundaries != null)
				{
					if (numericBoundaries6.HasFiredTransitionFinished || boundariesAnimator.OnTransitionFinished == null)
					{
						goto IL_06d5;
					}
					numericBoundaries6.HasFiredTransitionStarted = false;
					ProCamera2DNumericBoundaries numericBoundaries7 = boundariesAnimator.NumericBoundaries;
					if ((object)boundariesAnimator.NumericBoundaries != null)
					{
						numericBoundaries7.HasFiredTransitionFinished = true;
						Action onTransitionFinished = boundariesAnimator.OnTransitionFinished;
						if (boundariesAnimator.OnTransitionFinished != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v328.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							goto IL_06d5;
						}
					}
				}
			}
			goto IL_06a8;
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

	private sealed class _003CLeftTransitionRoutine_003Ed__19(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BoundariesAnimator _003C_003E4__this;

		public float duration;

		public bool turnOffBoundaryAfterwards;

		private float _003CinitialLeftBoundary_003E5__2;

		private float _003Ct_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_01b8: Expected I4, but got I8
			//IL_06b0: Expected I4, but got O
			//IL_04dd: Expected F4, but got I4
			//IL_0716: Expected O, but got F4
			//IL_050b: Expected F4, but got I4
			//IL_0526: Expected F4, but got O
			BoundariesAnimator boundariesAnimator = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this != null)
				{
					Func<Vector3, float> vector3H = boundariesAnimator.Vector3H;
					if ((object)boundariesAnimator.ProCamera2D != null)
					{
						Vector3 localPosition = boundariesAnimator.ProCamera2D.LocalPosition;
						if (boundariesAnimator.Vector3H != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ rbp_v9 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							ProCamera2D proCamera2D = boundariesAnimator.ProCamera2D;
							if ((object)boundariesAnimator.ProCamera2D != null)
							{
								float num = (float)proCamera2D._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 0.5f;
								float num2 = localPosition.x - num;
								_003CinitialLeftBoundary_003E5__2 = num2;
								ProCamera2DNumericBoundaries numericBoundaries = boundariesAnimator.NumericBoundaries;
								if ((object)boundariesAnimator.NumericBoundaries != null)
								{
									numericBoundaries.TargetLeftBoundary = boundariesAnimator.LeftBoundary;
									_003Ct_003E5__3 = 0f;
									float x = localPosition.x;
									goto IL_06b0;
								}
							}
						}
					}
				}
				goto IL_06a2;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				goto IL_06b0;
			}
			goto IL_06cf;
			IL_030e:
			ProCamera2DNumericBoundaries numericBoundaries2 = boundariesAnimator.NumericBoundaries;
			float value;
			if ((object)boundariesAnimator.NumericBoundaries != null)
			{
				float leftBoundary = Utils.EaseFromTo(_003CinitialLeftBoundary_003E5__2, boundariesAnimator.LeftBoundary, value, boundariesAnimator.TransitionEaseType);
				numericBoundaries2.LeftBoundary = leftBoundary;
				Func<Vector3, float> vector3H2 = boundariesAnimator.Vector3H;
				if ((object)boundariesAnimator.ProCamera2D != null)
				{
					Vector3 localPosition2 = boundariesAnimator.ProCamera2D.LocalPosition;
					if (boundariesAnimator.Vector3H != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v123 @ rbp_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						ProCamera2D proCamera2D2 = boundariesAnimator.ProCamera2D;
						if ((object)boundariesAnimator.ProCamera2D != null)
						{
							float num3 = (float)proCamera2D2._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 0.5f;
							ProCamera2DNumericBoundaries numericBoundaries3 = boundariesAnimator.NumericBoundaries;
							float num4 = localPosition2.x - num3;
							if ((object)boundariesAnimator.NumericBoundaries != null)
							{
								if (numericBoundaries3.TargetLeftBoundary > num4 && num4 > numericBoundaries3.LeftBoundary)
								{
									numericBoundaries3.LeftBoundary = num4;
								}
								goto IL_06dd;
							}
						}
					}
				}
			}
			goto IL_06a2;
			IL_06dd:
			ProCamera2D proCamera2D3 = boundariesAnimator.ProCamera2D;
			if ((object)boundariesAnimator.ProCamera2D != null)
			{
				bool flag = proCamera2D3.UpdateType != UpdateType.FixedUpdate;
				float num5 = 0f;
				if (!flag)
				{
					bool flag2 = proCamera2D3.IgnoreTimeScale;
					num5 = 0f;
					if (!flag2)
					{
						num5 = (float)proCamera2D3._waitForFixedUpdate;
					}
				}
				_003C_003E2__current = num5;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_06a2;
			IL_06a2:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_06cf:
			return false;
			IL_06b0:
			if (!(1f < _003Ct_003E5__3))
			{
				if (_003C_003E4__this != null)
				{
					ProCamera2D proCamera2D4 = boundariesAnimator.ProCamera2D;
					if ((object)boundariesAnimator.ProCamera2D != null)
					{
						float num6 = proCamera2D4._003CDeltaTime_003Ek__BackingField / duration;
						value = (_003Ct_003E5__3 = num6 + _003Ct_003E5__3);
						if (boundariesAnimator.UseLeftBoundary)
						{
							if (!boundariesAnimator.UseRightBoundary)
							{
								goto IL_030e;
							}
							if (_003CinitialLeftBoundary_003E5__2 > boundariesAnimator.LeftBoundary)
							{
								ProCamera2DNumericBoundaries numericBoundaries4 = boundariesAnimator.NumericBoundaries;
								if ((object)boundariesAnimator.NumericBoundaries == null)
								{
									goto IL_06a2;
								}
								numericBoundaries4.LeftBoundary = boundariesAnimator.LeftBoundary;
							}
							else if (boundariesAnimator.UseLeftBoundary)
							{
								goto IL_030e;
							}
						}
						goto IL_06dd;
					}
				}
			}
			else if (_003C_003E4__this != null)
			{
				if (turnOffBoundaryAfterwards)
				{
					ProCamera2DNumericBoundaries numericBoundaries5 = boundariesAnimator.NumericBoundaries;
					if ((object)boundariesAnimator.NumericBoundaries == null)
					{
						goto IL_06a2;
					}
					numericBoundaries5.UseLeftBoundary = false;
					boundariesAnimator.UseLeftBoundary = false;
				}
				ProCamera2DNumericBoundaries numericBoundaries6 = boundariesAnimator.NumericBoundaries;
				if ((object)boundariesAnimator.NumericBoundaries != null)
				{
					if (numericBoundaries6.HasFiredTransitionFinished || boundariesAnimator.OnTransitionFinished == null)
					{
						goto IL_06cf;
					}
					numericBoundaries6.HasFiredTransitionStarted = false;
					ProCamera2DNumericBoundaries numericBoundaries7 = boundariesAnimator.NumericBoundaries;
					if ((object)boundariesAnimator.NumericBoundaries != null)
					{
						numericBoundaries7.HasFiredTransitionFinished = true;
						Action onTransitionFinished = boundariesAnimator.OnTransitionFinished;
						if (boundariesAnimator.OnTransitionFinished != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v328.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							goto IL_06cf;
						}
					}
				}
			}
			goto IL_06a2;
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

	private sealed class _003CRightTransitionRoutine_003Ed__20(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BoundariesAnimator _003C_003E4__this;

		public float duration;

		public bool turnOffBoundaryAfterwards;

		private float _003CinitialRightBoundary_003E5__2;

		private float _003Ct_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_01b8: Expected I4, but got I8
			//IL_06b0: Expected I4, but got O
			//IL_04dd: Expected F4, but got I4
			//IL_0716: Expected O, but got F4
			//IL_050b: Expected F4, but got I4
			//IL_0526: Expected F4, but got O
			BoundariesAnimator boundariesAnimator = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this != null)
				{
					Func<Vector3, float> vector3H = boundariesAnimator.Vector3H;
					if ((object)boundariesAnimator.ProCamera2D != null)
					{
						Vector3 localPosition = boundariesAnimator.ProCamera2D.LocalPosition;
						if (boundariesAnimator.Vector3H != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ rbp_v9 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							ProCamera2D proCamera2D = boundariesAnimator.ProCamera2D;
							if ((object)boundariesAnimator.ProCamera2D != null)
							{
								float num = (float)proCamera2D._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 0.5f;
								float num2 = num + localPosition.x;
								_003CinitialRightBoundary_003E5__2 = num2;
								ProCamera2DNumericBoundaries numericBoundaries = boundariesAnimator.NumericBoundaries;
								if ((object)boundariesAnimator.NumericBoundaries != null)
								{
									numericBoundaries.TargetRightBoundary = boundariesAnimator.RightBoundary;
									_003Ct_003E5__3 = 0f;
									float x = localPosition.x;
									goto IL_06b0;
								}
							}
						}
					}
				}
				goto IL_06a2;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				goto IL_06b0;
			}
			goto IL_06cf;
			IL_030e:
			ProCamera2DNumericBoundaries numericBoundaries2 = boundariesAnimator.NumericBoundaries;
			float value;
			if ((object)boundariesAnimator.NumericBoundaries != null)
			{
				float rightBoundary = Utils.EaseFromTo(_003CinitialRightBoundary_003E5__2, boundariesAnimator.RightBoundary, value, boundariesAnimator.TransitionEaseType);
				numericBoundaries2.RightBoundary = rightBoundary;
				Func<Vector3, float> vector3H2 = boundariesAnimator.Vector3H;
				if ((object)boundariesAnimator.ProCamera2D != null)
				{
					Vector3 localPosition2 = boundariesAnimator.ProCamera2D.LocalPosition;
					if (boundariesAnimator.Vector3H != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v119 @ rbp_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						ProCamera2D proCamera2D2 = boundariesAnimator.ProCamera2D;
						if ((object)boundariesAnimator.ProCamera2D != null)
						{
							float num3 = (float)proCamera2D2._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 0.5f;
							ProCamera2DNumericBoundaries numericBoundaries3 = boundariesAnimator.NumericBoundaries;
							float num4 = num3 + localPosition2.x;
							if ((object)boundariesAnimator.NumericBoundaries != null)
							{
								if (num4 > numericBoundaries3.TargetRightBoundary && numericBoundaries3.RightBoundary > num4)
								{
									numericBoundaries3.RightBoundary = num4;
								}
								goto IL_06dd;
							}
						}
					}
				}
			}
			goto IL_06a2;
			IL_06dd:
			ProCamera2D proCamera2D3 = boundariesAnimator.ProCamera2D;
			if ((object)boundariesAnimator.ProCamera2D != null)
			{
				bool flag = proCamera2D3.UpdateType != UpdateType.FixedUpdate;
				float num5 = 0f;
				if (!flag)
				{
					bool flag2 = proCamera2D3.IgnoreTimeScale;
					num5 = 0f;
					if (!flag2)
					{
						num5 = (float)proCamera2D3._waitForFixedUpdate;
					}
				}
				_003C_003E2__current = num5;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_06a2;
			IL_06a2:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_06cf:
			return false;
			IL_06b0:
			if (!(1f < _003Ct_003E5__3))
			{
				if (_003C_003E4__this != null)
				{
					ProCamera2D proCamera2D4 = boundariesAnimator.ProCamera2D;
					if ((object)boundariesAnimator.ProCamera2D != null)
					{
						float num6 = proCamera2D4._003CDeltaTime_003Ek__BackingField / duration;
						value = (_003Ct_003E5__3 = num6 + _003Ct_003E5__3);
						if (boundariesAnimator.UseRightBoundary)
						{
							if (!boundariesAnimator.UseLeftBoundary)
							{
								goto IL_030e;
							}
							if (boundariesAnimator.RightBoundary > _003CinitialRightBoundary_003E5__2)
							{
								ProCamera2DNumericBoundaries numericBoundaries4 = boundariesAnimator.NumericBoundaries;
								if ((object)boundariesAnimator.NumericBoundaries == null)
								{
									goto IL_06a2;
								}
								numericBoundaries4.RightBoundary = boundariesAnimator.RightBoundary;
							}
							else if (boundariesAnimator.UseRightBoundary)
							{
								goto IL_030e;
							}
						}
						goto IL_06dd;
					}
				}
			}
			else if (_003C_003E4__this != null)
			{
				if (turnOffBoundaryAfterwards)
				{
					ProCamera2DNumericBoundaries numericBoundaries5 = boundariesAnimator.NumericBoundaries;
					if ((object)boundariesAnimator.NumericBoundaries == null)
					{
						goto IL_06a2;
					}
					numericBoundaries5.UseRightBoundary = false;
					boundariesAnimator.UseRightBoundary = false;
				}
				ProCamera2DNumericBoundaries numericBoundaries6 = boundariesAnimator.NumericBoundaries;
				if ((object)boundariesAnimator.NumericBoundaries != null)
				{
					if (numericBoundaries6.HasFiredTransitionFinished || boundariesAnimator.OnTransitionFinished == null)
					{
						goto IL_06cf;
					}
					numericBoundaries6.HasFiredTransitionStarted = false;
					ProCamera2DNumericBoundaries numericBoundaries7 = boundariesAnimator.NumericBoundaries;
					if ((object)boundariesAnimator.NumericBoundaries != null)
					{
						numericBoundaries7.HasFiredTransitionFinished = true;
						Action onTransitionFinished = boundariesAnimator.OnTransitionFinished;
						if (boundariesAnimator.OnTransitionFinished != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v324.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							goto IL_06cf;
						}
					}
				}
			}
			goto IL_06a2;
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

	private sealed class _003CTopTransitionRoutine_003Ed__21(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BoundariesAnimator _003C_003E4__this;

		public float duration;

		public bool turnOffBoundaryAfterwards;

		private float _003CinitialTopBoundary_003E5__2;

		private float _003Ct_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_01bb: Expected I4, but got I8
			//IL_06b6: Expected I4, but got O
			//IL_04e3: Expected F4, but got I4
			//IL_071c: Expected O, but got F4
			//IL_0511: Expected F4, but got I4
			//IL_052c: Expected F4, but got O
			BoundariesAnimator boundariesAnimator = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this != null)
				{
					Func<Vector3, float> vector3V = boundariesAnimator.Vector3V;
					if ((object)boundariesAnimator.ProCamera2D != null)
					{
						Vector3 localPosition = boundariesAnimator.ProCamera2D.LocalPosition;
						if (boundariesAnimator.Vector3V != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ rbp_v9 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							ProCamera2D proCamera2D = boundariesAnimator.ProCamera2D;
							if ((object)boundariesAnimator.ProCamera2D != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rax_v32 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
								float num = 0f * 0.5f;
								float num2 = num + localPosition.x;
								_003CinitialTopBoundary_003E5__2 = num2;
								ProCamera2DNumericBoundaries numericBoundaries = boundariesAnimator.NumericBoundaries;
								if ((object)boundariesAnimator.NumericBoundaries != null)
								{
									numericBoundaries.TargetTopBoundary = boundariesAnimator.TopBoundary;
									_003Ct_003E5__3 = 0f;
									float x = localPosition.x;
									goto IL_06b6;
								}
							}
						}
					}
				}
				goto IL_06a8;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				goto IL_06b6;
			}
			goto IL_06d5;
			IL_0311:
			ProCamera2DNumericBoundaries numericBoundaries2 = boundariesAnimator.NumericBoundaries;
			float value;
			if ((object)boundariesAnimator.NumericBoundaries != null)
			{
				float topBoundary = Utils.EaseFromTo(_003CinitialTopBoundary_003E5__2, boundariesAnimator.TopBoundary, value, boundariesAnimator.TransitionEaseType);
				numericBoundaries2.TopBoundary = topBoundary;
				Func<Vector3, float> vector3V2 = boundariesAnimator.Vector3V;
				if ((object)boundariesAnimator.ProCamera2D != null)
				{
					Vector3 localPosition2 = boundariesAnimator.ProCamera2D.LocalPosition;
					if (boundariesAnimator.Vector3V != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v119 @ rbp_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						ProCamera2D proCamera2D2 = boundariesAnimator.ProCamera2D;
						if ((object)boundariesAnimator.ProCamera2D != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v24 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
							float num3 = 0f * 0.5f;
							ProCamera2DNumericBoundaries numericBoundaries3 = boundariesAnimator.NumericBoundaries;
							float num4 = num3 + localPosition2.x;
							if ((object)boundariesAnimator.NumericBoundaries != null)
							{
								if (num4 > numericBoundaries3.TargetTopBoundary && numericBoundaries3.TopBoundary > num4)
								{
									numericBoundaries3.TopBoundary = num4;
								}
								goto IL_06e3;
							}
						}
					}
				}
			}
			goto IL_06a8;
			IL_06e3:
			ProCamera2D proCamera2D3 = boundariesAnimator.ProCamera2D;
			if ((object)boundariesAnimator.ProCamera2D != null)
			{
				bool flag = proCamera2D3.UpdateType != UpdateType.FixedUpdate;
				float num5 = 0f;
				if (!flag)
				{
					bool flag2 = proCamera2D3.IgnoreTimeScale;
					num5 = 0f;
					if (!flag2)
					{
						num5 = (float)proCamera2D3._waitForFixedUpdate;
					}
				}
				_003C_003E2__current = num5;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_06a8;
			IL_06a8:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_06d5:
			return false;
			IL_06b6:
			if (!(1f < _003Ct_003E5__3))
			{
				if (_003C_003E4__this != null)
				{
					ProCamera2D proCamera2D4 = boundariesAnimator.ProCamera2D;
					if ((object)boundariesAnimator.ProCamera2D != null)
					{
						float num6 = proCamera2D4._003CDeltaTime_003Ek__BackingField / duration;
						value = (_003Ct_003E5__3 = num6 + _003Ct_003E5__3);
						if (boundariesAnimator.UseTopBoundary)
						{
							if (!boundariesAnimator.UseBottomBoundary)
							{
								goto IL_0311;
							}
							if (boundariesAnimator.TopBoundary > _003CinitialTopBoundary_003E5__2)
							{
								ProCamera2DNumericBoundaries numericBoundaries4 = boundariesAnimator.NumericBoundaries;
								if ((object)boundariesAnimator.NumericBoundaries == null)
								{
									goto IL_06a8;
								}
								numericBoundaries4.TopBoundary = boundariesAnimator.TopBoundary;
							}
							else if (boundariesAnimator.UseTopBoundary)
							{
								goto IL_0311;
							}
						}
						goto IL_06e3;
					}
				}
			}
			else if (_003C_003E4__this != null)
			{
				if (turnOffBoundaryAfterwards)
				{
					ProCamera2DNumericBoundaries numericBoundaries5 = boundariesAnimator.NumericBoundaries;
					if ((object)boundariesAnimator.NumericBoundaries == null)
					{
						goto IL_06a8;
					}
					numericBoundaries5.UseTopBoundary = false;
					boundariesAnimator.UseTopBoundary = false;
				}
				ProCamera2DNumericBoundaries numericBoundaries6 = boundariesAnimator.NumericBoundaries;
				if ((object)boundariesAnimator.NumericBoundaries != null)
				{
					if (numericBoundaries6.HasFiredTransitionFinished || boundariesAnimator.OnTransitionFinished == null)
					{
						goto IL_06d5;
					}
					numericBoundaries6.HasFiredTransitionStarted = false;
					ProCamera2DNumericBoundaries numericBoundaries7 = boundariesAnimator.NumericBoundaries;
					if ((object)boundariesAnimator.NumericBoundaries != null)
					{
						numericBoundaries7.HasFiredTransitionFinished = true;
						Action onTransitionFinished = boundariesAnimator.OnTransitionFinished;
						if (boundariesAnimator.OnTransitionFinished != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v324.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							goto IL_06d5;
						}
					}
				}
			}
			goto IL_06a8;
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

	public Action OnTransitionStarted;

	public Action OnTransitionFinished;

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

	private ProCamera2D ProCamera2D;

	private ProCamera2DNumericBoundaries NumericBoundaries;

	private Func<Vector3, float> Vector3H;

	private Func<Vector3, float> Vector3V;

	public BoundariesAnimator(ProCamera2D proCamera2D, ProCamera2DNumericBoundaries numericBoundaries)
	{
		//IL_0058: Expected O, but got I4
		TransitionDuration = 1f;
		ProCamera2D = proCamera2D;
		NumericBoundaries = numericBoundaries;
		ProCamera2D proCamera2D2 = ProCamera2D;
		bool flag = proCamera2D2.Axis == MovementAxis.XY;
		if (!flag)
		{
			object obj = proCamera2D2.Axis - 1;
			if (!flag)
			{
				if ((nint)obj == 1)
				{
					Func<Vector3, float> vector3H = _003C_003Ec._003C_003E9__16_4;
					if (_003C_003Ec._003C_003E9__16_4 == null)
					{
						Func<Vector3, float> func = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F4E40");
						_003C_003Ec._003C_003E9__16_4 = func;
						vector3H = func;
					}
					Vector3H = vector3H;
					Func<Vector3, float> vector3V = _003C_003Ec._003C_003E9__16_5;
					if (_003C_003Ec._003C_003E9__16_5 == null)
					{
						Func<Vector3, float> func2 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F4E40");
						_003C_003Ec._003C_003E9__16_5 = func2;
						vector3V = func2;
					}
					Vector3V = vector3V;
				}
			}
			else
			{
				Func<Vector3, float> vector3H2 = _003C_003Ec._003C_003E9__16_2;
				if (_003C_003Ec._003C_003E9__16_2 == null)
				{
					Func<Vector3, float> func3 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F4E40");
					_003C_003Ec._003C_003E9__16_2 = func3;
					vector3H2 = func3;
				}
				Vector3H = vector3H2;
				Func<Vector3, float> vector3V2 = _003C_003Ec._003C_003E9__16_3;
				if (_003C_003Ec._003C_003E9__16_3 == null)
				{
					Func<Vector3, float> func4 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F4E40");
					_003C_003Ec._003C_003E9__16_3 = func4;
					vector3V2 = func4;
				}
				Vector3V = vector3V2;
			}
		}
		else
		{
			Func<Vector3, float> vector3H3 = _003C_003Ec._003C_003E9__16_0;
			if (_003C_003Ec._003C_003E9__16_0 == null)
			{
				Func<Vector3, float> func5 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F4E40");
				_003C_003Ec._003C_003E9__16_0 = func5;
				vector3H3 = func5;
			}
			Vector3H = vector3H3;
			Func<Vector3, float> vector3V3 = _003C_003Ec._003C_003E9__16_1;
			if (_003C_003Ec._003C_003E9__16_1 == null)
			{
				Func<Vector3, float> func6 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F4E40");
				_003C_003Ec._003C_003E9__16_1 = func6;
				vector3V3 = func6;
			}
			Vector3V = vector3V3;
		}
	}

	public int GetAnimsCount()
	{
		//IL_0313: Expected I4, but got O
		int num;
		if (!UseLeftBoundary)
		{
			ProCamera2DNumericBoundaries numericBoundaries = NumericBoundaries;
			if ((object)NumericBoundaries == null)
			{
				goto IL_0305;
			}
			bool flag = !numericBoundaries.UseLeftBoundary;
			num = 0;
			if (!flag)
			{
				bool flag2 = !UseRightBoundary;
				num = 0;
				if (!flag2)
				{
					bool flag3 = !(numericBoundaries.TargetLeftBoundary > RightBoundary);
					num = 0;
					if (!flag3)
					{
						num = 1;
					}
					goto IL_0191;
				}
			}
		}
		else
		{
			num = 1;
		}
		if (UseRightBoundary)
		{
			goto IL_0191;
		}
		ProCamera2DNumericBoundaries numericBoundaries2 = NumericBoundaries;
		if ((object)NumericBoundaries == null)
		{
			goto IL_0305;
		}
		bool flag4 = !numericBoundaries2.UseRightBoundary;
		int num2 = num;
		if (!flag4)
		{
			bool flag5 = !UseLeftBoundary;
			num2 = num;
			if (!flag5)
			{
				bool flag6 = !(LeftBoundary > numericBoundaries2.TargetRightBoundary);
				num2 = num;
				if (!flag6)
				{
					goto IL_0191;
				}
			}
		}
		goto IL_0335;
		IL_0394:
		return num2;
		IL_0381:
		int num3;
		num2 = num3 + 1;
		goto IL_0394;
		IL_0191:
		num2 = num + 1;
		goto IL_0335;
		IL_0335:
		if (!UseTopBoundary)
		{
			ProCamera2DNumericBoundaries numericBoundaries3 = NumericBoundaries;
			if ((object)NumericBoundaries == null)
			{
				goto IL_0305;
			}
			if (numericBoundaries3.UseTopBoundary)
			{
				if (!UseBottomBoundary)
				{
					goto IL_0262;
				}
				bool flag7 = !(BottomBoundary > numericBoundaries3.TargetTopBoundary);
				num3 = num2;
				if (!flag7)
				{
					num3 = num2 + 1;
				}
				goto IL_0381;
			}
		}
		else
		{
			num2++;
		}
		bool flag8 = UseBottomBoundary;
		num3 = num2;
		if (!flag8)
		{
			goto IL_0262;
		}
		goto IL_0381;
		IL_0262:
		ProCamera2DNumericBoundaries numericBoundaries4 = NumericBoundaries;
		if ((object)NumericBoundaries == null)
		{
			goto IL_0305;
		}
		if (numericBoundaries4.UseBottomBoundary && UseTopBoundary && numericBoundaries4.TargetBottomBoundary > TopBoundary)
		{
			return num2 + 1;
		}
		goto IL_0394;
		IL_0305:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public void Transition()
	{
		//IL_0285: Expected O, but got I
		//IL_049c: Expected O, but got I
		//IL_01de: Expected O, but got I
		//IL_06b6: Expected O, but got I
		//IL_03f5: Expected O, but got I
		//IL_08cc: Expected O, but got I
		//IL_060f: Expected O, but got I
		//IL_0829: Expected O, but got I
		ProCamera2DNumericBoundaries numericBoundaries = NumericBoundaries;
		if (!numericBoundaries.HasFiredTransitionStarted && OnTransitionStarted != null)
		{
			numericBoundaries.HasFiredTransitionStarted = true;
			Action onTransitionStarted = OnTransitionStarted;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v514.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		ProCamera2DNumericBoundaries numericBoundaries2 = NumericBoundaries;
		numericBoundaries2.HasFiredTransitionFinished = false;
		ProCamera2DNumericBoundaries numericBoundaries3 = NumericBoundaries;
		numericBoundaries3.UseNumericBoundaries = true;
		ProCamera2DNumericBoundaries numericBoundaries4 = NumericBoundaries;
		if (!UseLeftBoundary)
		{
			if (numericBoundaries4.UseLeftBoundary && UseRightBoundary)
			{
				if (numericBoundaries4.TargetLeftBoundary > RightBoundary)
				{
					numericBoundaries4.UseLeftBoundary = true;
					ProCamera2D proCamera2D = ProCamera2D;
					UseLeftBoundary = true;
					MonoBehaviour numericBoundaries5 = NumericBoundaries;
					float num = (float)proCamera2D._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 100f;
					float leftBoundary = RightBoundary - num;
					LeftBoundary = leftBoundary;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v81 (UnityEngine.MonoBehaviour)+B8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v81 (UnityEngine.MonoBehaviour)+B8]");
						numericBoundaries5.StopCoroutine((Coroutine)0);
					}
					IEnumerator routine = LeftTransitionRoutine(TransitionDuration, turnOffBoundaryAfterwards: true);
					Coroutine coroutine = NumericBoundaries.StartCoroutine(routine);
					goto IL_02c1;
				}
			}
			else
			{
				numericBoundaries4 = NumericBoundaries;
			}
			numericBoundaries4.UseLeftBoundary = false;
		}
		else
		{
			numericBoundaries4.UseLeftBoundary = true;
			MonoBehaviour numericBoundaries6 = NumericBoundaries;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rax_v69 (UnityEngine.MonoBehaviour)+B8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rax_v69 (UnityEngine.MonoBehaviour)+B8]");
				numericBoundaries6.StopCoroutine((Coroutine)0);
			}
			IEnumerator routine2 = LeftTransitionRoutine(TransitionDuration);
			Coroutine coroutine2 = NumericBoundaries.StartCoroutine(routine2);
		}
		goto IL_02c1;
		IL_06f2:
		ProCamera2DNumericBoundaries numericBoundaries7 = NumericBoundaries;
		if (!UseBottomBoundary)
		{
			if (numericBoundaries7.UseBottomBoundary && UseTopBoundary)
			{
				if (numericBoundaries7.TargetBottomBoundary > TopBoundary)
				{
					numericBoundaries7.UseBottomBoundary = true;
					ProCamera2D proCamera2D2 = ProCamera2D;
					UseBottomBoundary = true;
					MonoBehaviour numericBoundaries8 = NumericBoundaries;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ rax_v26 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
					float num2 = 0f * 100f;
					float bottomBoundary = TopBoundary - num2;
					BottomBoundary = bottomBoundary;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rax_v27 (UnityEngine.MonoBehaviour)+B0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rax_v27 (UnityEngine.MonoBehaviour)+B0]");
						numericBoundaries8.StopCoroutine((Coroutine)0);
					}
					IEnumerator routine3 = BottomTransitionRoutine(TransitionDuration, turnOffBoundaryAfterwards: true);
					Coroutine coroutine3 = NumericBoundaries.StartCoroutine(routine3);
					return;
				}
			}
			else
			{
				numericBoundaries7 = NumericBoundaries;
			}
			numericBoundaries7.UseBottomBoundary = false;
		}
		else
		{
			numericBoundaries7.UseBottomBoundary = true;
			MonoBehaviour numericBoundaries9 = NumericBoundaries;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v14 (UnityEngine.MonoBehaviour)+B0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v14 (UnityEngine.MonoBehaviour)+B0]");
				numericBoundaries9.StopCoroutine((Coroutine)0);
			}
			IEnumerator routine4 = BottomTransitionRoutine(TransitionDuration);
			Coroutine coroutine4 = NumericBoundaries.StartCoroutine(routine4);
		}
		return;
		IL_04d8:
		ProCamera2DNumericBoundaries numericBoundaries10 = NumericBoundaries;
		if (!UseTopBoundary)
		{
			if (numericBoundaries10.UseTopBoundary && UseBottomBoundary)
			{
				if (BottomBoundary > numericBoundaries10.TargetTopBoundary)
				{
					numericBoundaries10.UseTopBoundary = true;
					ProCamera2D proCamera2D3 = ProCamera2D;
					UseTopBoundary = true;
					MonoBehaviour numericBoundaries11 = NumericBoundaries;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v44 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
					float num3 = 0f * 100f;
					float topBoundary = num3 + BottomBoundary;
					TopBoundary = topBoundary;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rax_v45 (UnityEngine.MonoBehaviour)+A8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rax_v45 (UnityEngine.MonoBehaviour)+A8]");
						numericBoundaries11.StopCoroutine((Coroutine)0);
					}
					IEnumerator routine5 = TopTransitionRoutine(TransitionDuration, turnOffBoundaryAfterwards: true);
					Coroutine coroutine5 = NumericBoundaries.StartCoroutine(routine5);
					goto IL_06f2;
				}
			}
			else
			{
				numericBoundaries10 = NumericBoundaries;
			}
			numericBoundaries10.UseTopBoundary = false;
		}
		else
		{
			numericBoundaries10.UseTopBoundary = true;
			MonoBehaviour numericBoundaries12 = NumericBoundaries;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rax_v33 (UnityEngine.MonoBehaviour)+A8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rax_v33 (UnityEngine.MonoBehaviour)+A8]");
				numericBoundaries12.StopCoroutine((Coroutine)0);
			}
			IEnumerator routine6 = TopTransitionRoutine(TransitionDuration);
			Coroutine coroutine6 = NumericBoundaries.StartCoroutine(routine6);
		}
		goto IL_06f2;
		IL_02c1:
		ProCamera2DNumericBoundaries numericBoundaries13 = NumericBoundaries;
		if (!UseRightBoundary)
		{
			if (numericBoundaries13.UseRightBoundary && UseLeftBoundary)
			{
				if (LeftBoundary > numericBoundaries13.TargetRightBoundary)
				{
					numericBoundaries13.UseRightBoundary = true;
					ProCamera2D proCamera2D4 = ProCamera2D;
					UseRightBoundary = true;
					MonoBehaviour numericBoundaries14 = NumericBoundaries;
					float num4 = (float)proCamera2D4._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 100f;
					float rightBoundary = num4 + LeftBoundary;
					RightBoundary = rightBoundary;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v63 (UnityEngine.MonoBehaviour)+C0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v63 (UnityEngine.MonoBehaviour)+C0]");
						numericBoundaries14.StopCoroutine((Coroutine)0);
					}
					IEnumerator routine7 = RightTransitionRoutine(TransitionDuration, turnOffBoundaryAfterwards: true);
					Coroutine coroutine7 = NumericBoundaries.StartCoroutine(routine7);
					goto IL_04d8;
				}
			}
			else
			{
				numericBoundaries13 = NumericBoundaries;
			}
			numericBoundaries13.UseRightBoundary = false;
		}
		else
		{
			numericBoundaries13.UseRightBoundary = true;
			MonoBehaviour numericBoundaries15 = NumericBoundaries;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v51 (UnityEngine.MonoBehaviour)+C0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v51 (UnityEngine.MonoBehaviour)+C0]");
				numericBoundaries15.StopCoroutine((Coroutine)0);
			}
			IEnumerator routine8 = RightTransitionRoutine(TransitionDuration);
			Coroutine coroutine8 = NumericBoundaries.StartCoroutine(routine8);
		}
		goto IL_04d8;
	}

	private IEnumerator LeftTransitionRoutine(float duration, bool turnOffBoundaryAfterwards = false)
	{
		_003CLeftTransitionRoutine_003Ed__19 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.duration = duration;
		obj.turnOffBoundaryAfterwards = turnOffBoundaryAfterwards;
		return obj;
	}

	private IEnumerator RightTransitionRoutine(float duration, bool turnOffBoundaryAfterwards = false)
	{
		_003CRightTransitionRoutine_003Ed__20 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.duration = duration;
		obj.turnOffBoundaryAfterwards = turnOffBoundaryAfterwards;
		return obj;
	}

	private IEnumerator TopTransitionRoutine(float duration, bool turnOffBoundaryAfterwards = false)
	{
		_003CTopTransitionRoutine_003Ed__21 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.duration = duration;
		obj.turnOffBoundaryAfterwards = turnOffBoundaryAfterwards;
		return obj;
	}

	private IEnumerator BottomTransitionRoutine(float duration, bool turnOffBoundaryAfterwards = false)
	{
		_003CBottomTransitionRoutine_003Ed__22 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.duration = duration;
		obj.turnOffBoundaryAfterwards = turnOffBoundaryAfterwards;
		return obj;
	}
}
