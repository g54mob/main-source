using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2D : MonoBehaviour, ISerializationCallbackReceiver
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Vector3, float> _003C_003E9__130_0;

		public static Func<Vector3, float> _003C_003E9__130_1;

		public static Func<Vector3, float> _003C_003E9__130_2;

		public static Func<float, float, Vector3> _003C_003E9__130_3;

		public static Func<float, float, float, Vector3> _003C_003E9__130_4;

		public static Func<Vector3, float> _003C_003E9__130_5;

		public static Func<Vector3, float> _003C_003E9__130_6;

		public static Func<Vector3, float> _003C_003E9__130_7;

		public static Func<float, float, Vector3> _003C_003E9__130_8;

		public static Func<float, float, float, Vector3> _003C_003E9__130_9;

		public static Func<Vector3, float> _003C_003E9__130_10;

		public static Func<Vector3, float> _003C_003E9__130_11;

		public static Func<Vector3, float> _003C_003E9__130_12;

		public static Func<float, float, Vector3> _003C_003E9__130_13;

		public static Func<float, float, float, Vector3> _003C_003E9__130_14;

		public static Func<IPreMover, int> _003C_003E9__141_0;

		public static Func<IPositionDeltaChanger, int> _003C_003E9__144_0;

		public static Func<IPositionOverrider, int> _003C_003E9__147_0;

		public static Func<ISizeDeltaChanger, int> _003C_003E9__150_0;

		public static Func<ISizeOverrider, int> _003C_003E9__153_0;

		public static Func<IPostMover, int> _003C_003E9__156_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003CResetAxisFunctions_003Eb__130_0(Vector3 vector)
		{
			return vector.x;
		}

		internal float _003CResetAxisFunctions_003Eb__130_1(Vector3 vector)
		{
			return vector.y;
		}

		internal float _003CResetAxisFunctions_003Eb__130_2(Vector3 vector)
		{
			return vector.z;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__130_3(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->y = v;
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__130_4(float h, float v, float d)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0022: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			float z = default(float);
			((Vector3*)(nint)vector)->z = z;
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->y = v;
			return vector;
		}

		internal float _003CResetAxisFunctions_003Eb__130_5(Vector3 vector)
		{
			return vector.x;
		}

		internal float _003CResetAxisFunctions_003Eb__130_6(Vector3 vector)
		{
			return vector.z;
		}

		internal float _003CResetAxisFunctions_003Eb__130_7(Vector3 vector)
		{
			return vector.y;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__130_8(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->z = v;
			((Vector3*)(nint)vector)->y = 0f;
			return vector;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__130_9(float h, float v, float d)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0022: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			float y = default(float);
			((Vector3*)(nint)vector)->y = y;
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->z = v;
			return vector;
		}

		internal float _003CResetAxisFunctions_003Eb__130_10(Vector3 vector)
		{
			return vector.z;
		}

		internal float _003CResetAxisFunctions_003Eb__130_11(Vector3 vector)
		{
			return vector.y;
		}

		internal float _003CResetAxisFunctions_003Eb__130_12(Vector3 vector)
		{
			return vector.x;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__130_13(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->y = v;
			((Vector3*)(nint)vector)->z = h;
			((Vector3*)(nint)vector)->x = 0f;
			return vector;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__130_14(float h, float v, float d)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0022: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			float x = default(float);
			((Vector3*)(nint)vector)->x = x;
			((Vector3*)(nint)vector)->y = v;
			((Vector3*)(nint)vector)->z = h;
			return vector;
		}

		internal int _003CSortPreMovers_003Eb__141_0(IPreMover a)
		{
			//IL_0022: Expected I4, but got O
			if (a != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal int _003CSortPositionDeltaChangers_003Eb__144_0(IPositionDeltaChanger a)
		{
			//IL_0022: Expected I4, but got O
			if (a != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal int _003CSortPositionOverriders_003Eb__147_0(IPositionOverrider a)
		{
			//IL_0022: Expected I4, but got O
			if (a != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal int _003CSortSizeDeltaChangers_003Eb__150_0(ISizeDeltaChanger a)
		{
			//IL_0022: Expected I4, but got O
			if (a != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal int _003CSortSizeOverriders_003Eb__153_0(ISizeOverrider a)
		{
			//IL_0022: Expected I4, but got O
			if (a != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal int _003CSortPostMovers_003Eb__156_0(IPostMover a)
		{
			//IL_0022: Expected I4, but got O
			if (a != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private sealed class _003CAdjustTargetInfluenceRoutine_003Ed__134(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public CameraTarget cameraTarget;

		public ProCamera2D _003C_003E4__this;

		public float duration;

		public float influenceH;

		public float influenceV;

		public bool removeIfZeroInfluence;

		private float _003CstartInfluenceH_003E5__2;

		private float _003CstartInfluenceV_003E5__3;

		private float _003Ct_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_001e: Expected I4, but got I8
			//IL_00c5: Expected I4, but got I8
			//IL_0467: Expected I4, but got O
			//IL_012d: Invalid comparison between I4 and F4
			//IL_0178: Expected F4, but got I4
			//IL_04bb: Invalid comparison between I4 and F4
			//IL_01b4: Expected F4, but got I4
			//IL_0218: Invalid comparison between I4 and F4
			//IL_0263: Expected F4, but got I4
			//IL_04f7: Invalid comparison between I4 and F4
			//IL_029f: Expected F4, but got I4
			//IL_0304: Expected F4, but got I4
			//IL_0534: Expected O, but got F4
			//IL_0332: Expected F4, but got I4
			//IL_034d: Expected F4, but got O
			ProCamera2D proCamera2D = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				CameraTarget cameraTarget = this.cameraTarget;
				_003C_003E1__state = -1;
				if (this.cameraTarget != null)
				{
					_003CstartInfluenceH_003E5__2 = cameraTarget.TargetInfluenceH;
					CameraTarget cameraTarget2 = this.cameraTarget;
					if (this.cameraTarget != null)
					{
						_003CstartInfluenceV_003E5__3 = cameraTarget2.TargetInfluenceV;
						_003Ct_003E5__4 = 0f;
						goto IL_0493;
					}
				}
				goto IL_0459;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_0453;
			}
			_003C_003E1__state = -1;
			goto IL_0493;
			IL_0453:
			return false;
			IL_0459:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0493:
			if (!(1f < _003Ct_003E5__4))
			{
				if ((object)_003C_003E4__this != null)
				{
					float num = proCamera2D._003CDeltaTime_003Ek__BackingField / duration;
					CameraTarget cameraTarget3 = this.cameraTarget;
					float num2 = (_003Ct_003E5__4 = num + _003Ct_003E5__4);
					if (!(0f > num2))
					{
						if (num2 > 1f)
						{
							num2 = 1f;
						}
					}
					else
					{
						num2 = 0f;
					}
					if (!(0f > num2))
					{
						if (num2 > 1f)
						{
							num2 = 1f;
						}
					}
					else
					{
						num2 = 0f;
					}
					if (this.cameraTarget != null)
					{
						float num3 = influenceH - _003CstartInfluenceH_003E5__2;
						float num4 = num3 * num2;
						float targetInfluenceH = num4 + _003CstartInfluenceH_003E5__2;
						cameraTarget3.TargetInfluenceH = targetInfluenceH;
						float num5 = _003Ct_003E5__4;
						CameraTarget cameraTarget4 = this.cameraTarget;
						if (!(0f > _003Ct_003E5__4))
						{
							if (num5 > 1f)
							{
								num5 = 1f;
							}
						}
						else
						{
							num5 = 0f;
						}
						if (!(0f > num5))
						{
							if (num5 > 1f)
							{
								num5 = 1f;
							}
						}
						else
						{
							num5 = 0f;
						}
						if (this.cameraTarget != null)
						{
							float num6 = influenceV - _003CstartInfluenceV_003E5__3;
							float num7 = num6 * num5;
							float targetInfluenceV = num7 + _003CstartInfluenceV_003E5__3;
							cameraTarget4.TargetInfluenceV = targetInfluenceV;
							bool flag = proCamera2D.UpdateType != UpdateType.FixedUpdate;
							float num8 = 0f;
							if (!flag)
							{
								bool flag2 = proCamera2D.IgnoreTimeScale;
								num8 = 0f;
								if (!flag2)
								{
									num8 = (float)proCamera2D._waitForFixedUpdate;
								}
							}
							_003C_003E2__current = num8;
							_003C_003E1__state = 1;
							return true;
						}
					}
				}
				goto IL_0459;
			}
			if (removeIfZeroInfluence)
			{
				object obj = this.cameraTarget;
				if (this.cameraTarget == null)
				{
					goto IL_0459;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v4 (System.Object)+18]");
				if ((nint)0 >= (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v4 (System.Object)+1C]");
					if ((nint)0 >= (nint)0)
					{
						if ((object)_003C_003E4__this == null || proCamera2D.CameraTargets == null)
						{
							goto IL_0459;
						}
						bool flag3 = ((List<object>)(object)proCamera2D.CameraTargets).Remove((object)this.cameraTarget);
					}
				}
			}
			goto IL_0453;
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

	private sealed class _003CApplyInfluenceTimedRoutine_003Ed__133(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public ProCamera2D _003C_003E4__this;

		public Vector2 influence;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0038: Expected I4, but got I8
			//IL_0043: Invalid comparison between F4 and I4
			//IL_0137: Expected I4, but got O
			ProCamera2D proCamera2D = _003C_003E4__this;
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				if (duration > 0f)
				{
					if ((object)_003C_003E4__this != null)
					{
						float num = duration - proCamera2D._003CDeltaTime_003Ek__BackingField;
						duration = num;
						Vector2 vector = default(Vector2);
						_003C_003E4__this.ApplyInfluence(vector);
						object obj = ((proCamera2D.UpdateType != UpdateType.FixedUpdate) ? null : ((!proCamera2D.IgnoreTimeScale) ? proCamera2D._waitForFixedUpdate : null));
						_003C_003E2__current = obj;
						_003C_003E1__state = 1;
						return true;
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
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

	private sealed class _003CApplyInfluencesTimedRoutine_003Ed__132(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float[] durations;

		public ProCamera2D _003C_003E4__this;

		public IList<Vector2> influences;

		private int _003Ccount_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0054: Expected I4, but got I8
			//IL_01ce: Expected I4, but got O
			//IL_0083: Expected O, but got I4
			//IL_0165: Expected F4, but got I
			if (_003C_003E1__state == 0)
			{
				_003Ccount_003E5__2 = -1;
			}
			else if (_003C_003E1__state != 1)
			{
				goto IL_0198;
			}
			float[] array = durations;
			_003C_003E1__state = -1;
			if (durations != null)
			{
				object obj = array.Length - 1;
				if (_003Ccount_003E5__2 >= (nint)obj)
				{
					goto IL_0198;
				}
				int num = _003Ccount_003E5__2;
				float[] array2 = durations;
				int num2 = _003Ccount_003E5__2 + 1;
				_003Ccount_003E5__2 = num2;
				if (durations != null && influences != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F6370");
					if ((object)_003C_003E4__this != null)
					{
						_003CApplyInfluenceTimedRoutine_003Ed__133 obj2 = null;
						obj2._003C_003E1__state = 0;
						obj2._003C_003E4__this = _003C_003E4__this;
						Vector2 influence = default(Vector2);
						obj2.influence = influence;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v3 (System.Single[])+24+v122 @ rax_v10 (System.Int32)*4]");
						obj2.duration = 0f;
						Coroutine coroutine = _003C_003E4__this.StartCoroutine(obj2);
						_003C_003E2__current = coroutine;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0198:
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

	private sealed class _003CDollyZoomRoutine_003Ed__136(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2D _003C_003E4__this;

		public float duration;

		public float finalFOV;

		public EaseType easeType;

		private float _003CstartFOV_003E5__2;

		private float _003CnewFOV_003E5__3;

		private float _003Ct_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_00ed: Expected I4, but got I8
			//IL_04d4: Expected F4, but got I4
			//IL_04ec: Expected O, but got F4
			//IL_02ff: Expected F4, but got I4
			//IL_031a: Expected F4, but got O
			//IL_0421->IL03b9: Incompatible stack heights: 1 vs 0
			//IL_0255->IL03b9: Incompatible stack heights: 1 vs 0
			//IL_0479->IL03b9: Incompatible stack heights: 2 vs 0
			//IL_028b->IL03b9: Incompatible stack heights: 2 vs 0
			//IL_0338->IL04f1: Incompatible stack heights: 3 vs 0
			ProCamera2D proCamera2D = _003C_003E4__this;
			float num;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)proCamera2D.GameCamera != null)
				{
					float fieldOfView = proCamera2D.GameCamera.fieldOfView;
					_003Ct_003E5__4 = 0f;
					num = _003Ct_003E5__4;
					_003CstartFOV_003E5__2 = fieldOfView;
					_003CnewFOV_003E5__3 = fieldOfView;
					goto IL_0116;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_03c0;
				}
				_003C_003E1__state = -1;
				num = _003Ct_003E5__4;
				if ((object)_003C_003E4__this != null)
				{
					goto IL_0116;
				}
			}
			goto IL_03b9;
			IL_03c0:
			return false;
			IL_03b9:
			throw new NullReferenceException();
			IL_0116:
			if (!(1f < num))
			{
				float num2 = proCamera2D._003CDeltaTime_003Ek__BackingField / duration;
				float fieldOfView2 = (_003CnewFOV_003E5__3 = Utils.EaseFromTo(value: _003Ct_003E5__4 = num2 + _003Ct_003E5__4, start: _003CstartFOV_003E5__2, end: finalFOV, type: easeType));
				if ((object)proCamera2D.GameCamera != null)
				{
					proCamera2D.GameCamera.fieldOfView = fieldOfView2;
					object transform = proCamera2D._transform;
					Func<float, float, float, Vector3> vectorHVD = proCamera2D.VectorHVD;
					Func<Vector3, float> vector3H = proCamera2D.Vector3H;
					if ((object)proCamera2D._transform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r13_v10 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r13_v10 (System.Object)+10]");
						Transform.get_localPosition_Injected((IntPtr)0, out Vector3 ret);
						if (proCamera2D.Vector3H != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v102 @ r14_v10 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							object transform2 = proCamera2D._transform;
							Func<Vector3, float> vector3V = proCamera2D.Vector3V;
							if ((object)proCamera2D._transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbp_v10 (System.Object)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbp_v10 (System.Object)+10]");
								Transform.get_localPosition_Injected((IntPtr)0, out ret);
								if (proCamera2D.Vector3V != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v103 @ r14_v11 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									if (proCamera2D.VectorHVD != null)
									{
										float num3 = _003CnewFOV_003E5__3 * 0.5f;
										float num4 = num3 * ((float)Math.PI / 180f);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B745E0");
										float num5 = num4 + num4;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v105 @ r12_v10 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r13_v10 (System.Object)+10]");
										bool flag3 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r13_v10 (System.Object)+10]");
										Vector3 value = default(Vector3);
										Transform.set_localPosition_Injected((IntPtr)0, ref value);
										bool flag4 = proCamera2D.UpdateType != UpdateType.FixedUpdate;
										float num6 = 0f;
										if (!flag4)
										{
											bool flag5 = proCamera2D.IgnoreTimeScale;
											num6 = 0f;
											if (!flag5)
											{
												num6 = (float)proCamera2D._waitForFixedUpdate;
											}
										}
										_003C_003E2__current = num6;
										_003C_003E1__state = 1;
										return true;
									}
								}
							}
						}
					}
				}
				goto IL_03b9;
			}
			proCamera2D._dollyZoomRoutine = null;
			if (proCamera2D.OnDollyZoomFinished != null)
			{
				Action<float> onDollyZoomFinished = proCamera2D.OnDollyZoomFinished;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v591 @ rax_v26 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
			if (proCamera2D.OnUpdateScreenSizeFinished != null)
			{
				Action<float> onUpdateScreenSizeFinished = proCamera2D.OnUpdateScreenSizeFinished;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				float num7 = 0f * 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v645 @ rax_v24 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
			goto IL_03c0;
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

	private sealed class _003CUpdateScreenSizeRoutine_003Ed__135(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2D _003C_003E4__this;

		public float duration;

		public float finalSize;

		public EaseType easeType;

		private float _003CstartSize_003E5__2;

		private float _003CnewSize_003E5__3;

		private float _003Ct_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_00d1: Expected I4, but got I8
			//IL_025f: Expected I4, but got O
			//IL_01a5: Expected F4, but got I4
			//IL_026f: Expected O, but got F4
			//IL_01d3: Expected F4, but got I4
			//IL_01ee: Expected F4, but got O
			ProCamera2D proCamera2D = _003C_003E4__this;
			float num2;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
					float num = 0f * 0.5f;
					_003Ct_003E5__4 = 0f;
					num2 = _003Ct_003E5__4;
					_003CstartSize_003E5__2 = num;
					_003CnewSize_003E5__3 = num;
					goto IL_00fa;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_025f;
				}
				_003C_003E1__state = -1;
				num2 = _003Ct_003E5__4;
				if ((object)_003C_003E4__this != null)
				{
					goto IL_00fa;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_00fa:
			if (!(1f < num2))
			{
				float num3 = proCamera2D._003CDeltaTime_003Ek__BackingField / duration;
				float screenSize = (_003CnewSize_003E5__3 = Utils.EaseFromTo(value: _003Ct_003E5__4 = num3 + _003Ct_003E5__4, start: _003CstartSize_003E5__2, end: finalSize, type: easeType));
				_003C_003E4__this.SetScreenSize(screenSize);
				bool flag = proCamera2D.UpdateType != UpdateType.FixedUpdate;
				float num4 = 0f;
				if (!flag)
				{
					bool flag2 = proCamera2D.IgnoreTimeScale;
					num4 = 0f;
					if (!flag2)
					{
						num4 = (float)proCamera2D._waitForFixedUpdate;
					}
				}
				_003C_003E2__current = num4;
				_003C_003E1__state = 1;
				return true;
			}
			proCamera2D._updateScreenSizeCoroutine = null;
			if (proCamera2D.OnUpdateScreenSizeFinished != null)
			{
				Action<float> onUpdateScreenSizeFinished = proCamera2D.OnUpdateScreenSizeFinished;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v270 @ rax_v6 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
			goto IL_025f;
			IL_025f:
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

	public const string Title = "Pro Camera 2D";

	public static readonly Version Version;

	public List<CameraTarget> CameraTargets;

	public bool CenterTargetOnStart;

	public MovementAxis Axis;

	public UpdateType UpdateType;

	public bool FollowHorizontal;

	public float HorizontalFollowSmoothness;

	public bool FollowVertical;

	public float VerticalFollowSmoothness;

	public float OffsetX;

	public float OffsetY;

	public bool IsRelativeOffset;

	public bool ZoomWithFOV;

	public bool IgnoreTimeScale;

	private static ProCamera2D _instance;

	private float _cameraTargetHorizontalPositionSmoothed;

	private float _cameraTargetVerticalPositionSmoothed;

	private Vector2 _003CStartScreenSizeInWorldCoordinates_003Ek__BackingField;

	private Vector2 _003CScreenSizeInWorldCoordinates_003Ek__BackingField;

	private Vector3 _003CPreviousTargetsMidPoint_003Ek__BackingField;

	private Vector3 _003CTargetsMidPoint_003Ek__BackingField;

	private Vector3 _003CCameraTargetPosition_003Ek__BackingField;

	private float _003CDeltaTime_003Ek__BackingField;

	private Vector3 _003CParentPosition_003Ek__BackingField;

	private Vector3 _influencesSum;

	public Action<float> PreMoveUpdate;

	public Action<float> PostMoveUpdate;

	public Action<Vector2> OnCameraResize;

	public Action<float> OnUpdateScreenSizeFinished;

	public Action<float> OnDollyZoomFinished;

	public Action OnReset;

	public Vector3? ExclusiveTargetPosition;

	public int CurrentZoomTriggerID;

	public bool IsCameraPositionLeftBounded;

	public bool IsCameraPositionRightBounded;

	public bool IsCameraPositionTopBounded;

	public bool IsCameraPositionBottomBounded;

	public Camera GameCamera;

	private Func<Vector3, float> Vector3H;

	private Func<Vector3, float> Vector3V;

	private Func<Vector3, float> Vector3D;

	private Func<float, float, Vector3> VectorHV;

	private Func<float, float, float, Vector3> VectorHVD;

	private Coroutine _updateScreenSizeCoroutine;

	private Coroutine _dollyZoomRoutine;

	private List<Vector3> _influences;

	private float _originalCameraDepthSign;

	private float _previousCameraTargetHorizontalPositionSmoothed;

	private float _previousCameraTargetVerticalPositionSmoothed;

	private int _previousScreenWidth;

	private int _previousScreenHeight;

	private Vector3 _previousCameraPosition;

	private WaitForFixedUpdate _waitForFixedUpdate;

	private Transform _transform;

	private List<IPreMover> _preMovers;

	private List<IPositionDeltaChanger> _positionDeltaChangers;

	private List<IPositionOverrider> _positionOverriders;

	private List<ISizeDeltaChanger> _sizeDeltaChangers;

	private List<ISizeOverrider> _sizeOverriders;

	private List<IPostMover> _postMovers;

	public static ProCamera2D Instance
	{
		get
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0068: Expected I, but got O
			//IL_0075: Expected I, but got O
			//IL_0085: Expected O, but got I
			//IL_00ff: Expected O, but got I4
			//IL_00c1: Expected O, but got I
			//IL_00f1: Expected O, but got I4
			UnityEngine.Object obj3;
			UnityEngine.Object instance;
			object obj6;
			if ((object)_instance == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj2 = default(object);
				object obj = obj2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type type2 = default(Type);
				Type type = type2;
				obj3 = UnityEngine.Object.FindObjectOfType(type);
				nint num = (nint)typeof(ProCamera2D);
				bool flag = (object)obj3 == null;
				instance = null;
				if (!flag)
				{
					nint num2 = (nint)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v5 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ProCamera2D>)+130]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ r8_v10 (Il2CppClass<UnityEngine.Object>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v5 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ProCamera2D>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ r8_v10 (Il2CppClass<UnityEngine.Object>)+C8]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v35+FFFFFFF8+v251 @ rax_v31*8]");
						if (0 == num)
						{
							obj6 = 1;
							goto IL_018d;
						}
					}
					obj6 = 0;
					goto IL_018d;
				}
				goto IL_01d6;
			}
			goto IL_01af;
			IL_018d:
			bool flag2 = obj6 == null;
			instance = null;
			if (!flag2)
			{
				instance = obj3;
			}
			goto IL_01d6;
			IL_01d6:
			_instance = (ProCamera2D)instance;
			if ((object)_instance != null)
			{
				goto IL_01af;
			}
			UnityException ex = new UnityException("ProCamera2D does not exist.");
			throw ex;
			IL_01af:
			return _instance;
		}
	}

	public static bool Exists
	{
		get
		{
			ProCamera2D instance = _instance;
			if ((object)_instance != null)
			{
				bool flag = ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	public bool IsMoving
	{
		get
		{
			//IL_01b3->IL0162: Incompatible stack heights: 1 vs 0
			//IL_006b->IL0162: Incompatible stack heights: 1 vs 0
			//IL_00d1->IL0162: Incompatible stack heights: 1 vs 0
			//IL_0202->IL0162: Incompatible stack heights: 2 vs 0
			//IL_010e->IL0162: Incompatible stack heights: 2 vs 0
			//IL_0141->IL0154: Incompatible stack heights: 2 vs 1
			//IL_0154->IL0207: Incompatible stack heights: 2 vs 1
			Transform transform = _transform;
			Func<Vector3, float> vector3H = Vector3H;
			if ((object)_transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if (Vector3H != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ rsi_v1 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					Func<Vector3, float> vector3H2 = Vector3H;
					if (Vector3H != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v95 @ rcx_v16 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001851D50FEh\"");
						if ((object)ret != (object)ret)
						{
							goto IL_0154;
						}
						Transform transform2 = _transform;
						Func<Vector3, float> vector3V = Vector3V;
						if ((object)_transform != null)
						{
							bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
							if (Vector3V != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ rsi_v10 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
								Func<Vector3, float> vector3V2 = Vector3V;
								if (Vector3V != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v97 @ rcx_v24 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851D50FEh\"");
									if ((object)ret == (object)ret)
									{
										return false;
									}
									goto IL_0154;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_0154:
			return true;
		}
	}

	public unsafe Rect Rect
	{
		get
		{
			//IL_0051: Expected native int or pointer, but got O
			Camera gameCamera = GameCamera;
			bool flag = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
			float ret;
			Camera.get_rect_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr, out *(Rect*)(&ret));
			Rect rect = default(Rect);
			((Rect*)(nint)rect)->m_XMin = ret;
			return rect;
		}
		set
		{
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Expected O, but got Unknown
			//IL_0069->IL013e: Incompatible stack heights: 2 vs 1
			//IL_01f8->IL01f8: Incompatible stack heights: 8 vs 1
			Camera gameCamera = GameCamera;
			bool flag = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
			float value2 = default(float);
			Camera.set_rect_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr, ref *(Rect*)(&value2));
			ProCamera2DParallax componentInChildren = GetComponentInChildren<ProCamera2DParallax>();
			if ((object)componentInChildren == null || ((UnityEngine.Object)componentInChildren).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			Camera camera = null;
			float value3 = default(float);
			while (true)
			{
				List<ProCamera2DParallaxLayer> parallaxLayers = componentInChildren.ParallaxLayers;
				bool flag2 = componentInChildren.ParallaxLayers == null;
				if ((nint)camera < parallaxLayers._size)
				{
					bool flag3 = (nint)camera >= parallaxLayers._size;
					ProCamera2DParallaxLayer[] items = parallaxLayers._items;
					bool flag4 = parallaxLayers._items == null;
					bool flag5 = (nint)camera >= items.Length;
					ProCamera2DParallaxLayer proCamera2DParallaxLayer = items[(object)camera];
					bool flag6 = items[(object)camera] == null;
					object parallaxCamera = proCamera2DParallaxLayer.ParallaxCamera;
					bool flag7 = (object)proCamera2DParallaxLayer.ParallaxCamera == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rdi_v14 (System.Object)+10]");
					bool flag8 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rdi_v14 (System.Object)+10]");
					Camera.set_rect_Injected((IntPtr)0, ref *(Rect*)(&value3));
					camera = (Camera)(camera + 1);
					continue;
				}
				break;
			}
		}
	}

	public Vector2 CameraTargetPositionSmoothed
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			//IL_000a: Expected F4, but got O
			_cameraTargetHorizontalPositionSmoothed = (float)value;
			float cameraTargetVerticalPositionSmoothed = default(float);
			_cameraTargetVerticalPositionSmoothed = cameraTargetVerticalPositionSmoothed;
		}
	}

	public unsafe Vector3 LocalPosition
	{
		get
		{
			//IL_0051: Expected native int or pointer, but got O
			//IL_005f: Expected native int or pointer, but got O
			Transform transform = _transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = ret;
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		set
		{
			Transform transform = _transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float value2 = default(float);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value2));
		}
	}

	public Vector2 StartScreenSizeInWorldCoordinates
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		private set
		{
			_003CStartScreenSizeInWorldCoordinates_003Ek__BackingField = value;
		}
	}

	public Vector2 ScreenSizeInWorldCoordinates
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		private set
		{
			_003CScreenSizeInWorldCoordinates_003Ek__BackingField = value;
		}
	}

	public unsafe Vector3 PreviousTargetsMidPoint
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_003CPreviousTargetsMidPoint_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+70]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		private set
		{
			//IL_000f: Expected O, but got F4
			_003CPreviousTargetsMidPoint_003Ek__BackingField = (Vector3)value.x;
			_ = value.z;
		}
	}

	public unsafe Vector3 TargetsMidPoint
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_003CTargetsMidPoint_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+7C]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		private set
		{
			//IL_000f: Expected O, but got F4
			_003CTargetsMidPoint_003Ek__BackingField = (Vector3)value.x;
			_ = value.z;
		}
	}

	public unsafe Vector3 CameraTargetPosition
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_003CCameraTargetPosition_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+88]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		private set
		{
			//IL_000f: Expected O, but got F4
			_003CCameraTargetPosition_003Ek__BackingField = (Vector3)value.x;
			_ = value.z;
		}
	}

	public float DeltaTime
	{
		get
		{
			return _003CDeltaTime_003Ek__BackingField;
		}
		private set
		{
			_003CDeltaTime_003Ek__BackingField = value;
		}
	}

	public unsafe Vector3 ParentPosition
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_003CParentPosition_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		private set
		{
			//IL_000f: Expected O, but got F4
			_003CParentPosition_003Ek__BackingField = (Vector3)value.x;
			_ = value.z;
		}
	}

	public unsafe Vector3 InfluencesSum
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_influencesSum;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+A4]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
	}

	private unsafe void Awake()
	{
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b1: Expected O, but got Unknown
		//IL_05d5: Expected O, but got I
		//IL_037c: Expected O, but got I4
		//IL_0399: Expected O, but got I
		//IL_03af: Invalid comparison between F4 and O
		//IL_04b4: Expected O, but got I4
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b2: Expected O, but got Unknown
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_074a: Expected O, but got Unknown
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Expected O, but got Unknown
		//IL_044e: Expected F4, but got I
		//IL_0477: Expected O, but got I
		//IL_0489: Expected O, but got I
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d2: Expected O, but got Unknown
		//IL_031b: Expected I4, but got O
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_05e7->IL056a: Incompatible stack heights: 4 vs 1
		//IL_01b6->IL01b6: Incompatible stack heights: 2 vs 1
		//IL_0543->IL0543: Incompatible stack heights: 3 vs 0
		//IL_049c->IL06df: Incompatible stack heights: 5 vs 2
		//IL_02ec->IL0321: Incompatible stack heights: 7 vs 8
		//IL_0361->IL0656: Incompatible stack heights: 9 vs 2
		object obj2 = default(object);
		Transform transform5;
		while (true)
		{
			_instance = this;
			Transform transform = base.transform;
			_transform = transform;
			bool flag = (object)_transform == null;
			Transform parent = _transform.parent;
			if ((object)parent != null && ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0)
			{
				bool flag2 = (object)_transform == null;
				Transform parent2 = _transform.parent;
				bool flag3 = (object)parent2 == null;
				_ = 0;
				_ = 0;
				bool flag4 = ((UnityEngine.Object)parent2).m_CachedPtr == (IntPtr)0;
				object obj = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)parent2).m_CachedPtr, out *(Vector3*)obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
				_003CParentPosition_003Ek__BackingField = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-28]");
				_ = 0;
			}
			Camera gameCamera = GameCamera;
			if ((object)GameCamera == null || ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0)
			{
				Camera component = GetComponent<Camera>();
				GameCamera = component;
			}
			Transform gameCamera2 = (Transform)(object)GameCamera;
			if ((object)GameCamera == null || ((UnityEngine.Object)gameCamera2).m_CachedPtr == (IntPtr)0)
			{
				GameObject gameObject = base.gameObject;
				bool flag5 = (object)gameObject == null;
				string text = ((UnityEngine.Object)gameObject).GetName();
				string message = "Unity Camera not set and not found on the GameObject: " + text;
				Debug.LogError(message);
			}
			ResetAxisFunctions();
			List<CameraTarget> cameraTargets = CameraTargets;
			bool flag6 = CameraTargets == null;
			Transform transform2 = null;
			Transform transform3 = null;
			while ((nint)transform3 < cameraTargets._size)
			{
				List<CameraTarget> cameraTargets2 = CameraTargets;
				bool flag7 = CameraTargets == null;
				bool flag8 = (nint)transform2 >= cameraTargets2._size;
				CameraTarget[] items = cameraTargets2._items;
				bool flag9 = cameraTargets2._items == null;
				bool flag10 = (nint)transform2 >= items.Length;
				CameraTarget cameraTarget = items[(object)transform2];
				bool flag11 = items[(object)transform2] == null;
				Transform targetTransform = cameraTarget.TargetTransform;
				if ((object)cameraTarget.TargetTransform == null || ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0)
				{
					bool flag12 = CameraTargets == null;
					CameraTargets.RemoveAt((int)transform2);
				}
				cameraTargets = CameraTargets;
				transform2 = (Transform)(transform2 + 1);
				bool flag13 = CameraTargets == null;
				transform3 = transform2;
			}
			CalculateScreenSize();
			_ = 0;
			object obj3 = 0 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+24]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+24]");
			object obj4 = num * 0;
			object obj5 = obj4 + obj3;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
			{
				Transform transform4 = _transform;
				Func<Vector3, float> vector3D = Vector3D;
				bool flag14 = (object)_transform == null;
				_ = 0;
				_ = 0;
				bool flag15 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
				object obj6 = obj2 - 48;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj6);
				bool flag16 = Vector3D == null;
				object obj7 = obj2 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v229 @ r14_v13 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				float distance = num2 & 0;
				Vector2 screenSizeInWorldCoords = Utils.GetScreenSizeInWorldCoords(GameCamera, distance);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+24]");
				obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
				_003CStartScreenSizeInWorldCoordinates_003Ek__BackingField = (Vector2)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+24]");
				_ = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+24]");
				_ = 0;
				_003CStartScreenSizeInWorldCoordinates_003Ek__BackingField = (Vector2)0;
			}
			transform5 = _transform;
			Func<Vector3, float> vector3D2 = Vector3D;
			bool flag17 = (object)_transform == null;
			_ = 0;
			_ = 0;
			if (((UnityEngine.Object)transform5).m_CachedPtr != (IntPtr)0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_transform);
		}
		object obj8 = obj2 - 48;
		Transform.get_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)obj8);
		bool flag18 = Vector3D == null;
		object obj9 = obj2 - 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v257 @ rsi_v12 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
		float originalCameraDepthSign = (((nint)0 < (nint)0) ? (-1f) : 1f);
		_originalCameraDepthSign = originalCameraDepthSign;
	}

	private unsafe void Start()
	{
		//IL_0008: Expected O, but got Ref
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Ref, but got Unknown
		//IL_005b: Expected O, but got F4
		//IL_009c: Expected O, but got Ref
		//IL_00f1: Expected O, but got Ref
		//IL_0136: Expected F4, but got O
		//IL_0155: Expected O, but got I
		//IL_04ee: Expected F4, but got O
		//IL_014a: Expected O, but got I
		//IL_06c7: Expected O, but got Ref
		//IL_06eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Expected O, but got Unknown
		//IL_0714: Expected O, but got I
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_0729: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected Ref, but got Unknown
		//IL_0422: Expected O, but got Ref
		//IL_044a: Expected F4, but got O
		//IL_0454: Expected F4, but got O
		//IL_0481: Expected O, but got Ref
		//IL_04ab: Expected F4, but got O
		//IL_04b7: Expected F4, but got O
		//IL_0221: Expected O, but got Ref
		//IL_057b: Expected O, but got Ref
		//IL_0273: Expected O, but got I
		//IL_0281: Expected O, but got Ref
		//IL_02cd: Expected O, but got Ref
		//IL_0609: Expected O, but got Ref
		//IL_0331: Expected O, but got Ref
		//IL_036d: Expected O, but got Ref
		//IL_03b3: Expected O, but got Ref
		//IL_075c->IL04bc: Incompatible stack heights: 1 vs 0
		//IL_046e->IL04bc: Incompatible stack heights: 1 vs 0
		//IL_05aa->IL04bc: Incompatible stack heights: 1 vs 0
		//IL_02a0->IL050d: Incompatible stack heights: 1 vs 0
		//IL_0638->IL04bc: Incompatible stack heights: 1 vs 0
		//IL_035a->IL05af: Incompatible stack heights: 1 vs 0
		//IL_03e0->IL03e0: Incompatible stack heights: 0 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		SortPreMovers();
		SortPositionDeltaChangers();
		SortPositionOverriders();
		SortSizeDeltaChangers();
		SortSizeOverriders();
		SortPostMovers();
		Vector3 targetsWeightedMidPoint = GetTargetsWeightedMidPoint(ref *(List<CameraTarget>*)(this + 32));
		Func<Vector3, float> vector3H = Vector3H;
		_003CTargetsMidPoint_003Ek__BackingField = (Vector3)targetsWeightedMidPoint.x;
		_ = targetsWeightedMidPoint.z;
		Vector3 targetsWeightedMidPoint2;
		if (Vector3H != null)
		{
			_ = targetsWeightedMidPoint.z;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = targetsWeightedMidPoint.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v67 @ rcx_v9 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3V = Vector3V;
			float cameraTargetHorizontalPositionSmoothed = default(float);
			_cameraTargetHorizontalPositionSmoothed = cameraTargetHorizontalPositionSmoothed;
			if (Vector3V != null)
			{
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Vector3 vector = _003CTargetsMidPoint_003Ek__BackingField;
				_ = _003CTargetsMidPoint_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+7C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v85 @ rcx_v33 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				bool flag = !IgnoreTimeScale;
				_cameraTargetVerticalPositionSmoothed = (float)_003CTargetsMidPoint_003Ek__BackingField;
				if (!flag)
				{
					object obj5 = 0;
				}
				else
				{
					object obj5 = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v421 @ rax_v36 (should have been resolved before IL gen)");
				_003CDeltaTime_003Ek__BackingField = (float)vector;
				if (!CenterTargetOnStart)
				{
					goto IL_03e1;
				}
				List<CameraTarget> cameraTargets = CameraTargets;
				if (CameraTargets != null)
				{
					if (cameraTargets._size <= 0)
					{
						goto IL_03e1;
					}
					targetsWeightedMidPoint2 = GetTargetsWeightedMidPoint(ref *(List<CameraTarget>*)(this + 32));
					bool flag2 = !FollowHorizontal;
					Func<Vector3, float> vector3H2 = Vector3H;
					if (!flag2)
					{
						if (Vector3H != null)
						{
							_ = targetsWeightedMidPoint2.x;
							object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							_ = targetsWeightedMidPoint2.z;
							goto IL_050d;
						}
					}
					else
					{
						object obj7 = _transform;
						if ((object)_transform != null)
						{
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rsi_v16 (System.Object)+10]");
							bool flag3 = (nint)0 == 0;
							object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rsi_v16 (System.Object)+10]");
							Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj8);
							if (Vector3H != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
								vector = (Vector3)0;
								object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
								_ = 0;
								goto IL_050d;
							}
						}
					}
				}
			}
		}
		goto IL_04bc;
		IL_050d:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v135 @ rdi_v13 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		bool flag4 = !FollowVertical;
		Func<Vector3, float> vector3V2 = Vector3V;
		if (!flag4)
		{
			if (Vector3V != null)
			{
				object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				_ = targetsWeightedMidPoint2.x;
				_ = targetsWeightedMidPoint2.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v136 @ rdi_v14 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				goto IL_05af;
			}
		}
		else
		{
			object obj10 = _transform;
			if ((object)_transform != null)
			{
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rsi_v15 (System.Object)+10]");
				bool flag5 = (nint)0 == 0;
				object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rsi_v15 (System.Object)+10]");
				Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj11);
				if (Vector3V != null)
				{
					object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v136 @ rdi_v14 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					goto IL_05af;
				}
			}
		}
		goto IL_04bc;
		IL_04bc:
		throw new NullReferenceException();
		IL_05af:
		if (IsRelativeOffset)
		{
		}
		Func<Vector3, float> vector3H3 = Vector3H;
		Vector2 vector2 = default(Vector2);
		if (Vector3H != null)
		{
			object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			_ = _003CParentPosition_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v194 @ rcx_v50 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			if (!IsRelativeOffset)
			{
				Func<Vector3, float> vector3V3 = Vector3V;
				if (Vector3V == null)
				{
					goto IL_04bc;
				}
			}
			object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			_ = _003CParentPosition_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v195 @ rcx_v52 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			MoveCameraInstantlyToPosition(vector2);
			return;
		}
		goto IL_04bc;
		IL_03e1:
		Transform transform = _transform;
		if ((object)_transform != null)
		{
			_ = 0;
			_ = 0;
			bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj15);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
			object obj16 = 0 - _003CParentPosition_003Ek__BackingField;
			_ = _003CParentPosition_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
			object obj17 = num - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-15]");
			object obj18 = 0 - vector2;
			Func<Vector3, float> vector3H4 = Vector3H;
			_003CCameraTargetPosition_003Ek__BackingField = vector2;
			if (Vector3H != null)
			{
				object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v196 @ rcx_v39 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Func<Vector3, float> vector3V4 = Vector3V;
				_cameraTargetHorizontalPositionSmoothed = (float)vector2;
				_previousCameraTargetHorizontalPositionSmoothed = (float)vector2;
				if (Vector3V != null)
				{
					object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					_ = _003CCameraTargetPosition_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+88]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v191 @ rcx_v41 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					_cameraTargetVerticalPositionSmoothed = (float)_003CCameraTargetPosition_003Ek__BackingField;
					_previousCameraTargetVerticalPositionSmoothed = (float)_003CCameraTargetPosition_003Ek__BackingField;
					return;
				}
			}
		}
		goto IL_04bc;
	}

	private void LateUpdate()
	{
		//IL_0052: Expected O, but got I
		//IL_0047: Expected O, but got I
		if (UpdateType == UpdateType.LateUpdate)
		{
			if (IgnoreTimeScale)
			{
				object obj = 0;
			}
			else
			{
				object obj = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v109 @ rax_v4 (should have been resolved before IL gen)");
			float deltaTime = default(float);
			Move(deltaTime);
		}
	}

	private void FixedUpdate()
	{
		//IL_0052: Expected O, but got I
		//IL_0047: Expected O, but got I
		if (UpdateType == UpdateType.FixedUpdate)
		{
			if (IgnoreTimeScale)
			{
				object obj = 0;
			}
			else
			{
				object obj = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v109 @ rax_v4 (should have been resolved before IL gen)");
			float deltaTime = default(float);
			Move(deltaTime);
		}
	}

	private void OnApplicationQuit()
	{
		_instance = null;
	}

	public float GetOffsetX()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		if (IsRelativeOffset)
		{
			object obj = _003CScreenSizeInWorldCoordinates_003Ek__BackingField * OffsetX;
			return (float)obj * 0.5f;
		}
		return OffsetX;
	}

	public float GetOffsetY()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		if (IsRelativeOffset)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			object obj = 0 * OffsetY;
			return (float)obj * 0.5f;
		}
		return OffsetY;
	}

	public unsafe void ApplyInfluence(Vector2 influence)
	{
		//IL_00a4: Expected O, but got F4
		//IL_00ad: Invalid comparison between F4 and O
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0090: Expected O, but got Ref
		object obj = Time.deltaTime;
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			return;
		}
		object obj3 = influence & -2147483649L;
		if ((nint)obj3 <= 2139095040)
		{
			object obj5 = default(object);
			object obj4 = obj5 & -2147483649L;
			if ((nint)obj4 <= 2139095040)
			{
				Func<float, float, Vector3> vectorHV = VectorHV;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v239 @ rdx_v2 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
				object obj6 = default(object);
				_influences.Add((Vector3)(&obj6));
			}
		}
	}

	public Coroutine ApplyInfluencesTimed(Vector2[] influences, float[] durations)
	{
		_003CApplyInfluencesTimedRoutine_003Ed__132 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.influences = influences;
		obj.durations = durations;
		return StartCoroutine(obj);
	}

	public CameraTarget AddCameraTarget(Transform targetTransform, float targetInfluenceH = 1f, float targetInfluenceV = 1f, float duration = 0f, Vector2 targetOffset = default(Vector2))
	{
		CameraTarget cameraTarget = new CameraTarget();
		cameraTarget.TargetInfluenceH = 1f;
		cameraTarget.TargetInfluenceV = 1f;
		cameraTarget.TargetTransform = targetTransform;
		Vector2 targetOffset2 = default(Vector2);
		cameraTarget.TargetOffset = targetOffset2;
		cameraTarget.TargetInfluenceH = targetInfluenceH;
		cameraTarget.TargetInfluenceV = targetInfluenceV;
		if (CameraTargets != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B76D0");
			object obj = default(object);
			if ((nint)obj > 0)
			{
				cameraTarget.TargetInfluenceH = 0f;
				float duration2 = default(float);
				bool removeIfZeroInfluence = default(bool);
				IEnumerator routine = AdjustTargetInfluenceRoutine(cameraTarget, targetInfluenceH, targetInfluenceV, duration2, removeIfZeroInfluence);
				Coroutine coroutine = StartCoroutine(routine);
			}
			return cameraTarget;
		}
		return (CameraTarget)(object)new NullReferenceException();
	}

	public void AddCameraTargets(IList<Transform> targetsTransforms, float targetsInfluenceH = 1f, float targetsInfluenceV = 1f, float duration = 0f, Vector2 targetOffset = default(Vector2))
	{
		int num = 0;
		int num2 = 0;
		float duration2 = default(float);
		Vector2 targetOffset2 = default(Vector2);
		while (true)
		{
			int count = targetsTransforms.Count;
			if (num < count)
			{
				Transform targetTransform = targetsTransforms.get_Item(num2);
				CameraTarget cameraTarget = AddCameraTarget(targetTransform, targetsInfluenceH, targetsInfluenceV, duration2, targetOffset2);
				num2++;
				num = num2;
				continue;
			}
			break;
		}
	}

	public void AddCameraTargets(IList<CameraTarget> cameraTargets)
	{
		List<object> cameraTargets2 = (List<object>)(object)CameraTargets;
		((List<object>)(object)CameraTargets).InsertRange(cameraTargets2._size, (IEnumerable<object>)cameraTargets);
	}

	public CameraTarget GetCameraTarget(Transform targetTransform)
	{
		//IL_00fb: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		List<CameraTarget> cameraTargets = CameraTargets;
		object obj = 0;
		object obj2 = 0;
		CameraTarget result = default(CameraTarget);
		while (true)
		{
			if ((nint)obj2 < cameraTargets._size)
			{
				List<CameraTarget> cameraTargets2 = CameraTargets;
				if ((nint)obj >= cameraTargets2._size)
				{
					break;
				}
				CameraTarget[] items = cameraTargets2._items;
				CameraTarget cameraTarget = items[obj];
				int instanceID = cameraTarget.TargetTransform.GetInstanceID();
				int instanceID2 = targetTransform.GetInstanceID();
				cameraTargets = CameraTargets;
				if (instanceID != instanceID2)
				{
					obj++;
					obj2 = obj;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				return result;
			}
			return null;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		CameraTarget result2 = default(CameraTarget);
		return result2;
	}

	public void RemoveCameraTarget(Transform targetTransform, float duration = 0f)
	{
		//IL_000e: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		//IL_00c1: Expected O, but got I
		//IL_0112: Expected O, but got I4
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_0104: Expected O, but got I
		//IL_0120: Invalid comparison between F4 and I4
		//IL_01a7: Expected F4, but got I4
		//IL_01ae: Expected I, but got O
		List<CameraTarget> cameraTargets = CameraTargets;
		object obj = 0;
		float num = duration;
		object obj2 = 0;
		object item = default(object);
		CameraTarget cameraTarget2 = default(CameraTarget);
		float duration2 = default(float);
		bool removeIfZeroInfluence = default(bool);
		while (true)
		{
			if ((nint)obj2 >= cameraTargets._size)
			{
				return;
			}
			List<CameraTarget> cameraTargets2 = CameraTargets;
			if ((nint)obj >= cameraTargets2._size)
			{
				break;
			}
			CameraTarget[] items = cameraTargets2._items;
			CameraTarget cameraTarget = items[obj];
			Transform targetTransform2 = cameraTarget.TargetTransform;
			object obj3;
			if (((UnityEngine.Object)targetTransform2).m_CachedPtr != (IntPtr)0)
			{
				IntPtr cachedPtr = ((UnityEngine.Object)targetTransform2).m_CachedPtr;
				int offsetOfInstanceIDInCPlusPlusObject = UnityEngine.Object.OffsetOfInstanceIDInCPlusPlusObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rax_v30 (System.Int32)+v379 @ rdi_v12 (System.IntPtr)]");
				obj3 = 0;
			}
			else
			{
				obj3 = 0;
			}
			object obj4;
			if (((UnityEngine.Object)targetTransform).m_CachedPtr != (IntPtr)0)
			{
				IntPtr cachedPtr2 = ((UnityEngine.Object)targetTransform).m_CachedPtr;
				int offsetOfInstanceIDInCPlusPlusObject2 = UnityEngine.Object.OffsetOfInstanceIDInCPlusPlusObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v25 (System.Int32)+v95 @ rbp_v6 (System.IntPtr)]");
				obj4 = 0;
			}
			else
			{
				obj4 = 0;
			}
			if (obj3 == obj4)
			{
				if (!(duration > 0f))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag = ((List<object>)(object)CameraTargets).Remove(item);
					nint num2 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					IEnumerator routine = AdjustTargetInfluenceRoutine(cameraTarget2, 0f, 0f, duration2, removeIfZeroInfluence);
					Coroutine coroutine = StartCoroutine(routine);
					num = 0f;
					nint num2 = unchecked((nint)null);
				}
			}
			cameraTargets = CameraTargets;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void RemoveAllCameraTargets(float duration = 0f)
	{
		//IL_0164: Invalid comparison between F4 and I4
		//IL_0083: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		List<CameraTarget> cameraTargets = CameraTargets;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851D7383h\"");
		if (duration == 0f)
		{
			int version = cameraTargets._version + 1;
			cameraTargets._version = version;
			cameraTargets._size = 0;
			if (cameraTargets._size > 0)
			{
				Array.Clear(cameraTargets._items, 0, cameraTargets._size);
			}
			return;
		}
		object obj = 0;
		object obj2 = 0;
		float duration2 = default(float);
		bool removeIfZeroInfluence = default(bool);
		while (true)
		{
			if ((nint)obj2 >= cameraTargets._size)
			{
				return;
			}
			List<CameraTarget> cameraTargets2 = CameraTargets;
			if ((nint)obj >= cameraTargets2._size)
			{
				break;
			}
			CameraTarget[] items = cameraTargets2._items;
			IEnumerator routine = AdjustTargetInfluenceRoutine(items[obj], 0f, 0f, duration2, removeIfZeroInfluence);
			Coroutine coroutine = StartCoroutine(routine);
			cameraTargets = CameraTargets;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public Coroutine AdjustCameraTargetInfluence(CameraTarget cameraTarget, float targetInfluenceH, float targetInfluenceV, float duration = 0f)
	{
		object obj = default(object);
		if ((nint)obj <= 0)
		{
			if (cameraTarget != null)
			{
				cameraTarget.TargetInfluenceH = targetInfluenceH;
				cameraTarget.TargetInfluenceV = targetInfluenceV;
				return null;
			}
			return (Coroutine)(object)new NullReferenceException();
		}
		float duration2 = default(float);
		bool removeIfZeroInfluence = default(bool);
		IEnumerator routine = AdjustTargetInfluenceRoutine(cameraTarget, targetInfluenceH, targetInfluenceV, duration2, removeIfZeroInfluence);
		return StartCoroutine(routine);
	}

	public Coroutine AdjustCameraTargetInfluence(Transform cameraTargetTransf, float targetInfluenceH, float targetInfluenceV, float duration = 0f)
	{
		Coroutine cameraTarget = (Coroutine)(object)GetCameraTarget(cameraTargetTransf);
		if (cameraTarget != null)
		{
			object obj = default(object);
			if ((nint)obj <= 0)
			{
				return null;
			}
			float duration2 = default(float);
			bool removeIfZeroInfluence = default(bool);
			IEnumerator routine = AdjustTargetInfluenceRoutine((CameraTarget)(object)cameraTarget, targetInfluenceH, targetInfluenceV, duration2, removeIfZeroInfluence);
			return StartCoroutine(routine);
		}
		return cameraTarget;
	}

	public void TranslateCamera(Vector2 translateAmount)
	{
		//IL_0070: Expected I, but got O
		//IL_00fa->IL0095: Incompatible stack heights: 1 vs 0
		//IL_0057->IL0095: Incompatible stack heights: 1 vs 0
		Transform transform = _transform;
		if ((object)_transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			Func<Vector3, float> vector3D = Vector3D;
			Transform vectorHVD = (Transform)(object)VectorHVD;
			if (Vector3D != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v65 @ rcx_v16 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				if (VectorHVD != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v100 @ rdi_v8 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
					nint num = (nint)_transform;
					bool flag2 = (object)_transform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rsi_v9 (System.IntPtr)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rsi_v9 (System.IntPtr)+10]");
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected((IntPtr)0, ref value);
					object obj = default(object);
					float previousCameraTargetVerticalPositionSmoothed = (float)obj + _previousCameraTargetVerticalPositionSmoothed;
					float cameraTargetVerticalPositionSmoothed = (float)obj + _cameraTargetVerticalPositionSmoothed;
					Vector3 vector = default(Vector3);
					_003CCameraTargetPosition_003Ek__BackingField = vector;
					_003CTargetsMidPoint_003Ek__BackingField = vector;
					_003CPreviousTargetsMidPoint_003Ek__BackingField = vector;
					float previousCameraTargetHorizontalPositionSmoothed = (float)translateAmount + _previousCameraTargetHorizontalPositionSmoothed;
					float cameraTargetHorizontalPositionSmoothed = (float)translateAmount + _cameraTargetHorizontalPositionSmoothed;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rax_v23+8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rax_v23+8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rax_v23+8]");
					_ = 0;
					_previousCameraTargetHorizontalPositionSmoothed = previousCameraTargetHorizontalPositionSmoothed;
					_previousCameraTargetVerticalPositionSmoothed = previousCameraTargetVerticalPositionSmoothed;
					_cameraTargetHorizontalPositionSmoothed = cameraTargetHorizontalPositionSmoothed;
					_cameraTargetVerticalPositionSmoothed = cameraTargetVerticalPositionSmoothed;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void MoveCameraInstantlyToPosition(Vector2 cameraPos)
	{
		Transform transform = _transform;
		Func<float, float, float, Vector3> vectorHVD = VectorHVD;
		Func<Vector3, float> vector3D = Vector3D;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v16 @ rsi_v1 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v15 @ r15_v1 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		ResetMovement();
	}

	public void Reset(bool centerOnTargets = true, bool resetSize = true, bool resetExtensions = true)
	{
		if (!centerOnTargets)
		{
			ResetMovement();
		}
		else
		{
			CenterOnTargets();
		}
		bool flag = default(bool);
		if (flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+5C]");
			float screenSize = 0f * 0.5f;
			SetScreenSize(screenSize);
		}
		if (resetExtensions && OnReset != null)
		{
			Action onReset = OnReset;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v89.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void ResetMovement()
	{
		//IL_0052: Expected F4, but got O
		//IL_005e: Expected F4, but got O
		Transform transform = _transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		Func<Vector3, float> vector3H = Vector3H;
		_003CCameraTargetPosition_003Ek__BackingField = ret;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v59 @ rcx_v10 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Func<Vector3, float> vector3V = Vector3V;
		float cameraTargetHorizontalPositionSmoothed = default(float);
		_cameraTargetHorizontalPositionSmoothed = cameraTargetHorizontalPositionSmoothed;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v58 @ rcx_v12 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		_cameraTargetVerticalPositionSmoothed = (float)_003CCameraTargetPosition_003Ek__BackingField;
		_previousCameraTargetVerticalPositionSmoothed = (float)_003CCameraTargetPosition_003Ek__BackingField;
		_previousCameraTargetHorizontalPositionSmoothed = _cameraTargetHorizontalPositionSmoothed;
		_003CTargetsMidPoint_003Ek__BackingField = _003CCameraTargetPosition_003Ek__BackingField;
		_003CPreviousTargetsMidPoint_003Ek__BackingField = _003CCameraTargetPosition_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+88]");
		_ = 0;
	}

	public void ResetSize()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+5C]");
		float screenSize = 0f * 0.5f;
		SetScreenSize(screenSize);
	}

	public void ResetStartSize(Vector2 newSize = default(Vector2))
	{
		//IL_0030: Invalid comparison between F4 and O
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected F4, but got Unknown
		object obj2 = default(object);
		object obj = obj2 * obj2;
		object obj3 = newSize * newSize;
		object obj4 = obj + obj3;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
		{
			Transform transform = _transform;
			Func<Vector3, float> vector3D = Vector3D;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v45 @ rbp_v1 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Vector3 vector = ret;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			float distance = vector & 0;
			Vector2 screenSizeInWorldCoords = Utils.GetScreenSizeInWorldCoords(GameCamera, distance);
			_003CStartScreenSizeInWorldCoordinates_003Ek__BackingField = screenSizeInWorldCoords;
		}
		else
		{
			_003CStartScreenSizeInWorldCoordinates_003Ek__BackingField = newSize;
		}
	}

	public void ResetExtensions()
	{
		if (OnReset != null)
		{
			Action onReset = OnReset;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public unsafe void CenterOnTargets()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Ref, but got Unknown
		Vector3 targetsWeightedMidPoint = GetTargetsWeightedMidPoint(ref *(List<CameraTarget>*)(this + 32));
		Func<Vector3, float> vector3H = Vector3H;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v16 @ rcx_v2 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Func<Vector3, float> vector3V = Vector3V;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v41 @ rcx_v5 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		if (IsRelativeOffset)
		{
		}
		Vector2 cameraPos = default(Vector2);
		MoveCameraInstantlyToPosition(cameraPos);
	}

	public void UpdateScreenSize(float newSize, float duration = 0f, EaseType easeType = EaseType.EaseInOut)
	{
		//IL_00da: Expected O, but got I4
		//IL_005e: Invalid comparison between F4 and I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null)
		{
			if (_updateScreenSizeCoroutine != null)
			{
				StopCoroutine(_updateScreenSizeCoroutine);
			}
			if (!(duration > 0f))
			{
				SetScreenSize(newSize);
				return;
			}
			_003CUpdateScreenSizeRoutine_003Ed__135 obj2 = null;
			obj2._003C_003E1__state = 0;
			obj2._003C_003E4__this = this;
			obj2.finalSize = newSize;
			obj2.duration = duration;
			obj2.easeType = easeType;
			Coroutine updateScreenSizeCoroutine = StartCoroutine(obj2);
			_updateScreenSizeCoroutine = updateScreenSizeCoroutine;
		}
	}

	public void CalculateScreenSize()
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected F4, but got Unknown
		//IL_00e4->IL0083: Incompatible stack heights: 1 vs 0
		//IL_0133->IL0083: Incompatible stack heights: 2 vs 0
		Camera gameCamera = GameCamera;
		if ((object)GameCamera != null)
		{
			bool flag = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
			Camera.ResetAspect_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr);
			Camera camera = (Camera)(object)_transform;
			Func<Vector3, float> vector3D = Vector3D;
			if ((object)_transform != null)
			{
				bool flag2 = ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)camera).m_CachedPtr, out Vector3 ret);
				if (Vector3D != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v41 @ rbp_v8 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					Vector3 vector = ret;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					float distance = vector & 0;
					Vector2 screenSizeInWorldCoords = Utils.GetScreenSizeInWorldCoords(GameCamera, distance);
					_003CScreenSizeInWorldCoordinates_003Ek__BackingField = screenSizeInWorldCoords;
					int width = Screen.width;
					_previousScreenWidth = width;
					int height = Screen.height;
					_previousScreenHeight = height;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Zoom(float zoomAmount, float duration = 0f, EaseType easeType = EaseType.EaseInOut)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
		float num = 0f * 0.5f;
		float newSize = num + zoomAmount;
		UpdateScreenSize(newSize, duration, easeType);
	}

	public void DollyZoom(float targetFOV, float duration = 1f, EaseType easeType = EaseType.EaseInOut)
	{
		//IL_02c4: Expected O, but got I4
		//IL_02ea: Invalid comparison between I4 and F4
		//IL_0181: Expected I4, but got O
		//IL_01be: Expected I4, but got O
		//IL_003f->IL02a9: Incompatible stack heights: 1 vs 0
		//IL_014f->IL02a9: Incompatible stack heights: 1 vs 0
		//IL_019b->IL02a9: Incompatible stack heights: 1 vs 0
		//IL_0373->IL02a9: Incompatible stack heights: 2 vs 0
		//IL_01e2->IL02a9: Incompatible stack heights: 2 vs 0
		//IL_03c8->IL02a9: Incompatible stack heights: 3 vs 0
		//IL_0215->IL02a9: Incompatible stack heights: 3 vs 0
		//IL_0243->IL02a9: Incompatible stack heights: 3 vs 0
		//IL_0408->IL0134: Incompatible stack heights: 4 vs 1
		float num2;
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			if ((object)GameCamera != null)
			{
				if (!GameCamera.orthographic)
				{
					if (_dollyZoomRoutine != null)
					{
						StopCoroutine(_dollyZoomRoutine);
					}
					bool flag2 = 0.1f > targetFOV;
					float num = 0.1f;
					if (!flag2)
					{
						bool flag3 = !(targetFOV > 179.9f);
						num = 179.9f;
						num2 = targetFOV;
						if (flag3)
						{
							goto IL_02e1;
						}
					}
					num2 = num;
					goto IL_02e1;
				}
				Debug.LogWarning("Dolly zooming is only supported on perspective cameras");
				return;
			}
		}
		goto IL_02a9;
		IL_02e1:
		if (0f < duration)
		{
			_003CDollyZoomRoutine_003Ed__136 obj2 = null;
			obj2._003C_003E1__state = 0;
			obj2._003C_003E4__this = this;
			obj2.finalFOV = num2;
			obj2.duration = duration;
			obj2.easeType = easeType;
			Coroutine coroutine = StartCoroutine(obj2);
			return;
		}
		if ((object)GameCamera != null)
		{
			GameCamera.fieldOfView = num2;
			object obj3 = _transform;
			Func<float, float, float, Vector3> vectorHVD = VectorHVD;
			EaseType easeType2 = (EaseType)Vector3H;
			if ((object)_transform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r14_v12 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r14_v12 (System.Object)+10]");
				Transform.get_localPosition_Injected((IntPtr)0, out Vector3 ret);
				if (Vector3H != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v168 @ rsi_v13 (Com.LuisPedroFonseca.ProCamera2D.EaseType)+18] (should have been resolved before IL gen)");
					EaseType easeType3 = (EaseType)_transform;
					Func<Vector3, float> vector3V = Vector3V;
					if ((object)_transform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rsi_v14 (Com.LuisPedroFonseca.ProCamera2D.EaseType)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rsi_v14 (Com.LuisPedroFonseca.ProCamera2D.EaseType)+10]");
						Transform.get_localPosition_Injected((IntPtr)0, out ret);
						if (Vector3V != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v138 @ rdi_v13 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							if ((object)GameCamera != null)
							{
								float fieldOfView = GameCamera.fieldOfView;
								if (VectorHVD != null)
								{
									float num3 = fieldOfView * 0.5f;
									float num4 = num3 * ((float)Math.PI / 180f);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B745E0");
									float num5 = num4 + num4;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v114 @ r15_v12 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r14_v12 (System.Object)+10]");
									bool flag6 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r14_v12 (System.Object)+10]");
									Vector3 value = default(Vector3);
									Transform.set_localPosition_Injected((IntPtr)0, ref value);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_02a9;
		IL_02a9:
		throw new NullReferenceException();
	}

	public unsafe void Move(float deltaTime)
	{
		//IL_0008: Expected O, but got Ref
		//IL_1d1b: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_18f4: Expected O, but got I4
		//IL_190c: Expected O, but got Ref
		//IL_193f: Expected O, but got I4
		//IL_1948: Expected O, but got I4
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected Ref, but got Unknown
		//IL_0202: Expected O, but got F4
		//IL_0211: Expected O, but got F4
		//IL_0248: Expected O, but got F4
		//IL_031e: Expected O, but got Ref
		//IL_0181: Expected O, but got I
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_0360: Expected O, but got Ref
		//IL_03ad: Expected O, but got I
		//IL_19e4: Expected O, but got Ref
		//IL_0405: Expected O, but got Ref
		//IL_03f2: Expected O, but got I4
		//IL_0458: Expected O, but got I
		//IL_0466: Expected O, but got Ref
		//IL_04d5: Expected O, but got Ref
		//IL_0797: Expected F4, but got I4
		//IL_0552: Expected O, but got Ref
		//IL_0801: Expected F4, but got I4
		//IL_05a9: Expected O, but got Ref
		//IL_0814: Expected O, but got Ref
		//IL_0826: Expected F4, but got O
		//IL_0843: Expected O, but got I
		//IL_0615: Expected O, but got Ref
		//IL_0892: Expected O, but got Ref
		//IL_08f7: Expected O, but got F4
		//IL_066e: Expected O, but got I
		//IL_067c: Expected O, but got Ref
		//IL_0997: Expected O, but got Ref
		//IL_0a08: Expected O, but got F4
		//IL_06dc: Expected O, but got I
		//IL_06f9: Expected O, but got I
		//IL_0707: Expected O, but got Ref
		//IL_0733: Expected O, but got I4
		//IL_0abe: Expected O, but got Ref
		//IL_0b2b: Expected O, but got Ref
		//IL_0b3b: Expected O, but got I
		//IL_0b94: Expected O, but got Ref
		//IL_0ba6: Expected F4, but got O
		//IL_0bb6: Expected F4, but got I
		//IL_0bda: Expected F4, but got I4
		//IL_0beb: Expected O, but got I4
		//IL_0bf4: Expected O, but got I4
		//IL_0e8b: Expected O, but got I4
		//IL_0e94: Expected O, but got I4
		//IL_1151: Expected O, but got I4
		//IL_115a: Expected O, but got I4
		//IL_1340: Expected F4, but got O
		//IL_1349: Expected O, but got I4
		//IL_135a: Expected O, but got I4
		//IL_0cc5: Expected O, but got I
		//IL_0cee: Expected I, but got O
		//IL_0f65: Expected O, but got I
		//IL_1526: Expected O, but got Ref
		//IL_0f8e: Expected I, but got O
		//IL_0d85: Expected O, but got I
		//IL_0d9e: Expected O, but got I
		//IL_0db5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dba: Expected O, but got Unknown
		//IL_0d26: Expected O, but got I
		//IL_0d2f: Expected O, but got I4
		//IL_156d: Expected O, but got Ref
		//IL_158b: Expected F4, but got O
		//IL_1025: Expected O, but got I
		//IL_103e: Expected O, but got I
		//IL_1055: Unknown result type (might be due to invalid IL or missing references)
		//IL_105a: Expected O, but got Unknown
		//IL_0fc6: Expected O, but got I
		//IL_0fcf: Expected O, but got I4
		//IL_0e20: Expected O, but got I
		//IL_0e29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2e: Expected O, but got Unknown
		//IL_0e36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3b: Expected O, but got Unknown
		//IL_0d3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d42: Expected O, but got Unknown
		//IL_124f: Expected O, but got Ref
		//IL_1272: Expected O, but got I
		//IL_127f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1284: Expected O, but got Unknown
		//IL_10c0: Expected O, but got I
		//IL_10c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ce: Expected O, but got Unknown
		//IL_10d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_10db: Expected O, but got Unknown
		//IL_0fdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe2: Expected O, but got Unknown
		//IL_15c8: Expected O, but got Ref
		//IL_144a: Expected O, but got Ref
		//IL_147b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1480: Expected O, but got Unknown
		//IL_1616: Expected O, but got Ref
		//IL_1ca4: Expected O, but got I4
		//IL_1cad: Expected O, but got I4
		//IL_16fa: Expected O, but got I
		//IL_1723: Expected I, but got O
		//IL_17bb: Expected I, but got O
		//IL_17d5: Expected O, but got I
		//IL_17e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ed: Expected O, but got Unknown
		//IL_180f: Expected I, but got O
		//IL_176b: Expected O, but got I
		//IL_1774: Expected O, but got I4
		//IL_1782: Unknown result type (might be due to invalid IL or missing references)
		//IL_1787: Expected O, but got Unknown
		//IL_1877->IL1877: Incompatible stack heights: 1 vs 0
		//IL_0378->IL1952: Incompatible stack heights: 6 vs 4
		//IL_01c1->IL008f: Incompatible stack heights: 8 vs 2
		//IL_03f7->IL19d6: Incompatible stack heights: 7 vs 5
		//IL_0738->IL1a78: Incompatible stack heights: 14 vs 8
		//IL_0df7->IL0bfe: Incompatible stack heights: 24 vs 19
		//IL_1097->IL0e9e: Incompatible stack heights: 25 vs 20
		//IL_12cd->IL1164: Incompatible stack heights: 26 vs 21
		//IL_14d9->IL1364: Incompatible stack heights: 27 vs 22
		//IL_12d3->IL12d3: Incompatible stack heights: 26 vs 21
		//IL_14df->IL14df: Incompatible stack heights: 27 vs 22
		//IL_184d->IL191a: Incompatible stack heights: 31 vs 1
		//IL_186b->IL191a: Incompatible stack heights: 31 vs 1
		//IL_1828->IL1cee: Incompatible stack heights: 36 vs 31
		object obj2 = default(object);
		object obj = (object)(&obj2);
		while (true)
		{
			object obj3 = _transform;
			bool flag = (object)_transform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_transform);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (System.Object)+10]");
		Transform.get_localPosition_Injected((IntPtr)0, out Vector3 ret);
		_previousCameraPosition = ret;
		_ = 0;
		object obj4 = Screen.width;
		object obj6;
		if ((nint)obj4 == _previousScreenWidth)
		{
			object obj5 = Screen.height;
			bool flag2 = (nint)obj5 == _previousScreenHeight;
			obj6 = (object)(&ret);
			if (flag2)
			{
				goto IL_0030;
			}
		}
		CalculateScreenSize();
		obj6 = 0;
		goto IL_0030;
		IL_0030:
		_003CDeltaTime_003Ek__BackingField = deltaTime;
		if (0.0001f > deltaTime)
		{
			return;
		}
		if (PreMoveUpdate != null)
		{
			Action<float> preMoveUpdate = PreMoveUpdate;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1697 @ rax_v258 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
		}
		List<IPreMover> preMovers = _preMovers;
		bool flag3 = _preMovers == null;
		object obj7 = 0;
		object obj8 = 0;
		while ((nint)obj8 < preMovers._size)
		{
			List<IPreMover> preMovers2 = _preMovers;
			bool flag4 = _preMovers == null;
			bool flag5 = (nint)obj7 >= preMovers2._size;
			IPreMover items = (IPreMover)(object)preMovers2._items;
			bool flag6 = preMovers2._items == null;
			object obj9 = obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rsi_v43 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+18]");
			bool flag7 = (nint)obj9 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rsi_v43 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v262 @ rdi_v22*8]");
			bool flag8 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rsi_v43 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v262 @ rdi_v22*8]");
			((IPreMover)0).PreMove(deltaTime);
			preMovers = _preMovers;
			obj7++;
			bool flag9 = _preMovers == null;
			obj8 = obj7;
		}
		ref List<CameraTarget> targets = ref *(List<CameraTarget>*)(this + 32);
		_003CPreviousTargetsMidPoint_003Ek__BackingField = _003CTargetsMidPoint_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+7C]");
		_ = 0;
		Vector3 targetsWeightedMidPoint = GetTargetsWeightedMidPoint(ref targets);
		_003CTargetsMidPoint_003Ek__BackingField = (Vector3)targetsWeightedMidPoint.x;
		_003CCameraTargetPosition_003Ek__BackingField = (Vector3)targetsWeightedMidPoint.x;
		_ = targetsWeightedMidPoint.z;
		_ = targetsWeightedMidPoint.z;
		Vector3 vectorsSum = Utils.GetVectorsSum(_influences);
		_influencesSum = (Vector3)vectorsSum.x;
		object obj11 = default(object);
		Vector3 vector = default(Vector3);
		object obj10 = obj11 + (object)vector;
		float num = vectorsSum.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+88]");
		float num2 = num + 0f;
		_ = vectorsSum.z;
		List<Vector3> influences = _influences;
		_003CCameraTargetPosition_003Ek__BackingField = vector;
		bool flag10 = _influences == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rcx_v62 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		Func<Vector3, float> vector3H = Vector3H;
		Vector3 vector2;
		if (FollowHorizontal)
		{
			bool flag11 = Vector3H == null;
			vector2 = _003CCameraTargetPosition_003Ek__BackingField;
			object obj12 = (object)(&ret);
		}
		else
		{
			object obj13 = _transform;
			bool flag12 = (object)_transform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rsi_v42 (System.Object)+10]");
			bool flag13 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rsi_v42 (System.Object)+10]");
			Transform.get_localPosition_Injected((IntPtr)0, out ret);
			bool flag14 = Vector3H == null;
			object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			_ = 0;
			vector2 = ret;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v264 @ rdi_v23 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Func<Vector3, float> vector3V = Vector3V;
		Vector3 vector3;
		if (FollowVertical)
		{
			bool flag15 = Vector3V == null;
			vector3 = _003CCameraTargetPosition_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+88]");
			object obj14 = 0;
		}
		else
		{
			object obj15 = _transform;
			bool flag16 = (object)_transform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rsi_v41 (System.Object)+10]");
			bool flag17 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rsi_v41 (System.Object)+10]");
			Transform.get_localPosition_Injected((IntPtr)0, out ret);
			bool flag18 = Vector3V == null;
			vector3 = ret;
			object obj14 = 0;
		}
		object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v265 @ rdi_v24 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Func<Vector3, float> vector3H2 = Vector3H;
		Func<float, float, Vector3> vectorHV = VectorHV;
		bool flag19 = Vector3H == null;
		object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		_ = _003CParentPosition_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v575 @ rcx_v67 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Func<Vector3, float> vector3V2 = Vector3V;
		bool flag20 = Vector3V == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v542 @ rcx_v69 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
		object obj18 = 0;
		object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Vector3 vector4 = _003CParentPosition_003Ek__BackingField;
		_ = _003CParentPosition_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v542 @ rcx_v69 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		bool flag21 = VectorHV == null;
		object obj20 = vector3 - _003CParentPosition_003Ek__BackingField;
		object obj21 = vector2 - _003CParentPosition_003Ek__BackingField;
		object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v266 @ rdi_v25 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
		object obj23 = default(object);
		_003CCameraTargetPosition_003Ek__BackingField = (Vector3)obj23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v78+8]");
		_ = 0;
		if ((object)ExclusiveTargetPosition != null)
		{
			Func<float, float, Vector3> vectorHV2 = VectorHV;
			Func<Vector3, float> vector3H3 = Vector3H;
			bool flag22 = Vector3H == null;
			object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+DC]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+E4]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v544 @ rcx_v173 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3H4 = Vector3H;
			bool flag23 = Vector3H == null;
			object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			_ = _003CParentPosition_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v545 @ rcx_v175 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3V3 = Vector3V;
			bool flag24 = (object)ExclusiveTargetPosition == null;
			bool flag25 = Vector3V == null;
			object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+DC]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+E4]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v546 @ rcx_v177 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3V4 = Vector3V;
			bool flag26 = Vector3V == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rcx_v179 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
			obj18 = 0;
			object obj27 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			vector4 = _003CParentPosition_003Ek__BackingField;
			_ = _003CParentPosition_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v547 @ rcx_v179 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			bool flag27 = VectorHV == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+DC]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+DC]");
			object obj28 = num3 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+DC]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+DC]");
			object obj29 = num4 - 0;
			object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v267 @ rdi_v47 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
			object obj31 = default(object);
			_003CCameraTargetPosition_003Ek__BackingField = (Vector3)obj31;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3033 @ rax_v225+8]");
			_ = 0;
			ExclusiveTargetPosition = (Vector3?)(object)0;
		}
		Func<float, float, Vector3> vectorHV3 = VectorHV;
		if (FollowHorizontal)
		{
			if (IsRelativeOffset)
			{
				float num5 = (float)_003CScreenSizeInWorldCoordinates_003Ek__BackingField * OffsetX;
				float num6 = num5 * 0.5f;
			}
			else
			{
				float num6 = OffsetX;
			}
		}
		else
		{
			float num6 = 0f;
		}
		if (FollowVertical)
		{
			if (IsRelativeOffset)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				float num7 = 0f * OffsetY;
				float num8 = num7 * 0.5f;
			}
			else
			{
				float num8 = OffsetY;
			}
		}
		else
		{
			float num8 = 0f;
		}
		bool flag28 = VectorHV == null;
		object obj32 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v470 @ rdx_v50 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
		object obj33 = default(object);
		float num9 = (float)obj33;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+88]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rax_v81+8]");
		object obj34 = num10 + 0;
		object obj35 = obj11 + (object)vector;
		_003CCameraTargetPosition_003Ek__BackingField = vector;
		Func<Vector3, float> vector3H5 = Vector3H;
		bool flag29 = Vector3H == null;
		object obj36 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v549 @ rcx_v75 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		float num11 = 1f / HorizontalFollowSmoothness;
		float num12 = num11 * _003CDeltaTime_003Ek__BackingField;
		float num13 = (float)vector - _previousCameraTargetHorizontalPositionSmoothed;
		float num14 = num13 / num12;
		object obj37 = num12 ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F490");
		Func<Vector3, float> vector3V5 = Vector3V;
		float num15 = _cameraTargetHorizontalPositionSmoothed - _previousCameraTargetHorizontalPositionSmoothed;
		float num16 = (float)vector - num14;
		float num17 = num15 + num14;
		float num18 = (float)obj37 * num17;
		_previousCameraTargetHorizontalPositionSmoothed = (_cameraTargetHorizontalPositionSmoothed = num18 + num16);
		bool flag30 = Vector3V == null;
		object obj38 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		_ = _003CCameraTargetPosition_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v550 @ rcx_v77 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		float num19 = 1f / VerticalFollowSmoothness;
		float num20 = num19 * _003CDeltaTime_003Ek__BackingField;
		float num21 = (float)_003CCameraTargetPosition_003Ek__BackingField - _previousCameraTargetVerticalPositionSmoothed;
		float num22 = num21 / num20;
		object obj39 = num20 ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F490");
		object obj40 = _transform;
		float num23 = (float)_003CCameraTargetPosition_003Ek__BackingField - num22;
		Func<Vector3, float> vector3H6 = Vector3H;
		float num24 = _cameraTargetVerticalPositionSmoothed - _previousCameraTargetVerticalPositionSmoothed;
		float num25 = num24 + num22;
		float num26 = (float)obj39 * num25;
		_previousCameraTargetVerticalPositionSmoothed = (_cameraTargetVerticalPositionSmoothed = num26 + num23);
		bool flag31 = (object)_transform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rsi_v24 (System.Object)+10]");
		bool flag32 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rsi_v24 (System.Object)+10]");
		Transform.get_localPosition_Injected((IntPtr)0, out ret);
		bool flag33 = Vector3H == null;
		object obj41 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v269 @ rdi_v28 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		IPreMover preMover = (IPreMover)_transform;
		float num27 = _cameraTargetHorizontalPositionSmoothed - (float)ret;
		Func<Vector3, float> vector3V6 = Vector3V;
		bool flag34 = (object)_transform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rsi_v25 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+10]");
		bool flag35 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rsi_v25 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+10]");
		float ret2;
		Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)(&ret2));
		bool flag36 = Vector3V == null;
		object obj42 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rdi_v29 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
		Vector3 vector5 = (Vector3)0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v270 @ rdi_v29 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Func<float, float, Vector3> vectorHV4 = VectorHV;
		bool flag37 = VectorHV == null;
		float num28 = _cameraTargetVerticalPositionSmoothed - ret2;
		object obj43 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v450 @ rdx_v58 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
		object obj44 = default(object);
		float num29 = (float)obj44;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3245 @ rax_v102+8]");
		float num30 = 0f;
		List<ISizeDeltaChanger> sizeDeltaChangers = _sizeDeltaChangers;
		bool flag38 = _sizeDeltaChangers == null;
		float num31 = 0f;
		float num32 = num27;
		object obj45 = 0;
		object obj46 = 0;
		object obj49 = default(object);
		while ((nint)obj46 < sizeDeltaChangers._size)
		{
			List<ISizeDeltaChanger> sizeDeltaChangers2 = _sizeDeltaChangers;
			bool flag39 = _sizeDeltaChangers == null;
			bool flag40 = (nint)obj45 >= sizeDeltaChangers2._size;
			IPreMover items2 = (IPreMover)(object)sizeDeltaChangers2._items;
			bool flag41 = sizeDeltaChangers2._items == null;
			object obj47 = obj45;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rsi_v39 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+18]");
			bool flag42 = (nint)obj47 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rsi_v39 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v272 @ rdi_v31*8]");
			ISizeDeltaChanger sizeDeltaChanger = (ISizeDeltaChanger)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rsi_v39 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v272 @ rdi_v31*8]");
			bool flag43 = (nint)0 == 0;
			nint num33 = (nint)sizeDeltaChanger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ r10_v29 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ISizeDeltaChanger>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_0d66;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ r10_v29 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ISizeDeltaChanger>)+B0]");
			object obj48 = 0;
			obj49 = 0;
			while (true)
			{
				object obj50 = obj49 + obj49;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3347 @ r8_v70+v3350 @ rax_v207*8]");
				if (0 == (nint)typeof(ISizeDeltaChanger))
				{
					break;
				}
				obj49++;
				object obj51 = obj49;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ r10_v29 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ISizeDeltaChanger>)+12E]");
				if ((nint)obj51 < 0)
				{
					continue;
				}
				goto IL_0d66;
			}
			goto IL_0dfd;
			IL_0d66:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			goto IL_0d75;
			IL_0d75:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3414 @ rax_v200+8]");
			vector5 = (Vector3)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rsi_v39 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v272 @ rdi_v31*8]");
			float num34 = ((ISizeDeltaChanger)0).AdjustSize(deltaTime, num31);
			sizeDeltaChangers = _sizeDeltaChangers;
			obj45++;
			bool flag44 = _sizeDeltaChangers != null;
			num31 = ret2;
			num32 = ret2;
			num9 = deltaTime;
			obj46 = obj45;
			if (flag44)
			{
				continue;
			}
			goto IL_0dfd;
			IL_0dfd:
			object obj52 = obj49 + obj49;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3347 @ r8_v70+8+v3417 @ rcx_v167*8]");
			object obj53 = (nint)0 << 4;
			object obj54 = obj53 + 312;
			object obj55 = obj54 + num33;
			goto IL_0d75;
		}
		List<ISizeOverrider> sizeOverriders = _sizeOverriders;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
		float num35 = 0f * 0.5f;
		float num36 = num35 + num31;
		bool flag45 = _sizeOverriders == null;
		object obj56 = 0;
		object obj57 = 0;
		object obj60 = default(object);
		while ((nint)obj57 < sizeOverriders._size)
		{
			List<ISizeOverrider> sizeOverriders2 = _sizeOverriders;
			bool flag46 = _sizeOverriders == null;
			bool flag47 = (nint)obj56 >= sizeOverriders2._size;
			IPreMover items3 = (IPreMover)(object)sizeOverriders2._items;
			bool flag48 = sizeOverriders2._items == null;
			object obj58 = obj56;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rsi_v37 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+18]");
			bool flag49 = (nint)obj58 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rsi_v37 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v275 @ rdi_v33*8]");
			ISizeOverrider sizeOverrider = (ISizeOverrider)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rsi_v37 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v275 @ rdi_v33*8]");
			bool flag50 = (nint)0 == 0;
			nint num37 = (nint)sizeOverrider;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ r10_v28 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ISizeOverrider>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_1006;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ r10_v28 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ISizeOverrider>)+B0]");
			object obj59 = 0;
			obj60 = 0;
			while (true)
			{
				object obj61 = obj60 + obj60;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3471 @ r8_v66+v3474 @ rax_v193*8]");
				if (0 == (nint)typeof(ISizeOverrider))
				{
					break;
				}
				obj60++;
				object obj62 = obj60;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ r10_v28 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ISizeOverrider>)+12E]");
				if ((nint)obj62 < 0)
				{
					continue;
				}
				goto IL_1006;
			}
			goto IL_109d;
			IL_1006:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			goto IL_1015;
			IL_1015:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3528 @ rax_v186+8]");
			vector5 = (Vector3)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rsi_v37 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v275 @ rdi_v33*8]");
			float num38 = ((ISizeOverrider)0).OverrideSize(deltaTime, num36);
			sizeOverriders = _sizeOverriders;
			obj56++;
			bool flag51 = _sizeOverriders != null;
			num36 = ret2;
			num32 = ret2;
			num9 = deltaTime;
			obj57 = obj56;
			if (flag51)
			{
				continue;
			}
			goto IL_109d;
			IL_109d:
			object obj63 = obj60 + obj60;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3471 @ r8_v66+8+v3531 @ rcx_v157*8]");
			object obj64 = (nint)0 << 4;
			object obj65 = obj64 + 312;
			object obj66 = obj65 + num37;
			goto IL_1015;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
		float num39 = 0f * 0.5f;
		bool flag52 = num36 == num39;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851D974Ch\"");
		if (!flag52)
		{
			SetScreenSize(num36);
		}
		List<IPositionDeltaChanger> positionDeltaChangers = _positionDeltaChangers;
		bool flag53 = _positionDeltaChangers == null;
		object obj67 = 0;
		object obj68 = 0;
		while ((nint)obj68 < positionDeltaChangers._size)
		{
			List<IPositionDeltaChanger> positionDeltaChangers2 = _positionDeltaChangers;
			bool flag54 = _positionDeltaChangers == null;
			bool flag55 = (nint)obj67 >= positionDeltaChangers2._size;
			IPreMover items4 = (IPreMover)(object)positionDeltaChangers2._items;
			bool flag56 = positionDeltaChangers2._items == null;
			object obj69 = obj67;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rsi_v35 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+18]");
			bool flag57 = (nint)obj69 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rsi_v35 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v278 @ rdi_v35*8]");
			bool flag58 = (nint)0 == 0;
			vector5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rsi_v35 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v278 @ rdi_v35*8]");
			Vector3 vector6 = ((IPositionDeltaChanger)0).AdjustDelta(deltaTime, vector5);
			obj67++;
			num29 = vector6.x;
			num30 = vector6.z;
			positionDeltaChangers = _positionDeltaChangers;
			bool flag59 = _positionDeltaChangers != null;
			obj68 = obj67;
			if (!flag59)
			{
				break;
			}
		}
		Vector3 localPosition = LocalPosition;
		float x = localPosition.x;
		float num40 = num30 + localPosition.z;
		_ = localPosition.x;
		object obj70 = obj11 + (object)vector;
		List<IPositionOverrider> positionOverriders = _positionOverriders;
		bool flag60 = _positionOverriders == null;
		float num41 = num40;
		float num42 = (float)vector;
		object obj71 = 0;
		Vector3 vector7 = vector;
		object obj72 = 0;
		while ((nint)obj72 < positionOverriders._size)
		{
			List<IPositionOverrider> positionOverriders2 = _positionOverriders;
			bool flag61 = _positionOverriders == null;
			bool flag62 = (nint)obj71 >= positionOverriders2._size;
			IPositionOverrider[] items5 = positionOverriders2._items;
			bool flag63 = positionOverriders2._items == null;
			bool flag64 = (nint)obj71 >= items5.Length;
			bool flag65 = items5[obj71] == null;
			vector5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			Vector3 vector8 = items5[obj71].OverridePosition(deltaTime, vector5);
			obj71++;
			num42 = vector8.x;
			num41 = vector8.z;
			positionOverriders = _positionOverriders;
			bool flag66 = _positionOverriders != null;
			num40 = deltaTime;
			vector7 = vector;
			obj72 = obj71;
			if (!flag66)
			{
				break;
			}
		}
		Func<Vector3, float> vector3H7 = Vector3H;
		object obj73 = _transform;
		Func<float, float, float, Vector3> vectorHVD = VectorHVD;
		bool flag67 = Vector3H == null;
		object obj74 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v567 @ rcx_v98 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		Func<Vector3, float> vector3V7 = Vector3V;
		bool flag68 = Vector3V == null;
		object obj75 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v568 @ rcx_v100 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		float num43 = (float)_transform;
		IPreMover vector3D = (IPreMover)(object)Vector3D;
		bool flag69 = (object)_transform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r14_v28 (System.Single)+10]");
		bool flag70 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r14_v28 (System.Single)+10]");
		Transform.get_localPosition_Injected((IntPtr)0, out ret);
		bool flag71 = Vector3D == null;
		object obj76 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rsi_v30 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+18]");
		nint num44 = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v352 @ rsi_v30 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+18] (should have been resolved before IL gen)");
		bool flag72 = VectorHVD == null;
		object obj77 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v283 @ rdi_v38 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
		bool flag73 = (object)_transform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2479 @ rax_v125+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r15_v20 (System.Object)+10]");
		bool flag74 = (nint)0 == 0;
		nint num45 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r15_v20 (System.Object)+10]");
		Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)num45);
		List<IPostMover> postMovers = _postMovers;
		bool flag75 = _postMovers == null;
		object obj78 = 0;
		object obj79 = 0;
		while ((nint)obj79 < postMovers._size)
		{
			List<IPostMover> postMovers2 = _postMovers;
			bool flag76 = _postMovers == null;
			bool flag77 = (nint)obj78 >= postMovers2._size;
			IPreMover items6 = (IPreMover)(object)postMovers2._items;
			bool flag78 = postMovers2._items == null;
			object obj80 = obj78;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rsi_v32 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+18]");
			bool flag79 = (nint)obj80 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rsi_v32 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v284 @ rdi_v41*8]");
			IPostMover postMover = (IPostMover)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rsi_v32 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v284 @ rdi_v41*8]");
			bool flag80 = (nint)0 == 0;
			nint num46 = (nint)postMover;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r10_v25 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.IPostMover>)+12E]");
			num45 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r10_v25 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.IPostMover>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_17a3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r10_v25 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.IPostMover>)+B0]");
			object obj81 = 0;
			object obj82 = 0;
			while (true)
			{
				object obj83 = obj82 + obj82;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3860 @ r8_v51+v3863 @ rax_v144*8]");
				if (0 != (nint)typeof(IPostMover))
				{
					obj82++;
					if ((nint)obj82 < num45)
					{
						continue;
					}
					goto IL_17a3;
				}
				break;
			}
			goto IL_17c0;
			IL_17c0:
			bool flag81;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rsi_v32 (Com.LuisPedroFonseca.ProCamera2D.IPreMover)+20+v284 @ rdi_v41*8]");
				((IPostMover)0).PostMove(deltaTime);
				postMovers = _postMovers;
				obj78++;
				flag81 = _postMovers != null;
				num44 = (nint)typeof(IPostMover);
				x = deltaTime;
				obj79 = obj78;
			}
			while (!flag81);
			continue;
			IL_17a3:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			num45 = (nint)typeof(IPostMover);
			goto IL_17c0;
		}
		if (PostMoveUpdate != null)
		{
			Action<float> postMoveUpdate = PostMoveUpdate;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3846 @ rax_v133 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
		}
	}

	internal YieldInstruction GetYield()
	{
		if (UpdateType != UpdateType.FixedUpdate || IgnoreTimeScale)
		{
			return null;
		}
		return _waitForFixedUpdate;
	}

	private void ResetAxisFunctions()
	{
		//IL_0015: Expected O, but got I4
		bool flag = Axis == MovementAxis.XY;
		if (!flag)
		{
			object obj = Axis - 1;
			if (!flag)
			{
				if ((nint)obj == 1)
				{
					Func<Vector3, float> vector3H = _003C_003Ec._003C_003E9__130_10;
					if (_003C_003Ec._003C_003E9__130_10 == null)
					{
						Func<Vector3, float> func = null;
						float num = ((_003C_003Ec)(object)func)._003CResetAxisFunctions_003Eb__130_10((Vector3)_003C_003Ec._003C_003E9);
						_003C_003Ec._003C_003E9__130_10 = func;
						vector3H = func;
					}
					Vector3H = vector3H;
					Func<Vector3, float> vector3V = _003C_003Ec._003C_003E9__130_11;
					if (_003C_003Ec._003C_003E9__130_11 == null)
					{
						Func<Vector3, float> func2 = null;
						float num2 = ((_003C_003Ec)(object)func2)._003CResetAxisFunctions_003Eb__130_11((Vector3)_003C_003Ec._003C_003E9);
						_003C_003Ec._003C_003E9__130_11 = func2;
						vector3V = func2;
					}
					Vector3V = vector3V;
					Func<Vector3, float> vector3D = _003C_003Ec._003C_003E9__130_12;
					if (_003C_003Ec._003C_003E9__130_12 == null)
					{
						Func<Vector3, float> func3 = null;
						float num3 = ((_003C_003Ec)(object)func3)._003CResetAxisFunctions_003Eb__130_12((Vector3)_003C_003Ec._003C_003E9);
						_003C_003Ec._003C_003E9__130_12 = func3;
						vector3D = func3;
					}
					Vector3D = vector3D;
					Func<float, float, Vector3> vectorHV = _003C_003Ec._003C_003E9__130_13;
					if (_003C_003Ec._003C_003E9__130_13 == null)
					{
						Func<float, float, Vector3> func4 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
						_003C_003Ec._003C_003E9__130_13 = func4;
						vectorHV = func4;
					}
					VectorHV = vectorHV;
					Func<float, float, float, Vector3> vectorHVD = _003C_003Ec._003C_003E9__130_14;
					if (_003C_003Ec._003C_003E9__130_14 == null)
					{
						Func<float, float, float, Vector3> func5 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7300");
						_003C_003Ec._003C_003E9__130_14 = func5;
						vectorHVD = func5;
					}
					VectorHVD = vectorHVD;
				}
			}
			else
			{
				Func<Vector3, float> vector3H2 = _003C_003Ec._003C_003E9__130_5;
				if (_003C_003Ec._003C_003E9__130_5 == null)
				{
					Func<Vector3, float> func6 = null;
					float num4 = ((_003C_003Ec)(object)func6)._003CResetAxisFunctions_003Eb__130_5((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__130_5 = func6;
					vector3H2 = func6;
				}
				Vector3H = vector3H2;
				Func<Vector3, float> vector3V2 = _003C_003Ec._003C_003E9__130_6;
				if (_003C_003Ec._003C_003E9__130_6 == null)
				{
					Func<Vector3, float> func7 = null;
					float num5 = ((_003C_003Ec)(object)func7)._003CResetAxisFunctions_003Eb__130_6((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__130_6 = func7;
					vector3V2 = func7;
				}
				Vector3V = vector3V2;
				Func<Vector3, float> vector3D2 = _003C_003Ec._003C_003E9__130_7;
				if (_003C_003Ec._003C_003E9__130_7 == null)
				{
					Func<Vector3, float> func8 = null;
					float num6 = ((_003C_003Ec)(object)func8)._003CResetAxisFunctions_003Eb__130_7((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__130_7 = func8;
					vector3D2 = func8;
				}
				Vector3D = vector3D2;
				Func<float, float, Vector3> vectorHV2 = _003C_003Ec._003C_003E9__130_8;
				if (_003C_003Ec._003C_003E9__130_8 == null)
				{
					Func<float, float, Vector3> func9 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
					_003C_003Ec._003C_003E9__130_8 = func9;
					vectorHV2 = func9;
				}
				VectorHV = vectorHV2;
				Func<float, float, float, Vector3> vectorHVD2 = _003C_003Ec._003C_003E9__130_9;
				if (_003C_003Ec._003C_003E9__130_9 == null)
				{
					Func<float, float, float, Vector3> func10 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7300");
					_003C_003Ec._003C_003E9__130_9 = func10;
					vectorHVD2 = func10;
				}
				VectorHVD = vectorHVD2;
			}
		}
		else
		{
			Func<Vector3, float> vector3H3 = _003C_003Ec._003C_003E9__130_0;
			if (_003C_003Ec._003C_003E9__130_0 == null)
			{
				Func<Vector3, float> func11 = null;
				float num7 = ((_003C_003Ec)(object)func11)._003CResetAxisFunctions_003Eb__130_0((Vector3)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__130_0 = func11;
				vector3H3 = func11;
			}
			Vector3H = vector3H3;
			Func<Vector3, float> vector3V3 = _003C_003Ec._003C_003E9__130_1;
			if (_003C_003Ec._003C_003E9__130_1 == null)
			{
				Func<Vector3, float> func12 = null;
				float num8 = ((_003C_003Ec)(object)func12)._003CResetAxisFunctions_003Eb__130_1((Vector3)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__130_1 = func12;
				vector3V3 = func12;
			}
			Vector3V = vector3V3;
			Func<Vector3, float> vector3D3 = _003C_003Ec._003C_003E9__130_2;
			if (_003C_003Ec._003C_003E9__130_2 == null)
			{
				Func<Vector3, float> func13 = null;
				float num9 = ((_003C_003Ec)(object)func13)._003CResetAxisFunctions_003Eb__130_2((Vector3)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__130_2 = func13;
				vector3D3 = func13;
			}
			Vector3D = vector3D3;
			Func<float, float, Vector3> vectorHV3 = _003C_003Ec._003C_003E9__130_3;
			if (_003C_003Ec._003C_003E9__130_3 == null)
			{
				Func<float, float, Vector3> func14 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
				_003C_003Ec._003C_003E9__130_3 = func14;
				vectorHV3 = func14;
			}
			VectorHV = vectorHV3;
			Func<float, float, float, Vector3> vectorHVD3 = _003C_003Ec._003C_003E9__130_4;
			if (_003C_003Ec._003C_003E9__130_4 == null)
			{
				Func<float, float, float, Vector3> func15 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7300");
				_003C_003Ec._003C_003E9__130_4 = func15;
				vectorHVD3 = func15;
			}
			VectorHVD = vectorHVD3;
		}
	}

	private unsafe Vector3 GetTargetsWeightedMidPoint(ref List<CameraTarget> targets)
	{
		//IL_003a: Expected F4, but got I4
		//IL_0043: Expected F4, but got I4
		//IL_0054: Expected F4, but got I4
		//IL_006f: Expected F4, but got I4
		//IL_0638: Expected native int or pointer, but got O
		//IL_0646: Expected F4, but got I4
		//IL_0673: Expected native int or pointer, but got O
		//IL_04f0: Expected F4, but got I
		//IL_04fd: Expected F4, but got O
		//IL_04f8: Expected native int or pointer, but got O
		//IL_010f: Expected O, but got I
		List<CameraTarget> list = targets;
		float z;
		Vector3 vector = default(Vector3);
		if (list._size != 0)
		{
			float num = 0f;
			float num2 = 0f;
			ref List<CameraTarget> reference = ref targets;
			float num3 = 0f;
			int i = 0;
			int num4 = 0;
			float num5 = 0f;
			int num6 = 0;
			CameraTarget cameraTarget = default(CameraTarget);
			CameraTarget cameraTarget2 = default(CameraTarget);
			for (int num7 = 0; num7 < list._size; list = targets, i++, num7 = i)
			{
				List<CameraTarget> list2 = targets;
				if (i < list2._size)
				{
					CameraTarget[] items = list2._items;
					if (items[i] != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ rax_v35+10]");
						Func<Vector3, float> func = (Func<Vector3, float>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ rax_v35+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rsi_v8 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
							if ((nint)0 != 0)
							{
								Func<Vector3, float> vector3H = Vector3H;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Vector3 targetPosition = cameraTarget.TargetPosition;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v153 @ rsi_v11 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ rax_v45+20]");
								float num8 = 0f + targetPosition.x;
								func = Vector3V;
								float num9 = num8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v46+18]");
								float num10 = num9 * 0f;
								num2 += num10;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Vector3 targetPosition2 = cameraTarget2.TargetPosition;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rsi_v8 (System.Func`2<UnityEngine.Vector3, System.Single>)+28]");
								reference = ref *(List<CameraTarget>*)null;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v156 @ rsi_v8 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v51+24]");
								float num11 = 0f + targetPosition2.x;
								float num12 = num11;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rax_v52+1C]");
								float num13 = num12 * 0f;
								num += num13;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								float num14 = num5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ rax_v53+18]");
								num5 = num14 + 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								float num15 = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v54+1C]");
								num3 = num15 + 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v55+18]");
								if ((nint)0 > (nint)0)
								{
									num6++;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ rax_v56+1C]");
								bool flag = (nint)0 <= (nint)0;
								float x = targetPosition2.x;
								float x2 = targetPosition.x;
								if (!flag)
								{
									num4++;
									x = targetPosition2.x;
									x2 = targetPosition.x;
								}
								continue;
							}
						}
					}
					targets.RemoveAt(i);
					reference = ref *(List<CameraTarget>*)null;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new IndexOutOfRangeException();
			}
			if (1f > num5 && num6 == 1)
			{
				float num16 = 1f - num5;
				num5 += num16;
			}
			bool flag2 = !(1f > num3);
			float num17 = 1f;
			if (!flag2)
			{
				bool flag3 = num4 != 1;
				num17 = 1f;
				if (!flag3)
				{
					num17 = 1f - num3;
					num3 += num17;
				}
			}
			if (num5 > 0.0001f)
			{
				num2 /= num5;
			}
			if (num3 > 0.0001f)
			{
				num /= num3;
			}
			Func<float, float, Vector3> vectorHV = VectorHV;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v178 @ rdx_v11 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rax_v27+8]");
			z = 0f;
			object obj = default(object);
			((Vector3*)(nint)vector)->x = (float)obj;
		}
		else
		{
			Transform transform = base.transform;
			if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				throw new NullReferenceException();
			}
			float x2;
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&x2));
			((Vector3*)(nint)vector)->x = x2;
			z = 0f;
		}
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	private IEnumerator ApplyInfluencesTimedRoutine(IList<Vector2> influences, float[] durations)
	{
		_003CApplyInfluencesTimedRoutine_003Ed__132 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.influences = influences;
		obj.durations = durations;
		return obj;
	}

	private IEnumerator ApplyInfluenceTimedRoutine(Vector2 influence, float duration)
	{
		_003CApplyInfluenceTimedRoutine_003Ed__133 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.duration = duration;
		obj.influence = influence;
		return obj;
	}

	private IEnumerator AdjustTargetInfluenceRoutine(CameraTarget cameraTarget, float influenceH, float influenceV, float duration, bool removeIfZeroInfluence = false)
	{
		_003CAdjustTargetInfluenceRoutine_003Ed__134 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.cameraTarget = cameraTarget;
		bool removeIfZeroInfluence2 = default(bool);
		obj.removeIfZeroInfluence = removeIfZeroInfluence2;
		obj.influenceH = influenceH;
		obj.influenceV = influenceV;
		float duration2 = default(float);
		obj.duration = duration2;
		return obj;
	}

	private IEnumerator UpdateScreenSizeRoutine(float finalSize, float duration, EaseType easeType)
	{
		_003CUpdateScreenSizeRoutine_003Ed__135 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.finalSize = finalSize;
		obj.duration = duration;
		obj.easeType = easeType;
		return obj;
	}

	private IEnumerator DollyZoomRoutine(float finalFOV, float duration, EaseType easeType)
	{
		_003CDollyZoomRoutine_003Ed__136 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.finalFOV = finalFOV;
		obj.duration = duration;
		obj.easeType = easeType;
		return obj;
	}

	private unsafe void SetScreenSize(float newSize)
	{
		//IL_0468: Expected O, but got I4
		//IL_039e: Invalid comparison between F4 and I
		//IL_03cd: Expected F4, but got I
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Expected O, but got Unknown
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_0682: Expected O, but got F4
		//IL_06c8: Expected O, but got F4
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0294: Expected O, but got I
		//IL_02d5: Expected O, but got I
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00fa: Expected I, but got O
		//IL_0527: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_014b: Expected O, but got I
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0227: Expected F4, but got O
		//IL_0587: Unknown result type (might be due to invalid IL or missing references)
		//IL_058c: Expected O, but got Unknown
		//IL_064d->IL0431: Incompatible stack heights: 1 vs 0
		//IL_0267->IL0431: Incompatible stack heights: 1 vs 0
		//IL_00af->IL0431: Incompatible stack heights: 1 vs 0
		//IL_0413->IL0431: Incompatible stack heights: 1 vs 0
		//IL_060f->IL0431: Incompatible stack heights: 2 vs 0
		//IL_04ec->IL0431: Incompatible stack heights: 2 vs 0
		//IL_011e->IL0431: Incompatible stack heights: 2 vs 0
		//IL_062e->IL0431: Incompatible stack heights: 2 vs 0
		//IL_038e->IL03ef: Incompatible stack heights: 2 vs 1
		//IL_055b->IL0431: Incompatible stack heights: 3 vs 0
		//IL_0189->IL0431: Incompatible stack heights: 3 vs 0
		//IL_01d7->IL0431: Incompatible stack heights: 3 vs 0
		//IL_05ab->IL03ef: Incompatible stack heights: 4 vs 1
		Camera gameCamera = GameCamera;
		float num6 = default(float);
		float num7;
		if ((object)GameCamera != null)
		{
			bool flag = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
			object obj = Camera.get_orthographic_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr);
			if (obj == null)
			{
				Camera camera = (Camera)(object)_transform;
				object obj3 = default(object);
				if ((ZoomWithFOV ? 1 : 0) == (nint)obj)
				{
					Func<float, float, float, Vector3> vectorHVD = VectorHVD;
					Func<Vector3, float> vector3H = Vector3H;
					if ((object)_transform != null)
					{
						_ = 0;
						_ = 0;
						bool flag2 = ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0;
						object obj2 = obj3 - 80;
						Transform.get_localPosition_Injected(((UnityEngine.Object)camera).m_CachedPtr, out *(Vector3*)obj2);
						if (Vector3H != null)
						{
							object obj4 = obj3 - 64;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-48]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v102 @ r14_v17 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							nint num = (nint)_transform;
							Func<Vector3, float> vector3V = Vector3V;
							if ((object)_transform != null)
							{
								_ = 0;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rsi_v19 (System.IntPtr)+10]");
								bool flag3 = (nint)0 == 0;
								object obj5 = obj3 - 80;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rsi_v19 (System.IntPtr)+10]");
								Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj5);
								if (Vector3V != null)
								{
									object obj6 = obj3 - 64;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r14_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-50]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-48]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v103 @ r14_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									if ((object)GameCamera != null)
									{
										float fieldOfView = GameCamera.fieldOfView;
										float num2 = fieldOfView * 0.5f;
										float num3 = num2 * ((float)Math.PI / 180f);
										if (VectorHVD != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B745E0");
											object obj8 = obj3 - 80;
											float num4 = newSize / num3;
											float num5 = num4 * _originalCameraDepthSign;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v107 @ r13_v16 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
											object obj9 = default(object);
											num6 = (float)obj9;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1261 @ rax_v76+8]");
											_ = 0;
											bool flag4 = ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0;
											object obj10 = obj3 - 64;
											Transform.set_localPosition_Injected(((UnityEngine.Object)camera).m_CachedPtr, ref *(Vector3*)obj10);
											num7 = newSize;
											goto IL_03ef;
										}
									}
								}
							}
						}
					}
				}
				else
				{
					Func<Vector3, float> vector3D = Vector3D;
					if ((object)_transform != null)
					{
						_ = 0;
						_ = 0;
						bool flag5 = ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0;
						object obj11 = obj3 - 80;
						Transform.get_localPosition_Injected(((UnityEngine.Object)camera).m_CachedPtr, out *(Vector3*)obj11);
						if (Vector3D != null)
						{
							object obj10 = obj3 - 64;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r14_v16 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-48]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v104 @ r14_v16 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-50]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
							object obj12 = num8 & 0;
							float num9 = newSize / (float)obj12;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DEF0");
							float num10 = num9 + num9;
							num6 = num10 * 57.29578f;
							bool flag6 = 0.1f > num6;
							float num11 = 0.1f;
							if (!flag6)
							{
								bool flag7 = !(num6 > 179.9f);
								num11 = 179.9f;
								if (flag7)
								{
									goto IL_0614;
								}
							}
							num6 = num11;
							goto IL_0614;
						}
					}
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
				bool flag8 = !(newSize < 0f);
				num7 = newSize;
				if (!flag8)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
					num7 = 0f;
				}
				if ((object)GameCamera != null)
				{
					GameCamera.orthographicSize = num7;
					float num5 = num7;
					goto IL_03ef;
				}
			}
		}
		goto IL_0431;
		IL_0614:
		if ((object)GameCamera != null)
		{
			GameCamera.fieldOfView = num6;
			float num5 = num6;
			num7 = newSize;
			goto IL_03ef;
		}
		goto IL_0431;
		IL_0431:
		throw new NullReferenceException();
		IL_03ef:
		Camera gameCamera2 = GameCamera;
		if ((object)GameCamera != null)
		{
			bool flag9 = ((UnityEngine.Object)gameCamera2).m_CachedPtr == (IntPtr)0;
			object obj13 = Camera.get_aspect_Injected(((UnityEngine.Object)gameCamera2).m_CachedPtr);
			Action<Vector2> onCameraResize = OnCameraResize;
			float num12 = num7 + num7;
			float num13 = num7 + num7;
			float num14 = num6 * num12;
			_003CScreenSizeInWorldCoordinates_003Ek__BackingField = (Vector2)num14;
			if (OnCameraResize != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1055 @ rax_v43 (System.Action`1<UnityEngine.Vector2>)+18] (should have been resolved before IL gen)");
			}
			return;
		}
		goto IL_0431;
	}

	private float GetCameraDistanceForFOV(float fov, float cameraHeight)
	{
		float num = fov * 0.5f;
		float num2 = num * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B745E0");
		float num3 = num2 + num2;
		return cameraHeight / num3;
	}

	public void AddPreMover(IPreMover mover)
	{
		List<object> preMovers = (List<object>)(object)_preMovers;
		int version = preMovers._version + 1;
		preMovers._version = version;
		object[] items = preMovers._items;
		if (preMovers._size >= items.Length)
		{
			preMovers.AddWithResize((object)mover);
			return;
		}
		int size = preMovers._size + 1;
		preMovers._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void RemovePreMover(IPreMover mover)
	{
		bool flag = ((List<object>)(object)_preMovers).Remove((object)mover);
	}

	public void SortPreMovers()
	{
		Func<IPreMover, int> keySelector = _003C_003Ec._003C_003E9__141_0;
		if (_003C_003Ec._003C_003E9__141_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__141_0 = delegate(IPreMover a)
			{
				//IL_0022: Expected I4, but got O
				if (a == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (int)ex2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			});
		}
		IOrderedEnumerable<IPreMover> orderedEnumerable = Enumerable.OrderBy(_preMovers, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> preMovers = new List<object>(orderedEnumerable);
			_preMovers = (List<IPreMover>)(object)preMovers;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void AddPositionDeltaChanger(IPositionDeltaChanger changer)
	{
		List<object> positionDeltaChangers = (List<object>)(object)_positionDeltaChangers;
		int version = positionDeltaChangers._version + 1;
		positionDeltaChangers._version = version;
		object[] items = positionDeltaChangers._items;
		if (positionDeltaChangers._size >= items.Length)
		{
			positionDeltaChangers.AddWithResize((object)changer);
			return;
		}
		int size = positionDeltaChangers._size + 1;
		positionDeltaChangers._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void RemovePositionDeltaChanger(IPositionDeltaChanger changer)
	{
		bool flag = ((List<object>)(object)_positionDeltaChangers).Remove((object)changer);
	}

	public void SortPositionDeltaChangers()
	{
		Func<IPositionDeltaChanger, int> keySelector = _003C_003Ec._003C_003E9__144_0;
		if (_003C_003Ec._003C_003E9__144_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__144_0 = delegate(IPositionDeltaChanger a)
			{
				//IL_0022: Expected I4, but got O
				if (a == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (int)ex2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			});
		}
		IOrderedEnumerable<IPositionDeltaChanger> orderedEnumerable = Enumerable.OrderBy(_positionDeltaChangers, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> positionDeltaChangers = new List<object>(orderedEnumerable);
			_positionDeltaChangers = (List<IPositionDeltaChanger>)(object)positionDeltaChangers;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void AddPositionOverrider(IPositionOverrider overrider)
	{
		List<object> positionOverriders = (List<object>)(object)_positionOverriders;
		int version = positionOverriders._version + 1;
		positionOverriders._version = version;
		object[] items = positionOverriders._items;
		if (positionOverriders._size >= items.Length)
		{
			positionOverriders.AddWithResize((object)overrider);
			return;
		}
		int size = positionOverriders._size + 1;
		positionOverriders._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void RemovePositionOverrider(IPositionOverrider overrider)
	{
		bool flag = ((List<object>)(object)_positionOverriders).Remove((object)overrider);
	}

	public void SortPositionOverriders()
	{
		Func<IPositionOverrider, int> keySelector = _003C_003Ec._003C_003E9__147_0;
		if (_003C_003Ec._003C_003E9__147_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__147_0 = delegate(IPositionOverrider a)
			{
				//IL_0022: Expected I4, but got O
				if (a == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (int)ex2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			});
		}
		IOrderedEnumerable<IPositionOverrider> orderedEnumerable = Enumerable.OrderBy(_positionOverriders, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> positionOverriders = new List<object>(orderedEnumerable);
			_positionOverriders = (List<IPositionOverrider>)(object)positionOverriders;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void AddSizeDeltaChanger(ISizeDeltaChanger changer)
	{
		List<object> sizeDeltaChangers = (List<object>)(object)_sizeDeltaChangers;
		int version = sizeDeltaChangers._version + 1;
		sizeDeltaChangers._version = version;
		object[] items = sizeDeltaChangers._items;
		if (sizeDeltaChangers._size >= items.Length)
		{
			sizeDeltaChangers.AddWithResize((object)changer);
			return;
		}
		int size = sizeDeltaChangers._size + 1;
		sizeDeltaChangers._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void RemoveSizeDeltaChanger(ISizeDeltaChanger changer)
	{
		bool flag = ((List<object>)(object)_sizeDeltaChangers).Remove((object)changer);
	}

	public void SortSizeDeltaChangers()
	{
		Func<ISizeDeltaChanger, int> keySelector = _003C_003Ec._003C_003E9__150_0;
		if (_003C_003Ec._003C_003E9__150_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__150_0 = delegate(ISizeDeltaChanger a)
			{
				//IL_0022: Expected I4, but got O
				if (a == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (int)ex2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			});
		}
		IOrderedEnumerable<ISizeDeltaChanger> orderedEnumerable = Enumerable.OrderBy(_sizeDeltaChangers, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> sizeDeltaChangers = new List<object>(orderedEnumerable);
			_sizeDeltaChangers = (List<ISizeDeltaChanger>)(object)sizeDeltaChangers;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void AddSizeOverrider(ISizeOverrider overrider)
	{
		List<object> sizeOverriders = (List<object>)(object)_sizeOverriders;
		int version = sizeOverriders._version + 1;
		sizeOverriders._version = version;
		object[] items = sizeOverriders._items;
		if (sizeOverriders._size >= items.Length)
		{
			sizeOverriders.AddWithResize((object)overrider);
			return;
		}
		int size = sizeOverriders._size + 1;
		sizeOverriders._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void RemoveSizeOverrider(ISizeOverrider overrider)
	{
		bool flag = ((List<object>)(object)_sizeOverriders).Remove((object)overrider);
	}

	public void SortSizeOverriders()
	{
		Func<ISizeOverrider, int> keySelector = _003C_003Ec._003C_003E9__153_0;
		if (_003C_003Ec._003C_003E9__153_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__153_0 = delegate(ISizeOverrider a)
			{
				//IL_0022: Expected I4, but got O
				if (a == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (int)ex2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			});
		}
		IOrderedEnumerable<ISizeOverrider> orderedEnumerable = Enumerable.OrderBy(_sizeOverriders, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> sizeOverriders = new List<object>(orderedEnumerable);
			_sizeOverriders = (List<ISizeOverrider>)(object)sizeOverriders;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void AddPostMover(IPostMover mover)
	{
		List<object> postMovers = (List<object>)(object)_postMovers;
		int version = postMovers._version + 1;
		postMovers._version = version;
		object[] items = postMovers._items;
		if (postMovers._size >= items.Length)
		{
			postMovers.AddWithResize((object)mover);
			return;
		}
		int size = postMovers._size + 1;
		postMovers._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void RemovePostMover(IPostMover mover)
	{
		bool flag = ((List<object>)(object)_postMovers).Remove((object)mover);
	}

	public void SortPostMovers()
	{
		Func<IPostMover, int> keySelector = _003C_003Ec._003C_003E9__156_0;
		if (_003C_003Ec._003C_003E9__156_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__156_0 = delegate(IPostMover a)
			{
				//IL_0022: Expected I4, but got O
				if (a == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (int)ex2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				int result = default(int);
				return result;
			});
		}
		IOrderedEnumerable<IPostMover> orderedEnumerable = Enumerable.OrderBy(_postMovers, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> postMovers = new List<object>(orderedEnumerable);
			_postMovers = (List<IPostMover>)(object)postMovers;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
		ResetAxisFunctions();
	}

	public ProCamera2D()
	{
		//IL_013a: Expected I, but got O
		List<CameraTarget> cameraTargets = new List<CameraTarget>();
		CameraTargets = cameraTargets;
		FollowHorizontal = true;
		HorizontalFollowSmoothness = 0.15f;
		FollowVertical = true;
		VerticalFollowSmoothness = 0.15f;
		IsRelativeOffset = true;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_influencesSum = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		List<Vector3> influences = new List<Vector3>();
		_influences = influences;
		WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
		_waitForFixedUpdate = waitForFixedUpdate;
		List<IPreMover> preMovers = new List<IPreMover>();
		_preMovers = preMovers;
		List<IPositionDeltaChanger> positionDeltaChangers = new List<IPositionDeltaChanger>();
		_positionDeltaChangers = positionDeltaChangers;
		List<IPositionOverrider> positionOverriders = new List<IPositionOverrider>();
		_positionOverriders = positionOverriders;
		List<ISizeDeltaChanger> sizeDeltaChangers = new List<ISizeDeltaChanger>();
		_sizeDeltaChangers = sizeDeltaChangers;
		List<ISizeOverrider> sizeOverriders = new List<ISizeOverrider>();
		_sizeOverriders = sizeOverriders;
		List<IPostMover> postMovers = new List<IPostMover>();
		_postMovers = postMovers;
	}

	unsafe static ProCamera2D()
	{
		//IL_014d: Expected O, but got Ref
		//IL_0169: Expected O, but got Ref
		Version version = new Version
		{
			_Build = -1
		};
		if ("2.9.0" == null)
		{
			ArgumentNullException ex = new ArgumentNullException("input");
			throw ex;
		}
		object obj = default(object);
		Version version2 = Version.ParseVersion((ReadOnlySpan<char>)(&obj), true);
		bool flag = (object)version2 == null;
		ReadOnlySpan<char> readOnlySpan = (ReadOnlySpan<char>)(&obj);
		if (!flag)
		{
			version._Major = version2._Major;
			version._Minor = version2._Minor;
			version._Build = version2._Build;
			version._Revision = version2._Revision;
			Version = version;
			return;
		}
		throw new NullReferenceException();
	}
}
