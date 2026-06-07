using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Shop/Products", Scope.Project)]
	public class ProductsSettings : CustomSettings<ProductsSettings>
	{
		[Header("Stacking")]
		[SerializeField]
		private float m_stackingAnimDuration = 0.2f;

		public static float StackingAnimDuration => CustomSettings<ProductsSettings>.I.m_stackingAnimDuration;
	}
}
