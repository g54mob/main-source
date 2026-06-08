using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CrashReportController : MonoBehaviour
{
	private const string BASE_URL = "https://stonestoryrpg.com/cs/";

	private List<string> breadcrumbs = new List<string>();

	public bool hasSentReport { get; private set; }

	public static CrashReportController singleton { get; private set; }

	public void AddBreadcrumb(string crumb)
	{
		if (!hasSentReport)
		{
			breadcrumbs.Add(crumb);
		}
	}

	public void ClearBreadcrumbs()
	{
		breadcrumbs.Clear();
	}

	public bool HasBreadcrumbs()
	{
		return breadcrumbs.Count > 0;
	}

	public string GetBreadcrumbsString()
	{
		return "Breadcrumbs:" + string.Join(',', breadcrumbs);
	}

	public void SendReport(string errorStack)
	{
		if (!hasSentReport)
		{
			hasSentReport = true;
			errorStack = errorStack.Replace(" [0x00000] in <00000000000000000000000000000000>:0", "");
			if (HasBreadcrumbs())
			{
				errorStack = GetBreadcrumbsString() + "\n  " + errorStack;
			}
			string versionStr = Features.VERSION.ToString();
			string operatingSystemGlyph = DiagnosticsUI.GetOperatingSystemGlyph();
			StartCoroutine(_SendReport(errorStack, versionStr, operatingSystemGlyph));
		}
	}

	public void DownloadReports()
	{
	}

	public void ClearDatabase(string minVersionToRetain)
	{
	}

	private IEnumerator _SendReport(string errorStack, string versionStr, string operatingSys)
	{
		string text = "https://stonestoryrpg.com/cs/crash.php";
		Utils.LogIfEditor("Calling remote: " + text);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("err", errorStack);
		wWWForm.AddField("v", versionStr);
		wWWForm.AddField("os", operatingSys);
		using UnityWebRequest webRequest = UnityWebRequest.Post(text, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			hasSentReport = false;
			Utils.LogErrorIfEditor(webRequest.error);
		}
	}

	private void Awake()
	{
		singleton = this;
	}
}
