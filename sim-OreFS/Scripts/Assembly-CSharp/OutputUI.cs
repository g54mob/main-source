using I2.Loc;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OutputUI : MonoBehaviour
{
	[Header("Active Item Info")]
	public Image itemIcon;

	public TextMeshProUGUI itemName;

	public TextMeshProUGUI itemCount;

	[Header("Progress")]
	public GameObject startUI;

	public GameObject stopUI;

	public Image progressFill;

	public TextMeshProUGUI progressValue;

	public GameObject droppingContainer;

	[Header("References")]
	[SerializeField]
	private T_SortingOutput sortingOutput;

	private int selectedCount = 1;

	private bool _lastRunning;

	private int _lastPercent = -1;

	private void Awake()
	{
		SetActiveDroppingContainer(active: false);
	}

	private void OnEnable()
	{
		if (sortingOutput != null)
		{
			sortingOutput.OnSelectedItemChangedEvent += OnSelectedItemChanged;
			sortingOutput.OnItemCountChangedEvent += OnItemCountChanged;
		}
	}

	private void OnDisable()
	{
		if (sortingOutput != null)
		{
			sortingOutput.OnSelectedItemChangedEvent -= OnSelectedItemChanged;
			sortingOutput.OnItemCountChangedEvent -= OnItemCountChanged;
		}
	}

	private void Update()
	{
		if (!(sortingOutput == null))
		{
			bool outputRunningState = sortingOutput.GetOutputRunningState();
			SetOutputRunningState(outputRunningState);
			float outputProgress = sortingOutput.GetOutputProgress();
			SetOutputProgress(outputProgress);
		}
	}

	public void SetSortingOutput(T_SortingOutput output)
	{
		if (sortingOutput != null)
		{
			sortingOutput.OnSelectedItemChangedEvent -= OnSelectedItemChanged;
			sortingOutput.OnItemCountChangedEvent -= OnItemCountChanged;
		}
		sortingOutput = output;
		if (sortingOutput != null)
		{
			sortingOutput.OnSelectedItemChangedEvent += OnSelectedItemChanged;
			sortingOutput.OnItemCountChangedEvent += OnItemCountChanged;
		}
		UpdateUI();
	}

	private void UpdateUI()
	{
		if (sortingOutput == null)
		{
			ClearUI();
			return;
		}
		T_ItemSO selectedItem = sortingOutput.GetSelectedItem();
		if (selectedItem == null)
		{
			ClearUI();
			return;
		}
		UpdateItemInfo(selectedItem);
		UpdateState();
	}

	private void OnSelectedItemChanged(T_ItemSO item)
	{
		if (item != null && itemIcon != null)
		{
			itemIcon.sprite = item.Icon;
			itemIcon.enabled = item.Icon != null;
		}
		UpdateUI();
	}

	private void OnItemCountChanged(int count)
	{
		if (!(sortingOutput == null))
		{
			if (sortingOutput.GetSelectedItem() == null)
			{
				ClearUI();
			}
			else if (itemCount != null)
			{
				itemCount.text = $"{count}";
			}
		}
	}

	private void UpdateItemInfo(T_ItemSO item)
	{
		if (item == null)
		{
			SetActiveDroppingContainer(active: false);
			return;
		}
		SetActiveDroppingContainer(active: true);
		if (itemIcon != null)
		{
			itemIcon.sprite = item.Icon;
			itemIcon.enabled = item.Icon != null;
		}
		if (itemName != null)
		{
			string translation = LocalizationManager.GetTranslation(item.Name);
			itemName.text = ((!string.IsNullOrEmpty(translation)) ? translation : item.Name);
		}
		if (itemCount != null)
		{
			int selectedItemCount = sortingOutput.GetSelectedItemCount();
			itemCount.text = $"{selectedItemCount}";
		}
	}

	private void UpdateState()
	{
		if (!(sortingOutput == null))
		{
			bool outputRunningState = sortingOutput.GetOutputRunningState();
			SetOutputRunningState(outputRunningState);
			float outputProgress = sortingOutput.GetOutputProgress();
			SetOutputProgress(outputProgress);
		}
	}

	private void SetActiveDroppingContainer(bool active)
	{
		if (droppingContainer != null)
		{
			droppingContainer.SetActive(active);
		}
	}

	private void ClearUI()
	{
		if (itemIcon != null)
		{
			itemIcon.sprite = null;
			itemIcon.enabled = false;
		}
		if (itemName != null)
		{
			itemName.text = "";
		}
		if (itemCount != null)
		{
			itemCount.text = "0";
		}
		SetActiveDroppingContainer(active: false);
		SetOutputRunningState(running: false);
		SetOutputProgress(0f);
	}

	private void SetOutputRunningState(bool running)
	{
		if (running != _lastRunning)
		{
			_lastRunning = running;
			if (startUI != null)
			{
				startUI.SetActive(!running);
			}
			if (stopUI != null)
			{
				stopUI.SetActive(running);
			}
		}
	}

	private void SetOutputProgress(float normalized)
	{
		normalized = Mathf.Clamp01(normalized);
		if (progressFill != null)
		{
			progressFill.fillAmount = normalized;
		}
		if (progressValue != null)
		{
			int num = Mathf.RoundToInt(normalized * 100f);
			if (num != _lastPercent)
			{
				_lastPercent = num;
				progressValue.text = num + " %";
			}
		}
	}

	public void OnStartButtonClicked()
	{
		if (sortingOutput == null)
		{
			return;
		}
		if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"));
			}
			return;
		}
		T_ItemSO selectedItem = sortingOutput.GetSelectedItem();
		if (!(selectedItem == null))
		{
			sortingOutput.HandleOutputStartButton(selectedItem);
		}
	}

	public void SpawnSack()
	{
		if (sortingOutput == null)
		{
			return;
		}
		T_ItemSO selectedItem = sortingOutput.GetSelectedItem();
		if (selectedItem == null)
		{
			return;
		}
		int selectedItemCount = sortingOutput.GetSelectedItemCount();
		if (selectedCount <= 0 || selectedCount > selectedItemCount)
		{
			return;
		}
		if (NetworkClient.localPlayer != null && GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
			if (pickupItem != null)
			{
				T_Pickup component = pickupItem.GetComponent<T_Pickup>();
				if (component != null && (component.itemType == ItemType.Building || component.itemType == ItemType.Pickup))
				{
					GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NotPickupAvailable"));
					return;
				}
			}
		}
		sortingOutput.RequestSpawnSack(selectedItem, selectedCount);
	}
}
