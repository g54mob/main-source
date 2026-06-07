using UnityEngine;

[CreateAssetMenu(menuName = "Minamolc/Component Styles Data")]
public class ComponentStylesData : ScriptableObject
{
	[Header("Wheel Audio Effects")]
	[Space(5f)]
	public AudioClip wheelFrictionClip;

	[Space(10f)]
	[Header("Simple Motor Audio Effects")]
	[Space(5f)]
	public AudioClip simpleMotorCombustionIdleClip;

	public AudioClip simpleMotorElectricIdleClip;

	[Space(10f)]
	[Header("Cannon Audio Effects")]
	[Space(5f)]
	public AudioClip cannonFireClip;

	public AudioClip cannonEmptyClip;

	[Space(10f)]
	[Header("Steerable Block Audio Effects")]
	[Space(5f)]
	public AudioClip steerablePositionChangedClip;

	[Space(10f)]
	[Header("Piston Audio Effects")]
	[Space(5f)]
	public AudioClip pistonPositionChangedClip;

	[Space(10f)]
	[Header("Linear Stage Audio Effects")]
	[Space(5f)]
	public AudioClip linearPositionChangingClip;

	[Space(10f)]
	[Header("Decoupler Audio Effects")]
	[Space(5f)]
	public AudioClip decouplerActivatedClip;

	[Space(10f)]
	[Header("Grabber Audio Effects")]
	[Space(5f)]
	public AudioClip grabberTurnOnClip;

	public AudioClip grabberTurnOffClip;

	public AudioClip grabberGrabbedClip;

	[Space(10f)]
	[Header("Thruster Audio Effects")]
	[Space(5f)]
	public AudioClip thrusterClip;

	public AudioClip multiThrusterClip;

	[Header("Solid Rocket Booster (SRB) Audio Effects")]
	[Space(5f)]
	public AudioClip srbStartClip;

	public AudioClip srbThrustClip;

	[Space(10f)]
	[Header("Buzzer Audio Effects")]
	[Space(5f)]
	public AudioClip buzzerClip;
}
