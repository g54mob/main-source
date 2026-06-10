using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "evidence_data", menuName = "Database/Evidence/Evidence Preset")]
public class EvidencePreset : SoCustomComparison
{
	public enum CaptureRules
	{
		building = 0,
		location = 1,
		item = 2,
		citizen = 3
	}

	public enum BelongsToSetting
	{
		self = 0,
		partner = 1,
		paramour = 2,
		boss = 3,
		doctor = 4,
		landlord = 5
	}

	public enum Subject
	{
		self = 0,
		writer = 1,
		receiver = 2,
		parent = 3,
		interactable = 4,
		interactableLocation = 5
	}

	[Serializable]
	public class EvidenceFactSetup
	{
		public FactPreset preset;

		public Subject link;

		[Tooltip("Item evidence only: Only create the belongsTo fact if this is placed in an owned position.")]
		public bool onlyIfInOwnedPosition;

		[Tooltip("Create this fact on discovery")]
		public bool createOnDiscovery;

		[Tooltip("Force discovery of this fact when this is created")]
		public bool forceDiscoveryOnCreation;

		[Tooltip("When creating the above, switch the from (this) and to (link) evidence.")]
		public bool switchFindingFactToFrom;
	}

	[Serializable]
	public class FactLinkSetup
	{
		public FactLinkSubject subject;

		public string factDictionary;

		public Evidence.DataKey key;

		public bool discovery;
	}

	[Serializable]
	public class DataKeyAutomaticTies
	{
		public Evidence.DataKey mainKey;

		public List<Evidence.DataKey> mergeAtStart;
	}

	public enum FactLinkSubject
	{
		writer = 0,
		receiver = 1
	}

	[Serializable]
	public class MergeKeysSetup
	{
		public Subject link;

		public List<Evidence.DataKey> mergeKeys;
	}

	[Serializable]
	public class DiscoveryApplication
	{
		public Subject link;

		public Evidence.Discovery applyDiscoveryTrigger;
	}

	public enum PinnedStyle
	{
		polaroid = 0,
		stickNote = 1
	}

	[Header("Setup")]
	[Tooltip("Spawn this subclass. If left empty it will use the base class.")]
	public string subClass;

	[Tooltip("The window style this evidence should use.")]
	public WindowStylePreset windowStyle;

	[Tooltip("Should this evidence use data key instances? If false, all keys will be tied together on creation.")]
	public bool useDataKeys;

	[EnableIf("useDataKeys")]
	public List<DataKeyControls.DataKeySettings> validKeys;

	[Tooltip("The below keys act as if merged when retrieved")]
	[EnableIf("useDataKeys")]
	public List<DataKeyAutomaticTies> passiveTies;

	[EnableIf("useDataKeys")]
	public bool notifyOfTies;

	[Tooltip("Item Evidence class only: Should the person who this belongs to be featured in the name?")]
	public bool useBelongsToInName;

	[Tooltip("Does only one instance of this evidence exist?")]
	public bool isSingleton;

	[Tooltip("If true this does appear in history when inspected")]
	public bool disableHistory;

	[Tooltip("Allow this evidence to be given custom names")]
	public bool allowCustomNames;

	[Tooltip("If true this will be marked as discovered on any interaction, as opposed to just world interactions")]
	public bool markAsDiscoveredOnAnyInteraction;

	[Tooltip("If true this will always and only be able to be a world interaction")]
	public bool forceWorldInteraction;

	[Tooltip("Use window focus mode (black screen behind the window)")]
	public bool useWindowFocusMode;

	[Tooltip("The icon for this evidence")]
	[Header("Graphics")]
	public Sprite iconSpriteLarge;

	public Texture2D defaultNullImage;

	[Tooltip("Take in-game shot of this item for use in evidence (only used if photo key present)")]
	public bool useInGamePhoto;

	[Tooltip("Instead of 'this' use a photo of the person this belongs to")]
	public bool useWriter;

	[EnableIf("useInGamePhoto")]
	public Vector3 relativeCamPhotoPos;

	[EnableIf("useInGamePhoto")]
	public Vector3 relativeCamPhotoEuler;

	[EnableIf("useInGamePhoto")]
	public CaptureRules captureRules;

	[EnableIf("useInGamePhoto")]
	public bool changeTimeOfDay;

	[EnableIf("useInGamePhoto")]
	public float captureTimeOfDay;

	public bool useCaptureLight;

	[Tooltip("Use image from a CCTV capture")]
	[DisableIf("useInGamePhoto")]
	public bool useSurveillanceCapture;

	[BoxGroup("Facts")]
	[Tooltip("Item evidence only: The 'belongs to' reference is set to this relation.")]
	public BelongsToSetting itemOwner;

	[BoxGroup("Facts")]
	[Tooltip("Item evidence only: The 'belongs to' reference is set to this relation.")]
	public BelongsToSetting itemWriter;

	[Tooltip("Item evidence only: The 'subject' reference is set to this relation.")]
	[BoxGroup("Facts")]
	public BelongsToSetting itemReceiver;

	[BoxGroup("Facts")]
	[Tooltip("Automatically create these facts...")]
	[ReorderableList]
	public List<EvidenceFactSetup> factSetup;

	[BoxGroup("Facts")]
	[Tooltip("Automatically add a link to these facts (doesn't have to feature this evidence)")]
	[ReorderableList]
	public List<FactLinkSetup> addFactLinks;

	[Tooltip("Discover this evidence when it is created.")]
	[BoxGroup("Discovery")]
	public bool discoverOnCreate;

	[BoxGroup("Discovery")]
	[Tooltip("On discovery, merge these keys (this evidence)")]
	[ReorderableList]
	public List<MergeKeysSetup> keyMergeOnDiscovery;

	[Tooltip("Conditions for discovery of this evidence (ANY of these)")]
	[ReorderableList]
	[BoxGroup("Discovery")]
	public List<Evidence.Discovery> discoveryTriggers;

	[BoxGroup("Discovery")]
	[Tooltip("Apply these discoveries on discovery")]
	[ReorderableList]
	public List<DiscoveryApplication> applicationOnDiscover;

	[Header("Content")]
	[Tooltip("Use this ID for content (do the rest in DDS editor)")]
	public string ddsDocumentID;

	[Tooltip("Some matching types below will only match to-from a match parent.")]
	[Header("Matching")]
	public bool isMatchParent;

	[Tooltip("List of match types for auto-creating matches")]
	public List<MatchPreset> matchTypes;

	[Header("Evidence Folder")]
	public bool enableSummary;

	public bool enableFacts;

	[Tooltip("The type of pinned evidence style")]
	public PinnedStyle pinnedStyle;

	[Tooltip("Colour multiplier for pinned evidence background")]
	public Color pinnedBackgroundColour;

	public List<Evidence.DataKey> GetValidProfileKeys()
	{
		return null;
	}

	public List<Evidence.DataKey> GetUniqueProfileKeys()
	{
		return null;
	}

	public bool IsKeyValid(Evidence.DataKey key, out bool countTowardsProfile)
	{
		countTowardsProfile = default(bool);
		return false;
	}

	public bool IsKeyUnique(Evidence.DataKey key)
	{
		return false;
	}

	public int GetProfileKeyCount(List<Evidence.DataKey> keyList)
	{
		return 0;
	}
}
