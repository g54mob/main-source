using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DCinematics : BasePC2D, IPositionOverrider, ISizeOverrider
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Camera, float> _003C_003E9__51_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003CSetupLetterbox_003Eb__51_0(Camera c)
		{
			bool flag = ((UnityEngine.Object)c).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
	}

	private sealed class _003CEndCinematicRoutine_003Ed__50(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DCinematics _003C_003E4__this;

		private float _003CinitialPosH_003E5__2;

		private float _003CinitialPosV_003E5__3;

		private float _003CcurrentCameraSize_003E5__4;

		private float _003Ct_003E5__5;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_026f: Expected I4, but got I8
			//IL_091b: Expected I4, but got O
			//IL_0043: Expected O, but got I
			//IL_072f: Expected O, but got I
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Expected O, but got Unknown
			//IL_0163: Expected F4, but got I
			//IL_07eb: Expected O, but got I
			//IL_0378: Unknown result type (might be due to invalid IL or missing references)
			//IL_037d: Expected O, but got Unknown
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Expected O, but got Unknown
			//IL_01d6: Expected F4, but got I
			//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03de: Expected O, but got Unknown
			//IL_07b0: Expected O, but got I
			//IL_00eb: Expected F4, but got I
			//IL_00eb: Expected O, but got I
			//IL_05bb: Expected F4, but got I
			//IL_05e6: Expected F4, but got I
			//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f9: Expected O, but got Unknown
			//IL_0602: Unknown result type (might be due to invalid IL or missing references)
			//IL_0607: Expected O, but got Unknown
			//IL_0621: Expected F4, but got I
			//IL_0631: Expected F4, but got I
			//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bc: Expected O, but got Unknown
			//IL_0509: Expected F4, but got I
			//IL_0648: Unknown result type (might be due to invalid IL or missing references)
			//IL_064d: Expected O, but got Unknown
			//IL_0692: Expected F4, but got I
			//IL_054a: Unknown result type (might be due to invalid IL or missing references)
			//IL_054f: Expected O, but got Unknown
			BasePC2D basePC2D = _003C_003E4__this;
			object obj3 = default(object);
			float num3;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r14_v6+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+94]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
								if ((nint)0 == 0)
								{
									goto IL_090d;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+98]");
								((ProCamera2DLetterbox)num).TweenTo(0f, 0f);
							}
						}
					}
					Func<Vector3, float> vector3H = basePC2D.Vector3H;
					if (basePC2D.Vector3H != null)
					{
						object obj2 = obj3 - 64;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E4]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+EC]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v204 @ rcx_v47 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E4]");
						_003CinitialPosH_003E5__2 = 0f;
						Func<Vector3, float> vector3V = basePC2D.Vector3V;
						if (basePC2D.Vector3V != null)
						{
							object obj4 = obj3 - 64;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E4]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+EC]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v205 @ rcx_v49 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E4]");
							_003CinitialPosV_003E5__3 = 0f;
							ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v63 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
								float num2 = 0f * 0.5f;
								_003Ct_003E5__5 = 0f;
								num3 = _003Ct_003E5__5;
								_003CcurrentCameraSize_003E5__4 = num2;
								goto IL_0298;
							}
						}
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0971;
				}
				_003C_003E1__state = -1;
				num3 = _003Ct_003E5__5;
				if ((object)_003C_003E4__this != null)
				{
					goto IL_0298;
				}
			}
			goto IL_090d;
			IL_0971:
			return false;
			IL_090d:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_09ab:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+8C]");
			EaseType easeType = EaseType.EaseInOut;
			float num4;
			float start = num4;
			float num5;
			float end = num5;
			float value = _003Ct_003E5__5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+8C]");
			float num6 = Utils.EaseFromTo(start, end, value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B8]");
			if ((nint)0 != 0)
			{
				object obj5 = obj3 + 48;
				object obj6 = obj3 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851AF0F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
				num6 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+20]");
				float num7 = 0f;
				easeType = EaseType.EaseInOut;
			}
			Func<float, float, float, Vector3> vectorHVD = basePC2D.VectorHVD;
			if (basePC2D.VectorHVD == null)
			{
				goto IL_090d;
			}
			object obj7 = obj3 - 64;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v144 @ rdx_v24 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v662 @ rax_v48+8]");
			_ = 0;
			float start2 = _003CcurrentCameraSize_003E5__4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+AC]");
			nint num8 = 0;
			float value2 = _003Ct_003E5__5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+8C]");
			float num9 = Utils.EaseFromTo(start2, num8, value2);
			goto IL_097f;
			IL_0298:
			if (!(1f < num3))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+10C]");
				if ((nint)0 != 0)
				{
					goto IL_097f;
				}
				ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D2 != null)
				{
					float num10 = proCamera2D2._003CDeltaTime_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
					float num11 = num10 / 0f;
					float num12 = num11 + _003Ct_003E5__5;
					_003Ct_003E5__5 = num12;
					Func<Vector3, float> vector3H2 = basePC2D.Vector3H;
					if (basePC2D.Vector3H != null)
					{
						object obj8 = obj3 - 64;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+F0]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+F8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v208 @ rcx_v29 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						Func<Vector3, float> vector3V2 = basePC2D.Vector3V;
						if (basePC2D.Vector3V != null)
						{
							object obj9 = obj3 - 64;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+F0]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+F8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v209 @ rcx_v31 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							ProCamera2D proCamera2D3 = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D3 != null)
							{
								List<CameraTarget> cameraTargets = proCamera2D3.CameraTargets;
								if (proCamera2D3.CameraTargets != null)
								{
									if (cameraTargets._size > 0)
									{
										float start3 = _003CinitialPosH_003E5__2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+F0]");
										nint num13 = 0;
										float value3 = _003Ct_003E5__5;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+8C]");
										float num14 = Utils.EaseFromTo(start3, num13, value3);
										num4 = _003CinitialPosV_003E5__3;
										float num7 = num14;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+F0]");
										num5 = 0f;
										goto IL_09ab;
									}
									Func<Vector3, float> vector3H3 = basePC2D.Vector3H;
									if (basePC2D.Vector3H != null)
									{
										object obj10 = obj3 - 64;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+FC]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+104]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v211 @ rcx_v38 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
										float start4 = _003CinitialPosH_003E5__2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+F0]");
										nint num15 = 0;
										float value4 = _003Ct_003E5__5;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+8C]");
										float num16 = Utils.EaseFromTo(start4, num15, value4);
										Func<Vector3, float> vector3V3 = basePC2D.Vector3V;
										if (basePC2D.Vector3V != null)
										{
											object obj11 = obj3 - 64;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+FC]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+104]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ rcx_v40 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
											float num7 = num16;
											num5 = num16;
											num4 = _003CinitialPosV_003E5__3;
											goto IL_09ab;
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
				object obj12 = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdi_v6+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
						if ((nint)0 == 0)
						{
							goto IL_090d;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
						nint num17 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B8]");
						((Behaviour)num17).enabled = false;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+70]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+70]");
					((UnityEvent)0).Invoke();
				}
				ProCamera2D proCamera2D4 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D4 != null)
				{
					List<CameraTarget> cameraTargets2 = proCamera2D4.CameraTargets;
					if (proCamera2D4.CameraTargets != null)
					{
						if (cameraTargets2._size == 0)
						{
							ProCamera2D proCamera2D5 = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D5 == null)
							{
								goto IL_090d;
							}
							proCamera2D5.CenterOnTargets();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v17 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+5C]");
							float screenSize = 0f * 0.5f;
							proCamera2D5.SetScreenSize(screenSize);
							if (proCamera2D5.OnReset != null)
							{
								Action onReset = proCamera2D5.OnReset;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1035.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							}
						}
						goto IL_0971;
					}
				}
			}
			goto IL_090d;
			IL_097f:
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
			goto IL_090d;
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

	private sealed class _003CGoToCinematicTargetRoutine_003Ed__49(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public CinematicTarget cinematicTarget;

		public ProCamera2DCinematics _003C_003E4__this;

		public int targetIndex;

		private float _003CinitialPosH_003E5__2;

		private float _003CinitialPosV_003E5__3;

		private float _003CcurrentCameraSize_003E5__4;

		private float _003Ct_003E5__5;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0678: Expected I4, but got I8
			//IL_001d: Expected O, but got I4
			//IL_006e: Expected I4, but got I8
			//IL_0076: Expected I, but got O
			//IL_005a: Expected I4, but got I8
			//IL_0c54: Expected O, but got I
			//IL_0d64: Invalid comparison between I4 and F4
			//IL_0cb1: Expected O, but got I
			//IL_0cde: Expected O, but got I
			//IL_0772: Expected O, but got Ref
			//IL_01c5: Expected O, but got Ref
			//IL_0e81: Expected O, but got I
			//IL_0815: Expected O, but got Ref
			//IL_024c: Expected O, but got Ref
			//IL_13ae: Expected O, but got Ref
			//IL_0ebe: Expected O, but got Ref
			//IL_08e3: Invalid comparison between F4 and I4
			//IL_0f4b: Expected O, but got Ref
			//IL_0f8b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f90: Expected O, but got Unknown
			//IL_0370: Expected O, but got Ref
			//IL_0fd1: Expected O, but got I
			//IL_0968: Expected O, but got Ref
			//IL_03f7: Expected O, but got Ref
			//IL_09ef: Expected O, but got Ref
			//IL_1420: Expected O, but got Ref
			//IL_04c9: Expected O, but got Ref
			//IL_04d7: Expected O, but got Ref
			//IL_04f1: Expected F4, but got I
			//IL_0501: Expected F4, but got I
			//IL_100e: Expected O, but got Ref
			//IL_051d: Expected O, but got Ref
			//IL_0aaa: Expected O, but got Ref
			//IL_109b: Expected O, but got Ref
			//IL_10ab: Expected O, but got I
			//IL_10e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_10e6: Expected O, but got Unknown
			//IL_111e: Expected O, but got Ref
			//IL_112c: Expected O, but got Ref
			//IL_1146: Expected O, but got I
			//IL_1156: Expected O, but got I
			//IL_115f: Expected O, but got I4
			//IL_1172: Expected O, but got Ref
			//IL_0b31: Expected O, but got Ref
			//IL_0bd2: Expected O, but got Ref
			//IL_13e0->IL1266: Incompatible stack heights: 1 vs 0
			//IL_0f16->IL1266: Incompatible stack heights: 1 vs 0
			//IL_0f38->IL1266: Incompatible stack heights: 1 vs 0
			//IL_0fbc->IL1266: Incompatible stack heights: 1 vs 0
			//IL_0ff1->IL1266: Incompatible stack heights: 1 vs 0
			//IL_1452->IL1266: Incompatible stack heights: 2 vs 0
			//IL_1066->IL1266: Incompatible stack heights: 2 vs 0
			//IL_1088->IL1266: Incompatible stack heights: 2 vs 0
			//IL_1481->IL1266: Incompatible stack heights: 2 vs 0
			//IL_11b1->IL1258: Incompatible stack heights: 2 vs 0
			//IL_11b6->IL11b6: Incompatible stack heights: 2 vs 0
			object obj2 = default(object);
			object obj = (object)(&obj2);
			BasePC2D basePC2D = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			nint num;
			object obj4 = default(object);
			if (!flag)
			{
				object obj3 = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					num = (nint)obj4;
					goto IL_1354;
				}
				if ((nint)obj3 == 1)
				{
					_003C_003E1__state = -1;
					goto IL_1296;
				}
			}
			else
			{
				CinematicTarget cinematicTarget = this.cinematicTarget;
				_003C_003E1__state = -1;
				if (this.cinematicTarget == null)
				{
					goto IL_1266;
				}
				object targetTransform = cinematicTarget.TargetTransform;
				if ((object)cinematicTarget.TargetTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r14_v25 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						if ((object)_003C_003E4__this != null)
						{
							object vector3H = basePC2D.Vector3H;
							ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D != null)
							{
								Vector3 localPosition = proCamera2D.LocalPosition;
								if (basePC2D.Vector3H != null)
								{
									object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
									_ = localPosition.x;
									_ = localPosition.z;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v215 @ r14_v26 (System.Object)+18] (should have been resolved before IL gen)");
									_003CinitialPosH_003E5__2 = localPosition.x;
									object vector3V = basePC2D.Vector3V;
									ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
									if ((object)proCamera2D2 != null)
									{
										Vector3 localPosition2 = proCamera2D2.LocalPosition;
										if (basePC2D.Vector3V != null)
										{
											object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ r14_v27 (System.Object)+28]");
											num = 0;
											_ = localPosition2.x;
											_ = localPosition2.z;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v216 @ r14_v27 (System.Object)+18] (should have been resolved before IL gen)");
											_003CinitialPosV_003E5__3 = localPosition2.x;
											ProCamera2D proCamera2D3 = _003C_003E4__this.ProCamera2D;
											if ((object)proCamera2D3 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v99 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
												float num2 = 0f * 0.5f;
												CinematicTarget cinematicTarget2 = this.cinematicTarget;
												_003Ct_003E5__5 = 0f;
												_003CcurrentCameraSize_003E5__4 = num2;
												if (this.cinematicTarget != null)
												{
													if (cinematicTarget2.EaseInDuration > 0f)
													{
														goto IL_1354;
													}
													object vector3H2 = basePC2D.Vector3H;
													if ((object)cinematicTarget2.TargetTransform != null)
													{
														Vector3 position = cinematicTarget2.TargetTransform.position;
														if (basePC2D.Vector3H != null)
														{
															object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
															_ = position.x;
															_ = position.z;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v217 @ r14_v28 (System.Object)+18] (should have been resolved before IL gen)");
															object vector3H3 = basePC2D.Vector3H;
															ProCamera2D proCamera2D4 = _003C_003E4__this.ProCamera2D;
															if ((object)proCamera2D4 != null && basePC2D.Vector3H != null)
															{
																object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																_ = proCamera2D4._003CParentPosition_003Ek__BackingField;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v104 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v218 @ r14_v29 (System.Object)+18] (should have been resolved before IL gen)");
																CinematicTarget cinematicTarget3 = this.cinematicTarget;
																object vector3V2 = basePC2D.Vector3V;
																if (this.cinematicTarget != null && (object)cinematicTarget3.TargetTransform != null)
																{
																	Vector3 position2 = cinematicTarget3.TargetTransform.position;
																	if (basePC2D.Vector3V != null)
																	{
																		object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																		_ = position2.x;
																		_ = position2.z;
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v219 @ r14_v30 (System.Object)+18] (should have been resolved before IL gen)");
																		object vector3V3 = basePC2D.Vector3V;
																		ProCamera2D proCamera2D5 = _003C_003E4__this.ProCamera2D;
																		if ((object)proCamera2D5 != null && basePC2D.Vector3V != null)
																		{
																			object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																			_ = proCamera2D5._003CParentPosition_003Ek__BackingField;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rax_v110 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v220 @ r14_v31 (System.Object)+18] (should have been resolved before IL gen)");
																			Func<float, float, float, Vector3> vectorHVD = basePC2D.VectorHVD;
																			if (basePC2D.VectorHVD != null)
																			{
																				float num3 = position2.x - (float)proCamera2D5._003CParentPosition_003Ek__BackingField;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rdx_v70 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18]");
																				num = 0;
																				float num4 = position.x - (float)proCamera2D4._003CParentPosition_003Ek__BackingField;
																				object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
																				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v265 @ rdx_v70 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1897 @ rax_v114+8]");
																				_ = 0;
																				CinematicTarget cinematicTarget4 = this.cinematicTarget;
																				if (this.cinematicTarget != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+AC]");
																					float num5 = 0f / cinematicTarget4.Zoom;
																					goto IL_12bf;
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
						goto IL_1266;
					}
				}
			}
			goto IL_1258;
			IL_1258:
			return false;
			IL_1354:
			if ((object)_003C_003E4__this != null)
			{
				bool flag2 = 1f < _003Ct_003E5__5;
				float num5 = 1f;
				if (flag2)
				{
					goto IL_12bf;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+10C]");
				if ((nint)0 != 0)
				{
					goto IL_05cd;
				}
				ProCamera2D proCamera2D6 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D6 != null)
				{
					CinematicTarget cinematicTarget5 = this.cinematicTarget;
					if (this.cinematicTarget != null)
					{
						float num6 = proCamera2D6._003CDeltaTime_003Ek__BackingField / cinematicTarget5.EaseInDuration;
						float num7 = num6 + _003Ct_003E5__5;
						_003Ct_003E5__5 = num7;
						object vector3H4 = basePC2D.Vector3H;
						if ((object)cinematicTarget5.TargetTransform != null)
						{
							Vector3 position3 = cinematicTarget5.TargetTransform.position;
							if (basePC2D.Vector3H != null)
							{
								object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								_ = position3.x;
								_ = position3.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v210 @ r14_v10 (System.Object)+18] (should have been resolved before IL gen)");
								object vector3H5 = basePC2D.Vector3H;
								ProCamera2D proCamera2D7 = _003C_003E4__this.ProCamera2D;
								if ((object)proCamera2D7 != null && basePC2D.Vector3H != null)
								{
									object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
									_ = proCamera2D7._003CParentPosition_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rax_v23 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v211 @ r14_v11 (System.Object)+18] (should have been resolved before IL gen)");
									CinematicTarget cinematicTarget6 = this.cinematicTarget;
									if (this.cinematicTarget != null)
									{
										float end = position3.x - (float)proCamera2D7._003CParentPosition_003Ek__BackingField;
										float num8 = Utils.EaseFromTo(_003CinitialPosH_003E5__2, end, _003Ct_003E5__5, cinematicTarget6.EaseType);
										CinematicTarget cinematicTarget7 = this.cinematicTarget;
										object vector3V4 = basePC2D.Vector3V;
										if (this.cinematicTarget != null && (object)cinematicTarget7.TargetTransform != null)
										{
											Vector3 position4 = cinematicTarget7.TargetTransform.position;
											if (basePC2D.Vector3V != null)
											{
												object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
												_ = position4.x;
												_ = position4.z;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ r14_v12 (System.Object)+18] (should have been resolved before IL gen)");
												object vector3V5 = basePC2D.Vector3V;
												ProCamera2D proCamera2D8 = _003C_003E4__this.ProCamera2D;
												if ((object)proCamera2D8 != null && basePC2D.Vector3V != null)
												{
													object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
													_ = proCamera2D8._003CParentPosition_003Ek__BackingField;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rax_v29 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v213 @ r14_v13 (System.Object)+18] (should have been resolved before IL gen)");
													CinematicTarget cinematicTarget8 = this.cinematicTarget;
													if (this.cinematicTarget != null)
													{
														EaseType easeType = cinematicTarget8.EaseType;
														float end2 = position4.x - (float)proCamera2D8._003CParentPosition_003Ek__BackingField;
														float num9 = Utils.EaseFromTo(_003CinitialPosV_003E5__3, end2, _003Ct_003E5__5, cinematicTarget8.EaseType);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+90]");
														bool flag3 = (nint)0 == 0;
														float num10 = num8;
														if (!flag3)
														{
															object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
															object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851AF0F0");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
															num9 = 0f;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
															num10 = 0f;
															easeType = EaseType.EaseInOut;
														}
														Func<float, float, float, Vector3> vectorHVD2 = basePC2D.VectorHVD;
														if (basePC2D.VectorHVD != null)
														{
															object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v274 @ rdx_v25 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1874 @ rax_v34+8]");
															_ = 0;
															CinematicTarget cinematicTarget9 = this.cinematicTarget;
															if (this.cinematicTarget != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+AC]");
																float end3 = 0f / cinematicTarget9.Zoom;
																float num11 = Utils.EaseFromTo(_003CcurrentCameraSize_003E5__4, end3, _003Ct_003E5__5, cinematicTarget9.EaseType);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E0]");
																if ((nint)0 == 0)
																{
																	goto IL_05cd;
																}
																goto IL_1258;
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
			goto IL_1266;
			IL_05cd:
			ProCamera2D proCamera2D9 = _003C_003E4__this.ProCamera2D;
			if ((object)proCamera2D9 == null)
			{
				goto IL_1266;
			}
			bool flag4 = proCamera2D9.UpdateType != UpdateType.FixedUpdate;
			WaitForFixedUpdate waitForFixedUpdate = null;
			if (!flag4)
			{
				bool flag5 = proCamera2D9.IgnoreTimeScale;
				waitForFixedUpdate = null;
				if (!flag5)
				{
					waitForFixedUpdate = proCamera2D9._waitForFixedUpdate;
				}
			}
			_003C_003E2__current = waitForFixedUpdate;
			_003C_003E1__state = 1;
			goto IL_1495;
			IL_12bf:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+68]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+68]");
				((UnityEvent<int>)0).Invoke(targetIndex);
				num = 0;
			}
			CinematicTarget cinematicTarget10 = this.cinematicTarget;
			if (this.cinematicTarget == null)
			{
				goto IL_1266;
			}
			string sendMessageName = cinematicTarget10.SendMessageName;
			bool flag6 = cinematicTarget10.SendMessageName == null;
			obj4 = num;
			if (!flag6)
			{
				bool flag7 = sendMessageName._stringLength <= 0;
				obj4 = num;
				if (!flag7)
				{
					if ((object)cinematicTarget10.TargetTransform == null)
					{
						goto IL_1266;
					}
					obj4 = cinematicTarget10.SendMessageParam;
					cinematicTarget10.TargetTransform.SendMessage(cinematicTarget10.SendMessageName, cinematicTarget10.SendMessageParam, SendMessageOptions.DontRequireReceiver);
				}
			}
			_003Ct_003E5__5 = 0f;
			goto IL_1296;
			IL_11b6:
			ProCamera2D proCamera2D10 = _003C_003E4__this.ProCamera2D;
			if ((object)proCamera2D10 == null)
			{
				goto IL_1266;
			}
			bool flag8 = proCamera2D10.UpdateType != UpdateType.FixedUpdate;
			WaitForFixedUpdate waitForFixedUpdate2 = null;
			if (!flag8)
			{
				bool flag9 = proCamera2D10.IgnoreTimeScale;
				waitForFixedUpdate2 = null;
				if (!flag9)
				{
					waitForFixedUpdate2 = proCamera2D10._waitForFixedUpdate;
				}
			}
			_003C_003E2__current = waitForFixedUpdate2;
			_003C_003E1__state = 2;
			goto IL_1495;
			IL_1266:
			throw new NullReferenceException();
			IL_1296:
			CinematicTarget cinematicTarget11 = this.cinematicTarget;
			if (this.cinematicTarget != null)
			{
				if (!(0f > cinematicTarget11.HoldDuration))
				{
					float num5 = cinematicTarget11.HoldDuration;
					if (cinematicTarget11.HoldDuration < _003Ct_003E5__5)
					{
						goto IL_1258;
					}
				}
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+10C]");
					if ((nint)0 != 0)
					{
						goto IL_11b6;
					}
					ProCamera2D proCamera2D11 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D11 != null)
					{
						float num12 = _003Ct_003E5__5 + proCamera2D11._003CDeltaTime_003Ek__BackingField;
						object obj19 = this.cinematicTarget;
						_003Ct_003E5__5 = num12;
						Func<Vector3, float> vector3H6 = basePC2D.Vector3H;
						if (this.cinematicTarget != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r14_v17 (System.Object)+10]");
							object obj20 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r14_v17 (System.Object)+10]");
							if ((nint)0 != 0)
							{
								_ = 0;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ r14_v18 (System.Object)+10]");
								bool flag10 = (nint)0 == 0;
								object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ r14_v18 (System.Object)+10]");
								Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj21);
								if (basePC2D.Vector3H != null)
								{
									object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v110 @ r15_v9 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									object vector3H7 = basePC2D.Vector3H;
									ProCamera2D proCamera2D12 = _003C_003E4__this.ProCamera2D;
									if ((object)proCamera2D12 != null && basePC2D.Vector3H != null)
									{
										object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
										_ = proCamera2D12._003CParentPosition_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v60 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v225 @ r14_v19 (System.Object)+18] (should have been resolved before IL gen)");
										object obj24 = this.cinematicTarget;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
										object obj25 = 0 - proCamera2D12._003CParentPosition_003Ek__BackingField;
										Func<Vector3, float> vector3V6 = basePC2D.Vector3V;
										if (this.cinematicTarget != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ r14_v20 (System.Object)+10]");
											object obj26 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ r14_v20 (System.Object)+10]");
											if ((nint)0 != 0)
											{
												_ = 0;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ r14_v21 (System.Object)+10]");
												bool flag11 = (nint)0 == 0;
												object obj27 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ r14_v21 (System.Object)+10]");
												Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj27);
												if (basePC2D.Vector3V != null)
												{
													object obj28 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ r15_v10 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
													object vector3V7 = basePC2D.Vector3V;
													ProCamera2D proCamera2D13 = _003C_003E4__this.ProCamera2D;
													if ((object)proCamera2D13 != null && basePC2D.Vector3V != null)
													{
														object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ r14_v22 (System.Object)+18]");
														object obj30 = 0;
														_ = proCamera2D13._003CParentPosition_003Ek__BackingField;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v70 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+98]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v228 @ r14_v22 (System.Object)+18] (should have been resolved before IL gen)");
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
														object obj31 = 0 - proCamera2D13._003CParentPosition_003Ek__BackingField;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+90]");
														if ((nint)0 != 0)
														{
															object obj32 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
															object obj33 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851AF0F0");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
															obj25 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
															obj31 = 0;
															obj30 = 0;
														}
														Func<float, float, float, Vector3> vectorHVD3 = basePC2D.VectorHVD;
														if (basePC2D.VectorHVD != null)
														{
															object obj34 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v277 @ rdx_v49 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v979 @ rax_v75+8]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+E0]");
															if ((nint)0 == 0)
															{
																goto IL_11b6;
															}
															goto IL_1258;
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
			goto IL_1266;
			IL_1495:
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

	private sealed class _003CStartCinematicRoutine_003Ed__48(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DCinematics _003C_003E4__this;

		private int _003Ccount_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0202: Expected I4, but got I8
			//IL_0217: Expected O, but got I
			//IL_0232: Expected O, but got I
			//IL_004f: Expected O, but got I
			//IL_027d: Expected O, but got I
			//IL_01cc: Expected I4, but got I8
			//IL_011e: Expected O, but got I
			//IL_02cb: Expected O, but got I
			//IL_03be: Expected O, but got I
			//IL_03d5: Expected O, but got I
			//IL_0178: Expected O, but got I
			//IL_01b8: Expected F4, but got I
			//IL_01b8: Expected F4, but got I
			//IL_01b8: Expected O, but got I
			BasePC2D basePC2D = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+60]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+60]");
					((UnityEvent)0).Invoke();
				}
				ProCamera2D proCamera2D = basePC2D.ProCamera2D;
				Vector3 localPosition = proCamera2D.LocalPosition;
				_ = localPosition.x;
				_ = localPosition.z;
				ProCamera2D proCamera2D2 = basePC2D.ProCamera2D;
				Vector3 localPosition2 = proCamera2D2.LocalPosition;
				_ = localPosition2.x;
				_ = localPosition2.z;
				ProCamera2D proCamera2D3 = basePC2D.ProCamera2D;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+91]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v50 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				float num = 0f * 0.5f;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rsi_v10+10]");
						if ((nint)0 != 0)
						{
							goto IL_0168;
						}
					}
					((ProCamera2DCinematics)basePC2D).SetupLetterbox();
					goto IL_0168;
				}
				goto IL_01bd;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				goto IL_0207;
			}
			goto IL_031e;
			IL_0168:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+9C]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+C0]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+94]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+98]");
			((ProCamera2DLetterbox)num2).TweenTo(num3, 0f);
			goto IL_01bd;
			IL_031e:
			return false;
			IL_0207:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+80]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v12+18]");
			object obj4 = -1;
			if (_003Ccount_003E5__2 < (nint)obj4)
			{
				int num4 = _003Ccount_003E5__2 + 1;
				_003Ccount_003E5__2 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+80]");
				object obj5 = 0;
				_ = 0;
				int num5 = _003Ccount_003E5__2;
				int num6 = _003Ccount_003E5__2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v16+18]");
				if ((nint)num6 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v16+10]");
					object obj6 = 0;
					_003CGoToCinematicTargetRoutine_003Ed__49 obj7 = null;
					obj7._003C_003E1__state = 0;
					obj7._003C_003E4__this = (ProCamera2DCinematics)basePC2D;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdx_v7+20+v126 @ rcx_v9 (System.Int32)*8]");
					obj7.cinematicTarget = (CinematicTarget)0;
					obj7.targetIndex = _003Ccount_003E5__2;
					Coroutine coroutine = basePC2D.StartCoroutine(obj7);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+D0]");
					_003C_003E2__current = 0;
					_003C_003E1__state = 1;
					return true;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				bool result = default(bool);
				return result;
			}
			((ProCamera2DCinematics)basePC2D).Stop();
			goto IL_031e;
			IL_01bd:
			_003Ccount_003E5__2 = -1;
			goto IL_0207;
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

	public static string ExtensionName = "Cinematics";

	public UnityEvent OnCinematicStarted;

	public CinematicEvent OnCinematicTargetReached;

	public UnityEvent OnCinematicFinished;

	private bool _isPlaying;

	public List<CinematicTarget> CinematicTargets;

	public float EndDuration;

	public EaseType EndEaseType;

	public bool UseNumericBoundaries;

	public bool UseLetterbox;

	public float LetterboxAmount;

	public float LetterboxAnimDuration;

	public Color LetterboxColor;

	private float _initialCameraSize;

	private ProCamera2DNumericBoundaries _numericBoundaries;

	private bool _numericBoundariesPreviousState;

	private ProCamera2DLetterbox _letterbox;

	private Coroutine _startCinematicRoutine;

	private Coroutine _goToCinematicRoutine;

	private Coroutine _endCinematicRoutine;

	private bool _skipTarget;

	private Vector3 _newPos;

	private Vector3 _originalPos;

	private Vector3 _startPos;

	private float _newSize;

	private bool _paused;

	private int _poOrder;

	private int _soOrder;

	public bool IsPlaying => _isPlaying;

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
		if (UseLetterbox)
		{
			SetupLetterbox();
		}
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.AddPositionOverrider(this);
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
			bool flag = ((List<object>)(object)proCamera2D2._positionOverriders).Remove((object)this);
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			bool flag2 = ((List<object>)(object)proCamera2D3._sizeOverriders).Remove((object)this);
		}
	}

	public unsafe Vector3 OverridePosition(float deltaTime, Vector3 originalPosition)
	{
		//IL_00a7: Expected O, but got I4
		//IL_008e: Expected native int or pointer, but got O
		//IL_00d9: Expected native int or pointer, but got O
		//IL_0045: Expected O, but got F4
		//IL_006d: Expected F4, but got I
		//IL_007c: Expected F4, but got O
		//IL_0077: Expected native int or pointer, but got O
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		bool flag2 = obj == null;
		float z = originalPosition.z;
		Vector3 vector = default(Vector3);
		if (!flag2)
		{
			bool flag3 = !_isPlaying;
			_originalPos = (Vector3)originalPosition.x;
			_ = originalPosition.z;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DCinematics)+EC]");
				z = 0f;
				((Vector3*)(nint)vector)->x = (float)_newPos;
				goto IL_00d1;
			}
		}
		((Vector3*)(nint)vector)->x = originalPosition.x;
		goto IL_00d1;
		IL_00d1:
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	public float OverrideSize(float deltaTime, float originalSize)
	{
		//IL_005f: Expected O, but got I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null && _isPlaying)
		{
			return _newSize;
		}
		return originalSize;
	}

	public void Play()
	{
		if (_isPlaying)
		{
			return;
		}
		List<CinematicTarget> cinematicTargets = CinematicTargets;
		_paused = false;
		if (cinematicTargets._size != 0)
		{
			ProCamera2D proCamera2D = base.ProCamera2D;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v9 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			float initialCameraSize = 0f * 0.5f;
			ProCamera2DNumericBoundaries numericBoundaries = _numericBoundaries;
			_initialCameraSize = initialCameraSize;
			if ((object)_numericBoundaries == null || ((UnityEngine.Object)numericBoundaries).m_CachedPtr == (IntPtr)0)
			{
				ProCamera2D proCamera2D2 = base.ProCamera2D;
				ProCamera2DNumericBoundaries componentInChildren = proCamera2D2.GetComponentInChildren<ProCamera2DNumericBoundaries>();
				_numericBoundaries = componentInChildren;
			}
			ProCamera2DNumericBoundaries numericBoundaries2 = _numericBoundaries;
			if ((object)_numericBoundaries == null || ((UnityEngine.Object)numericBoundaries2).m_CachedPtr == (IntPtr)0)
			{
				ProCamera2DNumericBoundaries numericBoundaries3 = UnityEngine.Object.FindObjectOfType<ProCamera2DNumericBoundaries>();
				_numericBoundaries = numericBoundaries3;
			}
			ProCamera2DNumericBoundaries numericBoundaries4 = _numericBoundaries;
			if ((object)_numericBoundaries != null && ((UnityEngine.Object)numericBoundaries4).m_CachedPtr != (IntPtr)0)
			{
				bool numericBoundariesPreviousState = _numericBoundaries.enabled;
				_numericBoundariesPreviousState = numericBoundariesPreviousState;
				_numericBoundaries.enabled = false;
			}
			else
			{
				UseNumericBoundaries = false;
			}
			_isPlaying = true;
			if (_endCinematicRoutine != null)
			{
				StopCoroutine(_endCinematicRoutine);
				_endCinematicRoutine = null;
			}
			if (_startCinematicRoutine == null)
			{
				_003CStartCinematicRoutine_003Ed__48 obj = null;
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = this;
				Coroutine startCinematicRoutine = StartCoroutine(obj);
				_startCinematicRoutine = startCinematicRoutine;
			}
		}
		else
		{
			Debug.LogWarning("No cinematic targets added to the list");
		}
	}

	public void Stop()
	{
		if (_isPlaying)
		{
			if (_startCinematicRoutine != null)
			{
				StopCoroutine(_startCinematicRoutine);
				_startCinematicRoutine = null;
			}
			if (_goToCinematicRoutine != null)
			{
				StopCoroutine(_goToCinematicRoutine);
				_goToCinematicRoutine = null;
			}
			if (_endCinematicRoutine == null)
			{
				_003CEndCinematicRoutine_003Ed__50 obj = null;
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = this;
				Coroutine endCinematicRoutine = StartCoroutine(obj);
				_endCinematicRoutine = endCinematicRoutine;
			}
		}
	}

	public void Toggle()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 12 Invalid \"Jump target not found in method: 0x1851ADEC0\"");
		Stop();
	}

	public void GoToNextTarget()
	{
		_skipTarget = true;
	}

	public void Pause()
	{
		_paused = true;
	}

	public void Unpause()
	{
		_paused = false;
	}

	public void AddCinematicTarget(Transform targetTransform, float easeInDuration = 1f, float holdDuration = 1f, float zoom = 1f, EaseType easeType = EaseType.EaseOut, string sendMessageName = "", string sendMessageParam = "", int index = -1)
	{
		//IL_01a2: Expected F4, but got I
		CinematicTarget cinematicTarget = new CinematicTarget();
		cinematicTarget.EaseInDuration = 1f;
		cinematicTarget.HoldDuration = 1f;
		cinematicTarget.Zoom = 1f;
		cinematicTarget.EaseType = EaseType.EaseOut;
		cinematicTarget.TargetTransform = targetTransform;
		EaseType easeType2 = default(EaseType);
		cinematicTarget.EaseType = easeType2;
		string sendMessageName2 = default(string);
		cinematicTarget.SendMessageName = sendMessageName2;
		cinematicTarget.EaseInDuration = easeInDuration;
		cinematicTarget.HoldDuration = holdDuration;
		IntPtr intPtr = default(IntPtr);
		cinematicTarget.Zoom = (nint)intPtr;
		string sendMessageParam2 = default(string);
		cinematicTarget.SendMessageParam = sendMessageParam2;
		int num = default(int);
		if (num != -1)
		{
			List<object> cinematicTargets = (List<object>)(object)CinematicTargets;
			if (num <= cinematicTargets._size)
			{
				cinematicTargets.Insert(num, cinematicTarget);
				return;
			}
		}
		List<object> cinematicTargets2 = (List<object>)(object)CinematicTargets;
		int version = cinematicTargets2._version + 1;
		cinematicTargets2._version = version;
		object[] items = cinematicTargets2._items;
		if (cinematicTargets2._size >= items.Length)
		{
			cinematicTargets2.AddWithResize((object)cinematicTarget);
			return;
		}
		int size = cinematicTargets2._size + 1;
		cinematicTargets2._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void RemoveCinematicTarget(Transform targetTransform)
	{
		//IL_0182: Expected O, but got I4
		//IL_018b: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_00c6: Expected O, but got I
		//IL_0117: Expected O, but got I4
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0109: Expected O, but got I
		List<CinematicTarget> cinematicTargets = CinematicTargets;
		object obj = 0;
		object obj2 = 0;
		object item = default(object);
		while (true)
		{
			if ((nint)obj2 < cinematicTargets._size)
			{
				List<CinematicTarget> cinematicTargets2 = CinematicTargets;
				if ((nint)obj >= cinematicTargets2._size)
				{
					break;
				}
				CinematicTarget[] items = cinematicTargets2._items;
				CinematicTarget cinematicTarget = items[obj];
				Transform targetTransform2 = cinematicTarget.TargetTransform;
				object obj3;
				if (((UnityEngine.Object)targetTransform2).m_CachedPtr != (IntPtr)0)
				{
					IntPtr cachedPtr = ((UnityEngine.Object)targetTransform2).m_CachedPtr;
					int offsetOfInstanceIDInCPlusPlusObject = UnityEngine.Object.OffsetOfInstanceIDInCPlusPlusObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v27 (System.Int32)+v316 @ rdi_v12 (System.IntPtr)]");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rax_v22 (System.Int32)+v64 @ rbp_v6 (System.IntPtr)]");
					obj4 = 0;
				}
				else
				{
					obj4 = 0;
				}
				if (obj3 == obj4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag = ((List<object>)(object)CinematicTargets).Remove(item);
					nint num = 0;
				}
				cinematicTargets = CinematicTargets;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private IEnumerator StartCinematicRoutine()
	{
		_003CStartCinematicRoutine_003Ed__48 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator GoToCinematicTargetRoutine(CinematicTarget cinematicTarget, int targetIndex)
	{
		_003CGoToCinematicTargetRoutine_003Ed__49 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.cinematicTarget = cinematicTarget;
		obj.targetIndex = targetIndex;
		return obj;
	}

	private IEnumerator EndCinematicRoutine()
	{
		_003CEndCinematicRoutine_003Ed__50 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void SetupLetterbox()
	{
		ProCamera2D proCamera2D = base.ProCamera2D;
		GameObject gameObject = proCamera2D.gameObject;
		ProCamera2DLetterbox componentInChildren = gameObject.GetComponentInChildren<ProCamera2DLetterbox>(includeInactive: false);
		if ((object)componentInChildren == null || ((UnityEngine.Object)componentInChildren).m_CachedPtr == (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			GameObject gameObject2 = proCamera2D2.gameObject;
			Camera[] componentsInChildren = gameObject2.GetComponentsInChildren<Camera>(includeInactive: false);
			Func<object, float> keySelector = (Func<object, float>)_003C_003Ec._003C_003E9__51_0;
			if (_003C_003Ec._003C_003E9__51_0 == null)
			{
				keySelector = (Func<object, float>)(_003C_003Ec._003C_003E9__51_0 = (Func<object, float>)delegate(Camera c)
				{
					bool flag2 = ((UnityEngine.Object)c).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
					/*Error: End of method reached without returning.*/;
				});
			}
			bool flag = default(bool);
			System.Linq.OrderedEnumerable<object, float> orderedEnumerable = new System.Linq.OrderedEnumerable<object, float>((IEnumerable<object>)componentsInChildren, keySelector, (IComparer<float>)null, flag);
			if (orderedEnumerable == null)
			{
				Exception ex = System.Linq.Error.ArgumentNull("source");
				throw ex;
			}
			System.Linq.Buffer<object> buffer = new System.Linq.Buffer<object>((IEnumerable<object>)orderedEnumerable);
			System.Linq.Buffer<Camera> buffer2 = default(System.Linq.Buffer<Camera>);
			Camera[] array = buffer2.ToArray();
			GameObject gameObject3 = array[0].gameObject;
			ProCamera2DLetterbox proCamera2DLetterbox = gameObject3.AddComponent<ProCamera2DLetterbox>();
		}
		_letterbox = componentInChildren;
	}

	private unsafe void LimitToNumericBoundaries(ref float horizontalPos, ref float verticalPos)
	{
		//IL_00dc: Expected Ref, but got F4
		//IL_01bd: Expected Ref, but got F4
		//IL_0295: Expected Ref, but got F4
		//IL_037c: Expected Ref, but got F4
		ProCamera2DNumericBoundaries numericBoundaries = _numericBoundaries;
		if (numericBoundaries.UseLeftBoundary)
		{
			ProCamera2D proCamera2D = base.ProCamera2D;
			ProCamera2DNumericBoundaries numericBoundaries2 = _numericBoundaries;
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
		ProCamera2DNumericBoundaries numericBoundaries3 = _numericBoundaries;
		if (numericBoundaries3.UseRightBoundary)
		{
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			ProCamera2DNumericBoundaries numericBoundaries4 = _numericBoundaries;
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
		ProCamera2DNumericBoundaries numericBoundaries5 = _numericBoundaries;
		if (numericBoundaries5.UseBottomBoundary)
		{
			ProCamera2D proCamera2D5 = base.ProCamera2D;
			ProCamera2DNumericBoundaries numericBoundaries6 = _numericBoundaries;
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
		ProCamera2DNumericBoundaries numericBoundaries7 = _numericBoundaries;
		if (numericBoundaries7.UseTopBoundary)
		{
			ProCamera2D proCamera2D7 = base.ProCamera2D;
			ProCamera2DNumericBoundaries numericBoundaries8 = _numericBoundaries;
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

	public ProCamera2DCinematics()
	{
		//IL_00ba: Expected O, but got I
		UnityEvent unityEvent = (UnityEvent)new UnityEventBase();
		unityEvent.m_InvokeArray = null;
		((UnityEventBase)unityEvent)._002Ector();
		OnCinematicStarted = unityEvent;
		CinematicEvent onCinematicTargetReached = new CinematicEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnCinematicTargetReached = onCinematicTargetReached;
		OnCinematicFinished = (UnityEvent)new UnityEventBase
		{
			m_InvokeArray = null
		};
		List<CinematicTarget> cinematicTargets = new List<CinematicTarget>();
		CinematicTargets = cinematicTargets;
		EndDuration = 1f;
		EndEaseType = EaseType.EaseOut;
		UseLetterbox = true;
		LetterboxAmount = 0.1f;
		LetterboxAnimDuration = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		LetterboxColor = (Color)0;
		_soOrder = 3000;
	}
}
