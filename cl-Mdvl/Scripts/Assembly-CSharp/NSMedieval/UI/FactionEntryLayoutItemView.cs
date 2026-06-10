using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class FactionEntryLayoutItemView : LayoutGroupItemView
	{
		[SerializeField]
		private TooltipViewNew nameTootip;

		[SerializeField]
		private TooltipViewNew statusTooltip;

		private const int HeraldryIndex = 0;

		private const int TextIndex = 1;

		private const int StatusIndex = 2;

		private const int HostileParentIndex = 3;

		private readonly List<HeraldrySymbolElement> hostileFactions = new List<HeraldrySymbolElement>();

		public void SetData(FactionInstance factionInstance)
		{
			base.GroupItems[1].GetComponent<TMP_Text>().SetText(GetFactionText(factionInstance));
			base.GroupItems[2].GetComponent<TMP_Text>().SetText(factionInstance.GetFriendlinessTextColored());
			Sprite heraldryCrestSprite = factionInstance.Blueprint.HeraldryCrestSprite;
			Sprite heraldryBackgroundSprite = factionInstance.Blueprint.HeraldryBackgroundSprite;
			base.GroupItems[0].GetComponent<HeraldrySymbolElement>().SetSprites(heraldryCrestSprite, heraldryBackgroundSprite);
			hostileFactions.SetAllActive(active: false);
			foreach (FactionInstance item in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.GetEnemyFaction(factionInstance))
			{
				Sprite heraldryCrestSprite2 = item.Blueprint.HeraldryCrestSprite;
				Sprite heraldryBackgroundSprite2 = item.Blueprint.HeraldryBackgroundSprite;
				HeraldrySymbolElement next = hostileFactions.GetNext(base.GroupItems[3].GetComponent<LayoutGroupView>());
				next.SetSprites(heraldryCrestSprite2, heraldryBackgroundSprite2);
				next.SetFactionId(item.Blueprint.GetID());
			}
			nameTootip.SetLines(GetNameData(factionInstance));
			statusTooltip.SetLines(GetStatusData(factionInstance));
		}

		private void GetSettlementNames(FactionInstance factionInstance, IList<string> outputList)
		{
			foreach (VillagePlace villagePlace in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.VillagePlaces)
			{
				if (villagePlace.FactionInstance == factionInstance)
				{
					outputList.Add(villagePlace.Name);
				}
			}
		}

		private string GetFactionText(FactionInstance factionInstance)
		{
			using PooledList<string> pooledList = ListPool<string>.GetJanitor();
			GetSettlementNames(factionInstance, pooledList);
			string nameLocalized = factionInstance.NameLocalized;
			if (pooledList.Count == 0)
			{
				return nameLocalized;
			}
			return nameLocalized + "\n" + MonoSingleton<LocalizationController>.Instance.GetText("faction_settlements") + ": " + string.Join(", ", pooledList);
		}

		private List<string> GetNameData(FactionInstance factionInstance)
		{
			return new List<string>
			{
				TooltipStyles.ApplyStyle(base.Localize.GetText(LocKeyUtils.GetName(factionInstance.Blueprint.LocKeys)), TooltipStyles.TooltipTitle),
				base.Localize.GetText(LocKeyUtils.GetInfo(factionInstance.Blueprint.LocKeys)) ?? "",
				base.Localize.GetText("center_of_power") + " : " + base.Localize.GetText(factionInstance.Blueprint.GetID() + "_center")
			};
		}

		private static List<string> GetStatusData(FactionInstance factionInstance)
		{
			return new List<string> { NpcUtils.GetLocalizedFactionFriendliness(factionInstance) };
		}
	}
}
