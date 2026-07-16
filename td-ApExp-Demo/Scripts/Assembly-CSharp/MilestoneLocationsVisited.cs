using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Locations Visited/Create New")]
public class MilestoneLocationsVisited : Milestone
{
	public enum Difficulty
	{
		None = 0,
		Easy = 1,
		Medium = 2,
		Hard = 3
	}

	private bool correctLevel;

	[field: SerializeField]
	[field: Tooltip("If you leave this field empty (Set to None), this milestone will count every level type.")]
	public LootType LootType { get; private set; }

	[field: SerializeField]
	public Difficulty LevelDifficulty { get; private set; }

	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.LocationsVisited;
		LevelManager.Instance.NextLevelSelected += CheckNextLevel;
		LevelManager.Instance.DestinationReached += AddProgress;
	}

	public void CheckNextLevel(Level level)
	{
		if (LootType == LootType.None)
		{
			if (LevelDifficulty == Difficulty.None)
			{
				correctLevel = true;
			}
			else if (level.Difficulty.Name == LevelDifficulty.ToString())
			{
				correctLevel = true;
			}
		}
		else if (level.LootType == LootType)
		{
			if (LevelDifficulty == Difficulty.None)
			{
				correctLevel = true;
			}
			else if (level.Difficulty.Name == LevelDifficulty.ToString())
			{
				correctLevel = true;
			}
		}
	}

	public override void AddProgress()
	{
		if (correctLevel)
		{
			base.AddProgress();
		}
		correctLevel = false;
	}

	public override void Complete()
	{
		base.Complete();
		LevelManager.Instance.NextLevelSelected -= CheckNextLevel;
		LevelManager.Instance.DestinationReached -= AddProgress;
	}
}
