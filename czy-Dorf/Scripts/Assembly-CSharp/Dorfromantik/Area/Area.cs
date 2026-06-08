using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik.Area
{
	public class Area : MonoBehaviour
	{
		[SerializeField]
		private AreaType type;

		[SerializeField]
		internal AreaScope scope;

		[SerializeField]
		private AreaSpawnBehavior spawnBehavior;

		[SerializeField]
		private bool isPercentageComplete;

		[SerializeField]
		private bool isFullyComplete;

		[SerializeField]
		private float completionPercentageCurrent;

		[SerializeField]
		private int completionPercentageNeeded;

		[SerializeField]
		private int tilesNeededForCompletion;

		[SerializeField]
		private int areaSlotCapacity;

		[SerializeField]
		private List<Tile> placedTiles;

		[SerializeField]
		private List<AreaSlot> areaSlots;

		[SerializeField]
		private List<AreaSlot> edgeAreaSlots;

		[SerializeField]
		private Material initialAreaSlotMaterial;

		internal Material previewMaterial;

		internal AreaSignpost areaSignpost;

		private TileOutliner tileOutliner;

		internal int AreaSlotCapacity
		{
			get
			{
				return areaSlotCapacity;
			}
			private set
			{
				areaSlotCapacity = value;
			}
		}

		internal AreaType Type
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
			}
		}

		internal AreaScope Scope
		{
			get
			{
				return scope;
			}
			private set
			{
				scope = value;
			}
		}

		internal AreaSpawnBehavior SpawnBehavior
		{
			get
			{
				return spawnBehavior;
			}
			private set
			{
				spawnBehavior = value;
			}
		}

		internal List<AreaSlot> AreaSlots
		{
			get
			{
				return areaSlots;
			}
			private set
			{
				areaSlots = value;
			}
		}

		internal List<AreaSlot> EdgeAreaSlots
		{
			get
			{
				return edgeAreaSlots;
			}
			private set
			{
				edgeAreaSlots = value;
			}
		}

		internal event Action<Area> OnAreaCompletion;

		private void Awake()
		{
			AreaSlots = new List<AreaSlot>();
			EdgeAreaSlots = new List<AreaSlot>();
			placedTiles = new List<Tile>();
			if (tileOutliner == null)
			{
				tileOutliner = GetComponent<TileOutliner>();
			}
		}

		internal void Initialize(int areaSlotCapacity, AreaType areaType, AreaScope areaScope, AreaSpawnBehavior areaSpawnBehavior, Material areaPreviewColor, string gameObjectName = null)
		{
			if (gameObjectName != null)
			{
				base.gameObject.name = gameObjectName;
			}
			previewMaterial = areaPreviewColor;
			AreaSlotCapacity = areaSlotCapacity;
			tilesNeededForCompletion = AreaSlotCapacity * Mathf.Clamp(completionPercentageNeeded, 0, 100) / 100;
			Type = areaType;
			Scope = areaScope;
			SpawnBehavior = areaSpawnBehavior;
			completionPercentageNeeded = areaSpawnBehavior.completionPercentageNeeded;
		}

		internal void Terminate(bool shouldDestroyAreaSlots = false, bool shouldDestroyAreaSignpost = false)
		{
			if (Enumerable.Any(AreaSlots))
			{
				foreach (AreaSlot areaSlot in AreaSlots)
				{
					if (areaSlot.placedTile != null)
					{
						Debug.LogWarning("The " + base.name + " is terminated, although there is still a placed tile (" + areaSlot.placedTile.name + ") placed on its position.");
					}
					areaSlot.UpdateAreaSlotNeighborsNeighborList(shouldDestroyAreaSlots);
					if (shouldDestroyAreaSlots)
					{
						UnityEngine.Object.Destroy(areaSlot.gameObject);
					}
				}
				EdgeAreaSlots.Clear();
				AreaSlots.Clear();
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}

		internal void AddAreaSlot(AreaSlot areaSlotToAdd)
		{
			if (!AreaSlots.Contains(areaSlotToAdd))
			{
				AreaSlots.Add(areaSlotToAdd);
				if (areaSlotToAdd.IsLocalEdgeAreaSlot)
				{
					AddEdgeAreaSlot(areaSlotToAdd);
				}
			}
			else
			{
				Debug.Log($"The areaSlot {areaSlotToAdd} is already added to {base.name}!");
			}
		}

		internal void AddEdgeAreaSlot(AreaSlot edgeAreaSlotToAdd)
		{
			if (!EdgeAreaSlots.Contains(edgeAreaSlotToAdd))
			{
				EdgeAreaSlots.Add(edgeAreaSlotToAdd);
			}
		}

		internal void RemoveEdgeAreaSlot(AreaSlot edgeAreaSlotToRemove)
		{
			if (EdgeAreaSlots.Contains(edgeAreaSlotToRemove))
			{
				EdgeAreaSlots.Remove(edgeAreaSlotToRemove);
			}
		}

		internal void AddPlacedTile(Tile tile)
		{
			if (!placedTiles.Contains(tile))
			{
				placedTiles.Add(tile);
				if (!tile.IsInitialTile)
				{
					CheckForCompletion();
				}
			}
		}

		private void CheckForCompletion()
		{
			tilesNeededForCompletion = Mathf.RoundToInt((float)AreaSlots.Count / 100f * (float)completionPercentageNeeded);
			float value = (float)placedTiles.Count / (float)tilesNeededForCompletion * 100f;
			completionPercentageCurrent = Mathf.Clamp(value, 0f, 100f);
			if (placedTiles.Count < tilesNeededForCompletion)
			{
				isFullyComplete = false;
				isPercentageComplete = false;
				return;
			}
			if (!isPercentageComplete)
			{
				this.OnAreaCompletion?.Invoke(this);
			}
			isPercentageComplete = true;
			if (placedTiles.Count >= AreaSlots.Count)
			{
				isFullyComplete = true;
			}
		}

		internal void DrawOutline()
		{
			if (Scope == AreaScope.Global && tileOutliner.offset < 0f)
			{
				tileOutliner.offset = Math.Abs(tileOutliner.offset);
			}
			else
			{
				tileOutliner.offset *= -1f;
			}
			tileOutliner.Outline(Enumerable.ToList((IEnumerable<IOutlineable>)EdgeAreaSlots));
		}

		internal void ClearOutline()
		{
			tileOutliner.ClearOutlines();
		}

		private void OnDestroy()
		{
			areaSignpost.Terminate();
		}

		private void ShowEdgeAreaSlots()
		{
			Material material = new Material(Enumerable.FirstOrDefault(EdgeAreaSlots)?.GetComponentInChildren<Renderer>().sharedMaterial);
			material.color = UnityEngine.Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.7f, 1f, 0.45f, 0.55f);
			foreach (AreaSlot edgeAreaSlot in EdgeAreaSlots)
			{
				edgeAreaSlot.GetComponentInChildren<Renderer>().sharedMaterial = material;
			}
		}

		private void HideEdgeAreaSlots()
		{
			foreach (AreaSlot edgeAreaSlot in EdgeAreaSlots)
			{
				edgeAreaSlot.GetComponentInChildren<Renderer>().sharedMaterial = initialAreaSlotMaterial;
			}
		}
	}
}
