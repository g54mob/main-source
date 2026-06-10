using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ShieldPileGroup : QualityPileGroup
	{
		[SerializeField]
		private TMP_Text itemMeleeCover;

		[SerializeField]
		private TMP_Text itemRangedCover;

		public override void SetInstance(ResourcePileInstance instance, int index)
		{
			base.SetInstance(instance, index);
			Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
			itemMeleeCover.SetText(base.Localize.GetText($"{byID.GetCoverChance(DamageType.Melee):P0}"));
			itemRangedCover.SetText(base.Localize.GetText($"{byID.GetCoverChance(DamageType.Ranged):P0}"));
		}
	}
}
