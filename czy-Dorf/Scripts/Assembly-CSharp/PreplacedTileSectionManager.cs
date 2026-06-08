using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;

public class PreplacedTileSectionManager : SectionManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<SessionQuest, bool> _003C_003E9__6_0;

		public static Func<SessionQuest, bool> _003C_003E9__11_0;

		internal bool _003CSetupSections_003Eb__6_0(SessionQuest x)
		{
			return x.unlocksQuestTile;
		}

		internal bool _003CSetupPendingLockedChallenges_003Eb__11_0(SessionQuest x)
		{
			if (x.CurrentState == RewardState.Hidden && x.compositeParentQuest == null)
			{
				return x.GetLevel(0).reward.unlockType == UnlockType.Tile;
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public List<ChallengeId> loadedLockedChallenges;

		internal bool _003CSetupPendingLockedChallenges_003Eb__1(SessionQuest x)
		{
			return loadedLockedChallenges.Contains(x.id);
		}
	}

	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	public List<SessionQuest> pendingLockedChallenges = new List<SessionQuest>();

	private List<SessionQuest> allValidChallenges = new List<SessionQuest>();

	public Dictionary<Vector2Int, QuestTileId> predefinedPreplacedTiles = new Dictionary<Vector2Int, QuestTileId>();

	public SessionQuestManager SessionQuestManager => sessionQuestManager;

	public override void SetupSections(Transform container, bool randomizeSeed, bool setNewSeed = true)
	{
		allValidChallenges = Enumerable.ToList(Enumerable.Where(sessionQuestManager.sessionQuests, (SessionQuest x) => x.unlocksQuestTile));
		base.SetupSections(container, randomizeSeed, setNewSeed);
	}

	public SessionQuest GetChallenge()
	{
		if (pendingLockedChallenges.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, pendingLockedChallenges.Count);
			SessionQuest result = pendingLockedChallenges[index];
			pendingLockedChallenges.RemoveAt(index);
			return result;
		}
		return allValidChallenges[UnityEngine.Random.Range(0, allValidChallenges.Count)];
	}

	public void DefinePreplacedTile(Vector2Int sectionGridPos, QuestTileId preplacedTileId)
	{
		if (!predefinedPreplacedTiles.ContainsKey(sectionGridPos))
		{
			predefinedPreplacedTiles.Add(sectionGridPos, preplacedTileId);
		}
		else
		{
			Debug.LogError($"already has defined a preplaced tile for section {sectionGridPos}: " + $"{predefinedPreplacedTiles[sectionGridPos]} - trying to add {preplacedTileId}");
		}
	}

	public QuestTileId GetPredefinedPreplacedTile(Vector2Int sectionGridPos)
	{
		if (predefinedPreplacedTiles.ContainsKey(sectionGridPos))
		{
			return predefinedPreplacedTiles[sectionGridPos];
		}
		return QuestTileId.Undefined;
	}

	public void SetupPredefinedTiles(List<PreplacedTileData_002> loadedGamePreplacedTiles)
	{
		predefinedPreplacedTiles = new Dictionary<Vector2Int, QuestTileId>();
		if (loadedGamePreplacedTiles == null)
		{
			return;
		}
		foreach (PreplacedTileData_002 loadedGamePreplacedTile in loadedGamePreplacedTiles)
		{
			predefinedPreplacedTiles.Add(new Vector2Int(loadedGamePreplacedTile.sectionGridPosX, loadedGamePreplacedTile.sectionGridPosY), loadedGamePreplacedTile.preplacedTileId);
		}
	}

	public void SetupPendingLockedChallenges(List<ChallengeId> loadedLockedChallenges)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals3.loadedLockedChallenges = loadedLockedChallenges;
		if (CS_0024_003C_003E8__locals3.loadedLockedChallenges == null)
		{
			pendingLockedChallenges = Enumerable.ToList(Enumerable.Where(sessionQuestManager.sessionQuests, (SessionQuest x) => x.CurrentState == RewardState.Hidden && x.compositeParentQuest == null && x.GetLevel(0).reward.unlockType == UnlockType.Tile));
		}
		else
		{
			pendingLockedChallenges = Enumerable.ToList(Enumerable.Where(pendingLockedChallenges, (SessionQuest x) => CS_0024_003C_003E8__locals3.loadedLockedChallenges.Contains(x.id)));
		}
	}
}
