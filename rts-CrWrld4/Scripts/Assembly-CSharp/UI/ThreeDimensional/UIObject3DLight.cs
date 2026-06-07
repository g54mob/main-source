using System;
using UnityEngine;

namespace UI.ThreeDimensional
{
	[ExecuteInEditMode]
	public class UIObject3DLight : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _LightPosition;

		[SerializeField]
		private Color _LightColor;

		[SerializeField]
		private float _LightIntensity;

		[NonSerialized]
		private UIObject3D UIObject3D;

		[NonSerialized]
		private Light _lightObject;

		public Vector3 LightPosition
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Color LightColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float LightIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private Light lightObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void UpdateLightEvent()
		{
		}

		public void UpdateLight(bool scheduleRender = false)
		{
		}

		private void SpawnLight()
		{
		}

		private void SetLightPosition(bool scheduleRender = true)
		{
		}

		private void SetLightProperties(bool scheduleRender = true)
		{
		}

		private void ScheduleRender()
		{
		}
	}
}
