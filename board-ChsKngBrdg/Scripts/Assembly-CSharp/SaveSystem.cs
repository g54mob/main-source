using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
	public static PlayerSaveData currentPlayerSaveData = new PlayerSaveData(OverworldTrollManager.OverworldState.ACT_I, OverworldTrollManager.Ending.BadEnding, 0, 0, 0, 0f, firstGameinScene: false, new List<PageFogEntry>());

	public static void ResetPlayerSaveData()
	{
		currentPlayerSaveData = new PlayerSaveData(OverworldTrollManager.OverworldState.ACT_I, OverworldTrollManager.Ending.BadEnding, 0, 0, 0, 0f, firstGameinScene: false, new List<PageFogEntry>());
		SavePlayerSaveData(currentPlayerSaveData);
	}

	public static PlayerSaveData LoadPlayerSaveData()
	{
		string text = FileHandler.ReadString("save_data", doDecrypt: true);
		if (text == null)
		{
			return null;
		}
		return JsonUtility.FromJson<PlayerSaveData>(text);
	}

	public static void SavePlayerSaveData(PlayerSaveData playerSaveData)
	{
		string input = JsonUtility.ToJson(playerSaveData);
		FileHandler.WriteString("save_data", input, doEncrypt: true);
	}
}
