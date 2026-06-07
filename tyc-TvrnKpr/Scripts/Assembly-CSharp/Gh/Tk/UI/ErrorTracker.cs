using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class ErrorTracker : MonoBehaviour
	{
		private static int _secondsToTrack;

		private static int _errorThreshold;

		private static List<int> _recentErrors;

		private int _lastSecondsIndex;

		public static bool IsPossiblyCorrupted { get; private set; }

		public static void ResetTracker()
		{
		}

		private void SaveLoadManagerOnPreLoadEvent(object sender, EventArgs e)
		{
		}

		private void Application_logMessageReceived(string errorMessage, string stackTrace, LogType type)
		{
		}

		private void Update()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
