using System.Collections.Generic;
using DV.TerrainSystem;
using DV.Utils;
using UnityEngine;

public class TunnelCollisionIgnore : MonoBehaviour
{
	private class TunnelCollisionCache : SingletonBehaviour<TunnelCollisionCache>
	{
		public Dictionary<Vector2Int, HashSet<Collider>> ignoredColliders = new Dictionary<Vector2Int, HashSet<Collider>>();

		public new static string AllowAutoCreate()
		{
			return "[TunnelCollisionCache]";
		}
	}

	private const string PLAYER_TAG = "Player";

	private TerrainHole hole;

	private TerrainCollider terrainCollider;

	private TeleportArcPassThrough arcPassThrough;

	private Vector2Int gridCoord = new Vector2Int(int.MinValue, int.MinValue);

	private bool isMaster;

	private LayerMask ignoredLayers;

	private void Start()
	{
		ignoredLayers = LayerMask.GetMask("Interactable");
		hole = GetComponentInChildren<TerrainHole>();
		arcPassThrough = GetComponentInChildren<TeleportArcPassThrough>();
		if ((bool)SingletonBehaviour<TerrainGrid>.Instance)
		{
			gridCoord = SingletonBehaviour<TerrainGrid>.Instance.ToGridCoords(base.transform.position);
			if (!SingletonBehaviour<TunnelCollisionCache>.Instance.ignoredColliders.TryGetValue(gridCoord, out var _))
			{
				isMaster = true;
				SingletonBehaviour<TunnelCollisionCache>.Instance.ignoredColliders[gridCoord] = new HashSet<Collider>();
			}
		}
		else
		{
			Debug.LogError("TunnelCollisionIgnore couldn't find TerrainGrid instance, entering tunnels won't work correctly");
		}
		base.gameObject.AddComponent<TeleportArcPassThrough>();
		if ((bool)hole.Terrain)
		{
			TransferTo(hole.Terrain);
		}
		hole.TerrainAboutToBeChanged += TransferTo;
	}

	private void TransferTo(Terrain newTerrain)
	{
		if (gridCoord.x == int.MinValue)
		{
			return;
		}
		TerrainCollider terrainCollider = (newTerrain ? newTerrain.GetComponent<TerrainCollider>() : null);
		if (isMaster && ((bool)this.terrainCollider || (bool)terrainCollider))
		{
			HashSet<Collider> hashSet = SingletonBehaviour<TunnelCollisionCache>.Instance.ignoredColliders[gridCoord];
			int num = hashSet.RemoveWhere((Collider c) => c == null);
			if (num > 0)
			{
				Debug.LogWarning(string.Format("{0} encountered {1} null colliders during {2}.", "TunnelCollisionIgnore", num, "TransferTo"));
			}
			foreach (Collider item in hashSet)
			{
				if ((bool)this.terrainCollider)
				{
					Physics.IgnoreCollision(this.terrainCollider, item, ignore: false);
				}
				if ((bool)terrainCollider)
				{
					Physics.IgnoreCollision(terrainCollider, item, ignore: true);
				}
			}
		}
		this.terrainCollider = terrainCollider;
		arcPassThrough.colliders.Clear();
		if ((bool)this.terrainCollider)
		{
			arcPassThrough.colliders.Add(this.terrainCollider);
		}
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col == null)
		{
			Debug.LogWarning("TunnelCollisionIgnore.OnTriggerEnter on '" + base.gameObject.GetPath() + "' got called with null collider", this);
		}
		else if (((int)ignoredLayers & (1 << col.gameObject.layer)) == 0)
		{
			ReliableOnTriggerExit.NotifyTriggerEnter(col, base.gameObject, OnTriggerExit);
			Ignore(col);
		}
	}

	private void OnTriggerExit(Collider col)
	{
		if (col == null)
		{
			Debug.LogWarning("TunnelCollisionIgnore.OnTriggerExit on '" + base.gameObject.GetPath() + "' got called with null collider", this);
		}
		else if (((int)ignoredLayers & (1 << col.gameObject.layer)) == 0)
		{
			ReliableOnTriggerExit.NotifyTriggerExit(col, base.gameObject);
			Unignore(col);
		}
	}

	private void Ignore(Collider col)
	{
		if (gridCoord.x == int.MinValue)
		{
			return;
		}
		if (!SingletonBehaviour<TunnelCollisionCache>.Instance.ignoredColliders.TryGetValue(gridCoord, out var value))
		{
			HashSet<Collider> hashSet = (SingletonBehaviour<TunnelCollisionCache>.Instance.ignoredColliders[gridCoord] = new HashSet<Collider>());
			value = hashSet;
		}
		if (value.Contains(col))
		{
			return;
		}
		if ((bool)terrainCollider)
		{
			Physics.IgnoreCollision(terrainCollider, col, ignore: true);
		}
		value.Add(col);
		if (!col.gameObject.CompareTag("Player"))
		{
			return;
		}
		CharacterController component = col.GetComponent<CharacterController>();
		if (component != null)
		{
			if ((bool)terrainCollider)
			{
				Physics.IgnoreCollision(terrainCollider, component, ignore: true);
			}
			value.Add(component);
		}
	}

	private void Unignore(Collider col)
	{
		if (gridCoord.x == int.MinValue)
		{
			return;
		}
		if (SingletonBehaviour<TunnelCollisionCache>.Instance.ignoredColliders.TryGetValue(gridCoord, out var value))
		{
			if (value.Contains(col))
			{
				value.Remove(col);
				if ((bool)terrainCollider)
				{
					Physics.IgnoreCollision(terrainCollider, col, ignore: false);
				}
				if (!col.gameObject.CompareTag("Player"))
				{
					return;
				}
				CharacterController component = col.GetComponent<CharacterController>();
				if (component != null)
				{
					if ((bool)terrainCollider)
					{
						Physics.IgnoreCollision(terrainCollider, component, ignore: false);
					}
					value.Remove(component);
				}
			}
			else
			{
				Debug.LogError("Collider '" + col.gameObject.GetPath() + "' wasn't in ignoredColliders hashset", col);
			}
		}
		else
		{
			Debug.LogError("Colliders '" + col.name + "' wasn't in OUTER dict", col);
		}
	}
}
