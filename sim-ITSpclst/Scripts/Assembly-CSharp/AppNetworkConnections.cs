using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppNetworkConnections : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CChceckingNetworkSometimes_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppNetworkConnections _003C_003E4__this;

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
		public _003CChceckingNetworkSometimes_003Ed__11(int _003C_003E1__state)
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

	[Header("Component")]
	public AppBase AppBase;

	public ComputerNetwork computerNetwork;

	[HideInInspector]
	public bool isOpen;

	public Sprite[] ethImage;

	[SerializeField]
	private Image statusETH;

	[SerializeField]
	private TextMeshProUGUI descriptionETH;

	private Coroutine ChceckingNetworkSometimes_Coroutine;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	[IteratorStateMachine(typeof(_003CChceckingNetworkSometimes_003Ed__11))]
	private IEnumerator ChceckingNetworkSometimes()
	{
		return null;
	}
}
