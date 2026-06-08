using System;
using LaundryBear.Math;
using UnityEngine;

public class PolarInput
{
	public delegate Vector2 PollJoystickInput();

	private const int DEFAULT_QUEUE_CAPACITY = 8;

	private const float DEFAULT_NOISE_FILTER = 0.25f;

	private PollJoystickInput m_axesDelegate;

	private Vector2 m_previousRawInput;

	private StatisticalFloatQueue m_velocityQueue;

	private float m_noiseFilter;

	public float AngularVelocitySmoothed => m_velocityQueue.GetAverage();

	public float AngularVelocity => m_velocityQueue.GetMostRecent();

	public float Angle => Mathf.Atan2(m_previousRawInput.y, m_previousRawInput.x);

	public float SquareMagnitude => m_previousRawInput.sqrMagnitude;

	public float Magnitude => m_previousRawInput.magnitude;

	public PolarInput(PollJoystickInput axesDelegate)
		: this(axesDelegate, 0.25f, 8)
	{
	}

	public PolarInput(PollJoystickInput axesDelegate, float noiseFilter)
		: this(axesDelegate, noiseFilter, 8)
	{
	}

	public PolarInput(PollJoystickInput axesDelegate, float noiseFilter, int smoothingQuality)
	{
		m_velocityQueue = new StatisticalFloatQueue(smoothingQuality);
		m_noiseFilter = noiseFilter;
		m_axesDelegate = axesDelegate;
	}

	public void Update(float deltaTime)
	{
		Vector2 previousRawInput = m_axesDelegate();
		if (previousRawInput.sqrMagnitude < m_noiseFilter)
		{
			previousRawInput = Vector2.zero;
		}
		float num = Mathf.Atan2(previousRawInput.y, previousRawInput.x);
		float num2 = Mathf.Atan2(m_previousRawInput.y, m_previousRawInput.x);
		float num3 = num;
		if (num < 0f)
		{
			num3 = num + MathF.PI * 2f;
		}
		float num4 = num2;
		if (num2 < 0f)
		{
			num4 = num2 + MathF.PI * 2f;
		}
		float num5 = 0f;
		num5 = num3 - num4;
		if (Mathf.Abs(num5) > MathF.PI)
		{
			num5 -= Mathf.Sign(num5) * MathF.PI * 2f;
		}
		m_velocityQueue.AddValue(num5 / deltaTime);
		m_previousRawInput = previousRawInput;
	}
}
