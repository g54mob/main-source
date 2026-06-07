using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Clipping", Scope.Project)]
	public class ClippingObjectSettings : CustomSettings<ClippingObjectSettings>
	{
		[SerializeField]
		[Layer]
		private int m_noClippingLayer;

		[SerializeField]
		[Layer]
		private int m_defaultLayer;

		public static int NoClippingLayer => CustomSettings<ClippingObjectSettings>.I.m_noClippingLayer;

		public static int DefaultLayer => CustomSettings<ClippingObjectSettings>.I.m_defaultLayer;
	}
}
