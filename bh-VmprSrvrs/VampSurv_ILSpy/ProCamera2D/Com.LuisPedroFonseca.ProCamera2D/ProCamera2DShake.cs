using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DShake : BasePC2D
{
	private sealed class _003CApplyShakeTimedRoutine_003Ed__44(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DShake _003C_003E4__this;

		public bool ignoreTimeScale;

		public float duration;

		public Vector2 shake;

		public Quaternion rotation;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_006f: Expected I4, but got I8
			//IL_03f7: Expected I4, but got O
			//IL_0402: Invalid comparison between F4 and I4
			//IL_0100: Expected F4, but got I4
			//IL_0445: Expected O, but got I
			//IL_01be: Expected F4, but got I4
			//IL_0263: Expected O, but got I
			//IL_02e4: Expected O, but got I
			//IL_0304: Expected O, but got I
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_0319: Expected O, but got Unknown
			//IL_02c9: Expected O, but got Ref
			//IL_02c9: Expected O, but got I
			BasePC2D basePC2D = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_03e9;
				}
				_ = 0;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_03af;
				}
				_003C_003E1__state = -1;
			}
			if (!(duration > 0f))
			{
				goto IL_03af;
			}
			float num;
			if (!ignoreTimeScale)
			{
				if ((object)_003C_003E4__this != null)
				{
					ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D != null)
					{
						num = duration - proCamera2D._003CDeltaTime_003Ek__BackingField;
						float num2 = 0f;
						goto IL_0419;
					}
				}
			}
			else if ((object)_003C_003E4__this != null)
			{
				ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D2 != null)
				{
					float num3;
					float num2 = default(float);
					if (proCamera2D2.UpdateType != UpdateType.LateUpdate)
					{
						ProCamera2D proCamera2D3 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D3 == null)
						{
							goto IL_03e9;
						}
						bool flag = proCamera2D3.UpdateType != UpdateType.FixedUpdate;
						num2 = 0f;
						if (flag)
						{
							goto IL_0428;
						}
						num3 = duration;
						num2 = Time.fixedUnscaledDeltaTime;
					}
					else
					{
						num3 = duration;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45B10");
					}
					num = num3 - num2;
					goto IL_0419;
				}
			}
			goto IL_03e9;
			IL_0419:
			duration = num;
			goto IL_0428;
			IL_0428:
			Func<float, float, Vector3> vectorHV = basePC2D.VectorHV;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B8]");
			List<Vector3> list = (List<Vector3>)0;
			if (basePC2D.VectorHV != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v108 @ rdx_v3 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v5+18]");
						if (num4 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B8]");
							object obj2 = default(object);
							((List<Vector3>)0).AddWithResize((Vector3)(&obj2));
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj3 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj4 = (nint)0 * (nint)2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbp_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj5 = 0 + obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v6+8]");
							_ = 0;
						}
						_ = rotation;
						ProCamera2D proCamera2D4 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D4 != null)
						{
							bool flag2 = proCamera2D4.UpdateType != UpdateType.FixedUpdate;
							WaitForFixedUpdate waitForFixedUpdate = null;
							if (!flag2)
							{
								bool flag3 = proCamera2D4.IgnoreTimeScale;
								waitForFixedUpdate = null;
								if (!flag3)
								{
									waitForFixedUpdate = proCamera2D4._waitForFixedUpdate;
								}
							}
							_003C_003E2__current = waitForFixedUpdate;
							_003C_003E1__state = 1;
							return true;
						}
					}
				}
			}
			goto IL_03e9;
			IL_03af:
			return false;
			IL_03e9:
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

	private sealed class _003CApplyShakesTimedRoutine_003Ed__43(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DShake _003C_003E4__this;

		public float[] durations;

		public IList<Vector2> shakes;

		public IList<Quaternion> rotations;

		public bool ignoreTimeScale;

		private int _003Ccount_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0099: Expected I4, but got I8
			//IL_0299: Expected I4, but got O
			//IL_00ae: Expected O, but got I4
			//IL_0063: Expected I4, but got I8
			//IL_01c9: Expected F4, but got I
			//IL_01db: Expected O, but got F4
			ProCamera2DShake proCamera2DShake = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				List<Coroutine> shakeTimedCoroutines = new List<Coroutine>();
				if ((object)_003C_003E4__this == null)
				{
					goto IL_028b;
				}
				proCamera2DShake._shakeTimedCoroutines = shakeTimedCoroutines;
				_003Ccount_003E5__2 = -1;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0251;
				}
				_003C_003E1__state = -1;
			}
			float[] array = durations;
			if (durations != null)
			{
				object obj = array.Length - 1;
				if (_003Ccount_003E5__2 >= (nint)obj)
				{
					goto IL_0251;
				}
				int num = _003Ccount_003E5__2;
				float[] array2 = durations;
				int num2 = _003Ccount_003E5__2 + 1;
				_003Ccount_003E5__2 = num2;
				if (durations != null && shakes != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F6370");
					if (rotations != null)
					{
						Quaternion quaternion = rotations.get_Item(_003Ccount_003E5__2);
						if ((object)_003C_003E4__this != null)
						{
							_003CApplyShakeTimedRoutine_003Ed__44 obj2 = null;
							obj2._003C_003E1__state = 0;
							obj2._003C_003E4__this = _003C_003E4__this;
							Vector2 shake = default(Vector2);
							obj2.shake = shake;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rcx_v4 (System.Single[])+24+v267 @ rax_v8 (System.Int32)*4]");
							obj2.duration = 0f;
							obj2.rotation = (Quaternion)quaternion.x;
							obj2.ignoreTimeScale = ignoreTimeScale;
							Coroutine coroutine = _003C_003E4__this.StartCoroutine(obj2);
							if (proCamera2DShake._shakeTimedCoroutines != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7730");
								_003C_003E2__current = coroutine;
								_003C_003E1__state = 1;
								return true;
							}
						}
					}
				}
			}
			goto IL_028b;
			IL_028b:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0251:
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

	private sealed class _003CCalculateConstantShakePosition_003Ed__46(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float frequencyMin;

		public float frequencyMax;

		public float amplitudeX;

		public float amplitudeY;

		public float amplitudeZ;

		public int index;

		public ProCamera2DShake _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0055: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_025c: Expected O, but got I
			//IL_00df: Expected O, but got I
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Expected O, but got Unknown
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Expected O, but got Unknown
			//IL_0151: Expected O, but got I4
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Expected O, but got Unknown
			//IL_0177->IL0261: Incompatible stack heights: 1 vs 0
			BasePC2D basePC2D = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag && (nint)obj != 1)
				{
					return false;
				}
			}
			_003C_003E1__state = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+114]");
			if ((nint)0 != 0)
			{
				float num = UnityEngine.Random.Range(frequencyMin, frequencyMax);
				UnityEngine.Random.get_insideUnitSphere_Injected(out Vector3 ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+100]");
				object obj2 = 0;
				int num2 = index;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v15+18]");
				if ((nint)num2 < (nint)0)
				{
					Func<float, float, float, Vector3> vectorHVD = basePC2D.VectorHVD;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+100]");
					object obj3 = 0;
					object obj4 = ret * amplitudeX;
					object obj6 = default(object);
					object obj5 = obj6 * amplitudeY;
					object obj7 = 0 * amplitudeZ;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v114 @ rdx_v13 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
					int num3 = index;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rsi_v7+18]");
					bool flag2 = (nint)num3 >= (nint)0;
					object obj8 = index * 2;
					object obj9 = obj8 + index;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v34+8]");
					_ = 0;
				}
				ProCamera2D proCamera2D = basePC2D.ProCamera2D;
				if (!proCamera2D.IgnoreTimeScale)
				{
					WaitForSeconds waitForSeconds = null;
					waitForSeconds.m_Seconds = num;
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 2;
				}
				else
				{
					WaitForSecondsRealtime waitForSecondsRealtime = null;
					waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = num;
					waitForSecondsRealtime.m_WaitUntilTime = -1f;
					_003C_003E2__current = waitForSecondsRealtime;
					_003C_003E1__state = 1;
				}
				return true;
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

	private sealed class _003CConstantShakeRoutine_003Ed__47(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DShake _003C_003E4__this;

		public float intensity;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_05bb: Expected I4, but got O
			//IL_0092: Invalid comparison between F4 and I4
			//IL_00ba: Expected O, but got I
			//IL_00ce: Expected O, but got I
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Expected O, but got Unknown
			//IL_0250: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Expected O, but got Unknown
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Expected O, but got Unknown
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_030e: Expected O, but got Unknown
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0323: Expected O, but got Unknown
			//IL_03d6: Expected O, but got I
			//IL_041e: Expected O, but got I
			//IL_049f: Expected O, but got I
			//IL_04bf: Expected O, but got I
			//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d4: Expected O, but got Unknown
			//IL_0484: Expected O, but got Ref
			//IL_0484: Expected O, but got I
			BasePC2D basePC2D = _003C_003E4__this;
			if (_003C_003E1__state > 1)
			{
				goto IL_0576;
			}
			_003C_003E1__state = -1;
			if ((object)_003C_003E4__this != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+114]");
				if ((nint)0 == 0)
				{
					goto IL_0576;
				}
				ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D != null)
				{
					if (!(proCamera2D._003CDeltaTime_003Ek__BackingField > 0f))
					{
						goto IL_05bb;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+100]");
					Vector3 vectorsSum = Utils.GetVectorsSum((IList<Vector3>)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+100]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+100]");
					if ((nint)0 != 0)
					{
						float num = vectorsSum.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v12+18]");
						float num2 = num / 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v12+18]");
						object obj3 = default(object);
						object obj2 = obj3 / 0;
						float num3 = vectorsSum.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v12+18]");
						float num4 = num3 / 0f;
						ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D2 != null)
						{
							float num5 = intensity * proCamera2D2._003CDeltaTime_003Ek__BackingField;
							float num6 = num2 - num2;
							float num7 = num6 / num5;
							ProCamera2D proCamera2D3 = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D3 != null)
							{
								float num8 = intensity * proCamera2D3._003CDeltaTime_003Ek__BackingField;
								object obj4 = obj2 - obj2;
								float num9 = (float)obj4 / num8;
								ProCamera2D proCamera2D4 = _003C_003E4__this.ProCamera2D;
								if ((object)proCamera2D4 != null)
								{
									float num10 = intensity * proCamera2D4._003CDeltaTime_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
									object obj5 = num5 ^ 0;
									float num11 = num4 - num4;
									float num12 = num11 / num10;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F490");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
									object obj6 = num8 ^ 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+108]");
									float num13 = 0f - num2;
									float num14 = num2 - num7;
									float num15 = num13 + num7;
									float num16 = (float)obj5 * num15;
									float num17 = num16 + num14;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F490");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
									object obj7 = num10 ^ 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+10C]");
									object obj8 = 0 - obj2;
									float num18 = (float)obj2 - num9;
									float num19 = (float)obj8 + num9;
									float num20 = (float)obj6 * num19;
									float num21 = num20 + num18;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F490");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+110]");
									float num22 = 0f - num4;
									float num23 = num4 - num12;
									float num24 = num22 + num12;
									float num25 = (float)obj7 * num24;
									float num26 = num25 + num23;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E8]");
									List<Vector3> list = (List<Vector3>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
										object obj9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
											nint num27 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ r8_v10+18]");
											if (num27 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E8]");
												object obj10 = default(object);
												((List<Vector3>)0).AddWithResize((Vector3)(&obj10));
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
												object obj11 = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
												object obj12 = (nint)0 * (nint)2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
												object obj13 = 0 + obj12;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+108]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+110]");
												_ = 0;
											}
											goto IL_05bb;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_05ad;
			IL_05bb:
			ProCamera2D proCamera2D5 = _003C_003E4__this.ProCamera2D;
			if ((object)proCamera2D5 != null)
			{
				WaitForFixedUpdate waitForFixedUpdate = ((proCamera2D5.UpdateType != UpdateType.FixedUpdate) ? null : ((!proCamera2D5.IgnoreTimeScale) ? proCamera2D5._waitForFixedUpdate : null));
				_003C_003E2__current = waitForFixedUpdate;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_05ad;
			IL_05ad:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0576:
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

	private sealed class _003CShakeRoutine_003Ed__41(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DShake _003C_003E4__this;

		public bool ignoreTimeScale;

		public float smoothness;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_001c: Expected I4, but got I8
			//IL_004b: Expected O, but got I
			//IL_024e: Expected O, but got I
			//IL_0746: Expected I, but got O
			//IL_0766: Expected F4, but got I
			//IL_00a5: Expected O, but got I
			//IL_033e: Expected O, but got I
			//IL_02c6: Invalid comparison between F4 and I4
			//IL_02d8: Expected O, but got I4
			//IL_02e1: Expected F4, but got O
			//IL_0798: Expected O, but got I
			//IL_0606: Expected O, but got Ref
			//IL_0899: Expected O, but got Ref
			//IL_02ff: Expected O, but got I
			//IL_0aa6: Expected I, but got O
			//IL_0ac3: Expected O, but got I
			//IL_0ae0: Expected O, but got I
			//IL_0afd: Expected O, but got I
			//IL_0b78: Expected O, but got F4
			//IL_0b86: Expected O, but got Ref
			//IL_0b94: Expected O, but got Ref
			//IL_0819: Unknown result type (might be due to invalid IL or missing references)
			//IL_081e: Expected Ref, but got Unknown
			//IL_08e2: Expected O, but got Ref
			//IL_0907: Expected O, but got I
			//IL_0159: Expected F8, but got I4
			//IL_047d: Expected F4, but got I
			//IL_07f4: Expected O, but got Ref
			//IL_0b28: Expected O, but got F4
			//IL_0b36: Expected O, but got Ref
			//IL_0b44: Expected O, but got Ref
			//IL_03f6: Invalid comparison between F4 and I4
			//IL_0962: Unknown result type (might be due to invalid IL or missing references)
			//IL_0967: Expected Ref, but got Unknown
			//IL_0425: Expected F4, but got I
			//IL_0662: Expected O, but got Ref
			//IL_0694: Expected O, but got I
			//IL_0716: Unknown result type (might be due to invalid IL or missing references)
			//IL_071b: Expected F4, but got Unknown
			//IL_09d1: Expected O, but got Ref
			//IL_0bcd: Expected O, but got Ref
			//IL_0bdb: Expected O, but got Ref
			//IL_0be9: Expected O, but got Ref
			//IL_0bfe: Expected F4, but got Ref
			//IL_0a3a: Expected O, but got Ref
			//IL_085e->IL0788: Incompatible stack heights: 1 vs 0
			//IL_0192->IL023d: Incompatible stack heights: 1 vs 0
			//IL_04ae->IL059b: Incompatible stack heights: 3 vs 0
			//IL_01c1->IL059b: Incompatible stack heights: 1 vs 0
			//IL_03e3->IL059b: Incompatible stack heights: 3 vs 0
			//IL_0952->IL059b: Incompatible stack heights: 3 vs 0
			//IL_0456->IL059b: Incompatible stack heights: 3 vs 0
			//IL_021f->IL023d: Incompatible stack heights: 2 vs 0
			//IL_0595->IL0a93: Incompatible stack heights: 7 vs 2
			object obj2 = default(object);
			object obj = (object)(&obj2);
			BasePC2D basePC2D = _003C_003E4__this;
			float num16;
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v53+18]");
						if ((nint)0 > (nint)0)
						{
							goto IL_023d;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
						if ((nint)0 != 0)
						{
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rsi_v27 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rsi_v27 (System.Object)+10]");
							Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj5);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+F0]");
							_ = 0;
							nint num = (nint)typeof(Math);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
							object obj6 = num2 - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-65]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-55]");
							object obj7 = num3 - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-61]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+F8]");
							object obj8 = num4 - 0;
							object obj9 = obj7 * obj7;
							object obj10 = obj6 * obj6;
							object obj11 = obj8 * obj8;
							object obj12 = obj9 + obj10;
							double d = (double)obj12 + (double)obj11;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v106 (Il2CppClass<System.Math>)+E4]");
							double num5;
							if ((nint)0 <= (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
								num5 = 0.0;
							}
							else
							{
								num5 = Math.Sqrt(d);
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
							if (num5 > 0.009999999776482582)
							{
								goto IL_023d;
							}
							object transform = basePC2D._transform;
							if ((object)basePC2D._transform != null)
							{
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rsi_v29 (System.Object)+10]");
								bool flag2 = (nint)0 == 0;
								object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rsi_v29 (System.Object)+10]");
								Transform.get_localRotation_Injected((IntPtr)0, out *(Quaternion*)obj13);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+D0]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
								object obj14 = num6 * 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-45]");
								float num8 = default(float);
								float num7 = 0f * num8;
								float num9 = num8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
								float num10 = num9 * 0f;
								float num11 = (float)obj14 + num7;
								float num12 = num8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-3D]");
								float num13 = num12 * 0f;
								float num14 = num11 + num10;
								float num15 = num14 + num13;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
								num16 = num15 & 0;
								if (!(1f > num16))
								{
									num16 = 1f;
								}
								if (!(num16 > 0.999999f))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6CB40");
									float num17 = num16 + num16;
									float num18 = num17 * 57.29578f;
									if (num18 > 0.01f)
									{
										goto IL_023d;
									}
								}
								_003C_003E4__this.ShakeCompleted();
								return false;
							}
						}
					}
				}
				goto IL_059b;
			}
			return false;
			IL_0928:
			object transform2 = basePC2D._transform;
			ref float reference;
			if ((object)basePC2D._transform != null)
			{
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r14_v27 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r14_v27 (System.Object)+10]");
				Transform.get_localRotation_Injected((IntPtr)0, out *(Quaternion*)obj15);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
				_ = 0;
				object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
				object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Quaternion.Slerp_Injected(ref *(Quaternion*)obj18, ref *(Quaternion*)obj17, (float)(nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference), out *(Quaternion*)obj16);
				object transform3 = basePC2D._transform;
				bool flag4 = (object)basePC2D._transform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1934 @ r14_v28 (System.Object)+10]");
				bool flag5 = (nint)0 == 0;
				object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1934 @ r14_v28 (System.Object)+10]");
				Transform.set_localRotation_Injected((IntPtr)0, ref *(Quaternion*)obj19);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+D0]");
				_ = 0;
				ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
				bool flag6 = (object)proCamera2D == null;
				bool flag7 = proCamera2D.UpdateType != UpdateType.FixedUpdate;
				WaitForFixedUpdate waitForFixedUpdate = null;
				if (!flag7)
				{
					bool flag8 = proCamera2D.IgnoreTimeScale;
					waitForFixedUpdate = null;
					if (!flag8)
					{
						waitForFixedUpdate = proCamera2D._waitForFixedUpdate;
					}
				}
				_003C_003E2__current = waitForFixedUpdate;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_059b;
			IL_023d:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B8]");
			Vector3 vectorsSum = Utils.GetVectorsSum((IList<Vector3>)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+F0]");
			_ = 0;
			float num19 = vectorsSum.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+F8]");
			float num20 = num19 + 0f;
			_ = vectorsSum.x;
			nint num21 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v58 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v53 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			float num23 = 0f;
			Vector3 vector;
			bool num25;
			Vector3 current;
			float num24;
			if (!ignoreTimeScale)
			{
				ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D2 != null)
				{
					bool flag9 = !(proCamera2D2._003CDeltaTime_003Ek__BackingField > 0f);
					vector = (Vector3)0;
					num24 = (float)Vector3.zeroVector;
					if (flag9)
					{
						goto IL_0788;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
					object obj20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
					if ((nint)0 != 0)
					{
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r14_v30 (System.Object)+10]");
						bool flag10 = (nint)0 == 0;
						num25 = flag10;
						object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r14_v30 (System.Object)+10]");
						Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj21);
						object obj22 = Time.deltaTime;
						vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
						current = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-61]");
						_ = 0;
						goto IL_080e;
					}
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
				if ((nint)0 != 0)
				{
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r14_v29 (System.Object)+10]");
					bool flag11 = (nint)0 == 0;
					num25 = flag11;
					object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r14_v29 (System.Object)+10]");
					Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj24);
					object obj25 = Time.unscaledDeltaTime;
					vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
					current = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-61]");
					_ = 0;
					goto IL_080e;
				}
			}
			goto IL_059b;
			IL_080e:
			float num26 = default(float);
			float num27 = default(float);
			float deltaTime = default(float);
			Vector3 vector2 = Vector3.SmoothDamp(current, vector, ref *(Vector3*)(_003C_003E4__this + 168), num26, num27, deltaTime);
			num23 = vector2.z;
			num24 = vector2.x;
			goto IL_0788;
			IL_0788:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
			object obj26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
			bool flag12 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r14_v26 (System.Object)+10]");
			bool flag13 = (nint)0 == 0;
			object obj27 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r14_v26 (System.Object)+10]");
			Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj27);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B8]");
			object obj28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B8]");
			bool flag14 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1156 @ rcx_v60+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			float current2;
			float num28;
			if (!ignoreTimeScale)
			{
				ProCamera2D proCamera2D3 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D3 != null)
				{
					bool flag15 = !(proCamera2D3._003CDeltaTime_003Ek__BackingField > 0f);
					reference = ref *(float*)vector;
					if (flag15)
					{
						goto IL_0928;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E0]");
					current2 = 0f;
					num28 = smoothness;
					ProCamera2D proCamera2D4 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D4 != null)
					{
						float num13 = proCamera2D4._003CDeltaTime_003Ek__BackingField;
						goto IL_0957;
					}
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E0]");
				current2 = 0f;
				num28 = smoothness;
				ProCamera2D proCamera2D5 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D5 != null)
				{
					if (proCamera2D5.UpdateType == UpdateType.LateUpdate)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45B10");
					}
					else
					{
						float fixedUnscaledDeltaTime = Time.fixedUnscaledDeltaTime;
					}
					goto IL_0957;
				}
			}
			goto IL_059b;
			IL_059b:
			throw new NullReferenceException();
			IL_0957:
			reference = ref *(float*)(_003C_003E4__this + 228);
			float num29 = Mathf.SmoothDamp(current2, 1f, ref reference, num28, num26, num27);
			num16 = num28;
			goto IL_0928;
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

	private sealed class _003CStopConstantShakeRoutine_003Ed__45(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DShake _003C_003E4__this;

		public float duration;

		private Vector3 _003Cvelocity_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_007d: Expected I4, but got I8
			//IL_0272: Expected I, but got O
			//IL_02aa: Invalid comparison between F4 and I4
			//IL_0029: Expected O, but got I
			//IL_02f5: Expected O, but got F4
			//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Expected Ref, but got Unknown
			//IL_031d: Expected O, but got Ref
			//IL_031d: Expected O, but got Ref
			//IL_0331: Expected O, but got I
			//IL_00de: Expected O, but got I
			//IL_0137: Expected O, but got I
			//IL_017d: Expected O, but got I
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Expected O, but got Unknown
			//IL_011c: Expected O, but got Ref
			//IL_0121->IL02c4: Incompatible stack heights: 0 vs 1
			//IL_022a->IL02e7: Incompatible stack heights: 1 vs 0
			BasePC2D basePC2D = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				nint num = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v35 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				_003Cvelocity_003E5__2 = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v24 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v25+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_022a;
				}
				_003C_003E1__state = -1;
			}
			if (!(duration < 0f))
			{
				ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
				float num3 = duration - proCamera2D._003CDeltaTime_003Ek__BackingField;
				duration = num3;
				object obj2 = Time.deltaTime;
				object obj3 = default(object);
				object obj4 = default(object);
				float smoothTime = default(float);
				float maxSpeed = default(float);
				float deltaTime = default(float);
				Vector3 vector = Vector3.SmoothDamp((Vector3)(&obj3), (Vector3)(&obj4), ref *(Vector3*)(this + 44), smoothTime, maxSpeed, deltaTime);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E8]");
				List<Vector3> list = (List<Vector3>)0;
				_ = vector.x;
				_ = vector.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r8_v5+18]");
				if (num4 >= 0)
				{
					list.AddWithResize((Vector3)(&obj3));
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					object obj6 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r8_v5+18]");
					bool flag = num5 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					object obj7 = (nint)0 * (nint)2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					object obj8 = 0 + obj7;
					_ = vector.x;
					_ = vector.z;
				}
				ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
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
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_022a;
			IL_022a:
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

	public static string ExtensionName = "Shake";

	private static ProCamera2DShake _instance;

	public Action OnShakeCompleted;

	public List<ShakePreset> ShakePresets;

	public List<ConstantShakePreset> ConstantShakePresets;

	public ConstantShakePreset StartConstantShakePreset;

	public ConstantShakePreset CurrentConstantShakePreset;

	private Transform _shakeParent;

	private List<Coroutine> _applyInfluencesCoroutines;

	private List<Coroutine> _shakeTimedCoroutines;

	private Coroutine _shakeCoroutine;

	private Vector3 _shakeVelocity;

	private List<Vector3> _shakePositions;

	private Quaternion _rotationTarget;

	private Quaternion _originalRotation;

	private float _rotationTime;

	private float _rotationVelocity;

	private List<Vector3> _influences;

	private Vector3 _influencesSum;

	private Vector3[] _constantShakePositions;

	private Vector3 _constantShakePosition;

	private bool _isConstantShaking;

	public static ProCamera2DShake Instance
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
				nint num = (nint)typeof(ProCamera2DShake);
				bool flag = (object)obj3 == null;
				instance = null;
				if (!flag)
				{
					nint num2 = (nint)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v5 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ProCamera2DShake>)+130]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ r8_v10 (Il2CppClass<UnityEngine.Object>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v5 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ProCamera2DShake>)+130]");
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
			_instance = (ProCamera2DShake)instance;
			if ((object)_instance != null)
			{
				goto IL_01af;
			}
			UnityException ex = new UnityException("ProCamera2D does not have a Shake extension.");
			throw ex;
			IL_01af:
			return _instance;
		}
	}

	public static bool Exists
	{
		get
		{
			ProCamera2DShake instance = _instance;
			if ((object)_instance != null)
			{
				bool flag = ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	protected override void Awake()
	{
		//IL_01d9->IL0298: Incompatible stack heights: 4 vs 0
		base.Awake();
		_instance = this;
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null)
		{
			Transform transform = proCamera2D.transform;
			if ((object)transform != null)
			{
				Transform parent = transform.parent;
				if ((object)parent != null && ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0)
				{
					GameObject gameObject = new GameObject();
					GameObject.Internal_CreateGameObject(gameObject, "ProCamera2DShakeContainer");
					if ((object)gameObject != null)
					{
						Transform shakeParent = gameObject.transform;
						_shakeParent = shakeParent;
						ProCamera2D proCamera2D2 = base.ProCamera2D;
						if ((object)proCamera2D2 != null)
						{
							Transform transform2 = proCamera2D2.transform;
							if ((object)transform2 != null)
							{
								Transform parent2 = transform2.parent;
								if ((object)_shakeParent != null)
								{
									_shakeParent.SetParent(parent2, worldPositionStays: true);
									object shakeParent2 = _shakeParent;
									bool flag = (object)_shakeParent == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rdi_v15 (System.Object)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rdi_v15 (System.Object)+10]");
									Vector3 value = default(Vector3);
									Transform.set_localPosition_Injected((IntPtr)0, ref value);
									ProCamera2D proCamera2D3 = base.ProCamera2D;
									bool flag3 = (object)proCamera2D3 == null;
									Transform transform3 = proCamera2D3.transform;
									bool flag4 = (object)transform3 == null;
									transform3.SetParent(_shakeParent, worldPositionStays: true);
									goto IL_0298;
								}
							}
						}
					}
				}
				else
				{
					GameObject gameObject2 = new GameObject();
					GameObject.Internal_CreateGameObject(gameObject2, "ProCamera2DShakeContainer");
					if ((object)gameObject2 != null)
					{
						Transform transform4 = gameObject2.transform;
						ProCamera2D proCamera2D4 = base.ProCamera2D;
						if ((object)proCamera2D4 != null)
						{
							Transform transform5 = proCamera2D4.transform;
							if ((object)transform5 != null)
							{
								transform5.SetParent(transform4, worldPositionStays: true);
								_shakeParent = transform4;
								goto IL_0298;
							}
						}
					}
				}
			}
		}
		goto IL_02cb;
		IL_0298:
		object obj = _transform;
		if ((object)_transform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdi_v9 (System.Object)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdi_v9 (System.Object)+10]");
			Transform.get_localRotation_Injected((IntPtr)0, out Quaternion ret);
			_originalRotation = ret;
			return;
		}
		goto IL_02cb;
		IL_02cb:
		throw new NullReferenceException();
	}

	private void Start()
	{
		ConstantShakePreset startConstantShakePreset = StartConstantShakePreset;
		if ((object)StartConstantShakePreset != null && ((UnityEngine.Object)startConstantShakePreset).m_CachedPtr != (IntPtr)0)
		{
			ConstantShake(StartConstantShakePreset);
		}
	}

	private void Update()
	{
		//IL_00dd: Expected I, but got O
		//IL_0049: Expected O, but got F4
		//IL_00cf->IL0099: Incompatible stack heights: 1 vs 0
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_influencesSum = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		IList<Vector3> influences = _influences;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v5 (System.Collections.Generic.IList`1<UnityEngine.Vector3>)+18]");
		if ((nint)0 > (nint)0)
		{
			Vector3 vectorsSum = Utils.GetVectorsSum(influences);
			_influencesSum = (Vector3)vectorsSum.x;
			_ = vectorsSum.z;
			List<Vector3> influences2 = _influences;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Transform shakeParent = _shakeParent;
			bool flag = ((UnityEngine.Object)shakeParent).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)shakeParent).m_CachedPtr, ref value);
		}
	}

	public unsafe void Shake(float duration, Vector2 strength, int vibrato = 10, float randomness = 0.1f, float initialAngle = -1f, Vector3 rotation = default(Vector3), float smoothness = 0.1f, bool ignoreTimeScale = false)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0523: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		//IL_0556: Expected F4, but got I4
		//IL_055f: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00f2: Expected O, but got I4
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0164: Expected F4, but got I
		//IL_018e: Invalid comparison between I and F4
		//IL_05da: Expected I, but got O
		//IL_01b5: Expected O, but got I
		//IL_01d7: Expected O, but got Ref
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_05c7: Expected F4, but got I4
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		//IL_021a: Expected O, but got I8
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_029c: Expected O, but got I
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fd: Expected O, but got Unknown
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_030c: Expected F4, but got I4
		//IL_0315: Expected O, but got I4
		//IL_064b: Expected I4, but got I8
		//IL_0662: Expected I, but got O
		//IL_0335: Expected I4, but got I8
		//IL_07dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e2: Expected O, but got Unknown
		//IL_07f9: Expected F4, but got O
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_082a: Expected O, but got Unknown
		//IL_0841: Expected O, but got Ref
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Expected O, but got Unknown
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0891: Expected O, but got Unknown
		//IL_089a: Unknown result type (might be due to invalid IL or missing references)
		//IL_089f: Expected O, but got Unknown
		//IL_08b4: Expected F4, but got O
		//IL_0795: Unknown result type (might be due to invalid IL or missing references)
		//IL_079a: Expected O, but got Unknown
		//IL_0853: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Expected O, but got Unknown
		//IL_086d: Expected F4, but got O
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Expected O, but got Unknown
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected O, but got Unknown
		//IL_049a: Expected O, but got I
		//IL_04c1: Expected F4, but got I4
		//IL_021f->IL05b4: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = obj2 - 200;
		_ = 0;
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj3 = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj3 == null)
		{
			return;
		}
		int num = default(int);
		object obj4 = num + 1;
		object obj5;
		object obj6;
		if ((nint)obj4 < 2)
		{
			obj5 = 2;
			obj6 = 2;
		}
		else
		{
			obj5 = obj4;
			obj6 = obj4;
		}
		float[] array = new float[obj5];
		float num2 = 0f;
		object obj7 = 0;
		bool flag2;
		do
		{
			object obj8 = obj7 + 1;
			object obj9 = obj8 / obj6;
			float num3 = (float)obj9 * duration;
			num2 += num3;
			object obj10 = obj7 + 1;
			array[obj7] = num3;
			flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
			obj7 = obj10;
		}
		while (flag2);
		float num4 = duration / num2;
		object obj11 = 0;
		float num5;
		object obj12;
		do
		{
			num5 = num4 * array[obj11];
			obj12 = obj11 + 1;
			array[obj11] = num5;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F8]");
		float num6 = 0f;
		float num7 = num5 / (float)obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851C5B68h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F8]");
		object obj15 = default(object);
		if (0f == -1f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag3 = (nint)0 != 0;
			object obj14 = (object)(&obj15);
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag4 = obj13 == null;
				obj14 = 6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1308 @ rax_v107 (should have been resolved before IL gen)");
			num6 = 0f;
		}
		Vector2[] shakes = new Vector2[obj6];
		nint num8 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v39 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num9 = 0;
		object obj16 = obj6 - 1;
		_ = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v22 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		Quaternion[] rotations = new Quaternion[obj6];
		object obj17 = obj6 - 1;
		object obj18 = obj17 + 2;
		object obj19 = obj18 + obj18;
		_ = _originalRotation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
		object obj20 = 0;
		Vector2 vector = default(Vector2);
		float num10 = (float)vector * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1431 @ rax_v49+8]");
		float num11 = 0f * ((float)Math.PI / 180f);
		_ = 0;
		object obj21 = obj - 96;
		Vector2 euler = default(Vector2);
		Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out *(Quaternion*)obj21);
		object obj22 = obj6 - 1;
		if ((nint)obj22 > 0)
		{
			object obj23 = obj6 - 1;
			object obj24 = obj15;
			object obj26 = default(object);
			object obj25 = obj26;
			float num12 = (float)Math.PI / 180f;
			float num13 = num5;
			float num14 = 0f;
			object obj27 = 0;
			Vector2 vector2 = strength;
			Quaternion b = default(Quaternion);
			object obj37 = default(object);
			object obj41 = default(object);
			while (true)
			{
				if ((nint)obj27 > 0)
				{
					int num15 = UnityEngine.Random.Range(-90, 90);
					float num16 = num6 - 180f;
					float num17 = num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
					num11 = num17 * 0f;
					num6 = num11 + num16;
				}
				int num18 = UnityEngine.Random.Range(-90, 90);
				nint num19 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1605 @ rcx_v54 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1608 @ rax_v62 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				_ = 0;
				_ = Vector3.upVector;
				object obj28 = obj - 112;
				Quaternion.AngleAxis_Injected((float)typeof(Vector3), ref *(Vector3*)obj28, out *(Quaternion*)(&euler));
				float num21 = num6 * num12;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Vector3 vector3 = (Vector3)(obj - 128);
				Vector3 vector4 = (Quaternion)(&b) * vector3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851DDAD0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851DDAD0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D4]");
				_ = 0;
				num13 -= num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D4]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851DDAD0");
				object obj29 = ~obj27;
				object obj30 = obj29 & 1;
				object obj31 = obj30 + obj30;
				if ((nint)obj31 == 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
					_ = 0;
					object obj32 = obj - 80;
					Quaternion.Lerp_Injected(ref *(Quaternion*)obj32, ref b, (float)vector3, out *(Quaternion*)(&euler));
					b = Quaternion.identityQuaternion;
					num = (int)(&euler);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
					_ = 0;
					_ = Quaternion.identityQuaternion;
					object obj33 = obj - 80;
					object obj34 = obj - 64;
					Quaternion.Lerp_Injected(ref *(Quaternion*)obj34, ref *(Quaternion*)obj33, (float)vector3, out b);
					_ = Quaternion.identityQuaternion;
					object obj35 = obj - 48;
					Quaternion.Inverse_Injected(ref *(Quaternion*)obj35, out *(Quaternion*)(&euler));
					num = (int)(&b);
				}
				object obj36 = (object)_originalRotation * obj37;
				object obj38 = vector * euler;
				object obj39 = obj38 + obj36;
				float num22 = (float)vector * vector4.z;
				object obj40 = (object)vector * obj41;
				object obj42 = obj39 + obj40;
				float num23 = (float)vector * vector4.z;
				float num24 = (float)obj42 - num23;
				num11 = (float)vector * (float)euler;
				object obj43 = (object)vector * obj37;
				float num25 = num22 + (float)obj43;
				object obj44 = (object)_originalRotation * obj41;
				float num26 = num25 + num11;
				num10 = num26 - (float)obj44;
				object obj45 = obj27 + 1;
				object obj46 = obj27 + 2;
				object obj47 = obj46 + obj46;
				bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj45) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj23);
				float z = vector4.z;
				if (flag5)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
				obj24 = 0;
				z = vector4.z;
				obj25 = obj41;
				num12 = (float)Math.PI / 180f;
				num14 = 0f;
				obj27 = obj45;
				vector2 = vector;
			}
		}
		float smoothness2 = default(float);
		bool ignoreTimeScale2 = default(bool);
		Coroutine coroutine = ApplyShakesTimed(shakes, rotations, array, smoothness2, ignoreTimeScale2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7730");
	}

	public void Shake(int presetIndex)
	{
		//IL_0018: Expected O, but got I4
		//IL_02db: Expected I4, but got F4
		List<ShakePreset> shakePresets = ShakePresets;
		object obj = shakePresets._size - 1;
		if (presetIndex > (nint)obj)
		{
			int num = default(int);
			string text = num.ToString();
			string message = "Could not find a shake preset with the index: " + text;
			Debug.LogWarning(message);
			return;
		}
		List<ShakePreset> shakePresets2 = ShakePresets;
		if (presetIndex < shakePresets2._size)
		{
			ShakePreset[] items = shakePresets2._items;
			ShakePreset shakePreset = items[presetIndex];
			if (presetIndex < shakePresets2._size)
			{
				List<ShakePreset> shakePresets3 = ShakePresets;
				if (presetIndex < shakePresets3._size)
				{
					ShakePreset[] items2 = shakePresets3._items;
					ShakePreset shakePreset2 = items2[presetIndex];
					List<ShakePreset> shakePresets4 = ShakePresets;
					if (presetIndex < shakePresets4._size)
					{
						ShakePreset[] items3 = shakePresets4._items;
						ShakePreset shakePreset3 = items3[presetIndex];
						if (presetIndex < shakePresets4._size)
						{
							ShakePreset[] items4 = shakePresets4._items;
							ShakePreset shakePreset4 = items4[presetIndex];
							if (shakePreset4.UseRandomInitialAngle || presetIndex < shakePresets4._size)
							{
								List<ShakePreset> shakePresets5 = ShakePresets;
								if (presetIndex < shakePresets5._size && presetIndex < shakePresets5._size && presetIndex < shakePresets5._size)
								{
									Vector2 strength = default(Vector2);
									float randomness = default(float);
									float initialAngle = default(float);
									Vector3 rotation = default(Vector3);
									float smoothness = default(float);
									Shake(shakePreset.Duration, strength, shakePreset2.Vibrato, randomness, initialAngle, rotation, smoothness, (byte)(int)shakePreset3.Randomness != 0);
									return;
								}
							}
						}
					}
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe void Shake(string presetName)
	{
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected Ref, but got Unknown
		//IL_0104: Expected I8, but got I4
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected Ref, but got Unknown
		List<ShakePreset> shakePresets = ShakePresets;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < shakePresets._size)
			{
				List<ShakePreset> shakePresets2 = ShakePresets;
				if (num >= shakePresets2._size)
				{
					break;
				}
				ShakePreset[] items = shakePresets2._items;
				string text = ((UnityEngine.Object)items[num]).GetName();
				if ((object)text != presetName)
				{
					if (text == null || presetName == null || text._stringLength != presetName._stringLength)
					{
						goto IL_0136;
					}
					ref byte second = ref *(byte*)(presetName + 20);
					ulong length = (ulong)(text._stringLength + text._stringLength);
					if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(text + 20), ref second, length))
					{
						goto IL_0136;
					}
				}
				Shake(num);
			}
			else
			{
				string message = "Could not find a shake preset with the name: " + presetName;
				Debug.LogWarning(message);
			}
			return;
			IL_0136:
			shakePresets = ShakePresets;
			num++;
			num2 = num;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void Shake(ShakePreset preset)
	{
		//IL_0063: Expected I4, but got F4
		if (preset.UseRandomInitialAngle)
		{
		}
		Vector2 strength = default(Vector2);
		float randomness = default(float);
		float initialAngle = default(float);
		Vector3 rotation = default(Vector3);
		float smoothness = default(float);
		Shake(preset.Duration, strength, preset.Vibrato, randomness, initialAngle, rotation, smoothness, (byte)(int)preset.Randomness != 0);
	}

	public void StopShaking()
	{
		//IL_0212: Expected O, but got I4
		//IL_021b: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_00c7: Expected O, but got I4
		//IL_0240: Expected I, but got O
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		List<Coroutine> applyInfluencesCoroutines = _applyInfluencesCoroutines;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < applyInfluencesCoroutines._size)
			{
				List<Coroutine> applyInfluencesCoroutines2 = _applyInfluencesCoroutines;
				if ((nint)obj >= applyInfluencesCoroutines2._size)
				{
					break;
				}
				Coroutine[] items = applyInfluencesCoroutines2._items;
				StopCoroutine(items[obj]);
				applyInfluencesCoroutines = _applyInfluencesCoroutines;
				obj++;
				obj2 = obj;
				continue;
			}
			List<Coroutine> shakeTimedCoroutines = _shakeTimedCoroutines;
			object obj3 = 0;
			object obj4 = 0;
			while (true)
			{
				if ((nint)obj4 < shakeTimedCoroutines._size)
				{
					List<Coroutine> shakeTimedCoroutines2 = _shakeTimedCoroutines;
					if ((nint)obj3 >= shakeTimedCoroutines2._size)
					{
						break;
					}
					Coroutine[] items2 = shakeTimedCoroutines2._items;
					StopCoroutine(items2[obj3]);
					shakeTimedCoroutines = _shakeTimedCoroutines;
					obj3++;
					bool flag = _shakeTimedCoroutines != null;
					obj4 = obj3;
					if (!flag)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				if (_shakeCoroutine != null)
				{
					StopCoroutine(_shakeCoroutine);
					_shakeCoroutine = null;
				}
				List<Vector3> shakePositions = _shakePositions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v11 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				nint num = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rax_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				_shakeVelocity = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				ShakeCompleted();
				return;
			}
			break;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void ConstantShake(ConstantShakePreset preset)
	{
		//IL_0110: Expected O, but got I
		//IL_0123: Expected O, but got I4
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0224: Expected O, but got I
		//IL_0237: Expected O, but got I4
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0285: Expected F4, but got I
		//IL_02a7: Expected F4, but got I
		ConstantShakePreset currentConstantShakePreset = CurrentConstantShakePreset;
		if ((object)CurrentConstantShakePreset != null && ((UnityEngine.Object)currentConstantShakePreset).m_CachedPtr != (IntPtr)0)
		{
			StopConstantShaking(0f);
		}
		CurrentConstantShakePreset = preset;
		_isConstantShaking = true;
		List<ConstantShakeLayer> layers = preset.Layers;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v14 (System.Collections.Generic.List`1<Com.LuisPedroFonseca.ProCamera2D.ConstantShakeLayer>)+18]");
		Vector3[] constantShakePositions = new Vector3[0];
		_constantShakePositions = constantShakePositions;
		int num = 0;
		int num2 = 0;
		float num9 = default(float);
		while (true)
		{
			List<ConstantShakeLayer> layers2 = preset.Layers;
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v18 (System.Collections.Generic.List`1<Com.LuisPedroFonseca.ProCamera2D.ConstantShakeLayer>)+18]");
			if ((nint)num3 >= (nint)0)
			{
				break;
			}
			int num4 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v18 (System.Collections.Generic.List`1<Com.LuisPedroFonseca.ProCamera2D.ConstantShakeLayer>)+18]");
			if ((nint)num4 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v18 (System.Collections.Generic.List`1<Com.LuisPedroFonseca.ProCamera2D.ConstantShakeLayer>)+10]");
				object obj = 0;
				object obj2 = num * 4;
				object obj3 = num + obj2;
				List<ConstantShakeLayer> layers3 = preset.Layers;
				int num5 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rcx_v25 (System.Collections.Generic.List`1<Com.LuisPedroFonseca.ProCamera2D.ConstantShakeLayer>)+18]");
				if ((nint)num5 < (nint)0)
				{
					List<ConstantShakeLayer> layers4 = preset.Layers;
					int num6 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rcx_v27 (System.Collections.Generic.List`1<Com.LuisPedroFonseca.ProCamera2D.ConstantShakeLayer>)+18]");
					if ((nint)num6 < (nint)0)
					{
						List<ConstantShakeLayer> layers5 = preset.Layers;
						int num7 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rcx_v29 (System.Collections.Generic.List`1<Com.LuisPedroFonseca.ProCamera2D.ConstantShakeLayer>)+18]");
						if ((nint)num7 < (nint)0)
						{
							List<ConstantShakeLayer> layers6 = preset.Layers;
							int num8 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rdx_v12 (System.Collections.Generic.List`1<Com.LuisPedroFonseca.ProCamera2D.ConstantShakeLayer>)+18]");
							if ((nint)num8 < (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rdx_v12 (System.Collections.Generic.List`1<Com.LuisPedroFonseca.ProCamera2D.ConstantShakeLayer>)+10]");
								object obj4 = 0;
								object obj5 = num * 4;
								object obj6 = num + obj5;
								_003CCalculateConstantShakePosition_003Ed__46 obj7 = null;
								obj7._003C_003E1__state = 0;
								obj7._003C_003E4__this = this;
								obj7.frequencyMax = num9;
								obj7.amplitudeX = num9;
								obj7.amplitudeY = num9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rcx_v24+20+v301 @ rax_v29*4]");
								obj7.frequencyMin = 0f;
								obj7.index = num;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdx_v13+30+v874 @ rcx_v31*4]");
								obj7.amplitudeZ = 0f;
								Coroutine coroutine = StartCoroutine(obj7);
								num++;
								num2 = num;
								continue;
							}
						}
					}
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
		}
		_003CConstantShakeRoutine_003Ed__47 obj8 = null;
		obj8._003C_003E1__state = 0;
		obj8._003C_003E4__this = this;
		obj8.intensity = preset.Intensity;
		Coroutine coroutine2 = StartCoroutine(obj8);
	}

	public unsafe void ConstantShake(string presetName)
	{
		//IL_0214: Expected O, but got I4
		//IL_021d: Expected O, but got I4
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected Ref, but got Unknown
		//IL_0134: Expected I8, but got I4
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected Ref, but got Unknown
		//IL_0160: Expected O, but got I4
		//IL_0168: Expected I, but got I8
		//IL_0171: Expected O, but got I4
		//IL_0179: Expected I, but got I8
		List<ConstantShakePreset> constantShakePresets = ConstantShakePresets;
		object obj = 0;
		object obj2 = 0;
		object obj4 = default(object);
		nint num2 = default(nint);
		ConstantShakePreset preset = default(ConstantShakePreset);
		while (true)
		{
			object obj3;
			nint num;
			if ((nint)obj2 < constantShakePresets._size)
			{
				List<ConstantShakePreset> constantShakePresets2 = ConstantShakePresets;
				if ((nint)obj >= constantShakePresets2._size)
				{
					break;
				}
				ConstantShakePreset[] items = constantShakePresets2._items;
				string text = ((UnityEngine.Object)items[obj]).GetName();
				if ((object)text != presetName)
				{
					bool flag = text == null;
					obj3 = obj4;
					num = num2;
					if (flag)
					{
						goto IL_0187;
					}
					bool flag2 = presetName == null;
					obj3 = obj4;
					num = num2;
					if (flag2)
					{
						goto IL_0187;
					}
					bool flag3 = text._stringLength != presetName._stringLength;
					obj3 = obj4;
					num = num2;
					if (flag3)
					{
						goto IL_0187;
					}
					ref byte second = ref *(byte*)(presetName + 20);
					ulong num3 = (ulong)(text._stringLength + text._stringLength);
					bool flag4 = System.SpanHelpers.SequenceEqual(ref *(byte*)(text + 20), ref second, num3);
					obj3 = 0;
					num = (nint)num3;
					obj4 = 0;
					num2 = (nint)num3;
					if (!flag4)
					{
						goto IL_0187;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				ConstantShake(preset);
			}
			else
			{
				string message = "Could not find a ConstantShakePreset with the name: " + presetName + ". Remember you need to add it to the ConstantShakePresets list first.";
				Debug.LogWarning(message);
			}
			return;
			IL_0187:
			constantShakePresets = ConstantShakePresets;
			obj++;
			obj4 = obj3;
			num2 = num;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void ConstantShake(int presetIndex)
	{
		//IL_0018: Expected O, but got I4
		List<ConstantShakePreset> constantShakePresets = ConstantShakePresets;
		object obj = constantShakePresets._size - 1;
		if (presetIndex > (nint)obj)
		{
			int num = default(int);
			string text = num.ToString();
			string message = "Could not find a ConstantShakePreset with the index: " + text + ". Remember you need to add it to the ConstantShakePresets list first.";
			Debug.LogWarning(message);
			return;
		}
		List<ConstantShakePreset> constantShakePresets2 = ConstantShakePresets;
		if (presetIndex < constantShakePresets2._size)
		{
			ConstantShakePreset[] items = constantShakePresets2._items;
			ConstantShake(items[presetIndex]);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe void StopConstantShaking(float duration = 0.3f)
	{
		//IL_0019: Invalid comparison between F4 and I4
		//IL_015d: Expected I, but got O
		//IL_0083: Expected O, but got I
		//IL_00d8: Expected O, but got I
		//IL_00f8: Expected O, but got I
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_00c1: Expected O, but got Ref
		CurrentConstantShakePreset = null;
		_isConstantShaking = false;
		if (!(duration > 0f))
		{
			StopAllCoroutines();
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			List<Vector3> influences = _influences;
			_constantShakePosition = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v14 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			List<Vector3> influences2 = _influences;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v8+18]");
			if (num3 >= 0)
			{
				object obj2 = default(object);
				influences2.AddWithResize((Vector3)(&obj2));
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj3 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj4 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj5 = 0 + obj4;
			_ = _constantShakePosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DShake)+110]");
			_ = 0;
		}
		else
		{
			_003CStopConstantShakeRoutine_003Ed__45 obj6 = null;
			obj6._003C_003E1__state = 0;
			obj6._003C_003E4__this = this;
			obj6.duration = duration;
			Coroutine coroutine = StartCoroutine(obj6);
		}
	}

	public Coroutine ApplyShakesTimed(Vector2[] shakes, Vector3[] rotations, float[] durations, float smoothness = 0.1f, bool ignoreTimeScale = false)
	{
		//IL_00d5: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null)
		{
			Quaternion[] rotations2 = new Quaternion[rotations.Length];
			object obj2 = 0;
			object obj3 = 0;
			Vector3 euler = default(Vector3);
			object obj5 = default(object);
			object obj7 = default(object);
			object obj8 = default(object);
			object obj12 = default(object);
			while ((nint)obj3 < rotations.Length)
			{
				Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion ret);
				object obj4 = obj5 * (object)_originalRotation;
				object obj6 = obj7 * obj8;
				object obj9 = (object)ret * obj8;
				object obj10 = obj9 + obj4;
				object obj11 = obj12 * obj8;
				object obj13 = obj10 + obj6;
				object obj14 = obj13 - obj11;
				object obj15 = obj2 + 2;
				object obj16 = obj15 + obj15;
				obj2++;
				obj3 = obj2;
			}
			float smoothness2 = default(float);
			bool ignoreTimeScale2 = default(bool);
			return ApplyShakesTimed(shakes, rotations2, durations, smoothness2, ignoreTimeScale2);
		}
		return null;
	}

	public unsafe void ApplyInfluenceIgnoringBoundaries(Vector2 influence)
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

	private Coroutine ApplyShakesTimed(Vector2[] shakes, Quaternion[] rotations, float[] durations, float smoothness = 0.1f, bool ignoreTimeScale = false)
	{
		bool ignoreTimeScale2 = default(bool);
		IEnumerator routine = ApplyShakesTimedRoutine(shakes, rotations, durations, ignoreTimeScale2);
		Coroutine result = StartCoroutine(routine);
		if (_shakeCoroutine == null)
		{
			_003CShakeRoutine_003Ed__41 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			float smoothness2 = default(float);
			obj.smoothness = smoothness2;
			bool ignoreTimeScale3 = default(bool);
			obj.ignoreTimeScale = ignoreTimeScale3;
			Coroutine shakeCoroutine = StartCoroutine(obj);
			_shakeCoroutine = shakeCoroutine;
		}
		return result;
	}

	private IEnumerator ShakeRoutine(float smoothness, bool ignoreTimeScale = false)
	{
		_003CShakeRoutine_003Ed__41 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.smoothness = smoothness;
		obj.ignoreTimeScale = ignoreTimeScale;
		return obj;
	}

	private void ShakeCompleted()
	{
		//IL_00d0->IL0075: Incompatible stack heights: 1 vs 0
		Transform shakeParent = _shakeParent;
		if ((object)_shakeParent != null)
		{
			bool flag = ((UnityEngine.Object)shakeParent).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)shakeParent).m_CachedPtr, ref value);
			Transform transform = _transform;
			if ((object)_transform != null)
			{
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Quaternion value2 = default(Quaternion);
				Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
				_shakeCoroutine = null;
				if (OnShakeCompleted != null)
				{
					Action onShakeCompleted = OnShakeCompleted;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v408.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator ApplyShakesTimedRoutine(IList<Vector2> shakes, IList<Quaternion> rotations, float[] durations, bool ignoreTimeScale = false)
	{
		_003CApplyShakesTimedRoutine_003Ed__43 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.shakes = shakes;
		obj.rotations = rotations;
		obj.durations = durations;
		bool ignoreTimeScale2 = default(bool);
		obj.ignoreTimeScale = ignoreTimeScale2;
		return obj;
	}

	private IEnumerator ApplyShakeTimedRoutine(Vector2 shake, Quaternion rotation, float duration, bool ignoreTimeScale = false)
	{
		//IL_003e: Expected O, but got F4
		_003CApplyShakeTimedRoutine_003Ed__44 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.shake = shake;
		bool ignoreTimeScale2 = default(bool);
		obj.ignoreTimeScale = ignoreTimeScale2;
		obj.duration = duration;
		obj.rotation = (Quaternion)rotation.x;
		return obj;
	}

	private IEnumerator StopConstantShakeRoutine(float duration)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002e: Expected O, but got I8
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_010a: Expected O, but got I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		_003CStopConstantShakeRoutine_003Ed__45 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = 6603864928L;
			object obj5 = obj3 & 0x1FFFFF;
			object obj6 = obj5 >> 6;
			object obj7 = obj5 & 0x3F;
			nint num2;
			do
			{
				object obj8 = 1 << (int)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				object obj9 = 0 | obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				if (num == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
			}
			while (num2 != 0);
			obj.duration = duration;
			return obj;
		}
		obj.duration = duration;
		return obj;
	}

	private IEnumerator CalculateConstantShakePosition(int index, float frequencyMin, float frequencyMax, float amplitudeX, float amplitudeY, float amplitudeZ)
	{
		_003CCalculateConstantShakePosition_003Ed__46 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		float amplitudeX2 = default(float);
		obj.amplitudeX = amplitudeX2;
		obj.frequencyMin = frequencyMin;
		obj.frequencyMax = frequencyMax;
		float amplitudeZ2 = default(float);
		obj.amplitudeZ = amplitudeZ2;
		float amplitudeY2 = default(float);
		obj.amplitudeY = amplitudeY2;
		obj.index = index;
		return obj;
	}

	private IEnumerator ConstantShakeRoutine(float intensity)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002e: Expected O, but got I8
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_010a: Expected O, but got I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		_003CConstantShakeRoutine_003Ed__47 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = 6603864928L;
			object obj5 = obj3 & 0x1FFFFF;
			object obj6 = obj5 >> 6;
			object obj7 = obj5 & 0x3F;
			nint num2;
			do
			{
				object obj8 = 1 << (int)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				object obj9 = 0 | obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				if (num == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
			}
			while (num2 != 0);
			obj.intensity = intensity;
			return obj;
		}
		obj.intensity = intensity;
		return obj;
	}

	public ProCamera2DShake()
	{
		//IL_00c8: Expected I, but got O
		List<ShakePreset> shakePresets = new List<ShakePreset>();
		ShakePresets = shakePresets;
		List<ConstantShakePreset> constantShakePresets = new List<ConstantShakePreset>();
		ConstantShakePresets = constantShakePresets;
		List<Coroutine> applyInfluencesCoroutines = new List<Coroutine>();
		_applyInfluencesCoroutines = applyInfluencesCoroutines;
		List<Coroutine> shakeTimedCoroutines = new List<Coroutine>();
		_shakeTimedCoroutines = shakeTimedCoroutines;
		List<Vector3> shakePositions = new List<Vector3>();
		_shakePositions = shakePositions;
		List<Vector3> influences = new List<Vector3>();
		_influences = influences;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rax_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_influencesSum = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ rcx_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
	}
}
