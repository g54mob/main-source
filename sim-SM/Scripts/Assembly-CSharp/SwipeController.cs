using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour, IEndDragHandler, IEventSystemHandler
{
	[SerializeField]
	private int maxPage;

	private int currentPage;

	private Vector3 targetPos;

	[SerializeField]
	private Vector3 m_PageStep;

	[SerializeField]
	private RectTransform m_LevelPagesRect;

	[SerializeField]
	private float m_TweenTime;

	[SerializeField]
	private float m_DragThreshold;

	[SerializeField]
	private Ease m_Easetype;

	[SerializeField]
	private Button m_PreviousBtn;

	[SerializeField]
	private Button m_NextBtn;

	private void Awake()
	{
	}

	public void Next()
	{
	}

	public void Previous()
	{
	}

	public void MoveItem()
	{
	}

	public void UpdateArrowButton()
	{
	}

	public void OnEndDrag(PointerEventData eventData)
	{
	}
}
