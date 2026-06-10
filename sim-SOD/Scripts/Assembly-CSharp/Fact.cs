using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Fact : CaseComponent
{
	public delegate void ConnectingEvidenceChangeDataKey();

	public delegate void IsSeen();

	[NonSerialized]
	public FactPreset preset;

	public List<Evidence> fromEvidence;

	public List<Evidence> toEvidence;

	public List<Evidence.DataKey> fromDataKeys;

	public List<Evidence.DataKey> toDataKeys;

	public bool isSeen;

	public bool isCustom;

	public string customName;

	public event ConnectingEvidenceChangeDataKey OnConnectingEvidenceChangeDataKey
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

	public event IsSeen OnSeen
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

	public Fact(FactPreset newPreset, List<Evidence> newFromEvidence, List<Evidence> newToEvidence, List<object> newPassedObjects, List<Evidence.DataKey> overrideFromKeys, List<Evidence.DataKey> overrideToKeys, bool isCustomFact)
	{
	}

	public override string GetIdentifier()
	{
		return null;
	}

	public override string GenerateName()
	{
		return null;
	}

	public virtual void ConnectFact()
	{
	}

	public override void OnDiscovery()
	{
	}

	public void SetSeen()
	{
	}

	public virtual void OnConnectedEvidenceDiscovery(CaseComponent discovered)
	{
	}

	public virtual string GetName(Evidence.FactLink specificLink = null)
	{
		return null;
	}

	public Evidence GetOther(Evidence ev)
	{
		return null;
	}

	public List<Evidence> GetOther(List<Evidence> ev)
	{
		return null;
	}

	public void OnConnectionsChangedDataKeys()
	{
	}

	public string GetSerializedString()
	{
		return null;
	}

	public virtual void SetCustomName(string str)
	{
	}
}
