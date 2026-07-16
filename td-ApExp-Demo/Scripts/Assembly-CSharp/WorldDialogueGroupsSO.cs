using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "World Dialogue Groups SO")]
public class WorldDialogueGroupsSO : ScriptableObject
{
	public SerializedDictionary<int, WorldDialogueIterationsSO> WorldDialogueIterations = new SerializedDictionary<int, WorldDialogueIterationsSO>();
}
