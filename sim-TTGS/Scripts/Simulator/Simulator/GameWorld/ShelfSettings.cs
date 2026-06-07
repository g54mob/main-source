using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Shop/Shelves", Scope.Project)]
	public class ShelfSettings : CustomSettings<ShelfSettings>
	{
		[Header("Shelf Interactions")]
		[SerializeField]
		private float m_holdInteractionSpeed = 0.25f;

		public static float HoldInteractionSpeed => CustomSettings<ShelfSettings>.I.m_holdInteractionSpeed;
	}
}
