using System;
using UnityEngine;
using XUGL;

namespace XCharts.Runtime
{
	public static class AnimationStyleHelper
	{
		public static float CheckDataAnimation(BaseChart chart, Serie serie, int dataIndex, float destProgress, float startPorgress = 0f)
		{
			if (!serie.animation.IsDataAnimation())
			{
				serie.animation.context.isAllItemAnimationEnd = false;
				return destProgress;
			}
			if (serie.animation.IsFinish())
			{
				serie.animation.context.isAllItemAnimationEnd = false;
				return destProgress;
			}
			bool isEnd = true;
			float result = serie.animation.CheckItemProgress(dataIndex, destProgress, ref isEnd, startPorgress);
			if (!isEnd)
			{
				serie.animation.context.isAllItemAnimationEnd = false;
			}
			return result;
		}

		public static void UpdateSerieAnimation(Serie serie)
		{
			Type type = serie.GetType();
			AnimationType defaultType = AnimationType.LeftToRight;
			bool enableSerieDataAnimation = true;
			if (type.IsDefined(typeof(DefaultAnimationAttribute), inherit: false))
			{
				DefaultAnimationAttribute attribute = type.GetAttribute<DefaultAnimationAttribute>();
				defaultType = attribute.type;
				enableSerieDataAnimation = attribute.enableSerieDataAddedAnimation;
			}
			UpdateAnimationType(serie.animation, defaultType, enableSerieDataAnimation);
		}

		public static void UpdateAnimationType(AnimationStyle animation, AnimationType defaultType, bool enableSerieDataAnimation)
		{
			animation.context.type = ((animation.type == AnimationType.Default) ? defaultType : animation.type);
			animation.context.enableSerieDataAddedAnimation = enableSerieDataAnimation;
		}

		public static bool GetAnimationPosition(AnimationStyle animation, bool isY, Vector3 lp, Vector3 cp, float progress, ref Vector3 ip)
		{
			if (animation.context.type == AnimationType.AlongPath)
			{
				float num = Vector3.Distance(lp, cp);
				float t = (num - animation.context.currentPathDistance + animation.GetCurrDetail()) / num;
				ip = Vector3.Lerp(lp, cp, t);
				return true;
			}
			Vector3 p = (isY ? new Vector3(-10000f, progress) : new Vector3(progress, -10000f));
			Vector3 p2 = (isY ? new Vector3(10000f, progress) : new Vector3(progress, 10000f));
			return UGLHelper.GetIntersection(lp, cp, p, p2, ref ip);
		}
	}
}
