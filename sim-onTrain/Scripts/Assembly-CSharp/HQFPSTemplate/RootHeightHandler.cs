using System;
using System.Collections;
using UnityEngine;

namespace HQFPSTemplate
{
	public class RootHeightHandler : PlayerComponent
	{
		[Serializable]
		private class HeightChangeState
		{
			[Range(-2f, 0f)]
			public float CameraOffset;

			public EasingOptions Easing;
		}

		[SerializeField]
		[Group]
		private HeightChangeState m_CrouchState;

		[SerializeField]
		[Group]
		private HeightChangeState m_ProneState;

		private HeightChangeState m_CurrentState;

		private float m_CurrentOffsetOnY;

		private float m_InitialHeight;

		private Easer m_HeightEaser;

		private void Start()
		{
			base.Player.Crouch.AddStartListener(delegate
			{
				OnControllerHeightChange(m_CrouchState);
			});
			base.Player.Crouch.AddStopListener(delegate
			{
				OnControllerHeightChange(null);
			});
			base.Player.Prone.AddStartListener(delegate
			{
				OnControllerHeightChange(m_ProneState);
			});
			base.Player.Prone.AddStopListener(delegate
			{
				OnControllerHeightChange(null);
			});
			m_InitialHeight = base.transform.localPosition.y;
		}

		private void OnControllerHeightChange(HeightChangeState heightChangeState)
		{
			float verticalOffset = 0f;
			if (heightChangeState != null)
			{
				float duration = heightChangeState.Easing.Duration;
				if (m_CurrentState != null)
				{
					duration = Mathf.Abs(m_CurrentState.Easing.Duration - heightChangeState.Easing.Duration);
				}
				m_HeightEaser = new Easer(heightChangeState.Easing.Function, duration);
				verticalOffset = heightChangeState.CameraOffset;
			}
			m_CurrentState = heightChangeState;
			StopAllCoroutines();
			StartCoroutine(SetVerticalOffset(verticalOffset));
		}

		private IEnumerator SetVerticalOffset(float offset)
		{
			float startOffset = m_CurrentOffsetOnY;
			m_HeightEaser.Reset();
			while (m_HeightEaser.InterpolatedValue < 1f)
			{
				m_HeightEaser.Update(Time.deltaTime);
				m_CurrentOffsetOnY = Mathf.Lerp(startOffset, offset, m_HeightEaser.InterpolatedValue);
				base.transform.localPosition = Vector3.up * (m_CurrentOffsetOnY + m_InitialHeight);
				yield return null;
			}
		}
	}
}
