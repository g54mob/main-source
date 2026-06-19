using UnityEngine;

public class WorldSlotNewWorldOption : RadicalMainMenuOption
{
	public SpriteRenderer selectMarker;

	public PugText text;

	public Color selectedColor;

	public Animator animator;

	public SelectWorldMenu selectWorldMenu;

	public bool loadFromMods;

	private int saveFileId;

	protected override void Awake()
	{
		animator.updateMode = AnimatorUpdateMode.UnscaledTime;
		base.Awake();
	}

	public void Init(int saveFileId)
	{
		this.saveFileId = saveFileId;
	}

	protected override void InitClickCollider()
	{
	}

	protected override void UpdateClickCollider()
	{
	}

	public override void OnActivated()
	{
		base.OnActivated();
		Manager.saves.SetWorldId(saveFileId);
		if (loadFromMods)
		{
			Manager.menu.PushMenu(RadicalMenu.MenuType.LOAD_WORLD_FROM_MOD);
		}
		else
		{
			Manager.menu.PushMenu(RadicalMenu.MenuType.CREATE_WORLD);
		}
	}

	public override bool OnSkimLeft()
	{
		return false;
	}

	public override bool OnSkimRight()
	{
		return false;
	}

	public override void OnSelected()
	{
		selectWorldMenu.selectedOptionIndex = 0;
		animator.SetTrigger(1260321794);
		DelayedSetColor();
		Invoke("DelayedSetColor", 0.001f);
		selectMarker.gameObject.SetActive(value: true);
		selectWorldMenu.GetScrollWindow().MoveScrollToIncludePosition(base.transform.localPosition.y, 1f);
		base.OnSelected();
	}

	private void DelayedSetColor()
	{
		selectMarker.color = selectedColor;
	}

	public override void OnDeselected(bool playEffect = true)
	{
		animator.SetTrigger(-1949102368);
		SetAsInactive();
		base.OnDeselected(playEffect);
	}

	public void SetAsInactive()
	{
		selectMarker.gameObject.SetActive(value: false);
	}
}
