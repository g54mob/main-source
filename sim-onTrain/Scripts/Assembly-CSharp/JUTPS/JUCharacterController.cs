using JUTPS.AI;
using JUTPS.CharacterBrain;
using JUTPS.ItemSystem;
using JUTPS.JUInputSystem;
using JUTPS.PhysicsScripts;
using JUTPS.VehicleSystem;
using UnityEngine;

namespace JUTPS
{
	[AddComponentMenu("JU TPS/Third Person System/Character Controllers/JU Character Controller")]
	[RequireComponent(typeof(Rigidbody), typeof(AudioSource), typeof(CapsuleCollider))]
	public class JUCharacterController : JUCharacterBrain
	{
		public bool isOnTrain;

		[Header("Controller Options")]
		public bool UseDefaultControllerInput = true;

		public bool AutoRun = true;

		public bool WalkOnRunButton = true;

		public bool SprintOnRunButton;

		public bool UnlimitedSprintDuration;

		public bool DecreaseSpeedOnJump;

		public bool BlockVerticalInput;

		public bool BlockHorizontalInput;

		public bool BlockFireModeOnCursorVisible;

		public bool BlockFireModeOnPunching = true;

		public bool EnablePunchAttacks = true;

		public bool EnableRoll = true;

		[Header("Physical Damage")]
		public bool PhysicalDamage = true;

		public bool DoRagdollPhysicalDamage = true;

		public float PhysicalDamageStartAt = 25f;

		public float PhysicalDamageMultiplier = 0.8f;

		public float RagdollStartAtDamage = 10f;

		public string[] PhysicalDamageIgnoreTags = new string[5] { "Player", "Enemy", "Bones", "Wall", "Bullet" };

		private float fireInputTime;

		private bool isFixedTps;

		private void FixedUpdate()
		{
			if (!IsDead && !DisableAllMove && !JUPauseGame.Paused)
			{
				Movement();
				SlopeSlide();
				StepCorrectionMovement();
			}
		}

		private void Update()
		{
			if (JUPauseGame.Paused)
			{
				return;
			}
			if (LocomotionMode == MovementMode.TpsFixed)
			{
				isFixedTps = true;
			}
			else
			{
				isFixedTps = false;
			}
			FootPlacementIKController();
			GroundCheck();
			HealthCheck();
			SetAnimatorParameters();
			SetupDefaultLayersWeights();
			if (!IsDead)
			{
				DrivingCheck();
				WallAHeadCheck();
				if (!DisableAllMove && TrainGameManager.isInputActive)
				{
					ControllerInputs();
					StepCorrectionCalculation();
					Rotate(HorizontalX, VerticalY);
					RefreshItemAimRotationPivot();
					WeaponOrientator();
					WieldingIKWeightController();
				}
				else
				{
					LegsLayerWeight = Mathf.Lerp(LegsLayerWeight, 0f, 8f * Time.deltaTime);
				}
			}
		}

		public virtual void ControllerInputs()
		{
			if (!UseDefaultControllerInput)
			{
				return;
			}
			bool button = JUInput.GetButton(JUInput.Buttons.ShotButton);
			bool buttonDown = JUInput.GetButtonDown(JUInput.Buttons.ShotButton);
			bool buttonDown2 = JUInput.GetButtonDown(JUInput.Buttons.ReloadButton);
			bool button2 = JUInput.GetButton(JUInput.Buttons.AimingButton);
			bool buttonDown3 = JUInput.GetButtonDown(JUInput.Buttons.AimingButton);
			FireModeTimer(button, button2);
			if (!BlockHorizontalInput)
			{
				HorizontalX = JUInput.GetAxis(JUInput.Axis.MoveHorizontal);
			}
			if (!BlockVerticalInput)
			{
				VerticalY = JUInput.GetAxis(JUInput.Axis.MoveVertical);
			}
			HorizontalX = Mathf.Clamp(HorizontalX, -1f, 1f);
			VerticalY = Mathf.Clamp(VerticalY, -1f, 1f);
			if (JUInput.GetButtonDown(JUInput.Buttons.CrouchButton))
			{
				if (IsRunning && AutoRun)
				{
					IsRunning = false;
					MaxSprintSpeed = false;
					CanSprint = true;
					SprintSpeedDecrease = 0f;
				}
				if (!IsCrouched || IsProne)
				{
					_Crouch();
				}
				else
				{
					_GetUp();
				}
			}
			if (JUInput.GetButtonDown(JUInput.Buttons.ProneButton))
			{
				if (!IsProne)
				{
					_Prone();
				}
				else
				{
					_GetUp();
					_GetUp();
				}
			}
			if (MaxWalkableAngle > 0f && GroundAngle > MaxWalkableAngle / 1.5f && IsProne)
			{
				_GetUp();
			}
			if (IsCrouched && JUInput.GetButton(JUInput.Buttons.RunButton))
			{
				_GetUp();
			}
			if (JUInput.GetButton(JUInput.Buttons.JumpButton) && !IsJumping)
			{
				_Jump();
			}
			_NewJumpDelay(0.2f, DecreaseSpeedOnJump);
			if (JUInput.GetButtonDown(JUInput.Buttons.RollButton) && EnableRoll)
			{
				_Roll();
			}
			if (JUInput.GetButton(JUInput.Buttons.RunButton))
			{
				if (WalkOnRunButton)
				{
					IsRunning = false;
				}
				else
				{
					IsRunning = true;
				}
				if (SprintOnRunButton && !IsCrouched && CanSprint && (Mathf.Abs(HorizontalX) > 0.5f || Mathf.Abs(VerticalY) > 0.5f))
				{
					IsRunning = true;
					IsSprinting = true;
					CanSprint = true;
					if (UnlimitedSprintDuration)
					{
						MaxSprintSpeed = false;
					}
				}
			}
			else
			{
				IsRunning = false;
				if (SprintOnRunButton && !IsCrouched && CanSprint)
				{
					IsSprinting = false;
				}
			}
			if (JUInput.GetButtonDown(JUInput.Buttons.RunButton) && AutoRun && SprintOnRunButton)
			{
				SprintSpeedDecrease = 6f;
				Debug.Log("Start Sprinting");
			}
			if (JUInput.GetButtonUp(JUInput.Buttons.RunButton) && SprintOnRunButton)
			{
				IsSprinting = false;
			}
			if (SprintingSkill && IsSprinting && UnlimitedSprintDuration)
			{
				MaxSprintSpeed = false;
			}
			if (WalkOnRunButton)
			{
				if (AutoRun && !JUInput.GetButton(JUInput.Buttons.RunButton) && !IsCrouched && (Mathf.Abs(HorizontalX) > 0.5f || Mathf.Abs(VerticalY) > 0.5f))
				{
					IsRunning = true;
				}
			}
			else if (AutoRun && !IsCrouched && (Mathf.Abs(HorizontalX) > 0.5f || Mathf.Abs(VerticalY) > 0.5f))
			{
				IsRunning = true;
			}
			if (JUGameManager.IsMobile && !BlockVerticalInput && JUInput.GetButton(JUInput.Buttons.RunButton) && JUInput.GetAxis(JUInput.Axis.MoveHorizontal) == 0f && JUInput.GetAxis(JUInput.Axis.MoveVertical) == 0f)
			{
				if (SprintOnRunButton)
				{
					IsSprinting = true;
					if (UnlimitedSprintDuration)
					{
						MaxSprintSpeed = false;
					}
				}
				IsRunning = true;
				IsCrouched = false;
				IsMoving = true;
				VerticalY = Mathf.Lerp(VerticalY, 1f, 8f * Time.deltaTime);
			}
			if (!FiringMode)
			{
				IsAiming = false;
			}
			if (Cursor.visible && !JUGameManager.IsMobile && BlockFireModeOnCursorVisible)
			{
				return;
			}
			if (Inventory != null)
			{
				if (Inventory.isPickedEmpty)
				{
					DefaultUseOfAllItems(ShotInput: false);
				}
				else
				{
					DefaultUseOfAllItems(button, buttonDown, !Inventory.IsPickingItem && buttonDown2, button2, buttonDown3, EnablePunchAttacks && buttonDown);
				}
			}
			else if (Inventory.isPickedEmpty)
			{
				DefaultUseOfAllItems(ShotInput: false);
			}
			else
			{
				DefaultUseOfAllItems(button, buttonDown, buttonDown2, button2, buttonDown3, EnablePunchAttacks && buttonDown);
			}
			if ((button || button2) && !FiringMode && !IsRolling && !IsDriving && !IsReloading && LocomotionMode != MovementMode.JuTpsClassic && (!BlockFireModeOnPunching || !IsPunching))
			{
				FiringModeIK = true;
				FiringMode = true;
			}
			if (BlockFireModeOnPunching && (IsPunching || !IsItemEquiped))
			{
				FiringMode = false;
				FiringModeIK = false;
			}
		}

		protected virtual void SetupDefaultLayersWeights()
		{
			TorsoLayerWeight = 1f;
			if (Inventory.equipedItemType == ItemType.FullBodyHandTool)
			{
				FullBodyLayerWeight = 1f;
			}
			else
			{
				FullBodyLayerWeight = 0f;
			}
			FullBodyLayerWeight = 1f;
			LegsOverrideLayerWeight = Mathf.Lerp(LegsOverrideLayerWeight, isFixedTps ? 1 : 0, 5f * Time.deltaTime);
			SetDefaultAnimatorsLayersWeight(AnimatorParameters, LegsLayerWeight, RightArmLayerWeight, LeftArmLayerWeight, BothArmsLayerWeight, WeaponSwitchLayerWeight, TorsoLayerWeight, LegsOverrideLayerWeight, FullBodyLayerWeight);
			if (IsMeleeAttacking)
			{
				return;
			}
			bool flag = FiringMode && !IsRolling && !IsDriving && !DisableAllMove;
			LegsLayerWeight = Mathf.Lerp(LegsLayerWeight, flag ? 1 : 0, 5f * Time.deltaTime);
			bool flag2 = IsReloading || anim.GetCurrentAnimatorStateInfo(AnimatorParameters._BothArmsLayerIndex).IsName("Reload Right Hand Weapon") || anim.GetCurrentAnimatorStateInfo(AnimatorParameters._BothArmsLayerIndex).IsName("Reload Left Hand Weapon");
			if (HoldableItemInUseRightHand != null)
			{
				bool flag3 = !IsDriving && !IsRolling && !IsReloading;
				if (HoldableItemInUseRightHand.HoldPose != HoldableItem.ItemHoldingPose.Free)
				{
					RightArmLayerWeight = Mathf.MoveTowards(RightArmLayerWeight, flag3 ? 0.8f : 0f, 2f * Time.deltaTime);
				}
				else
				{
					RightArmLayerWeight = Mathf.MoveTowards(RightArmLayerWeight, 0f, 2f * Time.deltaTime);
				}
			}
			else
			{
				RightArmLayerWeight = Mathf.MoveTowards(RightArmLayerWeight, 0f, 2f * Time.deltaTime);
			}
			if (HoldableItemInUseLeftHand != null)
			{
				bool flag4 = !IsDriving && !IsRolling && !IsReloading;
				LeftArmLayerWeight = Mathf.MoveTowards(LeftArmLayerWeight, flag4 ? 0.8f : 0f, 2f * Time.deltaTime);
			}
			else
			{
				LeftArmLayerWeight = Mathf.MoveTowards(LeftArmLayerWeight, 0f, 2f * Time.deltaTime);
			}
			bool num = !(HoldableItemInUseLeftHand == null);
			bool flag5 = !(HoldableItemInUseRightHand == null);
			if (num || flag5)
			{
				if (HoldableItemInUseRightHand != null && HoldableItemInUseLeftHand == null)
				{
					if (HoldableItemInUseRightHand.OppositeHandPosition != null || flag2)
					{
						BothArmsLayerWeight = Mathf.MoveTowards(BothArmsLayerWeight, 1f, 2f * Time.deltaTime);
					}
					else
					{
						BothArmsLayerWeight = Mathf.MoveTowards(BothArmsLayerWeight, 0f, 2f * Time.deltaTime);
					}
				}
				if (HoldableItemInUseRightHand == null && HoldableItemInUseLeftHand != null)
				{
					if (HoldableItemInUseLeftHand.OppositeHandPosition != null || flag2)
					{
						BothArmsLayerWeight = Mathf.MoveTowards(BothArmsLayerWeight, flag2 ? 1 : 0, 2f * Time.deltaTime);
					}
					else
					{
						BothArmsLayerWeight = Mathf.MoveTowards(BothArmsLayerWeight, 0f, 2f * Time.deltaTime);
					}
				}
				if (HoldableItemInUseRightHand != null && HoldableItemInUseLeftHand != null)
				{
					BothArmsLayerWeight = Mathf.MoveTowards(BothArmsLayerWeight, flag2 ? 1 : 0, 2f * Time.deltaTime);
				}
			}
			else
			{
				BothArmsLayerWeight = Mathf.MoveTowards(BothArmsLayerWeight, flag2 ? 1 : 0, 2f * Time.deltaTime);
			}
			if (flag2)
			{
				BothArmsLayerWeight = 1f;
			}
			if (IsWeaponSwitching)
			{
				FiringModeIK = false;
				WeaponSwitchLayerWeight = Mathf.MoveTowards(WeaponSwitchLayerWeight, 1f, 10f * Time.deltaTime);
			}
			else
			{
				WeaponSwitchLayerWeight = Mathf.MoveTowards(WeaponSwitchLayerWeight, 0f, 3f * Time.deltaTime);
			}
		}

		public virtual void SetAnimatorParameters()
		{
			Vector3 vector = WordSpaceToBlendTreeSpace(GetLookPosition(), DirectionTransform);
			float value = 0f;
			float value2 = 0f;
			if (FiringMode || isFixedTps)
			{
				if (JUGameManager.IsMobile)
				{
					value = Mathf.MoveTowards(anim.GetFloat(AnimatorParameters.VerticalInput), 8f * VelocityMultiplier * vector.z, 8f * Time.deltaTime);
					value2 = Mathf.MoveTowards(anim.GetFloat(AnimatorParameters.HorizontalInput), 8f * VelocityMultiplier * vector.x, 8f * Time.deltaTime);
				}
				else
				{
					value = Mathf.Lerp(anim.GetFloat(AnimatorParameters.VerticalInput), 3f * VelocityMultiplier * vector.z, 4f * Time.deltaTime);
					value2 = Mathf.Lerp(anim.GetFloat(AnimatorParameters.HorizontalInput), 3f * VelocityMultiplier * vector.x, 4f * Time.deltaTime);
				}
			}
			if (AnimatorParameters.Dying != "")
			{
				anim.SetBool(AnimatorParameters.Dying, IsDead);
			}
			if (AnimatorParameters.VerticalInput != "")
			{
				anim.SetFloat(AnimatorParameters.VerticalInput, value);
			}
			if (AnimatorParameters.HorizontalInput != "")
			{
				anim.SetFloat(AnimatorParameters.HorizontalInput, value2);
			}
			if (AnimatorParameters.Speed != "")
			{
				anim.SetFloat(AnimatorParameters.Speed, VelocityMultiplier);
			}
			if (AnimatorParameters.Moving != "")
			{
				anim.SetBool(AnimatorParameters.Moving, IsMoving);
			}
			if (AnimatorParameters.Running != "")
			{
				anim.SetBool(AnimatorParameters.Running, IsRunning);
			}
			if (AnimatorParameters.Grounded != "")
			{
				anim.SetBool(AnimatorParameters.Grounded, IsGrounded);
			}
			if (AnimatorParameters.Jumping != "")
			{
				anim.SetBool(AnimatorParameters.Jumping, IsJumping);
			}
			if (AnimatorParameters.Crouch != "")
			{
				anim.SetBool(AnimatorParameters.Crouch, IsCrouched);
			}
			if (AnimatorParameters.Prone != "")
			{
				anim.SetBool(AnimatorParameters.Prone, IsProne);
			}
			if (AnimatorParameters.MovingTurn != "")
			{
				CalculateBodyRotation(ref BodyRotation);
				anim.SetFloat(AnimatorParameters.MovingTurn, BodyRotation);
			}
			if (AnimatorParameters.IdleTurn != "")
			{
				CalculateRotationIntensity(ref IdleTurn);
				anim.SetFloat(AnimatorParameters.IdleTurn, IdleTurn);
			}
			if (AnimatorParameters.ItemEquiped != "")
			{
				anim.SetBool(AnimatorParameters.ItemEquiped, IsItemEquiped);
			}
			if (AnimatorParameters.FireMode != "")
			{
				anim.SetBool(AnimatorParameters.FireMode, FiringMode);
			}
			if (!IsWeaponSwitching && WeaponSwitchLayerWeight == 0f && AnimatorParameters._SwitchWeaponLayerIndex > -1)
			{
				anim.Play("Empty", AnimatorParameters._SwitchWeaponLayerIndex);
			}
			if (AnimatorParameters.ItemsWieldingIdentifier != "")
			{
				anim.SetInteger(AnimatorParameters.ItemsWieldingIdentifier, GetWieldingID());
			}
			if (AnimatorParameters.ItemWieldingRightHandPoseID != "")
			{
				anim.SetFloat(AnimatorParameters.ItemWieldingRightHandPoseID, (HoldableItemInUseRightHand != null) ? HoldableItemInUseRightHand.GetWieldingPoseIndex() : 0);
			}
			if (AnimatorParameters.ItemWieldingLeftHandPoseID != "")
			{
				anim.SetFloat(AnimatorParameters.ItemWieldingLeftHandPoseID, (HoldableItemInUseLeftHand != null) ? HoldableItemInUseLeftHand.GetWieldingPoseIndex() : 0);
			}
		}

		protected virtual void Movement()
		{
			LocomotionModeController();
			if (Ragdoller != null)
			{
				if (Ragdoller.State != AdvancedRagdollController.RagdollState.Animated)
				{
					IsRagdolled = true;
					IsAiming = false;
					FiringMode = false;
					IsDriving = false;
					ArmsWeightIK = 0f;
					LeftHandWeightIK = 0f;
					RightHandWeightIK = 0f;
					IsArmedWeight = 0f;
					BothArmsLayerWeight = 0f;
					DisableLocomotion();
				}
				else
				{
					IsRagdolled = false;
				}
			}
			if (RootMotion)
			{
				if (IsGrounded && !IsJumping && !IsRolling && !FiringMode)
				{
					anim.applyRootMotion = true;
				}
				else
				{
					anim.applyRootMotion = false;
				}
			}
			if (IsRolling)
			{
				if (CurvedMovement)
				{
					MoveForward(1.5f);
				}
				else
				{
					MoveDirectional(1.5f);
				}
			}
			if (!CanMove)
			{
				VelocityMultiplier = 0f;
				return;
			}
			InAirMovementControl();
			IsMoving = Mathf.Abs(VerticalY) != 0f || Mathf.Abs(HorizontalX) != 0f;
			DoFreeMovement(FiringMode, isFixedTps);
			DoFireModeMovement(FiringMode, isFixedTps);
			if (!(WeaponSwitchingCurrentTime <= 1f) || !IsWeaponSwitching)
			{
				return;
			}
			WeaponSwitchingCurrentTime += Time.deltaTime;
			if (WeaponSwitchingCurrentTime >= 0.5f)
			{
				if (FiringMode)
				{
					FiringModeIK = true;
				}
				IsWeaponSwitching = false;
				WeaponSwitchingCurrentTime = 0f;
			}
		}

		protected virtual void LocomotionModeController()
		{
			switch (LocomotionMode)
			{
			case MovementMode.AwaysInFireMode:
				FiringMode = true;
				CurrentTimeToDisableFireMode = 0f;
				if (IsReloading)
				{
					FiringModeIK = false;
				}
				break;
			case MovementMode.JuTpsClassic:
				FiringMode = IsItemEquiped;
				CurrentTimeToDisableFireMode = (IsItemEquiped ? 0f : CurrentTimeToDisableFireMode);
				break;
			}
		}

		public void DisableLocomotion(float duration = 0f)
		{
			HorizontalX = 0f;
			VerticalY = 0f;
			VelocityMultiplier = 0f;
			DisableAllMove = true;
			FiringMode = false;
			CanMove = false;
			if (duration > 0f)
			{
				Invoke("EnableMove", duration);
			}
		}

		public void EnableMove()
		{
			DisableAllMove = false;
		}

		private void WeaponOrientator()
		{
			if (Inventory != null)
			{
				CurrentItemIDRightHand = Inventory.CurrentRightHandItemID;
				CurrentItemIDLeftHand = Inventory.CurrentLeftHandItemID;
				IsItemEquiped = Inventory.IsItemSelected;
			}
			if (IsItemEquiped)
			{
				if (MyCamera != null)
				{
					if (WeaponInUseRightHand != null)
					{
						Vector3 shootDirection = ((LookAtPosition != Vector3.zero) ? GetCurrentWeaponLookDirection() : MyCamera.transform.forward);
						WeaponInUseRightHand.SetWeaponOrientation(MyCamera.transform.position, shootDirection);
					}
					if (WeaponInUseLeftHand != null)
					{
						Vector3 shootDirection2 = ((LookAtPosition != Vector3.zero) ? GetCurrentWeaponLookDirection() : MyCamera.transform.forward);
						WeaponInUseLeftHand.SetWeaponOrientation(MyCamera.transform.position, shootDirection2);
					}
				}
				else
				{
					if (WeaponInUseRightHand != null)
					{
						WeaponInUseRightHand.SetWeaponOrientation(Vector3.zero, GetCurrentWeaponLookDirection());
					}
					if (WeaponInUseLeftHand != null)
					{
						WeaponInUseLeftHand.SetWeaponOrientation(Vector3.zero, GetCurrentWeaponLookDirection());
					}
				}
			}
			if (CurrentItemIDRightHand == -1 && CurrentItemIDLeftHand == -1)
			{
				IsItemEquiped = false;
			}
			else
			{
				IsItemEquiped = true;
			}
			if (HoldableItemInUseRightHand != null && HoldableItemInUseRightHand.BlockFireMode)
			{
				FiringMode = false;
				FiringModeIK = false;
			}
			if (HoldableItemInUseLeftHand != null && HoldableItemInUseLeftHand.BlockFireMode)
			{
				FiringMode = false;
				FiringModeIK = false;
			}
		}

		private void WieldingIKWeightController()
		{
			if (!FiringMode)
			{
				FiringModeIK = false;
			}
			if (IsItemEquiped)
			{
				SmoothLeftHandPosition(25f);
				SmoothRightHandPosition(25f);
			}
			if (FiringMode && !IsReloading)
			{
				LookWeightIK = Mathf.Lerp(LookWeightIK, 1f, 5f * Time.deltaTime);
			}
			else
			{
				LookWeightIK = Mathf.Lerp(LookWeightIK, 0f, 6f * Time.deltaTime);
			}
			if (FiringModeIK && !IsWeaponSwitching && !IsRolling)
			{
				ArmsWeightIK = Mathf.MoveTowards(ArmsWeightIK, 1f, 2f * Time.deltaTime);
			}
			else
			{
				ArmsWeightIK = Mathf.MoveTowards(ArmsWeightIK, 0f, 0.5f * Time.deltaTime);
			}
			if (IsWeaponSwitching || IsRolling)
			{
				LeftHandWeightIK = 0f;
				RightHandWeightIK = 0f;
				return;
			}
			float num = 2f;
			if (!IsRolling && !IsReloading)
			{
				if (HoldableItemInUseLeftHand != null)
				{
					if (HoldableItemInUseLeftHand.HoldPose != HoldableItem.ItemHoldingPose.Free)
					{
						if (FiringModeIK)
						{
							LeftHandWeightIK = Mathf.MoveTowards(LeftHandWeightIK, 1f, num * Time.deltaTime);
						}
						else
						{
							LeftHandWeightIK = Mathf.MoveTowards(LeftHandWeightIK, 0f, num * Time.deltaTime);
						}
					}
					else if (HoldableItemInUseRightHand != null)
					{
						if (HoldableItemInUseRightHand.OppositeHandPosition != null)
						{
							LeftHandWeightIK = Mathf.MoveTowards(LeftHandWeightIK, 1f, num * Time.deltaTime);
						}
						else
						{
							LeftHandWeightIK = Mathf.MoveTowards(LeftHandWeightIK, 0f, num * Time.deltaTime);
						}
					}
					else
					{
						LeftHandWeightIK = Mathf.MoveTowards(LeftHandWeightIK, 0f, num * Time.deltaTime);
					}
				}
				else if (HoldableItemInUseRightHand != null)
				{
					if (HoldableItemInUseRightHand.OppositeHandPosition != null)
					{
						LeftHandWeightIK = Mathf.MoveTowards(LeftHandWeightIK, (FiringModeIK || !FiringMode) ? 1 : 0, num * Time.deltaTime);
					}
					else
					{
						LeftHandWeightIK = Mathf.MoveTowards(LeftHandWeightIK, 0f, num * Time.deltaTime);
					}
				}
				else
				{
					LeftHandWeightIK = Mathf.MoveTowards(LeftHandWeightIK, 0f, num * Time.deltaTime);
				}
				if (HoldableItemInUseRightHand != null)
				{
					if (HoldableItemInUseRightHand.HoldPose != HoldableItem.ItemHoldingPose.Free)
					{
						if (FiringModeIK)
						{
							RightHandWeightIK = Mathf.MoveTowards(RightHandWeightIK, 1f, num * Time.deltaTime);
						}
						else
						{
							RightHandWeightIK = Mathf.MoveTowards(RightHandWeightIK, 0f, 3f * num * Time.deltaTime);
						}
					}
					else if (HoldableItemInUseLeftHand != null)
					{
						if (HoldableItemInUseLeftHand.OppositeHandPosition != null)
						{
							RightHandWeightIK = Mathf.MoveTowards(RightHandWeightIK, 1f, num * Time.deltaTime);
						}
						else
						{
							RightHandWeightIK = Mathf.MoveTowards(RightHandWeightIK, 0f, num * Time.deltaTime);
						}
					}
					else
					{
						RightHandWeightIK = Mathf.MoveTowards(RightHandWeightIK, 0f, num * Time.deltaTime);
					}
				}
				else if (HoldableItemInUseLeftHand != null)
				{
					if (HoldableItemInUseLeftHand.OppositeHandPosition != null)
					{
						RightHandWeightIK = Mathf.MoveTowards(RightHandWeightIK, (FiringModeIK || !FiringMode) ? 1 : 0, num * Time.deltaTime);
					}
					else
					{
						RightHandWeightIK = Mathf.MoveTowards(RightHandWeightIK, 0f, num * Time.deltaTime);
					}
				}
				else
				{
					RightHandWeightIK = Mathf.MoveTowards(RightHandWeightIK, 0f, num * Time.deltaTime);
				}
			}
			else
			{
				LeftHandWeightIK = Mathf.MoveTowards(LeftHandWeightIK, 0f, num * Time.deltaTime);
				RightHandWeightIK = Mathf.MoveTowards(RightHandWeightIK, 0f, num * Time.deltaTime);
			}
		}

		private void RefreshItemAimRotationPivot()
		{
			Vector3 vector = HumanoidSpine.position + base.transform.forward * 0.2f - base.transform.up * 0.2f;
			Vector3 position = ((!IsProne) ? HumanoidSpine.position : vector);
			PivotItemRotation.transform.position = position;
			Vector3 lookDirectionEulerAngles = GetLookDirectionEulerAngles();
			if (FiringMode)
			{
				PivotItemRotation.transform.rotation = Quaternion.Lerp(PivotItemRotation.transform.rotation, Quaternion.Euler(lookDirectionEulerAngles), 10f * RotationSpeed * Time.deltaTime);
			}
			else
			{
				PivotItemRotation.transform.rotation = Quaternion.Lerp(PivotItemRotation.transform.rotation, base.transform.rotation, 10f * RotationSpeed * Time.deltaTime);
			}
		}

		private void FootPlacementIKController()
		{
			if (!(FootPlacerIK != null))
			{
				return;
			}
			if (!IsGrounded || IsJumping || IsDriving || IsDead || IsRolling || IsRagdolled || IsProne)
			{
				FootPlacerIK.SmoothIKTransition = false;
				FootPlacerIK.BlockBodyPositioning = true;
				FootPlacerIK.EnableDynamicBodyPlacing = false;
				return;
			}
			FootPlacerIK.SmoothIKTransition = true;
			if (!IsCrouched)
			{
				FootPlacerIK.EnableDynamicBodyPlacing = true;
			}
			else
			{
				FootPlacerIK.EnableDynamicBodyPlacing = false;
			}
		}

		public void EnablePhysicalDamage()
		{
			PhysicalDamage = true;
		}

		public void DisablePhysicalDamage()
		{
			PhysicalDamage = false;
		}

		public void DisablePhysicalDamageForSeconds(float seconds = 1f)
		{
			DisablePhysicalDamage();
			if (IsInvoking("EnablePhysicalDamage"))
			{
				CancelInvoke("EnablePhysicalDamage");
			}
			Invoke("EnablePhysicalDamage", seconds);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.transform.tag == "VehicleArea" && !IsDriving)
			{
				VehicleInArea = other.GetComponentInParent<Vehicle>();
				ToEnterVehicle = true;
			}
			if (other.gameObject.tag == "DeadZone")
			{
				KillCharacter();
			}
			if (other.gameObject.tag == "RagdollZone" && Ragdoller != null)
			{
				Ragdoller.State = AdvancedRagdollController.RagdollState.Ragdolled;
				IsArmedWeight = 0f;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.transform.tag == "VehicleArea" && !IsDriving)
			{
				VehicleInArea = null;
				ToEnterVehicle = false;
			}
		}

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.tag == "DeadZone")
			{
				KillCharacter();
			}
			if (other.gameObject.tag == "RagdollZone" && Ragdoller != null)
			{
				Ragdoller.State = AdvancedRagdollController.RagdollState.Ragdolled;
			}
			if (PhysicalDamage && !JUCharacterArtificialInteligenceBrain.TagMatches(other.collider.gameObject.tag, PhysicalDamageIgnoreTags) && other.gameObject.TryGetComponent<Rigidbody>(out var component) && !((double)Vector3.Dot((other.contacts[0].point - base.transform.position).normalized, component.velocity.normalized) > -0.1))
			{
				float num = PhysicalDamageMultiplier * (component.velocity.magnitude / 20f * component.mass);
				if (num > PhysicalDamageStartAt)
				{
					TakeDamage(num, other.contacts[0].point);
				}
				if (num > RagdollStartAtDamage)
				{
					Ragdoller.State = AdvancedRagdollController.RagdollState.Ragdolled;
				}
			}
		}

		private void OnAnimatorIK(int layerIndex)
		{
			if (!IsDead)
			{
				OriginalSpineRotation = anim.GetBoneTransform(HumanBodyBones.Spine).transform.localRotation;
				if (!IsRolling && !IsDriving)
				{
					LeftHandToRespectiveIKPosition(LeftHandWeightIK, LeftHandWeightIK / 1.2f);
					RightHandToRespectiveIKPosition(RightHandWeightIK, RightHandWeightIK / 1.2f);
					Vector3 lookPosition = GetLookPosition();
					float bodyIKWeight = (IsProne ? 0.1f : 0.3f);
					float num = Vector3.Dot(base.transform.forward, (lookPosition - base.transform.position).normalized);
					LookAtIK(lookPosition, num * LookWeightIK, bodyIKWeight, 0.6f);
				}
			}
		}

		private void OnAnimatorMove()
		{
			ApplyRootMotionOnLocomotion();
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
