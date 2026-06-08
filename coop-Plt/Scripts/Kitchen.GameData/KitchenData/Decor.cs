using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Decor", menuName = "Kitchen/Decoration/Decor", order = 3)]
	public class Decor : GameDataObject
	{
		public Material Material;

		public Appliance ApplicatorAppliance;

		public LayoutMaterialType Type;

		public bool IsAvailable = true;

		protected override void InitialiseDefaults()
		{
		}
	}
}
