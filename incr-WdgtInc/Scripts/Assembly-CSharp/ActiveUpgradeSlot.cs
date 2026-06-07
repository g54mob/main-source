using Assets.Source.UI;
using Assets.Source.World;
using UnityEngine;

public class ActiveUpgradeSlot : MonoBehaviour, ITooltipTitleSource, ITooltipCustomSource, ITooltipTextSource
{
	private FrameUpgrade _upgrade;

	private ActiveWorldFrame _frame;

	private ActiveWorldAnchor _anchor;

	[SerializeField]
	private string _techName;

	[SerializeField]
	private FrameButton _purchaseButton;

	[SerializeField]
	private SpriteRenderer _icon;

	[SerializeField]
	private SpriteRenderer _inactiveContent;

	[SerializeField]
	private SpriteRenderer _activeContent;

	[SerializeField]
	private Transform _underConstructionContent;

	private ConstructionProgress _construction;

	public FrameUpgrade Upgrade
	{
		get
		{
			if (_upgrade == null)
			{
				_upgrade = FrameUpgrade.Get(_frame.ActiveFrame.Identifier, _anchor.Slot);
			}
			return _upgrade;
		}
	}

	public ConstructionProgress Construction => _construction;

	private void Awake()
	{
		_frame = GetComponentInParent<ActiveWorldFrame>();
		_anchor = GetComponent<ActiveWorldAnchor>();
		if (!_anchor)
		{
			_anchor = base.gameObject.AddComponent<ActiveWorldAnchor>();
			_anchor.SetAnchor(WorldAnchorType.Upgrade, FrameUpgrade.Get(_techName).FrameOrdinal);
		}
		_inactiveContent.sprite = _activeContent.sprite;
	}

	private void Start()
	{
		UpdateState();
	}

	public void UpdateState()
	{
		_icon.sprite = Upgrade.RequiredTech.Icon;
		if (Upgrade.IsAvailable)
		{
			_construction = _frame.ActiveFrame.GetUpgradeConstruction(Upgrade);
			_underConstructionContent.gameObject.SetActive(_construction != null);
			bool flag = _frame.ActiveFrame.HasUpgrade(Upgrade);
			_purchaseButton.gameObject.SetActive(_construction == null && !flag);
			_activeContent.gameObject.SetActive(flag);
			_inactiveContent.gameObject.SetActive(!flag);
		}
		else
		{
			_purchaseButton.gameObject.SetActive(value: false);
			_activeContent.gameObject.SetActive(value: false);
			_inactiveContent.gameObject.SetActive(value: true);
		}
	}

	public void CancelConstruction()
	{
		_frame.ActiveFrame.CancelUpgradeConstruction(Upgrade);
	}

	public string GetTooltipTitle()
	{
		return Upgrade.Name;
	}

	public string GetTooltipText()
	{
		return Upgrade.Description;
	}

	public void AddTooltipCustomContent(UITooltip tooltip)
	{
		if (!_frame.ActiveFrame.HasUpgrade(Upgrade))
		{
			tooltip.AddCostLines(Upgrade.GetCost());
		}
	}
}
