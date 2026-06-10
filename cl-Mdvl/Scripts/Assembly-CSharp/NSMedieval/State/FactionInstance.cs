using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Factions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("FactionInstance", "")]
	public class FactionInstance : IFVSerializable
	{
		[SerializeField]
		private string blueprintId;

		[SerializeField]
		private float playerFriendliness;

		[SerializeField]
		private float maxPlayerFriendliness;

		[SerializeField]
		private bool hasPrisoners;

		[SerializeField]
		private FloatRange friendlinessRange;

		[NonSerialized]
		private Faction blueprint;

		public string BlueprintId => blueprintId;

		public float PlayerFriendliness => playerFriendliness;

		public float MaxPlayerFriendliness => maxPlayerFriendliness;

		public Faction Blueprint
		{
			get
			{
				if (blueprint == null)
				{
					blueprint = Repository<FactionRepository, Faction>.Instance.GetByID(blueprintId);
				}
				return blueprint;
			}
		}

		public string NameLocalized => MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(Blueprint.LocKeys), BodyType.None);

		public FloatRange FriendlinessRange => friendlinessRange;

		public float TradeDealMultiplier
		{
			get
			{
				if (!GlobalSaveController.CurrentVillageData.WorldMapData.TradeDeals.Contains(blueprintId))
				{
					return 1f;
				}
				return 0.85f;
			}
		}

		public FactionInstance(Faction blueprint)
		{
			blueprintId = blueprint.GetID();
			this.blueprint = blueprint;
			friendlinessRange = Blueprint.FriendlinessRange;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder;
			if (this.blueprint.FactionTypeId != "non_partisan")
			{
				Scenario selectedScenario = MonoSingleton<GameStartController>.Instance.SelectedScenario;
				if ((object)selectedScenario != null && selectedScenario.TryGetFriendlinessRangeOverride(this.blueprint.FactionTypeId, out var range))
				{
					messageBuilder = new FVLogTraceInterpolationHandler(34, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\Faction\\FactionInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Overriding range of ");
						messageBuilder.AppendFormatted(blueprint);
						messageBuilder.AppendLiteral(": (");
						messageBuilder.AppendFormatted(friendlinessRange.Min);
						messageBuilder.AppendLiteral(", ");
						messageBuilder.AppendFormatted(friendlinessRange.Max);
						messageBuilder.AppendLiteral(") to (");
						messageBuilder.AppendFormatted(range.Min);
						messageBuilder.AppendLiteral(", ");
						messageBuilder.AppendFormatted(range.Max);
						messageBuilder.AppendLiteral(")");
					}
					Log.Trace(messageBuilder);
					friendlinessRange = range;
				}
			}
			playerFriendliness = friendlinessRange.Random();
			messageBuilder = new FVLogTraceInterpolationHandler(22, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\Faction\\FactionInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Random range of ");
				messageBuilder.AppendFormatted(blueprint);
				messageBuilder.AppendLiteral(": (");
				messageBuilder.AppendFormatted(friendlinessRange.Min);
				messageBuilder.AppendLiteral(", ");
				messageBuilder.AppendFormatted(friendlinessRange.Max);
				messageBuilder.AppendLiteral(")");
			}
			Log.Trace(messageBuilder);
		}

		public void AddFriendliness(float valueToAdd, bool showNotification = true, bool processRelatedFactions = true)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(32, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\Faction\\FactionInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Adding ");
				messageBuilder.AppendFormatted(valueToAdd);
				messageBuilder.AppendLiteral(" friendliness to faction ");
				messageBuilder.AppendFormatted(BlueprintId);
			}
			Log.Info(messageBuilder);
			SetPlayerFriendliness(playerFriendliness + valueToAdd, showNotification, processRelatedFactions);
		}

		public void SetPlayerFriendliness(float newFriendliness, bool showNotification = true, bool processRelatedFactions = true)
		{
			if (Blueprint == null || IsPermanentlyHostile())
			{
				return;
			}
			FactionFriendliness friendliness = GetFriendliness();
			float f = playerFriendliness;
			float max = ((maxPlayerFriendliness > 0f) ? maxPlayerFriendliness : 100f);
			playerFriendliness = Mathf.Clamp(newFriendliness, -100f, max);
			FactionFriendliness friendliness2 = GetFriendliness();
			int num = Mathf.RoundToInt(playerFriendliness) - Mathf.RoundToInt(f);
			if (showNotification && num != 0)
			{
				string messageText = MonoSingleton<LocalizationController>.Instance.GetText("friendliness_change").Replace("<friendliness_impact>", num.ToString()).Replace("<faction_name>", NameLocalized);
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(messageText);
				MonoSingleton<FactionsController>.Instance.OnFriendlinessChangedByAmount(num, this);
			}
			if (friendliness2 != friendliness)
			{
				string nameLocalized = NameLocalized;
				string text = MonoSingleton<LocalizationController>.Instance.GetText(GetFriendlinessTextKey());
				string messageText2 = MonoSingleton<LocalizationController>.Instance.GetText("friendliness_stat_change").Replace("<faction_name>", nameLocalized).Replace("<faction_status>", text);
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(messageText2);
				MonoSingleton<FactionsController>.Instance.OnFriendlinessChanged(friendliness2, this);
				if (processRelatedFactions)
				{
					ProcessRelationsOnFriendlinessChange(friendliness2);
				}
			}
		}

		private void SetMaxPlayerFriendliness(float maxPlayerFriendliness)
		{
			this.maxPlayerFriendliness = maxPlayerFriendliness;
			if (this.maxPlayerFriendliness > 0f && playerFriendliness > this.maxPlayerFriendliness)
			{
				SetPlayerFriendliness(this.maxPlayerFriendliness);
			}
		}

		private IEnumerable<string> GetEnemyFactionTypes(string factionType)
		{
			float hostileMin = GlobalSaveController.CurrentVillageData.WorldMapData.FactionSettings.NeutralRange.Min;
			return (from relation in GlobalSaveController.CurrentVillageData.WorldMapData.FactionRelations
				where relation.FactionA.Equals(factionType) || relation.FactionB.Equals(factionType)
				where relation.Friendliness <= hostileMin
				select relation).ToList().ConvertAll((FactionRelationInstance item) => (!item.FactionA.Equals(factionType)) ? item.FactionA : item.FactionB);
		}

		private IEnumerable<string> GetFriendlyFactionTypes(string factionType)
		{
			float neutralRangeMax = GlobalSaveController.CurrentVillageData.WorldMapData.FactionSettings.NeutralRange.Max;
			return (from relation in GlobalSaveController.CurrentVillageData.WorldMapData.FactionRelations
				where relation.FactionA.Equals(factionType) || relation.FactionB.Equals(factionType)
				where relation.Friendliness > neutralRangeMax
				select relation).ToList().ConvertAll((FactionRelationInstance item) => (!item.FactionA.Equals(factionType)) ? item.FactionA : item.FactionB);
		}

		public IEnumerable<FactionInstance> GetEnemyFactionInstances()
		{
			string iD = Blueprint.FactionType.GetID();
			IEnumerable<string> enemyFactionTypes = GetEnemyFactionTypes(iD);
			if (enemyFactionTypes == null)
			{
				return null;
			}
			return GlobalSaveController.CurrentVillageData.WorldMapData.FactionInstances.Where((FactionInstance factionInstance) => enemyFactionTypes.Contains(factionInstance.Blueprint.FactionType.GetID()) && GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaceExistsForFaction(factionInstance.BlueprintId));
		}

		public IEnumerable<FactionInstance> GetFriendlyFactionInstances()
		{
			string iD = Blueprint.FactionType.GetID();
			IEnumerable<string> friendlyFactionTypes = GetFriendlyFactionTypes(iD);
			if (friendlyFactionTypes == null)
			{
				return null;
			}
			return GlobalSaveController.CurrentVillageData.WorldMapData.FactionInstances.Where((FactionInstance factionInstance) => friendlyFactionTypes.Contains(factionInstance.Blueprint.FactionType.GetID()) && GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaceExistsForFaction(factionInstance.BlueprintId));
		}

		private void ProcessRelationsOnFriendlinessChange(FactionFriendliness factionFriendliness)
		{
			if (!MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated() || (factionFriendliness != FactionFriendliness.Hostile && factionFriendliness != FactionFriendliness.Friendly))
			{
				return;
			}
			FactionGameModeSettings factionSettings = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionSettings;
			float valueToAdd = ((factionFriendliness == FactionFriendliness.Hostile) ? factionSettings.FriendlinessAddToEnemiesOfEnemy : factionSettings.FriendlinessAddToEnemiesOfFriend);
			IEnumerable<FactionInstance> enemyFactionInstances = GetEnemyFactionInstances();
			if (enemyFactionInstances == null)
			{
				return;
			}
			foreach (FactionInstance item in enemyFactionInstances)
			{
				if (!item.IsPermanentlyHostile())
				{
					item.AddFriendliness(valueToAdd, showNotification: false, processRelatedFactions: false);
				}
			}
		}

		public FactionFriendliness GetFriendliness()
		{
			FloatRange neutralRange = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionSettings.NeutralRange;
			if (IsPermanentlyHostile())
			{
				return FactionFriendliness.PermanentlyHostile;
			}
			if (playerFriendliness < neutralRange.Min)
			{
				return FactionFriendliness.Hostile;
			}
			if (playerFriendliness > neutralRange.Max)
			{
				return FactionFriendliness.Friendly;
			}
			return FactionFriendliness.Neutral;
		}

		public string GetFriendlinessTextKey()
		{
			FactionFriendliness friendliness = GetFriendliness();
			try
			{
				return MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionSettings.FriendlinessTextKeys[(int)friendliness];
			}
			catch (Exception ex)
			{
				Log.Error("Error: " + ex.Message + "\n" + ex.StackTrace, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\Faction\\FactionInstance.cs");
				return "friendliness_" + friendliness;
			}
		}

		public string GetFriendlinessTextColored()
		{
			FactionFriendliness friendliness = GetFriendliness();
			string text = MonoSingleton<LocalizationController>.Instance.GetText(GetFriendlinessTextKey());
			if (friendliness.Equals(FactionFriendliness.Friendly))
			{
				return ColorUtils.ColorText(text, Color.green);
			}
			if (friendliness.Equals(FactionFriendliness.Hostile))
			{
				return ColorUtils.ColorText(text, Color.red);
			}
			if (friendliness.Equals(FactionFriendliness.PermanentlyHostile))
			{
				return ColorUtils.ColorText(text, Color.red);
			}
			return ColorUtils.ColorText(text, Color.white);
		}

		public bool IsHostile()
		{
			if (IsPermanentlyHostile())
			{
				return true;
			}
			FloatRange neutralRange = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionSettings.NeutralRange;
			return playerFriendliness < neutralRange.Min;
		}

		public bool IsPermanentlyHostile()
		{
			if (Mathf.Approximately(Blueprint.FriendlinessRange.Min, -100f) && Mathf.Approximately(Blueprint.FriendlinessRange.Max, -100f))
			{
				return true;
			}
			if (Mathf.Approximately(friendlinessRange.Min, -100f))
			{
				return Mathf.Approximately(friendlinessRange.Max, -100f);
			}
			return false;
		}

		public void SetPermanentlyHostile()
		{
			if (!IsPermanentlyHostile())
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(40, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\Faction\\FactionInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Setting faction ");
					messageBuilder.AppendFormatted(blueprintId);
					messageBuilder.AppendLiteral(" to permanently hostile.");
				}
				Log.Info(messageBuilder);
				friendlinessRange = new FloatRange(-100f, -100f);
				maxPlayerFriendliness = -100f;
				playerFriendliness = -100f;
				MonoSingleton<FactionsController>.Instance.OnFriendlinessChanged(GetFriendliness(), this);
			}
		}

		public void TickFriendlinessDegradation()
		{
			if (IsPermanentlyHostile())
			{
				return;
			}
			FactionGameModeSettings factionSettings = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionSettings;
			float friendlinessTargetEnemy = factionSettings.FriendlinessTargetEnemy;
			float friendlinessTargetNeutral = factionSettings.FriendlinessTargetNeutral;
			float friendlinessTargetFriendly = factionSettings.FriendlinessTargetFriendly;
			float num = 0f;
			FloatRange neutralRange = factionSettings.NeutralRange;
			if (playerFriendliness <= neutralRange.Min)
			{
				num = friendlinessTargetEnemy;
			}
			else if (playerFriendliness < neutralRange.Max)
			{
				num = friendlinessTargetNeutral;
			}
			else if (playerFriendliness >= neutralRange.Max)
			{
				num = friendlinessTargetFriendly;
			}
			if (!(Math.Abs(playerFriendliness - num) < 0.05f))
			{
				float friendlinessChangePerDay = factionSettings.FriendlinessChangePerDay;
				if (playerFriendliness < num)
				{
					float valueToAdd = Mathf.Min(friendlinessChangePerDay, num - playerFriendliness);
					AddFriendliness(valueToAdd, showNotification: false);
				}
				else if (playerFriendliness > num)
				{
					float num2 = Mathf.Min(friendlinessChangePerDay, playerFriendliness - num);
					AddFriendliness(0f - num2, showNotification: false);
				}
			}
		}

		public BodyType GetRandomBodyType()
		{
			if (!(UnityEngine.Random.value > Blueprint.Female))
			{
				return BodyType.Female;
			}
			return BodyType.Male;
		}

		public void HitFromFriendly(float friendlinessToAdd)
		{
			MonoSingleton<GlobalStatManager>.Instance.AddToGlobalStatValue("infamy", 4f);
			AddFriendliness(friendlinessToAdd);
			float min = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionSettings.NeutralRange.Min;
			int num = Mathf.CeilToInt(Mathf.Max(0f, PlayerFriendliness - min) / Mathf.Abs(friendlinessToAdd));
			if (num > 0)
			{
				string messageText = MonoSingleton<LocalizationController>.Instance.GetText("message_hit_trader").Replace("<hits_count>", num.ToString());
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(messageText);
			}
		}

		public void MakeHostile()
		{
			AddFriendliness(-200f);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("blueprintId", blueprintId);
			serializer.Write("playerFriendliness", playerFriendliness);
			serializer.Write("maxPlayerFriendliness", maxPlayerFriendliness);
			serializer.Write("hasPrisoners", hasPrisoners);
			serializer.Write("friendlinessRange", friendlinessRange);
		}

		public FactionInstance(FVDeserializer deserializer)
		{
			blueprintId = deserializer.ReadString("blueprintId");
			playerFriendliness = deserializer.ReadFloat("playerFriendliness");
			maxPlayerFriendliness = deserializer.ReadFloat("maxPlayerFriendliness");
			hasPrisoners = deserializer.ReadBool("hasPrisoners");
			friendlinessRange = deserializer.ReadObject<FloatRange>("friendlinessRange") ?? Blueprint.FriendlinessRange;
		}

		public void SetHasPrisoners(bool hasPrisoners)
		{
			if (hasPrisoners != this.hasPrisoners)
			{
				this.hasPrisoners = hasPrisoners;
				SetMaxPlayerFriendliness(hasPrisoners ? Blueprint.MaxFriendlinessPrisoners : 0f);
			}
		}

		public TradeForbiddenReason GetPrisonerTradeStatus(CreatureBase creatureBase)
		{
			if (!(creatureBase is HumanoidInstance humanoidInstance))
			{
				return TradeForbiddenReason.None;
			}
			if (Blueprint.AcceptPrisonersOfSameFaction && BlueprintId == humanoidInstance.Faction?.BlueprintId)
			{
				return TradeForbiddenReason.None;
			}
			if (Blueprint.AcceptPrisonersOfOtherFactions && BlueprintId != humanoidInstance.Faction?.BlueprintId)
			{
				return TradeForbiddenReason.None;
			}
			return TradeForbiddenReason.PrisonerNotOwnFaction;
		}
	}
}
