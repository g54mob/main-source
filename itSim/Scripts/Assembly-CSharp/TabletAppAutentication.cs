using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TabletAppAutentication : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCheckSendDataPrograss_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletAppAutentication _003C_003E4__this;

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
		public _003CCheckSendDataPrograss_003Ed__19(int _003C_003E1__state)
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

	[Header("Window Components")]
	public TabletAppAnimationWindow tabletAppAnimationWindow;

	public TabletDeviceWiFiAdapter tabletDeviceWiFiAdapter;

	[SerializeField]
	[Header("Object")]
	private GameObject AboutAccess;

	[SerializeField]
	private TextMeshProUGUI sixCodeText;

	[SerializeField]
	private TextMeshProUGUI lastLoginSuccessfulText;

	[SerializeField]
	private TextMeshProUGUI lastLoginDenied;

	[HideInInspector]
	public int first_random_int;

	[HideInInspector]
	public int secound_random_int;

	public string dateLastLoginSuccessful;

	public string dateLastLoginDenied;

	[Header("UI")]
	public RectTransform AskedCanvas;

	public TMP_InputField AskedInputNumber;

	public TMP_Text AskedYesButton;

	public TabletAppAutenticationQueue queue;

	private Coroutine corCheckSendDataPrograss;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void AskedUpdateInputNumber()
	{
	}

	public void SetAnswer(int number, Action actCorrect, Action actIncorrect, Action actCaneled)
	{
	}

	[IteratorStateMachine(typeof(_003CCheckSendDataPrograss_003Ed__19))]
	private IEnumerator CheckSendDataPrograss()
	{
		return null;
	}

	public void ButtonAskedYes()
	{
	}

	public string SetLastLogin()
	{
		return null;
	}

	public void ButtonAskedNo()
	{
	}

	public void AboutAccount()
	{
	}

	public void ExitAboutAccount()
	{
	}
}
