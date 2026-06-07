using System;
using System.Xml.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Craft;
using Assets.Scripts.Web;
using ModApi.Craft;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DownloadCraftDialogScript : DialogScript
	{
		private static bool _achievementUnlockedDownloadCraft;

		private string _craftId;

		private DesignerScript _designerScript;

		private XmlElement _panel;

		private RectTransform _progressBar;

		private WebRequest _request;

		private TextMeshProUGUI _statusLabel;

		public static DownloadCraftDialogScript Create(Transform parent, string craftId)
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/Sharing/DownloadContentDialog", parent, delegate(DownloadCraftDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			}, delegate(DownloadCraftDialogScript d)
			{
				d._designerScript = Game.Instance.Designer as DesignerScript;
				d._craftId = craftId;
			});
		}

		public override void Close()
		{
			base.Close();
			_request = null;
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}

		public void OnCancelButtonClicked()
		{
			_designerScript.ShowMessage(string.Empty);
			Close();
		}

		public void ShowError(string message)
		{
			_designerScript.ShowMessage(string.Empty);
			Game.Instance.UserInterface.CreateMessageDialog().MessageText = message;
		}

		protected override void Start()
		{
			base.Start();
			_panel.Show(recursiveCall: false, delegate
			{
				string url = Game.SimpleRocketsWebsiteUrl + "/Client/DownloadCraft?id=" + _craftId;
				_request = WebRequest.Create(url);
				_designerScript.ShowMessage("Downloading Craft...");
			});
		}

		protected virtual async void Update()
		{
			if (_request != null)
			{
				float num = Mathf.Clamp01(_request.Progress);
				_progressBar.localScale = new Vector3(num, 1f, 1f);
				_statusLabel.text = $"DOWNLOADING CRAFT: {(int)(num * 100f)}%";
				if (_request.IsDone)
				{
					WebRequest completedRequest = _request;
					_request = null;
					await Game.Instance.Ads.ShowAdForDownloadCraft();
					_designerScript.ShowMessage("Loading Craft...");
					_statusLabel.text = "Loading Craft...";
					CompleteDownload(completedRequest);
				}
			}
		}

		private void CompleteDownload(WebRequest completedWebRequest)
		{
			if (!string.IsNullOrEmpty(completedWebRequest.Error))
			{
				if (completedWebRequest.Error.Contains("404"))
				{
					ShowError($"Could not find a craft with ID {_craftId}.");
				}
				else
				{
					ShowError("Failed to download the craft.\n" + completedWebRequest.Error);
				}
				Debug.Log("Download failed: " + completedWebRequest.Error);
				LoadNewCraftIfNecessary();
			}
			else
			{
				try
				{
					XElement xElement = CraftLoaderScript.LoadCraftXmlFromBytes(completedWebRequest.Bytes);
					string value = xElement.Attribute("name").Value;
					_designerScript.CraftLoader.LoadCraftInteractive(xElement, createUndoStep: true, centerCamera: true, "Download craft '" + value + "'", null, LoadNewCraftIfNecessary);
					if (!_achievementUnlockedDownloadCraft)
					{
						_achievementUnlockedDownloadCraft = true;
						Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.WebsiteDownloadCraft);
					}
				}
				catch (Exception message)
				{
					Debug.LogError(message);
					ShowError($"The craft failed to load.");
					LoadNewCraftIfNecessary();
				}
			}
			Close();
		}

		private void LoadNewCraftIfNecessary()
		{
			if (_designerScript.CraftScript == null)
			{
				_designerScript.CreateNewCraft(CrafConfigurationType.Rocket);
			}
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_statusLabel = xmlLayout.GetElementById<TextMeshProUGUI>("status-text");
			_progressBar = xmlLayout.GetElementById<RectTransform>("progress");
			_panel.SetAttribute("active", "false");
		}
	}
}
