using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class WeaponPileGroup : QualityPileGroup
	{
		[SerializeField]
		private TMP_Text itemDps;

		public override void SetInstance(ResourcePileInstance instance, int index)
		{
			base.SetInstance(instance, index);
			Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
			itemDps.SetText(base.Localize.GetText($"{byID.PrimaryDamage / byID.PrimaryAttackSpeed:0.00}"));
		}
	}
}
