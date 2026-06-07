using UnityEngine;

public interface ICardDataSource
{
	eItemType GetItemType();

	Sprite GetCardIcon();

	string GetLocNameString(bool isPrefix = true);

	string GetLocFlavorTextString();

	string GetLocStatsString();

	AItemSettingData GetScriptableObjectData();
}
