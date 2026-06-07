using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicSlot : MonoBehaviour
{
	private TMP_Text logicNameText;

	private Button deleteButton;

	private Toggle logicSlotToggle;

	private LogicSlotDragHandler logicSlotDragHandler;

	private Image slotImage;

	private CanvasGroup canvasGroup;

	private WaitForEndOfFrame waitForEndOfFrame;

	public Logic Logic { get; private set; }

	public event Action OnDeleteButtonEvent;

	public event Action<bool> OnToggleChangedEvent;

	public event Action<bool> OnSlotBeginOrEndDragEvent;

	public event Action<int, int> OnSlotPositionChangedEvent;

	private void Awake()
	{
		logicNameText = base.transform.FindComponent<TMP_Text>("LogicNameText", isRecursively: true);
		deleteButton = base.transform.FindComponent<Button>("DeleteButton", isRecursively: true);
		logicSlotToggle = GetComponent<Toggle>();
		logicSlotDragHandler = GetComponent<LogicSlotDragHandler>();
		slotImage = GetComponent<Image>();
		canvasGroup = GetComponent<CanvasGroup>();
		deleteButton.onClick.AddListener(delegate
		{
			this.OnDeleteButtonEvent?.Invoke();
		});
		logicSlotToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			deleteButton.gameObject.SetActive(isOn);
			this.OnToggleChangedEvent?.Invoke(isOn);
		});
		logicSlotDragHandler.OnBeginDragEvent += delegate
		{
			this.OnSlotBeginOrEndDragEvent?.Invoke(obj: true);
		};
		logicSlotDragHandler.OnEndDragEvent += delegate
		{
			this.OnSlotBeginOrEndDragEvent?.Invoke(obj: false);
		};
		logicSlotDragHandler.OnLogicSlotPositionChangedEvent += delegate(int oldIndex, int newIndex)
		{
			this.OnSlotPositionChangedEvent?.Invoke(oldIndex, newIndex);
		};
		waitForEndOfFrame = new WaitForEndOfFrame();
	}

	public void Initialize(Logic logic, ToggleGroup toggleGroup)
	{
		Logic = logic;
		logicNameText.SetText(logic.Name);
		SetActiveState(logic.Active);
		deleteButton.gameObject.SetActive(value: false);
		logicSlotToggle.group = toggleGroup;
		logicSlotToggle.isOn = false;
	}

	public void BlinkSlot()
	{
		canvasGroup.alpha = 0f;
		StartCoroutine(BlinkSlotUpdate());
		IEnumerator BlinkSlotUpdate()
		{
			while (canvasGroup.alpha < 1f)
			{
				canvasGroup.alpha += Time.deltaTime * 4f;
				yield return waitForEndOfFrame;
			}
		}
	}

	public void SelectSlot()
	{
		logicSlotToggle.isOn = true;
	}

	public void RefreshSlot()
	{
		logicNameText.SetText(Logic.Name);
	}

	public void SetActiveState(bool isActive)
	{
		logicNameText.color = (isActive ? Util.HexToColor("#FFFFFF") : Util.HexToColor("#787878"));
	}

	public void SetSlotHighlight(bool isHighlighted)
	{
		slotImage.color = (isHighlighted ? Util.HexToColor("#323335FF") : Util.HexToColor("#212224FF"));
	}
}
