using UnityEngine;

namespace Brewery.Controls3D
{
	public class ProgressBar3D : MonoBehaviour
	{
		[Header("Fill")]
		[Tooltip("The child GO that scales on Y to show progress")]
		[SerializeField]
		private Transform fill;

		[Header("Scale Range")]
		[Tooltip("Fill Y scale when progress = 0")]
		[SerializeField]
		private float minScaleY;

		[Tooltip("Fill Y scale when progress = 1")]
		[SerializeField]
		private float maxScaleY;

		[Header("Smooth")]
		[Tooltip("0 = instant. Higher = slower smooth follow (seconds to ~reach target).")]
		[SerializeField]
		private float smoothTime;

		private float value;

		private float displayValue;

		private float smoothVelocity;

		public float Value => 0f;

		public float DisplayValue => 0f;

		public Transform Fill => null;

		public float MinScaleY => 0f;

		public float MaxScaleY => 0f;

		public void SetValue(float normalized)
		{
		}

		public void SetValueImmediate(float normalized)
		{
		}

		private void Update()
		{
		}

		private void ApplyFill()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
