using System.Collections;
using UnityEngine;

public class ConveyorBeltItem : MonoBehaviour
{
	private float waitTime = 0.5f;

	private void Start()
	{
		StartCoroutine(WaitForNextAction());
		RandomizeWaitTime();
	}

	private void RandomizeWaitTime()
	{
		waitTime = Random.Range(0.4f, 0.9f);
	}

	private void TryToMoveToNextBelt()
	{
		Vector2Int xYCoordinates = GridSystem.ins.getXYCoordinates(base.transform.position);
		ConveyorBelt beltScript = getBeltScript(xYCoordinates);
		if ((bool)beltScript)
		{
			Vector2Int coordinates = xYCoordinates;
			switch (beltScript.beltDirection)
			{
			case ConveyorBelt.BeltDirection.Right:
				coordinates.x++;
				break;
			case ConveyorBelt.BeltDirection.Down:
				coordinates.y--;
				break;
			case ConveyorBelt.BeltDirection.Left:
				coordinates.x--;
				break;
			case ConveyorBelt.BeltDirection.Up:
				coordinates.y++;
				break;
			}
			ConveyorBelt beltScript2 = getBeltScript(coordinates);
			if ((bool)beltScript2)
			{
				StartCoroutine(MoveToNextBelt(beltScript, beltScript2));
				return;
			}
		}
		StartCoroutine(WaitForNextAction());
	}

	private IEnumerator WaitForNextAction()
	{
		yield return new WaitForSeconds(waitTime);
		TryToMoveToNextBelt();
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

	private IEnumerator MoveToNextBelt(ConveyorBelt currentBelt, ConveyorBelt nextBelt)
	{
		Vector3 itemCenterPosition = nextBelt.getItemCenterPosition();
		currentBelt.RemoveItemFromBelt();
		nextBelt.AddItemToBelt();
		yield return new WaitForPositionReached(base.transform, itemCenterPosition, nextBelt.speed);
		TryToMoveToNextBelt();
	}
}
