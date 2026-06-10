using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PinnedQuickMenuController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("Components")]
	public List<CanvasRenderer> renderers;

	public PinnedItemController parentPinned;

	public ButtonController locateOnMapButton;

	public ButtonController plotRouteButton;

	public ButtonController toggleCollapseButton;

	public ButtonController toggleCrossOutButton;

	public ButtonController stickyNoteButton;

	public ButtonController newLinkButton;

	public ButtonController contextMenuButton;

	public List<ButtonController> activeButtons;

	[Header("State")]
	public bool isOver;

	public bool active;

	public float appearProgress;

	public void Setup(PinnedItemController newParent)
	{
	}

	public void Remove(bool instant = false)
	{
	}

	private void Update()
	{
	}

	public void LocateOnMapButton()
	{
	}

	public void PlotRouteButton()
	{
	}

	public void ToggleCollapseButton()
	{
	}

	public void ToggleCrossOutButton()
	{
	}

	public void StickyNoteButton()
	{
	}

	public void NewLinkButton()
	{
	}

	public void ContextMenuButton()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
