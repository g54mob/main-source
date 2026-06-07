using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace VampireSurvivors.Tools
{
	public static class TweenExtensions
	{
		public static Tween SetGameId(this Tween tween)
		{
			return null;
		}

		public static Sequence SetGameId(this Sequence tween)
		{
			return null;
		}

		public static Tween SetGameIdPaused(this Tween tween)
		{
			return null;
		}

		public static Sequence SetGameIdPaused(this Sequence tween)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void KillIfAlive(this Tween tween)
		{
		}

		public static void CompleteIfAlive(this Tween tween)
		{
		}

		public static Tweener DOFade(this Tilemap target, float endValue, float duration)
		{
			return null;
		}

		public static Tweener DoTint(this Tilemap target, Color endColour, float duration)
		{
			return null;
		}
	}
}
