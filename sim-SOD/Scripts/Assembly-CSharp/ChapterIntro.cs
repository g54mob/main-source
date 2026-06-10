using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

public class ChapterIntro : Chapter
{
	public class IntoCharacterPick
	{
		public Human noteWriter;

		public Human kidnapper;

		public float score;
	}

	[CompilerGenerated]
	private sealed class _003CPreSimHandling_003Ed__152 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChapterIntro _003C_003E4__this;

		private float _003CprevTime_003E5__2;

		private bool _003CfindRestaurantSeat_003E5__3;

		private NewNode _003CboothSeatNode_003E5__4;

		private Interactable _003CboothSeat1_003E5__5;

		private Interactable _003CboothSeat2_003E5__6;

		private float _003CsittingTime_003E5__7;

		private float _003CpreMeetTime_003E5__8;

		private bool _003CfindMeetTime_003E5__9;

		private float _003CpreMeetingLength_003E5__10;

		private float _003CmeetingTimeLength_003E5__11;

		private float _003Cphase0LoadRatio_003E5__12;

		private bool _003CnoteWriterPathingComplete_003E5__13;

		private bool _003CnWpathsCalc_003E5__14;

		private int _003CnWcaptureCursor_003E5__15;

		private PathFinder.PathData _003CnWcapturePath_003E5__16;

		private Dictionary<NewRoom, List<NewNode>> _003CnWnodesPool_003E5__17;

		private Dictionary<NewNode, List<Interactable>> _003CnWcameraCoverage_003E5__18;

		private HashSet<NewRoom> _003CnWroutesCovered_003E5__19;

		private bool _003CnWwaitingForCapture_003E5__20;

		private float _003CnWwaitForCaptureTime_003E5__21;

		private Interactable _003CnWcam_003E5__22;

		private bool _003CkidnapperPathingComplete_003E5__23;

		private bool _003CkpathsCalc_003E5__24;

		private int _003CkcaptureCursor_003E5__25;

		private PathFinder.PathData _003CkcapturePath_003E5__26;

		private Dictionary<NewRoom, List<NewNode>> _003CknodesPool_003E5__27;

		private Dictionary<NewNode, List<Interactable>> _003CkcameraCoverage_003E5__28;

		private HashSet<NewRoom> _003CkroutesCovered_003E5__29;

		private bool _003CkwaitingForCapture_003E5__30;

		private float _003CkwaitForCaptureTime_003E5__31;

		private Interactable _003Ckcam_003E5__32;

		private float _003CnwAv_003E5__33;

		private float _003CkAv_003E5__34;

		private float _003CrecordedDistance2_003E5__35;

		private float _003CstartDistance2_003E5__36;

		private float _003Cphase1LoadRatio_003E5__37;

		private bool _003CsetupFinalPhase_003E5__38;

		private float _003CrecordedDistance_003E5__39;

		private float _003CstartDistance_003E5__40;

		private float _003Cphase2LoadRatio_003E5__41;

		private float _003CmurderTime_003E5__42;

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
		public _003CPreSimHandling_003Ed__152(int _003C_003E1__state)
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

	[Header("Character")]
	public Human noteWriter;

	public Human kidnapper;

	public Human killer;

	public Human slophouseOwner;

	[Header("Presim")]
	private GroupsController.SocialGroup meetGroup;

	private NewAIGoal meetFoodNotewriter;

	private NewAIGoal meetFoodKidnapper;

	private NewAIGoal postNote;

	private NewAIGoal kidnapperGoHome;

	private NewAIGoal kidnapperRunAway;

	private NewAIGoal returnToApartment;

	private MurderController.Murder murder;

	private MurderController.Murder murder2;

	private bool handlePreSim;

	private bool murderPreSimPass;

	public int preSimPhase;

	public float timeSinceCallObjective;

	[Header("Saved variables")]
	public int noteWriterID;

	public int kidnapperID;

	public int killerID;

	public int playersAparment;

	public int eatery;

	public int slopHouseOwnerID;

	public int slopHouseID;

	public int addressBookID;

	public float meetTime;

	public bool enforcerEventsTrigger;

	public bool findNotewriter;

	public bool notewriterDialogAdded;

	public bool lastCallPlaced;

	public float notewriterMurderTimer;

	public bool notewriterManualMurderTrigger;

	public bool notewriterMurderTriggered;

	public bool receiptSearchPromt;

	public bool addressBookSearchPrompt;

	public bool fingerprintPrompt;

	public float receiptSearchTimer;

	public float addressBookSearchTimer;

	public float printSearchTimer;

	public bool receiptSearchActivated;

	public bool addressBookSearchActivated;

	public bool printSearchActivated;

	public int killerBarID;

	public int redGumMeetID;

	public int chosenRouterAddressID;

	public int weaponSellerID;

	public bool discoveredWeaponsDealer;

	public bool completed;

	[Header("Locations")]
	public NewAddress apartment;

	private NewRoom playerBedroom;

	private NewRoom playerLounge;

	private NewRoom playerKitchen;

	private NewRoom kidnappersBedroom;

	private NewRoom noteWritersBedroom;

	public NewAddress restaurant;

	private NewRoom restaurantBackroom;

	public NewAddress killerBar;

	public NewAddress redGumMeet;

	public NewAddress chosenRouterAddress;

	public NewAddress weaponSeller;

	public NewAddress slophouse;

	[Header("Objects: Spawned")]
	private Interactable note;

	private Interactable key;

	private Interactable detectiveStuff;

	private Interactable policeBadge;

	private Interactable hairpin;

	private Interactable paperclip;

	private Interactable spareKeyDoormat;

	private Interactable workID;

	private Interactable safePasscode;

	private Interactable rewardSyncDisk;

	[NonSerialized]
	public Interactable murderWeapon;

	private Interactable kidnapperDiary;

	private Interactable envelopeWithCredits;

	private Interactable corpLetter;

	private Interactable crumpledFlyer;

	private Interactable printedVmail;

	private Interactable meetingNote;

	private Interactable noteOnNapkin;

	private Interactable tornPhotograph;

	private Interactable travelreceipt;

	private List<Interactable> playerApartmentLockpicks;

	[NonSerialized]
	public Evidence restaurantReceipt;

	public bool receiptInBin;

	private Interactable noteWriterDiary;

	public Interactable playersStorageBox;

	private Interactable policeCertificate;

	private Interactable fieldsAdvert;

	private Interactable scientificPaper;

	private Interactable playersPasscodeReminder;

	private Interactable killerPropaganda;

	private Interactable killerNotewriterDetails;

	private Interactable killerPoliceFines;

	private Interactable killerBusinessCard;

	private Interactable killerCorpSponsorship;

	private Interactable killerBarTab;

	private Interactable robItem;

	private Interactable workplaceReceipt;

	private Interactable workplaceMessageNote;

	private Interactable dinerFlyer;

	private Interactable finalNoticeBill;

	private Interactable evictionNotice;

	private Interactable flophouseWelcomeLetter;

	private Interactable flophouseSyncDiskNote;

	private Interactable flophouseJobNote;

	private Interactable flophouseSyncDisk;

	[Header("Objects: Reference")]
	private FurnitureLocation kidnappersSafe;

	private FurnitureLocation bed;

	private Interactable closestSleep;

	private Interactable closestLight;

	private NewNode.NodeAccess apartmentEntrance;

	private NewNode interiorDoorNode;

	private NewNode exteriorDoorNode;

	private Interactable playerCalendar;

	private Interactable cityDir;

	private FurnitureLocation noteWritersBed;

	private Interactable dinerCruncher;

	private NewNode.NodeAccess kidnappersEntrance;

	private NewNode kidnappersDoorNode;

	private NewDoor kidnappersDoor;

	private Interactable kidnappersCalendar;

	private Interactable kidnappersAddressBook;

	private Interactable kidnapperBin;

	private Interactable kidnapperPhone;

	private Interactable weaponsSalesLedger;

	private Interactable kidnapperRouter;

	private Interactable kidnapperRouterDoor;

	private EvidenceTime meetingTimeEvidence;

	[NonSerialized]
	public NewAIGoal layLowGoal;

	private RectTransform pointer;

	private PulseGlowController glow;

	private float nextLeadDelay;

	private bool notewriterOnCam;

	private bool kidnapperOnCam;

	public int lockpicksNeeded;

	private float endDelayTimer;

	private float passcodeNoteTimer;

	private bool triggeredPasscodeNoteHint;

	private float triggeredTutorialSkip;

	public override void OnLoaded()
	{
	}

	public override void OnGameStart()
	{
	}

	private void SetUpMission()
	{
	}

	public override StateSaveData.ChaperStateSave GetChapterSaveData()
	{
		return null;
	}

	public override void LoadStateSaveData(StateSaveData.ChaperStateSave newData)
	{
	}

	public override void OnObjectsCreated()
	{
	}

	private void SpawnPlayerApartmentClues()
	{
	}

	private void SpawnKidnapperClues()
	{
	}

	private void SpawnNotewriterClues()
	{
	}

	private void SpawnKillerClues()
	{
	}

	private void SpawnMiscClues()
	{
	}

	public void ExecutePreSim()
	{
	}

	[IteratorStateMachine(typeof(_003CPreSimHandling_003Ed__152))]
	private IEnumerator PreSimHandling()
	{
		return null;
	}

	public override void OnGameWorldLoop()
	{
	}

	public void OnReturnToApartmentOption()
	{
	}

	public void OnSkipAheadOption()
	{
	}

	public void OnCancelOption()
	{
	}

	private void ChooseInvestigatePhone()
	{
	}

	private void ChooseInvestigateCCTV()
	{
	}

	private void ChooseInvestigateVmails()
	{
	}

	private void ChooseInvestigateMurderWeapon()
	{
	}

	private void ChooseCancelLeads()
	{
	}

	public void ChangeLeadTip()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnMurderStateChange(MurderController.MurderState newState)
	{
	}

	private void PickCharacters()
	{
	}

	public void TurnOnLight(int passedVar)
	{
	}

	public void FindPartner(int passedVar)
	{
	}

	public void TelephoneRing(int passedVar)
	{
	}

	private void RingPhone()
	{
	}

	public void AnswerCall(int passedVar)
	{
	}

	public void SomethingWrong(int passedVar)
	{
	}

	public void OpenName(int passedVar)
	{
	}

	public void PinCitizen(int passedVar)
	{
	}

	public void PinNote(int passedVar)
	{
	}

	public void CloseCaseBoard1(int passedVar)
	{
	}

	public void InspectCityDirectory(int passedVar)
	{
	}

	public void AddressLookup(int passedVar)
	{
	}

	public void PinAddress(int passedVar)
	{
	}

	public void Pickup(int passedVar)
	{
	}

	public void AcquireLockpicks(int passedVar)
	{
	}

	public void UnlockBox(int passedVar)
	{
	}

	public void GatherItems(int passedVar)
	{
	}

	public void TakeKey(int passedVar)
	{
	}

	public void SetRouteOpenCaseBoard(int passedVar)
	{
	}

	public void SetRoute(int passedVar)
	{
	}

	public void CloseCaseBoard2(int passedVar)
	{
	}

	public void UnlockFrontDoor(int passedVar)
	{
	}

	public void FindNoteWriter(int passedVar)
	{
	}

	public void Knock(int passedVar)
	{
	}

	public void FindWayInside(int passedVar)
	{
	}

	public void InvestigateWriterAddress(int passedVar)
	{
	}

	private void EscapeTutorial()
	{
	}

	public void FoundBody(int passedVar)
	{
	}

	public void CrimeSceneClues(int passedVar)
	{
	}

	public void PrintsTutorial()
	{
	}

	private void InventoryPrompt()
	{
	}

	public void FindMeetingNote()
	{
	}

	public void FindAddressNote()
	{
	}

	public void FindAddressBook()
	{
	}

	public void FindWorkID()
	{
	}

	public void FindReceipt()
	{
	}

	public void FindCalendar()
	{
	}

	public void FindPrints()
	{
	}

	public void PoliceCall(int passedVar)
	{
	}

	private void StealthTutorial()
	{
	}

	private void TriggerEscapeEvents()
	{
	}

	public void CollectHandIn(int passedVar)
	{
	}

	public void ViewHandIn(int passedVar)
	{
	}

	public void ViewedHandIn(int passedVar)
	{
	}

	public void DisplayLeads(int passedVar)
	{
	}

	public void ExecuteChangeLeadsManual()
	{
	}

	public void ClearLeads(bool clearDiner, bool clearOffice, bool clearPhone, bool clearWeaponsDealer)
	{
	}

	public void InvestigateCCTV(int passedVar)
	{
	}

	public void InvestigateVmails(int passedVar)
	{
	}

	public void InvesitgatePhone(int passedVar)
	{
	}

	public void InvestigateMurderWeapon(int passedVar)
	{
	}

	public void ArrivalDiner(int passedVar)
	{
	}

	private void BreakerBox()
	{
	}

	private void BreakerTip()
	{
	}

	public void AccessBackroom(int passedVar)
	{
	}

	public void LaunchSurveillance(int passedVar)
	{
	}

	public void FoundRecords(int passedVar)
	{
	}

	private void UpdateCamReferences()
	{
	}

	public void KidnapperOnCam(int passedVar)
	{
	}

	public void OpenNotewirterEvidence(int passedVar)
	{
	}

	public void FindFlyer(int passedVar)
	{
	}

	public void ArrivalWorkplace(int passedVar)
	{
	}

	private void BreakerBoxWorkplace()
	{
	}

	private void ComputerTutorial()
	{
	}

	public void LaunchVmail(int passedVar)
	{
	}

	public void AccessKidnapperCruncher(int passedVar)
	{
	}

	public void FoundNotewriterID(int passedVar)
	{
	}

	public void WarnNotewriter()
	{
	}

	public void AccessCabinet(int passedVar)
	{
	}

	public void TraceCall(int passedVar)
	{
	}

	public void SearchCallSource(int passedVar)
	{
	}

	public void AccessOtherAddress(int passedVar)
	{
	}

	public void SearchOtherAddress(int passedVar)
	{
	}

	public void SearchFail(int passedVar)
	{
	}

	private void DudLead()
	{
	}

	public void SearchWeaponsDealer(int passedVar)
	{
	}

	public void FoundKillerID(int passedVar)
	{
	}

	public void ProveKiller(int passedVar)
	{
	}

	public void ReturnHome(int passedVar)
	{
	}

	public void VistSlophouseOwner(int passedVar)
	{
	}

	private void NobodyHome()
	{
	}

	public void GoToSlophouse(int passedVar)
	{
	}

	public void ArrivedAtSlophouse(int passedVar)
	{
	}

	public void CancelLeads(int passedVar)
	{
	}

	public void End(int passedVar)
	{
	}

	public void NotewriterLayLow()
	{
	}

	private void NotewritersLeads()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ManualTriggerNotewriterMurder()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SkipPreSim()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TriggerNotewriterLeads()
	{
	}
}
