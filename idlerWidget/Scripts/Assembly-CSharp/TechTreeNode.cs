using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.World;
using UnityEngine;

public class TechTreeNode : MonoBehaviour, ITooltipTitleSource, ITooltipCustomSource
{
	public delegate void OnTechNodeActivate(GamePlayer ply, TechNode node);

	[SerializeField]
	private SpriteRenderer _button;

	[SerializeField]
	private SpriteRenderer _icon;

	[SerializeField]
	private SpriteRenderer _underConstruction;

	[SerializeField]
	private SpriteRenderer _highlight;

	[SerializeField]
	private SpriteRenderer _purchased;

	[SerializeField]
	private SpriteRenderer _glow;

	[SerializeField]
	private Sprite _lockedSprite;

	[SerializeField]
	private Sprite _placementTechBorder;

	public TechNode Node;

	private bool _active = true;

	private ConstructionProgress _construction;

	private float _glowProgress;

	private float _glowScale = 1f;

	private Color _glowColor;

	private void Start()
	{
		_glowColor = _glow.color;
		if (Node.NodeType == TechNodeType.Frame)
		{
			foreach (FramePrefabSet orderedFramePrefab in WorldManager.Instance.OrderedFramePrefabs)
			{
				if (orderedFramePrefab.GetPreview().RequiredTech == Node)
				{
					_button.sprite = orderedFramePrefab.OverviewSprite;
					break;
				}
			}
		}
		else if (Node.NodeType == TechNodeType.Placement)
		{
			_button.sprite = _placementTechBorder;
		}
		if (Node.NodeType == TechNodeType.Frame || Node.NodeType == TechNodeType.Placement)
		{
			_glowScale = 1.2f;
			_highlight.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
		}
		UpdateStatus();
	}

	private void Update()
	{
		if (_glow.gameObject.activeSelf)
		{
			_glowProgress += Time.deltaTime;
			float num = Mathf.Sin(_glowProgress / 2f);
			float num2 = Mathf.Sin(_glowProgress);
			_glow.transform.localEulerAngles = new Vector3(0f, 0f, num * 5f);
			_glow.transform.localScale = new Vector3(_glowScale + num2 / 20f, _glowScale + num2 / 20f, 1f);
			_glow.color = new Color(_glowColor.r, _glowColor.g, _glowColor.b, _glowColor.a - num2 / 10f);
		}
	}

	private void OnDisable()
	{
		_highlight.gameObject.SetActive(value: false);
	}

	public void UpdateStatus()
	{
		if (Node != null)
		{
			_construction = GamePlayer.Current.GetTechConstruction(Node);
			_icon.sprite = (Node.IsAvailable ? Node.Icon : _lockedSprite);
			_underConstruction.gameObject.SetActive(_construction != null);
			Material material = (Node.IsAvailable ? Materials.Default : Materials.Grayscale);
			_button.material = material;
			_icon.material = material;
			_purchased.gameObject.SetActive(Node.IsPurchased);
			_glow.gameObject.SetActive(Node.IsAvailable && !Node.IsPurchased);
			if (Node.IsPurchased)
			{
				_active = false;
			}
			else
			{
				SetActive(Node.IsAvailable);
			}
		}
	}

	public void SetActive(bool active)
	{
		_active = active;
	}

	public string GetTooltipTitle()
	{
		return Node.Name;
	}

	public void AddTooltipCustomContent(UITooltip tooltip)
	{
		if (_active || Node.IsPurchased)
		{
			_addActiveTooltipContent(tooltip);
		}
		else if (Node.Tier > 3)
		{
			tooltip.AddTextLine("Unlocks in the full game.");
		}
		else if (Node.Tier > GamePlayer.Current.TechTier)
		{
			tooltip.AddTextLine("Unlocks at tier " + Node.Tier + ".");
		}
		else
		{
			tooltip.AddTextLine("Requires " + Node.Previous.Name + ".");
		}
	}

	private void _addActiveTooltipContent(UITooltip tooltip)
	{
		string text = Node.NodeType switch
		{
			TechNodeType.Frame => "Unlocks new Frame:", 
			TechNodeType.Upgrade => "Unlocks new Upgrade:", 
			_ => "", 
		};
		if (!string.IsNullOrEmpty(text))
		{
			tooltip.AddTextLine(text);
		}
		tooltip.AddTextLine(Node.Description);
		if (Node.IsPurchased)
		{
			tooltip.AddTextLine("<color=green>Technology unlocked!</color>");
		}
		else if (_construction != null)
		{
			tooltip.AddTextLine(UIHelper.HighlightText("Right-click") + " to cancel.");
			tooltip.AddConstructionLines(_construction);
		}
		else
		{
			tooltip.AddCostLines(Node.GetCost());
		}
	}

	private void OnMouseEnter()
	{
		if (_active)
		{
			_highlight.gameObject.SetActive(value: true);
		}
	}

	private void OnMouseExit()
	{
		_highlight.gameObject.SetActive(value: false);
	}

	private void OnMouseUpAsButton()
	{
		if (_active && _construction == null)
		{
			UISounds.Button();
			GamePlayer.Current.StartTechConstruction(Node);
			TechTreeNode[] componentsInChildren = base.transform.parent.GetComponentsInChildren<TechTreeNode>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].UpdateStatus();
			}
			UITooltip.Refresh();
		}
	}

	private void OnMouseOver()
	{
		if (_construction != null && PlayerControls.InputCancel)
		{
			GamePlayer.Current.CancelTechConstruction(Node);
			UITooltip.Refresh();
		}
	}
}
