using System;
using UnityEngine;

namespace TH20
{
	public class ClownClinicSpotlightsComponent : EntityTickComponent
	{
		[SerializeField]
		private float _lightHeight;

		[SerializeField]
		private float _lightRange;

		[SerializeField]
		private float _lightIntensity;

		[SerializeField]
		private float _spotAngle;

		[SerializeField]
		private float _maxLightRotationSpeed;

		[SerializeField]
		private float _doctorSpotlightIdleRadius;

		[SerializeField]
		private float _doctorSpotlightIdleSpeed;

		[SerializeField]
		private float _patientSpotlightIdleRadius;

		[SerializeField]
		private float _patientSpotlightIdleSpeed;

		[DontSave]
		private RoomItem _cureMachine;

		[DontSave]
		private ClippableLight _doctorSpotlight;

		[DontSave]
		private ClippableLight _patientSpotlight;

		private float _doctorCurrentIdleLightAngle;

		private float _patientCurrentIdleLightAngle;

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
		}

		protected override Type ValidEntityType()
		{
			return typeof(Room);
		}

		public override void Tick()
		{
			Room owner = GetOwner<Room>();
			RoomItem firstItemOfType = owner.GetFirstItemOfType(RoomItemDefinition.Type.Machine);
			if (firstItemOfType == null)
			{
				if (_doctorSpotlight != null)
				{
					_doctorSpotlight.enabled = false;
				}
				if (_patientSpotlight != null)
				{
					_patientSpotlight.enabled = false;
				}
				return;
			}
			if (_doctorSpotlight != null)
			{
				_doctorSpotlight.enabled = true;
			}
			if (_patientSpotlight != null)
			{
				_patientSpotlight.enabled = true;
			}
			if (_doctorSpotlight == null)
			{
				_doctorSpotlight = CreateClippableLight();
			}
			if (_patientSpotlight == null)
			{
				_patientSpotlight = CreateClippableLight();
			}
			Character character = null;
			Character character2 = null;
			foreach (Character item in owner.CharactersUsing)
			{
				if (item is Patient)
				{
					character2 = item as Patient;
					break;
				}
			}
			foreach (Staff staffMember in owner.StaffMembers)
			{
				if (staffMember.Definition._type == StaffDefinition.Type.Nurse)
				{
					character = staffMember;
					break;
				}
			}
			if (character == null)
			{
				_doctorCurrentIdleLightAngle += Time.deltaTime * _doctorSpotlightIdleSpeed;
				_doctorCurrentIdleLightAngle = Mathf.Repeat(_doctorCurrentIdleLightAngle, (float)Math.PI * 2f);
				UpdateIdleLight(_doctorSpotlight, firstItemOfType.WorldPosition, _doctorCurrentIdleLightAngle);
			}
			else
			{
				Quaternion to = Quaternion.LookRotation((character.Position - _doctorSpotlight.transform.position).normalized, Vector3.forward);
				_doctorSpotlight.transform.rotation = Quaternion.RotateTowards(_doctorSpotlight.transform.rotation, to, _maxLightRotationSpeed * Time.deltaTime);
			}
			if (character2 == null)
			{
				_patientCurrentIdleLightAngle += Time.deltaTime * _patientSpotlightIdleSpeed;
				_patientCurrentIdleLightAngle = Mathf.Repeat(_patientCurrentIdleLightAngle, (float)Math.PI * 2f);
				UpdateIdleLight(_patientSpotlight, firstItemOfType.WorldPosition, _patientCurrentIdleLightAngle);
			}
			else
			{
				Quaternion to2 = Quaternion.LookRotation((character2.Position - _patientSpotlight.transform.position).normalized, Vector3.forward);
				_patientSpotlight.transform.rotation = Quaternion.RotateTowards(_patientSpotlight.transform.rotation, to2, _maxLightRotationSpeed * Time.deltaTime);
			}
		}

		private void UpdateIdleLight(ClippableLight clippableLight, Vector3 orbitCenter, float angle)
		{
			clippableLight.transform.position = orbitCenter + new Vector3(0f, _lightHeight, 0f);
			Quaternion to = Quaternion.LookRotation((orbitCenter + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * _patientSpotlightIdleRadius - clippableLight.transform.position).normalized, Vector3.forward);
			clippableLight.transform.rotation = Quaternion.RotateTowards(clippableLight.transform.rotation, to, _maxLightRotationSpeed * Time.deltaTime);
		}

		private ClippableLight CreateClippableLight()
		{
			Room owner = GetOwner<Room>();
			GameObject gameObject = new GameObject("Clown Clinic - Spotlight");
			ClippableLight clippableLight = gameObject.AddComponent<ClippableLight>();
			clippableLight.Type = ClippableLight.LightType.Spot;
			clippableLight.Range = _lightRange;
			clippableLight.Intensity = _lightIntensity;
			clippableLight.SpotAngle = _spotAngle;
			gameObject.transform.SetParent(owner.FloorPlanVisual.GameObject.transform);
			base.Level.VisualManager.RoomLightingManager.RegisterClippableLight(clippableLight);
			return clippableLight;
		}

		public override void Destroy()
		{
			if (_doctorSpotlight != null)
			{
				UnityEngine.Object.Destroy(_doctorSpotlight.gameObject);
				_doctorSpotlight = null;
			}
			if (_patientSpotlight != null)
			{
				UnityEngine.Object.Destroy(_patientSpotlight.gameObject);
				_patientSpotlight = null;
			}
			base.Destroy();
		}
	}
}
