using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Settings/Session Settings")]
public class SessionSettings : ScriptableObject
{
	[Header("World")]
	[Tooltip("When set to false the generated seed by Unity will be overridden with our own. Else it will use the Unity generated seed.")]
	public bool UseRandomSeed = true;

	[Tooltip("World seed used in world generation.")]
	[ConditionalHide("UseRandomSeed", false, true)]
	public int WorldSeed = 1987;

	[Header("Story")]
	[Tooltip("Scenario to start the game with.")]
	public StartingScenarioProperties StartingScenario;
}
