using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sidejobhandin_data", menuName = "Database/Side Job Hand-In Preset")]
public class SideMissionHandInPreset : SoCustomComparison
{
	[Header("Rewards")]
	public int rewardModifier;

	[Header("Location")]
	public bool postersDoor;

	public bool cityHall;

	[Header("Elements")]
	public List<SideMissionIntroPreset.SideMissionObjectiveBlock> blocks;
}
