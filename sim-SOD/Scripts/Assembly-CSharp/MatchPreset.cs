using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "match_data", menuName = "Database/Match Type")]
public class MatchPreset : SoCustomComparison
{
	public enum MatchCondition
	{
		bloodGroup = 0,
		fingerprint = 1,
		time = 2,
		visualDescriptors = 3,
		retailPresetMatch = 4,
		murderWeapon = 5
	}

	[Header("Matching Conditions")]
	[Tooltip("True if this match preset can only be matched with")]
	public bool canOnlyBeMatchedWith;

	[Tooltip("These conditions must return true for it to register as a match. No conditions will result in a match between evidence with this match preset.")]
	public List<MatchCondition> matchConditions;

	[Tooltip("Only match with a match parent, and not with non-parents")]
	public bool onlyMatchWithMatchParents;

	[Tooltip("Can this match with evidence that is technically itself?")]
	public bool canMatchWithItself;

	[Tooltip("Only match with evidence with this other match condition")]
	public MatchPreset onlyMatchWithThis;

	[Tooltip("Link from data key")]
	public List<Evidence.DataKey> linkFromKeys;

	[Tooltip("Link to data key")]
	public List<Evidence.DataKey> linkToKeys;
}
