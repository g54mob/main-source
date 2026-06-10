using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.TaskManager;
using UnityEngine;

namespace NSMedieval
{
	public static class QuickWiggleEffect
	{
		private static readonly HashSet<Transform> CurrentObjects = new HashSet<Transform>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			CurrentObjects.Clear();
		}

		public static void WiggleX(Transform transform, float duration = 0.5f, float distance = 2f)
		{
			if (transform == null || !CurrentObjects.Add(transform))
			{
				return;
			}
			Vector3 localPosStart = transform.localPosition;
			Task task = new Task();
			task.DoForTime(delegate(float progress)
			{
				if (transform == null)
				{
					task.Stop();
					CurrentObjects.Remove(transform);
				}
				else
				{
					float num = Mathf.Sin(MathF.PI * 2f * progress) * distance;
					transform.localPosition = new Vector3(localPosStart.x + num, localPosStart.y, localPosStart.z);
					if (progress >= 1f)
					{
						CurrentObjects.Remove(transform);
						transform.localPosition = localPosStart;
						transform = null;
					}
				}
			}, duration);
			MonoSingleton<TaskController>.Instance.EnqueueCustomTask(task);
		}
	}
}
