using UnityEngine;

public class DogEar : MonoBehaviour
{
	public Transform leftEarJoint;

	public Transform rightEarJoint;

	public float maxEarBendLeft = -45f;

	public float maxEarBendRight = -45f;

	public void ApplyEarCurlMod(float modLeft, float modRight, bool syncedCurls)
	{
		if (!(leftEarJoint == null) && !(rightEarJoint == null))
		{
			if (syncedCurls)
			{
				modRight = modLeft;
			}
			leftEarJoint.transform.localRotation = Quaternion.Euler(leftEarJoint.transform.localRotation.eulerAngles + new Vector3(modLeft * maxEarBendLeft, 0f, 0f));
			rightEarJoint.transform.localRotation = Quaternion.Euler(rightEarJoint.transform.localRotation.eulerAngles + new Vector3(modRight * maxEarBendRight, 0f, 0f));
		}
	}
}
