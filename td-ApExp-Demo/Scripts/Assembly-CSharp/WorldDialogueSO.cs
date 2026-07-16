using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "World Dialogue SO")]
public class WorldDialogueSO : ScriptableObject
{
	public int LastLevelIndex;

	public SerializedDictionary<int, LevelDialogueSO> LevelDialogues = new SerializedDictionary<int, LevelDialogueSO>();

	public Sprite genericPortrait;
}
