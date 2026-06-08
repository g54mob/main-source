using System;
using System.Collections.Generic;
using UnityEngine;

public class EventRewardsContainer : ScrollContainer
{
	private enum AnimState
	{
		Waiting = 0,
		SolidifyCurrent = 1,
		ConnectToNext = 2,
		ActivateNext = 3,
		SolidifyFinalOne = 4,
		Done = 5,
		OpeningLocks = 6
	}

	private readonly int DISTANCE_BETWEEN = 12;

	private readonly int COLUMNS_PER_PAGINATION = 3;

	public DialogButton leftButton;

	public DialogButton rightButton;

	public AsciiSprite separator;

	public AsciiSprite vConnectionDotted;

	public AsciiSprite vConnectionDottedToActive;

	public AsciiSprite vConnectionActiveToSolid;

	public AsciiSprite vConnectionSolid;

	public AsciiSprite hConnectionDotted;

	public AsciiSprite hConnectionDottedToSolid;

	public AsciiSprite hConnectionSolid;

	public AsciiAnimation lockRemovalAnm;

	public EventRewardsColumn columnPrefab;

	private Stack<EventRewardsColumn> columnPool = new Stack<EventRewardsColumn>();

	private string eventId;

	private List<AsciiSprite> vConnections = new List<AsciiSprite>();

	private List<AsciiSprite> hConnections = new List<AsciiSprite>();

	private List<EventRewardsColumn> pool = new List<EventRewardsColumn>();

	private AnimState currentAnimState;

	private int elapsedAnimTics;

	private int currentColumnIndex = -1;

	private int unlockedColumnIndex;

	private int openingLocksIndex;

	private int maxEnchantmentBonus;

	private int maxTreasureLevel;

	private float separatorDisplayX;

	private float separatorTargetX;

	public event Action<Item, Data.EventReward> OnItemSelected;

	public void Setup(Data.EventRewardCollection rewardCollection, BaseEventController2 eventController)
	{
		int num = Mathf.Min(eventController.rewards.previousPoints, eventController.rewards.maxRewardPoints);
		int num2 = Mathf.Min(eventController.rewards.rewardPoints, eventController.rewards.maxRewardPoints);
		int num3 = currentColumnIndex;
		currentColumnIndex = Mathf.Max(currentColumnIndex, num - 1);
		unlockedColumnIndex = num2 - 1;
		if (currentColumnIndex > unlockedColumnIndex)
		{
			currentColumnIndex = unlockedColumnIndex;
		}
		SetStartingState();
		separatorTargetX = unlockedColumnIndex * DISTANCE_BETWEEN + 10;
		if (eventId == rewardCollection.id && currentColumnIndex == num3)
		{
			return;
		}
		eventId = rewardCollection.id;
		vConnections.Clear();
		hConnections.Clear();
		RecycleColumns();
		int num4 = Mathf.Min(rewardCollection.free.Length, rewardCollection.premium.Length);
		maxEnchantmentBonus = 0;
		maxTreasureLevel = 0;
		for (int i = 0; i < num4; i++)
		{
			Data.EventReward eventReward = rewardCollection.free[i];
			if (eventReward.IsSpecialEventTreasure())
			{
				maxEnchantmentBonus = Mathf.Max(maxEnchantmentBonus, eventReward.rarityBonus);
				maxTreasureLevel = Mathf.Max(maxTreasureLevel, eventReward.level);
			}
		}
		DateTime eventStartDate = eventController.rewards.eventStartDate;
		string signature = rewardCollection.GetSignature(eventStartDate);
		for (int j = 0; j < num4; j++)
		{
			Data.EventReward topReward = rewardCollection.free[j];
			Data.EventReward botReward = rewardCollection.premium[j];
			EventRewardsColumn column = GetColumn();
			AddRow(column);
			column.Setup(topReward, botReward, signature, eventStartDate);
			column.drawLock = !eventController.isPremiumActiveForEvent;
			column.isGrayedOut = j > currentColumnIndex;
			column.maxEnchantmentBonus = maxEnchantmentBonus;
			column.maxTreasureLevel = maxTreasureLevel;
			if (j < currentColumnIndex)
			{
				vConnections.Add(vConnectionSolid);
			}
			else if (j == currentColumnIndex)
			{
				vConnections.Add(vConnectionActiveToSolid);
				vConnectionActiveToSolid.GetComponent<AsciiAnimation>().Stop();
				vConnectionActiveToSolid.SetFrameIndex(0);
			}
			else
			{
				vConnections.Add(vConnectionDotted);
			}
			if (j < num4 - 1)
			{
				if (j < currentColumnIndex)
				{
					hConnections.Add(hConnectionSolid);
				}
				else
				{
					hConnections.Add(hConnectionDotted);
				}
			}
		}
		UpdateColumnsSpecialEventTreasureStatus();
		UpdatePadding();
		if (currentColumnIndex < 3)
		{
			SetScrollY(-padTop);
		}
		else
		{
			RefreshPrecompute();
			UpdatePrecompute();
			ScrollPositionToCentralizeRow(currentColumnIndex, jumpToPosition: true);
		}
		lockRemovalAnm.Sprite.SetFrameIndex(3);
	}

	private void SetStartingState()
	{
		if (currentColumnIndex >= unlockedColumnIndex)
		{
			SetAnimState(AnimState.Done);
		}
		else
		{
			SetAnimState(AnimState.Waiting);
		}
	}

	private EventRewardsColumn GetColumn()
	{
		if (columnPool.Count > 0)
		{
			return columnPool.Pop();
		}
		EventRewardsColumn eventRewardsColumn = UnityEngine.Object.Instantiate(columnPrefab);
		eventRewardsColumn.OnItemSelected += HandleItemSelected;
		return eventRewardsColumn;
	}

	private void RecycleColumns()
	{
		List<AsciiObject> list = GetRows();
		for (int i = 0; i < list.Count; i++)
		{
			columnPool.Push(list[i] as EventRewardsColumn);
		}
		base.Clear();
	}

	public void OpenLocks()
	{
		SfxController.singleton.Play("level_up");
		SetAnimState(AnimState.OpeningLocks);
	}

	private void SetAnimState(AnimState newState)
	{
		switch (newState)
		{
		case AnimState.SolidifyCurrent:
		case AnimState.ConnectToNext:
		case AnimState.SolidifyFinalOne:
			SfxController.singleton.Play("pickup_bronze");
			break;
		case AnimState.ActivateNext:
			SfxController.singleton.Play("pickup_bronze");
			SfxController.singleton.Play("quest_stone_jump", ignoreDuplicateSfxInSameFrame: true, 0.2f);
			break;
		}
		switch (newState)
		{
		case AnimState.SolidifyCurrent:
		case AnimState.SolidifyFinalOne:
		{
			SetConnectionAnimSafe(vConnections, currentColumnIndex, vConnectionActiveToSolid);
			AsciiAnimation component3 = vConnectionActiveToSolid.GetComponent<AsciiAnimation>();
			component3.Stop();
			component3.Play();
			break;
		}
		case AnimState.ConnectToNext:
		{
			SetConnectionAnimSafe(vConnections, currentColumnIndex, vConnectionSolid);
			SetConnectionAnimSafe(hConnections, currentColumnIndex, hConnectionDottedToSolid);
			AsciiAnimation component2 = hConnectionDottedToSolid.GetComponent<AsciiAnimation>();
			component2.Stop();
			component2.Play();
			break;
		}
		case AnimState.ActivateNext:
		{
			ScrollPositionToCentralizeRow(currentColumnIndex + 1);
			if (currentColumnIndex >= 0 && currentColumnIndex < hConnections.Count)
			{
				SetConnectionAnimSafe(hConnections, currentColumnIndex, hConnectionSolid);
			}
			SetConnectionAnimSafe(vConnections, currentColumnIndex + 1, vConnectionDottedToActive);
			AsciiAnimation component = vConnectionDottedToActive.GetComponent<AsciiAnimation>();
			component.Stop();
			component.Play();
			break;
		}
		case AnimState.OpeningLocks:
			SetScrollY(-padTop);
			RefreshPrecompute();
			UpdatePrecompute();
			openingLocksIndex = -1;
			break;
		}
		currentAnimState = newState;
		elapsedAnimTics = 0;
	}

	private void SetConnectionAnimSafe(List<AsciiSprite> spriteList, int index, AsciiSprite newValue)
	{
		if (spriteList.Count > 0)
		{
			index = Mathf.Clamp(index, 0, spriteList.Count - 1);
			spriteList[index] = newValue;
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (leftButton.enabled)
		{
			leftButton.UpdateTic();
		}
		if (rightButton.enabled)
		{
			rightButton.UpdateTic();
		}
		UpdatePadding();
		elapsedAnimTics++;
		if (currentAnimState == AnimState.Waiting && elapsedAnimTics >= 15)
		{
			if (currentColumnIndex < 0)
			{
				SetAnimState(AnimState.ActivateNext);
			}
			else
			{
				SetAnimState(AnimState.SolidifyCurrent);
			}
		}
		else if (currentAnimState == AnimState.SolidifyCurrent && elapsedAnimTics >= 22)
		{
			SetAnimState(AnimState.ConnectToNext);
		}
		else if (currentAnimState == AnimState.ConnectToNext && elapsedAnimTics >= 23)
		{
			SetAnimState(AnimState.ActivateNext);
		}
		else if (currentAnimState == AnimState.ActivateNext && elapsedAnimTics >= 22)
		{
			currentColumnIndex++;
			UpdateColumnsSpecialEventTreasureStatus();
			if (currentColumnIndex < unlockedColumnIndex)
			{
				SetAnimState(AnimState.SolidifyCurrent);
			}
			else if (currentColumnIndex >= vConnections.Count - 1)
			{
				SetAnimState(AnimState.SolidifyFinalOne);
			}
			else
			{
				SetAnimState(AnimState.Done);
			}
			FlashRewardsWhite();
		}
		else if (currentAnimState == AnimState.SolidifyFinalOne && elapsedAnimTics >= 22)
		{
			SetAnimState(AnimState.Done);
		}
		else if (currentAnimState == AnimState.OpeningLocks && elapsedAnimTics == 15)
		{
			elapsedAnimTics = 0;
			openingLocksIndex++;
			List<AsciiObject> list = GetRows();
			if (openingLocksIndex < list.Count)
			{
				EventRewardsColumn eventRewardsColumn = list[openingLocksIndex] as EventRewardsColumn;
				eventRewardsColumn.drawLock = false;
				ScrollPositionToCentralizeRow(eventRewardsColumn);
				lockRemovalAnm.Stop();
				lockRemovalAnm.Play();
				SfxController.singleton.Play("wand_drop");
			}
			else
			{
				SetStartingState();
			}
		}
	}

	private void UpdateColumnsSpecialEventTreasureStatus()
	{
		List<AsciiObject> list = GetRows();
		bool flag = false;
		for (int num = currentColumnIndex; num >= 0; num--)
		{
			EventRewardsColumn eventRewardsColumn = list[num] as EventRewardsColumn;
			if (flag)
			{
				eventRewardsColumn.isBestFreeReward = false;
			}
			else if (eventRewardsColumn.topData.IsSpecialEventTreasure())
			{
				flag = true;
				eventRewardsColumn.isBestFreeReward = true;
			}
		}
	}

	private void FlashRewardsWhite()
	{
		EventRewardsColumn obj = GetRows()[currentColumnIndex] as EventRewardsColumn;
		obj.FlashRewardsWhite();
		obj.isGrayedOut = false;
	}

	private void UpdatePadding()
	{
		padTop = (padBottom = GameStates.Singleton.asciiRenderer.width / 2 - 28);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int offsetX2;
		if (currentColumnIndex >= 0)
		{
			float t = Time.deltaTime * 4f;
			separatorDisplayX = Mathf.Lerp(separatorDisplayX, separatorTargetX, t);
			offsetX2 = offsetX - base.DisplayScrollY + Mathf.RoundToInt(separatorDisplayX);
			separator.Draw(r, offsetX2, offsetY);
		}
		offsetX2 = offsetX + 4 - base.DisplayScrollY;
		int offsetX3 = 0;
		for (int i = 0; i < vConnections.Count; i++)
		{
			vConnections[i].Draw(r, offsetX2, offsetY);
			if (i < hConnections.Count)
			{
				hConnections[i].Draw(r, offsetX2, offsetY);
			}
			if (openingLocksIndex == i)
			{
				offsetX3 = offsetX2;
			}
			offsetX2 += DISTANCE_BETWEEN;
		}
		base.Draw(r, offsetX, offsetY);
		if (currentAnimState != AnimState.OpeningLocks)
		{
			leftButton.enabled = displayScrollY > 0;
			rightButton.enabled = displayScrollY < base.totalContentLength - GetContainerLength();
			if (leftButton.enabled)
			{
				leftButton.Draw(r, 0, offsetY);
			}
			if (rightButton.enabled)
			{
				rightButton.Draw(r, r.width - rightButton.Width, offsetY);
			}
		}
		lockRemovalAnm.Sprite.Draw(r, offsetX3, offsetY + columnPrefab.lockY - 5);
	}

	private void HandleLeftButtonPressed(DialogButton btn)
	{
		int rowIndex = GetFocusedRowIndex() - COLUMNS_PER_PAGINATION;
		ScrollPositionToCentralizeRow(rowIndex);
	}

	private void HandleRightButtonPressed(DialogButton btn)
	{
		int rowIndex = GetFocusedRowIndex() + COLUMNS_PER_PAGINATION;
		ScrollPositionToCentralizeRow(rowIndex);
	}

	private void HandleItemSelected(Item item, Data.EventReward entryData)
	{
		if (this.OnItemSelected != null)
		{
			this.OnItemSelected(item, entryData);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		leftButton.OnPressed += HandleLeftButtonPressed;
		rightButton.OnPressed += HandleRightButtonPressed;
	}

	protected override void OnDestroy()
	{
		leftButton.OnPressed -= HandleLeftButtonPressed;
		rightButton.OnPressed -= HandleRightButtonPressed;
		base.OnDestroy();
	}
}
