using UnityEngine;

public class LazyFollower : MonoBehaviour
{
	private Transform mainCam;

	private void Start()
	{
		base.transform.SetParent(null);
		if (Camera.main != null)
		{
			mainCam = Camera.main.transform;
		}
		Vector3 position = base.transform.position;
		position.z = 0f;
		base.transform.position = position;
	}

	private void Update()
	{
		if (!(mainCam == null))
		{
			float z = mainCam.position.z;
			Vector3 position = base.transform.position;
			if (z > 1000f)
			{
				position.z = 2000f;
			}
			else
			{
				position.z = 0f;
			}
			base.transform.position = position;
		}
	}
}
