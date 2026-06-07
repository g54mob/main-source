using System;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtFloatingObject : MonoBehaviour
	{
		public UnityEvent OnSnap;

		public Action<double> OnDistance;

		[SerializeField]
		private SgtFloatingPoint point;

		[SerializeField]
		private Vector3 expectedPosition;

		[SerializeField]
		private bool expectedPositionSet;

		public SgtFloatingPoint Point
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void RegisterPoint()
		{
		}

		public void UnregisterPoint()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void OnDisable()
		{
		}

		private void CheckForPositionChanges()
		{
		}

		private void CameraSnap(SgtFloatingCamera floatingCamera, Vector3 delta)
		{
		}

		private void UpdatePosition()
		{
		}

		private void UpdatePositionNow(SgtFloatingCamera camera)
		{
		}
	}
}
