using UnityEngine;

namespace IL3DN
{
	[ExecuteInEditMode]
	public class IL3DN_Wind : MonoBehaviour
	{
		private float WindGizmo = 0.5f;

		private void Update()
		{
			Shader.SetGlobalVector("WindDirection", base.transform.rotation * Vector3.back);
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
