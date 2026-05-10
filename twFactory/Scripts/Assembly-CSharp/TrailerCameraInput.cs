using UnityEngine;

public class TrailerCameraInput : MonoBehaviour
{
	private DirectionalMover directionalMover;

	private Rotator rotator;

	private void Awake()
	{
		directionalMover = GetComponent<DirectionalMover>();
		rotator = GetComponent<Rotator>();
		if ((bool)directionalMover)
		{
			directionalMover.enabled = false;
		}
		if ((bool)rotator)
		{
			rotator.enabled = false;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.PageUp))
		{
			if ((bool)directionalMover)
			{
				directionalMover.enabled = true;
			}
			if ((bool)rotator)
			{
				rotator.enabled = true;
			}
		}
	}
}
