using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaceholderCreation : MonoBehaviour
{
	private readonly List<PlaceholderBlockBody> placeholderBlocks = new List<PlaceholderBlockBody>();

	public void Populate()
	{
		placeholderBlocks.Clear();
		base.transform.GetComponentsInChildren(includeInactive: true, placeholderBlocks);
	}

	public bool IsColliding()
	{
		return placeholderBlocks.Any((PlaceholderBlockBody placeholderBlock) => placeholderBlock.IsColliding);
	}

	public bool IsBlockColliding()
	{
		return placeholderBlocks.Any((PlaceholderBlockBody placeholderBlock) => placeholderBlock.IsBlockColliding);
	}

	public bool IsLevelObjectColliding()
	{
		return placeholderBlocks.Any((PlaceholderBlockBody placeholderBlock) => placeholderBlock.IsLevelObjectColliding);
	}

	public bool IsDelimitationZoneColliding()
	{
		return placeholderBlocks.Any((PlaceholderBlockBody placeholderBlock) => placeholderBlock.IsDelimitationZoneColliding);
	}

	public void SetCheckForBlocks(bool shouldCheckForBlocks)
	{
		foreach (PlaceholderBlockBody placeholderBlock in placeholderBlocks)
		{
			placeholderBlock.ShouldCheckForBlocks = shouldCheckForBlocks;
		}
	}

	public void SetCheckForLevelObject(bool shouldCheckForBlocks)
	{
		foreach (PlaceholderBlockBody placeholderBlock in placeholderBlocks)
		{
			placeholderBlock.ShouldCheckForLevelObject = shouldCheckForBlocks;
		}
	}

	public void SetCheckForDelimitationZone(bool shouldCheckForDelimitationZone)
	{
		foreach (PlaceholderBlockBody placeholderBlock in placeholderBlocks)
		{
			placeholderBlock.ShouldCheckForDelimitationZone = shouldCheckForDelimitationZone;
		}
	}

	public void ResetStatus()
	{
		foreach (PlaceholderBlockBody placeholderBlock in placeholderBlocks)
		{
			placeholderBlock.BlocksInCollision.ResetStatus();
		}
	}

	public void RefreshForTwoPointBlock(Vector3 endPosition, Quaternion endRotation)
	{
		if (placeholderBlocks.Count >= 1)
		{
			placeholderBlocks[0].BlocksInCollision.RefreshForTwoPointBlock(endPosition, endRotation);
		}
	}
}
