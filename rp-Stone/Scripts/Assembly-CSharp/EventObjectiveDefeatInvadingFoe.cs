using System.Collections.Generic;
using UnityEngine;

public class EventObjectiveDefeatInvadingFoe : EventObjectiveBase
{
	private string foeId;

	private string prefabPath;

	private int minLevel;

	private bool pointsByDifficulty;

	public EventObjectiveDefeatInvadingFoe(int goal, string foeId, string prefabPath, int minLevel, string foeName, bool pointsByDifficulty)
		: base("kill_invading_foe", goal)
	{
		this.foeId = foeId;
		this.prefabPath = prefabPath;
		this.minLevel = minLevel;
		this.pointsByDifficulty = pointsByDifficulty;
		description = string.Format(Te.xt("tid_q_basic_boss"), TranslateIfTID(foeName));
	}

	public override void Init()
	{
		Level.OnNextSection += HandleLevelSectionCreated;
		Character.OnCharacterDied += HandleCharacterDied;
		Utils.PreloadAsyncPrefab(prefabPath);
	}

	public override void End()
	{
		Level.OnNextSection -= HandleLevelSectionCreated;
		Character.OnCharacterDied -= HandleCharacterDied;
	}

	private void HandleLevelSectionCreated(Level level, int sectionIndex, List<Character> characters)
	{
		if (characters.Count == 0 || (level.QuestData != null && level.QuestData.safe))
		{
			return;
		}
		GameObject gameObject = Utils.InstantiatePrefab(prefabPath);
		if (!(gameObject != null))
		{
			return;
		}
		Character component = gameObject.GetComponent<Character>();
		if (!(component != null))
		{
			return;
		}
		Character character = null;
		int num = minLevel;
		for (int i = 0; i < characters.Count; i++)
		{
			Character character2 = characters[i];
			if (!(character2 == null))
			{
				if (character == null || character2.PositionX >= character.PositionX)
				{
					character = character2;
				}
				num = Mathf.Max(num, character2.level);
			}
		}
		component.PositionX = character.PositionX;
		component.PositionY = character.PositionY;
		component.PositionZ = character.PositionZ;
		component.SetLevel(num);
		level.AddCharacter(component);
	}

	private void HandleCharacterDied(Character c, Character.DeathReason reason, Damage dmg)
	{
		if ((reason == Character.DeathReason.DamageTaken || reason == Character.DeathReason.Unmake || reason == Character.DeathReason.Custom) && c.id.Contains(foeId))
		{
			if (pointsByDifficulty)
			{
				Data.Quest questData = GameStates.Singleton.level.QuestData;
				AddProgress(questData.level, questData.level);
			}
			else
			{
				AddProgress();
			}
		}
	}
}
