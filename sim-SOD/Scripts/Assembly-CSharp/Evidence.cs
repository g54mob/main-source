using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Evidence : CaseComponent
{
	public enum Discovery
	{
		livesAt = 0,
		partnerDiscovery = 1,
		jobDiscovery = 2,
		purchasedAt = 3,
		phoneLocation = 4,
		paramourDiscovery = 5,
		phonePersonal = 6,
		foundAt = 7,
		foundOn = 8,
		addressBookDiscovery = 9,
		relationshipDiscovery = 10,
		jobHours = 11,
		diaryDiscovery = 12,
		jobDiscoveryPhoto = 13,
		dateOfBirth = 14,
		timeOfDeath = 15,
		referenceDiscovery = 16,
		postedByDiscovery = 17,
		discoverCallFrom = 18,
		discoverCallTo = 19
	}

	public enum DataKey
	{
		name = 0,
		photo = 1,
		fingerprints = 2,
		code = 3,
		voice = 4,
		height = 5,
		build = 6,
		age = 7,
		sex = 8,
		hair = 9,
		eyes = 10,
		bloodType = 11,
		shoeSize = 12,
		facialHair = 13,
		address = 14,
		work = 15,
		workHours = 16,
		jobTitle = 17,
		shoeSizeEstimate = 18,
		glasses = 19,
		dateOfBirth = 20,
		salary = 21,
		randomInterest = 22,
		randomSocialClub = 23,
		ageGroup = 24,
		firstNameInitial = 25,
		partnerFirstName = 26,
		partnerJobTitle = 27,
		partnerSocialClub = 28,
		randomAffliction = 29,
		heightEstimate = 30,
		handwriting = 31,
		livesOnFloor = 32,
		telephoneNumber = 33,
		livesInBuilding = 34,
		worksInBuilding = 35,
		location = 36,
		blueprints = 37,
		firstName = 38,
		surname = 39,
		initialedName = 40,
		initials = 41,
		purpose = 42
	}

	[Serializable]
	public class FactLink
	{
		public Fact fact;

		public Evidence thisEvidence;

		public List<DataKey> thisKeys;

		public List<Evidence> destinationEvidence;

		public List<DataKey> destinationKeys;

		public bool thisIsTheFromEvidence;
	}

	[Serializable]
	public class CustomName
	{
		public DataKey key;

		public string name;
	}

	public delegate void OnDiscover(Evidence disc);

	public delegate void NewParent();

	public delegate void NewChild();

	public delegate void RemChild();

	public delegate void DiscoverChild();

	public delegate void ConnectFact();

	public delegate void DiscoverConnectedFact();

	public delegate void DataKeyChange();

	public delegate void DiscoveryChanged(Discovery newDisc);

	public delegate void MatchTypeAdded();

	public delegate void AnyPinnedChange();

	public delegate void NoteAdded();

	public string evID;

	public bool forceSave;

	[NonSerialized]
	public Interactable interactable;

	public InteractablePreset interactablePreset;

	public EvidencePreset preset;

	public Sprite imageOverride;

	[NonSerialized]
	public Evidence parent;

	public Human writer;

	public Human reciever;

	public Human belongsTo;

	public string overrideDDS;

	public Controller controller;

	public MetaObject meta;

	[NonSerialized]
	public List<Evidence> children;

	public Dictionary<DataKey, List<DataKey>> keyTies;

	public List<CustomName> customNames;

	public Dictionary<DataKey, List<FactLink>> factDictionary;

	[NonSerialized]
	public List<FactLink> allFacts;

	public List<Discovery> discoveryProgress;

	public List<MatchPreset> matches;

	public Dictionary<DataKey, string> notes;

	private Action OrderCheck;

	public event OnDiscover OnDiscovered
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

	public event NewParent OnNewParent
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

	public event NewChild OnNewChild
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

	public event RemChild OnRemoveChild
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

	public event DiscoverChild OnDiscoverChild
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

	public event ConnectFact OnConnectFact
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

	public event DiscoverConnectedFact OnDiscoverConnectedFact
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

	public event DataKeyChange OnDataKeyChange
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

	public event DiscoveryChanged OnDiscoveryChanged
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

	public event MatchTypeAdded OnMatchTypeAdded
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

	public event AnyPinnedChange OnAnyPinnedChange
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

	public event NoteAdded OnNoteAdded
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

	public Evidence(EvidencePreset newPreset, string newID, Controller newController, List<object> newPassedObjects)
	{
	}

	public override string GenerateName()
	{
		return null;
	}

	public virtual void Compile()
	{
	}

	public override string GetIdentifier()
	{
		return null;
	}

	public PinnedItemController GetPinned(List<DataKey> inputKeys)
	{
		return null;
	}

	public override string FoundAtName()
	{
		return null;
	}

	private void SetupKeyTies()
	{
	}

	public virtual void BuildDataSources()
	{
	}

	public void SetParent(Evidence newParent)
	{
	}

	public void SetBelongsTo(Human newOwner)
	{
	}

	public void SetWriter(Human newWriter)
	{
	}

	public void SetReciever(Human newReciever)
	{
	}

	public void SetOverrideDDS(string newTreeID)
	{
	}

	private void AddChild(Evidence newEv)
	{
	}

	private void RemoveChild(Evidence newEv)
	{
	}

	public void OnChildEvidenceDiscovery()
	{
	}

	public void AddFactLink(Fact newFact, List<DataKey> newKey, bool thisIsTheFromEvidence)
	{
	}

	public void AddFactLink(Fact newFact, DataKey newKey, bool thisIsTheFromEvidence)
	{
	}

	private void AddFactLinkExe(Fact newFact, DataKey newKey, bool thisIsTheFromEvidence)
	{
	}

	public void RemoveFactLink(Fact removeThis)
	{
	}

	public virtual void OnConnectedFactDiscovery(CaseComponent discovered)
	{
	}

	public void AddMatch(MatchPreset newMatch)
	{
	}

	public override void OnDiscovery()
	{
	}

	public virtual void AutoCreateFacts(bool discovery)
	{
	}

	public Evidence GetLinkForFact(EvidencePreset.Subject subject)
	{
		return null;
	}

	public virtual void MergeDataKeys(DataKey keyOne, DataKey keyTwo)
	{
	}

	public virtual void NamePhotoMerge()
	{
	}

	public virtual void OnDataKeyMerge(DataKey keyOne, DataKey keyTwo)
	{
	}

	public List<DataKey> GetTiedKeys(DataKey inputKey)
	{
		return null;
	}

	public virtual List<DataKey> GetTiedKeys(List<DataKey> inputKeys)
	{
		return null;
	}

	public List<FactLink> GetFactsForDataKey(DataKey inputKey)
	{
		return null;
	}

	public List<FactLink> GetFactsForDataKey(List<DataKey> inputKeys)
	{
		return null;
	}

	public string GetNameForDataKey(DataKey inputKey)
	{
		return null;
	}

	public virtual string GetNameForDataKey(List<DataKey> inputKeys)
	{
		return null;
	}

	public void AddOrSetCustomName(DataKey dk, string newCustomName)
	{
	}

	public void AddOrSetCustomName(List<DataKey> dk, string newCustomName)
	{
	}

	public void AddDiscovery(Discovery disc)
	{
	}

	public virtual void UpdateDiscoveries()
	{
	}

	public virtual Sprite GetIcon()
	{
		return null;
	}

	public Texture2D GetPhoto(List<DataKey> keys)
	{
		return null;
	}

	public virtual string GetSummary(List<DataKey> keys)
	{
		return null;
	}

	public void SetNote(List<DataKey> keys, string str)
	{
	}

	public virtual string GetNote(List<DataKey> keys)
	{
		return null;
	}

	public virtual string GetNoteComposed(List<DataKey> keys, bool useLinks = true)
	{
		return null;
	}

	public void OnPinnedChange()
	{
	}

	public virtual void OnPlayerLookedAtWithinReadingRange()
	{
	}

	public void SetImageOverride(Sprite newSprite)
	{
	}

	public void InstancingCheck()
	{
	}

	public void SetForceSave(bool val)
	{
	}

	public List<DataKey> GetMergedDiscoveryLinkKeysFor(Evidence linkEvidence, DataKey mustFeature)
	{
		return null;
	}
}
