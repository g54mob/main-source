namespace MalbersAnimations.Controller
{
	public enum modifier
	{
		RootMotion = 1,
		Sprint = 2,
		Gravity = 4,
		Grounded = 8,
		OrientToGround = 0x10,
		CustomRotation = 0x20,
		IgnoreLowerStates = 0x40,
		Persistent = 0x80,
		LockMovement = 0x100,
		LockInput = 0x200,
		AdditiveRotationSpeed = 0x400,
		AdditivePositionSpeed = 0x800,
		FreeMovement = 0x1000
	}
}
