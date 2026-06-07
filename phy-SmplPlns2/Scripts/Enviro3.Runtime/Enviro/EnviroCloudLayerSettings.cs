using System;
using UnityEngine;

namespace Enviro
{
	[Serializable]
	public class EnviroCloudLayerSettings
	{
		[Range(-1f, 1f)]
		public float cloudsWindDirectionXModifier = 1f;

		[Range(-1f, 1f)]
		public float cloudsWindDirectionYModifier = 1f;

		[Range(-0.1f, 0.1f)]
		public float windSpeedModifier = 1f;

		[Range(0f, 0.1f)]
		public float windUpwards = 1f;

		[Range(-1f, 1f)]
		public float coverage = 1f;

		public float worleyFreq2 = 4f;

		public float worleyFreq1 = 1f;

		[Range(0f, 1f)]
		public float dilateCoverage = 0.5f;

		[Range(0f, 1f)]
		public float dilateType = 0.5f;

		[Range(0f, 1f)]
		public float cloudsTypeModifier = 0.5f;

		public Vector2 locationOffset;

		public float bottomCloudsHeight = 2000f;

		public float topCloudsHeight = 8000f;

		[Range(0f, 2f)]
		public float density = 0.3f;

		[Range(0f, 2f)]
		public float densitySmoothness = 1f;

		[Range(0f, 2f)]
		public float scatteringIntensity = 1f;

		[Range(0f, 1f)]
		public float silverLiningSpread = 0.8f;

		[Range(0f, 1f)]
		public float powderIntensity = 0.5f;

		[Range(0f, 1f)]
		public float curlIntensity = 0.25f;

		[Range(0f, 0.25f)]
		public float lightStepModifier = 0.05f;

		[Range(0f, 2f)]
		public float lightAbsorbtion = 0.5f;

		[Range(0f, 1f)]
		public float multiScatteringA = 0.5f;

		[Range(0f, 1f)]
		public float multiScatteringB = 0.5f;

		[Range(0f, 1f)]
		public float multiScatteringC = 0.5f;

		public float baseNoiseUV = 15f;

		public float detailNoiseUV = 50f;

		[Range(0f, 1f)]
		public float baseErosionIntensity;

		[Range(0f, 1f)]
		public float detailErosionIntensity = 0.3f;

		[Range(0f, 1f)]
		public float anvilBias;
	}
}
