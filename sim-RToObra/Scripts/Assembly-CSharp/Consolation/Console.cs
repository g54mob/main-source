using System.Collections.Generic;
using UnityEngine;

namespace Consolation
{
	internal class Console : MonoBehaviour
	{
		private struct Log
		{
			public string message;

			public string stackTrace;

			public LogType type;
		}

		public KeyCode toggleKey = KeyCode.BackQuote;

		public bool shakeToOpen = true;

		public float shakeAcceleration = 3f;

		private readonly List<Log> logs = new List<Log>();

		private Vector2 scrollPosition;

		private bool visible;

		private bool collapse;

		private static readonly Dictionary<LogType, Color> logTypeColors = new Dictionary<LogType, Color>
		{
			{
				LogType.Assert,
				Color.white
			},
			{
				LogType.Error,
				Color.red
			},
			{
				LogType.Exception,
				Color.red
			},
			{
				LogType.Log,
				Color.white
			},
			{
				LogType.Warning,
				Color.yellow
			}
		};

		private const string windowTitle = "Console";

		private const int margin = 20;

		private static readonly GUIContent clearLabel = new GUIContent("Clear", "Clear the contents of the console.");

		private static readonly GUIContent collapseLabel = new GUIContent("Collapse", "Hide repeated messages.");

		private readonly Rect titleBarRect = new Rect(0f, 0f, 10000f, 20f);

		private Rect windowRect = new Rect(20f, 20f, Screen.width - 40, Screen.height - 40);

		private void OnEnable()
		{
			Application.logMessageReceived += HandleLog;
		}

		private void OnDisable()
		{
			Application.logMessageReceived -= HandleLog;
		}

		private void Update()
		{
			if (Input.GetKeyDown(toggleKey))
			{
				visible = !visible;
			}
			if (shakeToOpen && Input.acceleration.sqrMagnitude > shakeAcceleration)
			{
				visible = true;
			}
		}

		private void OnGUI()
		{
			if (visible)
			{
				windowRect = GUILayout.Window(123456, windowRect, ConsoleWindow, "Console");
			}
		}

		private void ConsoleWindow(int windowID)
		{
			scrollPosition = GUILayout.BeginScrollView(scrollPosition);
			for (int i = 0; i < logs.Count; i++)
			{
				Log log = logs[i];
				if (!collapse || i <= 0 || !(log.message == logs[i - 1].message))
				{
					GUI.contentColor = logTypeColors[log.type];
					GUILayout.Label(log.message);
				}
			}
			GUILayout.EndScrollView();
			GUI.contentColor = Color.white;
			GUILayout.BeginHorizontal();
			if (GUILayout.Button(clearLabel))
			{
				logs.Clear();
			}
			collapse = GUILayout.Toggle(collapse, collapseLabel, GUILayout.ExpandWidth(false));
			GUILayout.EndHorizontal();
			GUI.DragWindow(titleBarRect);
		}

		private void HandleLog(string message, string stackTrace, LogType type)
		{
			logs.Add(new Log
			{
				message = message,
				stackTrace = stackTrace,
				type = type
			});
			scrollPosition.y = 2.1474836E+09f;
		}
	}
}
