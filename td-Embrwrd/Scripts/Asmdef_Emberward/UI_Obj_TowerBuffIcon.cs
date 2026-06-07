using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Obj_TowerBuffIcon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private Image image_BG;

	[SerializeField]
	private TMP_Text text_BuffTimeLeft;

	[SerializeField]
	private Vector3 localOffset;

	[SerializeField]
	private float mouseDetectRange;

	private float mouseDetectRangeScaled;

	private ABaseBuffSettingData curBuff;

	private Vector3 tower2Dpos;

	private ABaseTower tower;

	private Vector3 offset;

	private Vector2 cursorHotspot;

	private bool isTowerControlOn;

	private Tweener scaleTweener;

	private Vector3 iconOriginalRotation;

	private string tooltipName;

	private string tooltipContent;

	private bool isMouseOver;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTowerControlToggle(bool isOn)
	{
	}

	private void OnClickTowerOnField(ABaseTower tower)
	{
	}

	private void OnGameStateChanged(eGameState fromState, eGameState toState)
	{
	}

	public void Setup(ABaseTower tower, ABaseBuffSettingData buff)
	{
	}

	public void ShowBuffIcon()
	{
	}

	private void Update()
	{
	}

	private void OnMouseEnterRange()
	{
	}

	private void OnMouseOverRange()
	{
	}

	private void OnMouseExitRange()
	{
	}

	private void OnTowerDespawn(ABaseTower tower)
	{
	}

	private void OnBuffRemove()
	{
	}

	private void OnTimerUpdate(int time)
	{
	}

	public void Remove()
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
