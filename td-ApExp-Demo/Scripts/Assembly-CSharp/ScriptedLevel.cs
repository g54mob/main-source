using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Scripted Level", menuName = "Scripted Level")]
public class ScriptedLevel : ScriptableObject
{
	public LocalizedString nameKey;

	public LocalizedString tooltipKey;

	public int difficultyIndex;

	public LevelType levelType;

	public LootType lootType;

	public TrackTypes[] trackTypesOverride;

	public int trackCountOverride = -1;

	public virtual void OnLevelStarting()
	{
	}

	public virtual void OnLevelPlaying()
	{
	}

	public virtual void OnLevelSlowing()
	{
	}

	public virtual void GetTrack(int i)
	{
	}

	public virtual LevelData CreateLevelData()
	{
		return new LevelData
		{
			name = nameKey.GetLocalizedString(),
			index = -1,
			position = default(Vector2),
			connectivity = new List<int>(),
			levelType = levelType,
			lootType = lootType,
			difficulty = LevelManager.Instance.Config.LevelDifficulties[difficultyIndex],
			scriptedLevel = this,
			savedModifiers = new List<float>()
		};
	}
}
