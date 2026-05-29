using UnityEngine;

public class BalatroCardVisual : MonoBehaviour
{
	[Header("Card")]
	[SerializeField]
	private Transform cardTransform;

	private Vector3 rotationDelta;

	private Vector3 movementDelta;

	[Header("Follow Parameters")]
	[SerializeField]
	private float followSpeed = 30f;

	[Header("Rotation Parameters")]
	[SerializeField]
	private float rotationAmount = 20f;

	[SerializeField]
	private float rotationSpeed = 20f;

	private void Update()
	{
		SmoothFollow();
		FollowRotation();
	}

	private void SmoothFollow()
	{
		base.transform.position = Vector3.Lerp(base.transform.position, cardTransform.position, followSpeed * Time.deltaTime);
	}

	private void FollowRotation()
	{
		Vector3 vector = base.transform.position - cardTransform.position;
		movementDelta = Vector3.Lerp(movementDelta, vector, 25f * Time.deltaTime);
		Vector3 b = vector * rotationAmount;
		rotationDelta = Vector3.Lerp(rotationDelta, b, rotationSpeed * Time.deltaTime);
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, base.transform.eulerAngles.y, Mathf.Clamp(rotationDelta.x, -60f, 60f));
	}
}
