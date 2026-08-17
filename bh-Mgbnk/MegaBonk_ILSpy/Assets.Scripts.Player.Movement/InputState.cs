using System;

namespace Assets.Scripts.Player.Movement;

public struct InputState
{
	public float moveHorizontal;

	public float moveVertical;

	public float rotationHorizontal;

	public float rotationVertical;

	public bool jumping;

	public bool crouching;

	public bool holdingJump;

	public bool holdingWallrun;

	public InputState(float mH, float mV, float rH, float rV, bool ju, bool cr, bool holdingJump, bool holdingWallrun)
	{
		//IL_0050: Expected F4, but got I
		bool flag = default(bool);
		jumping = flag;
		bool flag2 = default(bool);
		crouching = flag2;
		bool flag3 = default(bool);
		this.holdingJump = flag3;
		bool flag4 = default(bool);
		this.holdingWallrun = flag4;
		moveHorizontal = mH;
		moveVertical = mV;
		rotationHorizontal = rH;
		IntPtr intPtr = default(IntPtr);
		rotationVertical = (nint)intPtr;
	}
}
