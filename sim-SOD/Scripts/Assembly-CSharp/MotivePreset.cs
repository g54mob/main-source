using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "motive_data", menuName = "Database/Motive Preset")]
public class MotivePreset : SoCustomComparison
{
	[Serializable]
	public class ModifierRule
	{
		public CharacterTrait.RuleType rule;

		public List<CharacterTrait> traitList;

		[Tooltip("If this isn't true then it won't be picked for application at all.")]
		public bool mustPassForApplication;

		public int score;
	}

	[Header("Purpetrator")]
	public bool allowHomelessPurps;

	public bool allowJoblessPurps;

	public bool purpMustLiveAtDifferentAddressToPoster;

	public bool allowEnforcers;

	public bool disallowEchelonHome;

	[Tooltip("Purps must follow these trait rules")]
	[ReorderableList]
	public List<ModifierRule> purpTraitModifiers;

	[Space(7f)]
	[Tooltip("Purp must have one of these jobs...")]
	public bool usePurpJobs;

	[ReorderableList]
	public List<OccupationPreset> purpJobs;

	[Header("Posters")]
	public bool allowHomelessPosters;

	public bool allowJoblessPosters;

	public bool usePosterConnections;

	[Tooltip("Posters must be one of these connections (poster connection to purp)...")]
	public List<Acquaintance.ConnectionType> acceptableConnections;

	public bool usePosterTraits;

	[EnableIf("usePosterTraits")]
	public List<ModifierRule> posterTraitModifiers;

	[Header("Exempt")]
	[Tooltip("The chosen purp is exempt from further side jobs.")]
	public bool purpIsExemptFromPostingOtherJobs;

	public bool purpIsExemptFromPurpingOtherJobs;

	[Tooltip("The chosen poster is exempt from further side jobs.")]
	public bool posterIsExemptFromPostingOtherJobs;

	public bool posterIsExemptFromPurpingOtherJobs;
}
