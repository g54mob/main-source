using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UniversalInventorySystem
{
	[Serializable]
	public class InventoryUI : MonoBehaviour
	{
		public bool generateUIFromSlotPrefab;

		public GameObject generatedUIParent;

		public GameObject slotPrefab;

		public Canvas canvas;

		public GameObject DontDropItemRect;

		public List<GameObject> slots;

		public bool showAmount = true;

		public GameObject dragObj;

		public bool hideDragObj;

		public bool useOnClick;

		public Color outlineColor;

		public float outlineSize;

		public bool hideInventory;

		public KeyCode toggleKey;

		public GameObject togglableObject;

		public bool dropOnCloseCrafting;

		public Vector3 dropPos = Vector3.zero;

		public Vector3 randomFactor = Vector3.zero;

		public Inventory inv;

		public bool isCraftInventory;

		public Vector2Int gridSize;

		public bool allowsPatternCrafting;

		public GameObject[] productSlots;

		[HideInInspector]
		public bool isDraging;

		[HideInInspector]
		public int? dragSlotNumber;

		[HideInInspector]
		public bool shouldSwap;

		[HideInInspector]
		public List<Item> pattern = new List<Item>();

		[HideInInspector]
		public List<int> amount = new List<int>();

		private bool hasGenerated;

		public void SetInventory(Inventory _inv)
		{
			inv = _inv;
		}

		public Inventory GetInventory()
		{
			return inv;
		}

		public void Start()
		{
			if (isCraftInventory)
			{
				inv.slotAmounts += productSlots.Length;
				for (int i = 0; i < productSlots.Length; i++)
				{
					inv.slots.Add(Slot.nullSlot);
				}
				GameObject[] array = productSlots;
				foreach (GameObject item in array)
				{
					slots.Add(item);
				}
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(dragObj, canvas.transform);
			gameObject.name = $"DRAGITEMOBJ_{base.name}_{UnityEngine.Random.Range(int.MinValue, int.MaxValue)}";
			gameObject.AddComponent<DragSlot>();
			gameObject.SetActive(value: false);
			if (hideDragObj)
			{
				gameObject.hideFlags = HideFlags.HideInHierarchy;
			}
			dragObj = gameObject;
			InventoryController.inventoriesUI.Add(this);
			if (!generateUIFromSlotPrefab)
			{
				for (int k = 0; k < slots.Count; k++)
				{
					slots[k].name = k.ToString();
					for (int l = 0; l < slots[k].transform.childCount; l++)
					{
						if (slots[k].transform.GetChild(l).TryGetComponent<Image>(out var _))
						{
							if (slots[k].transform.GetChild(l).TryGetComponent<ItemDragHandler>(out var component2))
							{
								component2.canvas = canvas;
								component2.invUI = this;
							}
							else
							{
								component2 = slots[k].transform.GetChild(l).gameObject.AddComponent<ItemDragHandler>();
								component2.canvas = canvas;
								component2.invUI = this;
							}
							if (slots[k].transform.GetChild(l).TryGetComponent<Tooltip>(out var component3))
							{
								component3.canvas = canvas;
								component3.invUI = this;
								component3.slotNum = k;
							}
							else
							{
								component3 = slots[k].transform.GetChild(l).gameObject.AddComponent<Tooltip>();
								component3.canvas = canvas;
								component3.invUI = this;
								component3.slotNum = k;
							}
						}
					}
				}
			}
			if (!canvas.TryGetComponent<ItemDropHandler>(out var _))
			{
				canvas.gameObject.AddComponent<ItemDropHandler>();
			}
			if (isCraftInventory)
			{
				for (int m = 0; m < gridSize.x * gridSize.y; m++)
				{
					pattern.Add(null);
					amount.Add(0);
				}
				for (int n = gridSize.x * gridSize.y; n < inv.slots.Count; n++)
				{
					inv.slots[n] = Slot.SetSlotProperties(inv[n], _isProductSlot: true, SlotProtection.Remove | SlotProtection.Swap, null);
				}
			}
		}

		private List<GameObject> GenerateUI(int slotAmount)
		{
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < slotAmount; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(slotPrefab, Vector3.zero, Quaternion.identity);
				gameObject.transform.SetParent(generatedUIParent.transform);
				gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
				ItemDragHandler componentInChildren = gameObject.transform.GetComponentInChildren<ItemDragHandler>();
				componentInChildren.canvas = canvas;
				componentInChildren.invUI = this;
				gameObject.name = i.ToString();
				list.Add(gameObject);
				for (int j = 0; j < gameObject.transform.childCount; j++)
				{
					if (gameObject.transform.GetChild(j).TryGetComponent<Image>(out var _))
					{
						if (gameObject.transform.GetChild(j).TryGetComponent<ItemDragHandler>(out var component2))
						{
							component2.canvas = canvas;
							component2.invUI = this;
						}
						else
						{
							component2 = gameObject.transform.GetChild(j).gameObject.AddComponent<ItemDragHandler>();
							component2.canvas = canvas;
							component2.invUI = this;
						}
						if (gameObject.transform.GetChild(j).TryGetComponent<Tooltip>(out var component3))
						{
							component3.canvas = canvas;
							component3.invUI = this;
							component3.slotNum = i;
						}
						else
						{
							component3 = gameObject.transform.GetChild(j).gameObject.AddComponent<Tooltip>();
							component3.canvas = canvas;
							component3.invUI = this;
							component3.slotNum = i;
						}
					}
				}
			}
			slots = list;
			return list;
		}

		public void Update()
		{
			if (!inv.hasInitializated)
			{
				inv.Initialize();
			}
			if (generateUIFromSlotPrefab && !hasGenerated)
			{
				GenerateUI(inv.slotAmounts);
				hasGenerated = true;
			}
			if (hideInventory && Input.GetKeyDown(toggleKey) && !isDraging)
			{
				if (isCraftInventory && dropOnCloseCrafting)
				{
					for (int i = 0; i < inv.slots.Count; i++)
					{
						Slot slot = inv.slots[i];
						Vector3 dropPosition = dropPos;
						dropPosition.x += UnityEngine.Random.Range(0f - randomFactor.x, randomFactor.x);
						dropPosition.y += UnityEngine.Random.Range(0f - randomFactor.y, randomFactor.y);
						dropPosition.z += UnityEngine.Random.Range(0f - randomFactor.z, randomFactor.z);
						inv.DropItem(slot.amount, dropPosition, i);
					}
				}
				togglableObject.SetActive(!togglableObject.activeInHierarchy);
			}
			for (int j = 0; j < inv.slots.Count; j++)
			{
				if (isCraftInventory && j < pattern.Count)
				{
					pattern[j] = inv.slots[j].item;
					amount[j] = inv.slots[j].amount;
				}
				if (j >= slots.Count)
				{
					break;
				}
				Image component;
				TextMeshProUGUI component2;
				if (inv.slots[j].item == null)
				{
					for (int k = 0; k < slots[j].transform.childCount; k++)
					{
						if (slots[j].transform.GetChild(k).TryGetComponent<Image>(out component))
						{
							component.sprite = null;
							component.color = new Color(0f, 0f, 0f, 0f);
						}
						else if (slots[j].transform.GetChild(k).TryGetComponent<TextMeshProUGUI>(out component2))
						{
							component2.text = "";
						}
					}
					continue;
				}
				for (int l = 0; l < slots[j].transform.childCount; l++)
				{
					if (slots[j].transform.GetChild(l).TryGetComponent<Image>(out component))
					{
						if (inv.slots[j].item.hasDurability)
						{
							if (inv.slots[j].item.durabilityImages.Count > 0)
							{
								component.sprite = GetNearestSprite(inv, inv.slots[j].durability, j);
								component.color = new Color(1f, 1f, 1f, 1f);
							}
							else
							{
								component.sprite = inv.slots[j].item.sprite;
								component.color = new Color(1f, 1f, 1f, 1f);
							}
						}
						else
						{
							component.sprite = inv.slots[j].item.sprite;
							component.color = new Color(1f, 1f, 1f, 1f);
						}
					}
					else if (slots[j].transform.GetChild(l).TryGetComponent<TextMeshProUGUI>(out component2) && showAmount && inv[j].item.showAmount)
					{
						component2.text = inv.slots[j].amount.ToString();
					}
					else if (slots[j].transform.GetChild(l).TryGetComponent<TextMeshProUGUI>(out component2))
					{
						component2.text = "";
					}
				}
				if (dragObj.GetComponent<DragSlot>().GetSlotNumber() == j && isDraging)
				{
					if (inv.slots[j].amount - dragObj.GetComponent<DragSlot>().GetAmount() == 0)
					{
						for (int m = 0; m < slots[j].transform.childCount; m++)
						{
							if (slots[j].transform.GetChild(m).TryGetComponent<Image>(out component))
							{
								component.sprite = null;
								component.color = new Color(0f, 0f, 0f, 0f);
							}
							else if (slots[j].transform.GetChild(m).TryGetComponent<TextMeshProUGUI>(out component2))
							{
								component2.text = "";
							}
						}
					}
					else
					{
						for (int n = 0; n < slots[j].transform.childCount; n++)
						{
							if (slots[j].transform.GetChild(n).TryGetComponent<TextMeshProUGUI>(out component2) && showAmount && inv[j].item.showAmount)
							{
								component2.text = (inv.slots[j].amount - dragObj.GetComponent<DragSlot>().GetAmount()).ToString();
							}
							else if (slots[j].transform.GetChild(n).TryGetComponent<TextMeshProUGUI>(out component2))
							{
								component2.text = "";
							}
						}
					}
				}
				if (isCraftInventory)
				{
					continue;
				}
				slots[j].GetComponent<Button>().onClick.RemoveAllListeners();
				int index = j;
				slots[j].GetComponent<Button>().onClick.AddListener(delegate
				{
					if (useOnClick)
					{
						inv.UseItemInSlot(index);
					}
				});
			}
			if (!isCraftInventory)
			{
				return;
			}
			CraftItemData products = inv.CraftItem(new CraftItemData(pattern.ToArray(), amount.ToArray()), gridSize, craftItem: false, allowPatternRecipe: true, productSlots.Length);
			List<Item> productsItem = new List<Item>();
			if (products != CraftItemData.nullData && products.items.Length <= productSlots.Length)
			{
				if (products.items.Length == productSlots.Length)
				{
					for (int num = 0; num < products.items.Length; num++)
					{
						productsItem.Add(inv.slots[gridSize.x * gridSize.y + num].item ?? products.items[num]);
					}
				}
				else
				{
					for (int num2 = 0; num2 < productSlots.Length - products.items.Length + 1; num2++)
					{
						productsItem = new List<Item>();
						for (int num3 = 0; num3 < products.items.Length && gridSize.x * gridSize.y + num3 + num2 < inv.slots.Count; num3++)
						{
							if (inv.slots[gridSize.x * gridSize.y + num3 + num2].item == products.items[num3] || inv.slots[gridSize.x * gridSize.y + num3 + num2].item == null)
							{
								productsItem.Add(inv.slots[gridSize.x * gridSize.y + num3 + num2].item ?? products.items[num3]);
								if (products.items.SequenceEqual(productsItem.ToArray()))
								{
									num2 = 2147483646;
									break;
								}
							}
						}
					}
				}
			}
			int num4 = 0;
			for (int num5 = 0; num5 < productSlots.Length; num5++)
			{
				if (inv.slots[gridSize.x * gridSize.y + num5].hasItem)
				{
					for (int num6 = 0; num6 < slots[gridSize.x * gridSize.y + num5].transform.childCount; num6++)
					{
						TextMeshProUGUI component4;
						if (slots[gridSize.x * gridSize.y + num5].transform.GetChild(num6).TryGetComponent<Image>(out var component3))
						{
							if (inv.slots[gridSize.x * gridSize.y + num5].item.hasDurability)
							{
								if (inv.slots[gridSize.x * gridSize.y + num5].item.durabilityImages.Count > 0)
								{
									component3.sprite = GetNearestSprite(inv, inv.slots[gridSize.x * gridSize.y + num5].durability, gridSize.x * gridSize.y + num5);
									component3.color = new Color(1f, 1f, 1f, 1f);
								}
								else
								{
									component3.sprite = inv.slots[gridSize.x * gridSize.y + num5].item.sprite;
									component3.color = new Color(1f, 1f, 1f, 1f);
								}
							}
							else
							{
								component3.sprite = inv.slots[gridSize.x * gridSize.y + num5].item.sprite;
								component3.color = new Color(1f, 1f, 1f, 1f);
							}
						}
						else if (slots[gridSize.x * gridSize.y + num5].transform.GetChild(num6).TryGetComponent<TextMeshProUGUI>(out component4) && showAmount && inv[gridSize.x * gridSize.y + num5].item.showAmount)
						{
							component4.text = inv.slots[gridSize.x * gridSize.y + num5].amount.ToString();
						}
						else if (slots[gridSize.x * gridSize.y + num5].transform.GetChild(num6).TryGetComponent<TextMeshProUGUI>(out component4))
						{
							component4.text = "";
						}
					}
					if (products != null && products != CraftItemData.nullData)
					{
						Item item = inv[gridSize.x * gridSize.y + num5].item;
						CraftItemData craftItemData = products;
						if (item == (((craftItemData != null) ? craftItemData.items[num4] : null) ?? null))
						{
							int num7 = inv[gridSize.x * gridSize.y + num5].amount;
							CraftItemData craftItemData2 = products;
							if (num7 + ((craftItemData2 != null) ? craftItemData2.amounts[num4] : int.MaxValue) <= inv[gridSize.x * gridSize.y + num5].item.maxAmount)
							{
								num4++;
							}
						}
					}
					productSlots[num5].GetComponent<Button>().onClick.RemoveAllListeners();
					productSlots[num5].GetComponent<Button>().onClick.AddListener(delegate
					{
						if (products.items != null && products.items.Length <= productSlots.Length && products.items.SequenceEqual(productsItem.ToArray()))
						{
							inv.CraftItem(new CraftItemData(pattern.ToArray(), amount.ToArray()), gridSize, craftItem: true, allowPatternRecipe: true, productSlots.Length);
						}
					});
				}
				else if (products.items != null && products.items.Length <= productSlots.Length && num4 < products.items.Length)
				{
					bool flag = false;
					for (int num8 = 0; num8 < slots[gridSize.x * gridSize.y + num5].transform.childCount; num8++)
					{
						TextMeshProUGUI component6;
						if (slots[gridSize.x * gridSize.y + num5].transform.GetChild(num8).TryGetComponent<Image>(out var component5))
						{
							if (products.items[num4].hasDurability)
							{
								if (products.items[num4].durabilityImages.Count > 0)
								{
									component5.sprite = GetNearestSprite(products.items[num4], products.items[num4].maxDurability);
									component5.color = new Color(1f, 1f, 1f, 0.7f);
								}
								else
								{
									component5.sprite = products.items[num4].sprite;
									component5.color = new Color(1f, 1f, 1f, 0.7f);
								}
								flag = true;
							}
							else
							{
								component5.sprite = products.items[num4].sprite;
								component5.color = new Color(1f, 1f, 1f, 0.7f);
								flag = true;
							}
						}
						else if (productSlots[num5].transform.GetChild(num8).TryGetComponent<TextMeshProUGUI>(out component6) && showAmount && products.items[num4].showAmount)
						{
							component6.text = products.amounts[num4].ToString();
							flag = true;
						}
						else if (productSlots[num5].transform.GetChild(num8).TryGetComponent<TextMeshProUGUI>(out component6))
						{
							component6.text = "";
							flag = true;
						}
					}
					if (flag)
					{
						num4++;
					}
					productSlots[num5].GetComponent<Button>().onClick.RemoveAllListeners();
					productSlots[num5].GetComponent<Button>().onClick.AddListener(delegate
					{
						inv.CraftItem(new CraftItemData(pattern.ToArray(), amount.ToArray()), gridSize, craftItem: true, allowPatternRecipe: true, productSlots.Length);
					});
				}
				else
				{
					if (inv.slots[gridSize.x * gridSize.y + num5].hasItem)
					{
						continue;
					}
					for (int num9 = 0; num9 < slots[num5].transform.childCount; num9++)
					{
						TextMeshProUGUI component8;
						if (slots[gridSize.x * gridSize.y + num5].transform.GetChild(num9).TryGetComponent<Image>(out var component7))
						{
							component7.sprite = null;
							component7.color = new Color(0f, 0f, 0f, 0f);
						}
						else if (productSlots[num5].transform.GetChild(num9).TryGetComponent<TextMeshProUGUI>(out component8))
						{
							component8.text = "";
						}
					}
				}
			}
		}

		public static Sprite GetNearestSprite(Inventory inv, int durability, int slot)
		{
			int num = int.MaxValue;
			int index = 0;
			for (int num2 = inv.slots[slot].item.durabilityImages.Count - 1; num2 >= 0; num2--)
			{
				int num3 = inv.slots[slot].item.durabilityImages[num2].durability - durability;
				if (num3 < 0)
				{
					break;
				}
				if (num3 < num)
				{
					num = num3;
					index = num2;
				}
			}
			return inv.slots[slot].item.durabilityImages[index].sprite;
		}

		public static Sprite GetNearestSprite(Item item, int durability)
		{
			int num = int.MaxValue;
			int index = 0;
			for (int num2 = item.durabilityImages.Count - 1; num2 >= 0; num2--)
			{
				int num3 = item.durabilityImages[num2].durability - durability;
				if (num3 < 0)
				{
					break;
				}
				if (num3 < num)
				{
					num = num3;
					index = num2;
				}
			}
			return item.durabilityImages[index].sprite;
		}
	}
}
