using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Story/Starting Scenario")]
public class StartingScenarioProperties : ScriptableObject
{
	[Header("Agents")]
	[Tooltip("Amount of inhabitants to start the game with.")]
	public int Inhabitants = 3;

	[Tooltip("Spawn radius in which inhabitants will spawn.")]
	public float InhabitantSpawnRadius = 25f;

	[Space]
	[Tooltip("Townheart to start game with. If left empty, none will be spawned when set to null.")]
	public Buildable Townheart;

	[Tooltip("Position to place the townheart at.")]
	[ConditionalHide("StartingTownheart")]
	public Vector3 PositionTownheart = Vector3.zero;

	[Header("Items")]
	[Tooltip("List of resources the player starts with.")]
	public List<CountedItemProperty> StartingResources = new List<CountedItemProperty>();

	[Header("Story")]
	[Tooltip("The prefab of the message that is shown on start.")]
	public NewGamePanel StartMessage;
}
