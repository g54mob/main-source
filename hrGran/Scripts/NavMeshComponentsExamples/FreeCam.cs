using UnityEngine;

public class FreeCam : MonoBehaviour
{
	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes;

	public float sensitivityX;

	public float sensitivityY;

	public float minimumX;

	public float maximumX;

	public float minimumY;

	public float maximumY;

	public float moveSpeed;

	public bool lockHeight;

	private float rotationY;

	private void Update()
	{
	}
}
