using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public static class AnimationExtensions
	{
		internal static string GetNextTweenKey(this Transform transform, IStateProvider provider)
		{
			return null;
		}

		public static void Forward(this Tweener tweener, IStateProvider provider = null)
		{
		}

		public static void Forward(this Transform transform, IStateProvider provider = null)
		{
		}
	}
}
