using System;
using UnityEngine;

namespace Pug.RP
{
	[Serializable]
	public class SSAOSettings
	{
		[Min(0.01f)]
		public float radius = 1f;

		[Tooltip("Scale the sample radius with distance to the camera.")]
		public bool screenSpaceRadius;

		[Range(0f, 1f)]
		[Tooltip("Focuses samples towards the normal direction in order to hide low-tessellation artifacts.")]
		public float bias = 0.1f;

		[Range(0f, 1f)]
		[Tooltip("Focuses samples towards the screen. Useful for \"flat\" sidescroller perspectives.")]
		public float screenBias;

		[Range(0f, 8f)]
		public float strength = 1f;

		[Range(0f, 1f)]
		public float colorize = 0.75f;

		[Min(0f)]
		public float directionality = 4f;

		[Space(10f)]
		[Range(4f, 64f)]
		public int sampleCount = 32;

		public bool noise = true;

		[Tooltip("Optimize the occlusion gathering by calculating different directions in passes, leading to better cache coherency.")]
		public bool cacheOptimized = true;

		[Tooltip("Prevent bright screen edges by normalizing occlusion by the number of samples that fell within the screen. Can make undersampling more obvious.")]
		public bool normalizeEdges = true;

		[Space(10f)]
		public bool temporalFilter;

		[Range(0f, 0.99f)]
		public float temporalWeight = 0.9f;

		[Space(10f)]
		[Tooltip("Use a depth-aware blur to smoothen the result.")]
		public bool blurFilter = true;

		[Range(1f, 8f)]
		public int blurWidth = 2;

		[Range(1f, 8f)]
		public int blurPasses = 1;

		[Range(0f, 1f)]
		public float blurSharpness = 0.9f;
	}
}
