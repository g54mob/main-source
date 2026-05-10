using System;
using System.Collections;
using System.Collections.Generic;
using CTS;
using CTS.Core;
using NaughtyAttributes;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

public abstract class Quest : CTSBehaviour
{
	public enum EQuestType
	{
		Main = 0,
		Secondary = 1,
		Circumstantial = 2
	}

	public enum ETargetStyle
	{
		HigherOrEqual = 0,
		LowerOrEqual = 1
	}

	[SerializeField]
	[QuestPopup(true)]
	protected string _questName;

	[SerializeField]
	protected float _startDelay = 1f;

	[SerializeField]
	protected float _outroDelay = 8f;

	private LocalizedString _localizedQuestName = new LocalizedString();

	private LocalizedString _localizedQuestDescription = new LocalizedString();

	private LocalizedString _localizedQuestReward = new LocalizedString();

	private bool _introConversationEnded;

	private QuestState _previousState = QuestState.Unassigned;

	private List<QuestGoal> _goals;

	private string _questGUID = "";

	public string QuestGUID
	{
		get
		{
			if (_questGUID == "")
			{
				_questGUID = GUIDHelper.GenerateQuestGUID(_questName);
			}
			return _questGUID;
		}
	}

	public string QuestName => _questName;

	public string QuestLocalizedName => FormattedText.Parse(_localizedQuestName.GetLocalizedStringSafe(), DialogueManager.masterDatabase.emphasisSettings).text;

	public QuestState QuestState
	{
		get
		{
			return QuestLog.GetQuestState(_questName);
		}
		protected set
		{
			QuestLog.SetQuestState(_questName, value);
		}
	}

	public bool IsActive => QuestState == QuestState.Active;

	public int QuestEntriesAmount => QuestLog.GetQuestEntryCount(_questName);

	public string QuestLocalizedRewardDescription => FormattedText.Parse(_localizedQuestReward.GetLocalizedStringSafe(), DialogueManager.masterDatabase.emphasisSettings).text;

	public EQuestType QuestType { get; protected set; }

	public List<BBTBaseGoal> Goals { get; protected set; } = new List<BBTBaseGoal>();

	public static event Action<Quest> QuestStarted;

	public static event Action<Quest> QuestResumed;

	public static event Action<Quest, int> QuestEntryUpdated;

	public static event Action<Quest, int> QuestEntrySucceeded;

	public static event Action<Quest> QuestSucceeded;

	public static event Action<Quest> QuestValidated;

	public static event Action<Quest> QuestFailed;

	public event Action IntroDialogueStarting;

	public event Action Started;

	public event Action Resumed;

	public event Action<int> EntryUpdated;

	public event Action<int> EntrySucceeded;

	public event Action Succeeded;

	public event Action Validated;

	public event Action Failed;

	public event Action Skipped;

	public void ResumeQuest()
	{
		_previousState = QuestState;
		SetupQuest();
		StartObservingObjectives();
		OnResumeQuest();
		Quest.QuestResumed?.Invoke(this);
		this.Resumed?.Invoke();
		if (QuestState != QuestState.Success && AreAllQuestEntriesSuccess())
		{
			StartCoroutine(QuestSuccessCoroutine());
		}
	}

	protected virtual void OnResumeQuest()
	{
	}

	public virtual QuestState GetQuestState()
	{
		return QuestState;
	}

	protected void ResetGoalsVariables()
	{
		foreach (BBTBaseGoal goal in Goals)
		{
			goal.ResetVariable();
		}
	}

	protected void SetupGoalsTargets()
	{
		foreach (BBTBaseGoal goal in Goals)
		{
			goal.SetupTarget();
		}
	}

	protected void StopObservingGoals()
	{
		foreach (BBTBaseGoal goal in Goals)
		{
			goal.StopObserving();
		}
	}

	protected void ResetVariableTo0(params string[] variablesName)
	{
		for (int i = 0; i < variablesName.Length; i++)
		{
			DialogueLua.SetVariable(variablesName[i], 0);
		}
	}

	public void ResetQuest()
	{
		QuestLog.SetQuestState(_questName, QuestState.Unassigned);
		for (int i = 1; i <= QuestLog.GetQuestEntryCount(_questName); i++)
		{
			QuestLog.SetQuestEntryState(_questName, i, QuestState.Unassigned);
		}
		ResetGoalsVariables();
		OnResetQuest();
	}

	protected virtual void OnResetQuest()
	{
	}

	public virtual void StartQuest()
	{
		if (QuestLog.GetQuestState(_questName) == QuestState.Unassigned)
		{
			StopAllCoroutines();
			StartCoroutine(StartQuestCoroutine());
		}
	}

	private void SetupQuest()
	{
		SetupLocalizedStrings();
		QuestSetup();
	}

	protected virtual void QuestSetup()
	{
	}

	protected virtual IEnumerator QuestIntroduction()
	{
		yield break;
	}

	protected void StoppingObservingObjectives()
	{
		StopObservingGoals();
		StopObservingObjectives();
	}

	protected virtual void StopObservingObjectives()
	{
	}

	protected abstract void StartObservingObjectives();

	private void OnQuestStateChanged(string questName, QuestState state)
	{
		if (!(_questName != questName) && _previousState != state)
		{
			_previousState = state;
			if (state == QuestState.Active)
			{
				this.Started?.Invoke();
				StoppingObservingObjectives();
				StartObservingObjectives();
			}
			else
			{
				StoppingObservingObjectives();
			}
		}
	}

	public virtual void SuccessConfirmation()
	{
	}

	public virtual void ValidateQuest()
	{
		if (QuestState == QuestState.ReturnToNPC)
		{
			this.Validated?.Invoke();
			Quest.QuestValidated?.Invoke(this);
			QuestLog.SetQuestState(_questName, QuestState.Success);
		}
	}

	public virtual void FailQuest()
	{
		QuestLog.SetQuestState(_questName, QuestState.Failure);
		Quest.QuestFailed?.Invoke(this);
		this.Failed?.Invoke();
	}

	public virtual void SkipQuest()
	{
		StopAllCoroutines();
		SetAllQuestEntriesToSuccess();
		QuestLog.SetQuestState(_questName, QuestState.Success);
		this.Skipped?.Invoke();
	}

	[Obsolete("Might not be compatible with the new quest tracker.")]
	public void PauseQuestTracking(bool pause)
	{
		QuestLog.SetQuestTracking(_questName, !pause);
	}

	protected bool IncrementQuestEntryVariable(int entry, string progressVariableName, float increment, string maxVariableName, ETargetStyle targetStyle = ETargetStyle.HigherOrEqual)
	{
		bool result = false;
		float asFloat = DialogueLua.GetVariable(maxVariableName).asFloat;
		if (QuestLog.GetQuestEntryState(_questName, entry) == QuestState.Active)
		{
			double num = Math.Round(DialogueLua.GetVariable(progressVariableName).asFloat + increment, 2);
			switch (targetStyle)
			{
			case ETargetStyle.HigherOrEqual:
				if (num >= (double)asFloat)
				{
					num = asFloat;
					result = true;
				}
				break;
			case ETargetStyle.LowerOrEqual:
				if (num <= (double)asFloat)
				{
					num = asFloat;
					result = true;
				}
				break;
			}
			DialogueLua.SetVariable(progressVariableName, num);
			this.EntryUpdated?.Invoke(entry);
			Quest.QuestEntryUpdated?.Invoke(this, entry);
		}
		return result;
	}

	protected bool IncrementQuestEntryVariable(int entry, string progressVariableName, int increment, string maxVariableName, ETargetStyle targetStyle = ETargetStyle.HigherOrEqual)
	{
		return IncrementQuestEntryVariable(entry, progressVariableName, (float)increment, maxVariableName, targetStyle);
	}

	protected bool SetQuestEntryVariable(int entry, string progressVariableName, int newValue, string maxVariableName, ETargetStyle targetStyle = ETargetStyle.HigherOrEqual)
	{
		int asInt = DialogueLua.GetVariable(progressVariableName).asInt;
		return IncrementQuestEntryVariable(entry, progressVariableName, newValue - asInt, maxVariableName, targetStyle);
	}

	protected bool SetQuestEntryVariable(int entry, string progressVariableName, float newValue, string maxVariableName, ETargetStyle targetStyle = ETargetStyle.HigherOrEqual)
	{
		float asFloat = DialogueLua.GetVariable(progressVariableName).asFloat;
		return IncrementQuestEntryVariable(entry, progressVariableName, newValue - asFloat, maxVariableName, targetStyle);
	}

	protected virtual void QuestEntrySuccess(int entry)
	{
		if (QuestLog.GetQuestEntryState(_questName, entry) != QuestState.Success)
		{
			QuestLog.SetQuestEntryState(_questName, entry, QuestState.Success);
			this.EntryUpdated?.Invoke(entry);
			Quest.QuestEntryUpdated?.Invoke(this, entry);
			this.EntrySucceeded?.Invoke(entry);
			Quest.QuestEntrySucceeded?.Invoke(this, entry);
			SuccessCheck();
		}
	}

	protected virtual void QuestEntryCancelSuccess(int entry)
	{
		QuestLog.SetQuestEntryState(_questName, entry, QuestState.Active);
		this.EntryUpdated?.Invoke(entry);
		Quest.QuestEntryUpdated?.Invoke(this, entry);
	}

	public void WarnEntryUpdate(int entry)
	{
		this.EntryUpdated?.Invoke(entry);
		Quest.QuestEntryUpdated?.Invoke(this, entry);
	}

	public virtual void SuccessCheck()
	{
		if (AreAllQuestEntriesSuccess())
		{
			StartSuccess(waitDelay: false);
		}
	}

	protected bool AreAllQuestEntriesSuccess()
	{
		for (int i = 1; i <= QuestLog.GetQuestEntryCount(_questName); i++)
		{
			if (QuestLog.GetQuestEntryState(_questName, i) != QuestState.Success)
			{
				return false;
			}
		}
		return true;
	}

	protected void SetAllQuestEntriesToSuccess()
	{
		for (int i = 1; i <= QuestLog.GetQuestEntryCount(_questName); i++)
		{
			if (QuestLog.GetQuestEntryState(_questName, i) != QuestState.Success)
			{
				QuestLog.SetQuestEntryState(_questName, i, QuestState.Success);
			}
		}
	}

	protected bool IsEntryStateActive(int entryId)
	{
		return QuestLog.GetQuestEntryState(_questName, entryId) == QuestState.Active;
	}

	protected virtual void SetMissionBasket(StockMissionData stockMissionData)
	{
		CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.SetMission(stockMissionData);
	}

	protected virtual void CancelMissionBasket()
	{
		CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.ClearBasket();
	}

	private IEnumerator StartQuestCoroutine()
	{
		SetupQuest();
		yield return Coroutines.WaitForSecondsUnscaled(_startDelay);
		yield return QuestIntroduction();
		for (int i = 1; i <= QuestEntriesAmount; i++)
		{
			QuestLog.SetQuestEntryState(_questName, i, QuestState.Active);
		}
		QuestLog.SetQuestState(_questName, QuestState.Active);
		Quest.QuestStarted?.Invoke(this);
	}

	public void StartSuccess(bool waitDelay = true, bool playOutro = true)
	{
		StartCoroutine(QuestSuccessCoroutine(waitDelay, playOutro));
	}

	private IEnumerator QuestSuccessCoroutine(bool playDelay = true, bool playOutro = true)
	{
		StoppingObservingObjectives();
		if (playDelay)
		{
			yield return StartCoroutine(Coroutines.WaitForSecondsUnscaled(_outroDelay));
		}
		QuestLog.SetQuestState(_questName, QuestState.Success);
		if (playOutro)
		{
			yield return StartCoroutine(QuestOutroCoroutine());
		}
		OnQuestSuccess();
	}

	protected virtual IEnumerator QuestOutroCoroutine()
	{
		yield break;
	}

	protected virtual void OnQuestSuccess()
	{
		StopAllCoroutines();
		this.Succeeded?.Invoke();
		Quest.QuestSucceeded?.Invoke(this);
	}

	public virtual IEnumerator QuestPostSuccessCoroutine()
	{
		yield break;
	}

	public void SetupLocalizedStrings()
	{
		string questGUID = QuestGUID;
		string text = GUIDHelper.FindTableID(questGUID);
		_localizedQuestName.SetReference(text, questGUID);
		_localizedQuestDescription.SetReference(text, questGUID + "_Description");
		_localizedQuestReward.SetReference(text, questGUID + "_SuccessDescription");
	}

	protected override void OnEnabled()
	{
		QuestsEvents.QuestStateChanged += OnQuestStateChanged;
	}

	protected override void OnDisabled()
	{
		QuestsEvents.QuestStateChanged -= OnQuestStateChanged;
		StoppingObservingObjectives();
	}

	[Button(null, EButtonEnableMode.Always)]
	private void TryStartQuest()
	{
		StartQuest();
	}

	[Button(null, EButtonEnableMode.Always)]
	private void ForceQuestActive()
	{
		ResetQuest();
		StartQuest();
	}

	public virtual void ForceQuestSuccess()
	{
		StopAllCoroutines();
		SetAllQuestEntriesToSuccess();
		StartSuccess(waitDelay: false);
	}

	[Button(null, EButtonEnableMode.Always)]
	private void ForceSuccess()
	{
		ForceQuestSuccess();
	}
}
