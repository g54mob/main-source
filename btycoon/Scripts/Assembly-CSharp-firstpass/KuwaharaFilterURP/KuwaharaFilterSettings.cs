using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace KuwaharaFilterURP
{
	[Serializable]
	public class KuwaharaFilterSettings
	{
		[Range(0f, 10f)]
		[Tooltip("Warning: A value has an impact on performance")]
		public int GaussRadius = 5;

		[Range(0.1f, 10f)]
		public float GaussSigma = 8f;

		[Range(0f, 10f)]
		public float KuwaharaAlpha = 1f;

		[Range(0f, 10f)]
		[Tooltip("Warning: A value has aт impact on performance")]
		public int KuwaharaRadius = 2;

		[Range(1f, 20f)]
		public int KuwaharaQ = 8;

		[Range(0.1f, 1f)]
		[Tooltip("Warning: A value has aт impact on performance")]
		public float ResolutionScale = 1f;

		public RenderPassEvent RenderPassEvent = RenderPassEvent.AfterRendering;
	}
}
