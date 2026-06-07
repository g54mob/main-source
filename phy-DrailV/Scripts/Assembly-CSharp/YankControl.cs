using UnityEngine;

public class YankControl : MonoBehaviour
{
	private const int UP = 1;

	private const int DOWN = -1;

	[Tooltip("x-axis should be in [0-1] range")]
	public AnimationCurve positionDiffToTorque;

	[Header("Debug (read-only)")]
	[Range(-1f, 1f)]
	public float currentPosition;

	[Range(-1f, 1f)]
	public float targetPosition;

	public bool engaged;

	public float currentVelocity;

	public float outputTorque;

	public int direction = 1;

	public bool actingAgainst;

	private void Update()
	{
		currentPosition += currentVelocity * (float)direction * Time.deltaTime;
		bool num = currentPosition >= 1f || currentPosition <= -1f;
		currentPosition = Mathf.Clamp(currentPosition, -1f, 1f);
		if (num)
		{
			direction *= -1;
		}
		if (engaged)
		{
			float f = targetPosition - currentPosition;
			float num2 = positionDiffToTorque.Evaluate(Mathf.Abs(f) / 2f);
			outputTorque = num2 * Mathf.Sign(f) * (float)direction;
			actingAgainst = Mathf.Sign(outputTorque) != Mathf.Sign(currentVelocity);
		}
		else
		{
			outputTorque = 0f;
			actingAgainst = false;
		}
	}
}
