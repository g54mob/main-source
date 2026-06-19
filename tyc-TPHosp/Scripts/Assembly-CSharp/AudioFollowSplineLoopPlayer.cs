using TH20;
using UnityEngine;

public class AudioFollowSplineLoopPlayer : AudioLoopPlayer
{
	[SerializeField]
	private Vector3[] m_controlPoints;

	private readonly float LargeDistanceValue = 1000000f;

	private void Start()
	{
		UpdateLocation();
	}

	protected override void Update()
	{
		base.Update();
		UpdateLocation();
	}

	private void UpdateLocation()
	{
		Camera main = Camera.main;
		if (main == null)
		{
			return;
		}
		Vector3[] controlPoints = m_controlPoints;
		if (controlPoints != null && controlPoints.Length < 2)
		{
			return;
		}
		Vector3 position = main.transform.position;
		Vector3 lineVector = main.transform.forward * LargeDistanceValue;
		Vector3 controlPoint = GetControlPoint(0);
		Vector3 vector = controlPoint;
		Vector3 position2 = Vector3.zero;
		float num = float.MaxValue;
		for (int i = 1; i < m_controlPoints.Length; i++)
		{
			controlPoint = vector;
			vector = GetControlPoint(i);
			if (MathUtils.NearestPointsOnTwoLines(out var closestPointLine, out var _, controlPoint, vector - controlPoint, position, lineVector, mustBeOnLines: true))
			{
				Vector3 vector2 = closestPointLine;
				float sqrMagnitude = (position - vector2).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					position2 = vector2;
					num = sqrMagnitude;
				}
			}
		}
		if (num < float.MaxValue)
		{
			SourceGameObject.transform.position = position2;
		}
	}

	public int GetControlPointCount()
	{
		if (m_controlPoints == null)
		{
			return 0;
		}
		return m_controlPoints.Length;
	}

	public Vector3 GetControlPoint(int i)
	{
		return base.transform.TransformPoint(m_controlPoints[i]);
	}
}
