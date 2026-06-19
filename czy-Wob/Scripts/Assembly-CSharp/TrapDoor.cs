using UnityEngine;

public class TrapDoor : MonoBehaviour
{
	public FixedJoint joint;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.D) && joint != null)
		{
			Object.Destroy(joint);
		}
	}
}
