using JUTPSEditor.JUHeader;
using UnityEngine;

namespace JUTPS.VehicleSystem
{
	[ExecuteInEditMode]
	[AddComponentMenu("JU TPS/Vehicle System/Motorcycle Suspension")]
	public class MotorcycleSuspensionScaler : MonoBehaviour
	{
		[JUHeader("Target")]
		public Transform WheelTarget;

		[JUHeader("Scaling/Streching Suspension")]
		[Space(10f)]
		public bool Scale = true;

		public float LenghtOffset;

		public float MaxDistance;

		[JUHeader("Suspension Direction Options")]
		[Space(10f)]
		public bool LookAt = true;

		public bool InvertLookAt;

		public float HeightOffset;

		[JUHeader("Fix Wheel VISUAL Position")]
		[Space(10f)]
		public WheelCollider WheelColliderTarget;

		public Transform HandleBarForwardDirection;

		public float Offset = 0.1f;

		public bool MoveSuspension;

		public float SuspensionOfsset;

		public float Lenght;

		private void LateUpdate()
		{
			if (!(WheelTarget != null))
			{
				return;
			}
			if (LookAt)
			{
				if (InvertLookAt)
				{
					base.transform.rotation = Quaternion.LookRotation(WheelTarget.position - base.transform.position + base.transform.up * HeightOffset, base.transform.parent.up);
				}
				else
				{
					base.transform.rotation = Quaternion.LookRotation(base.transform.position - WheelTarget.position - base.transform.up * HeightOffset, base.transform.parent.up);
				}
				Vector3 localEulerAngles = base.transform.localEulerAngles;
				localEulerAngles.y = 0f;
				base.transform.localEulerAngles = localEulerAngles;
			}
			if (Scale)
			{
				float num = Vector3.Distance(base.transform.position, WheelTarget.position);
				if (MaxDistance == 0f || num * LenghtOffset < MaxDistance)
				{
					base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.y, num * LenghtOffset);
				}
			}
			if (WheelColliderTarget != null && HandleBarForwardDirection != null)
			{
				float num2 = Vector3.Distance(HandleBarForwardDirection.position, WheelTarget.position);
				WheelColliderTarget.GetWorldPose(out var pos, out var _);
				if (MoveSuspension)
				{
					WheelTarget.transform.position = pos - HandleBarForwardDirection.forward * (num2 * Lenght) + HandleBarForwardDirection.forward * Offset;
					base.transform.position = WheelTarget.transform.position + base.transform.forward * SuspensionOfsset;
				}
				else
				{
					WheelTarget.transform.position = pos - HandleBarForwardDirection.forward * Offset * base.transform.localScale.z + HandleBarForwardDirection.forward * Offset;
				}
			}
		}

		private void OnDrawGizmos()
		{
			if (WheelColliderTarget != null && HandleBarForwardDirection != null)
			{
				Gizmos.DrawLine(WheelTarget.transform.position, WheelTarget.transform.position + HandleBarForwardDirection.forward * Offset * base.transform.localScale.z);
				Gizmos.DrawSphere(WheelTarget.transform.position, 0.02f);
				Gizmos.DrawSphere(WheelTarget.transform.position + HandleBarForwardDirection.forward * Offset * base.transform.localScale.z, 0.02f);
			}
		}
	}
}
