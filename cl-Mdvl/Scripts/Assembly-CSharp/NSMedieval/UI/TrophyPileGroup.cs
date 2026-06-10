using NSMedieval.State;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class TrophyPileGroup : ResourcePileOverviewGroup
	{
		[SerializeField]
		private TMP_Text itemOwnerName;

		public override void SetInstance(ResourcePileInstance instance, int index)
		{
			base.SetInstance(instance, index);
			itemOwnerName.SetText(instance.GetStoredResource()?.LocalizedInheritedName);
		}
	}
}
