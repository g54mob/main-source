using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InGameAdminPanel : MonoBehaviour
{
	[Header("Item Bolumu")]
	[SerializeField]
	private TMP_Dropdown itemDropdown;

	[SerializeField]
	private TMP_InputField itemCountInput;

	[Header("Para Bolumu")]
	[SerializeField]
	private TMP_InputField moneyInput;

	[Header("XP Bolumu")]
	[SerializeField]
	private TMP_InputField xpInput;

	private List<T_ItemSO> allItems = new List<T_ItemSO>();

	private void Start()
	{
		InitializeItemDropdown();
	}

	private void InitializeItemDropdown()
	{
		if (itemDropdown == null)
		{
			return;
		}
		allItems.Clear();
		if (ScriptableListManager.Instance != null)
		{
			allItems = ScriptableListManager.Instance.AllItemSOs.ToList();
		}
		else if (ItemSOManager.Instance != null)
		{
			allItems = ItemSOManager.Instance.GetAllItemSOs();
		}
		allItems = (from i in allItems
			where i != null
			orderby i.Name
			select i).ToList();
		itemDropdown.ClearOptions();
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		foreach (T_ItemSO allItem in allItems)
		{
			TMP_Dropdown.OptionData item = new TMP_Dropdown.OptionData(allItem.Name, allItem.Icon, Color.white);
			list.Add(item);
		}
		itemDropdown.AddOptions(list);
		Debug.Log($"[InGameAdminPanel] {allItems.Count} item yuklendi.");
	}

	public void AddItemToPlayer()
	{
		if (allItems.Count == 0 || itemDropdown == null)
		{
			Debug.LogWarning("[InGameAdminPanel] Item listesi bos!");
			return;
		}
		int value = itemDropdown.value;
		if (value < 0 || value >= allItems.Count)
		{
			Debug.LogWarning("[InGameAdminPanel] Gecersiz item secimi!");
			return;
		}
		T_ItemSO t_ItemSO = allItems[value];
		if (t_ItemSO == null)
		{
			Debug.LogWarning("[InGameAdminPanel] Secili item null!");
			return;
		}
		int result = 1;
		if (itemCountInput != null && !string.IsNullOrEmpty(itemCountInput.text))
		{
			int.TryParse(itemCountInput.text, out result);
			result = Mathf.Max(1, result);
		}
		T_Bag t_Bag = GameManager.Instance?.localBag;
		if (t_Bag == null)
		{
			Debug.LogWarning("[InGameAdminPanel] Player Bag bulunamadi!");
			return;
		}
		int num = 0;
		for (int i = 0; i < result; i++)
		{
			if (t_Bag.AddItem(t_ItemSO))
			{
				num++;
				continue;
			}
			Debug.LogWarning($"[InGameAdminPanel] Bag dolu! {num}/{result} eklendi.");
			break;
		}
		Debug.Log($"[InGameAdminPanel] {num}x {t_ItemSO.Name} eklendi.");
	}

	public void AddMoney()
	{
		if (FactoryManager.Instance == null)
		{
			Debug.LogWarning("[InGameAdminPanel] FactoryManager bulunamadi!");
			return;
		}
		int result = 1000;
		if (moneyInput != null && !string.IsNullOrEmpty(moneyInput.text))
		{
			int.TryParse(moneyInput.text, out result);
			result = Mathf.Max(0, result);
		}
		if (result <= 0)
		{
			Debug.LogWarning("[InGameAdminPanel] Gecersiz para miktari!");
			return;
		}
		FactoryManager.Instance.AddMoney(result, EconomyType.EconomyType_Sale);
		Debug.Log($"[InGameAdminPanel] {result} para eklendi. Yeni: {FactoryManager.Instance.Money}");
	}

	public void AddXP()
	{
		if (FactoryManager.Instance == null)
		{
			Debug.LogWarning("[InGameAdminPanel] FactoryManager bulunamadi!");
			return;
		}
		int result = 100;
		if (xpInput != null && !string.IsNullOrEmpty(xpInput.text))
		{
			int.TryParse(xpInput.text, out result);
			result = Mathf.Max(0, result);
		}
		if (result <= 0)
		{
			Debug.LogWarning("[InGameAdminPanel] Gecersiz XP miktari!");
			return;
		}
		FactoryManager.Instance.AddXP(result, EconomyType.EconomyType_Sale);
		Debug.Log($"[InGameAdminPanel] {result} XP eklendi. Yeni: {FactoryManager.Instance.CurrentXP}");
	}
}
