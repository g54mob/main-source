using Dreamteck.Splines;
using UnityEngine;

public class SplineReset : MonoBehaviour
{
	[SerializeField]
	private SplineFollower spline;

	[SerializeField]
	private KeyCode key;

	private void Update()
	{
		if (Input.GetKeyDown(key))
		{
			spline.Restart();
		}
	}
}
