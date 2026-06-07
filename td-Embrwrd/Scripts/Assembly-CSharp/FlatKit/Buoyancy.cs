using UnityEngine;

namespace FlatKit
{
	public class Buoyancy : MonoBehaviour
	{
		[Tooltip("The object that contains a Water material.")]
		public Transform water;

		[Space]
		[Tooltip("Range of probing wave height for buoyancy rotation.")]
		public float size;

		[Tooltip("Max height of buoyancy going up and down.")]
		public float amplitude;

		[Tooltip("Optionally provide a separate material to get the wave parameters.")]
		[Space]
		public Material overrideWaterMaterial;

		private Material _material;

		private float _speed;

		private float _amplitude;

		private float _frequency;

		private float _direction;

		private Vector3 _originalPosition;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private Vector2 GradientNoiseDir(Vector2 p)
		{
			return default(Vector2);
		}

		private float GradientNoise(Vector2 p)
		{
			return 0f;
		}

		private Vector3 GetNormalWS(Vector3 positionOS)
		{
			return default(Vector3);
		}

		private float SineWave(Vector3 positionOS, float offset)
		{
			return 0f;
		}

		private float GetHeightOS(Vector3 positionOS)
		{
			return 0f;
		}
	}
}
