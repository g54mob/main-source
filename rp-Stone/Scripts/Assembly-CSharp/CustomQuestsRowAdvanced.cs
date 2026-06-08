using System;
using System.Collections.Generic;
using Stonescript;
using UnityEngine;

public class CustomQuestsRowAdvanced : CustomQuestsRow, INewIndicatorProvider
{
	public enum RowMode
	{
		Loading = 0,
		Active = 1,
		Inactive = 2,
		Completed = 3,
		Restricted = 4,
		Error = 5
	}

	public enum RowState
	{
		Locked = 0,
		Closed = 1,
		Open = 2,
		Opening = 3,
		Closing = 4
	}

	public AsciiString unlockLabel;

	public AsciiString completedLabel;

	public AsciiString newLabel;

	public AsciiString restrictionLabel;

	public AsciiString supertitle;

	public AsciiString questName;

	public AsciiMultiColorTextBox titleBox;

	public int iconX;

	public int iconY;

	private AsciiSprite icon;

	public AsciiSprite loadingIcon;

	public DialogButton actionButtonPrefab;

	public DialogButton cancelQuestButton;

	private Data.CustomQuest questDef;

	private ButtonSheen mySheen;

	public RowMode currentRowMode = RowMode.Inactive;

	public RowState currentRowState;

	private string error;

	private int initialHeight;

	private int targetHeight;

	private int initialActionButtonWidth;

	private List<DialogButton> actionButtons = new List<DialogButton>();

	private Stack<DialogButton> actionButtonPool = new Stack<DialogButton>();

	private bool showCancelButton;

	private string actionCallback;

	private bool isNew;

	private static float startButtonLastPressedTime;

	private float nextRestrictedRowRefresh;

	private bool abortButtonUpdate;

	private List<object> callbackParams = new List<object>();

	public Data.CustomQuest QuestDef => questDef;

	public ScrollContainer scrollContainer { get; set; }

	public void Setup(Data.CustomQuest questDef, bool open = false)
	{
		quest = null;
		this.questDef = questDef;
		SetTitle(Te.xt(questDef.title));
		if (questDef.icon != null)
		{
			icon = IconLoader.Singleton.GetSharedIcon(questDef.icon);
		}
		if (currentRowMode == RowMode.Error)
		{
			titleBox.Text = ((error != null) ? error : "An unknown error has occurred.");
			titleBox.color = Color.red;
			currentRowMode = RowMode.Error;
			showCancelButton = false;
			ClearActionButtons();
			SetRowState((!open) ? RowState.Closed : RowState.Open);
			return;
		}
		titleBox.color = Color.white;
		if (CustomQuestsController.Singleton.IsQuestLoading(questDef))
		{
			titleBox.Text = "";
			currentRowMode = RowMode.Loading;
			showCancelButton = false;
			ClearActionButtons();
			SetRowState((!open) ? RowState.Closed : RowState.Open);
			return;
		}
		titleBox.Text = Te.xt(questDef.intro);
		isNew = false;
		int completedCount = CustomQuestsController.Singleton.GetCompletedCount(questDef.id);
		if (completedCount == 0)
		{
			isNew = true;
		}
		string text = null;
		string questRestriction = CustomQuestsController.Singleton.GetQuestRestriction(questDef);
		if (questRestriction == null)
		{
			if (completedCount == 0)
			{
				currentRowMode = RowMode.Inactive;
				text = "Start Quest";
			}
			else
			{
				currentRowMode = RowMode.Completed;
				text = "Replay";
			}
		}
		else
		{
			currentRowMode = RowMode.Restricted;
			restrictionLabel.SetValue(questRestriction);
			if (CustomQuestsController.Singleton.IsOnCooldown(questDef))
			{
				restrictionLabel.color = ColorConstants.thirdGrey;
			}
			else
			{
				restrictionLabel.color = ColorConstants.yellow;
			}
		}
		showCancelButton = false;
		ClearActionButtons();
		if (text != null)
		{
			AddActionButton(text, delegate
			{
				if (Time.realtimeSinceStartup > startButtonLastPressedTime + 5f)
				{
					startButtonLastPressedTime = Time.realtimeSinceStartup;
					GameStates.Singleton.customQuestsScreen.TryReplay(questDef);
				}
			});
		}
		if (!CustomQuestsController.Singleton.IsEpicRevealed(questDef.id))
		{
			Height = initialHeight;
			SetRowState(RowState.Locked);
			mySheen.Play();
		}
		else
		{
			SetRowState((!open) ? RowState.Closed : RowState.Open);
		}
	}

	public void Setup(Data.CustomQuestInstance quest, bool open = false)
	{
		if (quest.completed || !quest.started)
		{
			Setup(quest.def, open);
			return;
		}
		base.quest = quest;
		questDef = quest.def;
		SetTitle(Te.xt(quest.Title));
		if (quest.Icon != null)
		{
			icon = IconLoader.Singleton.GetSharedIcon(quest.Icon);
		}
		if (currentRowMode == RowMode.Error)
		{
			titleBox.Text = ((error != null) ? error : "An unknown error has occurred.");
			titleBox.color = Color.red;
			currentRowMode = RowMode.Error;
			showCancelButton = false;
			ClearActionButtons();
			SetRowState((!open) ? RowState.Closed : RowState.Open);
			return;
		}
		titleBox.color = Color.white;
		if (!quest.loaded)
		{
			titleBox.Text = "";
			currentRowMode = RowMode.Loading;
			showCancelButton = false;
			ClearActionButtons();
			SetRowState((!open) ? RowState.Closed : RowState.Open);
		}
		else
		{
			titleBox.Text = quest.status;
			currentRowMode = RowMode.Active;
			isNew = false;
			showCancelButton = true;
			ClearActionButtons();
			BindActionButtons();
			SetRowState((!open) ? RowState.Closed : RowState.Open);
		}
	}

	private void SetTitle(string text)
	{
		int num = text.IndexOf('\n');
		if (num > 0 && num < text.Length - 1)
		{
			supertitle.SetValue(text.Substring(0, num));
			questName.SetValue(text.Substring(num + 1));
		}
		else
		{
			supertitle.Clear();
			questName.SetValue(text);
		}
	}

	public void SetRowState(RowState newState)
	{
		switch (newState)
		{
		case RowState.Closed:
			Height = initialHeight;
			scrollContainer.UpdateForHeightChange();
			GameStates.Singleton.customQuestsScreen.ScheduleUpdateContainerPosition();
			break;
		case RowState.Opening:
			targetHeight = ComputeOpenedHeight();
			break;
		case RowState.Closing:
			targetHeight = initialHeight;
			break;
		case RowState.Open:
			targetHeight = ComputeOpenedHeight();
			Height = targetHeight;
			scrollContainer.UpdateForHeightChange();
			GameStates.Singleton.customQuestsScreen.ScheduleUpdateContainerPosition();
			break;
		}
		currentRowState = newState;
	}

	public override void UpdateTic()
	{
		if (currentRowState != RowState.Opening && currentRowState != RowState.Closing)
		{
			base.UpdateTic();
		}
		if (currentRowState == RowState.Open)
		{
			UpdateActionButtons();
		}
		else if (currentRowState == RowState.Opening)
		{
			Height++;
			scrollContainer.UpdateForHeightChange();
			if (Height >= targetHeight)
			{
				SetRowState(RowState.Open);
			}
		}
		else if (currentRowState == RowState.Closing)
		{
			Height--;
			scrollContainer.UpdateForHeightChange();
			if (Height <= targetHeight)
			{
				SetRowState(RowState.Closed);
			}
		}
		if (currentRowMode == RowMode.Restricted && Time.realtimeSinceStartup >= nextRestrictedRowRefresh)
		{
			nextRestrictedRowRefresh = Time.realtimeSinceStartup + 1f;
			string questRestriction = CustomQuestsController.Singleton.GetQuestRestriction(questDef);
			if (questRestriction != null)
			{
				restrictionLabel.SetValue(questRestriction);
			}
			else
			{
				Setup(questDef, currentRowState == RowState.Open);
			}
		}
	}

	private void UpdateActionButtons()
	{
		abortButtonUpdate = false;
		foreach (DialogButton actionButton in actionButtons)
		{
			actionButton.UpdateTic();
			if (abortButtonUpdate)
			{
				break;
			}
		}
		if (showCancelButton)
		{
			cancelQuestButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		int num = offsetX + PositionX;
		int num2 = offsetY + PositionY;
		if (currentRowState == RowState.Locked)
		{
			unlockLabel.Draw(r, num, num2);
			mySheen.Draw(r, num, num2);
			return;
		}
		icon.Draw(r, num + iconX, num2 + iconY);
		questName.Draw(r, num, num2);
		supertitle.Draw(r, num, num2);
		r.PushClip(new AsciiRenderProcedural.Clip
		{
			bottom = r.height - (num2 + Height - 1)
		});
		if (currentRowState == RowState.Open || currentRowState == RowState.Opening || currentRowState == RowState.Closing)
		{
			DrawSeparator(r, num, num2);
			titleBox.Draw(r, num, num2);
			DrawActionButtons(r, num, num2);
			if (currentRowMode == RowMode.Restricted)
			{
				restrictionLabel.PositionY = Height - 3;
				restrictionLabel.Draw(r, num, num2);
			}
		}
		if (currentRowMode == RowMode.Completed || (!isNew && currentRowMode == RowMode.Restricted))
		{
			completedLabel.Draw(r, num, num2);
		}
		else if (isNew && currentRowMode != RowMode.Restricted && currentRowState == RowState.Closed)
		{
			newLabel.Draw(r, num, num2);
		}
		if (currentRowState == RowState.Open && currentRowMode == RowMode.Loading)
		{
			loadingIcon.Draw(r, num, num2);
		}
		if (currentRowState == RowState.Closed && currentRowMode == RowMode.Active)
		{
			r.SetCell(num + Width - 3, num2 + 1, SpecialSymbols.Map('•'), ColorConstants.rewardGreen);
		}
		r.PopClip();
	}

	private void DrawSeparator(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		for (int i = 0; i < 43; i += 2)
		{
			r.SetCell(i + 1 + offsetX, 5 + offsetY, 46, ColorConstants.lightGrey);
		}
	}

	private void DrawActionButtons(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (!showCancelButton)
		{
			offsetX += 2;
		}
		offsetY += titleBox.positionY + titleBox.lineCount + 1;
		foreach (DialogButton actionButton in actionButtons)
		{
			actionButton.Draw(r, offsetX, offsetY);
			offsetY += actionButton.Height;
		}
		if (showCancelButton)
		{
			offsetX += actionButtonPrefab.Width + actionButtonPrefab.PositionX;
			if (actionButtons.Count == 0)
			{
				offsetY += cancelQuestButton.Height - 1;
			}
			cancelQuestButton.Draw(r, offsetX, offsetY);
		}
	}

	private int ComputeOpenedHeight()
	{
		int num = initialHeight;
		num += 2;
		num += titleBox.lineCount;
		if (actionButtons.Count > 0)
		{
			num++;
			num += actionButtonPrefab.Height * actionButtons.Count;
		}
		else if (showCancelButton)
		{
			num += cancelQuestButton.Height - 1;
		}
		else if (currentRowMode == RowMode.Loading || currentRowMode == RowMode.Restricted)
		{
			num += 2;
		}
		return num;
	}

	private void HandleActionButtonPressed(DialogButton button)
	{
		GameStates.Singleton.customQuestsScreen.focusedRow = this;
		GameStates.Singleton.customQuestsScreen.hasInteractedWithEpic = true;
		abortButtonUpdate = true;
		int num = actionButtons.IndexOf(button);
		if (num < 0 || actionCallback == null)
		{
			return;
		}
		string text = actionCallback;
		if (quest.ssQuest.HasFunction(text))
		{
			IFunction function = quest.ssQuest.GetFunction(text);
			if (function == null)
			{
				Debug.LogWarning("Invalid action callback \"" + text + "\".");
				return;
			}
			callbackParams.Clear();
			List<string> parameterNames = function.ParameterNames;
			if (parameterNames != null && parameterNames.Count == 1)
			{
				callbackParams.Add(num);
			}
			function.Invoke(callbackParams);
		}
		else
		{
			Debug.LogWarning("Invalid action callback \"" + text + "\".");
		}
	}

	private void ClearActionButtons()
	{
		foreach (DialogButton actionButton in actionButtons)
		{
			actionButtonPool.Push(actionButton);
			actionButton.ClearOnPressed();
		}
		actionButtons.Clear();
		actionCallback = null;
	}

	private DialogButton AddActionButton(string label, Action<DialogButton> onPressed = null)
	{
		DialogButton dialogButton = ((actionButtonPool.Count <= 0) ? UnityEngine.Object.Instantiate(actionButtonPrefab) : actionButtonPool.Pop());
		actionButtons.Add(dialogButton);
		if (onPressed != null)
		{
			dialogButton.OnPressed += onPressed;
		}
		else
		{
			dialogButton.OnPressed += HandleActionButtonPressed;
		}
		string text = Te.xt(label);
		dialogButton.label.SetValue(text);
		dialogButton.Width = Mathf.Clamp(text.Length + 2, initialActionButtonWidth, initialActionButtonWidth + 2);
		dialogButton.label.PositionX = dialogButton.Width / 2;
		if (label == "tid_quest_button_complete")
		{
			dialogButton.pressedSfxId = "buy";
			showCancelButton = false;
		}
		else
		{
			dialogButton.pressedSfxId = "confirm";
		}
		return dialogButton;
	}

	public void BindActionButtons()
	{
		ClearActionButtons();
		List<string> actions = quest.actions;
		if (quest.actions.Count > 0)
		{
			actionCallback = actions[0];
			for (int i = 1; i < actions.Count; i++)
			{
				string text = actions[i];
				AddActionButton(text);
			}
		}
	}

	public virtual bool IsNewIndicating()
	{
		if (quest != null)
		{
			return !quest.seen;
		}
		return false;
	}

	public virtual Color GetNewIndicatorColor()
	{
		return ColorConstants.red;
	}

	public virtual string GetNewIndicatorString()
	{
		return Te.xt("New!");
	}

	private void HandleOnPressed(DialogButton button)
	{
		if (currentRowState == RowState.Closed)
		{
			SetRowState(RowState.Opening);
		}
		else if (currentRowState == RowState.Open)
		{
			SetRowState(RowState.Closing);
		}
	}

	private void HandleCancelQuestPressed(DialogButton button)
	{
		GameStates.Singleton.customQuestsScreen.TryAbandon(quest);
	}

	protected override void Awake()
	{
		base.Awake();
		base.OnPressed += HandleOnPressed;
		cancelQuestButton.OnPressed += HandleCancelQuestPressed;
		initialHeight = Height;
		initialActionButtonWidth = actionButtonPrefab.Width;
		mySheen = GetComponent<ButtonSheen>();
	}

	protected override void OnDestroy()
	{
		ClearActionButtons();
		base.OnPressed -= HandleOnPressed;
		cancelQuestButton.OnPressed -= HandleCancelQuestPressed;
		base.OnDestroy();
	}

	public void Close()
	{
		SetRowState(RowState.Closed);
	}

	public void SetError(string error)
	{
		this.error = error;
		currentRowMode = RowMode.Error;
		if (quest != null)
		{
			Setup(quest);
		}
		else
		{
			Setup(questDef);
		}
	}

	public void ClearError()
	{
		error = null;
		currentRowMode = RowMode.Loading;
		if (quest != null)
		{
			Setup(quest, currentRowState != RowState.Closed);
		}
		else
		{
			Setup(questDef, currentRowState != RowState.Closed);
		}
	}
}
