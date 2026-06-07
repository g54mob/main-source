using UnityEngine;

namespace IL3DN
{
	[ExecuteInEditMode]
	public class IL3DN_Wind : MonoBehaviour
	{
		public Texture2D NoiseTexture;

		public bool Wiggle = true;

		public bool Wind = true;

		[Range(0f, 1f)]
		public float WindStrength = 0.5f;

		[Range(0f, 1f)]
		public float WindSpeed = 0.2f;

		[Range(0f, 1f)]
		public float WindTurbulence = 0.5f;

		[Range(0f, 1f)]
		public float LeavesWiggle = 0.5f;

		[Range(0f, 1f)]
		public float GrassWiggle = 0.5f;

		private float WindGizmo = 0.5f;

		private void Update()
		{
			if (Wiggle)
			{
				Shader.EnableKeyword("_WIGGLE_ON");
			}
			else
			{
				Shader.DisableKeyword("_WIGGLE_ON");
			}
			if (Wind)
			{
				Shader.EnableKeyword("_WIND_ON");
			}
			else
			{
				Shader.DisableKeyword("_WIND_ON");
			}
			Shader.SetGlobalTexture("NoiseTextureFloat", NoiseTexture);
			Shader.SetGlobalVector("WindDirection", base.transform.rotation * Vector3.back);
			Shader.SetGlobalFloat("WindStrengthFloat", WindStrength);
			Shader.SetGlobalFloat("WindSpeedFloat", WindSpeed);
			Shader.SetGlobalFloat("WindTurbulenceFloat", WindTurbulence);
			Shader.SetGlobalFloat("LeavesWiggleFloat", LeavesWiggle);
			Shader.SetGlobalFloat("GrassWiggleFloat", GrassWiggle);
		}

		private void OnDrawGizmos()
		{
			_ = (base.transform.position + base.transform.forward).normalized;
			Gizmos.color = Color.green;
			Vector3 up = base.transform.up;
			Vector3 right = base.transform.right;
			Vector3 vector = base.transform.position + base.transform.forward * (WindGizmo * 5f);
			Vector3 vector2 = base.transform.position + base.transform.forward * (WindGizmo * 2.5f);
			Vector3 vector3 = base.transform.position + base.transform.forward * (WindGizmo * 0f);
			float windGizmo = WindGizmo;
			Vector3 vector4 = base.transform.forward * WindGizmo;
			Gizmos.DrawLine(vector3, vector3 - vector4 + up * windGizmo);
			Gizmos.DrawLine(vector3, vector3 - vector4 - up * windGizmo);
			Gizmos.DrawLine(vector3, vector3 - vector4 + right * windGizmo);
			Gizmos.DrawLine(vector3, vector3 - vector4 - right * windGizmo);
			Gizmos.DrawLine(vector3, vector3 - vector4 * 2f);
			Gizmos.DrawLine(vector2, vector2 - vector4 + up * windGizmo);
			Gizmos.DrawLine(vector2, vector2 - vector4 - up * windGizmo);
			Gizmos.DrawLine(vector2, vector2 - vector4 + right * windGizmo);
			Gizmos.DrawLine(vector2, vector2 - vector4 - right * windGizmo);
			Gizmos.DrawLine(vector2, vector2 - vector4 * 2f);
			Gizmos.DrawLine(vector, vector - vector4 + up * windGizmo);
			Gizmos.DrawLine(vector, vector - vector4 - up * windGizmo);
			Gizmos.DrawLine(vector, vector - vector4 + right * windGizmo);
			Gizmos.DrawLine(vector, vector - vector4 - right * windGizmo);
			Gizmos.DrawLine(vector, vector - vector4 * 2f);
		}
	}
}
