using UnityEngine;
using com.ootii.Actors.BoneControllers;

public class ImpactMotorCode : SceneCode
{
	private GameObject mHuman1;

	private ImpactMotor mHuman1Motor;

	private GameObject mHuman2;

	private ImpactMotor mHuman2Motor;

	private float mPower;

	private GameObject mGun1;

	private float mGun1Up;

	private float mGun1Right;

	private Vector3 mGun1Position;

	private bool mGun1IsActive;

	private float mArrowMass;

	private float mArrowSpeed;

	private float mArrowRange;

	private void Start()
	{
	}

	public override void Update()
	{
	}

	public void SetPower(float rValue)
	{
	}

	public void MoveGunUp(float rValue)
	{
	}

	public void MoveGunRight(float rValue)
	{
	}

	public void ShootGun()
	{
	}

	public override void NextDemo()
	{
	}

	public override void EnableMotors()
	{
	}

	public override void DisableMotors()
	{
	}
}
