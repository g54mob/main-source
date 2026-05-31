using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[Since("v3.8.0")]
	public class AnimationInfo
	{
		[SerializeField]
		[Since("v3.8.0")]
		private bool m_Enable = true;

		[SerializeField]
		[Since("v3.8.0")]
		private bool m_Reverse;

		[SerializeField]
		[Since("v3.8.0")]
		private float m_Delay;

		[SerializeField]
		[Since("v3.8.0")]
		private float m_Duration = 1000f;

		public AnimationInfoContext context = new AnimationInfoContext();

		public bool enable
		{
			get
			{
				return m_Enable;
			}
			set
			{
				m_Enable = value;
			}
		}

		public bool reverse
		{
			get
			{
				return m_Reverse;
			}
			set
			{
				m_Reverse = value;
			}
		}

		public float delay
		{
			get
			{
				return m_Delay;
			}
			set
			{
				m_Delay = value;
			}
		}

		public float duration
		{
			get
			{
				return m_Duration;
			}
			set
			{
				m_Duration = value;
			}
		}

		public Action OnAnimationStart { get; set; }

		public Action OnAnimationEnd { get; set; }

		public AnimationDelayFunction delayFunction { get; set; }

		public AnimationDurationFunction durationFunction { get; set; }

		public void Reset()
		{
			if (enable)
			{
				context.init = false;
				context.start = false;
				context.pause = false;
				context.end = false;
				context.startTime = 0f;
				context.currProgress = 0f;
				context.destProgress = 0f;
				context.totalProgress = 0f;
				context.sizeProgress = 0f;
				context.currPointIndex = 0;
				context.currPoint = Vector3.zero;
				context.destPoint = Vector3.zero;
				context.dataCurrProgress.Clear();
				context.dataDestProgress.Clear();
			}
		}

		public void Start(bool reset = true)
		{
			if (!enable)
			{
				return;
			}
			if (context.start)
			{
				context.pause = false;
				return;
			}
			context.init = false;
			context.start = true;
			context.end = false;
			context.pause = false;
			context.startTime = Time.time;
			if (reset)
			{
				context.currProgress = 0f;
				context.destProgress = 1f;
				context.totalProgress = 0f;
				context.sizeProgress = 0f;
				context.dataCurrProgress.Clear();
				context.dataDestProgress.Clear();
			}
			if (OnAnimationStart != null)
			{
				OnAnimationStart();
			}
		}

		public void Pause()
		{
			if (enable && context.start && !context.end)
			{
				context.pause = true;
			}
		}

		public void Resume()
		{
			if (enable && context.pause)
			{
				context.pause = false;
			}
		}

		public void End()
		{
			if (enable && context.start && !context.end)
			{
				context.start = false;
				context.end = true;
				context.currPointIndex = context.destPointIndex;
				context.startTime = Time.time;
				if (OnAnimationEnd != null)
				{
					OnAnimationEnd();
				}
			}
		}

		public bool Init(float curr, float dest, int totalPointIndex)
		{
			if (!enable || !context.start)
			{
				return false;
			}
			if (context.init || context.end)
			{
				return false;
			}
			context.init = true;
			context.totalProgress = dest - curr;
			context.destPointIndex = totalPointIndex;
			if (reverse)
			{
				context.currProgress = dest;
				context.destProgress = curr;
			}
			else
			{
				context.currProgress = curr;
				context.destProgress = dest;
			}
			return true;
		}

		public bool IsFinish()
		{
			if (!context.start)
			{
				return true;
			}
			if (context.end)
			{
				return true;
			}
			if (context.pause)
			{
				return false;
			}
			if (!context.init)
			{
				return false;
			}
			if (!m_Reverse)
			{
				return context.currProgress >= context.destProgress;
			}
			return context.currProgress <= context.destProgress;
		}

		public bool IsInDelay()
		{
			if (!context.start)
			{
				return false;
			}
			if (m_Delay > 0f)
			{
				return Time.time - context.startTime < m_Delay / 1000f;
			}
			return false;
		}

		public bool IsInIndexDelay(int dataIndex)
		{
			if (context.start)
			{
				return Time.time - context.startTime < GetIndexDelay(dataIndex) / 1000f;
			}
			return false;
		}

		public float GetIndexDelay(int dataIndex)
		{
			if (!context.start)
			{
				return 0f;
			}
			if (delayFunction != null)
			{
				return delayFunction(dataIndex);
			}
			return delay;
		}

		internal float GetCurrAnimationDuration(int dataIndex = -1)
		{
			if (dataIndex >= 0 && context.start && durationFunction != null)
			{
				return durationFunction(dataIndex) / 1000f;
			}
			if (!(m_Duration > 0f))
			{
				return 1f;
			}
			return m_Duration / 1000f;
		}

		internal void SetDataCurrProgress(int index, float state)
		{
			context.dataCurrProgress[index] = state;
		}

		internal float GetDataCurrProgress(int index, float initValue, float destValue, ref bool isBarEnd)
		{
			if (IsInDelay())
			{
				isBarEnd = false;
				return initValue;
			}
			bool flag = !context.dataCurrProgress.ContainsKey(index);
			bool flag2 = !context.dataDestProgress.ContainsKey(index);
			if (flag || flag2)
			{
				if (flag)
				{
					context.dataCurrProgress.Add(index, initValue);
				}
				if (flag2)
				{
					context.dataDestProgress.Add(index, destValue);
				}
				isBarEnd = false;
			}
			else
			{
				isBarEnd = context.dataCurrProgress[index] == context.dataDestProgress[index];
			}
			return context.dataCurrProgress[index];
		}

		internal void CheckProgress(double total, bool m_UnscaledTime)
		{
			if (!context.start || !context.init || context.pause || IsInDelay())
			{
				return;
			}
			float currAnimationDuration = GetCurrAnimationDuration();
			float num = (float)(total / (double)currAnimationDuration * (double)(m_UnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime));
			if (reverse)
			{
				context.currProgress -= num;
				if (context.currProgress <= context.destProgress)
				{
					context.currProgress = context.destProgress;
					End();
				}
			}
			else
			{
				context.currProgress += num;
				if (context.currProgress >= context.destProgress)
				{
					context.currProgress = context.destProgress;
					End();
				}
			}
		}

		internal float CheckItemProgress(int dataIndex, float destProgress, ref bool isEnd, float startProgress, bool m_UnscaledTime)
		{
			if (m_Reverse)
			{
				float num = startProgress;
				startProgress = destProgress;
				destProgress = num;
			}
			float dataCurrProgress = GetDataCurrProgress(dataIndex, startProgress, destProgress, ref isEnd);
			if (IsFinish())
			{
				return destProgress;
			}
			if (IsInDelay() || IsInIndexDelay(dataIndex))
			{
				return startProgress;
			}
			if (context.pause)
			{
				return dataCurrProgress;
			}
			float currAnimationDuration = GetCurrAnimationDuration(dataIndex);
			float num2 = (destProgress - startProgress) / currAnimationDuration * (m_UnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
			dataCurrProgress += num2;
			if (reverse)
			{
				if ((destProgress > 0f && dataCurrProgress <= 0f) || (destProgress < 0f && dataCurrProgress >= 0f))
				{
					dataCurrProgress = 0f;
					isEnd = true;
				}
			}
			else if ((destProgress - startProgress > 0f && dataCurrProgress > destProgress) || (destProgress - startProgress < 0f && dataCurrProgress < destProgress))
			{
				dataCurrProgress = destProgress;
				isEnd = true;
			}
			SetDataCurrProgress(dataIndex, dataCurrProgress);
			return dataCurrProgress;
		}

		internal void CheckSymbol(float dest, bool m_UnscaledTime)
		{
			if (!context.start || !context.init || context.pause || IsInDelay())
			{
				return;
			}
			float currAnimationDuration = GetCurrAnimationDuration();
			float num = dest / currAnimationDuration * (m_UnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
			if (reverse)
			{
				context.sizeProgress -= num;
				if (context.sizeProgress < 0f)
				{
					context.sizeProgress = 0f;
				}
			}
			else
			{
				context.sizeProgress += num;
				if (context.sizeProgress > dest)
				{
					context.sizeProgress = dest;
				}
			}
		}
	}
}
