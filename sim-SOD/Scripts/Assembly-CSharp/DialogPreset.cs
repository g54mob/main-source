using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "dialog_data", menuName = "Database/Dialog Option")]
public class DialogPreset : SoCustomComparison
{
	public enum InputSetting
	{
		none = 0,
		addressPassword = 1
	}

	public enum SpecialCase
	{
		none = 0,
		backroomBribe = 1,
		publicFacingWorkplace = 2,
		working = 3,
		workingGuestPass = 4,
		callInSuspect = 5,
		talkingToJobPoster = 6,
		inputName = 7,
		lastCaller = 8,
		knowName = 9,
		lookAroundHome = 10,
		returnJobItemA = 11,
		medicalCosts = 12,
		starchPitch = 13,
		mugging = 14,
		neverDisplay = 15,
		loanSharkAccept = 16,
		loanSharkPayment = 17,
		loanSharkPaymentRefuse = 18,
		loanSharkAsk = 19,
		revealHiddenitemPhoto = 20,
		hotelBill = 21,
		rentHotelRoomCheap = 22,
		rentHotelRoomExpensive = 23,
		hotelCheckOut = 24,
		hotelRentRoom = 25,
		mustHaveRoomAtHotel = 26,
		mustBeMurdererForSuccess = 27,
		killerCleanUp = 28,
		killerCleanUpAccept = 29,
		killerCleanUpReject = 30,
		killerCleanUpSuccess = 31,
		ransomInvestigate = 32,
		kidnapperOnly = 33,
		fameAndFortune = 34
	}

	[Header("Setup")]
	public string msgID;

	[Tooltip("Is this option added to citizens at the start?")]
	public bool defaultOption;

	[Tooltip("Is this used for the telephone calling dialog?")]
	[EnableIf("defaultOption")]
	public bool telephoneCallOption;

	[Tooltip("Is this used for the hospital decision tree dialog?")]
	public bool hospitalDecisionOption;

	[Tooltip("Must have access to this key for this option to appear")]
	public Evidence.DataKey tiedToKey;

	[Tooltip("Ranking within options")]
	public int ranking;

	[Tooltip("Remove this after it's been said")]
	public bool removeAfterSaying;

	[Tooltip("Replenish after each day: Every 24 hours this will be added to every citizen if not already added")]
	[EnableIf("defaultOption")]
	public bool dailyReplenish;

	[Tooltip("This dialog will give the player the mission details")]
	public bool isJobDetails;

	[Tooltip("If false, this will only be active when the associated job is active. If true, this requirement will be ignored.")]
	public bool ignoreActiveJobRequirement;

	[Tooltip("Special cases")]
	public SpecialCase specialCase;

	[Tooltip("This option is selectable for a cost")]
	public int cost;

	[Tooltip("If ture, the above is a percentage cost of the player's total wealth")]
	public bool usePercentageCost;

	[Tooltip("If true, and the player doesn't have enough to cover the cost then use the total amount of player's wealth")]
	public bool useAllWealthIfNotEnough;

	[Tooltip("Only displayed if the current address requires a password")]
	public bool displayIfPasswordUnknown;

	[Tooltip("Player must input correct string before forcing a success or fail")]
	public InputSetting inputBox;

	[Tooltip("Display this dialog in red (illegal)")]
	public bool displayAsIllegal;

	[Tooltip("Preceeding syntax")]
	public string preceedingSyntax;

	[Tooltip("Following syntax")]
	public string followingSyntax;

	[Tooltip("Use a success test to determin the outcome response")]
	[Header("Success Test")]
	public bool useSuccessTest;

	[EnableIf("useSuccessTest")]
	[Tooltip("Requires the correct password to be successful, if there is one")]
	public bool requiresPassword;

	[EnableIf("useSuccessTest")]
	[Range(0f, 1f)]
	public float baseChance;

	[EnableIf("useSuccessTest")]
	[Tooltip("If restrained, the success change is affected this much...")]
	public float affectChanceIfRestrained;

	[Tooltip("Modify success based on below traits...")]
	[ReorderableList]
	public List<CharacterTrait.TraitPickRule> modifySuccessChanceTraits;

	[Header("Responses")]
	[ReorderableList]
	public List<AIActionPreset.AISpeechPreset> responses;

	[Tooltip("Add these as player responses following...")]
	[Header("Follow up")]
	public List<DialogPreset> followUpDialogSuccess;

	public List<DialogPreset> followUpDialogFail;

	[Tooltip("Remove these other options")]
	public List<DialogPreset> removeDialog;

	public List<DialogPreset> removeDialogOnSuccess;

	public List<DialogPreset> removeDialogOnFail;

	public int GetCost(Actor talkingTo, Actor talking = null)
	{
		return 0;
	}
}
