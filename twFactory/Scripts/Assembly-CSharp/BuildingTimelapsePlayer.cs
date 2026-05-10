using System.Collections;
using UnityEngine;

public class BuildingTimelapsePlayer : MonoBehaviour
{
	[SerializeField]
	private BuildingRecorderData buildingData;

	[SerializeField]
	[Tooltip("Buildings placed per second")]
	private float timelapseSpeed = 1f;

	private Coroutine timelapseCoroutine;

	private void PlayTimelapse()
	{
		this.StartCoroutineCheckingVar(TimelapseCoroutine(instantBuild: false), ref timelapseCoroutine);
	}

	private void InstantBuild()
	{
		this.StartCoroutineCheckingVar(TimelapseCoroutine(instantBuild: true), ref timelapseCoroutine);
	}

	private IEnumerator TimelapseCoroutine(bool instantBuild)
	{
		WaitForSeconds wfs = new WaitForSeconds(1f / timelapseSpeed);
		foreach (BuildingRecorderObjectData building in buildingData.Buildings)
		{
			if (building.action == BuildingRecorderObjectData.EAction.Add)
			{
				PlacementComponent component = Object.Instantiate(building.objectData.Prefab, LTFunctionLibrary.GetGrid().SnapPositionToGrid(building.objectPosition), building.objectRotation).GetComponent<PlacementComponent>();
				if (component.CanBuildOnCurrentPosition(checkPositionVisible: false))
				{
					LTFunctionLibrary.GetPlayerData().AddPlayerBuilding(component.MainObject);
					component.Place(checkCanBuildOnCurrentPosition: false);
					if (!instantBuild)
					{
						yield return wfs;
					}
				}
				else
				{
					Object.Destroy(component.gameObject);
				}
				continue;
			}
			GameplayObject gameplayObject = null;
			foreach (GameplayObject playerBuilding in LTFunctionLibrary.GetPlayerData().PlayerBuildings)
			{
				if (playerBuilding.ObjectData == building.objectData && playerBuilding.transform.position == building.objectPosition)
				{
					gameplayObject = playerBuilding;
					break;
				}
			}
			if (gameplayObject != null)
			{
				LTFunctionLibrary.GetPlayerData().RemovePlayerBuilding(gameplayObject);
				gameplayObject.GetComponent<PlacementComponent>().Unplace();
				Object.Destroy(gameplayObject.gameObject);
			}
		}
		timelapseCoroutine = null;
	}
}
