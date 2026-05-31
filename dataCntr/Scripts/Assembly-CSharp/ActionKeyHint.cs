using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ActionKeyHint : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDelayedUpdateUI_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ActionKeyHint _003C_003E4__this;

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
		public _003CDelayedUpdateUI_003Ed__12(int _003C_003E1__state)
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
	private InputActionReference inputActionReference;

	[Range(0f, 20f)]
	[SerializeField]
	private int selectedBinding;

	[SerializeField]
	private InputBinding.DisplayStringOptions displayStringOptions;

	[Header("Binding Info - DO NOT EDIT")]
	[SerializeField]
	private InputBinding inputBinding;

	private int bindingIndex;

	private string actionName;

	[Header("UI Fields")]
	[SerializeField]
	private Image key_image;

	[SerializeField]
	private TextMeshProUGUI keyText;

	[SerializeField]
	private TextMeshProUGUI actionText;

	[SerializeField]
	private string customText;

	[SerializeField]
	private float howManySecondsBeforeFirstUpdateUI;

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedUpdateUI_003Ed__12))]
	private IEnumerator DelayedUpdateUI()
	{
		return null;
	}

	private void OnDisable()
	{
	}

	private void OnValidate()
	{
	}

	private void GetBindingInfo()
	{
	}

	private void UpdateUI()
	{
	}

	public void CustomKey(InputAction action, string _customText)
	{
	}
}
