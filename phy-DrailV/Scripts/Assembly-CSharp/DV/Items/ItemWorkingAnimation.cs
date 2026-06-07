using System;
using System.Collections;
using UnityEngine;

namespace DV.Items
{
	public class ItemWorkingAnimation : MonoBehaviour
	{
		public float moveInTime;

		public float moveOutTime;

		public float minWorkTime;

		public Func<bool> InputPressedCallback = () => true;

		public Func<bool> WorkDoneCallback = () => false;

		private Coroutine coro;

		public float MoveToWorkProgress { get; private set; }

		public float WorkProgress { get; private set; }

		public float WorkTimer { get; private set; }

		public bool WorkDone { get; set; }

		public bool IsAnimating => coro != null;

		public bool IsWorking
		{
			get
			{
				if (IsAnimating && MoveToWorkProgress == 1f)
				{
					return !WorkDone;
				}
				return false;
			}
		}

		public event Action AnimationStarted;

		public event Action AnimationStopped;

		public event Action WorkStarted;

		public event Action WorkStopped;

		public void StartAnimating()
		{
			StopAnimating();
			coro = StartCoroutine(WorkCoroutine());
		}

		public void StopAnimating()
		{
			if (IsAnimating)
			{
				StopCoroutine(coro);
				coro = null;
				this.AnimationStopped?.Invoke();
			}
		}

		private IEnumerator WorkCoroutine()
		{
			this.AnimationStarted?.Invoke();
			ItemWorkingAnimation itemWorkingAnimation = this;
			ItemWorkingAnimation itemWorkingAnimation2 = this;
			float num = (WorkTimer = 0f);
			float moveToWorkProgress = (itemWorkingAnimation2.WorkProgress = num);
			itemWorkingAnimation.MoveToWorkProgress = moveToWorkProgress;
			WorkDone = false;
			while (MoveToWorkProgress < 1f && InputPressedCallback())
			{
				MoveToWorkProgress = Mathf.MoveTowards(MoveToWorkProgress, 1f, Time.deltaTime / moveInTime);
				yield return null;
			}
			if (MoveToWorkProgress == 1f)
			{
				this.WorkStarted?.Invoke();
				while (true)
				{
					WorkTimer += Time.deltaTime;
					if (minWorkTime != 0f)
					{
						WorkProgress = Mathf.Clamp01(WorkTimer / minWorkTime);
					}
					if (WorkDoneCallback() || !InputPressedCallback() || WorkProgress == 1f)
					{
						break;
					}
					yield return null;
				}
				WorkDone = true;
				this.WorkStopped?.Invoke();
			}
			while (MoveToWorkProgress > 0f)
			{
				MoveToWorkProgress = Mathf.MoveTowards(MoveToWorkProgress, 0f, Time.deltaTime / moveOutTime);
				yield return null;
			}
			StopAnimating();
		}

		public static float EaseInCubic(in float x)
		{
			return x * x * x;
		}

		public static float EaseOutCubic(float x)
		{
			return 1f - Mathf.Pow(1f - x, 3f);
		}

		public static float EaseInOutCubic(float x)
		{
			if (!((double)x < 0.5))
			{
				return 1f - Mathf.Pow(-2f * x + 2f, 3f) / 2f;
			}
			return 4f * x * x * x;
		}
	}
}
