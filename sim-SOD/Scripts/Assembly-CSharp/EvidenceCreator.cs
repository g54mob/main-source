using System.Collections.Generic;
using UnityEngine;

public class EvidenceCreator : MonoBehaviour
{
	public bool globalEntries;

	private static EvidenceCreator _instance;

	public static EvidenceCreator Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public Evidence GetDateEvidence(string date, string evidenceType = "date", string parentID = "", int owner = -1, int writer = -1, int reciever = -1)
	{
		return null;
	}

	public EvidenceTime GetTimeEvidenceRange(float time, float accuracyRange, bool limitToNow, bool round, int roundToMinutes, string evidenceType = "time", string parentID = "", int writer = -1, int receiver = -1)
	{
		return null;
	}

	public EvidenceTime GetTimeEvidence(string evidenceID)
	{
		return null;
	}

	public EvidenceTime GetTimeEvidence(float from, float to, string evidenceType = "time", string parentID = "", int writer = -1, int reciever = -1)
	{
		return null;
	}

	public Evidence CreateEvidence(string presetName, string newID, Controller newController = null, Human newOwner = null, Human newWriter = null, Human newReciever = null, Evidence newParent = null, bool forceDiscoveryOnCreate = false, List<object> passedObjects = null)
	{
		return null;
	}

	public Evidence CreateEvidence(EvidencePreset preset, string newID, Controller newController = null, Human newOwner = null, Human newWriter = null, Human newReciever = null, Evidence newParent = null, bool forceDiscoveryOnCreate = false, List<object> passedObjects = null)
	{
		return null;
	}

	public Fact CreateFact(string presetName, Evidence fromEvidenceSingular = null, Evidence toEvidenceSingular = null, List<Evidence> fromEvidence = null, List<Evidence> toEvidence = null, bool forceDiscoveryOnCreate = false, List<object> passedObjects = null, List<Evidence.DataKey> overrideFromKeys = null, List<Evidence.DataKey> overrideToKeys = null, bool isCustomFact = false)
	{
		return null;
	}

	public Fact CreateFactFromSerializedString(string str)
	{
		return null;
	}
}
