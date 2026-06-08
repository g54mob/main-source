using System.Collections.Generic;
using Backtrace.Unity;
using Backtrace.Unity.Model;
using Dorfromantik;
using UnityEngine;

public class BacktraceManager : MonoBehaviour
{
	[SerializeField]
	private BacktraceConfiguration backtraceConfiguration;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private BuildInfo buildInfo;

	private static BacktraceClient client;

	private readonly List<string> attributesToRemove = new List<string> { "device.name", "application.data_path", "application.temporary_cache", "hostname" };

	private void Awake()
	{
		client = BacktraceClient.Initialize(backtraceConfiguration);
		client.BeforeSend = ValidateReportData;
	}

	private BacktraceData ValidateReportData(BacktraceData data)
	{
		data.Annotation.EnvironmentVariables = new Dictionary<string, string>();
		foreach (string item in attributesToRemove)
		{
			data.Attributes.Attributes.Remove(item);
		}
		foreach (KeyValuePair<string, string> allSetting in settingsRouter.GetAllSettings())
		{
			if (!data.Attributes.Attributes.ContainsKey(allSetting.Key))
			{
				data.Attributes.Attributes.Add(allSetting.Key, allSetting.Value);
			}
		}
		data.Attributes.Attributes.Add("dorfromantik.buildNumber", buildInfo.buildNumber);
		data.Attributes.Attributes.Add("dorfromantik.branch", buildInfo.branchName);
		Debug.Log("send backtrace report");
		return data;
	}

	private void SendBacktraceReport(string message, bool attachLog, bool attachSaveFiles)
	{
		if (!(client == null) && client.Enabled)
		{
			List<string> list = new List<string>();
			if (attachLog)
			{
				list.Add(Application.persistentDataPath + "/Player.log");
			}
			if (attachSaveFiles)
			{
				list.Add(Application.persistentDataPath + "/Saves/AutoSave01.sav");
			}
			BacktraceReport report = new BacktraceReport(message, null, (list.Count == 0) ? null : list);
			client.Send(report);
		}
	}

	public static void SendCustomBacktraceReport(string message, Dictionary<string, string> attributes)
	{
		if (!(client == null) && client.Enabled)
		{
			BacktraceReport report = new BacktraceReport(message, attributes);
			client.Send(report);
		}
	}

	private void TriggerError(string message)
	{
		Debug.LogError(message ?? "");
	}
}
