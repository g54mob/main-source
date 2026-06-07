using System;
using UnityEngine;

[Serializable]
public class DialogueConditionFlotsamSalvaged : IDialogueCondition
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Flotsam Salvaged";

	[SerializeField]
	private ItemProperties _itemProperties;

	[SerializeField]
	private int _requiredCount = 1;

	bool IDialogueCondition.IsMet()
	{
		if (_itemProperties == null)
		{
			Debug.LogError("No item was specified for DialogueConditionFlotsamSalvaged!");
			return true;
		}
		return GameManager.GameStatsManager.GetSalvagedMarkerItemsCount(_itemProperties) >= _requiredCount;
	}

	public override string ToString()
	{
		string arg = ((_itemProperties != null) ? _itemProperties.LocalizedName : "NO ITEM SPECIFIED");
		return $"Flotsam Salvaged: {arg} ({_requiredCount}+)";
	}
}
