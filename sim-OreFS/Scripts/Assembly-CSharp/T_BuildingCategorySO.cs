using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingCategory", menuName = "Game/Building Category")]
public class T_BuildingCategorySO : ScriptableObject
{
	[Header("Kategori Bilgileri")]
	[Tooltip("Kategori adı - UI'da gösterilecek")]
	public string CategoryName;

	[Tooltip("Kategori ID - Kod içinde referans için")]
	public string CategoryId;

	[Tooltip("Kategori ikonu - Radial menu'de gösterilecek")]
	public Sprite CategoryIcon;

	[TextArea(2, 4)]
	[Tooltip("Kategori açıklaması")]
	public string CategoryDescription;

	[Header("Building Listesi")]
	[Tooltip("Bu kategorideki building'ler - Scroll ile değiştirilebilir")]
	public List<T_BuildingItemSO> Buildings = new List<T_BuildingItemSO>();

	[Header("Ayarlar")]
	[Tooltip("Son item'dan ilk item'a dönüş yapılsın mı?")]
	public bool AllowScrollCycle = true;

	[Tooltip("Kategori seçildiğinde varsayılan olarak seçili olacak building index'i")]
	public int DefaultSelectedIndex;

	public int BuildingCount
	{
		get
		{
			if (Buildings == null)
			{
				return 0;
			}
			return Buildings.Count;
		}
	}

	public T_BuildingItemSO GetBuilding(int index)
	{
		if (Buildings == null || Buildings.Count == 0)
		{
			return null;
		}
		if (index < 0 || index >= Buildings.Count)
		{
			return null;
		}
		return Buildings[index];
	}

	public T_BuildingItemSO GetDefaultBuilding()
	{
		return GetBuilding(DefaultSelectedIndex);
	}

	public int GetNextIndex(int currentIndex, int direction)
	{
		if (Buildings == null || Buildings.Count == 0)
		{
			return 0;
		}
		int num = currentIndex + direction;
		if (AllowScrollCycle)
		{
			if (num < 0)
			{
				num = Buildings.Count - 1;
			}
			else if (num >= Buildings.Count)
			{
				num = 0;
			}
		}
		else
		{
			num = Mathf.Clamp(num, 0, Buildings.Count - 1);
		}
		return num;
	}
}
