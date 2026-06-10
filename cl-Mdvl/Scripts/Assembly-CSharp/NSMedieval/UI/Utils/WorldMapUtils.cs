using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Factions;
using NSMedieval.Model.SecondMap;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.WorldMap;
using Repository.Map;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class WorldMapUtils
	{
		public static string GetFriendlinessText(FactionInstance factionInstance)
		{
			int num = Mathf.RoundToInt(Mathf.Clamp(factionInstance.PlayerFriendliness, -100f, 100f));
			string text = UiUtils.Localize.GetText(factionInstance.GetFriendlinessTextKey());
			text = ColorUtils.ColorText(text, GetFriendlinessColor(factionInstance));
			return string.Format("{0}: {1}% ({2})", UiUtils.Localize.GetText("faction_player_friendliness"), num, text);
		}

		public static Color GetFriendlinessColor(FactionInstance factionInstance)
		{
			if (factionInstance == null)
			{
				return Color.gray;
			}
			FactionGameModeSettings factionSettings = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionSettings;
			FloatRange neutralRange = factionSettings.NeutralRange;
			float num = Mathf.Clamp(factionInstance.PlayerFriendliness, -100f, 100f);
			if (num < neutralRange.Min)
			{
				return Color.Lerp(factionSettings.ColorHostileLow, factionSettings.ColorHostileHigh, Mathf.Abs(Mathf.Abs(num - neutralRange.Min) / Mathf.Abs(-100f - neutralRange.Min)));
			}
			if (num > neutralRange.Max)
			{
				return Color.Lerp(factionSettings.ColorFriendlyLow, factionSettings.ColorFriendlyHigh, Mathf.Abs(Mathf.Abs(num - neutralRange.Max) / Mathf.Abs(100f - neutralRange.Max)));
			}
			if (num < 0f)
			{
				return Color.Lerp(factionSettings.ColorNeutral, factionSettings.ColorHostileLow, Mathf.Abs(num / neutralRange.Min));
			}
			return Color.Lerp(factionSettings.ColorNeutral, factionSettings.ColorFriendlyLow, Mathf.Abs(num / neutralRange.Max));
		}

		public static string PickMapBiomeVariant(PooledList<string> mapIds, in Vector2Int markerGridPosition)
		{
			if (!mapIds.HasValue || mapIds.Count == 0)
			{
				Log.Error("Can't pick map biome variant because stashMapMarkerIds is null or empty", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\WorldMapUtils.cs");
				return null;
			}
			string mapTypeName = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.GetMapTypeName(in markerGridPosition);
			if (mapTypeName == null)
			{
				throw new Exception($"Grid cell map type is null for position {markerGridPosition}");
			}
			using PooledList<SecondMapSaveInfo> pooledList = ListPool<SecondMapSaveInfo>.GetJanitor();
			foreach (string item in mapIds)
			{
				SecondMapSaveInfo byID = Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetByID(item);
				if (byID == null)
				{
					throw new Exception("Second map with ID '" + item + "' not found in SecondMapSaveRepository");
				}
				if (byID.BiomeType == mapTypeName)
				{
					pooledList.Add(byID);
				}
			}
			if (pooledList.Count == 0)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(132, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\WorldMapUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("(ignore this if spawned via dev panel) Matching biome variant not found for world map position ");
					messageBuilder.AppendFormatted(markerGridPosition);
					messageBuilder.AppendLiteral(", biome ");
					messageBuilder.AppendFormatted(mapTypeName);
					messageBuilder.AppendLiteral(", choosing random map variant");
				}
				Log.Info(messageBuilder);
				return mapIds.PickRandom();
			}
			return pooledList.PickRandom().GetID();
		}
	}
}
