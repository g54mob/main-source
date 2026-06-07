using System.Collections;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

[ExecutionOrder(-20)]
public class StartGameDataDevSceneLoader : MonoBehaviour
{
	[Tooltip("'Auto' is the same as 'Expanded' in the Dev scene.")]
	[SerializeField]
	private GameParams.StartingItemsType startingItems = GameParams.StartingItemsType.Auto;

	[Tooltip("Any string is valid in Dev scene but `Career` and `FreeRoam` are standard. No entry means 'Career'.")]
	[SerializeField]
	private string gameMode;

	[Tooltip("Any world name is valid for use in Dev scenes. No entry means 'World1'.")]
	[SerializeField]
	private string world;

	private StartGameData_DevScene devStartData;

	private void Awake()
	{
		devStartData = base.gameObject.AddComponent<StartGameData_DevScene>();
		int num = ((startingItems != GameParams.StartingItemsType.Basic) ? 2 : 0);
		string text = (string.IsNullOrWhiteSpace(gameMode) ? "Career" : gameMode);
		string text2 = (string.IsNullOrWhiteSpace(world) ? "World1" : world);
		Debug.Log("Creating session");
		SingletonBehaviour<UserManager>.Instance.CurrentUser.StartSession(text, text2);
		Debug.Log(string.Format("Setting params for {0}: Starting items entry: {1}, Game mode: {2}, World: {3}", "StartGameData_DevScene", num, text, text2));
		devStartData.SetSaveParams(num, text, text2);
		AStartGameData aStartGameData = SingletonBehaviour<SaveGameManager>.Instance.FindStartGameData();
		if (aStartGameData != devStartData)
		{
			Debug.LogError("Unexpected instances of AStartGameData found. This should not happen. Using Dev variant.", aStartGameData);
		}
	}

	private IEnumerator Start()
	{
		GameObject temp = new GameObject("[dummy player container]");
		yield return devStartData.DoLoad(temp.transform);
		Object.Destroy(temp);
	}
}
