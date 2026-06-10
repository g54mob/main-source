using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
	public TileClickedEvent onTileClicked = new TileClickedEvent();

	public TileClickedEvent onTileHoverEntered = new TileClickedEvent();

	public TileClickedEvent onTileHoverExited = new TileClickedEvent();

	public GameObject bubbleEffect;

	public bool isBubbleSpot { get; private set; }

	private void Awake()
	{
		if (bubbleEffect != null)
		{
			bubbleEffect.SetActive(value: false);
		}
	}

	private void OnMouseDown()
	{
		if (!(EventSystem.current != null) || !EventSystem.current.IsPointerOverGameObject())
		{
			if (CutsceneManager.Instance != null && CutsceneManager.Instance.IsBlockingFishing)
			{
				Debug.Log("[Tile] Click blocked — cutscene is active and blocking fishing.");
			}
			else if (!EndOfGamePanel.IsVisible)
			{
				onTileClicked?.Invoke(this);
			}
		}
	}

	private void OnMouseEnter()
	{
		if ((!(CutsceneManager.Instance != null) || !CutsceneManager.Instance.IsBlockingFishing) && !EndOfGamePanel.IsVisible)
		{
			onTileHoverEntered?.Invoke(this);
		}
	}

	private void OnMouseExit()
	{
		onTileHoverExited?.Invoke(this);
	}

	public void SetBubbleSpot(bool isActive)
	{
		isBubbleSpot = isActive;
		if (bubbleEffect != null)
		{
			bubbleEffect.SetActive(isActive);
		}
	}
}
