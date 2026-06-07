using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WorldTileSpawningBlocker
{
	[SerializeField]
	private bool _enabled;

	[SerializeField]
	[ConditionalHide("_enabled", true)]
	private float _dialogueTriggerThrehsold = 2000f;

	private List<ISpawner> _blockingSpawners;

	private WorldMapTownheart _townheart;

	private bool _triggered;

	public bool Enabled => _enabled;

	public QuestObjectiveBase QuestObjective { get; private set; }

	public WorldTileSpawningBlocker()
	{
	}

	public WorldTileSpawningBlocker(WorldTileSpawningBlocker other)
	{
		_enabled = other._enabled;
		_dialogueTriggerThrehsold = other._dialogueTriggerThrehsold;
	}

	public void LateUpdate()
	{
		if (QuestObjective == null || QuestObjective.IsCompleted())
		{
			Disable();
			return;
		}
		bool flag = false;
		foreach (ISpawner blockingSpawner in _blockingSpawners)
		{
			if (_dialogueTriggerThrehsold < _townheart.Position.x - blockingSpawner.WorldPosition.x)
			{
				flag = true;
			}
		}
		if (flag != _triggered)
		{
			_triggered = flag;
			if (_triggered)
			{
				QuestObjective.TriggerDialogue(DialogueTriggerType.OnSpawnerOutOfRange);
			}
		}
	}

	public void SetQuestObjective(QuestObjectiveBase questObjective)
	{
		QuestObjective = questObjective;
	}

	public void AddBlockingSpawner(ISpawner spawner)
	{
		if (_enabled)
		{
			Enable();
			_blockingSpawners.AddUnique(spawner);
		}
	}

	public void Disable()
	{
		_blockingSpawners.Dispose();
		_blockingSpawners = null;
		WorldManager.SpawningBlockers.Remove(this);
	}

	private void Enable()
	{
		if (_blockingSpawners == null)
		{
			_blockingSpawners = ListPool<ISpawner>.Get();
			_townheart = GameManager.WorldMapManager.WorldMap.Townheart;
			WorldManager.SpawningBlockers.Add(this);
		}
	}

	public bool BlocksRadioMessages()
	{
		return !_blockingSpawners.IsNullOrEmpty();
	}

	public bool BlocksSpawning(WorldTile lastWorldTile)
	{
		if (_blockingSpawners.IsNullOrEmpty())
		{
			return false;
		}
		foreach (ISpawner blockingSpawner in _blockingSpawners)
		{
			if (blockingSpawner.WorldTile.Index < lastWorldTile.Index)
			{
				return true;
			}
		}
		return false;
	}

	public bool BlocksPruning(WorldTile worldTileToPrune)
	{
		if (_blockingSpawners.IsNullOrEmpty())
		{
			return false;
		}
		foreach (ISpawner blockingSpawner in _blockingSpawners)
		{
			if (blockingSpawner.WorldTile == worldTileToPrune)
			{
				Debug.LogException(new Exception($"Tile pruning blocked by '{QuestObjective}'"));
				return true;
			}
		}
		return false;
	}
}
