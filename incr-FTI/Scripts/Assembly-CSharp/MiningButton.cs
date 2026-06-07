using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiningButton : Selectable, IDragHandler, IEventSystemHandler
{
	public Image backgroundImage;

	public Image itemIcon;

	public Image cover;

	public Image embeddedFrame;

	public Image itemCover;

	public MenuButton.ButtonDelegate pointerDownDelegate;

	public MiningMap parentMap;

	public TextMeshProUGUI debugText;

	public MiningGemInstance parentGemFormation;

	public ItemType item;

	public Coord coord;

	public bool isUnlocked;

	public bool isRevealed;

	public bool isExcavated;

	public float revealDelay;

	private Color baseCoverColor;

	private void Update()
	{
		if (revealDelay > 0f)
		{
			revealDelay -= TimeManager.MenuDelta;
			if (revealDelay <= 0f)
			{
				parentMap.OnReveal(this);
				UpdateItemIcon();
			}
		}
	}

	public void ResetState()
	{
		isUnlocked = false;
		isRevealed = false;
		isExcavated = false;
		revealDelay = 0f;
		cover.color = baseCoverColor;
		parentGemFormation = null;
		AssignItem(ItemType.None);
	}

	public void Init(int x, int y)
	{
		AddPointerDownTrigger(OnClick);
		coord = new Coord(x, y);
		baseCoverColor = cover.color;
	}

	public void AssignItem(ItemType t)
	{
		item = t;
		UpdateItemIcon();
	}

	public void UpdateItemIcon()
	{
		if (item == ItemType.None)
		{
			itemIcon.enabled = false;
		}
		else
		{
			itemIcon.enabled = true;
			itemIcon.color = MiningMap.ColorForItem(item);
			if (item == ItemType.Stone)
			{
				itemIcon.sprite = IconManager.Instance.stone;
			}
			else
			{
				itemIcon.sprite = IconManager.Instance.miningMinigameGemBlock;
			}
		}
		cover.gameObject.SetActive(!isRevealed || revealDelay > 0f);
		if (item == ItemType.Stone || item == ItemType.None)
		{
			embeddedFrame.gameObject.SetActive(!isRevealed);
			itemCover.gameObject.SetActive(value: false);
		}
		else
		{
			embeddedFrame.gameObject.SetActive(!isExcavated);
			itemCover.gameObject.SetActive(value: true);
		}
		embeddedFrame.color = (isUnlocked ? Color.yellow : Color.gray);
	}

	public void AddPointerDownTrigger(MenuButton.ButtonDelegate del)
	{
		pointerDownDelegate = del;
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);
		if (eventData.button == PointerEventData.InputButton.Left && IsActive() && IsInteractable() && EventSystem.current != null)
		{
			pointerDownDelegate?.Invoke();
		}
	}

	public void Reveal(float delay)
	{
		isRevealed = true;
		if (item == ItemType.None)
		{
			isExcavated = true;
		}
		else if (parentGemFormation != null)
		{
			parentMap.TryUnlockFormation(parentGemFormation);
		}
		if (delay <= 0f)
		{
			parentMap.OnReveal(this);
		}
		revealDelay = delay;
		UpdateItemIcon();
	}

	private void OnClick()
	{
		if (parentMap.minigameState == MinigameState.Failure)
		{
			parentMap.AnimateFailure();
		}
		else
		{
			if (parentMap.minigameState != MinigameState.Running)
			{
				return;
			}
			if (isRevealed)
			{
				if (item != ItemType.None && parentGemFormation != null)
				{
					parentMap.TryExcavateFormation(parentGemFormation);
				}
			}
			else
			{
				parentMap.digCount++;
				Reveal(0f);
				if (item == ItemType.None)
				{
					parentMap.BeginRevealSurroundingFrom(this);
				}
				else if (item == ItemType.Stone)
				{
					if (parentMap.digCount <= GameManager.Instance.LevelOfGlobalUpgrade(UpgradeType.LuckyPickaxe))
					{
						MenuManager.Instance.ShowMessage("LuckyPickaxeNotification".Localized());
					}
					else
					{
						parentMap.OnClickedRock();
					}
				}
				parentMap.UpdateProtectionIcons();
			}
			parentMap.isRewardStale = true;
		}
	}

	public void Unlock()
	{
		isUnlocked = true;
		UpdateItemIcon();
	}

	public void Excavate()
	{
		isExcavated = true;
		AssignItem(ItemType.None);
	}

	public void OnDrag(PointerEventData eventData)
	{
	}
}
