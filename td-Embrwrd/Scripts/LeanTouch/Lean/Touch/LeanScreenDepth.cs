using System;
using UnityEngine;

namespace Lean.Touch
{
	[Serializable]
	public struct LeanScreenDepth
	{
		public enum ConversionType
		{
			FixedDistance = 0,
			DepthIntercept = 1,
			PhysicsRaycast = 2,
			PlaneIntercept = 3,
			PathClosest = 4,
			AutoDistance = 5,
			HeightIntercept = 6
		}

		public ConversionType Conversion;

		public Camera Camera;

		public UnityEngine.Object Object;

		public LayerMask Layers;

		public float Distance;

		public static Vector3 LastWorldNormal;

		private static readonly RaycastHit[] hits;

		public LeanScreenDepth(ConversionType newConversion, int newLayers = -5, float newDistance = 0f)
		{
			Conversion = default(ConversionType);
			Camera = null;
			Object = null;
			Layers = default(LayerMask);
			Distance = 0f;
		}

		public Vector3 Convert(Vector2 screenPoint, GameObject gameObject = null, Transform ignore = null)
		{
			return default(Vector3);
		}

		public Vector3 ConvertDelta(Vector2 lastScreenPoint, Vector2 screenPoint, GameObject gameObject = null, Transform ignore = null)
		{
			return default(Vector3);
		}

		public bool TryConvert(ref Vector3 position, Vector2 screenPoint, GameObject gameObject = null, Transform ignore = null)
		{
			return false;
		}

		private bool Exists<T>(GameObject gameObject, ref T instance) where T : UnityEngine.Object
		{
			return false;
		}

		private static bool IsChildOf(Transform current, Transform target)
		{
			return false;
		}
	}
}
