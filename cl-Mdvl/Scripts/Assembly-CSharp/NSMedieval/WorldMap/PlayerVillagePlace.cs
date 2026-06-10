using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI.Statistic;
using NSMedieval.UI.Utils;

namespace NSMedieval.WorldMap
{
	[FVSerializableKey("PlayerVillagePlace", "")]
	public class PlayerVillagePlace : WorldMapPlace
	{
		private string enterMapLoadingScreenTitle;

		private string enterMapLoadingScreenDescription;

		public override string EnterMapLoadingScreenTitle
		{
			get
			{
				if (enterMapLoadingScreenTitle == null)
				{
					enterMapLoadingScreenTitle = LocKeyUtils.GetName(GlobalSaveController.CurrentVillageData.Scenario.LocKeys);
				}
				return enterMapLoadingScreenTitle;
			}
		}

		public override string EnterMapLoadingScreenDescription
		{
			get
			{
				if (enterMapLoadingScreenDescription == null)
				{
					enterMapLoadingScreenDescription = GetLoadingScreenEntries();
				}
				return enterMapLoadingScreenDescription;
			}
		}

		public override FactionInstance FactionInstance { get; set; }

		public override string PreciseEnemyCountInfoLocalized => null;

		public override string BallparkEnemyCountInfoLocalized => null;

		public PlayerVillagePlace()
			: base((string)null)
		{
			base.Name = GlobalSaveController.CurrentVillageData.Name;
			base.Position = MonoSingleton<WorldMap>.Instance.Data.VillagePosition;
			base.MapType = GlobalSaveController.CurrentVillageData.MapTypeID;
			base.MarkerState = MapMarkerState.None;
		}

		public override IWorldMapPlaceReference CreateReference()
		{
			return new PlayerVillagePlaceReference();
		}

		public override void GenerateSelectionPanelText(List<string> outLines)
		{
		}

		public override List<ResourceInstance> GenerateLoot()
		{
			return null;
		}

		private string GetLoadingScreenEntries()
		{
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			if (currentVillageData.HistoryEntries == null)
			{
				Log.Error("No History Entries for this village save. This should never happen.", "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\PlayerVillagePlace.cs");
				return string.Empty;
			}
			if (currentVillageData.HistoryEntries.Count == 1)
			{
				return currentVillageData.HistoryEntries.First().DetailsText;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int maxLength = 500;
			int num = 4;
			int num2 = 0;
			foreach (HistoryEntry item in currentVillageData.HistoryEntries.IterateInReverse())
			{
				stringBuilder.AppendLine("\r<style=AltColorParagraphTitle>" + item.TitleText + "</style> <style=Desc>" + item.Date + "</style> ");
				stringBuilder.AppendLine(item.DetailsText.RemoveNewLines().TruncateAtLenght(maxLength) + "</style>");
				stringBuilder.AppendLine();
				num2++;
				if (num2 == num)
				{
					return stringBuilder.ToString();
				}
			}
			return stringBuilder.ToString();
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public PlayerVillagePlace(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
