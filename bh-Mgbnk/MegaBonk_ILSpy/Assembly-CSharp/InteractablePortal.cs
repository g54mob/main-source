using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class InteractablePortal : BaseInteractable
{
	private sealed class _003CDoLoadNextStage_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InteractablePortal _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoLoadNextStage_003Ed__6(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00c7: Expected I4, but got I8
			//IL_014f: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				GameManager instance = GameManager.Instance;
				if ((object)GameManager.Instance != null)
				{
					instance.cutscene = true;
					if ((object)MyPlayer.Instance != null)
					{
						MyPlayer.Instance.TeleportPlayerNextStage();
						WaitForSeconds waitForSeconds = new WaitForSeconds(2f);
						_003C_003E2__current = waitForSeconds;
						_003C_003E1__state = 1;
						return true;
					}
				}
				goto IL_0141;
			}
			if (_003C_003E1__state == 1)
			{
				InteractablePortal interactablePortal = _003C_003E4__this;
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_0141;
				}
				if (!interactablePortal.restarted)
				{
					if ((object)MyPlayer.Instance == null)
					{
						goto IL_0141;
					}
					if (!MyPlayer.Instance.IsDead())
					{
						MapController.LoadNextStage();
					}
				}
			}
			return false;
			IL_0141:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	private bool done;

	private bool restarted;

	private void Awake()
	{
		//IL_0101: Expected I, but got O
		Action b = OnNewRunStarted;
		Delegate obj = Delegate.Combine(MapController.A_NewRunStarted, b);
		if ((object)obj == null)
		{
			MapController.A_NewRunStarted = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			MapController.A_NewRunStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void OnDestroy()
	{
		//IL_0101: Expected I, but got O
		Action value = OnNewRunStarted;
		Delegate obj = Delegate.Remove(MapController.A_NewRunStarted, value);
		if ((object)obj == null)
		{
			MapController.A_NewRunStarted = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			MapController.A_NewRunStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnNewRunStarted()
	{
		restarted = true;
	}

	public override bool Interact()
	{
		//IL_00a5: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C61]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!done)
		{
			done = true;
			_003CDoLoadNextStage_003Ed__6 obj = new _003CDoLoadNextStage_003Ed__6(0);
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
			GameObject gameObject = base.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.tag = "Untagged";
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private IEnumerator DoLoadNextStage()
	{
		_003CDoLoadNextStage_003Ed__6 obj = new _003CDoLoadNextStage_003Ed__6(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C63]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "ENTER_PORTAL");
	}

	public InteractablePortal()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
