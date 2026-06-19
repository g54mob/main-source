using UnityEngine;

public class DropdownEntry : UIelement
{
	public PugText text;

	public PugText subText;

	public DropdownUIElement dropdown;

	public DropdownEntryData entryData;

	public SpriteRenderer selectedSR;

	public SpriteRenderer activeSR;

	public SpriteRenderer background;

	private void Awake()
	{
		selectedSR.gameObject.SetActive(value: false);
	}

	public float GetTopPos()
	{
		float num = background.size.y / 2f;
		num += num % 0.0625f;
		return base.transform.position.y + num;
	}

	public float GetBottomPos()
	{
		float num = background.size.y / 2f;
		num += num % 0.0625f;
		return base.transform.position.y - num - 0.25f;
	}

	public void Init(DropdownUIElement dropdown, DropdownEntryData entryData, bool isCurrentActive)
	{
		this.entryData = entryData;
		this.dropdown = dropdown;
		text.Render(entryData.textStringToShow);
		subText.formatFields = entryData.subStringFormatFields;
		subText.Render(entryData.subtextStringToShow);
		activeSR.gameObject.SetActive(isCurrentActive);
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		base.OnLeftClicked(mod1, mod2);
		dropdown.OnEntryClicked(this);
	}

	public override void OnSelected()
	{
		base.OnSelected();
		selectedSR.gameObject.SetActive(value: true);
		dropdown.scrollWindow.MoveScrollToIncludePosition(base.transform.localPosition.y, background.size.y / 2f);
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		selectedSR.gameObject.SetActive(value: false);
	}
}
