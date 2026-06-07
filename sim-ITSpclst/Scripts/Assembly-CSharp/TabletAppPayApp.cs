using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TabletAppPayApp : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CViewOpenCoroutine_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool closedNow;

		public GameObject view;

		public TabletAppPayApp _003C_003E4__this;

		public RectTransform obj;

		public float toY;

		public float time;

		private float _003CelapsedTime_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private Vector2 _003CtargetPos_003E5__4;

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
		public _003CViewOpenCoroutine_003Ed__30(int _003C_003E1__state)
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

	public bool isCoroutineEnded;

	[Header("Data to save!!!")]
	public string passwordPayApp;

	public float currency;

	[Header("Lock View")]
	public TextMeshProUGUI currencyTextLockView;

	[Header("Logout View")]
	public RectTransform View_LogoutRect;

	public GameObject View_Logout;

	[Header("Login")]
	public RectTransform View_LoginRect;

	public GameObject View_Login;

	public Coroutine loginCoroutine;

	public GameObject[] dotInLogin;

	public string currentLogin;

	public TextMeshProUGUI podajPinText;

	[Header("Main View")]
	public GameObject View_Main;

	public TextMeshProUGUI currencyText;

	public Transform transactionMainMenuPrefab;

	public Transform transactionMainMenuList;

	[Header("Main View - Stats")]
	public TextMeshProUGUI[] statsMainView;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void LoginView()
	{
	}

	public void LogoutView()
	{
	}

	public void CloseLogoutView()
	{
	}

	public void CloseLoginView()
	{
	}

	public void GiveNumerToLogin(int number)
	{
	}

	public void DotInLoginResetStatus()
	{
	}

	public void Logut()
	{
	}

	public void ClearMail()
	{
	}

	public void MenuRefresh()
	{
	}

	public void TransactionMenuRender(List<Transaction> transactions)
	{
	}

	[IteratorStateMachine(typeof(_003CViewOpenCoroutine_003Ed__30))]
	public IEnumerator ViewOpenCoroutine(RectTransform obj, GameObject view, float fromY, float toY, float time, bool closedNow = false)
	{
		return null;
	}
}
