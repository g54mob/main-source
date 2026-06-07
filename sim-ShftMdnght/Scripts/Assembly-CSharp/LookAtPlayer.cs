using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
	public Transform cam;

	private void FixedUpdate()
	{
		if (cam == null)
		{
			if (Camera.main != null)
			{
				cam = Camera.main.transform;
			}
		}
		else
		{
			base.transform.LookAt(cam);
		}
	}
}
