using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public abstract class BaseTrigger : BasePC2D
{
	private sealed class _003CTestTriggerRoutine_003Ed__19(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BaseTrigger _003C_003E4__this;

		private WaitForSeconds _003CwaitForSeconds_003E5__2;

		private WaitForSecondsRealtime _003CwaitForSecondsRealtime_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_01d1: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_00a4: Expected I4, but got I8
			//IL_0208: Expected I4, but got O
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0071: Expected I4, but got I8
			BaseTrigger baseTrigger = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag && (nint)obj2 != 1)
					{
						return false;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						goto IL_011d;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						WaitForSeconds waitForSeconds = null;
						waitForSeconds.m_Seconds = baseTrigger.UpdateInterval;
						_003CwaitForSeconds_003E5__2 = waitForSeconds;
						WaitForSecondsRealtime waitForSecondsRealtime = null;
						waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = baseTrigger.UpdateInterval;
						waitForSecondsRealtime.m_WaitUntilTime = -1f;
						_003CwaitForSecondsRealtime_003E5__3 = waitForSecondsRealtime;
						goto IL_011d;
					}
				}
				goto IL_01fa;
			}
			_003C_003E1__state = -1;
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			_003C_003E2__current = waitForEndOfFrame;
			_003C_003E1__state = 1;
			return true;
			IL_01fa:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_011d:
			_003C_003E4__this.TestTrigger();
			ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
			if ((object)proCamera2D != null)
			{
				if (!proCamera2D.IgnoreTimeScale)
				{
					_003C_003E2__current = _003CwaitForSeconds_003E5__2;
					_003C_003E1__state = 3;
					return true;
				}
				_003C_003E2__current = _003CwaitForSecondsRealtime_003E5__3;
				_003C_003E1__state = 2;
				return true;
			}
			goto IL_01fa;
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

	public Action OnEnteredTrigger;

	public Action OnExitedTrigger;

	public float UpdateInterval;

	public TriggerShape TriggerShape;

	public bool UseTargetsMidPoint;

	public Transform TriggerTarget;

	protected float _exclusiveInfluencePercentage;

	private Coroutine _testTriggerRoutine;

	protected bool _insideTrigger;

	protected Vector2 _vectorFromPointToCenter;

	protected int _instanceID;

	private bool _triggerEnabled;

	protected override void Awake()
	{
		//IL_005a: Expected O, but got I
		//IL_00c0: Expected O, but got I8
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D == null || ((UnityEngine.Object)proCamera2D).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
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
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v227 @ rax_v12 (should have been resolved before IL gen)");
		float updateInterval = -0.02f + UpdateInterval;
		UpdateInterval = updateInterval;
		Toggle(value: true);
	}

	protected override void OnEnable()
	{
		Enable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0 && _triggerEnabled)
		{
			Toggle(value: true);
		}
	}

	protected override void OnDisable()
	{
		Disable();
		_testTriggerRoutine = null;
	}

	public void Toggle(bool value)
	{
		//IL_00bc: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		if (!value)
		{
			if (_testTriggerRoutine != null)
			{
				StopCoroutine(_testTriggerRoutine);
				_testTriggerRoutine = null;
			}
			if (_insideTrigger)
			{
				ExitedTrigger();
			}
			object obj = 168;
			_ = 0;
		}
		else
		{
			if (_testTriggerRoutine == null)
			{
				_003CTestTriggerRoutine_003Ed__19 obj2 = null;
				obj2._003C_003E1__state = 0;
				obj2._003C_003E4__this = this;
				Coroutine testTriggerRoutine = StartCoroutine(obj2);
				_testTriggerRoutine = testTriggerRoutine;
			}
			object obj3 = 168;
			_ = 1;
		}
	}

	public unsafe void TestTrigger()
	{
		//IL_0008: Expected O, but got Ref
		//IL_002a: Expected O, but got I
		//IL_0817: Expected O, but got Ref
		//IL_09d4: Expected O, but got Ref
		//IL_010a: Expected O, but got Ref
		//IL_0405: Expected O, but got Ref
		//IL_0886: Expected O, but got Ref
		//IL_0a43: Expected O, but got Ref
		//IL_07a2: Expected O, but got Ref
		//IL_07c7: Expected O, but got I
		//IL_07d7: Expected O, but got I
		//IL_0179: Expected O, but got Ref
		//IL_0474: Expected O, but got Ref
		//IL_08f5: Expected O, but got Ref
		//IL_0ab2: Expected O, but got Ref
		//IL_01e8: Expected O, but got Ref
		//IL_04e3: Expected O, but got Ref
		//IL_0964: Expected O, but got Ref
		//IL_0b21: Expected O, but got Ref
		//IL_0257: Expected O, but got Ref
		//IL_0552: Expected O, but got Ref
		//IL_02b2: Expected O, but got Ref
		//IL_05ad: Expected O, but got Ref
		//IL_02fd: Expected O, but got Ref
		//IL_034e: Expected F4, but got I
		//IL_034e: Expected F4, but got I
		//IL_034e: Expected F4, but got I
		//IL_034e: Expected F4, but got I
		//IL_05f8: Expected O, but got Ref
		//IL_0629: Expected O, but got I
		//IL_0646: Expected O, but got I
		//IL_0663: Expected O, but got I
		//IL_0846->IL06f3: Incompatible stack heights: 1 vs 0
		//IL_0a03->IL06f3: Incompatible stack heights: 1 vs 0
		//IL_015c->IL06f3: Incompatible stack heights: 1 vs 0
		//IL_0457->IL06f3: Incompatible stack heights: 1 vs 0
		//IL_08b5->IL06f3: Incompatible stack heights: 2 vs 0
		//IL_0a72->IL06f3: Incompatible stack heights: 2 vs 0
		//IL_07dc->IL0721: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL06f3: Incompatible stack heights: 2 vs 0
		//IL_04c6->IL06f3: Incompatible stack heights: 2 vs 0
		//IL_0924->IL06f3: Incompatible stack heights: 3 vs 0
		//IL_0ae1->IL06f3: Incompatible stack heights: 3 vs 0
		//IL_023a->IL06f3: Incompatible stack heights: 3 vs 0
		//IL_0535->IL06f3: Incompatible stack heights: 3 vs 0
		//IL_0993->IL06f3: Incompatible stack heights: 4 vs 0
		//IL_0b50->IL06f3: Incompatible stack heights: 4 vs 0
		//IL_029f->IL06f3: Incompatible stack heights: 4 vs 0
		//IL_059a->IL06f3: Incompatible stack heights: 4 vs 0
		//IL_02ea->IL06f3: Incompatible stack heights: 4 vs 0
		//IL_05e5->IL06f3: Incompatible stack heights: 4 vs 0
		//IL_0366->IL0398: Incompatible stack heights: 4 vs 0
		//IL_0388->IL0998: Incompatible stack heights: 4 vs 0
		//IL_06c9->IL06c9: Incompatible stack heights: 4 vs 0
		//IL_0398->IL0998: Incompatible stack heights: 4 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ProCamera2D proCamera2D = base.ProCamera2D;
		bool num;
		bool num2;
		bool num3;
		bool num4;
		if ((object)proCamera2D != null)
		{
			Vector3 vector = proCamera2D._003CTargetsMidPoint_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+7C]");
			object obj3 = 0;
			if (!UseTargetsMidPoint)
			{
				Transform triggerTarget = TriggerTarget;
				if ((object)TriggerTarget != null && ((UnityEngine.Object)triggerTarget).m_CachedPtr != (IntPtr)0)
				{
					object triggerTarget2 = TriggerTarget;
					if ((object)TriggerTarget == null)
					{
						goto IL_06f3;
					}
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdi_v35 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdi_v35 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj4);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
					vector = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-41]");
					obj3 = 0;
				}
			}
			if (TriggerShape != TriggerShape.RECTANGLE)
			{
				goto IL_0398;
			}
			object obj5 = _transform;
			Func<Vector3, float> vector3H = Vector3H;
			if ((object)_transform != null)
			{
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdi_v30 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				num = flag2;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdi_v30 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
				if (Vector3H != null)
				{
					object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v179 @ rsi_v30 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					object obj8 = _transform;
					Func<Vector3, float> vector3V = Vector3V;
					if ((object)_transform != null)
					{
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rdi_v31 (System.Object)+10]");
						bool flag3 = (nint)0 == 0;
						num2 = flag3;
						object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rdi_v31 (System.Object)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj9);
						if (Vector3V != null)
						{
							object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v180 @ rsi_v31 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							object obj11 = _transform;
							Func<Vector3, float> vector3H2 = Vector3H;
							if ((object)_transform != null)
							{
								_ = 0;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdi_v32 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								num3 = flag4;
								object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdi_v32 (System.Object)+10]");
								Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj12);
								if (Vector3H != null)
								{
									object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v181 @ rsi_v32 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									object obj14 = _transform;
									Func<Vector3, float> vector3V2 = Vector3V;
									if ((object)_transform != null)
									{
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v33 (System.Object)+10]");
										bool flag5 = (nint)0 == 0;
										num4 = flag5;
										object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v33 (System.Object)+10]");
										Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj15);
										if (Vector3V != null)
										{
											object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v182 @ rsi_v33 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
											Func<Vector3, float> vector3H3 = Vector3H;
											if (Vector3H != null)
											{
												object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v241 @ rcx_v100 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
												Func<Vector3, float> vector3V3 = Vector3V;
												if (Vector3V != null)
												{
													object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v242 @ rcx_v102 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
													nint num5 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
													nint num6 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
													nint num7 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
													float pointX = default(float);
													float pointY = default(float);
													if (Utils.IsInsideRectangle(num5, num6, num7, 0f, pointX, pointY))
													{
														goto IL_036b;
													}
													goto IL_0398;
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
		goto IL_06f3;
		IL_0398:
		if (TriggerShape != TriggerShape.CIRCLE)
		{
			goto IL_06c9;
		}
		object obj19 = _transform;
		Func<Vector3, float> vector3H4 = Vector3H;
		if ((object)_transform != null)
		{
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdi_v25 (System.Object)+10]");
			bool flag6 = (nint)0 == 0;
			num = flag6;
			object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdi_v25 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj20);
			if (Vector3H != null)
			{
				object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v183 @ rsi_v25 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				object obj22 = _transform;
				Func<Vector3, float> vector3V4 = Vector3V;
				if ((object)_transform != null)
				{
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v26 (System.Object)+10]");
					bool flag7 = (nint)0 == 0;
					num2 = flag7;
					object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v26 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj23);
					if (Vector3V != null)
					{
						object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v184 @ rsi_v26 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						object obj25 = _transform;
						Func<Vector3, float> vector3H5 = Vector3H;
						if ((object)_transform != null)
						{
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v27 (System.Object)+10]");
							bool flag8 = (nint)0 == 0;
							num3 = flag8;
							object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v27 (System.Object)+10]");
							Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj26);
							if (Vector3H != null)
							{
								object obj27 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v185 @ rsi_v27 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
								Func<Vector3, float> func = (Func<Vector3, float>)(object)_transform;
								object vector3V5 = Vector3V;
								if ((object)_transform != null)
								{
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rsi_v28 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
									bool flag9 = (nint)0 == 0;
									num4 = flag9;
									object obj28 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rsi_v28 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
									Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj28);
									if (Vector3V != null)
									{
										object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v196 @ rdi_v28 (System.Object)+18] (should have been resolved before IL gen)");
										Func<Vector3, float> vector3H6 = Vector3H;
										if (Vector3H != null)
										{
											object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v247 @ rcx_v70 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
											Func<Vector3, float> vector3V6 = Vector3V;
											if (Vector3V != null)
											{
												object obj31 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v248 @ rcx_v72 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
												nint num8 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
												object obj32 = num8 - 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
												nint num9 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
												object obj33 = num9 + 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
												nint num10 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
												object obj34 = num10 - 0;
												object obj35 = obj32 * obj32;
												float num11 = (float)obj33 * 0.25f;
												float num12 = (float)obj34 * (float)obj34;
												float num13 = num11 * num11;
												float num14 = (float)obj35 + num12;
												if (num13 > num14)
												{
													goto IL_036b;
												}
												goto IL_06c9;
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
		goto IL_06f3;
		IL_06c9:
		if (_insideTrigger)
		{
			ExitedTrigger();
		}
		return;
		IL_06f3:
		throw new NullReferenceException();
		IL_036b:
		if (!_insideTrigger)
		{
			EnteredTrigger();
		}
	}

	protected virtual void EnteredTrigger()
	{
		bool flag = OnEnteredTrigger == null;
		_insideTrigger = true;
		if (!flag)
		{
			Action onEnteredTrigger = OnEnteredTrigger;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	protected virtual void ExitedTrigger()
	{
		bool flag = OnExitedTrigger == null;
		_insideTrigger = false;
		if (!flag)
		{
			Action onExitedTrigger = OnExitedTrigger;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private IEnumerator TestTriggerRoutine()
	{
		_003CTestTriggerRoutine_003Ed__19 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected unsafe float GetDistanceToCenterPercentage(Vector2 point)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_05dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
		//IL_064a: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_016d: Expected O, but got F4
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Expected O, but got Unknown
		//IL_078d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Expected O, but got Unknown
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_02f4: Invalid comparison between I4 and F4
		//IL_07f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Expected O, but got Unknown
		//IL_033f: Expected F4, but got I4
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Expected O, but got Unknown
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Expected O, but got Unknown
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Expected O, but got Unknown
		//IL_0867: Invalid comparison between I4 and F4
		//IL_059d: Expected F4, but got I4
		//IL_060d->IL05a2: Incompatible stack heights: 1 vs 0
		//IL_00d3->IL05a2: Incompatible stack heights: 1 vs 0
		//IL_0676->IL05a2: Incompatible stack heights: 2 vs 0
		//IL_0368->IL05a2: Incompatible stack heights: 2 vs 0
		//IL_01c3->IL05a2: Incompatible stack heights: 2 vs 0
		//IL_03be->IL05a2: Incompatible stack heights: 2 vs 0
		//IL_06df->IL05a2: Incompatible stack heights: 3 vs 0
		//IL_07be->IL05a2: Incompatible stack heights: 3 vs 0
		//IL_0232->IL05a2: Incompatible stack heights: 3 vs 0
		//IL_0423->IL05a2: Incompatible stack heights: 3 vs 0
		//IL_0479->IL05a2: Incompatible stack heights: 3 vs 0
		//IL_0748->IL05a2: Incompatible stack heights: 4 vs 0
		//IL_0827->IL05a2: Incompatible stack heights: 4 vs 0
		object obj2 = default(object);
		object obj = obj2 - 95;
		Transform transform = _transform;
		Func<Vector3, float> vector3H = Vector3H;
		if ((object)_transform != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj3 = obj - 41;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
			if (Vector3H != null)
			{
				object obj4 = obj - 25;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v14 @ rsi_v1 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Transform transform2 = _transform;
				Func<Vector3, float> vector3V = Vector3V;
				if ((object)_transform != null)
				{
					_ = 0;
					_ = 0;
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					object obj5 = obj - 41;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj5);
					if (Vector3V != null)
					{
						object obj6 = obj - 25;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v290 @ rsi_v15 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
						float num = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
						float num2 = num - 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+6B]");
						float num3 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
						float num4 = num3 - 0f;
						bool flag3 = TriggerShape == TriggerShape.RECTANGLE;
						_vectorFromPointToCenter = (Vector2)num2;
						bool num5;
						bool num6;
						if (!flag3)
						{
							object obj7 = this + 156;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
							Transform transform3 = _transform;
							Func<Vector3, float> vector3H2 = Vector3H;
							if ((object)_transform != null)
							{
								_ = 0;
								_ = 0;
								bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								num5 = flag4;
								object obj8 = obj - 41;
								Transform.get_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj8);
								if (Vector3H != null)
								{
									object obj9 = obj - 25;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v291 @ rsi_v20 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									Transform transform4 = _transform;
									Func<Vector3, float> vector3V2 = Vector3V;
									if ((object)_transform != null)
									{
										_ = 0;
										_ = 0;
										bool flag5 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										num6 = flag5;
										object obj10 = obj - 41;
										Transform.get_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj10);
										if (Vector3V != null)
										{
											object obj11 = obj - 25;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v67 @ r14_v21 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
											float num7 = 0f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
											float num8 = num7 + 0f;
											float num9 = num8 * 0.25f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
											float num10 = 0f / num9;
											float num11 = num10 - _exclusiveInfluencePercentage;
											float num12 = 1f - _exclusiveInfluencePercentage;
											float num13 = num11 / num12;
											if (!(0f > num13))
											{
												if (num13 > 1f)
												{
													num13 = 1f;
												}
											}
											else
											{
												num13 = 0f;
											}
											return num13;
										}
									}
								}
							}
						}
						else
						{
							Func<Vector3, float> vector3H3 = Vector3H;
							if (Vector3H != null)
							{
								object obj12 = obj - 25;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v131 @ rcx_v41 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
								Transform transform5 = _transform;
								Func<Vector3, float> vector3H4 = Vector3H;
								if ((object)_transform != null)
								{
									_ = 0;
									_ = 0;
									bool flag6 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
									num5 = flag6;
									object obj13 = obj - 41;
									Transform.get_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)obj13);
									if (Vector3H != null)
									{
										object obj14 = obj - 25;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v292 @ rsi_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
										Func<Vector3, float> vector3V3 = Vector3V;
										if (Vector3V != null)
										{
											object obj15 = obj - 25;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v133 @ rcx_v47 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
											Transform transform6 = _transform;
											Func<Vector3, float> vector3V4 = Vector3V;
											if ((object)_transform != null)
											{
												_ = 0;
												_ = 0;
												bool flag7 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
												num6 = flag7;
												object obj16 = obj - 41;
												Transform.get_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out *(Vector3*)obj16);
												if (Vector3V != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
													float num14 = 0f * 0.5f;
													object obj17 = obj - 25;
													float num16 = default(float);
													float num15 = num16 / num14;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
													object obj18 = num15 & 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v69 @ r14_v19 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
													float num17 = 0f * 0.5f;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
													float num18 = 0f / num17;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
													object obj19 = num18 & 0;
													if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj19))
													{
														obj18 = obj19;
													}
													float num19 = (float)obj18 - _exclusiveInfluencePercentage;
													float num20 = 1f - _exclusiveInfluencePercentage;
													float num21 = num19 / num20;
													if (!(0f > num21))
													{
														if (num21 > 1f)
														{
															return 1f;
														}
													}
													else
													{
														num21 = 0f;
													}
													return num21;
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

	protected BaseTrigger()
	{
		//IL_002b: Expected I, but got O
		UpdateInterval = 0.1f;
		UseTargetsMidPoint = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
