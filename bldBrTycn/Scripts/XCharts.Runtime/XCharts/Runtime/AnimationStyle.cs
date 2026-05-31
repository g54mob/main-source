using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class AnimationStyle : ChildComponent
	{
		[SerializeField]
		private bool m_Enable = true;

		[SerializeField]
		private AnimationType m_Type;

		[SerializeField]
		private AnimationEasing m_Easting;

		[SerializeField]
		private int m_Threshold = 2000;

		[SerializeField]
		[Since("v3.4.0")]
		private bool m_UnscaledTime;

		[SerializeField]
		[Since("v3.8.0")]
		private AnimationFadeIn m_FadeIn = new AnimationFadeIn();

		[SerializeField]
		[Since("v3.8.0")]
		private AnimationFadeOut m_FadeOut = new AnimationFadeOut
		{
			reverse = true
		};

		[SerializeField]
		[Since("v3.8.0")]
		private AnimationChange m_Change = new AnimationChange
		{
			duration = 500f
		};

		[SerializeField]
		[Since("v3.8.0")]
		private AnimationAddition m_Addition = new AnimationAddition
		{
			duration = 500f
		};

		[SerializeField]
		[Since("v3.8.0")]
		private AnimationHiding m_Hiding = new AnimationHiding
		{
			duration = 500f
		};

		[SerializeField]
		[Since("v3.8.0")]
		private AnimationInteraction m_Interaction = new AnimationInteraction
		{
			duration = 250f
		};

		[Obsolete("Use animation.fadeIn.delayFunction instead.", true)]
		public AnimationDelayFunction fadeInDelayFunction;

		[Obsolete("Use animation.fadeIn.durationFunction instead.", true)]
		public AnimationDurationFunction fadeInDurationFunction;

		[Obsolete("Use animation.fadeOut.delayFunction instead.", true)]
		public AnimationDelayFunction fadeOutDelayFunction;

		[Obsolete("Use animation.fadeOut.durationFunction instead.", true)]
		public AnimationDurationFunction fadeOutDurationFunction;

		public AnimationStyleContext context;

		private Vector3 m_LinePathLastPos;

		private List<AnimationInfo> m_Animations;

		[Obsolete("Use animation.fadeIn.OnAnimationEnd() instead.", true)]
		public Action fadeInFinishCallback { get; set; }

		[Obsolete("Use animation.fadeOut.OnAnimationEnd() instead.", true)]
		public Action fadeOutFinishCallback { get; set; }

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

		public AnimationType type
		{
			get
			{
				return m_Type;
			}
			set
			{
				m_Type = value;
			}
		}

		public int threshold
		{
			get
			{
				return m_Threshold;
			}
			set
			{
				m_Threshold = value;
			}
		}

		public bool unscaledTime
		{
			get
			{
				return m_UnscaledTime;
			}
			set
			{
				m_UnscaledTime = value;
			}
		}

		public AnimationFadeIn fadeIn => m_FadeIn;

		public AnimationFadeOut fadeOut => m_FadeOut;

		public AnimationChange change => m_Change;

		public AnimationAddition addition => m_Addition;

		public AnimationHiding hiding => m_Hiding;

		public AnimationInteraction interaction => m_Interaction;

		private List<AnimationInfo> animations
		{
			get
			{
				if (m_Animations == null)
				{
					m_Animations = new List<AnimationInfo>();
					m_Animations.Add(m_FadeIn);
					m_Animations.Add(m_FadeOut);
					m_Animations.Add(m_Change);
					m_Animations.Add(m_Addition);
					m_Animations.Add(m_Hiding);
				}
				return m_Animations;
			}
		}

		public AnimationInfo activedAnimation
		{
			get
			{
				foreach (AnimationInfo animation in animations)
				{
					if (animation.context.start)
					{
						return animation;
					}
				}
				return null;
			}
		}

		public void FadeIn()
		{
			if (!m_FadeOut.context.start)
			{
				m_FadeIn.Start();
			}
		}

		public void Restart()
		{
			AnimationInfo animationInfo = activedAnimation;
			Reset();
			animationInfo?.Start();
		}

		public void FadeOut()
		{
			m_FadeOut.Start();
		}

		public void Addition()
		{
			if (enable && !m_FadeIn.context.start && !m_FadeOut.context.start)
			{
				m_Addition.Start(reset: false);
			}
		}

		public void Pause()
		{
			foreach (AnimationInfo animation in animations)
			{
				animation.Pause();
			}
		}

		public void Resume()
		{
			foreach (AnimationInfo animation in animations)
			{
				animation.Resume();
			}
		}

		public void Reset()
		{
			foreach (AnimationInfo animation in animations)
			{
				animation.Reset();
			}
		}

		public void InitProgress(float curr, float dest)
		{
			AnimationInfo animationInfo = activedAnimation;
			if (animationInfo == null)
			{
				return;
			}
			bool flag = animationInfo is AnimationAddition;
			if (IsSerieAnimation())
			{
				if (flag)
				{
					animationInfo.Init(animationInfo.context.currPointIndex, dest, (int)dest - 1);
					return;
				}
				m_Addition.context.currPointIndex = (int)dest - 1;
				animationInfo.Init(curr, dest, (int)dest - 1);
			}
			else
			{
				animationInfo.Init(curr, dest, 0);
			}
		}

		public void InitProgress(List<Vector3> paths, bool isY)
		{
			if (paths.Count < 1)
			{
				return;
			}
			AnimationInfo animationInfo = activedAnimation;
			if (animationInfo == null)
			{
				m_Addition.context.currPointIndex = paths.Count - 1;
				return;
			}
			bool num = animationInfo is AnimationAddition;
			int num2 = 0;
			if (num)
			{
				num2 = ((animationInfo.context.currPointIndex == paths.Count - 1) ? (paths.Count - 2) : animationInfo.context.currPointIndex);
				if (num2 < 0 || num2 > paths.Count - 2)
				{
					num2 = 0;
				}
			}
			else
			{
				m_Addition.context.currPointIndex = paths.Count - 1;
			}
			Vector3 vector = paths[num2];
			Vector3 vector2 = paths[paths.Count - 1];
			if (vector == animationInfo.context.currPoint && vector2 == animationInfo.context.destPoint)
			{
				return;
			}
			animationInfo.context.currPoint = vector;
			animationInfo.context.destPoint = vector2;
			float curr = (isY ? vector.y : vector.x);
			float num3 = (isY ? vector2.y : vector2.x);
			if (context.type == AnimationType.AlongPath)
			{
				curr = 0f;
				num3 = 0f;
				Vector3 b = vector;
				for (int i = 1; i < paths.Count; i++)
				{
					Vector3 vector3 = paths[i];
					num3 += Vector3.Distance(vector3, b);
					b = vector3;
					if (num2 > 0 && i == num2)
					{
						curr = num3;
					}
				}
				m_LinePathLastPos = vector;
				context.currentPathDistance = 0f;
			}
			animationInfo.Init(curr, num3, paths.Count - 1);
		}

		public bool IsEnd()
		{
			foreach (AnimationInfo animation in animations)
			{
				if (animation.context.start)
				{
					return animation.context.end;
				}
			}
			return m_FadeIn.context.end;
		}

		public bool IsFinish()
		{
			if (!m_Enable)
			{
				return true;
			}
			AnimationInfo animationInfo = activedAnimation;
			if (animationInfo != null && animationInfo.context.end)
			{
				return true;
			}
			if (IsSerieAnimation())
			{
				if (m_FadeOut.context.start)
				{
					return m_FadeOut.context.currProgress <= m_FadeOut.context.destProgress;
				}
				if (m_Addition.context.start)
				{
					return m_Addition.context.currProgress >= m_Addition.context.destProgress;
				}
				return m_FadeIn.context.currProgress >= m_FadeIn.context.destProgress;
			}
			if (IsDataAnimation())
			{
				return animationInfo?.context.end ?? true;
			}
			return true;
		}

		public bool IsInDelay()
		{
			return activedAnimation?.IsInDelay() ?? false;
		}

		public bool IsDataAnimation()
		{
			if (context.type != AnimationType.BottomToTop)
			{
				return context.type == AnimationType.InsideOut;
			}
			return true;
		}

		public bool IsSerieAnimation()
		{
			if (context.type != AnimationType.LeftToRight && context.type != AnimationType.AlongPath)
			{
				return context.type == AnimationType.Clockwise;
			}
			return true;
		}

		public bool CheckDetailBreak(float detail)
		{
			if (!IsSerieAnimation())
			{
				return false;
			}
			foreach (AnimationInfo animation in animations)
			{
				if (animation.context.start)
				{
					return !IsFinish() && detail > animation.context.currProgress;
				}
			}
			return false;
		}

		public bool CheckDetailBreak(Vector3 pos, bool isYAxis)
		{
			if (!IsSerieAnimation())
			{
				return false;
			}
			if (IsFinish())
			{
				return false;
			}
			if (context.type == AnimationType.AlongPath)
			{
				context.currentPathDistance += Vector3.Distance(pos, m_LinePathLastPos);
				m_LinePathLastPos = pos;
				return CheckDetailBreak(context.currentPathDistance);
			}
			if (isYAxis)
			{
				return pos.y > GetCurrDetail();
			}
			return pos.x > GetCurrDetail();
		}

		public void CheckProgress()
		{
			if (IsDataAnimation() && context.isAllItemAnimationEnd)
			{
				foreach (AnimationInfo animation in animations)
				{
					animation.End();
				}
				return;
			}
			foreach (AnimationInfo animation2 in animations)
			{
				animation2.CheckProgress(animation2.context.totalProgress, m_UnscaledTime);
			}
		}

		public void CheckProgress(double total)
		{
			if (IsFinish())
			{
				return;
			}
			foreach (AnimationInfo animation in animations)
			{
				animation.CheckProgress(total, m_UnscaledTime);
			}
		}

		internal float CheckItemProgress(int dataIndex, float destProgress, ref bool isEnd, float startProgress = 0f)
		{
			isEnd = false;
			AnimationInfo animationInfo = activedAnimation;
			if (animationInfo == null)
			{
				isEnd = true;
				return destProgress;
			}
			return animationInfo.CheckItemProgress(dataIndex, destProgress, ref isEnd, startProgress, m_UnscaledTime);
		}

		public void CheckSymbol(float dest)
		{
			m_FadeIn.CheckSymbol(dest, m_UnscaledTime);
			m_FadeOut.CheckSymbol(dest, m_UnscaledTime);
		}

		public float GetSysmbolSize(float dest)
		{
			if (!enable)
			{
				return dest;
			}
			if (IsEnd())
			{
				if (!m_FadeOut.context.start)
				{
					return dest;
				}
				return 0f;
			}
			if (!m_FadeOut.context.start)
			{
				return m_FadeIn.context.sizeProgress;
			}
			return m_FadeOut.context.sizeProgress;
		}

		public float GetCurrDetail()
		{
			foreach (AnimationInfo animation in animations)
			{
				if (animation.context.start)
				{
					return animation.context.currProgress;
				}
			}
			return m_FadeIn.context.currProgress;
		}

		public float GetCurrRate()
		{
			if (!enable || IsEnd())
			{
				return 1f;
			}
			if (!m_FadeOut.context.start)
			{
				return m_FadeIn.context.currProgress;
			}
			return m_FadeOut.context.currProgress;
		}

		public int GetCurrIndex()
		{
			if (!enable)
			{
				return -1;
			}
			AnimationInfo animationInfo = activedAnimation;
			if (animationInfo == null)
			{
				return -1;
			}
			return (int)animationInfo.context.currProgress;
		}

		public float GetChangeDuration()
		{
			if (m_Enable && m_Change.enable)
			{
				return m_Change.duration;
			}
			return 0f;
		}

		public float GetAdditionDuration()
		{
			if (m_Enable && m_Addition.enable)
			{
				return m_Addition.duration;
			}
			return 0f;
		}

		public float GetInteractionDuration()
		{
			if (m_Enable && m_Interaction.enable)
			{
				return m_Interaction.duration;
			}
			return 0f;
		}

		public float GetInteractionRadius(float radius)
		{
			if (m_Enable && m_Interaction.enable)
			{
				return m_Interaction.GetRadius(radius);
			}
			return radius;
		}

		public bool HasFadeOut()
		{
			if (enable)
			{
				return m_FadeOut.context.end;
			}
			return false;
		}

		public bool IsFadeIn()
		{
			if (enable)
			{
				return m_FadeIn.context.start;
			}
			return false;
		}

		public bool IsFadeOut()
		{
			if (enable)
			{
				return m_FadeOut.context.start;
			}
			return false;
		}

		public bool CanCheckInteract()
		{
			if (enable && interaction.enable && !IsFadeIn())
			{
				return !IsFadeOut();
			}
			return false;
		}
	}
}
