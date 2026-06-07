using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button_StartWave : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private UI_HoldableButton button;

	[SerializeField]
	private Image image_HoldButtonProgress;

	private float holdSpaceTimer;

	private float holdSpaceToBattleTime;

	private bool isUIOn;

	private bool isHoldingSpace;

	private float holdSoundInterval;

	private float holdSoundTimer;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void UpdateHoldButtonImage(float t)
	{
	}

	private void OnBattleStart()
	{
	}

	private void OnBattleEnd()
	{
	}

	private void OnShowCommonIngameUI()
	{
	}

	private void OnHideCommonIngameUI()
	{
	}

	private void OnButtonDown()
	{
	}

	private void OnHoldButton()
	{
	}

	private void OnButtonUp()
	{
	}

	private void Toggle(bool isOn)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
