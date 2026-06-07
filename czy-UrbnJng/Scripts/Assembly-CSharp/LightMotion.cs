using UnityEngine;

public class LightMotion : MonoBehaviour
{
	[SerializeField]
	private Vector2 m_cycleDurationXZ = new Vector2(20f, 20f);

	[SerializeField]
	private AnimationCurve m_movementPathX;

	[SerializeField]
	private AnimationCurve m_movementPathZ;

	[SerializeField]
	private Vector2 m_movementMagnitudeXZ = new Vector2(1f, 1f);

	[SerializeField]
	private Vector2 m_movementTimeOffsetXZ;

	private Vector3 m_initialPosition;

	private void Awake()
	{
		m_initialPosition = base.transform.position;
	}

	private void Update()
	{
		UpdateMotion();
	}

	private void UpdateMotion()
	{
		float num = Time.time % m_cycleDurationXZ.x;
		num /= m_cycleDurationXZ.x;
		float num2 = Time.time % m_cycleDurationXZ.y;
		num2 /= m_cycleDurationXZ.y;
		float x = m_movementPathX.Evaluate(num + m_movementTimeOffsetXZ.x) * m_movementMagnitudeXZ.x;
		float z = m_movementPathZ.Evaluate(num2 + m_movementTimeOffsetXZ.y) * m_movementMagnitudeXZ.y;
		base.transform.position = m_initialPosition + new Vector3(x, 0f, z);
	}
}
