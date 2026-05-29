using System;
using DG.Tweening;
using UnityEngine;

public class OrderNotebookAnimation : MonoBehaviour
{
	[Serializable]
	private struct MovementStep
	{
		public Vector3 Offset;

		public float Duration;

		public Ease Ease;

		public float EaseOvershoot;

		public float InsertOffset;
	}

	[Serializable]
	private struct AnimationParams
	{
		public MovementStep[] Steps;

		public Ease Ease;

		public float DurationScale;

		public AnimationParams(Ease ease = Ease.Unset, float durationScale = 1f)
		{
			Steps = null;
			Ease = default(Ease);
			DurationScale = 0f;
		}
	}

	[SerializeField]
	private Transform m_Graphics;

	[SerializeField]
	private AnimationParams m_PositionParams;

	[SerializeField]
	private AnimationParams m_RotationParams;

	[SerializeField]
	private float m_Direction;

	public void PlayClose(float direction = 1f)
	{
	}

	public void PlayOpen()
	{
	}

	private void Apply(AnimationParams param, Vector3 componentScaleFactor, Func<Vector3, float, Tween> setter)
	{
	}

	public void PlayStack(int stackIndex)
	{
	}

	public static float CalculateStackPosition(int stackIndex)
	{
		return 0f;
	}
}
