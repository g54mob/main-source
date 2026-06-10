using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "fact_data", menuName = "Database/Evidence/Fact Preset")]
public class FactPreset : SoCustomComparison
{
	[Tooltip("Whenever this fact is displayed in an icon, use this sprite.")]
	[Header("Setup")]
	public Sprite iconSpriteLarge;

	[Tooltip("Spawn this subclass. If left empty it will use the base class.")]
	public string subClass;

	[Tooltip("Allow to -> from duplicates of this evidence")]
	public bool allowDuplicates;

	[Tooltip("Allow reverse duplicates of this evidence")]
	public bool allowReverseDuplicates;

	[Header("Links")]
	[ReorderableList]
	[Tooltip("Link specifically to these data keys. These keys can be override manually by passing them in the constructor.")]
	public List<Evidence.DataKey> fromDataKeys;

	[ReorderableList]
	[Tooltip("Link specifically to these data keys. These keys can be override manually by passing them in the constructor.")]
	public List<Evidence.DataKey> toDataKeys;

	[Header("Discovery")]
	[Tooltip("Discover this evidence when it is created.")]
	public bool discoverOnCreate;

	[Tooltip("When discovered, this is eligable to be tagged as 'new information'")]
	public bool countsAsNewInformationOnDiscovery;

	[ReorderableList]
	[Tooltip("On discovery, apply these data keys to the 'from' evidence.")]
	public List<Evidence.DataKey> applyFromKeysOnDiscovery;

	[Tooltip("On discovery, apply these data keys to the 'to' evidence.")]
	[ReorderableList]
	public List<Evidence.DataKey> applyToKeysOnDiscovery;

	[InfoBox("When either of the connecting evidence has this trigger applied, the fact will become 'discovered'", EInfoBoxType.Normal)]
	public List<Evidence.Discovery> discoveryTriggers;

	[Header("Misc.")]
	[Tooltip("Use this to rank facts within the facts list (lowest displayed first).")]
	[Range(0f, 10f)]
	public int factRank;
}
