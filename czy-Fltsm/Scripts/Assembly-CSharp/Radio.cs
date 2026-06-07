using System;
using I2.Loc;
using UnityEngine;

public class Radio : SceneBehaviour, IBuildableExtendable, IPersistentReference, ILocalizationParamsManager
{
	[SerializeField]
	private AgentProfile[] _specialists;

	private PlaceableAlertProperties _malfunction;

	private Quest _blockingQuest;

	public AgentProfile[] Specialists => _specialists;

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; }

	private void LateUpdate()
	{
		RadioMessagesManager radioMessagesManager = GameManager.RadioMessagesManager;
		GameplaySettings gameplaySettings = GameSettings.Instance.GameplaySettings;
		Quest quest;
		if (radioMessagesManager.IsReceivingRadioSignals)
		{
			SetMalfunction(gameplaySettings.RadioReceivingAlert);
			SetBlockingQuest(null);
		}
		else if (WorldManager.HasEndTile)
		{
			SetMalfunction(gameplaySettings.RadioEndTileAlert);
			SetBlockingQuest(null);
		}
		else if (TryGetBlockingQuest(out quest, radioMessagesManager))
		{
			SetMalfunction(gameplaySettings.RadioBlockedAlert);
			SetBlockingQuest(quest);
		}
		else
		{
			SetMalfunction(gameplaySettings.RadioMoveEastAlert);
			SetBlockingQuest(null);
		}
	}

	private void SetMalfunction(PlaceableAlertProperties malfunction)
	{
		if (!(_malfunction == malfunction))
		{
			Buildable.RemoveMalfunction(_malfunction);
			_malfunction = malfunction;
			if ((bool)_malfunction)
			{
				Buildable.AddMalfunction(_malfunction);
			}
		}
	}

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
	}

	public void Activate()
	{
		Active = true;
	}

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public bool CanBeSalvaged()
	{
		return true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void Finish(bool restored = false)
	{
	}

	public bool IsEnabled()
	{
		throw new NotImplementedException();
	}

	public void OnDeconstruct()
	{
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		Debug.LogWarning("TODO: Implement persistence for Radio");
	}

	public void Remove()
	{
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
		Debug.LogWarning("TODO: Implement persistence for Radio");
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		Debug.LogWarning("TODO: Implement persistence for Radio");
	}

	public string ReturnDescription(string description)
	{
		return description;
	}

	public float ReturnWeight()
	{
		return 0f;
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		Debug.LogWarning("TODO: Implement persistence for Radio");
		return null;
	}

	public void Shutdown()
	{
	}

	public void ShutdownImmediately()
	{
	}

	public void Upgrade(Buildable buildable)
	{
	}

	private void SetBlockingQuest(Quest quest)
	{
		if (quest == null && _blockingQuest != null)
		{
			LocalizationManager.ParamManagers.Remove(this);
		}
		else if (quest != null && _blockingQuest == null)
		{
			LocalizationManager.ParamManagers.Add(this);
		}
		_blockingQuest = quest;
	}

	string ILocalizationParamsManager.GetParameterValue(string Param)
	{
		if (_blockingQuest != null && Param.Equals("BLOCKING_QUEST_NAME"))
		{
			return _blockingQuest.Properties.QuestTitle;
		}
		return null;
	}

	private bool TryGetBlockingQuest(out Quest quest, RadioMessagesManager radioMessagesManager)
	{
		if (radioMessagesManager.TryGetActiveRadioMessageQuest(out quest))
		{
			return true;
		}
		if (WorldManager.TryReturnWorldTileSpawningBlocker(out var worldTileSpawningBlocker) && worldTileSpawningBlocker.QuestObjective != null)
		{
			quest = worldTileSpawningBlocker.QuestObjective.Quest;
		}
		else
		{
			quest = null;
		}
		return quest != null;
	}
}
