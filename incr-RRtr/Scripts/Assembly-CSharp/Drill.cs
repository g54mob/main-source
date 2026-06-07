using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
	public enum Direction
	{
		Right = 0,
		Down = 1,
		Left = 2,
		Up = 3
	}

	public Direction direction;

	public GameObject oreItemTest;

	private Vector3 centerOffset = new Vector3(0.5625f, 0.5625f, 0f);

	private void Start()
	{
		InvokeRepeating("MineOre", 5f, 5f);
	}

	private void Update()
	{
	}

	private void MineOre()
	{
		Vector2Int xYCoordinates = GridSystem.ins.getXYCoordinates(base.transform.position + centerOffset);
		ConveyorBelt conveyorBelt = nearbyConveyorBelt(xYCoordinates);
		if (conveyorBelt != null)
		{
			Vector3 normalized = (conveyorBelt.transform.position - base.transform.position).normalized;
			Vector3 position = conveyorBelt.getItemCenterPosition() - normalized * 0.375f;
			Object.Instantiate(oreItemTest, position, Quaternion.identity);
			conveyorBelt.AddItemToBelt();
		}
	}

	private ConveyorBelt nearbyConveyorBelt(Vector2Int currentXY)
	{
		List<ConveyorBelt> list = new List<ConveyorBelt>();
		ConveyorBelt beltScript = getBeltScript(new Vector2Int(currentXY.x + 1, currentXY.y));
		if (beltScript != null)
		{
			list.Add(beltScript);
		}
		ConveyorBelt beltScript2 = getBeltScript(new Vector2Int(currentXY.x, currentXY.y - 1));
		if (beltScript2 != null)
		{
			list.Add(beltScript2);
		}
		ConveyorBelt beltScript3 = getBeltScript(new Vector2Int(currentXY.x - 1, currentXY.y));
		if (beltScript3 != null)
		{
			list.Add(beltScript3);
		}
		ConveyorBelt beltScript4 = getBeltScript(new Vector2Int(currentXY.x, currentXY.y + 1));
		if (beltScript4 != null)
		{
			list.Add(beltScript4);
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[0];
	}

	private ConveyorBelt getBeltScript(Vector2Int coordinates)
	{
		Building buildingScriptAt = GridSystem.ins.getBuildingScriptAt(coordinates);
		if (buildingScriptAt != null && buildingScriptAt.TryGetComponent<ConveyorBelt>(out var component))
		{
			return component;
		}
		return null;
	}
}
