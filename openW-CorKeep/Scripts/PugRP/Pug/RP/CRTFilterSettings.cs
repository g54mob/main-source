using System;
using UnityEngine;

namespace Pug.RP
{
	[Serializable]
	public struct CRTFilterSettings
	{
		public CRTFilterMode mode;

		public CRTSimulationStyle simulationStyle;

		[Min(1f)]
		public float HDRExposure;

		public CRTShadowStyle shadowStyle;

		public CRTShadowDirection shadowDirection;

		public CRTMaskAlignment maskAlignment;

		public bool shadowGradients;

		public bool stablePixels;

		public static CRTFilterSettings baseSettings => new CRTFilterSettings
		{
			mode = CRTFilterMode.Off,
			simulationStyle = CRTSimulationStyle.Soft,
			HDRExposure = 1f,
			shadowStyle = CRTShadowStyle.Mask,
			shadowDirection = CRTShadowDirection.Vertical,
			maskAlignment = CRTMaskAlignment.Uneven,
			shadowGradients = true,
			stablePixels = true
		};

		public CRTFilterSettings CopyFromOther(CRTFilterSettings other)
		{
			return new CRTFilterSettings
			{
				mode = other.mode,
				simulationStyle = other.simulationStyle,
				HDRExposure = other.HDRExposure,
				shadowStyle = other.shadowStyle,
				shadowDirection = other.shadowDirection,
				maskAlignment = other.maskAlignment,
				shadowGradients = other.shadowGradients,
				stablePixels = other.stablePixels
			};
		}
	}
}
