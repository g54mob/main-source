using System.Collections.Generic;
using DV.ThingTypes;
using DV.Utils;
using DV.WorldTools;
using UnityEngine;

namespace DV.Hazmat
{
	public class Igniter : MonoBehaviour
	{
		[Header("Ignition basics")]
		public float ignitionStrength = 1f;

		public float objectsRadius = 0.03f;

		public float terrainClearance = 1f;

		public GameObject ignoredObject;

		[Header("Active ignition")]
		public float ignitionInterval = 0.1f;

		[Range(0f, 0.99f)]
		public float intervalJitter = 0.1f;

		private static Collider[] overlapCache = new Collider[16];

		private static int hazmatLayer = -1;

		private static int ignitionMask = -1;

		private float timeout;

		private IIgnitable ignoredIgnitable;

		private static List<HazmatGridTile> hazmatTileCache = new List<HazmatGridTile>();

		private void Awake()
		{
			timeout = ignitionInterval + Random.Range((0f - ignitionInterval) * intervalJitter, ignitionInterval * intervalJitter);
			if ((bool)ignoredObject)
			{
				ignoredIgnitable = ignoredObject.GetComponent<IIgnitable>();
				if (ignoredIgnitable == null)
				{
					Debug.LogError("Ignored object " + ignoredObject.name + " is assigned, but it has no IIgnitable component in it, this is probably unintended.", ignoredObject);
				}
			}
		}

		public void SetIgnoredIgnitable(IIgnitable ignitable)
		{
			ignoredIgnitable = ignitable;
		}

		private void Update()
		{
			if (timeout >= 0f)
			{
				timeout -= Time.deltaTime;
				if (timeout <= 0f)
				{
					IgniteNow();
					intervalJitter = Mathf.Clamp(intervalJitter, 0f, 0.99f);
					timeout = ignitionInterval + Random.Range((0f - ignitionInterval) * intervalJitter, ignitionInterval * intervalJitter);
				}
			}
		}

		public void IgniteNow()
		{
			Ignite(base.transform.position, ignitionStrength, objectsRadius, ignoredIgnitable, terrainClearance);
		}

		public bool IgniteSpecificObject(IIgnitable ignitable)
		{
			return ignitable?.Ignite(ignitionStrength) ?? false;
		}

		public static bool Ignite(Vector3 position, float ignitionStrength = 1f, float objectsRadius = 0.03f, IIgnitable ignoredIgnitable = null, float terrainClearance = 1f, float explosionChance = 0f)
		{
			bool result = false;
			if (objectsRadius > 0f)
			{
				if (hazmatLayer < 0)
				{
					hazmatLayer = LayerMask.NameToLayer("Hazmat");
				}
				if (ignitionMask < 0)
				{
					ignitionMask = LayerMask.GetMask("Grabbed_Item", "World_Item", "Hazmat");
				}
				int num = Physics.OverlapSphereNonAlloc(position, objectsRadius, overlapCache, ignitionMask, QueryTriggerInteraction.Collide);
				for (int i = 0; i < num; i++)
				{
					Collider collider = overlapCache[i];
					if (collider.gameObject.layer == hazmatLayer)
					{
						ICargoReaction componentInParent = collider.GetComponentInParent<ICargoReaction>();
						if (componentInParent == null || (componentInParent is IIgnitable && componentInParent as IIgnitable == ignoredIgnitable) || (!componentInParent.IsFlammable() && !componentInParent.IsExplosive()))
						{
							continue;
						}
						if (componentInParent.GetCargoPhase() == CargoPhase.Solid)
						{
							if (componentInParent.IsFlammable())
							{
								if (componentInParent.TryIgniteExternally(ignitionStrength))
								{
									result = true;
								}
							}
							else if (explosionChance >= Random.value)
							{
								componentInParent.TryExplodeExternally();
							}
						}
						else if (componentInParent.IsExplosive() && Random.value <= explosionChance * componentInParent.RequestRuptureArea())
						{
							componentInParent.TryExplodeExternally();
						}
						else if (componentInParent.TryIgniteExternally(ignitionStrength))
						{
							result = true;
						}
					}
					else
					{
						IIgnitable componentInParent2 = collider.GetComponentInParent<IIgnitable>();
						if (componentInParent2 is Component component && component != null && componentInParent2 != ignoredIgnitable && collider == componentInParent2.OverlapInteractionCollider && componentInParent2.IgnitionAllowed && componentInParent2.Ignite(ignitionStrength))
						{
							result = true;
						}
					}
				}
			}
			if (terrainClearance > 0f && IgniteTerrain(position, ignitionStrength, terrainClearance))
			{
				result = true;
			}
			return result;
		}

		public static bool IgniteTerrain(Vector3 position, float ignitionStrength = 1f, float terrainClearance = 1f, int tileOffsetX = 0, int tileOffsetY = 0)
		{
			if (!SingletonBehaviour<HazmatTileManager>.Instance)
			{
				return false;
			}
			if (position.y - HeightMapProvider.GetInterpolated(position) <= terrainClearance)
			{
				int gridPositionFromWorldPosition = SingletonBehaviour<HazmatTileManager>.Instance.GetGridPositionFromWorldPosition(position, usingWorldShift: true, tileOffsetX, tileOffsetY);
				bool num = SingletonBehaviour<HazmatTileManager>.Instance.IgniteTile(gridPositionFromWorldPosition, ignitionStrength);
				if (num)
				{
					SingletonBehaviour<HazmatTileManager>.Instance.hazmatAudioGrid.PlayIgnitionSound(position, forced: true);
				}
				return num;
			}
			return false;
		}

		public static bool IgniteTerrainDiamond(Vector3 position, float ignitionStrength = 1f, float terrainClearance = 1f, float radius = 1f, float chance = 1f)
		{
			if (!SingletonBehaviour<HazmatTileManager>.Instance)
			{
				return false;
			}
			hazmatTileCache.Clear();
			SingletonBehaviour<HazmatTileManager>.Instance.GetTilesInDiamondAreaAroundWorldPosition(position, radius, existingOnly: true, hazmatTileCache);
			bool result = false;
			foreach (HazmatGridTile item in hazmatTileCache)
			{
				if (!item.IsIgnited && position.y - item.terrainHeight <= terrainClearance && (chance >= 1f || Random.value < chance) && SingletonBehaviour<HazmatTileManager>.Instance.IgniteTile(item, ignitionStrength))
				{
					result = true;
				}
			}
			return result;
		}

		public static bool IgniteTerrainLine(Vector3 start, Vector3 end, float ignitionStrength = 1f, float terrainClearance = 1f, float chance = 1f)
		{
			if (!SingletonBehaviour<HazmatTileManager>.Instance)
			{
				return false;
			}
			hazmatTileCache.Clear();
			SingletonBehaviour<HazmatTileManager>.Instance.GetTilesInLine(start, end, existingOnly: true, hazmatTileCache);
			bool result = false;
			for (int i = 0; i < hazmatTileCache.Count; i++)
			{
				HazmatGridTile hazmatGridTile = hazmatTileCache[i];
				float t = (float)i / (float)Mathf.Max(1, hazmatTileCache.Count - 1);
				if (!hazmatGridTile.IsIgnited && Mathf.Lerp(start.y, end.y, t) - hazmatGridTile.terrainHeight <= terrainClearance && (chance >= 1f || Random.value < chance) && SingletonBehaviour<HazmatTileManager>.Instance.IgniteTile(hazmatGridTile, ignitionStrength))
				{
					result = true;
				}
			}
			return result;
		}
	}
}
