using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScaleTutorialManager : NoktaSingleton<ScaleTutorialManager>
{
	[CompilerGenerated]
	private sealed class _003CEndTutorialDelayed_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ScaleTutorialManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CEndTutorialDelayed_003Ed__22(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private ScaleStepMission m_Mission;

	[SerializeField]
	private TutorialObjectiveDisplay m_ObjectiveDisplay;

	[SerializeField]
	private TutorialObjectiveData m_ScaleWaitCustomerObjective;

	[SerializeField]
	private TutorialObjectiveData m_ScaleInteractionObjective;

	[SerializeField]
	private TutorialObjectiveData m_ScaleEnterCodeObjective;

	[SerializeField]
	private TutorialObjectiveData m_ScaleApplyBarcodeObjective;

	private bool m_EndQueued;

	private MissionSystem m_MissionSystem;

	public bool HasStarted { get; private set; }

	public ICustomerHelperControllable TemporaryControllable { get; private set; }

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	public void BeginTutorial()
	{
	}

	public void CheckIds()
	{
	}

	public void EndTutorial()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CEndTutorialDelayed_003Ed__22))]
	private IEnumerator EndTutorialDelayed()
	{
		return null;
	}
}
