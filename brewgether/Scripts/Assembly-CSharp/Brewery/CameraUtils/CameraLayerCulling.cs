using System;
using UnityEngine;

namespace Brewery.CameraUtils
{
	[RequireComponent(typeof(Camera))]
	public class CameraLayerCulling : MonoBehaviour
	{
		[Serializable]
		public class LayerCullDistance
		{
			[Tooltip("Layer to apply custom cull distance to")]
			public string layerName;

			[Tooltip("Objects on this layer beyond this distance won't render")]
			[Range(10f, 1000f)]
			public float cullDistance;
		}

		[Header("Layer Culling Settings")]
		[Tooltip("Define custom cull distances per layer. Layers not listed use camera's far clip plane.")]
		[SerializeField]
		private LayerCullDistance[] layerCullDistances;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugInfo;

		private Camera _camera;

		private float[] _cullDistances;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnValidate()
		{
		}

		public void ApplyCullingDistances()
		{
		}

		public void SetLayerCullDistance(string layerName, float distance)
		{
		}

		public void SetLayerCullDistance(int layerIndex, float distance)
		{
		}

		public float GetLayerCullDistance(string layerName)
		{
			return 0f;
		}
	}
}
