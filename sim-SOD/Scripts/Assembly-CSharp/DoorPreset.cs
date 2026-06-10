using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "door_data", menuName = "Database/Door Preset")]
public class DoorPreset : SoCustomComparison
{
	public enum LockType
	{
		none = 0,
		key = 1,
		keypad = 2
	}

	[Serializable]
	public class DoorSign
	{
		public List<GameObject> signagePool;

		public List<RoomConfiguration> ifEntranceToRoom;

		public bool placeIfFromPublicArea;

		public bool placeIfFromOutside;

		public bool placeIfFromInside;

		public bool onlyPlaceIfInhabited;
	}

	public enum ClosingBehaviour
	{
		nothing = 0,
		closeOnCull = 1,
		closeOnDespawn = 2
	}

	[Header("Visuals")]
	public GameObject doorModel;

	public InteractablePreset objectPreset;

	public GameObject handleModel;

	public InteractablePreset handlePreset;

	public Vector3 handleOffset;

	public bool isTransparent;

	public Material nonRainGlassMaterial;

	[Header("Signs")]
	public Vector3 doorSignOffset;

	[ReorderableList]
	public List<DoorSign> doorSigns;

	[Header("Decor Settings")]
	public bool inheritColouringFromDecor;

	[Tooltip("If true the same material colours will be shared over all instances of this furniture for the room")]
	public FurniturePreset.ShareColours shareColours;

	public List<MaterialGroupPreset.MaterialVariation> variations;

	[Tooltip("How fast the door opens and closes")]
	[Header("Behaviour")]
	public float doorOpenSpeed;

	[Tooltip("The maximum amount this door can open")]
	public float openAngle;

	[Tooltip("Can the player peek underneath this door?")]
	public bool canPeakUnderneath;

	[Tooltip("If open, close the door depending on this behaviour")]
	public ClosingBehaviour closeBehaviour;

	[Header("Lock")]
	public LockType lockType;

	[Tooltip("If the above is set to something other than none or key, then setup this lock interactable...")]
	public InteractablePreset lockInteractable;

	public Vector3 lockOffsetFront;

	public Vector3 lockOffsetRear;

	[Tooltip("The lock is armed when the door movement is closed")]
	public bool armLockOnClose;

	[Tooltip("The door strength range")]
	[MinMaxSlider(0f, 1f)]
	public Vector2 doorStrengthRange;

	[Tooltip("The lock strength range")]
	[MinMaxSlider(0f, 1f)]
	public Vector2 lockStrengthRange;

	[Header("Audio")]
	public AudioEvent audioOpen;

	public AudioEvent audioClose;

	public AudioEvent audioCloseAction;

	public AudioEvent audioLock;

	public AudioEvent audioUnlock;

	public AudioEvent audioLockedEntryAttempt;

	public AudioEvent audioKnockLight;

	public AudioEvent audioKnockMed;

	public AudioEvent audioKnockHeavy;

	public AudioEvent doorBargeContact;

	public AudioEvent doorBargeBreak;
}
