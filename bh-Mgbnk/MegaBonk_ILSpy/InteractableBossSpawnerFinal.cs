using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class InteractableBossSpawnerFinal : BaseInteractable
{
	private sealed class _003CDoLoadNextStage_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoLoadNextStage_003Ed__4(int _003C_003E1__state)
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
			//IL_00bd: Expected I4, but got I8
			//IL_0101: Expected I4, but got O
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
				goto IL_00f3;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)MyPlayer.Instance == null)
				{
					goto IL_00f3;
				}
				if (!MyPlayer.Instance.IsDead())
				{
					MapController.LoadFinalStage();
				}
			}
			return false;
			IL_00f3:
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

	public GameObject preventObjectsSpawningHere;

	private new void Start()
	{
		preventObjectsSpawningHere.SetActive(value: false);
	}

	public override bool Interact()
	{
		//IL_0092: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C34]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!done)
		{
			done = true;
			_003CDoLoadNextStage_003Ed__4 obj = new _003CDoLoadNextStage_003Ed__4(0);
			obj._003C_003E1__state = 0;
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
		_003CDoLoadNextStage_003Ed__4 obj = new _003CDoLoadNextStage_003Ed__4(0);
		obj._003C_003E1__state = 0;
		return obj;
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C36]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "FINAL_BOSS");
	}

	public InteractableBossSpawnerFinal()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
