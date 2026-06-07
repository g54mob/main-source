using System.Collections.Generic;
using Unity.Components.Logs;
using UnityEngine;

public class Tiler : MonoBehaviour
{
	public enum BlockMode
	{
		ZeroPoint = 0,
		AnyIntersection = 1
	}

	public GameObject Tile;

	public GameObject Space;

	public GameObject CoreSpace;

	public Vector3 Spacing = Vector3.zero;

	public BlockMode CoreBlock;

	public List<GameObject> CreatedObjects = new List<GameObject>();

	public void FillSpace()
	{
		if (Space == null)
		{
			Space = base.gameObject;
		}
		Vector3 size = GetBounds(Space).size;
		Vector3 size2 = GetBounds(Tile).size;
		Vector3 vector = UnityUtils.Vector3Division(size, size2);
		Bounds bounds = GetBounds(CoreSpace);
		Log.Debug("tile={0} space={1} intiles={2}", size2, size, vector);
		for (int i = 0; (float)i < vector.x; i++)
		{
			for (int j = 0; (float)j < vector.y; j++)
			{
				for (int k = 0; (float)k < vector.z; k++)
				{
					Vector3 b = new Vector3(i, j, k);
					b = UnityUtils.Vector3Mult(size2, b);
					b += UnityUtils.Vector3Mult(Spacing, b);
					b += size2 / 2f;
					b -= size / 2f;
					b += GetBounds(Space).center;
					if (CoreSpace != null)
					{
						if (CoreBlock == BlockMode.ZeroPoint)
						{
							if (bounds.Contains(b))
							{
								continue;
							}
						}
						else if (CoreBlock == BlockMode.AnyIntersection && new Bounds(b, size2).Intersects(bounds))
						{
							continue;
						}
					}
					GameObject gameObject = Object.Instantiate(Tile);
					gameObject.name = $"{i}_{j}_{k}";
					gameObject.transform.position = b;
					gameObject.transform.parent = Space.transform;
					CreatedObjects.Add(gameObject);
				}
			}
		}
	}

	private Bounds GetBounds(GameObject o)
	{
		BoxCollider component = o.GetComponent<BoxCollider>();
		if (component != null)
		{
			return component.bounds;
		}
		return o.GetComponent<Renderer>().bounds;
	}

	public void Clear()
	{
		foreach (GameObject createdObject in CreatedObjects)
		{
			Object.DestroyImmediate(createdObject);
		}
		CreatedObjects.Clear();
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		if (Space != null)
		{
			Gizmos.DrawWireCube(GetBounds(Space).center, GetBounds(Space).size);
		}
		if (CoreSpace != null)
		{
			Gizmos.DrawWireCube(GetBounds(CoreSpace).center, GetBounds(CoreSpace).size);
		}
		if (Tile != null)
		{
			Gizmos.DrawWireCube(GetBounds(Tile).center, GetBounds(Tile).size);
		}
	}
}
