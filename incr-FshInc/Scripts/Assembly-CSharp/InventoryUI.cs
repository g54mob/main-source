using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	public List<SimpleTooltipTrigger> inventorySlots = new List<SimpleTooltipTrigger>();

	public List<Image> slotIcons = new List<Image>();

	private int _currentFishIndex;

	[Header("Animation Settings")]
	public float slideInDuration = 0.5f;

	public float slideInStaggerDelay = 0.07f;

	public float slideInStartYOffset = -1000f;

	public Ease slideInEase = Ease.OutBack;

	public float initialWait = 0.2f;

	private List<Vector2> _originalSlotPositions = new List<Vector2>();

	private List<RectTransform> _slotRectTransforms = new List<RectTransform>();

	private void OnEnable()
	{
		Inventory.OnFishAdded += AddFishToDisplay;
	}

	private void OnDisable()
	{
		Inventory.OnFishAdded -= AddFishToDisplay;
	}

	private void Awake()
	{
		_originalSlotPositions.Clear();
		_slotRectTransforms.Clear();
		foreach (SimpleTooltipTrigger inventorySlot in inventorySlots)
		{
			RectTransform component = inventorySlot.GetComponent<RectTransform>();
			_slotRectTransforms.Add(component);
			inventorySlot.gameObject.SetActive(value: false);
		}
		ClearDisplay();
	}

	private void Start()
	{
		for (int i = 0; i < _slotRectTransforms.Count; i++)
		{
			Vector2 anchoredPosition = _slotRectTransforms[i].anchoredPosition;
			_originalSlotPositions.Add(anchoredPosition);
			InventorySlotHover component = inventorySlots[i].GetComponent<InventorySlotHover>();
			if (component != null)
			{
				component.Initialize(anchoredPosition);
				component.enabled = false;
			}
		}
		StartCoroutine(AnimateSlotsIn());
	}

	private IEnumerator AnimateSlotsIn()
	{
		yield return new WaitForSeconds(initialWait);
		for (int i = 0; i < _slotRectTransforms.Count; i++)
		{
			RectTransform rectTransform = _slotRectTransforms[i];
			rectTransform.anchoredPosition = new Vector2(_originalSlotPositions[i].x, slideInStartYOffset);
			rectTransform.gameObject.SetActive(value: true);
		}
		for (int j = 0; j < _slotRectTransforms.Count; j++)
		{
			_slotRectTransforms[j].DOAnchorPos(_originalSlotPositions[j], slideInDuration).SetEase(slideInEase);
			yield return new WaitForSeconds(slideInStaggerDelay);
		}
		yield return new WaitForSeconds(slideInDuration);
		foreach (SimpleTooltipTrigger inventorySlot in inventorySlots)
		{
			InventorySlotHover component = inventorySlot.GetComponent<InventorySlotHover>();
			if (component != null)
			{
				component.enabled = true;
			}
		}
	}

	public void ClearDisplay()
	{
		foreach (Image slotIcon in slotIcons)
		{
			slotIcon.enabled = false;
		}
		foreach (SimpleTooltipTrigger inventorySlot in inventorySlots)
		{
			inventorySlot.tooltipText = "";
			inventorySlot.enabled = false;
		}
		_currentFishIndex = 0;
	}

	private void AddFishToDisplay(CaughtFish fish)
	{
		if (_currentFishIndex < slotIcons.Count)
		{
			slotIcons[_currentFishIndex].sprite = fish.artwork;
			slotIcons[_currentFishIndex].enabled = true;
			inventorySlots[_currentFishIndex].enabled = true;
			inventorySlots[_currentFishIndex].tooltipText = fish.fish.LocalizedName + " (" + fish.rarityData.rarity.GetLocalizedText() + ")";
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.text.perfect.catch");
			if (fish.isPerfectCatch)
			{
				inventorySlots[_currentFishIndex].headerText = localizedString.GetLocalizedString();
				inventorySlots[_currentFishIndex].showHeaderText = true;
			}
			else
			{
				inventorySlots[_currentFishIndex].showHeaderText = false;
			}
			_currentFishIndex++;
		}
	}
}
