using System;
using UnityEngine;

namespace Assets.Scripts.Analysis.Analytics
{
	public class UnityAnalyticsScript : MonoBehaviour
	{
		private DateTime _lastActivityTime;

		protected virtual void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			ActivateApp();
		}

		protected virtual void Update()
		{
			if (UnityEngine.Input.anyKeyDown || UnityEngine.Input.touchCount > 0)
			{
				_lastActivityTime = DateTime.Now;
			}
			if (DateTime.Now - _lastActivityTime > TimeSpan.FromMinutes(5.0))
			{
				UnityAnalytics.PauseTimer();
			}
			else
			{
				UnityAnalytics.ResumeTimer();
			}
		}

		private void ActivateApp()
		{
		}
	}
}
