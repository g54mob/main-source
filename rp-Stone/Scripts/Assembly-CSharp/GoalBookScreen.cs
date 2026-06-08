using System;
using System.Collections.Generic;
using UnityEngine;

public class GoalBookScreen : BaseBookScreen
{
	private class PageContent
	{
		public AsciiObject[] doodles;

		private GoalBookItemAndRewardUI itemAndReward;

		private List<GoalBookEntryUI> allEntries = new List<GoalBookEntryUI>();

		private List<AsciiObject> activeEntries = new List<AsciiObject>();

		private int lastGoal = -1;

		private int lastProgress = -1;

		private ScrollContainer leftContainer;

		private ScrollContainer rightContainer;

		private readonly int LAYOUT_MAX_CONTENT_HEIGHT = 21;

		private readonly int LAYOUT_PAGE_1_X = -28;

		private readonly int LAYOUT_PAGE_2_X = 4;

		private readonly int LAYOUT_TOP_Y = -9;

		public ScrollContainer containerPrototype { get; set; }

		public void SetupEntries(List<string> texts)
		{
			for (int i = 0; i < texts.Count; i++)
			{
				GoalBookEntryUI goalBookEntryUI = UnityEngine.Object.Instantiate(singleton.entryPrototype);
				goalBookEntryUI.sourcePrefab = singleton.entryPrototype;
				allEntries.Add(goalBookEntryUI);
				goalBookEntryUI.SetText(texts[i]);
			}
		}

		public void UpdateContent(BaseGoals goal, bool transitionBetweenGoals)
		{
			string iconPath = goal.iconPath;
			ItemData.Element iconElement = goal.iconElement;
			int num = goal.goal.GetValue();
			int value = goal.progress.GetValue();
			int goalCount = goal.goalCount;
			int rewardEnchantBonus = goal.rewardEnchantBonus;
			AsciiObject supportingUIElement = goal.GetSupportingUIElement(num);
			if (DEBUG_SHOW_ALL)
			{
				num = goalCount;
			}
			if (lastGoal == num && lastProgress == value && itemAndReward != null)
			{
				return;
			}
			lastGoal = num;
			lastProgress = value;
			if (itemAndReward == null)
			{
				itemAndReward = UnityEngine.Object.Instantiate(singleton.treasureProgress);
			}
			itemAndReward.Setup(iconPath, iconElement, num, goalCount, rewardEnchantBonus, transitionBetweenGoals);
			activeEntries.Clear();
			for (int i = 0; i < allEntries.Count && i <= num; i++)
			{
				GoalBookEntryUI goalBookEntryUI = allEntries[i];
				if (i < num)
				{
					if (transitionBetweenGoals && i == num - 1)
					{
						goalBookEntryUI.SetState(GoalBookEntryUI.State.EnteringComplete);
					}
					else
					{
						goalBookEntryUI.SetState(GoalBookEntryUI.State.Complete);
					}
				}
				else if (transitionBetweenGoals)
				{
					goalBookEntryUI.SetState(GoalBookEntryUI.State.EnteringIncomplete);
				}
				else
				{
					goalBookEntryUI.SetState(GoalBookEntryUI.State.Incomplete);
				}
				activeEntries.Add(goalBookEntryUI);
			}
			if (supportingUIElement != null)
			{
				activeEntries.Add(supportingUIElement);
			}
			if (leftContainer == null && activeEntries.Count > 0)
			{
				leftContainer = UnityEngine.Object.Instantiate(containerPrototype);
				rightContainer = UnityEngine.Object.Instantiate(containerPrototype);
				leftContainer.PositionX = LAYOUT_PAGE_1_X;
				rightContainer.PositionX = LAYOUT_PAGE_2_X;
				leftContainer.Height = LAYOUT_MAX_CONTENT_HEIGHT;
				rightContainer.Height = LAYOUT_MAX_CONTENT_HEIGHT;
				leftContainer.Width = activeEntries[0].Width;
				rightContainer.Width = activeEntries[0].Width;
			}
			if (leftContainer != null)
			{
				RebuildLayout();
			}
		}

		public void UpdateTic()
		{
			if (leftContainer != null)
			{
				leftContainer.UpdateTic();
				rightContainer.UpdateTic();
			}
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
		{
			if (leftContainer != null)
			{
				leftContainer.Draw(r, offsetX, offsetY);
				rightContainer.Draw(r, offsetX, offsetY);
			}
		}

		public void RebuildLayout()
		{
			if (TryLayoutA())
			{
				return;
			}
			while (!TryLayoutB() && activeEntries.Count > 1)
			{
				GoalBookEntryUI goalBookEntryUI = activeEntries[0] as GoalBookEntryUI;
				if (goalBookEntryUI != null && (goalBookEntryUI.currentState == GoalBookEntryUI.State.Complete || goalBookEntryUI.currentState == GoalBookEntryUI.State.EnteringComplete))
				{
					activeEntries.RemoveAt(0);
					continue;
				}
				break;
			}
		}

		private bool TryLayoutA()
		{
			int num = itemAndReward.Height;
			for (int i = 0; i < activeEntries.Count; i++)
			{
				num += 1 + activeEntries[i].Height;
			}
			if (num > leftContainer.Height)
			{
				return false;
			}
			leftContainer.Clear();
			rightContainer.Clear();
			leftContainer.AddRow(itemAndReward);
			for (int j = 0; j < activeEntries.Count; j++)
			{
				AsciiObject row = activeEntries[j];
				leftContainer.AddRow(row);
			}
			leftContainer.UpdateForHeightChange();
			AddDoodle();
			BalanceYPositions();
			return true;
		}

		private bool TryLayoutB()
		{
			leftContainer.Clear();
			rightContainer.Clear();
			leftContainer.AddRow(itemAndReward);
			for (int i = 0; i < activeEntries.Count; i++)
			{
				AsciiObject row = activeEntries[i];
				if (leftContainer.totalContentLength < LAYOUT_MAX_CONTENT_HEIGHT)
				{
					leftContainer.AddRow(row);
					leftContainer.UpdateForHeightChange();
				}
				else
				{
					rightContainer.AddRow(row);
				}
			}
			rightContainer.UpdateForHeightChange();
			if (leftContainer.totalContentLength <= LAYOUT_MAX_CONTENT_HEIGHT && rightContainer.totalContentLength <= LAYOUT_MAX_CONTENT_HEIGHT)
			{
				AddDoodle();
				BalanceYPositions();
				return true;
			}
			if (rightContainer.totalContentLength > LAYOUT_MAX_CONTENT_HEIGHT)
			{
				return false;
			}
			if (leftContainer.totalContentLength + rightContainer.totalContentLength + 1 > LAYOUT_MAX_CONTENT_HEIGHT * 2)
			{
				return false;
			}
			List<AsciiObject> rows = leftContainer.GetRows();
			if (rows.Count == 0)
			{
				return false;
			}
			AsciiObject asciiObject = rows[rows.Count - 1];
			leftContainer.RemoveRow(asciiObject);
			leftContainer.UpdateForHeightChange();
			rightContainer.AddRow(asciiObject, top: true);
			rightContainer.UpdateForHeightChange();
			if (rightContainer.totalContentLength <= LAYOUT_MAX_CONTENT_HEIGHT && rightContainer.totalContentLength - leftContainer.totalContentLength <= 4)
			{
				AddDoodle();
				BalanceYPositions();
				return true;
			}
			leftContainer.AddRow(asciiObject);
			leftContainer.UpdateForHeightChange();
			rightContainer.RemoveRow(asciiObject);
			rightContainer.UpdateForHeightChange();
			GoalBookEntryUI goalBookEntryUI = asciiObject as GoalBookEntryUI;
			if (goalBookEntryUI == null)
			{
				return false;
			}
			string[] lines = goalBookEntryUI.textBox.lines;
			int num = (leftContainer.totalContentLength - rightContainer.totalContentLength) / 2;
			string[] array = new string[lines.Length - num];
			string[] array2 = new string[num];
			Array.Copy(lines, 0, array, 0, array.Length);
			Array.Copy(lines, array.Length, array2, 0, num);
			leftContainer.RemoveRow(asciiObject);
			GoalBookEntryUI goalBookEntryUI2 = UnityEngine.Object.Instantiate(goalBookEntryUI.sourcePrefab) as GoalBookEntryUI;
			goalBookEntryUI2.sourcePrefab = goalBookEntryUI.sourcePrefab;
			goalBookEntryUI2.SetText(array);
			goalBookEntryUI2.SetState(goalBookEntryUI.currentState);
			leftContainer.AddRow(goalBookEntryUI2);
			goalBookEntryUI2 = UnityEngine.Object.Instantiate(goalBookEntryUI.sourcePrefab) as GoalBookEntryUI;
			goalBookEntryUI2.sourcePrefab = goalBookEntryUI.sourcePrefab;
			goalBookEntryUI2.SetText(array2);
			goalBookEntryUI2.isHalfEntry = true;
			goalBookEntryUI2.SetState(goalBookEntryUI.currentState);
			rightContainer.AddRow(goalBookEntryUI2, top: true);
			leftContainer.UpdateForHeightChange();
			rightContainer.UpdateForHeightChange();
			AddDoodle();
			BalanceYPositions();
			return true;
		}

		private void BalanceYPositions()
		{
			leftContainer.PositionY = LAYOUT_TOP_Y + (leftContainer.Height - leftContainer.totalContentLength) / 2;
			leftContainer.ComputeOffsets();
			List<int> offsets = leftContainer.GetOffsets();
			int num = 0;
			if (offsets.Count >= 2)
			{
				num = offsets[1];
			}
			else if (offsets.Count >= 1)
			{
				num = offsets[0];
			}
			rightContainer.PositionY = leftContainer.PositionY + num;
			if (rightContainer.PositionY + rightContainer.totalContentLength > LAYOUT_TOP_Y + rightContainer.Height)
			{
				rightContainer.PositionY = LAYOUT_TOP_Y + (rightContainer.Height - rightContainer.totalContentLength) / 2;
			}
		}

		private void AddDoodle()
		{
			if (doodles == null || doodles.Length == 0)
			{
				return;
			}
			int a = rightContainer.Height - rightContainer.totalContentLength;
			a = Mathf.Min(a, leftContainer.totalContentLength - rightContainer.totalContentLength);
			a -= rightContainer.spaceBetweenRows;
			for (int num = doodles.Length - 1; num >= 0; num--)
			{
				AsciiObject asciiObject = doodles[num];
				if (asciiObject.Height <= a)
				{
					AsciiSprite component = asciiObject.GetComponent<AsciiSprite>();
					if (component != null)
					{
						component.pivotX = -(rightContainer.Width - asciiObject.Width) / 2;
					}
					rightContainer.AddRow(asciiObject);
					rightContainer.UpdateForHeightChange();
					break;
				}
			}
		}
	}

	private static bool DEBUG_SHOW_ALL;

	public GoalBookItemAndRewardUI treasureProgress;

	public GoalBookEntryUI entryPrototype;

	public ScrollContainer containerPrototype;

	public AsciiTextBox ruleAString;

	public AsciiTextBox ruleBString;

	public AsciiTextBox ruleCString;

	public HyperlinkButton hyperlinkButton;

	private Dictionary<int, PageContent> pageContents = new Dictionary<int, PageContent>();

	private bool scheduledShowCover;

	private BaseGoals scheduledGoalsToShow;

	public static GoalBookScreen singleton { get; private set; }

	protected override int GetContentDiscovered()
	{
		return GoalController.singleton.GetTotalCompleted();
	}

	protected override int GetTotalContentAmount()
	{
		return GoalController.singleton.totalGoals;
	}

	protected override int GetPageCount()
	{
		return GoalController.singleton.goalData.Length + 2;
	}

	protected override void UpdateContentForPage(int index)
	{
		if (index == 0)
		{
			scheduledShowCover = false;
		}
		else if (index < GetPageCount() - 1)
		{
			bool flag = false;
			if (!pageContents.ContainsKey(index))
			{
				flag = true;
				PageContent pageContent = new PageContent();
				pageContent.containerPrototype = containerPrototype;
				pageContents.Add(index, pageContent);
			}
			BaseGoals baseGoals = GoalController.singleton.goalData[index - 1];
			bool transitionBetweenGoals = false;
			if (scheduledGoalsToShow == baseGoals)
			{
				scheduledGoalsToShow = null;
				transitionBetweenGoals = true;
			}
			PageContent pageContent2 = pageContents[index];
			if (flag)
			{
				pageContent2.SetupEntries(baseGoals.GetTexts());
				AsciiObject[] doodles = baseGoals.doodles;
				pageContent2.doodles = doodles;
			}
			pageContent2.UpdateContent(baseGoals, transitionBetweenGoals);
		}
	}

	public void ScheduleShowCover()
	{
		scheduledShowCover = true;
		SequentialPopupManager.singleton.Enqueue(SequentialPopupManager.Mode.GoalBookScreen);
	}

	public void ScheduleShowGoals(BaseGoals goalData)
	{
		if ((scheduledGoalsToShow == null || goalData == null) && Inventory.Singleton.HasItemById("goal_book"))
		{
			scheduledGoalsToShow = goalData;
			SequentialPopupManager.singleton.Enqueue(SequentialPopupManager.Mode.GoalBookScreen);
		}
	}

	public bool IsScheduledToShow()
	{
		if (!scheduledShowCover)
		{
			return scheduledGoalsToShow != null;
		}
		return true;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == State.Idle && pageContents.ContainsKey(pageIndex))
		{
			pageContents[pageIndex].UpdateTic();
		}
		if (scheduledGoalsToShow != null && currentPage.IsPastHalfWayAnimation())
		{
			NextPage();
		}
	}

	protected override void DrawPageContents(AsciiRenderProcedural r, int offsetX, int offsetY, int index)
	{
		if (index == 0)
		{
			return;
		}
		if (pageContents.ContainsKey(index))
		{
			pageContents[index].Draw(r, offsetX, offsetY);
			return;
		}
		int num = ruleAString.lineCount + ruleBString.lineCount + ruleCString.lineCount;
		int num2 = offsetX - 17;
		int num3 = offsetY - 8;
		num2 -= 11;
		num3 += 2;
		if (num <= 13)
		{
			num3++;
		}
		ruleAString.Draw(r, num2, num3);
		num3 += 1 + ruleAString.lineCount;
		if (num <= 11)
		{
			num3++;
		}
		ruleBString.Draw(r, num2, num3);
		num3 += 1 + ruleBString.lineCount;
		if (num <= 11)
		{
			num3++;
		}
		ruleCString.Draw(r, num2, num3);
	}

	protected override void Awake()
	{
		base.Awake();
		singleton = this;
	}
}
