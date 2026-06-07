using System;
using UnityEngine;

namespace Brewery.Controls3D
{
	public static class Tween3D
	{
		private const int INVALID = -1;

		public static void Cancel(int tweenId)
		{
		}

		public static void CancelAll(GameObject go)
		{
		}

		public static bool IsActive(int tweenId)
		{
			return false;
		}

		public static int ScaleTo(GameObject go, Vector3 target, TweenConfig cfg, int cancelId = -1)
		{
			return 0;
		}

		public static int ScaleIn(GameObject go, TweenConfig cfg, int cancelId = -1)
		{
			return 0;
		}

		public static int ScaleInTo(GameObject go, Vector3 target, TweenConfig cfg, int cancelId = -1)
		{
			return 0;
		}

		public static int ScaleOut(GameObject go, TweenConfig cfg, Action onComplete = null, int cancelId = -1)
		{
			return 0;
		}

		public static int Value(GameObject go, float from, float to, TweenConfig cfg, Action<float> onUpdate, Action onComplete = null, int cancelId = -1)
		{
			return 0;
		}
	}
}
