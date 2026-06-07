using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "TutorialQuest_build", menuName = "Tower Factory/Tutorial/Build Quest")]
public class TutorialQuestData_build : TutorialQuestData
{
	[Serializable]
	private class BuildQuestElement
	{
		public GameplayObjectData buildingData;

		public bool ignorePosition = true;

		public Vector3 position;

		[HideInInspector]
		public bool isBuilt;
	}

	[SerializeField]
	private BuildQuestElement[] questBuildings;

	[SerializeField]
	[Tooltip("Si es true, se contarán para el objetivo los edificios que ya estaban construídos antes de empezar la quest")]
	private bool acceptAlreadyBuiltBuildings = true;

	[SerializeField]
	private GameObject positionMarkerPrefab;

	private List<GameObject> positionMarkers;

	private bool notifyUpdate;

	public override string GetObjectiveText()
	{
		string text = "";
		for (int i = 0; i < questBuildings.Length; i++)
		{
			if (i > 0)
			{
				text += "\n";
			}
			if (questBuildings[i].isBuilt)
			{
				text += "<s>";
			}
			text = text + new LocalizedString("Tutorial", "Tutorial_text_build").GetLocalizedString() + " " + questBuildings[i].buildingData.DisplayName;
			if (questBuildings[i].isBuilt)
			{
				text += "</s>";
			}
		}
		return text;
	}

	public override void StartQuest()
	{
		base.StartQuest();
		notifyUpdate = false;
		positionMarkers = new List<GameObject>();
		LTFunctionLibrary.GetPlayerData().onPlayerBuildingAdded += OnBuildingAdded;
		LTFunctionLibrary.GetPlayerData().onPlayerTowerAdded += OnBuildingAdded;
		for (int i = 0; i < questBuildings.Length; i++)
		{
			questBuildings[i].isBuilt = false;
			if (!questBuildings[i].ignorePosition)
			{
				positionMarkers.Add(UnityEngine.Object.Instantiate(positionMarkerPrefab, questBuildings[i].position, Quaternion.identity));
			}
		}
		if (!acceptAlreadyBuiltBuildings)
		{
			return;
		}
		List<GameplayObject> playerBuildingsAndTowers = LTFunctionLibrary.GetPlayerData().PlayerBuildingsAndTowers;
		GameplayObject[] scenePlayerBuildings = LTFunctionLibrary.GetLTGameManager().ScenePlayerBuildings;
		foreach (GameplayObject item in scenePlayerBuildings)
		{
			playerBuildingsAndTowers.Remove(item);
		}
		foreach (GameplayObject item2 in playerBuildingsAndTowers)
		{
			OnBuildingAdded(item2);
		}
	}

	public override void EndQuest()
	{
		base.EndQuest();
		LTFunctionLibrary.GetPlayerData().onPlayerBuildingAdded -= OnBuildingAdded;
		LTFunctionLibrary.GetPlayerData().onPlayerTowerAdded -= OnBuildingAdded;
		for (int num = positionMarkers.Count - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(positionMarkers[num]);
		}
		positionMarkers.Clear();
	}

	public override bool UpdateQuest()
	{
		if (notifyUpdate)
		{
			notifyUpdate = false;
			return true;
		}
		return false;
	}

	public override bool IsComplete()
	{
		for (int i = 0; i < questBuildings.Length; i++)
		{
			if (!questBuildings[i].isBuilt)
			{
				return false;
			}
		}
		return true;
	}

	protected void OnBuildingAdded(GameplayObject addedBuilding)
	{
		for (int i = 0; i < questBuildings.Length; i++)
		{
			if (!questBuildings[i].isBuilt && questBuildings[i].buildingData == addedBuilding.ObjectData && (questBuildings[i].ignorePosition || questBuildings[i].position == addedBuilding.transform.position))
			{
				questBuildings[i].isBuilt = true;
				notifyUpdate = true;
				break;
			}
		}
	}
}
