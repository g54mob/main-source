using System;
using System.Collections.Generic;
using UnityEngine;

public class SpeechController : MonoBehaviour
{
	[Serializable]
	public class QueueElement
	{
		public string dictRef;

		public string entryRef;

		public bool useParsing;

		public float delay;

		public bool delayActivated;

		public bool shouting;

		public bool interupt;

		public bool forceColour;

		public Color color;

		public int speakingAbout;

		public int jobRef;

		public bool endsDialog;

		public bool jobHandIn;

		public int speakingToRef;

		public string interactionDialogRef;

		public AIActionPreset.AISpeechPreset dialog;

		public string dialogPreset;

		public bool isObjective;

		public bool usePointer;

		public Vector3 pointerPosition;

		public List<Objective.ObjectiveTrigger> triggers;

		public Objective.OnCompleteAction onComplete;

		public bool removePreviousObjectives;

		public string chapterString;

		public bool isSilent;

		public bool allowCrouchPrompt;

		public InterfaceControls.Icon icon;

		public int caseID;

		public bool forceBottom;

		public QueueElement(string newDictRef, string newEntryRef, bool newUseParsing, float newDelay, bool newIsShouting, bool newInterupt, bool newForceColour = false, Color newColor = default(Color), Human newSpeakingAbout = null, bool newEndsDialog = false, bool newJobHandIn = false, SideJob newJobRef = null, DialogPreset newDialogPreset = null, AIActionPreset.AISpeechPreset newDialog = null, Interactable newSpeakingTo = null, Human.InteractionDialogInstance newInteraction = null)
		{
		}

		public QueueElement(int newCaseID, string newName, bool newUseUIPointer, Vector3 newUseUIPosition, InterfaceControls.Icon newIcon, List<Objective.ObjectiveTrigger> newTriggers, Objective.OnCompleteAction newOnCompleteAction, float newDelay = 0f, bool newRemoveObjectives = false, string newChapterString = "", bool newIsSilent = false, bool newAllowCrouchPromt = false, SideJob newJobRef = null, bool newForceBottom = false, bool newUseParsing = true)
		{
		}
	}

	public enum Bark
	{
		persuit = 0,
		lostTarget = 1,
		answeringDoor = 2,
		answerDoor = 3,
		giveUpSearch = 4,
		hearsSuspicious = 5,
		seesSuspicious = 6,
		enforcerRadio = 7,
		idleSounds = 8,
		discoverTamper = 9,
		fallOffChair = 10,
		sleeping = 11,
		yawn = 12,
		hearsObject = 13,
		stench = 14,
		seeBody = 15,
		examineBody = 16,
		mourn = 17,
		enforcersKnock = 18,
		scared = 19,
		cower = 20,
		attack = 21,
		confrontMessingAround = 22,
		pickUpMisplaced = 23,
		takeDamage = 24,
		frustration = 25,
		outOfBreath = 26,
		cold = 27,
		drunkIdle = 28,
		targetDown = 29,
		restrained = 30,
		restrainedIdle = 31,
		dazed = 32,
		trespass = 33,
		threatenByItem = 34,
		threatenByCombat = 35,
		soundAlarm = 36,
		doorBlocked = 37,
		spooked = 38,
		exposedConfront = 39,
		spookConfront = 40,
		loiteringConfront = 41,
		trespassClosed = 42,
		trespassLoiter = 43,
		fameAndFortune = 44,
		rat = 45
	}

	public Actor actor;

	[NonSerialized]
	public Interactable interactable;

	public Telephone phoneLine;

	[Header("Speech")]
	public SpeechBubbleController activeSpeechBubble;

	public bool endAfterThisSpeech;

	public float lastSpeech;

	public List<QueueElement> speechQueue;

	public float speechDelay;

	public bool speechActive;

	public virtual void TriggerBark(Bark newBark)
	{
	}

	public virtual void Speak(ref List<AIActionPreset.AISpeechPreset> speechOptions, Human speakAbout = null, SideJob sideJob = null, DialogPreset dialogPreset = null, Interactable saysTo = null, Human.InteractionDialogInstance interactionInstance = null)
	{
	}

	public virtual void Speak(string ddsMessage, bool shout = false, bool interupt = false, Human speakAbout = null, SideJob sideJob = null, Human.InteractionDialogInstance interactionInstance = null)
	{
	}

	public virtual void Speak(string dictionary, string speechEntryRef, bool useParsing = false, bool shout = false, bool interupt = false, float delay = 0f, bool forceColour = false, Color color = default(Color), Human speakingAbout = null, bool endsDialog = false, bool jobHandIn = false, SideJob sideJob = null, DialogPreset dialogPreset = null, AIActionPreset.AISpeechPreset dialog = null, Interactable speakingTo = null, Human.InteractionDialogInstance interactionInstance = null)
	{
	}

	private void Update()
	{
	}

	public void SetSpeechActive(bool val)
	{
	}

	private void OnEnable()
	{
	}
}
