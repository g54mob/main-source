using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.HologramVFX
{
	[CreateAssetMenu(menuName = "Factory/FactoryObjectViews/HologramVFXSettings", fileName = "HologramVFXSettings", order = 0)]
	public class HologramVFXSettings : ScriptableObject
	{
		public float AnimateTime = 0.275f;

		[Space]
		[ColorUsage(false, true)]
		public Color ValidOutlineColor = Color.white;

		[ColorUsage(false, true)]
		public Color ValidHighPeakColor;

		[ColorUsage(false, true)]
		public Color ValidLowPeakColor;

		[Space]
		[ColorUsage(false, true)]
		public Color InvalidOutlineColor = Color.white;

		[ColorUsage(false, true)]
		public Color InvalidHighPeakColor;

		[ColorUsage(false, true)]
		public Color InvalidLowPeakColor;
	}
}
