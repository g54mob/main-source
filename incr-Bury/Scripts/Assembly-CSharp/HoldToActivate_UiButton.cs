using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class HoldToActivate_UiButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField]
	private Image fillImage;

	private float heldTime_Curr;

	[SerializeField]
	private float holdTime_Max;

	[Header("Effects")]
	[SerializeField]
	private MMF_Player onHover_Effects;

	[SerializeField]
	private MMF_Player onCompleted_Effects;

	[Header("Completed Function")]
	public UnityEvent onCompleted;

	private bool canClick;

	private bool isHolding;

	private void Start()
	{
		isHolding = false;
		canClick = true;
	}

	private void Update()
	{
		if (isHolding)
		{
			if (heldTime_Curr <= holdTime_Max)
			{
				heldTime_Curr += Time.deltaTime;
			}
			else
			{
				CompleteClick();
			}
		}
		fillImage.fillAmount = heldTime_Curr / holdTime_Max;
	}

	private void CompleteClick()
	{
		onCompleted?.Invoke();
		onCompleted_Effects?.RestoreInitialValues();
		onCompleted_Effects?.PlayFeedbacks();
		ResetClicker();
	}

	private void ResetClicker()
	{
		heldTime_Curr = 0f;
		isHolding = false;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			isHolding = true;
			canClick = false;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			ResetClicker();
			canClick = true;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		onHover_Effects?.RestoreInitialValues();
		onHover_Effects?.PlayFeedbacks();
	}
}
