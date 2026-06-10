using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class EquipmentTooltipView : TooltipViewNew
	{
		[NonSerialized]
		private EquipmentInstance equipmentItem;

		[NonSerialized]
		private HumanoidInstance humanoid;

		public void SetupData(EquipmentInstance item, HumanoidInstance humanoidInstance)
		{
			if (item != null)
			{
				equipmentItem = item;
				humanoid = humanoidInstance;
			}
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			if (equipmentItem == null || equipmentItem.HasDisposed)
			{
				return base.Lines;
			}
			StatsInstance stats = equipmentItem.Stats;
			if (stats == null)
			{
				return base.Lines;
			}
			Resource resource = Repository<ResourceRepository, Resource>.Instance.GetByID(equipmentItem.Id);
			Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(equipmentItem.Id);
			StatInstance stat = stats.GetStat(StatType.Health);
			string text = EquipmentUtils.GetTooltipTitle(byID);
			if (humanoid != null)
			{
				string text2 = ((humanoid.Inventory.GetEquipments()?.FirstOrDefault((EquipmentInstance i) => i.Blueprint.GetID() == resource.GetID())?.IsManuallyEquiped == true) ? MonoSingleton<LocalizationController>.Instance.GetText("manually_equipped") : MonoSingleton<LocalizationController>.Instance.GetText("auto_equipped"));
				text = text + " (" + text2 + ")";
			}
			AppendLine(text, TooltipStyles.TooltipTitle);
			AppendLine($"<#{ColorTools.GetHexColor(Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max))}>{Mathf.RoundToInt(stat.Current)}" + string.Format("/{0} </color>  {1}", Mathf.RoundToInt(stat.Max), MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points")), TooltipStyles.TooltipDescriptionLine);
			AppendLines(EquipmentUtils.GetTooltipLines(byID, stat));
			return base.Lines;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			humanoid = null;
			equipmentItem = null;
		}
	}
}
