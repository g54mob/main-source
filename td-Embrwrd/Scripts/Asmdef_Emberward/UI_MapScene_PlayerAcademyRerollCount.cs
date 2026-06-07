using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_MapScene_PlayerAcademyRerollCount : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private TMP_Text text_Value;

	private int curExpVaue;

	private bool isInfiniteReroll;

	private Coroutine coroutine_ValueChange;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnAcademyRerollCountChanged(int value)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
