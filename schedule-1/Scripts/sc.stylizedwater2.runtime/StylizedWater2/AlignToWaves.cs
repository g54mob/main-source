using System.Collections.Generic;
using UnityEngine;

namespace StylizedWater2
{
	[AddComponentMenu("Stylized Water 2/Align Transform To Waves")]
	[ExecuteInEditMode]
	public class AlignToWaves : MonoBehaviour
	{
		public enum WaterLevelSource
		{
			FixedValue = 0,
			WaterObject = 1
		}

		[Tooltip("This reference is required to grab the wave distance and height values")]
		public WaterObject waterObject;

		[Tooltip("Automatically find the Water Object below of above the Transform's position. This is slower than assigning a specific Water Object directly.")]
		public bool autoFind;

		[Tooltip("Only enable if the material's wave parameters are being changed in realtime, this has some performance overhead.\n\nIn edit-mode, the wave parameters are always fetched, so changes are directly visible")]
		public bool dynamicMaterial;

		[Tooltip("Configure what should be used to set the base water level. Relative wave height is added to this value")]
		public WaterLevelSource waterLevelSource;

		public float waterLevel;

		[Tooltip("You can assign a child mesh object here. When assigned, the sample points will rotate/scale with the transform, instead of transform the component is attached to.")]
		public Transform childTransform;

		public float heightOffset;

		[Min(0f)]
		[Tooltip("Controls how strongly the transform should rotate to align with the wave curvature")]
		public float rollAmount;

		public List<Vector3> samples;

		private Vector3 normal;

		private float height;

		private float m_waterLevel;

		public static bool Disable;

		public void FixedUpdate()
		{
		}

		private void ApplyTransform()
		{
		}

		public Vector3 ConvertToWorldSpace(Vector3 position)
		{
			return default(Vector3);
		}

		public Vector3 ConvertToLocalSpace(Vector3 position)
		{
			return default(Vector3);
		}
	}
}
