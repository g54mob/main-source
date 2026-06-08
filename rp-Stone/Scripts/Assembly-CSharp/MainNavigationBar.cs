using System;
using System.Collections.Generic;
using UnityEngine;

public class MainNavigationBar : MonoBehaviour
{
	public int bigSelectorMinScreenWidth = 65;

	public int leftMarginSubtraction = 60;

	public float leftMarginMultiplication = 0.2f;

	public int navBarWidth = 13;

	public ToggleButtonGroup landscapeToggleGroup;

	public ToggleButtonGroup portraitToggleGroup;

	public QuestStoneNavButton questStoneButton;

	public AsciiSprite fancySelection;

	public AsciiSprite fancySelectionSmall;

	public AsciiSprite fancySelectionQuest;

	private bool questSelectorActive;

	public DialogButton mainMenuOptionsButton;

	private List<AsciiObject> screens = new List<AsciiObject>();

	private AsciiObject nextScreen;

	private Vector2 fancySelectionPos;

	private Vector2 selectedButtonPos;

	private bool selectorJumpPending;

	private bool lockedHandleChange;

	private float outAcceleration = 2.5f;

	private float inVelocity = 9f;

	private float inBounceThreshold = 5f;

	private float inBounceAcceleration = 4.5f;

	private float inBounceMaxVelocity = 2f;

	private float transitionOffsetX;

	private float transitionOutVelocity;

	private float nextUpdateBadgesTime;

	private int badgeIndexToUpdate = -1;

	public AsciiObject activeScreen { get; private set; }

	public event Action<int, AsciiObject> OnScreenChanged;

	private void Awake()
	{
		fancySelection.Load();
	}

	private void Start()
	{
		landscapeToggleGroup.OnIndexChanged += HandleOnLandscapeIndexChanged;
	}

	public void Reset()
	{
		SetScreenForIndex(0);
		JumpScreen();
		fancySelectionPos.x = landscapeToggleGroup.selectedButton.PositionX;
		fancySelectionPos.y = landscapeToggleGroup.selectedButton.PositionY;
	}

	private void OnDestroy()
	{
		landscapeToggleGroup.OnIndexChanged -= HandleOnLandscapeIndexChanged;
	}

	public void SetScreen(AsciiObject screenObject)
	{
		int indexOfScreen = GetIndexOfScreen(screenObject);
		if (indexOfScreen != landscapeToggleGroup.selectedIndex || activeScreen == null)
		{
			landscapeToggleGroup.selectedIndex = indexOfScreen;
			SetScreenForIndex(indexOfScreen);
		}
		else
		{
			ActivateScreen(activeScreen);
		}
	}

	public void JumpSelector()
	{
		selectorJumpPending = true;
	}

	public void JumpScreen()
	{
		if (nextScreen != null)
		{
			activeScreen = nextScreen;
			nextScreen = null;
			transitionOffsetX = 0f;
			transitionOutVelocity = 0f;
		}
	}

	public void SetIndexEnabled(int whichIndex, bool enabled)
	{
		if (whichIndex >= 0 && whichIndex < landscapeToggleGroup.buttons.Count)
		{
			landscapeToggleGroup.buttons[whichIndex].enabled = enabled;
		}
	}

	public int GetIndexOfScreen(AsciiObject screenObject)
	{
		for (int i = 0; i < screens.Count; i++)
		{
			if (screens[i] == screenObject)
			{
				return i;
			}
		}
		return -1;
	}

	public bool IsTransitioning()
	{
		return nextScreen != null;
	}

	private void HandleOnLandscapeIndexChanged(int newIndex)
	{
		if (!lockedHandleChange)
		{
			lockedHandleChange = true;
			AsciiObject arg = SetScreenForIndex(newIndex);
			if (this.OnScreenChanged != null)
			{
				this.OnScreenChanged(newIndex, arg);
			}
			lockedHandleChange = false;
		}
	}

	private AsciiObject SetScreenForIndex(int newIndex)
	{
		if (newIndex >= 0 && newIndex < screens.Count)
		{
			AsciiObject asciiObject = screens[newIndex];
			if (asciiObject == nextScreen)
			{
				return asciiObject;
			}
			DeactivateCurrentScreen();
			nextScreen = screens[newIndex];
			if (newIndex == 3)
			{
				questSelectorActive = true;
			}
			return asciiObject;
		}
		activeScreen = null;
		return null;
	}

	private void DeactivateCurrentScreen()
	{
		if (activeScreen is IActivatable activatable)
		{
			activatable.Deactivate();
		}
	}

	private void ActivateScreen(AsciiObject screen)
	{
		if (screen is IActivatable activatable)
		{
			activatable.Activate();
		}
	}

	public void UpdateTic()
	{
		landscapeToggleGroup.UpdateTic();
		UpdateFancySelectionPosition();
		if (nextScreen != null)
		{
			if (activeScreen != null)
			{
				transitionOutVelocity += outAcceleration;
				transitionOffsetX += transitionOutVelocity;
				if (transitionOffsetX > (float)activeScreen.Width)
				{
					activeScreen = null;
					ActivateScreen(nextScreen);
					transitionOffsetX = nextScreen.Width;
					transitionOutVelocity = 0f - inVelocity;
				}
			}
			else
			{
				nextScreen.UpdateTic();
				bool flag = transitionOffsetX >= 0f && transitionOutVelocity >= 0f;
				if (transitionOffsetX > inBounceThreshold)
				{
					transitionOffsetX += transitionOutVelocity;
				}
				else
				{
					transitionOutVelocity = Mathf.Min(inBounceMaxVelocity, transitionOutVelocity + inBounceAcceleration);
					transitionOffsetX += transitionOutVelocity;
					if (transitionOffsetX >= 0f && transitionOutVelocity >= 0f)
					{
						flag = true;
					}
				}
				if (flag)
				{
					activeScreen = nextScreen;
					nextScreen = null;
					transitionOffsetX = 0f;
					transitionOutVelocity = 0f;
				}
			}
		}
		if (activeScreen != null)
		{
			activeScreen.UpdateTic();
		}
		UpdateBadges();
		mainMenuOptionsButton.UpdateTic();
	}

	private void UpdateFancySelectionPosition()
	{
		selectedButtonPos.x = (float)landscapeToggleGroup.selectedButton.lastDrawnX + (float)(landscapeToggleGroup.selectedButton.Width / 2);
		selectedButtonPos.y = landscapeToggleGroup.selectedButton.lastDrawnY;
		if (selectorJumpPending)
		{
			selectorJumpPending = false;
			fancySelectionPos = selectedButtonPos;
		}
		else
		{
			fancySelectionPos = Vector2.Lerp(fancySelectionPos, selectedButtonPos, 0.5f);
			fancySelectionPos.x = selectedButtonPos.x;
		}
		if (!questSelectorActive)
		{
			return;
		}
		int frameIndex = fancySelectionQuest.GetFrameIndex();
		if (landscapeToggleGroup.selectedIndex == 3)
		{
			if (frameIndex < fancySelectionQuest.FrameCount - 1)
			{
				fancySelectionQuest.SetFrameIndex(frameIndex + 1);
			}
		}
		else if (frameIndex == 0)
		{
			questSelectorActive = false;
		}
		else
		{
			fancySelectionQuest.SetFrameIndex(frameIndex - 1);
		}
	}

	private void UpdateBadges()
	{
		if (!(nextUpdateBadgesTime < Time.realtimeSinceStartup))
		{
			return;
		}
		nextUpdateBadgesTime = Time.realtimeSinceStartup + 0.2f;
		badgeIndexToUpdate = (badgeIndexToUpdate + 1) % landscapeToggleGroup.buttons.Count;
		if (badgeIndexToUpdate == 0)
		{
			int num = 0;
			for (int i = 0; i < QuestController.singleton.AvailableQuests.Count; i++)
			{
				if (!QuestController.singleton.HasSeen(QuestController.singleton.AvailableQuests[i].id))
				{
					num++;
				}
			}
			landscapeToggleGroup.buttons[badgeIndexToUpdate].badge.number = num;
		}
		else if (badgeIndexToUpdate == 1)
		{
			int num2 = 0;
			for (int j = 0; j < QuestController.singleton.AvailableWorkstationQuests.Count; j++)
			{
				if (!QuestController.singleton.HasSeen(QuestController.singleton.AvailableWorkstationQuests[j].id))
				{
					num2++;
				}
			}
			landscapeToggleGroup.buttons[badgeIndexToUpdate].badge.number = num2;
		}
		else
		{
			if (badgeIndexToUpdate != 2)
			{
				return;
			}
			int num3 = 0;
			List<Item> allItems = Inventory.Singleton.GetAllItems();
			for (int k = 0; k < allItems.Count; k++)
			{
				Item item = allItems[k];
				if (item != null && !item.hasInteracted)
				{
					num3++;
				}
			}
			landscapeToggleGroup.buttons[2].badge.number = num3;
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int num = Mathf.Max(0, Mathf.FloorToInt((float)(r.width - leftMarginSubtraction) * leftMarginMultiplication));
		offsetX += num;
		if (selectorJumpPending)
		{
			DrawButtons(r, offsetX, offsetY);
			UpdateFancySelectionPosition();
		}
		DrawSelector(r);
		DrawButtons(r, offsetX, offsetY);
		AsciiObject asciiObject = ((activeScreen != null) ? activeScreen : nextScreen);
		if (asciiObject != null)
		{
			int num2 = r.width - navBarWidth - asciiObject.Width;
			if (asciiObject == GameStates.Singleton.itemScreen)
			{
				num2 -= UtilityBeltUI.singleton.displayedWidth + 1;
			}
			int num3 = (num2 - num) / 2;
			offsetX += navBarWidth + num3 + (int)transitionOffsetX;
			asciiObject.Draw(r, offsetX, offsetY);
		}
	}

	private void DrawSelector(AsciiRenderProcedural r)
	{
		int offsetX = Mathf.RoundToInt(fancySelectionPos.x);
		int offsetY = Mathf.RoundToInt(fancySelectionPos.y);
		if (questSelectorActive)
		{
			fancySelectionQuest.Draw(r, offsetX, offsetY);
		}
		else if (r.width >= bigSelectorMinScreenWidth)
		{
			fancySelection.Draw(r, offsetX, offsetY);
		}
		else
		{
			fancySelectionSmall.Draw(r, offsetX, offsetY);
		}
	}

	private void DrawButtons(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int num;
		if (landscapeToggleGroup.buttons.Count >= 4)
		{
			num = (landscapeToggleGroup.buttons[3].enabled ? 1 : 0);
			if (num != 0)
			{
				offsetY--;
			}
		}
		else
		{
			num = 0;
		}
		landscapeToggleGroup.Draw(r, offsetX, offsetY);
		if (num != 0)
		{
			offsetY++;
		}
		mainMenuOptionsButton.Draw(r, offsetX, r.height);
	}

	public void AddScreen(AsciiObject screen)
	{
		screens.Add(screen);
	}
}
