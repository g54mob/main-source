using System;
using MLCN_Localization;

[Serializable]
public class AnomalyEffect
{
	public enum EffectType
	{
		Neutral = -1,
		Positive = 0,
		Negative = 1
	}

	public bool isActive;

	public EffectType effectType;

	public int index;

	public string effectName;

	public string effectMsg;

	public void SetName(string name)
	{
		effectName = LocalizationManager.GetLocalizedString(name, LocalizationDataTable.Tables.UI);
	}

	public void SetMessage(string positiveMessage, string negativeMessage, string neutralMessage = "")
	{
		if (effectType == EffectType.Positive)
		{
			effectMsg = LocalizationManager.GetLocalizedString(positiveMessage, LocalizationDataTable.Tables.UI);
		}
		else if (effectType == EffectType.Negative)
		{
			effectMsg = LocalizationManager.GetLocalizedString(negativeMessage, LocalizationDataTable.Tables.UI);
		}
		else
		{
			effectMsg = LocalizationManager.GetLocalizedString(neutralMessage, LocalizationDataTable.Tables.UI);
		}
	}

	public Action OnEffectEvent()
	{
		return OnEffectAction;
	}

	public Action OnReverseEffect()
	{
		return OnEffectReverse;
	}

	protected virtual void OnEffectAction()
	{
	}

	protected virtual void OnEffectReverse()
	{
	}
}
