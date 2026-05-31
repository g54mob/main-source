using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

public class PosTerminal : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCheckKeyStroke_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PosTerminal _003C_003E4__this;

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
		public _003CCheckKeyStroke_003Ed__32(int _003C_003E1__state)
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
	private Checkout m_Checkout;

	[SerializeField]
	private GameObject m_gamepadParent;

	[SerializeField]
	private GameObject m_PosCam;

	[SerializeField]
	private GameObject m_controllerPosCam;

	[SerializeField]
	private TMP_Text m_InputText;

	[SerializeField]
	private TMP_InputField m_gamePadInput;

	[SerializeField]
	private int m_MaxCharLimit;

	[SerializeField]
	private int m_MaxFloatingPointCharLimit;

	[SerializeField]
	private Transform m_CreditCardPlacedPosition;

	[SerializeField]
	private Transform m_CreditCardSwipeStartPosition;

	[SerializeField]
	private Transform m_CreditCardSwipeFinishPosition;

	[SerializeField]
	private Button[] m_Buttons;

	[Header("Animation")]
	[SerializeField]
	private float m_CreditCardPlacingAnimDuration;

	private float m_Total;

	private bool m_DeleteOnEdit;

	private GameObject m_CurrentCard;

	private bool m_CheckKeyInput;

	private bool m_isGamepad;

	private GamePadUIPanel m_gamePadUIPanel;

	private NumpadSystem m_numpadUIPanel;

	private bool m_isPosInteracted;

	public bool PosInteractedRemote
	{
		set
		{
		}
	}

	public bool EnablePosInteraction
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void SwitchNumpad(bool value)
	{
	}

	private void SetGamepadValues(bool value, bool isInitialize = true)
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void ControllerInitialization()
	{
	}

	private void SwitchGamePadParent(bool isGamepad)
	{
	}

	[IteratorStateMachine(typeof(_003CCheckKeyStroke_003Ed__32))]
	private IEnumerator CheckKeyStroke()
	{
		return null;
	}

	public void PrepareForCardSwipe(GameObject card)
	{
	}

	private void SwipeCard()
	{
	}

	public void AddChar(string character)
	{
	}

	public void RemoveCharacter()
	{
	}

	public void Approve()
	{
	}

	public void PlaceCreditCard(GameObject card)
	{
	}

	public void RefreshTerminal()
	{
	}

	private void OnDestroy()
	{
	}
}
