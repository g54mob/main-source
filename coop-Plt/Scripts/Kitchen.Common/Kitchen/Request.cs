using System;
using System.Collections;
using UnityEngine;

namespace Kitchen
{
	public static class Request
	{
		private static int LastFrame;

		private const int MaxPerFrame = 2;

		private static int RemainingThisFrame;

		public static IEnumerator Snapshot(int cache_id, Action callback)
		{
			while (!PrefabSnapshot.HasSnapshot(cache_id) && RemainingThisFrame <= 0 && LastFrame == Time.frameCount)
			{
				yield return null;
			}
			if (LastFrame != Time.frameCount)
			{
				RemainingThisFrame = 2;
			}
			RemainingThisFrame--;
			LastFrame = Time.frameCount;
			callback();
		}
	}
}
