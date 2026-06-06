using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Collider))]
	public class Slider3D : MonoBehaviour
	{
		public enum SliderAxis
		{
			Vertical = 0,
			Horizontal = 1
		}

		[Header("Configuration")]
		[SerializeField]
		private SliderAxis axis;

		[SerializeField]
		private float range;

		[Header("State")]
		[SerializeField]
		[Range(0f, 1f)]
		private float value;

		private Plane dragPlane;

		private Vector3 dragStartWorld;

		private float dragStartValue;

		private bool isDragging;

		private Collider cachedCollider;

		public float Value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event Action<float> OnValueChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdatePosition()
		{
		}

		public void SetValueWithoutNotify(float normalized)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
