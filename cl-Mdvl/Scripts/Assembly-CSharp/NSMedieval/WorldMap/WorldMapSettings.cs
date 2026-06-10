using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	[Serializable]
	public class WorldMapSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private List<WorldMapCellType> cellTypes;

		[SerializeField]
		private List<string> startMapTypes;

		[SerializeField]
		private SerializableVector2Int resolution;

		[SerializeField]
		private List<TraderStockModifiersContainer> stockModifiersByMapId;

		[NonSerialized]
		private Dictionary<int, WorldMapCellType> cellTypesByHeightCache;

		[NonSerialized]
		private Dictionary<int, WorldMapCellType> cellTypesByIdCache;

		[NonSerialized]
		private bool initDone;

		public List<string> StartMapTypes => startMapTypes;

		public Vector2Int Resolution => resolution;

		public WorldMapCellType GetCellTypeByID(int id)
		{
			return cellTypesByIdCache.GetValueOrDefault(id);
		}

		public WorldMapCellType GetCellTypeForHeight(float height)
		{
			int key = (int)Mathf.Clamp(height * 100f, 0f, 99f);
			return cellTypesByHeightCache[key];
		}

		public bool CheckId(int id, string cellType)
		{
			if (!cellTypesByIdCache.TryGetValue(id, out var value))
			{
				return false;
			}
			return value.MapType.Equals(cellType);
		}

		public List<TraderStockModifier> GetTraderStockModifiersForMapType(string mapTypeId)
		{
			foreach (TraderStockModifiersContainer item in stockModifiersByMapId)
			{
				if (mapTypeId.Equals(item.GetID()))
				{
					return item.StockModifiers;
				}
			}
			return null;
		}

		public override string GetID()
		{
			return "WorldMapSettings";
		}

		public void Init()
		{
			if (initDone)
			{
				return;
			}
			initDone = true;
			if (cellTypesByIdCache == null)
			{
				cellTypesByIdCache = new Dictionary<int, WorldMapCellType>();
				foreach (WorldMapCellType cellType in cellTypes)
				{
					if (!cellTypesByIdCache.TryAdd(cellType.Id, cellType))
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(79, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMapSettings.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Conflicting map cell types: ");
							messageBuilder.AppendFormatted(cellType.MapType);
							messageBuilder.AppendLiteral(" and ");
							messageBuilder.AppendFormatted(cellTypesByIdCache[cellType.Id]?.MapType);
							messageBuilder.AppendLiteral(" have the same ID: ");
							messageBuilder.AppendFormatted(cellType.Id);
							messageBuilder.AppendLiteral(". Overriding with new one: ");
							messageBuilder.AppendFormatted(cellType.MapType);
						}
						Log.Error(messageBuilder);
						cellTypesByIdCache[cellType.Id] = cellType;
					}
				}
			}
			if (cellTypesByHeightCache != null)
			{
				return;
			}
			List<WorldMapCellType> list = new List<WorldMapCellType>(cellTypes);
			list.Sort((WorldMapCellType itemA, WorldMapCellType itemB) => (int)(itemB.Height * 1000f - itemA.Height * 1000f));
			cellTypesByHeightCache = new Dictionary<int, WorldMapCellType>();
			for (int num = 0; num < 100; num++)
			{
				float h = (float)num / 100f;
				WorldMapCellType value = list.FirstOrDefault((WorldMapCellType worldMapCellType) => h >= worldMapCellType.Height);
				cellTypesByHeightCache.Add(num, value);
			}
		}
	}
}
