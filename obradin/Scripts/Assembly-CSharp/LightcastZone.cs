using System.Collections.Generic;
using UnityEngine;

public class LightcastZone : MonoBehaviour
{
	public List<Bounds> worldBoxes = new List<Bounds>();

	public bool Contains(Vector3 lightPos)
	{
		foreach (Bounds worldBox in worldBoxes)
		{
			if (worldBox.Contains(lightPos))
			{
				return true;
			}
		}
		return false;
	}

	public bool Intersects(Bounds worldBounds)
	{
		foreach (Bounds worldBox in worldBoxes)
		{
			if (worldBox.Intersects(worldBounds))
			{
				return true;
			}
		}
		return false;
	}
}
