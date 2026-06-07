using System;
using UnityEngine;

[Serializable]
public class CardData
{
	[SerializeField]
	public eCardType CardType;

	[SerializeField]
	public AItemSettingData data;

	[HideInInspector]
	[SerializeField]
	public bool IsFromPlayerStorage;

	[SerializeField]
	public int siblingIndexOnCreate;

	[Header("飛入時的起始位置")]
	[SerializeField]
	public Vector3 flyInOriginPosition;

	[SerializeField]
	protected eItemType itemType;

	protected bool isCorrupted;

	protected bool isBanned;

	public eItemType ItemType => default(eItemType);

	public bool IsCorrupted => false;

	public bool IsBanned => false;

	public static CardData CreateCardData(AItemSettingData data, bool isFromPlayerStorage)
	{
		return null;
	}

	public CardData Clone()
	{
		return null;
	}

	public void OverrideData(AItemSettingData newData)
	{
	}

	public virtual void ReloadDataFromResource()
	{
	}

	public void SetIsCorrupted(bool isCorrupted)
	{
	}

	public void SetIsBanned(bool isBanned)
	{
	}

	public CardData(AItemSettingData data, bool isFromPlayerStorage)
	{
	}

	public CardData()
	{
	}

	public Sprite GetCardIcon()
	{
		return null;
	}

	public ICardDataSource GetDataSource()
	{
		return null;
	}
}
