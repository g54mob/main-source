using UnityEngine;

namespace UI.ThreeDimensional
{
	public class DragRotateUIObject3D : MonoBehaviour
	{
		public float RotationSpeed;

		public bool RotateX;

		public bool InvertX;

		public bool RotateY;

		public bool InvertY;

		public bool UseInertia;

		public float SlowSpeed;

		private UIObject3D UIObject3D;

		private bool beingDragged;

		private Vector3 speed;

		private Vector3 averageSpeed;

		private Vector2 lastMousePosition;

		private int _xMultiplier => 0;

		private int _yMultiplier => 0;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void SetupEvents()
		{
		}
	}
}
