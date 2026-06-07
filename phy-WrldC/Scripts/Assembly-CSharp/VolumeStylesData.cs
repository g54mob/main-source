using UnityEngine;

[CreateAssetMenu(menuName = "Minamolc/Volume Styles Data")]
public class VolumeStylesData : ScriptableObject
{
	[Header("Main Audio Volumes (2D)")]
	[Space(5f)]
	[Range(0f, 1f)]
	public float musicVolume = 0.1f;

	[Range(0f, 1f)]
	public float uiVolume = 0.5f;

	[Range(0f, 1f)]
	public float levelCompletedVolume = 0.5f;

	[Space(10f)]
	[Header("Animator Volumes (3D)")]
	[Space(5f)]
	[Range(0f, 1f)]
	public float animatorAnimation = 0.4f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float animatorByButton = 0.4f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float animatorTransitionMoving = 0.4f;

	[Range(0f, 1f)]
	public float animatorTransitionEnd = 0.5f;

	[Space(10f)]
	[Header("Block Component Volumes (3D)")]
	[Space(5f)]
	[Range(0f, 1f)]
	public float cannonFire = 1f;

	[Range(0f, 1f)]
	public float cannonEmpty = 0.7f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float decoupleActived = 0.5f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float grabberTurnOnOff = 0.7f;

	[Range(0f, 1f)]
	public float grabberGrabbed = 0.7f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float linearStageMoving = 0.5f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float pistonMoving = 0.5f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float simpleMotorCombustionMax = 1f;

	[Range(0f, 1f)]
	public float simpleMotorCombustionMin = 0.2f;

	[Range(0f, 1f)]
	public float simpleMotorEletricMax = 0.2f;

	[Range(0f, 1f)]
	public float simpleMotorEletricMin = 0.02f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float steerableBlockMoving = 0.1f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float wheelFriction = 0.2f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float buzzer = 0.4f;

	[Space(10f)]
	[Header("Rigidbody Volumes (3D)")]
	[Space(5f)]
	[Range(0f, 1f)]
	public float landMineBeep = 1f;

	[Range(0f, 1f)]
	public float landMineExplosion = 1f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float laserButtonTurnOn = 0.25f;

	[Range(0f, 1f)]
	public float laserButtonTurnOff = 0.25f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float laserEmitterWorking = 0.25f;

	[Range(0f, 1f)]
	public float laserEmitterDamaging = 0.15f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float levelButtonTurnOnOff = 1f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float tntCrateExplosion = 1f;
}
