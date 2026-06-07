using System;
using System.IO;
using UnityEngine;

public class MetricLogger : MonoBehaviour
{
	public static MetricLogger Singleton;

	private string logFilePath;

	public bool ENABLE_MetricLogging;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Singleton = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		Setup();
	}

	private void Setup()
	{
		if (ENABLE_MetricLogging)
		{
			string text = DateTime.Now.ToString("yyyyMMdd_HHmmss");
			string path = "game_metrics_" + text + ".txt";
			logFilePath = Path.Combine(Application.persistentDataPath, path);
			File.WriteAllText(logFilePath, "Round, Round Time Max, Total Time Played (Round Time), Total $$$, Total $$$ Spent, Current $$$, Total $$$ Dropped, Total (*), Total (*) Spent, Current (*), Fell In Hole This Round?, Vers.\n");
		}
	}

	public void LogMetrics()
	{
	}
}
