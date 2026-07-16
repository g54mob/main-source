using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "World Dialogue Iterations SO")]
public class WorldDialogueIterationsSO : ScriptableObject
{
	public SerializedDictionary<int, WorldDialogueSO> WorldDialogues = new SerializedDictionary<int, WorldDialogueSO>();
}
