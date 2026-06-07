using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Storage;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Assets.Scripts.Net
{
	public class WebCraftProcessorScript : MonoBehaviour
	{
		private long _minimumID;

		private int _numFailed;

		private int _numProcessed;

		private DateTime _startTime;

		[SerializeField]
		private Text _statusText;

		private bool _useMinimumPostId;

		protected virtual string SubmitStatusUrl => "ProcessPerformanceCostSubmit";

		private string StateFilePath => GameData.GetPath("WebCraftProcessorState.txt");

		private string TempCraftDirectory => "D:\\temp\\WebCraftProcessor\\Crafts";

		private string WebsiteUrl => Game.SimplePlanesWebsiteUrl + "/Client";

		protected virtual string ProcessCraft(XElement aircraftXml)
		{
			return PerformanceCost.CalculateCost(new AircraftData(aircraftXml, CraftLoadContext.Designer)).ToString();
		}

		protected virtual void Start()
		{
			try
			{
				Application.targetFrameRate = 60;
				if (_useMinimumPostId)
				{
					_minimumID = long.Parse(File.ReadAllText(StateFilePath));
				}
			}
			catch (Exception)
			{
				_minimumID = 0L;
			}
			_startTime = DateTime.Now;
			StartCoroutine(Process());
		}

		protected virtual void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				Game.Instance.SceneManager.LoadMenu();
			}
			TimeSpan timeSpan = DateTime.Now - _startTime;
			double num = (double)_numProcessed / timeSpan.TotalSeconds;
			_statusText.text = $"PROCESSED: {_numProcessed}\nFAILED: {_numFailed}\nVELOCITY: {num:n2}/s";
		}

		private string GetCraftTempPath(string urlID, int revision)
		{
			string path = urlID[0].ToString().ToUpper();
			string path2 = urlID[1].ToString().ToUpper();
			string text = ((revision > 0) ? $"-{revision}" : string.Empty);
			return Path.Combine(TempCraftDirectory, path, path2, urlID + text + ".xml");
		}

		private void Log(string message, bool error = false, long failedPostID = 0L)
		{
			if (error)
			{
				Debug.LogError(message);
			}
			else
			{
				Debug.Log(message);
			}
			File.AppendAllText(GameData.GetPath("WebCraftProcessorLog.txt"), message + "\n");
			if (failedPostID > 0)
			{
				File.AppendAllText(GameData.GetPath("WebCraftProcessorFailedCrafts.txt"), $"{failedPostID}\n");
				_numFailed++;
			}
		}

		private IEnumerator Process()
		{
			bool done = false;
			while (!done)
			{
				string text = string.Format(WebsiteUrl + "/ProcessPerformanceCostQuery");
				if (_useMinimumPostId)
				{
					text += $"?minimumId={_minimumID}";
				}
				UnityWebRequest webRequest = UnityWebRequest.Get(text);
				yield return webRequest.SendWebRequest();
				if (webRequest.error != null)
				{
					Log("Server returned error: " + webRequest.error, error: true, 0L);
					continue;
				}
				string text2 = webRequest.downloadHandler.text;
				if (text2 == "0")
				{
					Debug.Log("No crafts to process. Waiting...");
					yield return new WaitForSeconds(60f);
					continue;
				}
				string[] array = text2.Split(new char[1] { '\t' });
				int postID = int.Parse(array[0]);
				string text3 = array[1];
				int revision = int.Parse(array[2]);
				Debug.Log($"Processing craft {text3} with postID {postID}");
				yield return StartCoroutine(ProcessCraftRoutine(postID, text3, revision));
				if (_useMinimumPostId)
				{
					_minimumID = postID + 1;
					File.WriteAllText(StateFilePath, _minimumID.ToString());
				}
			}
		}

		private IEnumerator ProcessCraftRoutine(long postID, string urlID, int revision)
		{
			string aircraftXmlText = null;
			string craftTempPath = GetCraftTempPath(urlID, revision);
			if (File.Exists(craftTempPath))
			{
				aircraftXmlText = File.ReadAllText(craftTempPath);
			}
			else
			{
				UnityWebRequest aircraftDownload = UnityWebRequest.Get(Game.GetDownloadAircraftUrl(urlID, revision));
				yield return aircraftDownload.SendWebRequest();
				if (aircraftDownload.error != null)
				{
					Log("Failed to download airplane " + urlID + ". Server returned error: " + aircraftDownload.error, error: true, postID);
				}
				else
				{
					aircraftXmlText = aircraftDownload.downloadHandler.text;
					FileInfo fileInfo = new FileInfo(craftTempPath);
					if (!fileInfo.Directory.Exists)
					{
						fileInfo.Directory.Create();
					}
					File.WriteAllText(craftTempPath, aircraftXmlText);
				}
			}
			string text;
			try
			{
				XElement aircraftXml = Utility.LoadCraftXmlFromBytes(Encoding.UTF8.GetBytes(aircraftXmlText));
				text = ProcessCraft(aircraftXml);
			}
			catch (Exception ex)
			{
				text = "-1";
				Log("Error processing craft " + urlID + ": " + ex.ToString(), error: true, postID);
				Log(aircraftXmlText, error: false, 0L);
			}
			if (text != null)
			{
				yield return SubmitStatus(postID, text);
			}
		}

		private IEnumerator SubmitStatus(long postID, string status)
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("PostID", postID.ToString());
			wWWForm.AddField("Status", status);
			wWWForm.AddField("UserName", Game.Instance.Settings.App.UserName);
			wWWForm.AddField("ClientToken", Game.Instance.Settings.App.ClientToken);
			string uri = $"{WebsiteUrl}/{SubmitStatusUrl}";
			UnityWebRequest submitRequest = UnityWebRequest.Post(uri, wWWForm);
			yield return submitRequest.SendWebRequest();
			if (submitRequest.error != null || submitRequest.downloadHandler.text != "1")
			{
				Log("Server returned error: " + submitRequest.error, error: true, postID);
			}
			else
			{
				_numProcessed++;
			}
		}
	}
}
