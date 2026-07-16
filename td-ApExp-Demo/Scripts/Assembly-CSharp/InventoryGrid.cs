using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryGrid : MonoBehaviour
{
	[SerializeField]
	private InventoryGrid otherGrid;

	[SerializeField]
	public InventorySlot[] slots;

	[SerializeField]
	protected RectTransform selectRt;

	[SerializeField]
	protected int rows;

	[SerializeField]
	protected int cols;

	[SerializeField]
	protected Sprite rarityCommon;

	[SerializeField]
	protected Sprite rarityRare;

	[SerializeField]
	protected Sprite rarityEpic;

	[SerializeField]
	protected Sprite rarityLegendary;

	[SerializeField]
	protected Sprite lockIcon;

	[SerializeField]
	protected GameObject? slotPrefabGo;

	[SerializeField]
	protected RectTransform? slotParentRt;

	[SerializeField]
	protected Scrollbar? scrollbar;

	[SerializeField]
	protected ScrollRect? scrollRect;

	protected Enhancement[] enhs;

	protected int index;

	public bool LinkUpToOther;

	public bool LinkDownToOther;

	public int Cols => cols;

	public int Rows => rows;

	public event Action<Enhancement> SlotEnhancementPressed;

	private void Start()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			int ii = i;
			slots[ii].Button.onClick.AddListener(delegate
			{
				OnSlotPressed(ii);
			});
			slots[ii].Button.onClick.AddListener(delegate
			{
				RemoveOutlines(slots[ii]);
			});
		}
		Reset();
	}

	public virtual void Reset()
	{
		index = 0;
		if (enhs != null && enhs.Length != 0 && enhs[index] != null)
		{
			selectRt.gameObject.SetActive(value: true);
		}
		else
		{
			selectRt.gameObject.SetActive(value: false);
		}
		if (scrollbar != null)
		{
			scrollbar.value = 0f;
			scrollbar.interactable = false;
			scrollRect.enabled = false;
		}
	}

	public virtual void Populate(Enhancement[] enhs)
	{
		Reset();
		Clear();
		this.enhs = enhs;
		if (enhs.Length > slots.Length)
		{
			ExpandSlots(slots, enhs.Length, slots.Length);
		}
		if (enhs.Length > 15)
		{
			scrollbar.interactable = true;
			scrollRect.enabled = true;
		}
		for (int i = 0; i < slots.Length && i < enhs.Length && enhs[i] != null; i++)
		{
			slots[i].Button.interactable = true;
			slots[i].IconImage.enabled = true;
			slots[i].IconImage.sprite = enhs[i].Icon;
			slots[i].rarityBorder.enabled = true;
			switch (enhs[i].Rarity)
			{
			case Rarity.Common:
				slots[i].rarityBorder.sprite = rarityCommon;
				break;
			case Rarity.Rare:
				slots[i].rarityBorder.sprite = rarityRare;
				break;
			case Rarity.Epic:
				slots[i].rarityBorder.sprite = rarityEpic;
				break;
			case Rarity.Legendary:
				slots[i].rarityBorder.sprite = rarityLegendary;
				break;
			}
		}
		if (enhs == null || enhs.Length - 1 < index || enhs[index] == null)
		{
			Reset();
			Clear();
		}
		SetupSlotNavigation(otherGrid);
	}

	public virtual void PopulateAll(Module[] modules)
	{
		Reset();
		Clear();
		int num = 0;
		int num2 = 0;
		Enhancement[] array = null;
		enhs = new Enhancement[200];
		foreach (Module module in modules)
		{
			num2 += module.StatsSO.Upgrades.Length;
			if (num2 > 15)
			{
				scrollbar.interactable = true;
				scrollRect.enabled = true;
			}
			if (num2 > slots.Length)
			{
				ExpandSlots(slots, num2, slots.Length);
			}
			for (int j = 0; j < module.StatsSO.Upgrades.Length; j++)
			{
				Enhancement[] upgrades = module.StatsSO.Upgrades;
				array = upgrades;
				if (j >= array.Length || !(array[j] != null))
				{
					break;
				}
				slots[num].Button.interactable = true;
				slots[num].IconImage.enabled = true;
				slots[num].IconImage.sprite = array[j].Icon;
				slots[num].rarityBorder.enabled = true;
				switch (array[j].Rarity)
				{
				case Rarity.Common:
					slots[num].rarityBorder.sprite = rarityCommon;
					break;
				case Rarity.Rare:
					slots[num].rarityBorder.sprite = rarityRare;
					break;
				case Rarity.Epic:
					slots[num].rarityBorder.sprite = rarityEpic;
					break;
				case Rarity.Legendary:
					slots[num].rarityBorder.sprite = rarityLegendary;
					break;
				}
				enhs[num] = array[j];
				num++;
			}
		}
	}

	protected virtual void OnSlotPressed(int i)
	{
		index = i;
		if (enhs != null && i < enhs.Length && !(enhs[i] == null))
		{
			selectRt.gameObject.SetActive(value: true);
			selectRt.transform.position = slots[i].transform.position;
			this.SlotEnhancementPressed?.Invoke(enhs[i]);
		}
	}

	protected virtual void Clear()
	{
		InventorySlot[] array = slots;
		foreach (InventorySlot obj in array)
		{
			obj.Button.interactable = false;
			obj.IconImage.enabled = false;
			obj.rarityBorder.enabled = false;
		}
	}

	protected virtual void ExpandSlots(InventorySlot[] slots, int firstArrayLength, int secondArrayLength)
	{
		if (firstArrayLength > secondArrayLength)
		{
			int num = secondArrayLength;
			secondArrayLength = firstArrayLength;
			firstArrayLength = num;
		}
		int num2 = (secondArrayLength - firstArrayLength) / 5;
		num2 *= 5;
		if ((secondArrayLength - firstArrayLength) % 5 > 0)
		{
			num2 += 5;
		}
		this.slots = new InventorySlot[slots.Length + num2];
		for (int i = 0; i < slots.Length; i++)
		{
			this.slots[i] = slots[i];
		}
		for (int j = firstArrayLength; j < this.slots.Length; j++)
		{
			int ii = j;
			this.slots[j] = UnityEngine.Object.Instantiate(slotPrefabGo, slotParentRt).GetComponentInChildren<InventorySlot>();
			this.slots[j].Button.onClick.AddListener(delegate
			{
				OnSlotPressed(ii);
			});
			this.slots[j].Button.onClick.AddListener(delegate
			{
				RemoveOutlines(this.slots[ii]);
			});
		}
		scrollbar.interactable = true;
		scrollRect.enabled = true;
	}

	public virtual void RemoveOutlines(InventorySlot? self)
	{
		InventorySlot[] array = slots;
		foreach (InventorySlot obj in array)
		{
			OutlineOnHover component = obj.GetComponent<OutlineOnHover>();
			bool flag = obj == self;
			component.SetOutlineLocked(flag);
			component.outline.color = (flag ? HexToColor("#ffe613") : HexToColor("#FFFFFF"));
		}
	}

	public virtual void SetupSlotNavigation(InventoryGrid linkedGrid)
	{
		bool flag = (bool)linkedGrid && base.transform.position.y > linkedGrid.transform.position.y;
		for (int i = 0; i < slots.Length; i++)
		{
			if (enhs == null || i >= enhs.Length || enhs[i] == null)
			{
				slots[i].Button.navigation = new Navigation
				{
					mode = Navigation.Mode.None
				};
				continue;
			}
			Navigation navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit
			};
			int num = i / cols;
			int num2 = i % cols;
			int num3 = i - cols;
			int num4 = i + cols;
			if (num3 >= 0 && enhs[num3] != null)
			{
				navigation.selectOnUp = slots[num3].Button;
			}
			else if ((bool)linkedGrid && num == 0 && !flag)
			{
				for (int j = 0; j < linkedGrid.slots.Length; j++)
				{
					if (linkedGrid.slots[j].Button.interactable)
					{
						navigation.selectOnUp = linkedGrid.slots[j].Button;
						break;
					}
				}
			}
			if (num4 < slots.Length && enhs != null && num4 < enhs.Length && enhs[num4] != null)
			{
				navigation.selectOnDown = slots[num4].Button;
			}
			else if ((bool)linkedGrid && LinkDownToOther)
			{
				for (int k = 0; k < linkedGrid.slots.Length; k++)
				{
					if (linkedGrid.slots[k].Button.interactable)
					{
						navigation.selectOnDown = linkedGrid.slots[k].Button;
						break;
					}
				}
			}
			if (num2 > 0 && enhs[i - 1] != null)
			{
				navigation.selectOnLeft = slots[i - 1].Button;
			}
			if (num2 < cols - 1 && i + 1 < enhs.Length && enhs[i + 1] != null)
			{
				navigation.selectOnRight = slots[i + 1].Button;
			}
			slots[i].Button.navigation = navigation;
		}
	}

	public static Color HexToColor(string hex)
	{
		hex = hex.Replace("0x", "").Replace("#", "");
		byte a = byte.MaxValue;
		byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
		if (hex.Length == 8)
		{
			a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
		}
		return new Color32(r, g, b, a);
	}
}
