using UnityEngine;

public class Indicator : MonoBehaviour
{
	public float m_Scale;

	public float m_Offset;

	public Vector3 m_VecScale;

	public Vector3 m_Position;

	protected void Awake()
	{
		m_Scale = 1f;
		m_Offset = 0f;
		m_VecScale = default(Vector3);
		m_Position = default(Vector3);
	}

	protected virtual void UpdateTransform(Vector3 WorldPosition)
	{
		if (CameraManager.Instance == null || CameraManager.Instance.m_Camera == null)
		{
			return;
		}
		Vector3 vector = CameraManager.Instance.m_Camera.transform.position - WorldPosition;
		vector.x = 0f;
		float num = 1f / vector.magnitude;
		float num2 = num * 20f * m_Scale;
		if (num2 < 10f)
		{
			m_VecScale.x = num2;
			m_VecScale.y = num2;
			m_VecScale.z = num2;
			base.transform.localScale = m_VecScale;
			Vector3 position = CameraManager.Instance.m_Camera.WorldToScreenPoint(WorldPosition);
			if (position.z > 0f)
			{
				m_Position.y = 20f * m_Offset;
				if ((bool)HudManager.Instance)
				{
					base.transform.localPosition = HudManager.Instance.ScreenToCanvas(position) + m_Position * num;
				}
			}
			else
			{
				base.transform.localScale = Vector3.zero;
			}
		}
		else
		{
			base.transform.localScale = Vector3.zero;
		}
	}
}
