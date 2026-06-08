using System;
using System.Collections.Generic;
using UnityEngine;

public class EventQuestRow : DialogButton, INewIndicatorProvider
{
	public enum RowState
	{
		Loading = 0,
		Closed = 1,
		OpenWaiting = 2,
		Started = 3,
		ClaimingPoints = 4,
		RefillingObjectives = 5,
		OutOfObjectives = 6,
		Ended = 7
	}

	private float flyUpVelX = -1.9f;

	private float flyUpVelY = 1.5f;

	public AsciiString newLabel;

	public AsciiString questName;

	public AsciiString closedSubtitle;

	public AsciiString completeLabel;

	public AsciiMultiColorTextBox description;

	public int iconClosedX;

	private AsciiSprite icon;

	public DialogButton startButton;

	public DialogButton endButton;

	public DialogButton treasureButton;

	public DialogButton leaderboardButton;

	public AsciiSprite disabledButtonSprite;

	public AsciiString rewardPointsLabel;

	public EnchantBonusEventRewardSprite treasureIcon;

	public CountdownClockUI clock;

	public AsciiString outOfObjectivesSeparator;

	public AsciiString outOfObjectivesLine1;

	public AsciiString outOfObjectivesLine2;

	private ButtonSheen mySheen;

	public RowState currentRowState;

	private int elapsedRowStateTics;

	private int initialHeight;

	private int targetHeight;

	public EventObjectiveRow objectiveRowPrefab;

	private List<EventObjectiveRow> objectiveRows = new List<EventObjectiveRow>();

	private Stack<EventObjectiveRow> objectiveRowPool = new Stack<EventObjectiveRow>();

	private DateTime endDate;

	private int updateContentPending;

	private int refillObjectivesTimer;

	private int lastRewardPointsValue;

	private int elapsedLoadingLabelTics;

	private float outOfObjectivesNextLabelUpdateTime;

	private bool showRewardsScreenAfterClaim;

	private int rewardPointsClaiming;

	public ScrollContainer scrollContainer { get; set; }

	public BaseEventController2 eventController { get; private set; }

	public event Action<BaseEventController2> OnStartPressed;

	public event Action<Data.EventRewardCollection, DateTime> OnShowRewards;

	public event Action<Data.EventRewardCollection> OnLastChanceTriggered;

	public event Action OnShowLeaderboard;

	public event Action<string, string> OnShowObjectiveExtraInfo;

	public void Setup(BaseEventController2 eventController)
	{
		this.eventController = eventController;
		if (eventController.isReady)
		{
			_Setup();
		}
		else
		{
			SetRowState(RowState.Loading);
		}
	}

	private void _Setup()
	{
		string eventId = eventController.GetEventId();
		endDate = EventSchedules.singleton.GetDateTimeEnd(eventId);
		clock.Setup(endDate);
		treasureIcon.eventId = eventId;
		UpdateContent();
	}

	private void UpdateContent()
	{
		UpdateRewardPointsLabel();
		UpdateObjectiveContent();
		if (eventController.HasEventEnded())
		{
			SetRowState(RowState.Ended);
		}
		else if (eventController.HasEventStarted())
		{
			if (objectiveRows.Count > 0)
			{
				SetRowState(RowState.Started);
			}
			else
			{
				SetRowState(RowState.OutOfObjectives);
			}
		}
		else
		{
			SetRowState(RowState.Closed);
			mySheen.Play();
		}
	}

	public void SetRowState(RowState newState)
	{
		switch (newState)
		{
		case RowState.Loading:
			UpdateLoadingLabel();
			break;
		case RowState.Closed:
		case RowState.OpenWaiting:
			questName.SetValue("▶ " + Te.xt(eventController.data.name) + " ◀");
			break;
		default:
			questName.SetValue(Te.xt(eventController.data.name));
			break;
		}
		if (newState == RowState.OpenWaiting)
		{
			description.Text = Te.xt(eventController.data.description);
		}
		if ((newState == RowState.Closed || newState == RowState.OpenWaiting || newState == RowState.Ended) && eventController.data.iconPath != null)
		{
			icon = IconLoader.Singleton.GetSharedIcon(eventController.data.iconPath);
		}
		if (newState == RowState.Started || newState == RowState.Ended)
		{
			GameStates.Singleton.customQuestsScreen.focusedRow = this;
		}
		if (HeroSettings.isNameSet)
		{
			leaderboardButton.isDisabledState = false;
		}
		else
		{
			leaderboardButton.isDisabledState = true;
		}
		if (newState == RowState.ClaimingPoints)
		{
			EventObjectiveRow eventObjectiveRow = null;
			for (int i = 0; i < objectiveRows.Count; i++)
			{
				EventObjectiveRow eventObjectiveRow2 = objectiveRows[i];
				if (eventObjectiveRow2.claimButton.enabled && !eventObjectiveRow2.IsCollapsing() && !eventObjectiveRow2.IsHidden())
				{
					eventObjectiveRow = objectiveRows[i];
					break;
				}
			}
			if (!(eventObjectiveRow != null))
			{
				SetRowState(RowState.Started);
				return;
			}
			eventObjectiveRow.Collapse();
			int points = eventObjectiveRow.objData.rewardPoints;
			string text = ((points != 1) ? string.Format(Te.xt("tid_event_points_bonus"), points) : Te.xt("tid_event_points_single"));
			AnimatedResourceFlyup.singleton.Show(text, Color.cyan, eventObjectiveRow.claimButton.lastDrawX - 4, (float)eventObjectiveRow.claimButton.lastDrawY + 1f, treasureButton.lastDrawX + treasureButton.Width / 2, treasureButton.lastDrawY + treasureButton.Height / 2, flyUpVelX, flyUpVelY, delegate
			{
				UpdateRewardPointsLabel(points);
				rewardPointsLabel.color = Color.green * 2f;
				rewardPointsClaiming -= points;
				if (showRewardsScreenAfterClaim && rewardPointsClaiming == 0)
				{
					HandleTreasureButtonPressed(null);
				}
				else if (eventController.rewards.rewardPoints > eventController.rewards.maxRewardPoints)
				{
					int kiGain = lastRewardPointsValue;
					AnimatedResourceFlyup.singleton.Show("+@" + kiGain, ColorConstants.white, treasureButton.lastDrawX + treasureButton.Width / 2 + 2, treasureButton.lastDrawY + treasureButton.Height / 2, GameStates.Singleton.asciiRenderer.width - 3, 0f, 0f, 1f, delegate
					{
						InventoryResources.singleton.AddResourceOfType(Data.Resource.Xi, kiGain);
					});
				}
				if (rewardPointsClaiming == 0)
				{
					updateContentPending = 15;
				}
			});
		}
		targetHeight = ComputeHeightForState(newState);
		currentRowState = newState;
		elapsedRowStateTics = 0;
	}

	public override void UpdateTic()
	{
		elapsedRowStateTics++;
		if (currentRowState == RowState.Closed || currentRowState == RowState.OpenWaiting)
		{
			base.UpdateTic();
		}
		if (Height > targetHeight)
		{
			Height--;
			scrollContainer.UpdateForHeightChange();
			if (Height == targetHeight)
			{
				scrollContainer.UpdateForHeightChange();
				GameStates.Singleton.customQuestsScreen.ScheduleUpdateContainerPosition();
			}
		}
		else if (Height < targetHeight)
		{
			Height++;
			scrollContainer.UpdateForHeightChange();
			if (Height == targetHeight)
			{
				scrollContainer.UpdateForHeightChange();
				GameStates.Singleton.customQuestsScreen.ScheduleUpdateContainerPosition();
			}
		}
		if (currentRowState == RowState.Loading)
		{
			if (eventController.isReady)
			{
				_Setup();
			}
			else
			{
				UpdateLoadingLabel();
			}
		}
		else if (currentRowState == RowState.OpenWaiting)
		{
			startButton.UpdateTic();
		}
		else if (currentRowState == RowState.Started)
		{
			treasureButton.UpdateTic();
			leaderboardButton.UpdateTic();
			UpdateObjectiveTics();
			if (--refillObjectivesTimer <= 0)
			{
				refillObjectivesTimer = 30;
				if (!eventController.objectives.IsFull())
				{
					eventController.objectives.FillObjectives();
					if (eventController.objectives.activeObjectives.Count > 0)
					{
						UpdateObjectiveContent();
					}
				}
			}
			if (--updateContentPending == 0)
			{
				UpdateContent();
			}
			clock.UpdateTic();
			if (clock.hasExpired)
			{
				SetRowState(RowState.Ended);
			}
		}
		else if (currentRowState == RowState.ClaimingPoints)
		{
			UpdateObjectiveTics();
			if (elapsedRowStateTics == 20)
			{
				SetRowState(RowState.ClaimingPoints);
			}
		}
		else if (currentRowState == RowState.OutOfObjectives)
		{
			treasureButton.UpdateTic();
			leaderboardButton.UpdateTic();
			clock.UpdateTic();
			if (clock.hasExpired)
			{
				SetRowState(RowState.Ended);
			}
			if (eventController.objectives.HasDayChanged())
			{
				eventController.objectives.FillObjectives();
				if (eventController.objectives.activeObjectives.Count > 0)
				{
					UpdateObjectiveContent();
					SetRowState(RowState.Started);
				}
			}
		}
		else if (currentRowState == RowState.Ended)
		{
			endButton.UpdateTic();
		}
	}

	private void UpdateObjectiveTics()
	{
		for (int i = 0; i < objectiveRows.Count; i++)
		{
			objectiveRows[i].UpdateTic();
		}
	}

	private void UpdateRewardPointsLabel()
	{
		int num = 30;
		if (eventController != null)
		{
			lastRewardPointsValue = eventController.rewards.rewardPoints;
			num = eventController.rewards.maxRewardPoints;
		}
		rewardPointsLabel.SetValue(lastRewardPointsValue + "/" + num);
	}

	private void UpdateRewardPointsLabel(int incrementValue)
	{
		lastRewardPointsValue += incrementValue;
		int maxRewardPoints = eventController.rewards.maxRewardPoints;
		rewardPointsLabel.SetValue(lastRewardPointsValue + "/" + maxRewardPoints);
	}

	private void UpdateObjectiveContent()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < objectiveRows.Count; i++)
		{
			EventObjectiveRow eventObjectiveRow = objectiveRows[i];
			string id = eventObjectiveRow.objData.id;
			dictionary.Add(id, eventObjectiveRow.PositionY);
			objectiveRowPool.Push(eventObjectiveRow);
		}
		objectiveRows.Clear();
		int num = 0;
		List<EventObjectiveBase> activeObjectives = eventController.objectives.activeObjectives;
		for (int j = 0; j < activeObjectives.Count; j++)
		{
			EventObjectiveRow eventObjectiveRow2 = MakeObjectiveRow();
			EventObjectiveBase eventObjectiveBase = activeObjectives[j];
			eventObjectiveRow2.Setup(eventObjectiveBase);
			objectiveRows.Add(eventObjectiveRow2);
			if (dictionary.ContainsKey(eventObjectiveBase.id))
			{
				eventObjectiveRow2.f_posY = dictionary[eventObjectiveBase.id];
				continue;
			}
			num++;
			int delay = num * 30;
			eventObjectiveRow2.Expand(delay);
			eventObjectiveRow2.f_posY = -1f;
		}
	}

	private EventObjectiveRow MakeObjectiveRow()
	{
		if (objectiveRowPool.Count > 0)
		{
			return objectiveRowPool.Pop();
		}
		EventObjectiveRow eventObjectiveRow = UnityEngine.Object.Instantiate(objectiveRowPrefab);
		eventObjectiveRow.OnClaimed += HandleClaimObjective;
		eventObjectiveRow.OnExtraInfo += HandleObjectiveExtraInfo;
		return eventObjectiveRow;
	}

	private void UpdateLoadingLabel()
	{
		int num = elapsedLoadingLabelTics++ % 40;
		if (num == 0)
		{
			questName.SetValue(Te.xt("tid_event_loading"));
		}
		else if (num % 10 == 0)
		{
			questName.SetValue(" " + questName.Value + ".");
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		int num = offsetX + PositionX;
		int num2 = offsetY + PositionY;
		int num3 = Width / 2;
		if (currentRowState == RowState.Loading)
		{
			num2 += 2;
			questName.Draw(r, num + num3, num2);
			return;
		}
		if (currentRowState == RowState.Closed)
		{
			mySheen.Draw(r, num, num2);
		}
		r.PushClip(new AsciiRenderProcedural.Clip
		{
			bottom = r.height - (num2 + Height - 1)
		});
		if (currentRowState == RowState.Closed)
		{
			newLabel.Draw(r, num, num2);
			num2 += 3;
			questName.Draw(r, num + num3 - 7, num2);
			closedSubtitle.Draw(r, num + num3 - 7, num2);
			if (icon != null)
			{
				icon.Draw(r, num + iconClosedX, num2 - icon.height / 2);
			}
		}
		else if (currentRowState == RowState.OpenWaiting)
		{
			num2 += 2;
			questName.Draw(r, num + num3, num2);
			num2 += 2;
			if (icon != null)
			{
				icon.Draw(r, num + num3, num2 + icon.pivotY);
				num2 += icon.height + 1;
			}
			description.Draw(r, num, num2);
			num2 += description.lineCount + 1;
			startButton.Draw(r, num, num2);
		}
		else if (currentRowState == RowState.Ended)
		{
			num2 += 2;
			questName.Draw(r, num + num3, num2);
			num2++;
			completeLabel.Draw(r, num + num3, num2);
			num2 += 2;
			if (icon != null)
			{
				icon.Draw(r, num + num3, num2 + icon.pivotY);
				num2 += icon.height;
			}
			endButton.Draw(r, num, num2);
		}
		else
		{
			float t = Time.deltaTime * 6f;
			rewardPointsLabel.color = Color.Lerp(rewardPointsLabel.color, ColorConstants.white, t);
			treasureButton.Draw(r, num, num2);
			treasureIcon.Draw(r, num + treasureButton.PositionX + 5, num2 + treasureButton.PositionY + 1);
			rewardPointsLabel.Draw(r, num - (rewardPointsLabel.Length % 2 - 1), num2);
			leaderboardButton.Draw(r, num, num2);
			if (leaderboardButton.isDisabledState)
			{
				disabledButtonSprite.Draw(r, num + leaderboardButton.PositionX, num2 + leaderboardButton.PositionY);
			}
			num2 += 2;
			questName.Draw(r, num + num3, num2);
			num2 += 2;
			clock.Draw(r, num, num2);
			num2 += 2;
			if (currentRowState == RowState.Started || currentRowState == RowState.ClaimingPoints || currentRowState == RowState.RefillingObjectives)
			{
				DrawObjectives(r, num, num2);
				if (objectiveRows.Count == 1)
				{
					UpdateObjectivesCooldownLabel();
					num += num3;
					num2 += objectiveRows[0].Height + 2;
					outOfObjectivesLine2.Draw(r, num, num2);
				}
			}
			else if (currentRowState == RowState.OutOfObjectives)
			{
				UpdateObjectivesCooldownLabel();
				num += num3;
				num2++;
				outOfObjectivesSeparator.Draw(r, num, num2);
				num2 += 2;
				outOfObjectivesLine1.Draw(r, num, num2);
				num2++;
				outOfObjectivesLine2.Draw(r, num, num2);
				num2 += 2;
				outOfObjectivesSeparator.Draw(r, num, num2);
			}
		}
		r.PopClip();
	}

	private void DrawObjectives(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetY++;
		int num = 0;
		foreach (EventObjectiveRow objectiveRow in objectiveRows)
		{
			objectiveRow.PositionY = num;
			objectiveRow.Draw(r, offsetX, offsetY);
			num += objectiveRow.Height + 1;
		}
	}

	private void UpdateObjectivesCooldownLabel()
	{
		if (outOfObjectivesLine2.Length == 0 || outOfObjectivesNextLabelUpdateTime <= Time.realtimeSinceStartup)
		{
			outOfObjectivesNextLabelUpdateTime = Time.realtimeSinceStartup + 0.5f;
			string arg = Utils.FormatTimeCasual(Utils.GetSecondsUtilMidnight(), morePrecision: true);
			string format = Te.xt("tid_event_out_of_objs_2");
			format = string.Format(format, arg);
			outOfObjectivesLine2.SetValue(format);
		}
	}

	private int ComputeHeightForState(RowState state)
	{
		switch (state)
		{
		case RowState.Loading:
			return 5;
		case RowState.Closed:
			return initialHeight;
		case RowState.OpenWaiting:
		{
			int num2 = 4;
			if (icon != null)
			{
				num2 += 1 + icon.height;
			}
			num2 += 1 + description.lineCount;
			return num2 + (1 + startButton.Height);
		}
		case RowState.Started:
		case RowState.ClaimingPoints:
		case RowState.RefillingObjectives:
		{
			int num3 = 7;
			for (int i = 0; i < objectiveRows.Count; i++)
			{
				num3 += 1 + objectiveRows[i].Height;
			}
			if (objectiveRows.Count == 1)
			{
				num3 += 3;
			}
			return num3;
		}
		case RowState.OutOfObjectives:
			return 15;
		case RowState.Ended:
		{
			int num = 5;
			if (icon != null)
			{
				num += 1 + icon.height;
			}
			return num + endButton.Height;
		}
		default:
			return initialHeight;
		}
	}

	public virtual bool IsNewIndicating()
	{
		return currentRowState == RowState.Closed;
	}

	public virtual Color GetNewIndicatorColor()
	{
		return ColorConstants.red;
	}

	public virtual string GetNewIndicatorString()
	{
		return Te.xt("New!");
	}

	private void HandleClaimObjective(EventObjectiveRow row)
	{
		if (currentRowState == RowState.Started)
		{
			int rewardPoints = eventController.rewards.rewardPoints;
			eventController.ClaimCompletedObjectives();
			showRewardsScreenAfterClaim = rewardPoints < eventController.rewards.maxRewardPoints;
			rewardPointsClaiming = eventController.rewards.rewardPoints - rewardPoints;
			SetRowState(RowState.ClaimingPoints);
		}
	}

	private void HandleObjectiveExtraInfo(string infoText, string titleText)
	{
		if (this.OnShowObjectiveExtraInfo != null)
		{
			this.OnShowObjectiveExtraInfo(infoText, titleText);
		}
	}

	private void HandleOnPressed(DialogButton button)
	{
		if (currentRowState == RowState.Closed)
		{
			SetRowState(RowState.OpenWaiting);
		}
		else if (currentRowState == RowState.OpenWaiting)
		{
			SetRowState(RowState.Closed);
		}
	}

	private void HandleStartButtonPressed(DialogButton btn)
	{
		if (currentRowState == RowState.OpenWaiting)
		{
			eventController.StartEvent();
			UpdateObjectiveContent();
			SetRowState(RowState.Started);
			if (this.OnStartPressed != null)
			{
				this.OnStartPressed(eventController);
			}
		}
		if (!ProgressFlags.GetFlag("freetkts2"))
		{
			ProgressFlags.SetFlag("freetkts2");
			Item item = Inventory.Singleton.MakeReward("event_ticket", 1);
			Inventory.Singleton.AddItem(item, 20);
			SequentialPopupManager.singleton.ScheduleItemFound(item, 20);
		}
		ProgressFlags.Remove("freetkts");
	}

	private void HandleTreasureButtonPressed(DialogButton btn)
	{
		FireShowRewards();
	}

	public void FireShowRewards()
	{
		if (this.OnShowRewards != null && eventController.rewards.data != null)
		{
			this.OnShowRewards(eventController.rewards.data, endDate);
		}
	}

	private void HandleLeaderboardButtonPressed(DialogButton btn)
	{
		FireShowLeaderboard();
	}

	public void FireShowLeaderboard()
	{
		if (this.OnShowLeaderboard != null)
		{
			this.OnShowLeaderboard();
		}
	}

	private void HandleEndButtonPressed(DialogButton btn)
	{
		if (!(HeroSettings.lastSaveTime - DateTime.Now > new TimeSpan(24, 0, 0)))
		{
			if (eventController.rewards.rewardPoints > 0 && !eventController.HasPremiumAccess() && !EventController.singleton.HasCompletedYear(eventController.GetEventId(), eventController.rewards.eventStartDate.Year) && this.OnLastChanceTriggered != null)
			{
				this.OnLastChanceTriggered(eventController.rewards.data);
			}
			else
			{
				eventController.CollectRewardsAndEnd();
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		base.OnPressed += HandleOnPressed;
		initialHeight = Height;
		mySheen = GetComponent<ButtonSheen>();
		startButton.OnPressed += HandleStartButtonPressed;
		treasureButton.OnPressed += HandleTreasureButtonPressed;
		leaderboardButton.OnPressed += HandleLeaderboardButtonPressed;
		endButton.OnPressed += HandleEndButtonPressed;
	}

	protected override void OnDestroy()
	{
		base.OnPressed -= HandleOnPressed;
		startButton.OnPressed -= HandleStartButtonPressed;
		treasureButton.OnPressed -= HandleTreasureButtonPressed;
		leaderboardButton.OnPressed -= HandleLeaderboardButtonPressed;
		endButton.OnPressed -= HandleEndButtonPressed;
		base.OnDestroy();
	}

	public void Close()
	{
		if (currentRowState == RowState.OpenWaiting)
		{
			SetRowState(RowState.Closed);
		}
	}
}
