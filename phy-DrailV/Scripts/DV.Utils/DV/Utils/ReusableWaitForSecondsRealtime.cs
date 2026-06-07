using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Utils
{
	public class ReusableWaitForSecondsRealtime : IEnumerator
	{
		private static readonly Stack<ReusableWaitForSecondsRealtime> cache = new Stack<ReusableWaitForSecondsRealtime>();

		private float waitUntilTime = -1f;

		private float waitTime;

		public object Current => null;

		public static ReusableWaitForSecondsRealtime New(float time)
		{
			ReusableWaitForSecondsRealtime obj = ((cache.Count > 0) ? cache.Pop() : new ReusableWaitForSecondsRealtime());
			obj.waitTime = time;
			return obj;
		}

		private ReusableWaitForSecondsRealtime()
		{
		}

		public bool MoveNext()
		{
			if (waitUntilTime < 0f)
			{
				waitUntilTime = Time.realtimeSinceStartup + waitTime;
			}
			bool num = Time.realtimeSinceStartup < waitUntilTime;
			if (!num)
			{
				Reset();
			}
			return num;
		}

		public void Reset()
		{
			waitUntilTime = -1f;
			cache.Push(this);
		}
	}
}
