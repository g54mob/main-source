using JUTPS.JUInputSystem;
using JUTPSActions;
using UnityEngine;

namespace JUTPS.ActionScripts
{
	[AddComponentMenu("JU TPS/Third Person System/Additionals/Aim On Mouse Position")]
	public class AimOnMousePosition : JUTPSAction
	{
		[HideInInspector]
		public static Vector3 AimPosition;

		[Header("Settings")]
		public bool Enabled = true;

		public float NormalOffset = 0.1f;

		public bool PreventResetingAimPosition;

		[Header("Two Dimensional Settings")]
		public bool TwoDimensional;

		private void Update()
		{
			if (!Enabled || cam == null)
			{
				AimPosition = Vector3.zero;
				TPSCharacter.LookAtPosition = AimPosition;
				return;
			}
			Vector2 mousePosition = JUInput.GetMousePosition();
			if (TwoDimensional)
			{
				Ray ray = cam.ScreenPointToRay(mousePosition);
				Vector3 position = base.transform.position;
				position.y = TPSCharacter.HumanoidSpine.position.y;
				Vector3 vector = ray.origin + ray.direction * Vector3.Distance(position, ray.origin);
				vector.z = base.transform.position.z;
				Vector3 b = vector;
				b.y = position.y;
				float t = Vector3.Distance(position, b);
				vector.z = Mathf.Lerp(TPSCharacter.transform.position.z - 3f, position.z, t);
				AimPosition = Vector3.Lerp(AimPosition, vector, 10f * Time.deltaTime);
				Debug.DrawLine(position, AimPosition, Color.red);
			}
			else
			{
				Physics.Raycast(cam.ScreenPointToRay(mousePosition), out var hitInfo, (int)((TPSCharacter.MyPivotCamera == null) ? default(LayerMask) : TPSCharacter.MyPivotCamera.CrosshairRaycastLayerMask));
				if (PreventResetingAimPosition)
				{
					if (hitInfo.point != Vector3.zero)
					{
						AimPosition = Vector3.Lerp(AimPosition, hitInfo.point + hitInfo.normal * NormalOffset, 10f * Time.deltaTime);
					}
				}
				else
				{
					AimPosition = Vector3.Lerp(AimPosition, hitInfo.point + hitInfo.normal * NormalOffset, 10f * Time.deltaTime);
					if (hitInfo.point == Vector3.zero)
					{
						AimPosition = Vector3.zero;
					}
				}
			}
			TPSCharacter.LookAtPosition = AimPosition;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			if (TwoDimensional)
			{
				Gizmos.DrawWireCube(AimPosition, new Vector3(0.1f, 0.1f, 0f));
				Gizmos.DrawWireCube(AimPosition, new Vector3(0.5f, 0.5f, 0f));
			}
			else
			{
				Gizmos.DrawWireCube(AimPosition, new Vector3(0.1f, 0f, 0.1f));
				Gizmos.DrawWireCube(AimPosition, new Vector3(0.5f, 0f, 0.5f));
			}
		}
	}
}
