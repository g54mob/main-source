using System.Diagnostics;
using UnityEngine;
using WeavUtils;

public class DebugGUI : MonoBehaviour
{
	private static bool quitting;

	private bool initialized;

	private static DebugGUI _instance;

	public DebugGUISettings _settings;

	private GraphWindow graphWindow;

	private LogWindow logWindow;

	private static DebugGUI Instance
	{
		get
		{
			if (_instance == null && !quitting)
			{
				_instance = Object.FindObjectOfType<DebugGUI>();
				if (_instance == null && Application.isPlaying)
				{
					_instance = new GameObject("DebugGUI").AddComponent<DebugGUI>();
				}
				if (!_instance.initialized)
				{
					_instance.Init();
				}
			}
			return _instance;
		}
	}

	public static DebugGUISettings Settings => Instance._settings;

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	public static void SetGraphProperties(object key, string label, float min, float max, int group, Color color, bool autoScale)
	{
		if (Settings.enableGraphs)
		{
			Instance.graphWindow.SetGraphProperties(key, label, min, max, group, color, autoScale);
		}
	}

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	public static void Graph(object key, float val)
	{
		if (Settings.enableGraphs)
		{
			Instance.graphWindow.Graph(key, val);
		}
	}

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	public static void RemoveGraph(object key)
	{
		if (Settings.enableGraphs)
		{
			Instance.graphWindow.RemoveGraph(key);
		}
	}

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	public static void ClearGraph(object key)
	{
		if (Settings.enableGraphs)
		{
			Instance.graphWindow.ClearGraph(key);
		}
	}

	public static string ExportGraphs()
	{
		return null;
	}

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	public static void LogPersistent(object key, string message)
	{
		if (Settings.enableLogs)
		{
			Instance.logWindow.LogPersistent(key, message);
		}
	}

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	public static void RemovePersistent(object key)
	{
		if (Settings.enableLogs)
		{
			Instance.logWindow.RemovePersistent(key);
		}
	}

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	public static void ClearPersistent()
	{
		if (Settings.enableLogs)
		{
			Instance.logWindow.ClearPersistent();
		}
	}

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	public static void Log(object message)
	{
		if (Settings.enableLogs)
		{
			Instance.logWindow.Log(message.ToString());
		}
	}

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	public static void ForceReinitializeAttributes()
	{
		if (!(Instance == null))
		{
			Instance.graphWindow.ReinitializeAttributes();
			Instance.logWindow.ReinitializeAttributes();
		}
	}

	private void Awake()
	{
		if (!initialized)
		{
			Init();
		}
	}

	private void Init()
	{
		Application.quitting += delegate
		{
			quitting = true;
		};
		initialized = true;
		_settings = Resources.Load<DebugGUISettings>("DebugGUISettings");
		Object.DontDestroyOnLoad(base.gameObject);
		if (Settings.enableGraphs)
		{
			graphWindow = new GameObject("Graph").AddComponent<GraphWindow>();
			graphWindow.Init();
			graphWindow.transform.parent = base.transform;
		}
		if (Settings.enableLogs)
		{
			logWindow = new GameObject("Log").AddComponent<LogWindow>();
			logWindow.Init();
			logWindow.transform.parent = base.transform;
		}
	}
}
