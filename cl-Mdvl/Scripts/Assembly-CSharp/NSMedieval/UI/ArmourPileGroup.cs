using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ArmourPileGroup : QualityPileGroup
	{
		[SerializeField]
		private TMP_Text armourRating;

		public override void SetInstance(ResourcePileInstance instance, int index)
		{
			base.SetInstance(instance, index);
			Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
			StatInstance stat = instance.GetStat(StatType.Health);
			float num = ((stat != null) ? Mathf.Clamp(byID.ArmorRating * (stat.Current / stat.Max), 0f, 1f) : byID.ArmorRating);
			armourRating.SetText($"{num:P2}");
		}
	}
}
