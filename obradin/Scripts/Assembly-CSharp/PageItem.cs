using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PageItem : MonoBehaviour, IMoveHandler, IEventSystemHandler
{
	[Serializable]
	public class Cache
	{
		public Text textComponent;

		public Image image;

		public Image childImage;

		public RawImage rawImage;

		public Button buttonComponent;

		public LayoutGroup layoutGroup;

		public Folio folio;

		public RectTransform rt;

		public TextFitter textFitter;

		public TextUnveiler textUnveiler;

		public bool inPopup;
	}

	public enum ButtonSide
	{
		None = 0,
		Left = 1,
		Right = 2
	}

	[Serializable]
	public class ButtonSettings
	{
		public string actionId;

		public ButtonSide side;

		public int priority;

		public bool manualNavigation;

		public string soundId;
	}

	public string id;

	public string staticStringId;

	public ButtonSettings buttonSettings;

	[Readonly]
	public Cache cache;

	[Readonly]
	public GameObject hostGo;

	[HideInInspector]
	public bool touched;

	private PageTemplateHost host;

	public bool visible
	{
		set
		{
			base.gameObject.SetActive(value);
			touched = value;
		}
	}

	public string text
	{
		set
		{
			cache.textComponent.text = value;
			touched = true;
		}
	}

	public Sprite sprite
	{
		set
		{
			cache.image.sprite = value;
			if (value != null)
			{
				touched = true;
			}
		}
	}

	public Sprite childSprite
	{
		set
		{
			cache.childImage.sprite = value;
			if (value != null)
			{
				touched = true;
			}
		}
	}

	public Material material
	{
		set
		{
			cache.image.material = value;
			touched = true;
		}
	}

	public Vector2 position
	{
		set
		{
			cache.rt.anchoredPosition = value;
			touched = true;
		}
	}

	public float rotation
	{
		set
		{
			cache.rt.localRotation = Quaternion.Euler(0f, 0f, value);
			touched = true;
		}
	}

	public RectTransform rt
	{
		get
		{
			return cache.rt;
		}
	}

	public Rect uvRect
	{
		set
		{
			cache.rawImage.uvRect = value;
			touched = true;
		}
	}

	public float textUnveilT
	{
		set
		{
			cache.textUnveiler.unveilT = value;
			cache.textComponent.enabled = false;
			cache.textComponent.enabled = true;
			touched = true;
		}
	}

	public Folio folio
	{
		get
		{
			touched = true;
			return cache.folio;
		}
	}

	public bool textFitterEnabled
	{
		set
		{
			if (cache.textFitter != null)
			{
				cache.textFitter.enabled = value;
			}
			touched = true;
		}
	}

	public float width
	{
		set
		{
			cache.rt.sizeDelta = new Vector2(value, cache.rt.sizeDelta.y);
			touched = true;
		}
	}

	public Font font
	{
		set
		{
			if (cache.textComponent.font != value)
			{
				cache.textComponent.font = value;
			}
			touched = true;
		}
	}

	public bool isButton
	{
		get
		{
			return cache.buttonComponent != null;
		}
	}

	public Selectable selectable
	{
		get
		{
			return cache.buttonComponent;
		}
	}

	public bool canSelect
	{
		get
		{
			return selectable.isActiveAndEnabled;
		}
		set
		{
			selectable.enabled = value;
			if (cache.textComponent != null)
			{
				Color color = cache.textComponent.color;
				color.a = ((!value) ? 0.5f : 1f);
				cache.textComponent.color = color;
			}
		}
	}

	public float imageRadialFill
	{
		set
		{
			cache.image.fillAmount = value;
			touched = true;
		}
	}

	public bool isStaticText
	{
		get
		{
			return cache.textComponent != null && staticStringId.HasValue();
		}
	}

	public void Init(GameObject hostGo_)
	{
		hostGo = hostGo_;
		PageItemPrefixer componentInParentAnyActive = this.GetComponentInParentAnyActive<PageItemPrefixer>();
		if (componentInParentAnyActive != null)
		{
			string combinedPrefix = componentInParentAnyActive.combinedPrefix;
			if (!string.IsNullOrEmpty(id))
			{
				id = combinedPrefix + id;
			}
			if (!string.IsNullOrEmpty(buttonSettings.actionId))
			{
				buttonSettings.actionId = combinedPrefix + buttonSettings.actionId;
			}
		}
		cache = new Cache();
		cache.rt = base.transform as RectTransform;
		cache.textComponent = GetComponent<Text>();
		cache.image = GetComponent<Image>();
		cache.buttonComponent = GetComponent<Button>();
		cache.rawImage = GetComponent<RawImage>();
		cache.layoutGroup = GetComponent<LayoutGroup>();
		cache.folio = GetComponent<Folio>();
		cache.textFitter = GetComponent<TextFitter>();
		cache.inPopup = base.gameObject.GetComponentInParentAnyActive<Popup>() != null;
		Image[] componentsInChildren = GetComponentsInChildren<Image>();
		foreach (Image image in componentsInChildren)
		{
			if (!(image == cache.image))
			{
				cache.childImage = image;
				break;
			}
		}
		if (cache.textComponent == null)
		{
			cache.textComponent = GetComponentInChildren<Text>(true);
		}
		if (cache.textComponent != null)
		{
			cache.textUnveiler = cache.textComponent.GetComponent<TextUnveiler>();
		}
	}

	private void Start()
	{
		if (hostGo != null)
		{
			host = hostGo.GetComponent<PageTemplateHost>();
		}
		if (cache.buttonComponent != null)
		{
			cache.buttonComponent.onClick.AddListener(OnClick);
		}
	}

	private void OnClick()
	{
		if (!Monitor.blackingOut)
		{
			host.OnPageButtonClick(this);
		}
	}

	public Selectable GetOppositeSelectable()
	{
		if (buttonSettings.side == ButtonSide.Left)
		{
			return cache.buttonComponent.navigation.selectOnRight;
		}
		if (buttonSettings.side == ButtonSide.Right)
		{
			return cache.buttonComponent.navigation.selectOnLeft;
		}
		return null;
	}

	public void OnMove(AxisEventData eventData)
	{
		if (buttonSettings.manualNavigation)
		{
			return;
		}
		if (cache.inPopup)
		{
			Navigation navigation = cache.buttonComponent.navigation;
			Selectable selectable = null;
			if (eventData.moveDir == MoveDirection.Left || eventData.moveDir == MoveDirection.Right)
			{
				Selectable neighbor = SelectionHelper.GetNeighbor(navigation, eventData.moveDir);
				if (neighbor != null && !SelectionHelper.CanSelect(neighbor))
				{
					selectable = SelectionHelper.GetFirstSelectableNeighbor(neighbor.navigation, MoveDirection.Down);
					if (selectable == null)
					{
						selectable = SelectionHelper.GetFirstSelectableNeighbor(neighbor.navigation, MoveDirection.Up);
					}
				}
			}
			else if (eventData.moveDir == MoveDirection.Up || eventData.moveDir == MoveDirection.Down)
			{
				selectable = SelectionHelper.GetFirstSelectableNeighbor(navigation, eventData.moveDir);
			}
			if (selectable != null)
			{
				SelectionHelper.SetCurrent(selectable);
				eventData.Use();
			}
		}
		else if (eventData.moveDir == MoveDirection.Left)
		{
			if (buttonSettings.side == ButtonSide.Left)
			{
				host.MoveOffPage(-1, this);
			}
			else if (buttonSettings.side == ButtonSide.Right)
			{
				Selectable firstSelectableNeighbor = SelectionHelper.GetFirstSelectableNeighbor(cache.buttonComponent.navigation, MoveDirection.Left);
				if (firstSelectableNeighbor != null)
				{
					SelectionHelper.SetCurrent(firstSelectableNeighbor);
					eventData.Use();
				}
				else
				{
					host.MoveOffPage(-1, this);
				}
			}
		}
		else if (eventData.moveDir == MoveDirection.Right)
		{
			if (buttonSettings.side == ButtonSide.Right)
			{
				host.MoveOffPage(1, this);
			}
			else if (buttonSettings.side == ButtonSide.Left)
			{
				Selectable firstSelectableNeighbor2 = SelectionHelper.GetFirstSelectableNeighbor(cache.buttonComponent.navigation, MoveDirection.Right);
				if (firstSelectableNeighbor2 != null)
				{
					SelectionHelper.SetCurrent(firstSelectableNeighbor2);
					eventData.Use();
				}
				else
				{
					host.MoveOffPage(1, this);
				}
			}
		}
		else if (eventData.moveDir == MoveDirection.Up || eventData.moveDir == MoveDirection.Down)
		{
			Selectable firstSelectableNeighbor3 = SelectionHelper.GetFirstSelectableNeighbor(cache.buttonComponent.navigation, eventData.moveDir);
			if (firstSelectableNeighbor3 != null)
			{
				SelectionHelper.SetCurrent(firstSelectableNeighbor3);
				eventData.Use();
			}
		}
	}
}
