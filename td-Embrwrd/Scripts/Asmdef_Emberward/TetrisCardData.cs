using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TetrisCardData : CardData
{
	[SerializeField]
	private PanelSettingData tetrisSettingData;

	[SerializeField]
	private int seed;

	[SerializeField]
	private List<eItemType> list_Runes;

	[SerializeField]
	private eItemType specialRune;

	public int Seed => 0;

	public eItemType SpecialRune => default(eItemType);

	public new static TetrisCardData CreateCardData(AItemSettingData data, bool isFromPlayerStorage)
	{
		return null;
	}

	public new TetrisCardData Clone()
	{
		return null;
	}

	public TetrisCardData(AItemSettingData data, bool isFromPlayerStorage)
		: base(null, isFromPlayerStorage: false)
	{
	}

	public override void ReloadDataFromResource()
	{
	}

	public void Initialize(int seed)
	{
	}

	public bool HasAnyRuneOrSpecialRune()
	{
		return false;
	}

	public void AddRune(eItemType rune)
	{
	}

	public void ReplaceRune(eItemType rune, int index)
	{
	}

	public List<eItemType> GetRunes()
	{
		return null;
	}

	public bool HasRune(eItemType rune)
	{
		return false;
	}

	public bool HasEmptySocket()
	{
		return false;
	}

	public int GetEmptySocketCount()
	{
		return 0;
	}

	public eItemType GetRune(int index)
	{
		return default(eItemType);
	}

	public int GetNextEmptySocketIndex()
	{
		return 0;
	}

	public int GetRuneCount()
	{
		return 0;
	}

	public void RemoveRune(eItemType rune)
	{
	}

	public void ClearAllRunes()
	{
	}

	public bool HasSpecialRune()
	{
		return false;
	}

	public void AddSpecialRune(eItemType rune)
	{
	}

	public void RemoveSpecialRune()
	{
	}

	public int GetSocketCount()
	{
		return 0;
	}

	public int GetBlockCount()
	{
		return 0;
	}

	public int GetBlockIndexWithSeed(int indexOrder)
	{
		return 0;
	}

	public void TurnIntoTwistedVersion()
	{
	}
}
