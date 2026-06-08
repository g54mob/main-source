using UnityEngine;

public class UniverseNodeObject : MonoBehaviour
{
	public delegate void KeyPressedDelegate(UniverseNode node);

	public KeyPressedDelegate shortcutPressed;

	public UITextLabel keyUI;

	private bool _mouseIsOverMe;

	private Rect posRect = default(Rect);

	private KeyCode shortcutKey;

	public UniverseNode node { get; set; }

	public bool IsDisabled { get; private set; }

	public Vector3 initialScale { get; private set; }

	private void Awake()
	{
		initialScale = base.transform.localScale;
	}

	private void OnDestroy()
	{
		keyUI = null;
	}

	private void Update()
	{
		if (GalaxyMapManager.Instance.CurrentMapState == GalaxyMapState.Universe && shortcutKey != KeyCode.None && Input.GetKeyDown(shortcutKey) && (MenuPanelUI.Instance == null || !MenuPanelUI.Instance.gameObject.activeSelf) && (ObjectivesUI.Instance == null || !ObjectivesUI.Instance.IsShowing) && shortcutPressed != null)
		{
			shortcutPressed(node);
		}
	}

	public void Refresh()
	{
		if (!node.IsSelected || (UniverseMapManager.Instance != null && UniverseMapManager.Instance.IsInSnapshotMode))
		{
			GetComponent<Renderer>().material = UniverseMapManager.NodeMaterialNormal;
			if (_mouseIsOverMe)
			{
				base.transform.localScale = initialScale * 2f;
			}
			else
			{
				base.transform.localScale = initialScale;
			}
		}
		else
		{
			GetComponent<Renderer>().material = UniverseMapManager.NodeMaterialSelected;
			if (_mouseIsOverMe)
			{
				base.transform.localScale = initialScale * 4f;
			}
			else
			{
				base.transform.localScale = initialScale * 2f;
			}
		}
		Color color = GetComponent<Renderer>().material.color;
		color.a = 0.5f;
		keyUI.label.color = color;
		keyUI.gameObject.SetActive(true);
		if (base.transform.localScale.x == 20f)
		{
			keyUI.gameObject.transform.localScale = new Vector3(0.0125f, 0.0125f, 0.0125f);
		}
		else if (base.transform.localScale.x == 10f)
		{
			keyUI.gameObject.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
		}
		else
		{
			keyUI.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
		}
	}

	public void Disable()
	{
		IsDisabled = true;
	}

	public void Enable()
	{
		IsDisabled = false;
	}

	private void OnGUI()
	{
		if (GlobalSettings.IsGamePaused)
		{
			return;
		}
		bool flag = false;
		if (UniverseMapManager.Instance != null && !UniverseMapManager.Instance.IsJumpingToGalaxy)
		{
			if (UniverseMapManager.Instance.IsInTravelMode)
			{
				if (!GalaxyMapManager.Instance.HideOverlays && !UniverseMapManager.Instance.IsInSnapshotMode && ((UniverseMapManager.Instance.highlightedTravelNode != null && UniverseMapManager.Instance.highlightedTravelNode.InternalID == node.InternalID) || (UniverseMapManager.Instance.selectedTravelNode != null && UniverseMapManager.Instance.highlightedTravelNode == null && UniverseMapManager.Instance.selectedTravelNode.InternalID == node.InternalID)))
				{
					if (_mouseIsOverMe && UniverseMapManager.Instance.selectedTravelNode.InternalID != node.InternalID)
					{
						float x = Event.current.mousePosition.x;
						float y = Event.current.mousePosition.y;
						posRect = new Rect(x + 10f, y + 5f, 90f, 30f);
					}
					else
					{
						Vector3 position = base.transform.position;
						position.z *= -1f;
						Vector3 vector = GalaxyMapManager.Instance.guiCamera.WorldToScreenPoint(position);
						int num = Screen.height / 2;
						posRect = new Rect(vector.x, (float)Screen.height - vector.y, 90f, 30f);
						posRect.x -= 45f;
						posRect.y += 22f;
					}
					flag = true;
				}
			}
			else if (UniverseMapManager.Instance.selectedViewNode != null && node.InternalID == UniverseMapManager.Instance.selectedViewNode.InternalID)
			{
				if (_mouseIsOverMe && UniverseMapManager.Instance.selectedViewNode.InternalID != node.InternalID)
				{
					float x2 = Event.current.mousePosition.x;
					float y2 = Event.current.mousePosition.y;
					posRect = new Rect(x2 + 10f, y2 + 5f, 90f, 30f);
				}
				else
				{
					Vector3 position2 = base.transform.position;
					position2.z *= -1f;
					Vector3 vector2 = GalaxyMapManager.Instance.guiCamera.WorldToScreenPoint(position2);
					int num2 = Screen.height / 2;
					posRect = new Rect(vector2.x, (float)Screen.height - vector2.y, 90f, 30f);
					posRect.x -= 45f;
					posRect.y += 22f;
				}
				flag = true;
			}
			else if (_mouseIsOverMe && (DialogUI.Instance == null || !DialogUI.Instance.IsShowing))
			{
				float x3 = Event.current.mousePosition.x;
				float y3 = Event.current.mousePosition.y;
				posRect = new Rect(x3 + 10f, y3 + 5f, 90f, 30f);
				flag = true;
			}
		}
		else if (_mouseIsOverMe)
		{
			float x4 = Event.current.mousePosition.x;
			float y4 = Event.current.mousePosition.y;
			posRect = new Rect(x4 + 10f, y4 + 5f, 90f, 30f);
			flag = true;
		}
		if (flag)
		{
			if (posRect.x + posRect.width > (float)Screen.width)
			{
				posRect.x -= posRect.x + posRect.width - (float)Screen.width;
			}
			if (posRect.y + posRect.height > (float)Screen.height)
			{
				posRect.y -= posRect.y + posRect.height - (float)Screen.height;
			}
			posRect.x += 5f;
			posRect.y += 5f;
			posRect.width -= 10f;
			posRect.height -= 25f;
		}
	}

	private void OnMouseEnter()
	{
		if (node != null && !IsDisabled && GlobalSettings.cheatMode && node.IsVisible && !GlobalSettings.IsGamePaused)
		{
			_mouseIsOverMe = true;
			if (UniverseMapManager.Instance.IsInTravelMode)
			{
				UniverseMapManager.Instance.ClearHighlightedPath();
				UniverseMapManager.Instance.HighlightPathToNode(node);
				base.transform.localScale = initialScale * 4f;
			}
			else if (node.IsSelected)
			{
				base.transform.localScale = initialScale * 4f;
			}
			else
			{
				base.transform.localScale = initialScale * 2f;
			}
		}
	}

	private void OnMouseExit()
	{
		if (node != null && !IsDisabled && GlobalSettings.cheatMode && node.IsVisible && !GlobalSettings.IsGamePaused)
		{
			_mouseIsOverMe = false;
			if (UniverseMapManager.Instance.IsInTravelMode)
			{
				UniverseMapManager.Instance.ClearPathToNode(node, true, true);
			}
			else if (!node.IsSelected)
			{
				base.transform.localScale = initialScale;
			}
			else
			{
				base.transform.localScale = initialScale * 2f;
			}
		}
	}

	private void OnMouseUp()
	{
		if (GlobalSettings.cheatMode && UniverseMapManager.Instance.IsInTravelMode && !IsDisabled && _mouseIsOverMe)
		{
			Refresh();
			if (UniverseMapManager.Instance.selectedTravelNode != node)
			{
				UniverseMapManager.Instance.SelectNode(node);
			}
			else
			{
				UniverseMapManager.Instance.DeselectNode();
			}
		}
	}

	private void OnMouseDown()
	{
		if (GlobalSettings.cheatMode && UniverseMapManager.Instance.IsInTravelMode && !IsDisabled)
		{
			GetComponent<Renderer>().material = UniverseMapManager.NodeMaterialMouseDown;
		}
	}

	public void SetShortcutKey(KeyCode key)
	{
		if (keyUI != null)
		{
			keyUI.label.text = "[" + key.ToString() + "]";
		}
		shortcutKey = key;
	}

	public void HideShortcut()
	{
		keyUI.gameObject.SetActive(false);
	}

	public void ShowShortcut()
	{
		keyUI.gameObject.SetActive(true);
	}
}
