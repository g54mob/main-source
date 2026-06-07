using UnityEngine;

public class Storehouse : GameplayObject, ISelectable
{
	[Header("Conveyor Belts")]
	[SerializeField]
	private bool spawnConveyorBeltsOnStart = true;

	[SerializeField]
	private Transform[] conveyorBeltsTransforms;

	[SerializeField]
	private GameObject conveyorBeltPrefab_T1;

	[SerializeField]
	private GameObject conveyorBeltPrefab_T2;

	[SerializeField]
	private GameObject conveyorBeltPrefab_T3;

	private GameObject[] currentConveyorBelts;

	private PlacementComponent placementComponent;

	private void Awake()
	{
		placementComponent = GetComponent<PlacementComponent>();
	}

	private void Start()
	{
		int conveyorBeltsTier = (int)LTFunctionLibrary.GetLTGameManager().PlayerTower.StatsComponent.GetStat(EStats.MaxUnlockedTier);
		if (spawnConveyorBeltsOnStart)
		{
			SetConveyorBeltsTier(conveyorBeltsTier);
		}
	}

	private void OnDestroy()
	{
		DeleteCurrentConveyorBelts();
	}

	public void SetConveyorBeltsTier(int tier)
	{
		DeleteCurrentConveyorBelts();
		currentConveyorBelts = new GameObject[conveyorBeltsTransforms.Length];
		for (int i = 0; i < currentConveyorBelts.Length; i++)
		{
			currentConveyorBelts[i] = SpawnConveyorBelt(tier, conveyorBeltsTransforms[i]);
			placementComponent.ChildObjects[i].gameplayObject = currentConveyorBelts[i].GetComponent<GameplayObject>();
			ConveyorBelt_storage component = currentConveyorBelts[i].GetComponent<ConveyorBelt_storage>();
			LTFunctionLibrary.GetPlayerData().AddPlayerBuilding(component);
			component.HasToIgnoreSave = true;
		}
	}

	private GameObject SpawnConveyorBelt(int tier, Transform parent)
	{
		GameObject gameObject = tier switch
		{
			0 => Object.Instantiate(conveyorBeltPrefab_T1, parent), 
			1 => Object.Instantiate(conveyorBeltPrefab_T2, parent), 
			2 => Object.Instantiate(conveyorBeltPrefab_T3, parent), 
			_ => Object.Instantiate(conveyorBeltPrefab_T1, parent), 
		};
		gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
		return gameObject;
	}

	private void DeleteCurrentConveyorBelts()
	{
		if (currentConveyorBelts == null)
		{
			return;
		}
		for (int num = currentConveyorBelts.Length - 1; num >= 0; num--)
		{
			ConveyorBelt component = currentConveyorBelts[num].GetComponent<ConveyorBelt_storage>();
			if (placementComponent.IsPlaced)
			{
				component.ForceCallUnplace();
			}
			LTFunctionLibrary.GetPlayerData().RemovePlayerBuilding(component);
			Object.Destroy(currentConveyorBelts[num]);
		}
	}

	public void Select()
	{
	}

	public void Deselect()
	{
	}
}
