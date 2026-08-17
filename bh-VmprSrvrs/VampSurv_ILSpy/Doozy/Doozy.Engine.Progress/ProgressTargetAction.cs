using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Doozy.Engine.Soundy;
using Doozy.Engine.UI.Base;
using UnityEngine;

namespace Doozy.Engine.Progress;

public class ProgressTargetAction : ProgressTarget
{
	private sealed class _003CExecuteResetTrigger_003Ed__36(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProgressTargetAction _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0069: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0055: Expected I4, but got I8
			//IL_0186: Expected F4, but got I
			//IL_014d: Expected F4, but got I
			//IL_00d9: Expected O, but got I
			//IL_021f->IL0105: Incompatible stack heights: 2 vs 0
			UnityEngine.Object obj = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj2 = _003C_003E1__state - 1;
				if (!flag && (nint)obj2 != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
			}
			else
			{
				_003C_003E1__state = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Object)+30]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Object)+4C]");
					if ((nint)0 == 0)
					{
						WaitForSeconds waitForSeconds = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Object)+30]");
						waitForSeconds.m_Seconds = 0f;
						_003C_003E2__current = waitForSeconds;
						_003C_003E1__state = 2;
					}
					else
					{
						WaitForSecondsRealtime waitForSecondsRealtime = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Object)+30]");
						waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = 0f;
						waitForSecondsRealtime.m_WaitUntilTime = -1f;
						_003C_003E2__current = waitForSecondsRealtime;
						_003C_003E1__state = 1;
					}
					return true;
				}
			}
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Object)+50]");
			bool flag2 = (nint)0 == 0;
			_ = 0;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Object)+50]");
				object obj3 = 0;
				bool flag3 = MonoBehaviour.IsObjectMonoBehaviour(obj);
				bool flag4 = !flag3;
				bool flag5 = obj.m_CachedPtr == (IntPtr)0;
				IntPtr cachedPtr = obj.m_CachedPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rsi_v6+10]");
				MonoBehaviour.StopCoroutineManaged_Injected(cachedPtr, (IntPtr)0);
				_ = 0;
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

	private const float TRIGGER_VALUE_DEFAULT_VALUE = 1f;

	private const float TOLERANCE_DEFAULT_VALUE = 0.01f;

	private const bool DISABLE_TRIGGER_AFTER_ACTIVATION_DEFAULT_VALUE = true;

	private const bool RESET_ON_ENABLE_DEFAULT_VALUE = true;

	private const bool RESET_ON_DISABLE_DEFAULT_VALUE = true;

	private const bool RESET_AFTER_DELAY_DEFAULT_VALUE = true;

	private const float RESET_DELAY_DEFAULT_VALUE = 3f;

	private const bool USE_UNSCALED_TIME_DEFAULT_VALUE = true;

	public UIAction Actions;

	public CompareType CompareMethod;

	public bool DisableTriggerAfterActivation;

	public bool ResetAfterDelay;

	public float ResetDelay;

	public bool ResetOnDisable;

	public bool ResetOnEnable;

	public float TriggerValue;

	public float TriggerMinValue;

	public float TriggerMaxValue;

	public ProgressorVariable TargetVariable;

	public float Tolerance;

	public bool UseUnscaledTime;

	private bool m_actionTriggered;

	private Coroutine m_resetCoroutine;

	private Progressor m_progressor;

	private float m_updateInterval;

	private float m_nextUpdateTime;

	public bool IsActive => !m_actionTriggered;

	private void Awake()
	{
		ResetTrigger();
	}

	public override void OnEnable()
	{
		if (ResetOnEnable)
		{
			ResetTrigger();
		}
	}

	public override void OnDisable()
	{
		if (ResetOnDisable)
		{
			ResetTrigger();
		}
	}

	private void Update()
	{
		//IL_0033: Expected O, but got F4
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_004c: Invalid comparison between O and F4
		object obj = Time.deltaTime;
		object obj3 = default(object);
		object obj2 = obj3 + m_updateInterval;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)m_nextUpdateTime))
		{
			float nextUpdateTime = m_nextUpdateTime + m_updateInterval;
			m_nextUpdateTime = nextUpdateTime;
			CheckTriggerValue();
		}
	}

	public void ResetTrigger()
	{
		bool flag = m_resetCoroutine == null;
		m_actionTriggered = false;
		if (!flag)
		{
			StopCoroutine(m_resetCoroutine);
			m_resetCoroutine = null;
		}
	}

	public void TriggerActions()
	{
		//IL_00ac: Expected O, but got I4
		//IL_00df: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		UIAction actions = Actions;
		GameObject source = base.gameObject;
		if (Actions.HasSound)
		{
			SoundyController soundyController = SoundyManager.Play(actions.SoundData);
		}
		Canvas canvas = Actions.GetCanvas(source);
		Actions.ExecuteEffect(canvas);
		Actions.InvokeAnimatorEvents();
		bool flag = actions.GameEvents == null;
		object obj = 0;
		if (!flag)
		{
			List<string> gameEvents = actions.GameEvents;
			bool flag2 = gameEvents._size <= 0;
			obj = 0;
			if (!flag2)
			{
				GameEventMessage.SendEvents(gameEvents, source);
				obj = 0;
			}
		}
		if (actions.Event != null)
		{
			actions.Event.Invoke();
		}
		if (actions.Action != null)
		{
			Action<GameObject> action = actions.Action;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v227 @ rax_v28 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
		}
		if (DisableTriggerAfterActivation)
		{
			bool flag3 = !ResetAfterDelay;
			m_actionTriggered = true;
			if (!flag3)
			{
				_003CExecuteResetTrigger_003Ed__36 obj2 = null;
				obj2._003C_003E1__state = 0;
				obj2._003C_003E4__this = this;
				Coroutine resetCoroutine = StartCoroutine(obj2);
				m_resetCoroutine = resetCoroutine;
			}
		}
	}

	public override void UpdateTarget(Progressor progressor)
	{
		m_progressor = progressor;
		if (!m_actionTriggered && Actions != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 73 Invalid \"Jump target not found in method: 0x182C32140\"");
		}
	}

	private void CheckTriggerValue()
	{
		//IL_0065: Expected O, but got I4
		//IL_00c8: Expected O, but got I8
		//IL_00e2: Expected O, but got I8
		while (true)
		{
			Progressor progressor = m_progressor;
			if ((object)m_progressor == null || ((UnityEngine.Object)progressor).m_CachedPtr == (IntPtr)0)
			{
				break;
			}
			bool flag = TargetVariable == ProgressorVariable.Value;
			if (!flag)
			{
				object obj = TargetVariable - 1;
				if (!flag)
				{
					if ((nint)obj == 1)
					{
						float progress = m_progressor.Progress;
					}
				}
				else
				{
					float progress = m_progressor.Progress;
				}
			}
			CompareType compareMethod = CompareMethod;
			if (CompareMethod <= CompareType.LessThanOrEqualTo)
			{
				object obj2 = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdx_v4+2C32380+v131 @ rax_v8 (Doozy.Engine.Progress.CompareType)*4]");
				object obj3 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v184 @ rcx_v10 (should have been resolved before IL gen)");
				continue;
			}
			break;
		}
	}

	private IEnumerator ExecuteResetTrigger()
	{
		_003CExecuteResetTrigger_003Ed__36 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public ProgressTargetAction()
	{
		UIAction actions = new UIAction();
		Actions = actions;
		CompareMethod = CompareType.EqualTo;
		DisableTriggerAfterActivation = true;
		ResetDelay = 3f;
		ResetOnDisable = true;
		TriggerValue = 1f;
		TriggerMinValue = 1f;
		TriggerMaxValue = 1f;
		TargetVariable = ProgressorVariable.Progress;
		Tolerance = 0.01f;
		UseUnscaledTime = true;
		m_updateInterval = 0.1f;
	}
}
