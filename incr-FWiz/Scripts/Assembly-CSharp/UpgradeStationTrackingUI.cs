using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class UpgradeStationTrackingUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COnChangeAnimation_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UpgradeStationTrackingUI _003C_003E4__this;

		private DefaultActionsHandler _003CplayerActions_003E5__2;

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
		public _003COnChangeAnimation_003Ed__14(int _003C_003E1__state)
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
	private Transform _upgradeIconImageTransform;

	[SerializeField]
	private Image _upgradeIconImage;

	[SerializeField]
	private Transform _costGridTransform;

	[SerializeField]
	private StandingPaymentUI _paymentUI;

	[SerializeField]
	private Transform _titleTransform;

	[SerializeField]
	private TypeOutText _titleText;

	[SerializeField]
	public LocalizedString _noUpgradeSelectedLocaleString;

	private Coroutine _titleCoroutine;

	private UpgradeAttempt _upgradeAttempt;

	public List<GameObject> ShowOnActive;

	public void Initiate(UpgradeAttempt upgradeAttempt)
	{
	}

	public void Set(UpgradeAttempt upgradeAttempt)
	{
	}

	public void OnAllUpgradesCompleted()
	{
	}

	public void Clear()
	{
	}

	[IteratorStateMachine(typeof(_003COnChangeAnimation_003Ed__14))]
	private IEnumerator OnChangeAnimation()
	{
		return null;
	}
}
