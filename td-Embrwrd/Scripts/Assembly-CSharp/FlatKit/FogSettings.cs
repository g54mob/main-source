using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FlatKit
{
	[CreateAssetMenu(fileName = "FogSettings", menuName = "FlatKit/Fog Settings")]
	public class FogSettings : ScriptableObject
	{
		[Header("Distance Fog")]
		public bool useDistance;

		public Gradient distanceGradient;

		public float near;

		public float far;

		[Range(0f, 1f)]
		public float distanceFogIntensity;

		public bool useDistanceFogOnSky;

		[Header("Height Fog")]
		[Space]
		public bool useHeight;

		public Gradient heightGradient;

		public float low;

		public float high;

		[Range(0f, 1f)]
		public float heightFogIntensity;

		public bool useHeightFogOnSky;

		[Range(0f, 1f)]
		[Space]
		[Header("Blending")]
		public float distanceHeightBlend;

		[Space]
		[Header("Advanced settings")]
		[Tooltip("The render stage at which the effect is applied. To exclude transparent objects, like water or UI elements, set this to \"Before Transparent\".")]
		public RenderPassEvent renderEvent;

		private void OnValidate()
		{
		}
	}
}
