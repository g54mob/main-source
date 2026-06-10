using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "firstperson_data", menuName = "Database/First Person Item")]
public class FirstPersonItem : SoCustomComparison
{
	public enum SpecialAction
	{
		none = 0,
		block = 1,
		handcuff = 2,
		takedown = 3,
		punch = 4,
		consumeTrue = 5,
		consumeFalse = 6,
		putDown = 7,
		attack = 8,
		raiseTrue = 9,
		raiseFalse = 10,
		takePicture = 11,
		placeCodebreaker = 12,
		placeDoorWedge = 13,
		takeOne = 14,
		placeFurniture = 15,
		cancelFurniture = 16,
		give = 17,
		placeTracker = 18,
		placeFlashbomb = 19,
		placeIncapacitator = 20,
		takeBriefcaseCash = 21,
		openBriefcaseBomb = 22,
		rotateFurnLeft = 23,
		rotateFurnRight = 24,
		putBriefcaseCash = 25,
		camFlashOn = 26,
		camFlashOff = 27,
		smoke = 28
	}

	[Serializable]
	public class FPSInteractionAction : InteractablePreset.InteractionAction
	{
		[Space(7f)]
		public AttackAvailability availability;

		public bool steamVersionOnly;

		public float attackMainSpeed;

		public PlayerTransitionPreset attackTrasition;

		[Tooltip("Minimum time between possible attacks: You might want to match this with the attack animation length")]
		public float attackDelay;

		public SpecialAction mainSpecialAction;

		public bool mainUseSpecialColour;

		public Color mainSpecialColour;

		public AudioEvent attackEvent;

		public bool useCameraJolt;

		public Vector2 joltXRange;

		public Vector2 joltYRange;

		public Vector2 joltZRange;

		public float joltAmplitude;

		public float joltSpeed;
	}

	public enum AttackAvailability
	{
		never = 0,
		always = 1,
		handcuffs = 2,
		behindCitizen = 3,
		onConsuming = 4,
		onNotConsuming = 5,
		onNotConsumingButLeftovers = 6,
		nearPutDown = 7,
		onRaised = 8,
		onNotRaised = 9,
		codebreaker = 10,
		doorWedge = 11,
		giveItem = 12,
		tracker = 13,
		onRaisedButLeftovers = 14,
		onRaisedNotFull = 15,
		whenCamFlashOn = 16,
		whenCamFlashOff = 17
	}

	[Header("Setup")]
	[Tooltip("Priority of this within the inventory hierarchy.")]
	public int slotPriority;

	[Tooltip("Should the arm models be displayed at all?")]
	public bool modelActive;

	public AnimationClip idleClip;

	public Sprite selectionIcon;

	public string summaryMsgID;

	public string triggerTutorial;

	public bool disableBracketDisplayName;

	[Header("Animation")]
	[Tooltip("How fast to play the draw animation")]
	public float drawSpeed;

	[Tooltip("How fast to play the holster animation")]
	public float holsterSpeed;

	[Header("Objects")]
	public GameObject leftHandObject;

	public GameObject rightHandObject;

	public Vector3 spawnScale;

	public bool useFoodSlotItem;

	public bool useAlternateTrashObjects;

	[EnableIf("useAlternateTrashObjects")]
	public GameObject leftHandObjectTrash;

	[EnableIf("useAlternateTrashObjects")]
	public GameObject rightHandObjectTrash;

	[ReorderableList]
	[Header("Interaction")]
	[Tooltip("Setup of actions able to be performed")]
	public List<FPSInteractionAction> actions;

	[Tooltip("How this impacts nerve levels of a citizen if drawn")]
	public float drawnNerveModifier;

	[Tooltip("Chance of bark trigger")]
	public float barkTriggerChance;

	public SpeechController.Bark bark;

	[Header("Compatibility")]
	public bool compatibleWithLockedIn;

	public bool compatibleWithHidden;

	[Header("Audio")]
	public float equipSoundDelay;

	public AudioEvent equipEvent;

	public float holsterSoundDelay;

	public AudioEvent holsterEvent;

	public AudioEvent activeLoop;

	public bool passRainParamsToActiveLoop;
}
