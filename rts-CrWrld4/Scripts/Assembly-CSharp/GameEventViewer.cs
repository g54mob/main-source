using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameEventViewer : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler
{
	public GameObject rowPrefab;

	public GameObject rowContainer;

	public Toggle enemyToggle;

	public Toggle playerToggle;

	private Vector2 pointerOffset;

	private RectTransform canvasRectTransform;

	private RectTransform panelRectTransform;

	private void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void Refresh()
	{
	}

	public void OnPointerDown(PointerEventData data)
	{
	}

	public void OnDrag(PointerEventData data)
	{
	}
}
