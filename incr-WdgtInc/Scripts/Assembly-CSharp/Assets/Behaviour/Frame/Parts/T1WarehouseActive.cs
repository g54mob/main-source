using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T1WarehouseActive : ActiveWorldFrame
	{
		[SerializeField]
		private T1WarehouseSelector _selector;

		public override void UpdateUpgradeSlot(WorldAnchor anchor)
		{
			base.UpdateUpgradeSlot(anchor);
			_selector.UpdateText();
		}
	}
}
