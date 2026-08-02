using JUTPS.ActionScripts;
using JUTPS.ExtendedInverseKinematics;
using JUTPS.VehicleSystem;
using JUTPSActions;
using UnityEngine;

namespace JUTPS.FX
{
	[AddComponentMenu("JU TPS/FX/Driver Procedural Animation")]
	[RequireComponent(typeof(DriveVehicles))]
	public class ProceduralDrivingAnimation : JUTPSAction
	{
		private DriveVehicles DriveAbility;

		[Header("Settings")]
		public bool Enabled = true;

		public bool FootPlacer;

		private Transform LeftFootTargetPosition;

		private Transform RightFootTargetPosition;

		public LayerMask GroundLayer;

		[Header("Spine Lean")]
		[SerializeField]
		private bool SpineLean = true;

		[Range(0f, 1f)]
		[SerializeField]
		private float LeanDirection = 0.2f;

		[SerializeField]
		private BodyLeanInert.Axis ForwardLeanAxis;

		[SerializeField]
		private BodyLeanInert.Axis SidesLeanAxis = BodyLeanInert.Axis.Z;

		public bool InvertForwardLean;

		public bool InvertSideLean;

		private void Start()
		{
			DriveAbility = GetComponent<DriveVehicles>();
			LeftFootTargetPosition = new GameObject("LeftFootTargetPosition").transform;
			RightFootTargetPosition = new GameObject("RightFootTargetPosition").transform;
			LeftFootTargetPosition.hideFlags = HideFlags.HideInHierarchy;
			RightFootTargetPosition.hideFlags = HideFlags.HideInHierarchy;
			LeftFootTargetPosition.position = base.transform.position;
			RightFootTargetPosition.position = base.transform.position;
			LeftFootTargetPosition.parent = base.transform;
			RightFootTargetPosition.parent = base.transform;
		}

		private void OnAnimatorIK(int layerIndex)
		{
			if (Enabled && !(DriveAbility == null))
			{
				DoProceduralDrivingAnimation(DriveAbility.VehicleToDrive);
			}
		}

		protected virtual void DoProceduralDrivingAnimation(Vehicle Vehicle)
		{
			if (!TPSCharacter.IsDriving || Vehicle == null || TPSCharacter.IsRagdolled || Vehicle.InverseKinematicTargetPositions.LeftFootPositionIK == null || Vehicle.InverseKinematicTargetPositions.RightFootPositionIK == null || Vehicle.InverseKinematicTargetPositions.LeftHandPositionIK == null || Vehicle.InverseKinematicTargetPositions.RightHandPositionIK == null || Vehicle.InverseKinematicTargetPositions.PlayerLocation == null)
			{
				return;
			}
			float vehicleCurrentSpeed = Vehicle.GetVehicleCurrentSpeed();
			vehicleCurrentSpeed = Mathf.Clamp(vehicleCurrentSpeed, 0f, 15f);
			anim.SetLeftHandOn(Vehicle.InverseKinematicTargetPositions.LeftHandPositionIK, 1f);
			anim.SetRightHandOn(Vehicle.InverseKinematicTargetPositions.RightHandPositionIK, 1f);
			float num = 6f * Mathf.Clamp(Vehicle.GetSmoothedHorizontalMovement(), -1f, 0f) * vehicleCurrentSpeed / 20f;
			float num2 = 6f * Mathf.Clamp(Vehicle.GetSmoothedHorizontalMovement(), 0f, 1f) * vehicleCurrentSpeed / 20f;
			float num3 = 3f * Vehicle.AnimationWeights.HintMovementWeight;
			Vector3 hintAjust = Vector3.zero - Vector3.right * (num3 - num) + Vector3.forward * 10f;
			Vector3 hintAjust2 = Vector3.zero + Vector3.right * (num3 + num2) + Vector3.forward * 10f;
			if (FootPlacer && Vehicle.AnimationWeights.FootPlacement)
			{
				Vector3 position = Vehicle.InverseKinematicTargetPositions.RightFootPositionIK.position;
				Vector3 position2 = Vehicle.InverseKinematicTargetPositions.LeftFootPositionIK.position;
				Physics.Raycast(position2 + Vehicle.transform.forward * vehicleCurrentSpeed / 5f - Vehicle.transform.right * 0.2f, -Vehicle.transform.up, out var hitInfo, 0.8f, GroundLayer);
				Physics.Raycast(position + Vehicle.transform.forward * vehicleCurrentSpeed / 5f + Vehicle.transform.right * 0.2f, -Vehicle.transform.up, out var hitInfo2, 0.8f, GroundLayer);
				Vector3 a = (hitInfo.collider ? (hitInfo.point + hitInfo.normal * 0.15f) : position2);
				Vector3 a2 = (hitInfo2.collider ? (hitInfo2.point + hitInfo2.normal * 0.15f) : position);
				Vector3 position3 = Vector3.Lerp(a, position2, vehicleCurrentSpeed / 5f);
				Vector3 position4 = Vector3.Lerp(a2, position, vehicleCurrentSpeed / 5f);
				Quaternion rotation = Quaternion.Lerp(Quaternion.FromToRotation(LeftFootTargetPosition.up, hitInfo.normal) * LeftFootTargetPosition.rotation, Vehicle.InverseKinematicTargetPositions.LeftFootPositionIK.rotation, vehicleCurrentSpeed / 5f);
				Quaternion rotation2 = Quaternion.Lerp(Quaternion.FromToRotation(RightFootTargetPosition.up, hitInfo2.normal) * RightFootTargetPosition.rotation, Vehicle.InverseKinematicTargetPositions.RightFootPositionIK.rotation, vehicleCurrentSpeed / 5f);
				LeftFootTargetPosition.position = position3;
				LeftFootTargetPosition.rotation = rotation;
				RightFootTargetPosition.position = position4;
				RightFootTargetPosition.rotation = rotation2;
				anim.SetLeftFootOn(LeftFootTargetPosition.position, LeftFootTargetPosition.rotation, 1f, hintAjust, Vehicle.AnimationWeights.HintMovementWeight);
				anim.SetRightFootOn(Vehicle.InverseKinematicTargetPositions.RightFootPositionIK.position, RightFootTargetPosition.rotation, 1f, hintAjust2, Vehicle.AnimationWeights.HintMovementWeight);
			}
			else
			{
				anim.SetLeftFootOn(Vehicle.InverseKinematicTargetPositions.LeftFootPositionIK, 1f, hintAjust, Vehicle.AnimationWeights.HintMovementWeight);
				anim.SetRightFootOn(Vehicle.InverseKinematicTargetPositions.RightFootPositionIK, 1f, hintAjust2, Vehicle.AnimationWeights.HintMovementWeight);
			}
			if (SpineLean)
			{
				Vector3 position5 = base.transform.position + Vehicle.transform.forward * 10f + Vehicle.transform.up * 0.6f + Vehicle.transform.right * Vehicle.GetSmoothedHorizontalMovement() * 8f;
				anim.NormalLookAt(position5, Vehicle.AnimationWeights.LookAtDirectionWeight);
				float leanIntensity = (0f - Vehicle.GetSmoothedHorizontalMovement()) * (vehicleCurrentSpeed / 5f);
				float leanIntensity2 = Vehicle.GetSmoothedForwardMovement() * (vehicleCurrentSpeed / 4f);
				Vector3 direction = new Vector3(0f, 0f, 0f);
				switch (ForwardLeanAxis)
				{
				case BodyLeanInert.Axis.X:
					direction = (InvertForwardLean ? Vector3.left : Vector3.right);
					break;
				case BodyLeanInert.Axis.Y:
					direction = (InvertForwardLean ? Vector3.down : Vector3.up);
					break;
				case BodyLeanInert.Axis.Z:
					direction = (InvertForwardLean ? Vector3.back : Vector3.forward);
					break;
				}
				Vector3 b = new Vector3(0f, 0f, 0f);
				switch (SidesLeanAxis)
				{
				case BodyLeanInert.Axis.X:
					b = (InvertSideLean ? Vector3.left : Vector3.right);
					break;
				case BodyLeanInert.Axis.Y:
					b = (InvertSideLean ? Vector3.down : Vector3.up);
					break;
				case BodyLeanInert.Axis.Z:
					b = (InvertSideLean ? Vector3.back : Vector3.forward);
					break;
				}
				anim.SpineInclination(direction, leanIntensity2, Vehicle.AnimationWeights.FrontalLeanWeight);
				anim.SpineInclination(Vector3.Lerp(Vector3.up, b, LeanDirection), leanIntensity, Vehicle.AnimationWeights.SideLeanWeight);
			}
		}
	}
}
