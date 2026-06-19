using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour
{
	protected Building _building;

	public virtual void SetBuilding(Building building)
	{
	}

	public virtual void Initiate()
	{
	}

	public virtual void OnMove()
	{
	}

	public virtual List<BuildingSelectorData> GetSelectorTransforms()
	{
		return null;
	}

	public virtual void ClearForDestroy()
	{
	}
}
