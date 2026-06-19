using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Upgrade_", menuName = "Project/Upgrade Def")]
public class UpgradeDef : ScriptableObject
{
	[Header("Basics")]
	public string ID;

	public Sprite Icon;

	[Header("Levels")]
	public List<UpgradeLevel> UpgradeLevels;

	[Header("Localised Info")]
	public LocalizedString Title;

	public LocalizedString Description;

	[HideInInspector]
	public Vector2Int Position;

	[HideInInspector]
	public UpgradeDef ParentUpgrade;

	public Checkpoint RequiredCheckpoint;

	public bool IsKeyUpgrade;
}
