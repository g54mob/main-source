using UnityEngine;
using com.ootii.Actors.BoneControllers;

public class SkeletonRaycastCode : SceneCode
{
	private GameObject mHuman;

	private BoneController mSkeleton;

	private GameObject mGun1;

	private float mGun1Up;

	private float mGun1Right;

	private Vector3 mGun1Position;

	private bool mGun1IsActive;

	private IKBone mHitBone;

	private Vector3 mHitPoint;

	private void Start()
	{
	}

	public override void Update()
	{
	}

	public void MoveGunUp(float rValue)
	{
	}

	public void MoveGunRight(float rValue)
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
