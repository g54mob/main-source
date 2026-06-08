using System.Collections;
using UnityEngine;

public class Eye : MonoBehaviour
{
	public static WaitForSeconds EYE_WAIT_TIME = new WaitForSeconds(0.01f);

	[SerializeField]
	private float topRadius;

	[SerializeField]
	private float leftRadius;

	[SerializeField]
	private Transform eyeCopy;

	[SerializeField]
	private float lerpSpeed = 0.1f;

	public void CalculateVectorFromMouse(Vector3 mousePosition)
	{
		Vector3 vector = Camera.main.ScreenToWorldPoint(mousePosition) - eyeCopy.position;
		vector.Normalize();
		float theta = Mathf.Atan2(vector.y, vector.x);
		float num = CalculateEllipseRadius(leftRadius, topRadius, theta);
		Vector3 b = eyeCopy.position + vector * num;
		base.transform.position = Vector3.Lerp(base.transform.position, b, lerpSpeed);
	}

	public static float CalculateEllipseRadius(float a, float b, float theta)
	{
		float num = Mathf.Cos(theta);
		float num2 = Mathf.Sin(theta);
		float num3 = Mathf.Sqrt(b * b * num * num + a * a * num2 * num2);
		return a * b / num3;
	}

	public void ResetPosition()
	{
		StartCoroutine(ResetPositionRoutine(0.3f));
	}

	public IEnumerator ResetPositionRoutine(float duration)
	{
		float timeElapsed = 0f;
		while (timeElapsed < duration && !AssistantSpawner.IsLooking())
		{
			float t = timeElapsed / duration;
			base.transform.position = Vector3.Lerp(base.transform.position, eyeCopy.position, t);
			timeElapsed += Time.deltaTime;
			yield return EYE_WAIT_TIME;
		}
		if (!AssistantSpawner.IsLooking())
		{
			base.transform.position = eyeCopy.position;
		}
	}
}
