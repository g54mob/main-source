using System;
using UnityEngine;

namespace TH20
{
	public class SirenAnimatorComponent : MonoBehaviour
	{
		[SerializeField]
		private Renderer _sirenRenderer;

		[SerializeField]
		private Light _light;

		[Header("Default")]
		[SerializeField]
		private float _flashSpeed = 1f;

		[SerializeField]
		private float _lightIntensity = 3f;

		[SerializeField]
		private float _emissive = 1f;

		[SerializeField]
		private Color _emergencyColor0 = Color.red;

		[SerializeField]
		private Color _emergencyColor1 = Color.blue;

		[Header("Patient Cured")]
		[SerializeField]
		private Color _curedColor = Color.green;

		[SerializeField]
		private float _cureEmissive = 1f;

		[Space]
		[SerializeField]
		private Color _deathColor = Color.red;

		[SerializeField]
		private Color _ineffectiveColor = Color.yellow;

		[Header("Flicker")]
		[SerializeField]
		private float _flickerSpeed = 5f;

		[SerializeField]
		private float _flickerExp = 5f;

		[SerializeField]
		private float _flickerStep = 5f;

		private float _time;

		private Patient _patient;

		private Material _sirenLightMaterial;

		private MaterialPropertyBlock _propertyBlock;

		public void AssignPatient(Patient patient)
		{
			_patient = patient;
		}

		protected void Start()
		{
			_time = UnityEngine.Random.Range(0f, _flashSpeed);
			_sirenLightMaterial = _sirenRenderer.materials[0];
		}

		private void SetSirenColor(Color color, float emissive, float lightIntensity, float amplitude)
		{
			_light.color = color;
			_light.intensity = lightIntensity * amplitude;
			TH20Standard.SetEmissiveColor(_sirenLightMaterial, color * emissive * amplitude);
			_sirenLightMaterial.color = color;
		}

		protected void Update()
		{
			_time += Time.deltaTime;
			if (_patient != null)
			{
				switch (_patient.TreatmentOutcome)
				{
				case Treatment.Outcome.Cured:
					SetSirenColor(_curedColor, _cureEmissive, _lightIntensity, 1f);
					return;
				case Treatment.Outcome.Death:
					SetSirenColor(_deathColor, _emissive, _lightIntensity, 1f);
					return;
				case Treatment.Outcome.Ineffective:
					SetSirenColor(_ineffectiveColor, _emissive, _lightIntensity, 1f);
					return;
				}
			}
			float num = Mathf.Sin(_flashSpeed * _time * (float)Math.PI);
			float amplitude = Mathf.Abs(num);
			if ((double)(0.5f * (num + 1f)) < 0.5)
			{
				SetSirenColor(_emergencyColor0, _emissive, _lightIntensity, amplitude);
			}
			else
			{
				SetSirenColor(_emergencyColor1, _emissive, _lightIntensity, amplitude);
			}
		}
	}
}
