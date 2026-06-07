using UnityEngine;

public class AlwaysForceZeroRotation : MonoBehaviour
{
	private void Update()
	{
		base.transform.localEulerAngles = Vector3.zero;
	}
}
