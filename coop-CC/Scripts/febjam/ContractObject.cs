using System;
using Aggro.Core;
using Mirror;
using UnityEngine;

[CreateAssetMenu(menuName = "Shift/Contract", fileName = "contract-NAME")]
public class ContractObject : ScriptableObject
{
	[Serializable]
	public class Unlock
	{
		public CostumeObject costume;

		[Range(1f, 5f)]
		public int bellsRequired = 1;
	}

	public ContractType type;

	public GameObject randomBoxVisualPrefab;

	public string title;

	[Min(0f)]
	public int bellsRequired;

	[Min(0f)]
	public float modifierMultiplier = 1f;

	[Range(2f, 4f)]
	public int randomBoxCount = 2;

	public ShiftOrderObject[] orders;

	[Scene]
	public string bigWarehouse;

	[Scene]
	public string smallWarehouse;

	[Scene]
	public string[] bigWarehouses;

	[Scene]
	public string[] smallWarehouses;

	[Space]
	[Range(0f, 1f)]
	public float multiplierForOnePlayer = 0.5f;

	[Range(0f, 1f)]
	public float multiplierForTwoPlayers = 0.7f;

	[Range(0f, 1f)]
	public float multiplierForThreePlayers = 0.85f;

	[Space]
	public ContractShift shift1;

	public ContractShift shift2;

	public ContractShift shift3;

	public ContractShift shift4;

	public ContractShift shift5;

	[Space]
	public DeckCard<ShopItemObject>[] shopCards;

	public Unlock[] unlocks;

	public GameObject[] demoVisualPrefabs = new GameObject[0];

	public bool isDemoLocked => type == ContractType.DemoLocked;

	public ContractShift GetContractShift(int shift)
	{
		return shift switch
		{
			1 => shift1, 
			2 => shift2, 
			3 => shift3, 
			4 => shift4, 
			_ => shift5, 
		};
	}

	public float GetPlayerMultiplier(int playerCount)
	{
		return playerCount switch
		{
			1 => multiplierForOnePlayer, 
			2 => multiplierForTwoPlayers, 
			3 => multiplierForThreePlayers, 
			_ => 1f, 
		};
	}
}
