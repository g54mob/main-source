using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Construction;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public abstract class MapResource : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private float miningDuration;

		[SerializeField]
		private string miningTool;

		[SerializeField]
		private ushort pathfindingPenalty = ushort.MaxValue;

		[SerializeField]
		private float layerHideOffset;

		[SerializeField]
		private float layerShadowOffset;

		[SerializeField]
		private string[] prefabIDs;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private List<MeshVariationList> variationLists;

		[SerializeField]
		private float walkSpeedMultiplier = 0.5f;

		[NonSerialized]
		private Dictionary<string, MeshVariationList> variationsById;

		public string[] PrefabIDs => prefabIDs;

		public LocKeys[] LocKeys => locKeys;

		public ushort PathfindingPenalty => pathfindingPenalty;

		public string MiningTool => miningTool;

		public float LayerHideOffset => layerHideOffset;

		public float LayerShadowOffset => layerShadowOffset;

		public float WalkSpeedMultiplier => walkSpeedMultiplier;

		protected float MiningDuration => miningDuration;

		protected HarvestParametars MiningParameters { get; set; }

		public List<MeshVariationList> VariationLists => variationLists;

		public Dictionary<string, MeshVariationList> VariationsById
		{
			get
			{
				if (variationsById == null)
				{
					variationsById = new Dictionary<string, MeshVariationList>();
					foreach (MeshVariationList variationList in variationLists)
					{
						variationsById.TryAdd(variationList.Name, variationList);
					}
				}
				return variationsById;
			}
		}

		public override string GetID()
		{
			return id;
		}

		public abstract HarvestParametars GetMiningParameters();
	}
}
