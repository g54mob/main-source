using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FaskoManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CconnectVPNCheckOne_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FaskoManager _003C_003E4__this;

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
		public _003CconnectVPNCheckOne_003Ed__24(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CconnectVPNCheckTwo_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FaskoManager _003C_003E4__this;

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
		public _003CconnectVPNCheckTwo_003Ed__25(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CdisconnectVPN_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FaskoManager _003C_003E4__this;

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
		public _003CdisconnectVPN_003Ed__23(int _003C_003E1__state)
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

	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	public NotifiSystemManager notifiSystemManager;

	[Header("Authorization")]
	public TabletAppAutentication tabletAppAutentication;

	public GameObject Authorization;

	public int randomAuthorizationNumber;

	public TextMeshProUGUI RandomNumberText;

	[Header("Animation Elements")]
	public Sprite[] statusSprite;

	public TextMeshProUGUI statusText;

	public TextMeshProUGUI buttonStatusConnect;

	public Image statusImage;

	public bool VpnConnected;

	public GameObject buttonConnect;

	public int animationStart;

	[Header("Karta Sieciowa")]
	public ComputerNetwork computerNetwork;

	[HideInInspector]
	public bool isOpen;

	private Coroutine coroutineConnectVPN;

	private void Start()
	{
	}

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void CheckStatus()
	{
	}

	public void CloseAnimation()
	{
	}

	public void ConnectButton()
	{
	}

	[IteratorStateMachine(typeof(_003CdisconnectVPN_003Ed__23))]
	private IEnumerator disconnectVPN()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CconnectVPNCheckOne_003Ed__24))]
	private IEnumerator connectVPNCheckOne()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CconnectVPNCheckTwo_003Ed__25))]
	public IEnumerator connectVPNCheckTwo()
	{
		return null;
	}

	public void CloseAuthorization()
	{
	}
}
