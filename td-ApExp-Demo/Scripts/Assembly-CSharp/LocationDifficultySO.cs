using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyConditionSO", menuName = "DifficultyConditionSO/LocationDifficultySO/Create New")]
public class LocationDifficultySO : ScriptableObject
{
	[SerializeField]
	[Tooltip("Modifier is a percent increase so 1 means 100% more chance for selected location difficulty to appear on the map.")]
	public SerializedDictionary<string, float> Difficulty1Modifiers;

	[SerializeField]
	[Tooltip("Modifier is a percent increase so 1 means 100% more chance for selected location difficulty to appear on the map.")]
	public SerializedDictionary<string, float> Difficulty2Modifiers;

	[SerializeField]
	[Tooltip("Modifier is a percent increase so 1 means 100% more chance for selected location difficulty to appear on the map.")]
	public SerializedDictionary<string, float> Difficulty3Modifiers;
}
