using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DTriggerZoom : BaseTrigger
{
	private sealed class _003CInsideTriggerRoutine_003Ed__17(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DTriggerZoom _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_005e: Expected I4, but got I8
			//IL_00b3: Expected I4, but got I8
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Expected F4, but got Unknown
			//IL_01f0: Invalid comparison between F4 and I
			//IL_053e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0543: Expected O, but got Unknown
			//IL_069a: Expected F4, but got I
			//IL_07f5->IL0790: Incompatible stack heights: 1 vs 0
			//IL_085a->IL07f5: Incompatible stack heights: 1 vs 0
			ProCamera2DTriggerZoom proCamera2DTriggerZoom = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					goto IL_075a;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0745;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v59 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
						float num = 0f * 0.5f;
						float num2 = num - proCamera2DTriggerZoom._targetCamSize;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						float num3 = num2 & 0;
						if (num3 > 0.0001f)
						{
							float smoothness = ((!proCamera2DTriggerZoom.ResetSizeOnExit) ? proCamera2DTriggerZoom.ZoomSmoothness : proCamera2DTriggerZoom.ResetSizeSmoothness);
							_003C_003E4__this.UpdateScreenSize(smoothness);
						}
						ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851D45B2h\"");
							float previousCamSize = proCamera2DTriggerZoom._previousCamSize;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v61 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
							if (previousCamSize == 0f)
							{
								ProCamera2D proCamera2D3 = _003C_003E4__this.ProCamera2D;
								if ((object)proCamera2D3 == null)
								{
									goto IL_0753;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rax_v62 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
								num3 = 0f * 0.5f;
								proCamera2DTriggerZoom._zoomVelocity = 0f;
								proCamera2DTriggerZoom._targetCamSize = num3;
								proCamera2DTriggerZoom._targetCamSizeSmoothed = num3;
							}
							goto IL_075a;
						}
					}
				}
			}
			goto IL_0753;
			IL_075a:
			if (!proCamera2DTriggerZoom._insideTrigger)
			{
				goto IL_0745;
			}
			ProCamera2D proCamera2D4 = _003C_003E4__this.ProCamera2D;
			if ((object)proCamera2D4 != null)
			{
				if (proCamera2DTriggerZoom._instanceID != proCamera2D4.CurrentZoomTriggerID)
				{
					goto IL_0745;
				}
				Func<Vector3, float> vector3H = proCamera2DTriggerZoom.Vector3H;
				proCamera2DTriggerZoom._exclusiveInfluencePercentage = proCamera2DTriggerZoom.ExclusiveInfluencePercentage;
				Vector3 vector;
				Vector3 ret;
				if (proCamera2DTriggerZoom.UseTargetsMidPoint)
				{
					ProCamera2D proCamera2D5 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D5 == null)
					{
						goto IL_0753;
					}
					vector = proCamera2D5._003CTargetsMidPoint_003Ek__BackingField;
				}
				else
				{
					object triggerTarget = proCamera2DTriggerZoom.TriggerTarget;
					if ((object)proCamera2DTriggerZoom.TriggerTarget == null)
					{
						goto IL_0753;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rsi_v11 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rsi_v11 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					vector = ret;
				}
				if (proCamera2DTriggerZoom.Vector3H != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v96 @ r14_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					Func<Vector3, float> vector3V = proCamera2DTriggerZoom.Vector3V;
					if (proCamera2DTriggerZoom.UseTargetsMidPoint)
					{
						ProCamera2D proCamera2D6 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D6 == null)
						{
							goto IL_0753;
						}
						Vector3 vector2 = proCamera2D6._003CTargetsMidPoint_003Ek__BackingField;
						ret = vector;
					}
					else
					{
						object triggerTarget2 = proCamera2DTriggerZoom.TriggerTarget;
						if ((object)proCamera2DTriggerZoom.TriggerTarget == null)
						{
							goto IL_0753;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rsi_v10 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rsi_v10 (System.Object)+10]");
						Transform.get_position_Injected((IntPtr)0, out ret);
						Vector3 vector2 = ret;
					}
					if (proCamera2DTriggerZoom.Vector3V != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v71 @ r15_v8 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						Vector2 point = default(Vector2);
						float distanceToCenterPercentage = _003C_003E4__this.GetDistanceToCenterPercentage(point);
						float num4;
						if (!proCamera2DTriggerZoom.SetSizeAsMultiplier)
						{
							ProCamera2D proCamera2D7 = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D7 == null || (object)proCamera2D7.GameCamera == null)
							{
								goto IL_0753;
							}
							bool orthographic = proCamera2D7.GameCamera.orthographic;
							num4 = proCamera2DTriggerZoom.TargetZoom;
							if (!orthographic)
							{
								float num5 = proCamera2DTriggerZoom.TargetZoom * 0.5f;
								float num6 = num5 * ((float)Math.PI / 180f);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B745E0");
								float initialCamDepth = proCamera2DTriggerZoom._initialCamDepth;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
								object obj = initialCamDepth & 0;
								num4 = num6 * (float)obj;
							}
						}
						else
						{
							num4 = proCamera2DTriggerZoom._startCamSize / proCamera2DTriggerZoom.TargetZoom;
						}
						float num7 = 1f - distanceToCenterPercentage;
						float num8 = distanceToCenterPercentage * proCamera2DTriggerZoom._initialCamSize;
						float num9 = num7 * num4;
						float num10 = num9 + num8;
						ProCamera2D proCamera2D8 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D8 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v24 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
							float num11 = 0f * 0.5f;
							if (!(num4 > num11) || !(num10 > proCamera2DTriggerZoom._targetCamSize))
							{
								ProCamera2D proCamera2D9 = _003C_003E4__this.ProCamera2D;
								if ((object)proCamera2D9 == null)
								{
									goto IL_0753;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rax_v35 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
								float num12 = 0f * 0.5f;
								if ((!(num12 > num4) || !(proCamera2DTriggerZoom._targetCamSize > num10)) && !proCamera2DTriggerZoom.ResetSizeOnExit)
								{
									goto IL_08c8;
								}
							}
							proCamera2DTriggerZoom._targetCamSize = num10;
							goto IL_08c8;
						}
					}
				}
			}
			goto IL_0753;
			IL_08c8:
			ProCamera2D proCamera2D10 = _003C_003E4__this.ProCamera2D;
			if ((object)proCamera2D10 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v26 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				proCamera2DTriggerZoom._previousCamSize = 0f;
				ProCamera2D proCamera2D11 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D11 != null)
				{
					bool flag3 = proCamera2D11.UpdateType != UpdateType.FixedUpdate;
					WaitForFixedUpdate waitForFixedUpdate = null;
					if (!flag3)
					{
						bool flag4 = proCamera2D11.IgnoreTimeScale;
						waitForFixedUpdate = null;
						if (!flag4)
						{
							waitForFixedUpdate = proCamera2D11._waitForFixedUpdate;
						}
					}
					_003C_003E2__current = waitForFixedUpdate;
					_003C_003E1__state = 1;
					return true;
				}
			}
			goto IL_0753;
			IL_0745:
			return false;
			IL_0753:
			throw new NullReferenceException();
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

	private sealed class _003COutsideTriggerRoutine_003Ed__18(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DTriggerZoom _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0038: Expected I4, but got I8
			//IL_022f: Expected I4, but got O
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Expected O, but got Unknown
			//IL_0147: Invalid comparison between O and F4
			ProCamera2DTriggerZoom proCamera2DTriggerZoom = _003C_003E4__this;
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					if (proCamera2DTriggerZoom._insideTrigger)
					{
						goto IL_0207;
					}
					ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D != null)
					{
						if (proCamera2DTriggerZoom._instanceID != proCamera2D.CurrentZoomTriggerID)
						{
							goto IL_0207;
						}
						ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v7 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
							float num = 0f * 0.5f;
							float num2 = num - proCamera2DTriggerZoom._targetCamSize;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
							object obj = num2 & 0;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f))
							{
								goto IL_0207;
							}
							float smoothness = ((!proCamera2DTriggerZoom.ResetSizeOnExit) ? proCamera2DTriggerZoom.ZoomSmoothness : proCamera2DTriggerZoom.ResetSizeSmoothness);
							_003C_003E4__this.UpdateScreenSize(smoothness);
							ProCamera2D proCamera2D3 = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D3 != null)
							{
								WaitForFixedUpdate waitForFixedUpdate = ((proCamera2D3.UpdateType == UpdateType.FixedUpdate && !proCamera2D3.IgnoreTimeScale) ? proCamera2D3._waitForFixedUpdate : null);
								_003C_003E2__current = waitForFixedUpdate;
								_003C_003E1__state = 1;
								return true;
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
			IL_0207:
			proCamera2DTriggerZoom._zoomVelocity = 0f;
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

	public static string TriggerName = "Zoom Trigger";

	public bool SetSizeAsMultiplier;

	public float TargetZoom;

	public float ZoomSmoothness;

	public float ExclusiveInfluencePercentage;

	public bool ResetSizeOnExit;

	public float ResetSizeSmoothness;

	private float _startCamSize;

	private float _initialCamSize;

	private float _targetCamSize;

	private float _targetCamSizeSmoothed;

	private float _previousCamSize;

	private float _zoomVelocity;

	private float _initialCamDepth;

	private void Start()
	{
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			Func<Vector3, float> vector3D = Vector3D;
			float startCamSize = default(float);
			_startCamSize = startCamSize;
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			Vector3 localPosition = proCamera2D3.LocalPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v147 @ rdi_v5 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			_initialCamDepth = localPosition.x;
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
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.CurrentZoomTriggerID = _instanceID;
		float targetCamSizeSmoothed;
		if (!ResetSizeOnExit)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v18 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			targetCamSizeSmoothed = (_targetCamSize = (_initialCamSize = 0f * 0.5f));
		}
		else
		{
			_initialCamSize = _startCamSize;
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v16 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			float targetCamSize = 0f * 0.5f;
			_targetCamSize = targetCamSize;
			ProCamera2D proCamera2D4 = base.ProCamera2D;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v17 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			targetCamSizeSmoothed = 0f * 0.5f;
		}
		_targetCamSizeSmoothed = targetCamSizeSmoothed;
		_003CInsideTriggerRoutine_003Ed__17 obj = null;
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
		if (ResetSizeOnExit)
		{
			_targetCamSize = _startCamSize;
			_003COutsideTriggerRoutine_003Ed__18 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
		}
	}

	private IEnumerator InsideTriggerRoutine()
	{
		_003CInsideTriggerRoutine_003Ed__17 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator OutsideTriggerRoutine()
	{
		_003COutsideTriggerRoutine_003Ed__18 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected unsafe void UpdateScreenSize(float smoothness)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Ref, but got Unknown
		ProCamera2D proCamera2D = base.ProCamera2D;
		float maxSpeed = default(float);
		float deltaTime = default(float);
		float targetCamSizeSmoothed = Mathf.SmoothDamp(_targetCamSizeSmoothed, _targetCamSize, ref *(float*)(this + 220), smoothness, maxSpeed, deltaTime);
		_targetCamSizeSmoothed = targetCamSizeSmoothed;
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		proCamera2D2.UpdateScreenSize(_targetCamSizeSmoothed);
	}

	public ProCamera2DTriggerZoom()
	{
		//IL_0062: Expected I, but got O
		SetSizeAsMultiplier = true;
		TargetZoom = 1.5f;
		ZoomSmoothness = 1f;
		ExclusiveInfluencePercentage = 0.25f;
		ResetSizeSmoothness = 1f;
		UpdateInterval = 0.1f;
		UseTargetsMidPoint = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
