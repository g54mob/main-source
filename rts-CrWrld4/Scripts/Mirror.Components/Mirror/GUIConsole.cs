using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	public class GUIConsole : MonoBehaviour
	{
		public int height;

		public int maxLogCount;

		private Queue<LogEntry> log;

		public KeyCode hotKey;

		private bool visible;

		private Vector2 scroll;

		private void Awake()
		{
		}

		private void OnLog(string message, string stackTrace, LogType type)
		{
		}

		private void Update()
		{
		}

		private void OnGUI()
		{
		}
	}
}
