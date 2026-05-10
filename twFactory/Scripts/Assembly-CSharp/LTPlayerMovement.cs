using UnityEngine;

public class LTPlayerMovement : MovementComponent
{
	public override void Move(Vector3 direction, float tickTime, bool normalizeDirection = true)
	{
		base.Move(direction, tickTime, normalizeDirection);
		if (base.transform.position.x < 0f)
		{
			base.transform.position = new Vector3(0f, base.transform.position.y, base.transform.position.z);
		}
		else if (base.transform.position.x > (float)(LTFunctionLibrary.GetLTLevelController().LevelSizeX - 1))
		{
			base.transform.position = new Vector3(LTFunctionLibrary.GetLTLevelController().LevelSizeX - 1, base.transform.position.y, base.transform.position.z);
		}
		if (base.transform.position.z < 0f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 0f);
		}
		else if (base.transform.position.z > (float)(LTFunctionLibrary.GetLTLevelController().LevelSizeZ - 1))
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, LTFunctionLibrary.GetLTLevelController().LevelSizeZ - 1);
		}
	}
}
