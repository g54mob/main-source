using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "CustomerGroup", menuName = "Kitchen/Unlock/Customer Group", order = 0)]
	public class CustomerGroup : UnlockCard
	{
		public override string Icon => "<sprite name=\"group\">";

		public override Color Colour => new Color(1f, 0.6f, 0.46f);
	}
}
