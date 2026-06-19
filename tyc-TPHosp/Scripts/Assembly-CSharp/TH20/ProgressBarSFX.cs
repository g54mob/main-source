using System;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	[DisallowMultipleComponent]
	public class ProgressBarSFX : MonoBehaviour
	{
		[SerializeField]
		private string _loopRoundUpwardsSoundEvent;

		[SerializeField]
		private string _loopRoundDownwardsSoundEvent;

		private ProgressBarMaskable ProgressBarMaskable;

		private int _frameCount;

		private void OnEnable()
		{
			_frameCount = Time.frameCount;
			ProgressBarMaskable = GetComponent<ProgressBarMaskable>();
			if (ProgressBarMaskable != null)
			{
				ProgressBarMaskable progressBarMaskable = ProgressBarMaskable;
				progressBarMaskable.OnLoopRound = (Action<int, int>)Delegate.Combine(progressBarMaskable.OnLoopRound, new Action<int, int>(OnLoopRound));
			}
		}

		private void OnDisable()
		{
			ProgressBarMaskable = GetComponent<ProgressBarMaskable>();
			if (ProgressBarMaskable != null)
			{
				ProgressBarMaskable progressBarMaskable = ProgressBarMaskable;
				progressBarMaskable.OnLoopRound = (Action<int, int>)Delegate.Remove(progressBarMaskable.OnLoopRound, new Action<int, int>(OnLoopRound));
			}
		}

		private void OnLoopRound(int previous, int current)
		{
			if (Time.frameCount - _frameCount < 10)
			{
				return;
			}
			if (previous < current)
			{
				if (!_loopRoundUpwardsSoundEvent.IsNullOrEmpty())
				{
					AudioManager.Instance.Play(_loopRoundUpwardsSoundEvent);
				}
			}
			else if (!_loopRoundDownwardsSoundEvent.IsNullOrEmpty())
			{
				AudioManager.Instance.Play(_loopRoundDownwardsSoundEvent);
			}
		}
	}
}
