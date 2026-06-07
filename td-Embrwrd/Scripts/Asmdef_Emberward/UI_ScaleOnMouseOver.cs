using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ScaleOnMouseOver : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Vector3 targetScale;

	[SerializeField]
	[Header("Scale目標，如果沒有設定就使用自己")]
	private Transform scaleTarget;

	[SerializeField]
	private float duration;

	[SerializeField]
	private bool useUnscaledTime;

	[Header("當搖桿選擇時是否做一樣處理")]
	[SerializeField]
	private bool scaleOnJoystickSelect;

	[SerializeField]
	private Selectable joystickSelectable;

	private Vector3 originalScale;

	private Tweener cardMouseOverTweener;

	private Transform targetTransform => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnJoystickSelect()
	{
	}

	private void OnJoystickDeselect()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
