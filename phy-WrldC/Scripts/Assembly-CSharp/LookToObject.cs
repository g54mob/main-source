using UnityEngine;

public class LookToObject : MonoBehaviour
{
	public Transform objectToLook;

	private void Update()
	{
		if (objectToLook != null)
		{
			base.transform.LookAt(objectToLook);
		}
	}
}
