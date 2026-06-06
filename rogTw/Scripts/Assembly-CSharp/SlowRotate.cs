using UnityEngine;

public class SlowRotate : MonoBehaviour
{
	[SerializeField]
	private Vector3 rotation;

	private Vector3 currentRotation;

	private void Start()
	{
		currentRotation = base.transform.localEulerAngles;
	}

	private void Update()
	{
		currentRotation += rotation * Time.deltaTime;
		base.transform.localEulerAngles = currentRotation;
	}
}
