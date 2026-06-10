using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ApparelPileGroup : QualityPileGroup
	{
		[SerializeField]
		private TMP_Text itemTempMin;

		[SerializeField]
		private TMP_Text itemTempMax;

		public override void SetInstance(ResourcePileInstance instance, int index)
		{
			base.SetInstance(instance, index);
			Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
			TemperatureUnitsType temperatureUnits = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TemperatureUnits;
			string text = base.Localize.GetText($"general_symbol_{temperatureUnits}");
			int num = (int)WorldDate.ConvertCelsiusTemperature(byID.WarmthModifier.Min, temperatureUnits, baseValue: false);
			int num2 = (int)WorldDate.ConvertCelsiusTemperature(byID.WarmthModifier.Max, temperatureUnits, baseValue: false);
			itemTempMin.SetText(base.Localize.GetText($"{num}{text}"));
			itemTempMax.SetText(base.Localize.GetText($"{num2}{text}"));
		}
	}
}
