using System;
using System.Collections.Generic;
using PajamaLlama.Utilities;
using UnityEngine;

[Serializable]
public class DialogueBranch : ICloneable
{
	[SerializeField]
	private DialogueBranchType _type;

	[SerializeField]
	[ConditionalEnumHide("_type", 1, false, HideInInspector = true)]
	private string _name;

	[SerializeField]
	private DialogueNodeProperties _entryNode;

	[SerializeField]
	private bool _isDefaultBranch;

	[SerializeReference]
	[SubclassSelector]
	private List<IQuestObjective> _triggerConditions = new List<IQuestObjective>();

	[SerializeField]
	[HideInInspector]
	private ushort _uniqueID;

	public Action<DialogueNodeProperties> OnBranchTriggered;

	public DialogueBranchType Type => _type;

	public string Name => _name;

	public string Label
	{
		get
		{
			if (_type != DialogueBranchType.Reference)
			{
				return _type.ToString().SplitCamelCase();
			}
			return _type.ToString().SplitCamelCase() + ": " + _name;
		}
	}

	public DialogueNodeProperties EntryNode => _entryNode;

	public bool IsDefaultBranch => _isDefaultBranch;

	public IReadOnlyList<IQuestObjective> TriggerConditions => _triggerConditions;

	public ushort UniqueID => _uniqueID;

	public DialogueBranch()
	{
	}

	public DialogueBranch(DialogueNodeProperties entryNode)
	{
		_entryNode = entryNode;
	}

	public DialogueBranch(DialogueBranch other)
	{
		_type = other._type;
		_name = other._name;
		_entryNode = other._entryNode;
		_isDefaultBranch = other._isDefaultBranch;
		_triggerConditions = other._triggerConditions.Clone();
	}

	public void AssignUniqueID(ushort uniqueID)
	{
		_uniqueID = uniqueID;
	}

	public void Initialize()
	{
		foreach (IQuestObjective triggerCondition in _triggerConditions)
		{
			triggerCondition.InitializeDialogueTriggers();
			triggerCondition.Initialize();
		}
		FinalUpdate.RegisterEndOfFrameOneShot(RegisterObjectivesUpdated);
	}

	public void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestObjectiveUpdated, CheckObjectivesCompletion);
		foreach (IQuestObjective triggerCondition in _triggerConditions)
		{
			triggerCondition.Uninitialize();
			triggerCondition.UninitializeDialogueTriggers();
		}
	}

	public object Clone()
	{
		return new DialogueBranch(this);
	}

	private void TriggerBranch()
	{
		Uninitialize();
		DialogueGameEvent.DispatchBranchConditionsTriggered(_entryNode);
	}

	private void RegisterObjectivesUpdated()
	{
		GameEventDispatcher.AddListener(GameEventType.QuestObjectiveUpdated, CheckObjectivesCompletion);
		CheckObjectivesCompletion();
	}

	private void CheckObjectivesCompletion(GameEvent gameEvent = null)
	{
		if (AreConditionsCompleted())
		{
			TriggerBranch();
		}
	}

	private bool AreConditionsCompleted()
	{
		foreach (IQuestObjective triggerCondition in _triggerConditions)
		{
			if (!triggerCondition.IsOptional && !triggerCondition.IsCompleted())
			{
				return false;
			}
		}
		return true;
	}
}
