using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class RangedPileGroup : WeaponPileGroup
	{
		[SerializeField]
		private TMP_Text itemRange;

		[SerializeField]
		private TMP_Text itemPrecision;

		public override void SetInstance(ResourcePileInstance instance, int index)
		{
			base.SetInstance(instance, index);
			Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
			itemRange.SetText(base.Localize.GetText($"{byID.PrimaryRange}m"));
			itemPrecision.SetText(base.Localize.GetText($"{byID.PrimaryPrecision:P0}"));
		}
	}
}
