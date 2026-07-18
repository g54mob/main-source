using System;
using UnityEngine;

[Serializable]
public class GridObjectInstance
{
	public GameObject gridGameObject;

	public GridObjectInstance(GameObject gridGameObject)
	{
		this.gridGameObject = gridGameObject;
	}
}
