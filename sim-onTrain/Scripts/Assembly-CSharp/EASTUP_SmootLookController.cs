using UnityEngine;

public class EASTUP_SmootLookController : MonoBehaviour
{
	public Transform parent;

	public float smoothSpeed = 5f;

	private void Update()
	{
		if (!(parent == null))
		{
			Quaternion b = Quaternion.Euler(0f, parent.eulerAngles.y, 0f);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * smoothSpeed);
		}
	}
}
