using Dreamteck.Splines;
using UnityEngine;

public class Queue : MonoBehaviour
{
	[SerializeField]
	private SplineComputer m_Spline;

	[SerializeField]
	private int m_QueueLength;

	public int Length => 0;

	public TransformData GetQueuePosition(int queueIndex)
	{
		return null;
	}
}
