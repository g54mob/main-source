using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Crate Set", menuName = "Kitchen/Crate Set")]
	public class CrateSet : GameDataObject
	{
		public List<Appliance> Options;

		protected override void InitialiseDefaults()
		{
			Options = new List<Appliance>();
		}

		public override void SetupForGame()
		{
			if (Options == null)
			{
				Options = new List<Appliance>();
			}
		}
	}
}
