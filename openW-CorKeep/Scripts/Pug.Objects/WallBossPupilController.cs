using Pug.UnityExtensions;
using UnityEngine;

public class WallBossPupilController : MonoBehaviour
{
	public Transform pupil;

	[Min(0f)]
	public float panSpeed = 4f;

	[Min(0f)]
	public float panLinger = 10f;

	[Min(0f)]
	public float motionSmear = 0.0015f;

	[HideInInspector]
	public float deathTime = -1f;

	[HideInInspector]
	public bool centerPupil;

	private float m_centerPupilTime;

	private float GetYaw(float time)
	{
		return MathUtilities.SteepCosine(time * panSpeed, panLinger) * 30f;
	}

	public void UpdateAnimation()
	{
		float num = 0.05f;
		float num2 = GetYaw(Time.time);
		float num3 = Mathf.Abs(num2 - GetYaw(Time.time - num)) / num;
		if (centerPupil && m_centerPupilTime < 0f)
		{
			m_centerPupilTime = Time.time;
		}
		else if (!centerPupil)
		{
			m_centerPupilTime = -1f;
		}
		if (m_centerPupilTime > 0f)
		{
			float num4 = Mathf.Exp((0f - (Time.time - m_centerPupilTime)) * 4f);
			num2 *= num4;
			num3 *= num4;
		}
		pupil.localEulerAngles = new Vector3(0f, 0f, num2);
		pupil.localScale = new Vector3(1f + num3 * motionSmear, 1f, 1f);
	}
}
