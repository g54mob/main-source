using UnityEngine;

public class CameraTranslation : MonoBehaviour
{
	public float sensitivity = 0.1f;

	public float maxOffset = 0.5f;

	public Vector3 initialPosition;

	public bool started;

	public float lerpSpeed;

	private float offsetX;

	private float offsetY;

	public bool offsetXChangesZ;

	private void OnEnable()
	{
		started = true;
	}

	private void OnDisable()
	{
		started = false;
	}

	private void Update()
	{
		if (started)
		{
			float axis = Input.GetAxis("Mouse X");
			float axis2 = Input.GetAxis("Mouse Y");
			offsetX -= axis * sensitivity;
			offsetY += axis2 * sensitivity;
			offsetX = Mathf.Clamp(offsetX, 0f - maxOffset, maxOffset);
			offsetY = Mathf.Clamp(offsetY, 0f - maxOffset, maxOffset);
			if (offsetXChangesZ)
			{
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(initialPosition.x, initialPosition.y + offsetY, initialPosition.z + offsetX), Time.deltaTime * lerpSpeed);
			}
			else
			{
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(initialPosition.x + offsetX, initialPosition.y + offsetY, initialPosition.z), Time.deltaTime * lerpSpeed);
			}
		}
	}
}
