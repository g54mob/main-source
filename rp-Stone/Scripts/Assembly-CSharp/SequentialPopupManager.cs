using System.Collections.Generic;
using UnityEngine;

public class SequentialPopupManager : MonoBehaviour
{
	public enum Mode
	{
		ItemFound = 0,
		EventCompleted = 1,
		OfflineFarmRewards = 2,
		GoalBookScreen = 3,
		CosmeticSet = 4,
		TreasureUpgrade = 5
	}

	public enum State
	{
		Disabled = 0,
		Active = 1
	}

	public ItemFoundDialog itemFoundDialogPrefab;

	public EventCompletedDialog eventCompletedDialogPrefab;

	public OfflineFarmRewards offlineFarmRewardsDialogPrefab;

	public CosmeticSetPopup cosmeticSetPopupPrefab;

	public W2ETreasureUpgradeDialog treasureUpgradeDialogPrefab;

	public W2ETreasureUpgradeDialog treasureUpgradeDialogPrefabPC;

	private Queue<Mode> popupQueue = new Queue<Mode>();

	private Queue<Item> itemFoundQueue = new Queue<Item>();

	private Queue<int> itemCountQueue = new Queue<int>();

	private Queue<bool> itemWasAutoUpgradedQueue = new Queue<bool>();

	public ItemFoundDialog itemFoundDialog { get; private set; }

	public EventCompletedDialog eventCompletedDialog { get; private set; }

	public OfflineFarmRewards offlineFarmRewardsDialog { get; private set; }

	public CosmeticSetPopup cosmeticSetPopup { get; private set; }

	public W2ETreasureUpgradeDialog treasureUpgradeDialog { get; private set; }

	public Mode currentMode { get; private set; }

	public State currentState { get; private set; }

	public static SequentialPopupManager singleton { get; private set; }

	public bool ShouldDrawMoneyHud()
	{
		if (currentMode == Mode.GoalBookScreen && GoalBookScreen.singleton.currentState != BaseBookScreen.State.Out)
		{
			return false;
		}
		GameStates gameStates = GameStates.Singleton;
		if (gameStates.previousState == GameStates.State.ItemScreen || (gameStates.previousState == GameStates.State.CustomQuests && (gameStates.customQuestsScreen.currentState == CustomQuestsScreen.State.EventRewardsScreen || gameStates.customQuestsScreen.currentState == CustomQuestsScreen.State.EventLeaderboardScreen)))
		{
			return false;
		}
		return true;
	}

	public void Activate()
	{
		NextPopup();
	}

	public void Enqueue(Mode newMode)
	{
		popupQueue.Enqueue(newMode);
	}

	public bool IsPending()
	{
		return popupQueue.Count > 0;
	}

	public void ScheduleItemFound(Item item, int count = 1, bool wasAutoUpgraded = false)
	{
		itemFoundQueue.Enqueue(item);
		itemCountQueue.Enqueue(count);
		itemWasAutoUpgradedQueue.Enqueue(wasAutoUpgraded);
		Enqueue(Mode.ItemFound);
	}

	public void ScheduleEventReward(string titleStr, AsciiSprite sprite)
	{
		eventCompletedDialog.Setup(titleStr, sprite);
		Enqueue(Mode.EventCompleted);
	}

	public void ScheduleOfflineFarmRewards(OfflineFarmController.RewardsInfo rewardsInfo)
	{
		offlineFarmRewardsDialog.Setup(rewardsInfo);
		Enqueue(Mode.OfflineFarmRewards);
	}

	public void ScheduleTreasureUpgrade(TreasureItem current, TreasureItem upgraded)
	{
		if (treasureUpgradeDialog == null)
		{
			treasureUpgradeDialog = Object.Instantiate(treasureUpgradeDialogPrefabPC);
		}
		treasureUpgradeDialog.Setup(current, upgraded);
		Enqueue(Mode.TreasureUpgrade);
	}

	private void SetMode(Mode newMode)
	{
		switch (newMode)
		{
		case Mode.ItemFound:
		{
			Item item = itemFoundQueue.Dequeue();
			int count = itemCountQueue.Dequeue();
			bool wasAutoUpgraded = itemWasAutoUpgradedQueue.Dequeue();
			itemFoundDialog.Setup(item, count, wasAutoUpgraded);
			itemFoundDialog.Show();
			break;
		}
		case Mode.EventCompleted:
			eventCompletedDialog.Show();
			break;
		case Mode.OfflineFarmRewards:
			offlineFarmRewardsDialog.Show();
			break;
		case Mode.GoalBookScreen:
			GoalBookScreen.singleton.Show();
			break;
		case Mode.CosmeticSet:
			if (cosmeticSetPopup == null)
			{
				cosmeticSetPopup = Object.Instantiate(cosmeticSetPopupPrefab);
			}
			cosmeticSetPopup.Show();
			break;
		case Mode.TreasureUpgrade:
			treasureUpgradeDialog.Show();
			break;
		}
		currentMode = newMode;
	}

	private void SetState(State newState)
	{
		currentState = newState;
	}

	private void NextPopup()
	{
		if (popupQueue.Count > 0)
		{
			SetMode(popupQueue.Dequeue());
			SetState(State.Active);
		}
		else
		{
			SetState(State.Disabled);
		}
	}

	public void UpdateTic()
	{
		if (currentMode == Mode.ItemFound)
		{
			itemFoundDialog.UpdateTic();
			if (itemFoundDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				NextPopup();
				itemFoundDialog.FireDone();
			}
		}
		else if (currentMode == Mode.EventCompleted)
		{
			eventCompletedDialog.UpdateTic();
			if (eventCompletedDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				NextPopup();
			}
		}
		else if (currentMode == Mode.OfflineFarmRewards)
		{
			offlineFarmRewardsDialog.UpdateTic();
			if (offlineFarmRewardsDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				NextPopup();
			}
		}
		else if (currentMode == Mode.GoalBookScreen)
		{
			GoalBookScreen.singleton.UpdateTic();
			if (GoalBookScreen.singleton.currentState == BaseBookScreen.State.Disabled)
			{
				NextPopup();
			}
		}
		else if (currentMode == Mode.CosmeticSet)
		{
			cosmeticSetPopup.UpdateTic();
			if (cosmeticSetPopup.currentState == PopUpModalScreen.State.Disabled)
			{
				NextPopup();
			}
		}
		else if (currentMode == Mode.TreasureUpgrade)
		{
			treasureUpgradeDialog.UpdateTic();
			if (treasureUpgradeDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				NextPopup();
			}
		}
	}

	public void Draw(AsciiRenderProcedural r)
	{
		if (currentMode == Mode.ItemFound)
		{
			itemFoundDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentMode == Mode.EventCompleted)
		{
			eventCompletedDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentMode == Mode.OfflineFarmRewards)
		{
			offlineFarmRewardsDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentMode == Mode.GoalBookScreen)
		{
			GoalBookScreen.singleton.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentMode == Mode.CosmeticSet)
		{
			cosmeticSetPopup.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentMode == Mode.TreasureUpgrade)
		{
			treasureUpgradeDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
	}

	public void Initialize()
	{
		if (!(eventCompletedDialog != null))
		{
			itemFoundDialog = Object.Instantiate(itemFoundDialogPrefab);
			eventCompletedDialog = Object.Instantiate(eventCompletedDialogPrefab);
			offlineFarmRewardsDialog = Object.Instantiate(offlineFarmRewardsDialogPrefab);
		}
	}

	private void Awake()
	{
		singleton = this;
	}
}
