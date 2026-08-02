using System;
using JUTPS.FX;
using JUTPS.JUInputSystem;
using JUTPS.PhysicsScripts;
using JUTPS.VehicleSystem;
using JUTPSActions;
using UnityEngine;

namespace JUTPS.ActionScripts
{
	[AddComponentMenu("JU TPS/Third Person System/Actions/Drive Vehicles System")]
	public class DriveVehicles : JUTPSAction
	{
		private JUFootstep FootstepSoundsToDisable;

		private AdvancedRagdollController Ragdoller;

		[Header("Settings")]
		public Vehicle VehicleToDrive;

		public bool UseDefaultInputsOnVehicleInteraction = true;

		public bool CheckVehiclesByTrigger = true;

		public bool DriveSelectedVehicleOnStart;

		[Header("States")]
		public bool VehicleDrivableNearby;

		public bool IsDriving;

		public Action onEnterVehicle;

		public Action onExitVehicle;

		private void Start()
		{
			FootstepSoundsToDisable = GetComponent<JUFootstep>();
			Ragdoller = GetComponent<AdvancedRagdollController>();
			if (DriveSelectedVehicleOnStart && VehicleToDrive != null)
			{
				DriveVehicle(VehicleToDrive, base.gameObject);
			}
		}

		protected virtual void Update()
		{
			DrivingLocomotion();
			if (Ragdoller != null)
			{
				if (Ragdoller.State == AdvancedRagdollController.RagdollState.Ragdolled && IsDriving)
				{
					ExitVehicle();
				}
				if (Ragdoller.State == AdvancedRagdollController.RagdollState.Ragdolled)
				{
					VehicleToDrive = null;
				}
			}
			if (UseDefaultInputsOnVehicleInteraction && JUInput.GetButtonDown(JUInput.Buttons.EnterVehicleButton))
			{
				if (IsDriving)
				{
					ExitVehicle();
				}
				else
				{
					DriveVehicle();
				}
			}
		}

		protected virtual void DrivingLocomotion()
		{
			if (IsDriving && !(VehicleToDrive == null))
			{
				if (rb != null)
				{
					rb.useGravity = false;
					rb.velocity = VehicleToDrive.rb.velocity;
				}
				base.transform.position = VehicleToDrive.InverseKinematicTargetPositions.PlayerLocation.position;
				base.transform.rotation = VehicleToDrive.InverseKinematicTargetPositions.PlayerLocation.rotation;
			}
		}

		protected virtual void OnEnterVehicle()
		{
			OnJUTPSCharacterStartDriving();
		}

		protected virtual void OnExitVehicle()
		{
			OnJUTPSCharacterStopDriving();
		}

		public void DriveVehicle()
		{
			if (!(VehicleToDrive == null))
			{
				if (FootstepSoundsToDisable != null)
				{
					FootstepSoundsToDisable.enabled = false;
				}
				if (!IsDriving)
				{
					OnEnterVehicle();
				}
				TPSCharacter.PhysicalIgnore(VehicleToDrive.gameObject, ignore: true);
				VehicleToDrive.IsOn = true;
				IsDriving = true;
			}
		}

		public void ExitVehicle()
		{
			if (VehicleToDrive == null)
			{
				return;
			}
			if (FootstepSoundsToDisable != null)
			{
				FootstepSoundsToDisable.enabled = true;
			}
			if (IsDriving)
			{
				if (TPSCharacter != null)
				{
					TPSCharacter.Invoke("enableMove", 0.1f);
					TPSCharacter.transform.position = VehicleToDrive.GetExitPosition();
				}
				else
				{
					base.transform.position = VehicleToDrive.GetExitPosition();
				}
				OnExitVehicle();
			}
			Invoke("ReenablePhysic", 0.2f);
			VehicleToDrive.IsOn = false;
			IsDriving = false;
		}

		private void ReenablePhysic()
		{
			if (!IsDriving)
			{
				TPSCharacter.PhysicalIgnore(VehicleToDrive.gameObject, ignore: false);
			}
		}

		public static void DriveVehicle(Vehicle vehicle, GameObject character)
		{
			if (!(vehicle == null) && !(character == null))
			{
				if (character.TryGetComponent<DriveVehicles>(out var component))
				{
					component.VehicleToDrive = vehicle;
					component.DriveVehicle();
				}
				else
				{
					Debug.LogWarning("The character does not have the ability to drive vehicles, assign the script DriveVehicles.cs in gameobject");
				}
			}
		}

		public static void ExitVehicle(GameObject character)
		{
			if (!(character == null))
			{
				if (character.TryGetComponent<DriveVehicles>(out var component))
				{
					component.ExitVehicle();
				}
				else
				{
					Debug.LogWarning("Unable to execute exit vehicle command, as specified gameobject does not have the ability to drive vehicles.");
				}
			}
		}

		protected virtual void OnJUTPSCharacterStartDriving()
		{
			if (!(TPSCharacter == null))
			{
				anim.SetBool(TPSCharacter.AnimatorParameters.Driving, value: true);
				TPSCharacter.IsJumping = false;
				TPSCharacter.IsGrounded = false;
				TPSCharacter.VelocityMultiplier = 0f;
				TPSCharacter.SwitchToItem();
				TPSCharacter.DisableLocomotion();
				coll.isTrigger = true;
				for (int i = 1; i < 4; i++)
				{
					anim.SetLayerWeight(i, 0f);
				}
				anim.SetBool(TPSCharacter.AnimatorParameters.Crouch, value: false);
				anim.SetBool(TPSCharacter.AnimatorParameters.ItemEquiped, value: false);
				anim.SetBool(TPSCharacter.AnimatorParameters.FireMode, value: false);
				anim.SetBool(TPSCharacter.AnimatorParameters.Grounded, value: true);
				anim.SetBool(TPSCharacter.AnimatorParameters.Running, value: false);
				anim.SetFloat(TPSCharacter.AnimatorParameters.IdleTurn, 0f);
				anim.SetFloat(TPSCharacter.AnimatorParameters.Speed, 0f);
			}
		}

		protected virtual void OnJUTPSCharacterStopDriving()
		{
			if (!(TPSCharacter == null))
			{
				anim.SetBool(TPSCharacter.AnimatorParameters.Driving, value: false);
				TPSCharacter.EnableMove();
				TPSCharacter.transform.eulerAngles = new Vector3(0f, TPSCharacter.transform.eulerAngles.y, 0f);
				coll.isTrigger = false;
				rb.useGravity = true;
				TPSCharacter.ResetDefaultLayersWeight();
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (CheckVehiclesByTrigger && other.transform.tag == "VehicleArea" && !IsDriving)
			{
				VehicleToDrive = other.GetComponentInParent<Vehicle>();
				if (VehicleToDrive != null)
				{
					VehicleDrivableNearby = true;
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (CheckVehiclesByTrigger && other.transform.tag == "VehicleArea" && !IsDriving)
			{
				VehicleToDrive = null;
				VehicleDrivableNearby = false;
			}
		}
	}
}
