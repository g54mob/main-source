using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private LocalizedString header;

	[SerializeField]
	private LocalizedString content;

	[SerializeField]
	private GameObject controllerHelperObject;

	[SerializeField]
	public TextMeshProUGUI displayOnlyTxt;

	public event Action<TooltipTrigger> PointerEntered;

	private void Awake()
	{
		if (controllerHelperObject != null)
		{
			TooltipControllerHelper tooltipControllerHelper = controllerHelperObject.AddComponent<TooltipControllerHelper>();
			tooltipControllerHelper.OnSelected += ControllerSelect;
			tooltipControllerHelper.OnDeselected += ControllerDeselect;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		this.PointerEntered?.Invoke(this);
		if (displayOnlyTxt != null)
		{
			displayOnlyTxt.text = content.GetLocalizedString();
		}
		else
		{
			TooltipSystem.Instance.Show(content.GetLocalizedString(), header.GetLocalizedString(), base.gameObject);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		TooltipSystem.Instance.Hide();
	}

	private void OnDisable()
	{
		TooltipSystem.Instance.Hide();
	}

	private void OnDestroy()
	{
		TooltipSystem.Instance.Hide();
	}

	private void ControllerSelect()
	{
		if (InputManager.Instance.IsLastInputGamepad)
		{
			TooltipSystem.Instance.Show(content.GetLocalizedString(), header.GetLocalizedString(), base.gameObject);
		}
	}

	private void ControllerDeselect()
	{
		if (InputManager.Instance.IsLastInputGamepad)
		{
			TooltipSystem.Instance.Hide();
		}
	}
}
