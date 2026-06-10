using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DialogController : MonoBehaviour
{
	public enum ForceSuccess
	{
		none = 0,
		success = 1,
		fail = 2
	}

	public DialogPreset payForCode;

	public InfoWindow askWindow;

	public Human askTarget;

	public List<Evidence.DataKey> askTargetKeys;

	public Dictionary<DialogPreset, MethodInfo> dialogRef;

	[NonSerialized]
	public SideJob sideJobReference;

	[NonSerialized]
	public DialogPreset preset;

	[NonSerialized]
	public Citizen cit;

	private static DialogController _instance;

	public static DialogController Instance => null;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public bool ExecuteDialog(EvidenceWitness.DialogOption dialog, Interactable saysTo, NewNode where, Actor saidBy, ForceSuccess forceSuccess = ForceSuccess.none, Human.InteractionDialogInstance interactionInstance = null)
	{
		return false;
	}

	public bool TestSpecialCaseAvailability(DialogPreset preset, Citizen saysTo, SideJob jobRef)
	{
		return false;
	}

	public void OnDialogEnd(AIActionPreset.AISpeechPreset dialog, string dialogPresetStr, Interactable saysToInteractable, Actor saidBy, int jobRef)
	{
	}

	public void BribeForCode(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void Beg(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void PayForCode(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void IssueGuestPass(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void DoYouKnowThisPerson(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void DoYouKnowThisPersonBribe1(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void DoYouKnowThisPersonBribe2(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void DoYouKnowThisPersonBribe3(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void BuySomething(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void PhoneKeypad(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void IdentifyNumber(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void LastCalled(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void Police(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void Escape(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void PayMedicalFees(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void WarnNotewriter(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void InstallNewSyncDiskSlot(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void TakeALookAround(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void TakeALookAroundBribe1(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void TakeALookAroundBribe2(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void TakeALookAroundBribe3(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void TakeALookAroundBribe4(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void Job_HouseMeet_StolenItem(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void SeenOrHeardUnusual(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void GivePassword(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void MuggingAcquiesce(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void FFAcquiesce(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void FFMistaken(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void LoanShark_AcceptLoan(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void LoanShark_Pay(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void Give(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}

	public void BuyBriefcase(Citizen saysTo, Interactable saysToInteractable, NewNode where, Actor saidBy, bool success, NewRoom roomRef, SideJob jobRef)
	{
	}
}
