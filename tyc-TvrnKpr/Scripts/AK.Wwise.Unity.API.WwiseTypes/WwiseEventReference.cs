using System;

[Serializable]
public class WwiseEventReference : WwiseObjectReference
{
	public bool IsInUserDefinedSoundBank;

	private uint m_BankID;

	[NonSerialized]
	public bool IsAutoBankLoaded;

	public override WwiseObjectType WwiseObjectType => default(WwiseObjectType);

	private AkBankTypeEnum BankType => default(AkBankTypeEnum);

	protected void PostLoadAutoBank(uint bankId)
	{
	}

	public void LoadAutoBankAsync()
	{
	}

	public void LoadAutoBank()
	{
	}

	public void ReloadAutoBank()
	{
	}

	private void OnEnable()
	{
	}

	public void UnloadAutoBank()
	{
	}

	public void OnDisable()
	{
	}
}
