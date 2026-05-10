using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Local Market Product Database")]
public class LocalMarketProductDatabase : ScriptableObject
{
	[SerializeField]
	private LocalMarketProductCost[] m_Entries;

	public IEnumerable<LocalMarketProductCost> GetEnumerable()
	{
		return null;
	}

	public bool GetEntry(ProductSO product, out LocalMarketProductCost entry)
	{
		entry = default(LocalMarketProductCost);
		return false;
	}

	public bool GetEntryById(int id, out LocalMarketProductCost entry)
	{
		entry = default(LocalMarketProductCost);
		return false;
	}

	public float GetCost(ProductSO productSo)
	{
		return 0f;
	}
}
