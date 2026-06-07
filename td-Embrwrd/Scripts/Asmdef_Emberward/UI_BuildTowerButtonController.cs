using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UI_BuildTowerButtonController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_ShowButtons_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_BuildTowerButtonController _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CCR_ShowButtons_003Ed__12(int _003C_003E1__state)
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

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private List<UI_BuildTowerButton> list_Buttons;

	[SerializeField]
	private List<UI_BuildTowerButton> list_Button_Order;

	private bool shownNotification;

	private List<ABaseTower> list_ChangePriorityTower;

	private void OnEnable()
	{
	}

	private void OnButtonClicked(UI_BuildTowerButton fromButton)
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestTriggerTowerButtonShineEffect(int index)
	{
	}

	private void OnRequestDisableBuildTowerButtonUI()
	{
	}

	private void OnShowCommonIngameUI()
	{
	}

	private void OnHideCommonIngameUI()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowButtons_003Ed__12))]
	private IEnumerator CR_ShowButtons()
	{
		return null;
	}

	private void OnChangeTowerPriority(ABaseTower tower, eTowerTargetPriority priority)
	{
	}
}
