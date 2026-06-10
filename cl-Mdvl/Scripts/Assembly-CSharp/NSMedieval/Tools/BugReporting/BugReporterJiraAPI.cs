using System;
using System.Collections;
using System.IO;
using System.Text;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Tools.Debug;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace NSMedieval.Tools.BugReporting
{
	public class BugReporterJiraAPI : MonoSingleton<BugReporterJiraAPI>
	{
		private struct VersionInfo
		{
			private string self;

			private string id;

			private string name;

			private bool archived;

			private bool released;

			private int projectId;

			public string Self => self;

			public string ID => id;

			public string Name => name;

			public bool Archived => archived;

			public bool Released => released;

			public int ProjectId => projectId;

			public VersionInfo(string self, string id, string name, bool archived, bool released, int projectId)
			{
				this.self = self;
				this.id = id;
				this.name = name;
				this.archived = archived;
				this.released = released;
				this.projectId = projectId;
			}
		}

		public enum ReportPriority
		{
			None = 0,
			Low = 1,
			Medium = 2,
			High = 3
		}

		public enum ReportType
		{
			None = 0,
			Bug = 1,
			Feature = 2,
			Feedback = 3,
			Exception = 4
		}

		public enum ReportStatus
		{
			None = 0,
			Error = 1,
			Success = 2
		}

		public static bool IsReportUploading;

		private const string Username = "foxy@foxyvoxel.io";

		private const string APIKey = "7h7OTIezX7Au9kG6ySaq1EB0";

		private const string BaseUrl = "https://foxyvoxel.atlassian.net/";

		private const string ProjectKey = "GMB";

		private const string ProjectId = "10001";

		public static string ScreenShotPath => $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}butReporterShot.png";

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public new static void OnDomainReload()
		{
			IsReportUploading = false;
		}

		public void SubmitReport(ReportPriority priority, ReportType category, string subject, string description, Action<ReportStatus> callback)
		{
			if (IntegrityChecker.IsGameModified && category.Equals(ReportType.Exception))
			{
				callback?.Invoke(ReportStatus.Success);
				return;
			}
			if (description.Length == 0 || subject.Length == 0)
			{
				callback?.Invoke(ReportStatus.Error);
				return;
			}
			description += BugReporterUtils.GetSystemSpecs();
			string exceptionWhileSaving;
			string zipFilename = BugReporterUtils.GenerateZipFile(out exceptionWhileSaving);
			if (!string.IsNullOrEmpty(exceptionWhileSaving))
			{
				description = description + "\n\n ----- Exception while saving for bug report: " + exceptionWhileSaving;
			}
			IsReportUploading = true;
			string version = Application.version;
			PrepareJiraVersions(version, delegate(bool success)
			{
				if (!success)
				{
					callback?.Invoke(ReportStatus.Error);
					IsReportUploading = false;
				}
				else
				{
					CreateReport(priority, category, subject, description, delegate(string result)
					{
						ReportCreationRequestDone(result, zipFilename, callback);
					});
				}
			});
		}

		private void ReportCreationRequestDone(string result, string zipFilename, Action<ReportStatus> callback)
		{
			if (string.IsNullOrEmpty(result))
			{
				Log.Info("Error submitting bug report 1", "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporterJiraAPI.cs");
				callback(ReportStatus.Error);
				IsReportUploading = false;
				return;
			}
			JToken value = ((JObject)JsonConvert.DeserializeObject(result)).GetValue("key");
			if (value == null)
			{
				Log.Info("Error submitting bug report 2", "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporterJiraAPI.cs");
				callback(ReportStatus.Error);
				IsReportUploading = false;
				return;
			}
			string issueId;
			try
			{
				issueId = value.Value<string>();
			}
			catch (Exception)
			{
				Log.Info("Error submitting bug report 3", "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporterJiraAPI.cs");
				callback(ReportStatus.Error);
				IsReportUploading = false;
				return;
			}
			AttachFile(issueId, zipFilename, delegate(bool b)
			{
				if (b)
				{
					callback(ReportStatus.Success);
					AttachFile(issueId, ScreenShotPath, delegate
					{
						IsReportUploading = false;
					});
				}
				else
				{
					callback(ReportStatus.Error);
					IsReportUploading = false;
				}
			});
		}

		public void PrepareJiraVersions(string version, Action<bool> callback)
		{
			IEnumerator routine = SendGetRequest("https://foxyvoxel.atlassian.net/rest/api/latest/project/10001/versions", delegate(string result)
			{
				if (result.Equals(string.Empty))
				{
					callback?.Invoke(obj: false);
				}
				else
				{
					try
					{
						VersionInfo[] array = JsonConvert.DeserializeObject<VersionInfo[]>(result);
						for (int i = 0; i < array.Length; i++)
						{
							VersionInfo versionInfo = array[i];
							if (!versionInfo.Equals(default(VersionInfo)) && !string.IsNullOrEmpty(versionInfo.Name) && versionInfo.Name.ToLower().Trim().Equals(version.ToLower().Trim()))
							{
								callback?.Invoke(obj: true);
								return;
							}
						}
					}
					catch (Exception ex)
					{
						Log.Warning("Jira get versions exception: " + ex, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporterJiraAPI.cs");
						callback?.Invoke(obj: false);
						return;
					}
					string data = JsonConvert.SerializeObject(new
					{
						archived = false,
						releaseDate = "2010-01-01",
						name = version,
						description = "AutoGenerated",
						projectId = "10001",
						released = false
					});
					IEnumerator routine2 = PostSendJsonData("https://foxyvoxel.atlassian.net/rest/api/latest/version", data, delegate(string response)
					{
						if (response.Equals(string.Empty))
						{
							callback?.Invoke(obj: false);
						}
						else
						{
							callback?.Invoke(obj: true);
						}
					});
					StartCoroutine(routine2);
				}
			});
			StartCoroutine(routine);
		}

		private void CreateReport(ReportPriority priority, ReportType category, string subject, string inDescription, Action<string> callback)
		{
			string[] labels = ((!MonoSingleton<BugReporterManager>.Instance.IsDevConsoleOpened) ? new string[1] { "ClientReport" } : new string[2] { "ClientReport", "Cheater" });
			string data = JsonConvert.SerializeObject(new
			{
				fields = new
				{
					project = new
					{
						key = "GMB"
					},
					summary = subject,
					description = inDescription,
					issuetype = new
					{
						name = category.ToString()
					},
					priority = new
					{
						name = priority.ToString()
					},
					labels = labels,
					versions = new[]
					{
						new
						{
							name = Application.version
						}
					}
				}
			});
			IEnumerator routine = PostSendJsonData("https://foxyvoxel.atlassian.net//rest/api/latest/issue/", data, callback);
			StartCoroutine(routine);
		}

		private void AttachFile(string id, string filename, Action<bool> doneCallback)
		{
			IEnumerator postSendJsonData = PostSendFormFile("https://foxyvoxel.atlassian.net//rest/api/latest/issue/" + id + "/attachments", filename, Path.GetFileName(filename), delegate(string s)
			{
				doneCallback(!string.IsNullOrEmpty(s));
			});
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(1f).Then(delegate
			{
				StartCoroutine(postSendJsonData);
			});
		}

		private IEnumerator SendGetRequest(string url, Action<string> callback)
		{
			UnityWebRequest www = new UnityWebRequest(url, "GET");
			www.downloadHandler = new DownloadHandlerBuffer();
			string text = Convert.ToBase64String(Encoding.UTF8.GetBytes("foxy@foxyvoxel.io:7h7OTIezX7Au9kG6ySaq1EB0"));
			www.SetRequestHeader("Authorization", "Basic " + text);
			www.SetRequestHeader("Content-Type", "application/json");
			www.SendWebRequest();
			while (!www.isDone)
			{
				yield return false;
			}
			if (!string.IsNullOrEmpty(www.error))
			{
				Log.Error("GET : " + www.error, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporterJiraAPI.cs");
				if (www.downloadHandler?.text != null)
				{
					Log.Error("ERROR MSG GET: " + www.downloadHandler.text, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporterJiraAPI.cs");
				}
				callback(string.Empty);
			}
			else if (www.isDone)
			{
				callback(www.downloadHandler.text);
			}
		}

		private IEnumerator PostSendJsonData(string url, string data, Action<string> callback)
		{
			UnityWebRequest www = new UnityWebRequest(url, "POST");
			www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(data));
			www.downloadHandler = new DownloadHandlerBuffer();
			string text = Convert.ToBase64String(Encoding.UTF8.GetBytes("foxy@foxyvoxel.io:7h7OTIezX7Au9kG6ySaq1EB0"));
			www.SetRequestHeader("Authorization", "Basic " + text);
			www.SetRequestHeader("Content-Type", "application/json");
			www.SendWebRequest();
			while (!www.isDone)
			{
				yield return false;
			}
			if (!string.IsNullOrEmpty(www.error))
			{
				Log.Error(www.error, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporterJiraAPI.cs");
				if (www.downloadHandler?.text != null)
				{
					Log.Error("ERROR MSG: " + www.downloadHandler.text, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporterJiraAPI.cs");
				}
				callback(string.Empty);
			}
			else if (www.isDone)
			{
				callback(www.downloadHandler.text);
			}
		}

		private IEnumerator PostSendFormFile(string url, string filePath, string remoteFilename, Action<string> callback)
		{
			byte[] contents = FileUtils.SafeReadAllBytes(filePath);
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddBinaryData("file", contents, remoteFilename);
			UnityWebRequest www = UnityWebRequest.Post(url, wWWForm);
			string text = Convert.ToBase64String(Encoding.UTF8.GetBytes("foxy@foxyvoxel.io:7h7OTIezX7Au9kG6ySaq1EB0"));
			www.SetRequestHeader("Authorization", "Basic " + text);
			www.SetRequestHeader("X-Atlassian-Token", "no-check");
			yield return www.SendWebRequest();
			while (!www.isDone)
			{
				yield return false;
			}
			if (!string.IsNullOrEmpty(www.error))
			{
				Log.Error(www.error, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporterJiraAPI.cs");
				callback(string.Empty);
			}
			else if (www.isDone)
			{
				callback(www.downloadHandler.text);
			}
		}
	}
}
