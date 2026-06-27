using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Eclipse Profile", order = 361)]
	public class EclipseProfile : CozyProfile
	{
		[GradientUsage(true)]
		public Gradient skyZenithColor;

		[GradientUsage(true)]
		public Gradient skyHorizonColor;

		[GradientUsage(true)]
		public Gradient cloudColor;

		[GradientUsage(true)]
		public Gradient cloudHighlightColor;

		[GradientUsage(true)]
		public Gradient highAltitudeCloudColor;

		[GradientUsage(true)]
		public Gradient sunlightColor;

		[GradientUsage(true)]
		public Gradient moonlightColor;

		[GradientUsage(true)]
		public Gradient starColor;

		[GradientUsage(true)]
		public Gradient ambientLightHorizonColor;

		[GradientUsage(true)]
		public Gradient ambientLightZenithColor;

		public AnimationCurve ambientLightMultiplier;

		public AnimationCurve galaxyIntensity;

		[GradientUsage(true)]
		public Gradient fogColor1;

		[GradientUsage(true)]
		public Gradient fogColor2;

		[GradientUsage(true)]
		public Gradient fogColor3;

		[GradientUsage(true)]
		public Gradient fogColor4;

		[GradientUsage(true)]
		public Gradient fogColor5;

		[GradientUsage(true)]
		public Gradient fogFlareColor;

		[GradientUsage(true)]
		public Gradient fogMoonFlareColor;

		public AnimationCurve fogSmoothness;

		[GradientUsage(true)]
		public Gradient sunColor;

		public AnimationCurve sunFlareFalloff;

		[GradientUsage(true)]
		public Gradient sunFlareColor;

		public AnimationCurve moonFalloff;

		[GradientUsage(true)]
		public Gradient moonFlareColor;

		[GradientUsage(true)]
		public Gradient galaxy1Color;

		[GradientUsage(true)]
		public Gradient galaxy2Color;

		[GradientUsage(true)]
		public Gradient galaxy3Color;

		[GradientUsage(true)]
		public Gradient lightScatteringColor;

		public AnimationCurve fogLightFlareIntensity;

		public AnimationCurve fogLightFlareFalloff;

		[GradientUsage(true)]
		public Gradient cloudMoonColor;

		[GradientUsage(true)]
		public Gradient cloudTextureColor;
	}
}
