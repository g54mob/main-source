using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.ThreeDimensional
{
	public class RotateUIObject3D : MonoBehaviour
	{
		public enum eRotationMode
		{
			Constant = 0,
			WhenMouseIsOver = 1,
			WhenMouseIsOverThenSnapBack = 2
		}

		public eRotationMode RotationMode;

		public bool RotateX;

		public float RotateXSpeed;

		public bool RotateY;

		public float RotateYSpeed;

		public bool RotateZ;

		public float RotateZSpeed;

		public float snapbackTime;

		private UIObject3D UIObject3D;

		private bool mouseIsOver;

		private Vector3 initialRotation;

		private EventTrigger _eventTrigger;

		private float timeSinceLastUpdate;

		private EventTrigger eventTrigger => null;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void UpdateRotation()
		{
		}

		private void SetupEvents()
		{
		}

		private void OnPointerEnter()
		{
		}

		private void OnPointerExit()
		{
		}

		private IEnumerator SnapBack(float time)
		{
			return null;
		}

		private void OnValidate()
		{
		}
	}
}
