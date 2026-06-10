using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "playertransition_data", menuName = "Database/Player Transition Preset")]
public class PlayerTransitionPreset : SoCustomComparison
{
	public enum TransitionPosition
	{
		relativeToInteractable = 0,
		relativeToPlayer = 1
	}

	[Serializable]
	public class SFXSetting
	{
		public AudioEvent soundEvent;

		public float atProgress;
	}

	[Header("Transition")]
	[Tooltip("Transition speed in seconds")]
	public float transitionTime;

	[Header("Control")]
	[Tooltip("Player keeps movement control during transition")]
	public bool retainMovementControl;

	[Tooltip("If above is true, this movement multiplier is applied")]
	public AnimationCurve controlCurve;

	[Tooltip("Mouse look control curve")]
	public AnimationCurve mouseLookControlCurve;

	[Header("Height")]
	[Tooltip("Player height multiplier")]
	public float playerHeightMP;

	[Tooltip("Camera height multiplier")]
	public float CamHeightMP;

	[Tooltip("If true, both the above will be different depending on whether the player is crouched or stood up...")]
	public bool factorInCrouching;

	[Space(5f)]
	public AnimationCurve heightCurve;

	public AnimationCurve camHeightCurve;

	[Space(5f)]
	[Header("Movement")]
	public bool useXMovement;

	[EnableIf("useXMovement")]
	public AnimationCurve playerXCurve;

	public bool useYMovement;

	[EnableIf("useYMovement")]
	public AnimationCurve playerYCurve;

	public bool useZMovement;

	[EnableIf("useZMovement")]
	public AnimationCurve playerZCurve;

	[Header("Rat Modifier Fixes")]
	public bool fixYMovementForRatController;

	[EnableIf("fixYMovementForRatController")]
	public AnimationCurve playerYCurveIfRat;

	[Space(5f)]
	public TransitionPosition transitionRelativity;

	[Tooltip("Performing this transition won't override a previous stored position...")]
	[Space(5f)]
	public bool disableWriteReturnPosition;

	[Tooltip("If true then transition to the stored return postion using the curve below.")]
	public bool transitionToSavedReturnPosition;

	[Tooltip("If true then transition from the player's current position to the correct position as described in these settings.")]
	public bool transitionFromExistingPosition;

	[Tooltip("Transition curve for the above")]
	public AnimationCurve positionTransitionCurve;

	[Space(5f)]
	[Tooltip("Useful for door interactables")]
	public bool invertXPositionBasedOnRelativePlayerX;

	public bool invertYPositionBasedOnRelativePlayerY;

	public bool invertZPositionBasedOnRelativePlayerZ;

	[Tooltip("Use a raycast to check this position is valid")]
	public bool raycastCheck;

	[EnableIf("raycastCheck")]
	public PlayerTransitionPreset onFailUse;

	[Tooltip("Enable movement upon end transition")]
	[Space(7f)]
	public bool allowMovementOnEnd;

	[EnableIf("allowMovementOnEnd")]
	[Tooltip("The movement speed on end")]
	public bool restoreNormalMovementSpeed;

	[DisableIf("restoreNormalMovementSpeed")]
	public float customMovementSpeed;

	public bool disableGravity;

	public bool disableHeadBob;

	[Header("Mouse Look")]
	public bool useXLook;

	[EnableIf("useXLook")]
	public AnimationCurve playerXLookCurve;

	public bool useYLook;

	[EnableIf("useYLook")]
	public AnimationCurve playerYLookCurve;

	public bool useZLook;

	[EnableIf("useZLook")]
	public AnimationCurve playerZLookCurve;

	[Space(5f)]
	public TransitionPosition lookRelativity;

	[Tooltip("If the above is set to relative to player, use the forward direction multiplied by this to determin the look position. This must be higher than the distance the player can move forward.")]
	public float forwardPositionModifier;

	[Tooltip("Multiply the X, Y and Z movement by this. Useful for when relative to player and adjusting the forward position modifier...")]
	public float lookMovementMultiplier;

	[Space(5f)]
	public bool applyCameraRoll;

	public AnimationCurve cameraRoll;

	public float rollMultiplier;

	[Tooltip("Make sure camera roll is reset at the end of the transition")]
	public bool resetCameraRoll;

	[Space(5f)]
	[Tooltip("If true then transition from the player's current mouse position to the correct position as described in these settings.")]
	public bool transitionFromExistingMouse;

	[Tooltip("Transition curve for the above")]
	public AnimationCurve mouseTransitionCurve;

	[Header("VFX")]
	public bool useChromaticAberration;

	[EnableIf("useChromaticAberration")]
	public AnimationCurve chromaticAberrationCurve;

	public bool useGain;

	[EnableIf("useGain")]
	public AnimationCurve gainCurve;

	[ReorderableList]
	[Header("SFX")]
	public List<SFXSetting> sfx;

	[Tooltip("Force selection of nothing upon transition begin")]
	[Header("First Person")]
	public bool forceHolsterOnTransition;

	[Tooltip("Restore first person item after transition has ended")]
	[EnableIf("forceHolsterOnTransition")]
	public bool restoreHolsterOnTransitionEnd;

	[Tooltip("Allow weapon selection after transition has finished")]
	public bool allowWeaponSwitchingAfterTransition;

	[Space(7f)]
	[Tooltip("A recoil state can be switched to manually in the transition to add these in addition to the normal look curves")]
	public AnimationCurve playerXRecoilLookCurve;

	public AnimationCurve playerYRecoilLookCurve;

	public AnimationCurve playerZRecoilLookCurve;

	[Header("Return")]
	public bool useCustomReturnPosition;

	[EnableIf("useCustomReturnPosition")]
	[Tooltip("Return position relative to the interactable")]
	public Vector3 returnPostion;
}
