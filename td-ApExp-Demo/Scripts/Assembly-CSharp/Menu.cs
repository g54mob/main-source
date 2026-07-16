using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(GraphicRaycaster))]
public class Menu : MonoBehaviour
{
	[SerializeField]
	protected GameObject defaultSelectedGo;

	private GameObject lastSelectedGo;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private bool controlerHoverSupportOn;

	private float checkInterval = 0.5f;

	private float nextCheckTime;

	[field: Header("Menu")]
	[field: SerializeField]
	public MenuType MenuType { get; private set; }

	[field: SerializeField]
	public bool LockSortingOrder { get; private set; }

	protected virtual void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
		AddHoverTriggersToChildren();
	}

	public virtual void Init()
	{
	}

	public virtual void Open(params object[] menuArgs)
	{
		base.gameObject.SetActive(value: true);
		if (canvasGroup == null)
		{
			canvasGroup = GetComponent<CanvasGroup>();
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(base.gameObject.GetComponent<RectTransform>());
		OnOpen();
	}

	public virtual void Close()
	{
		EventSystem.current.SetSelectedGameObject(null);
		base.gameObject.SetActive(value: false);
		OnClose();
	}

	public void SetInteractivity(bool interactive)
	{
		canvasGroup.interactable = interactive;
		canvasGroup.blocksRaycasts = interactive;
		if (!interactive && EventSystem.current.currentSelectedGameObject != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	public void CacheCurrentSelection()
	{
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (currentSelectedGameObject != null && currentSelectedGameObject.activeInHierarchy)
		{
			lastSelectedGo = currentSelectedGameObject;
		}
	}

	public void ClearCachedSelection()
	{
		lastSelectedGo = null;
	}

	public GameObject GetSelectionToRestore()
	{
		if (lastSelectedGo != null && lastSelectedGo.activeInHierarchy)
		{
			return lastSelectedGo;
		}
		if (defaultSelectedGo != null && defaultSelectedGo.activeInHierarchy)
		{
			return defaultSelectedGo;
		}
		return null;
	}

	protected virtual void OnOpen()
	{
	}

	protected virtual void OnClose()
	{
	}

	private void AddHoverTriggersToChildren()
	{
		Selectable[] componentsInChildren = GetComponentsInChildren<Selectable>(includeInactive: true);
		foreach (Selectable selectable in componentsInChildren)
		{
			if (!(selectable.GetComponent<HoverSelectHandler>() != null))
			{
				selectable.gameObject.AddComponent<HoverSelectHandler>().Initialize(this);
			}
		}
	}

	public void HandleHoverSelect(GameObject selectedObject)
	{
		if (controlerHoverSupportOn)
		{
			EventSystem.current.SetSelectedGameObject(selectedObject);
			if (selectedObject.GetComponent<UnitAudioController>() != null)
			{
				selectedObject.GetComponent<UnitAudioController>().PlayOnChannel(0);
			}
		}
	}
}
