using Pug.UnityExtensions;
using UnityEngine;

public class VanityUI : InventoryUI
{
	public PlayerController playerPreview;

	public GameObject root;

	public override int MAX_ROWS => 1;

	public override int MAX_COLUMNS => 3;

	protected override void Awake()
	{
		base.Awake();
		Hide();
	}

	public override void Init()
	{
		if (initDone)
		{
			return;
		}
		base.visibleRows = MAX_ROWS;
		base.visibleColumns = MAX_COLUMNS;
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			itemSlot.Init(this);
		}
		initDone = true;
	}

	public void Show()
	{
		UpdateCharacterCustomization();
		Update();
		root.SetActive(value: true);
	}

	public void Hide()
	{
		root.SetActive(value: false);
	}

	private void Update()
	{
		if (Manager.main.player != null && root.activeSelf)
		{
			playerPreview.animator.SetFloat(898384463, Direction.back.vec2.x);
			playerPreview.animator.SetFloat(1116435161, Direction.back.vec2.y);
		}
	}

	public void UpdateCharacterCustomization()
	{
		playerPreview.activeCustomization = Manager.main.player.activeCustomization;
		playerPreview.RefreshCustomization();
	}
}
