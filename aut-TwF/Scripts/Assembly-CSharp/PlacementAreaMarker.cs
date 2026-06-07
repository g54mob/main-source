using UnityEngine;

public class PlacementAreaMarker : MonoBehaviour
{
	[SerializeField]
	private PlacementRequirementUI placementRequirementUIPrefab;

	[SerializeField]
	[ColorUsage(true, true)]
	private Color validAreaColor = Color.green;

	[SerializeField]
	[ColorUsage(true, true)]
	private Color invalidAreaColor = Color.red;

	private PlacementRequirementUI currentPlacementRequirementUI;

	private PlacementComponent currentPlacementComponent;

	private Material currentMaterial;

	public PlacementComponent CurrentPlacementComponent
	{
		get
		{
			return currentPlacementComponent;
		}
		set
		{
			if ((bool)currentPlacementComponent)
			{
				currentPlacementComponent.onChangePosition -= OnChangePosition;
			}
			currentPlacementComponent = value;
			if ((bool)currentPlacementComponent)
			{
				base.transform.localScale = new Vector3(currentPlacementComponent.Width, 1f, currentPlacementComponent.Length);
				OnChangePosition(currentPlacementComponent);
				currentPlacementComponent.onChangePosition += OnChangePosition;
			}
		}
	}

	private void Awake()
	{
		currentMaterial = GetComponentInChildren<Renderer>().material;
		currentPlacementRequirementUI = Object.Instantiate(placementRequirementUIPrefab);
		currentPlacementRequirementUI.SetFollowTarget(base.gameObject);
	}

	private void OnDestroy()
	{
		Object.Destroy(currentPlacementRequirementUI?.gameObject);
		if ((bool)CurrentPlacementComponent)
		{
			currentPlacementComponent.onChangePosition -= OnChangePosition;
		}
	}

	private void Update()
	{
		if (!currentPlacementComponent)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			UpdateMarkerColor();
		}
	}

	private void UpdateMarkerColor()
	{
		if (LTFunctionLibrary.GetPlayerData().PlayerBuildings.Contains(currentPlacementComponent.MainObject) || LTFunctionLibrary.GetPlayerData().PlayerTowers.Contains(currentPlacementComponent.MainObject))
		{
			bool flag = currentPlacementComponent.CanBuildOnCurrentPosition();
			currentMaterial.SetColor("_Color", flag ? validAreaColor : invalidAreaColor);
			currentPlacementRequirementUI.ShowCostGO(show: false);
			currentPlacementRequirementUI.ShowTowerLimitGO(show: false);
		}
		else
		{
			bool flag2 = currentPlacementComponent.CanBuildOnCurrentPosition();
			bool flag3 = currentPlacementComponent.MainObject.ObjectData.Type != EGameplayObjectType.Tower || !LTFunctionLibrary.GetPlayerData().HasReachedTowerLimit();
			bool flag4 = LTFunctionLibrary.GetLTGameManager().CanAfford(currentPlacementComponent.MainObject.ObjectData.BuyCost);
			currentMaterial.SetColor("_Color", (flag2 && flag3 && flag4) ? validAreaColor : invalidAreaColor);
			currentPlacementRequirementUI.ShowCostGO(!flag4);
			currentPlacementRequirementUI.ShowTowerLimitGO(!flag3);
		}
	}

	private void OnChangePosition(PlacementComponent placementComponent)
	{
		base.transform.position = placementComponent.GetCenter();
		base.transform.rotation = placementComponent.transform.rotation;
	}
}
