using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ActionController : MonoBehaviour
{
	public delegate void PlayerAction(AIActionPreset action, Interactable what, NewNode where, Actor who);

	[CompilerGenerated]
	private sealed class _003C_DialogInputBox_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DialogPreset preset;

		public ActionController _003C_003E4__this;

		public Interactable what;

		public NewNode where;

		public Actor who;

		public DialogButtonController button;

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
		public _003C_DialogInputBox_003Ed__54(int _003C_003E1__state)
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
	private sealed class _003CAddFirstPersonItemDelay_003Ed__83 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Interactable newInteractable;

		private float _003Cdelay_003E5__2;

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
		public _003CAddFirstPersonItemDelay_003Ed__83(int _003C_003E1__state)
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

	public List<AIActionPreset> allActions;

	private Dictionary<AIActionPreset, MethodInfo> actionRef;

	[NonSerialized]
	private Interactable bargeDoor;

	private static ActionController _instance;

	public static ActionController Instance => null;

	public event PlayerAction OnPlayerAction
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void ExecuteAction(AIActionPreset action, Interactable what, NewNode where, Actor who)
	{
	}

	public void TurnOnMainLight(Interactable what, NewNode where, Actor who)
	{
	}

	public void TurnOffMainLight(Interactable what, NewNode where, Actor who)
	{
	}

	public void TurnOnSecondaryLight(Interactable what, NewNode where, Actor who)
	{
	}

	public void TurnOffSecondaryLight(Interactable what, NewNode where, Actor who)
	{
	}

	public void TurnOnTV(Interactable what, NewNode where, Actor who)
	{
	}

	public void TurnOffTV(Interactable what, NewNode where, Actor who)
	{
	}

	public void PickUp(Interactable what, NewNode where, Actor who)
	{
	}

	public void PutDown(Interactable what, NewNode where, Actor who)
	{
	}

	public void Throw(Interactable what, NewNode where, Actor who)
	{
	}

	public void OpenDoor(Interactable what, NewNode where, Actor who)
	{
	}

	public void CloseDoor(Interactable what, NewNode where, Actor who)
	{
	}

	public void Open(Interactable what, NewNode where, Actor who)
	{
	}

	public void KnockOnDoor(Interactable what, NewNode where, Actor who)
	{
	}

	public void LockDoor(Interactable what, NewNode where, Actor who)
	{
	}

	public void UnlockDoor(Interactable what, NewNode where, Actor who)
	{
	}

	public void Lockpick(Interactable what, NewNode where, Actor who)
	{
	}

	public void PeekUnderDoor(Interactable what, NewNode where, Actor who)
	{
	}

	public void Hide(Interactable what, NewNode where, Actor who)
	{
	}

	public void AnswerTelephone(Interactable what, NewNode where, Actor who)
	{
	}

	public void AIHangUp(Interactable what, NewNode where, Actor who)
	{
	}

	public void Return(Interactable what, NewNode where, Actor who)
	{
	}

	public void PullPlayerFromHidingPlace(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeKey(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeBlueprints(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeMoney(Interactable what, NewNode where, Actor who)
	{
	}

	public void AIPickUpItemFromFloor(Interactable what, NewNode where, Actor who)
	{
	}

	public void AIPutBack(Interactable what, NewNode where, Actor who)
	{
	}

	public void CleanUp(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeSyncDisk(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeLockpick(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeLockpickKit(Interactable what, NewNode where, Actor who)
	{
	}

	public void Rob(Interactable what, NewNode where, Actor who)
	{
	}

	public void Inspect(Interactable what, NewNode where, Actor who)
	{
	}

	public void InspectRemove(Interactable what, NewNode where, Actor who)
	{
	}

	public void InspectComputer(Interactable what, NewNode where, Actor who)
	{
	}

	public void InspectMultiPage(Interactable what, NewNode where, Actor who)
	{
	}

	public void TalkTo(Interactable what, NewNode where, Actor who)
	{
	}

	public void Call(Interactable what, NewNode where, Actor who)
	{
	}

	public void Dial(Interactable what, NewNode where, Actor who)
	{
	}

	public void CallSomeone(Interactable what, NewNode where, Actor who)
	{
	}

	public void Say(Interactable what, NewNode where, Actor who)
	{
	}

	[IteratorStateMachine(typeof(_003C_DialogInputBox_003Ed__54))]
	public IEnumerator _DialogInputBox(Interactable what, NewNode where, Actor who, DialogButtonController button, DialogPreset preset)
	{
		return null;
	}

	private void _InvokeDialog(Interactable what, NewNode where, Actor who, DialogButtonController button, DialogPreset preset, DialogController.ForceSuccess forceSuccess, Human.InteractionDialogInstance interactionInstance = null)
	{
	}

	private void _InvokeDialog(Interactable what, NewNode where, Actor who, EvidenceWitness.DialogOption option, DialogPreset preset, DialogController.ForceSuccess forceSuccess, Human.InteractionDialogInstance interactionInstance = null)
	{
	}

	public void CrawlIntoVent(Interactable what, NewNode where, Actor who)
	{
	}

	public void UseKeypad(Interactable what, NewNode where, Actor who)
	{
	}

	public void NextPage(Interactable what, NewNode where, Actor who)
	{
	}

	public void PreviousPage(Interactable what, NewNode where, Actor who)
	{
	}

	public void SetCurrentMonth(Interactable what, NewNode where, Actor who)
	{
	}

	public void Sleep(Interactable what, NewNode where, Actor who)
	{
	}

	public void GetUp(Interactable what, NewNode where, Actor who)
	{
	}

	public void CallElevator(Interactable what, NewNode where, Actor who)
	{
	}

	public void PassTime(Interactable what, NewNode where, Actor who)
	{
	}

	public void CancelPassTime(Interactable what, NewNode where, Actor who)
	{
	}

	public void HoursMinutesToggle(Interactable what, NewNode where, Actor who)
	{
	}

	public void ActivateTimePass(Interactable what, NewNode where, Actor who)
	{
	}

	public void WatchForward(Interactable what, NewNode where, Actor who)
	{
	}

	public void WatchBack(Interactable what, NewNode where, Actor who)
	{
	}

	public void HideInstant(Interactable what, NewNode where, Actor who)
	{
	}

	public void BargeDoor(Interactable what, NewNode where, Actor who)
	{
	}

	public void BargeReturn(bool restoreTransform = false)
	{
	}

	public void UseComputer(Interactable what, NewNode where, Actor who)
	{
	}

	public void ReturnComputer(Interactable what, NewNode where, Actor who)
	{
	}

	public void TriggerAlarm(Interactable what, NewNode where, Actor who)
	{
	}

	public void Search(Interactable what, NewNode where, Actor who)
	{
	}

	public void Vomit(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakePrint(Interactable what, NewNode where, Actor who)
	{
	}

	public void NextChoice(Interactable what, NewNode where, Actor who)
	{
	}

	public void PreviousChoice(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeFirstPersonItem(Interactable what, NewNode where, Actor who)
	{
	}

	[IteratorStateMachine(typeof(_003CAddFirstPersonItemDelay_003Ed__83))]
	private IEnumerator AddFirstPersonItemDelay(Interactable newInteractable)
	{
		return null;
	}

	public void TakeFirstPersonItemUsed(Interactable what, NewNode where, Actor who)
	{
	}

	public void Buy(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeConsumable(Interactable what, NewNode where, Actor who)
	{
	}

	public void MakeCoffeeStart(Interactable what, NewNode where, Actor who)
	{
	}

	public void MakeCoffeeEnd(Interactable what, NewNode where, Actor who)
	{
	}

	public void TurnOnHob(Interactable what, NewNode where, Actor who)
	{
	}

	public void TurnOffHob(Interactable what, NewNode where, Actor who)
	{
	}

	public void TurnOnMusic(Interactable what, NewNode where, Actor who)
	{
	}

	public void TurnOffMusic(Interactable what, NewNode where, Actor who)
	{
	}

	public void PurchaseItem(Interactable what, NewNode where, Actor who)
	{
	}

	public void Consume(Interactable what, NewNode where, Actor who)
	{
	}

	public void Dispose(Interactable what, NewNode where, Actor who)
	{
	}

	public void PostJob(Interactable what, NewNode where, Actor who)
	{
	}

	public void LogOnComputer(Interactable what, NewNode where, Actor who)
	{
	}

	public void Sabotage(Interactable what, NewNode where, Actor who)
	{
	}

	public void DryOff(Interactable what, NewNode where, Actor who)
	{
	}

	public void OpenSyncDisks(Interactable what, NewNode where, Actor who)
	{
	}

	public void CallEnforcers(Interactable what, NewNode where, Actor who)
	{
	}

	public void PutUpPoliceTape(Interactable what, NewNode where, Actor who)
	{
	}

	public void RemovePoliceTape(Interactable what, NewNode where, Actor who)
	{
	}

	public void PutUpStreetCrimeScene(Interactable what, NewNode where, Actor who)
	{
	}

	public void GetCaseForm(Interactable what, NewNode where, Actor who)
	{
	}

	public void HandInCase(Interactable what, NewNode where, Actor who)
	{
	}

	public void RetirementConfirm()
	{
	}

	public void RetirementCancel()
	{
	}

	public void CheckPulse(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeActiveCodebreaker(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeActiveDoorWedge(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeActiveTracker(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeActiveFlashBomb(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeActiveIncapacitator(Interactable what, NewNode where, Actor who)
	{
	}

	public void OpenBreaker(Interactable what, NewNode where, Actor who)
	{
	}

	public void CloseBreaker(Interactable what, NewNode where, Actor who)
	{
	}

	public void ShootPoolBall(Interactable what, NewNode where, Actor who)
	{
	}

	public void ResetPoolGame(Interactable what, NewNode where, Actor who)
	{
	}

	public void PutBack(Interactable what, NewNode where, Actor who)
	{
	}

	public void Release(Interactable what, NewNode where, Actor who)
	{
	}

	public void TakeDetectiveStuff(Interactable what, NewNode where, Actor who)
	{
	}

	public void Mugging(Interactable what, NewNode where, Actor who)
	{
	}

	public void DebtCollection(Interactable what, NewNode where, Actor who)
	{
	}

	public void NextTrack(Interactable what, NewNode where, Actor who)
	{
	}

	public void PreviousTrack(Interactable what, NewNode where, Actor who)
	{
	}

	public void CancelPutDownHomeInventoryItem(Interactable what, NewNode where, Actor who)
	{
	}

	public void RotatePhysicsLeft(Interactable what, NewNode where, Actor who)
	{
	}

	public void RotatePhysicsRight(Interactable what, NewNode where, Actor who)
	{
	}

	public void Drink(Interactable what, NewNode where, Actor who)
	{
	}

	public void LoiteringConfront(Interactable what, NewNode where, Actor who)
	{
	}

	public void FameAndFortune(Interactable what, NewNode where, Actor who)
	{
	}
}
