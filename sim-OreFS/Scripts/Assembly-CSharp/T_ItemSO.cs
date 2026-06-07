using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "T_ItemSO", menuName = "Game/T_ItemSO")]
public class T_ItemSO : ScriptableObject
{
	[Serializable]
	public class RecipeIngredient
	{
		public T_ItemSO Item;

		[Min(1f)]
		public int Count = 1;
	}

	[Header("Identity")]
	[SerializeField]
	private string ItemID;

	public string Name;

	public Sprite Icon;

	public string Description;

	[Header("Market")]
	public int Price;

	[Header("Properties")]
	public float Scale = 1f;

	[Header("Type")]
	public PickupType Type;

	[Header("Filter")]
	[Tooltip("Bu item hangi filtrelerde görünecek (birden fazla seçilebilir)")]
	public List<FilterType> FilterTypes = new List<FilterType>();

	[Header("Visuals")]
	public GameObject MiningVFX;

	public GameObject PickupVFX;

	[Header("Spawn")]
	[Tooltip("Bu item spawn edilirken kullanılacak prefab (NetworkIdentity + T_Item içermeli)")]
	public GameObject SpawnPrefab;

	[Tooltip("SpawnPrefab içine spawn edilecek görsel prefab (local spawn)")]
	public GameObject VisualPrefab;

	[Header("Node Mining")]
	[Tooltip("Bu item bir node olarak spawn edilecek mi?")]
	public bool isNode;

	[Range(0f, 20f)]
	[Tooltip("Her parçanın kaç vuruşta kırılacağı")]
	public int nodeHealth = 3;

	[Tooltip("Toplandığında minimum maden miktarı")]
	[Min(1f)]
	public int collectAmountMin = 1;

	[Tooltip("Toplandığında maximum maden miktarı")]
	[Min(1f)]
	public int collectAmountMax = 3;

	[Tooltip("Node olarak spawn edildiğinde gösterilecek visual prefab")]
	public GameObject NodeVisualPrefab;

	[Tooltip("Node'a her vuruşta oynatılacak VFX tipi (pool'dan)")]
	public LayerVFX nodeHitVFX = LayerVFX.StoneVFX;

	[Tooltip("Node'a her vuruşta oynatılacak SFX tipi")]
	public LayerSFX nodeHitSFX = LayerSFX.StoneSFX;

	[Header("Version")]
	[Tooltip("True ise bu item sadece full version'da kullanılabilir (Demo'da kilitli)")]
	public bool fullVersionOnly;

	[Header("Recipe Book")]
	[Tooltip("Bu item'ı üreten makine (Building)")]
	public T_BuildingItemSO producedBy;

	public float productionTime;

	public T_ItemSO ore;

	[Tooltip("Resource üretimi için gerekli ore adedi")]
	[Min(1f)]
	public int oreCount = 1;

	public List<RecipeIngredient> RecipeList = new List<RecipeIngredient>();

	public string GetItemID()
	{
		return ItemID;
	}

	[ContextMenu("Regenerate ItemID")]
	public void RegenerateItemID()
	{
		ItemID = GenerateId(14);
	}

	private static string GenerateId(int len)
	{
		byte[] array = new byte[len];
		using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
		{
			randomNumberGenerator.GetBytes(array);
		}
		StringBuilder stringBuilder = new StringBuilder(len);
		for (int i = 0; i < len; i++)
		{
			stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[array[i] % "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Length]);
		}
		return stringBuilder.ToString();
	}
}
