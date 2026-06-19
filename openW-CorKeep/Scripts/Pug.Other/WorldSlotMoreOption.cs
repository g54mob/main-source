using Pug.UnityExtensions;
using UnityEngine;

public class WorldSlotMoreOption : RadicalMainMenuOption
{
	public WorldSlot worldSlot;

	public Animator animator;

	public SpriteRenderer icon;

	public SpriteRenderer icon2;

	public SpriteRenderer icon3;

	public SpriteRenderer background;

	public SpriteRenderer selectBackground;

	public SpriteRenderer notificationIcon;

	[HideInInspector]
	public SelectWorldMenu selectWorldMenu;

	private int saveFileId;

	private Transform parentTransform;

	private string _tooltipText;

	public override TextAndFormatFields GetHoverTitle()
	{
		if (_tooltipText == null)
		{
			return null;
		}
		return new TextAndFormatFields
		{
			text = _tooltipText
		};
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR;
	}

	public void Init(SelectWorldMenu _selectWorldMenu, int _saveFileId)
	{
		selectWorldMenu = _selectWorldMenu;
		saveFileId = _saveFileId;
		SetNotification(notificationActive: false);
		_tooltipText = null;
	}

	protected override void Awake()
	{
		base.enabled = false;
		selectBackground.enabled = false;
		SetIconSelectedColor(_selected: false);
		animator.updateMode = AnimatorUpdateMode.UnscaledTime;
		parentTransform = base.transform.parent.transform;
		base.Awake();
	}

	public void SetNotification(bool notificationActive)
	{
		notificationIcon.gameObject.SetActive(notificationActive);
	}

	public void SetTooltip(string tooltipText)
	{
		_tooltipText = tooltipText;
	}

	private void SetIconSelectedColor(bool _selected)
	{
		icon.SetAlpha(_selected ? 1f : 0.33f);
		icon2.SetAlpha(_selected ? 1f : 0.33f);
		icon3.SetAlpha(_selected ? 1f : 0.33f);
	}

	public override void OnActivated()
	{
		Manager.saves.SetWorldId(saveFileId);
		Manager.menu.PushMenu(RadicalMenu.MenuType.WORLD_SETTINGS);
		base.OnActivated();
	}

	public override void OnSelected()
	{
		animator.SetTrigger("select");
		selectBackground.enabled = true;
		SetIconSelectedColor(_selected: true);
		selectWorldMenu.GetScrollWindow().MoveScrollToIncludePosition(parentTransform.localPosition.y, 1f);
		base.OnSelected();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		animator.SetTrigger("select");
		selectBackground.enabled = false;
		SetIconSelectedColor(_selected: false);
		base.OnDeselected(playEffect);
	}

	public void SetEnabled(bool _enabled)
	{
		base.enabled = _enabled;
		icon.enabled = _enabled;
		icon2.enabled = _enabled;
		icon3.enabled = _enabled;
		background.enabled = _enabled;
	}
}
