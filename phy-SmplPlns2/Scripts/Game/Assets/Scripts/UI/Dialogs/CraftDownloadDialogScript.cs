using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Net;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Dialogs
{
	public class CraftDownloadDialogScript : PanelDialogScript
	{
		public enum CraftDownloadResultType
		{
			Success = 0,
			Error = 1,
			Canceled = 2,
			NotFound = 3
		}

		public class CraftDownloadResult
		{
			public XElement CraftXml { get; }

			public CraftDownloadResultType ResultType { get; }

			public CraftDownloadResult(XElement craftXml, CraftDownloadResultType resultType)
			{
				CraftXml = craftXml;
				ResultType = resultType;
			}
		}

		private WebRequest _craftDetailsWebRequest;

		private WebRequest _craftWebRequest;

		private Action<CraftDownloadResult> _downloadComplete;

		private ProgressBarWidget _progressBar;

		private TextWidget _progressBarText;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_progressBar = widget.FindWidget<ProgressBarWidget>("progress-bar");
			_progressBarText = widget.FindWidget<TextWidget>("progress-bar-text");
		}

		public void StartDownload(string aircraftId, Action<CraftDownloadResult> onComplete)
		{
			_downloadComplete = onComplete;
			string downloadAircraftUrl = Game.GetDownloadAircraftUrl(aircraftId);
			string downloadAircraftDetailsUrl = Game.GetDownloadAircraftDetailsUrl(aircraftId);
			if (!string.IsNullOrEmpty(downloadAircraftUrl))
			{
				_craftWebRequest = WebRequest.Get(downloadAircraftUrl);
				_craftDetailsWebRequest = WebRequest.Get(downloadAircraftDetailsUrl);
				return;
			}
			throw new ArgumentException("No download URL was provided");
		}

		protected virtual void Update()
		{
			if (_craftWebRequest == null || _craftDetailsWebRequest == null)
			{
				return;
			}
			try
			{
				if (!_craftWebRequest.IsDone || !_craftDetailsWebRequest.IsDone)
				{
					float percentage = Mathf.Lerp(0f, 0.95f, _craftWebRequest.Progress) + Mathf.Lerp(0f, 0.05f, _craftDetailsWebRequest.Progress);
					UpdateProgressBar(percentage);
					return;
				}
				bool flag = false;
				if (!string.IsNullOrEmpty(_craftWebRequest.Error))
				{
					Game.Instance.UserInterface.CreateMessageDialog("The download failed. Please check your internet connection and try again.");
					Debug.LogError("Craft download error: " + _craftWebRequest.Error);
					OnCompleted(CraftDownloadResultType.Error);
					return;
				}
				if (!string.IsNullOrEmpty(_craftDetailsWebRequest.Error))
				{
					Debug.LogError("Craft details download error: " + _craftDetailsWebRequest.Error);
					flag = true;
				}
				if (_craftWebRequest.IsCanceled || _craftDetailsWebRequest.IsCanceled)
				{
					OnCompleted(CraftDownloadResultType.Canceled);
					return;
				}
				UpdateProgressBar(1f);
				if (_craftWebRequest.Text == "0")
				{
					Game.Instance.UserInterface.CreateMessageDialog("Unable to find the aircraft. Please check that you have the correct URL and try again.");
					OnCompleted(CraftDownloadResultType.NotFound);
					return;
				}
				if (!flag && _craftDetailsWebRequest.Text == "0")
				{
					Debug.LogError("Craft details download error: No details were found for this craft.");
					flag = true;
				}
				XElement craftXml = Utility.LoadCraftXmlFromBytes(_craftWebRequest.Bytes);
				if (!flag)
				{
					try
					{
						List<string> craftTags = (from x in XDocument.Parse(_craftDetailsWebRequest.Text)?.Root?.Element("XmlResult")?.Element("Details")?.Element("Tags")?.Elements("Tag")
							select (string)x.Attribute("Name")).ToList() ?? new List<string>(0);
						ApplyCraftTags(craftXml, craftTags);
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
						Debug.LogError("An error occurred while loading the craft details. The craft will be downloaded without details. Error: " + ex.Message);
						flag = true;
					}
				}
				OnCompleted(CraftDownloadResultType.Success, craftXml);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Game.Instance.UserInterface.CreateMessageDialog("The download failed. Please make sure you have the latest version of the game.");
				OnCompleted(CraftDownloadResultType.Error);
			}
		}

		private void ApplyCraftTags(XElement craftXml, List<string> craftTags)
		{
			if (craftXml == null || craftTags == null || craftTags.Count == 0)
			{
				return;
			}
			List<string> stringListAttribute = craftXml.GetStringListAttribute("tags");
			List<string> list = new List<string>(stringListAttribute.Count + craftTags.Count);
			list.AddRange(stringListAttribute);
			bool flag = false;
			foreach (string craftTag in craftTags)
			{
				if (string.IsNullOrWhiteSpace(craftTag) || craftTag.StartsWith("Youtube", StringComparison.OrdinalIgnoreCase) || CraftTags.ExcludedWebsiteTags.Contains(craftTag, StringComparer.OrdinalIgnoreCase))
				{
					continue;
				}
				bool flag2 = false;
				foreach (string item in stringListAttribute)
				{
					if (string.Equals(item, craftTag, StringComparison.OrdinalIgnoreCase))
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					list.Add(craftTag);
					flag = true;
				}
			}
			if (flag)
			{
				craftXml.SetAttributeValue("tags", string.Join(',', list));
			}
		}

		private void OnCancelClicked(Widget widget)
		{
			if (_craftWebRequest != null)
			{
				_craftWebRequest.IsCanceled = true;
			}
			if (_craftDetailsWebRequest != null)
			{
				_craftDetailsWebRequest.IsCanceled = true;
			}
		}

		private void OnCompleted(CraftDownloadResultType result, XElement craftXml = null)
		{
			_craftWebRequest = null;
			_craftDetailsWebRequest = null;
			Close();
			try
			{
				_downloadComplete?.Invoke(new CraftDownloadResult(craftXml, result));
			}
			catch (Exception ex)
			{
				if (result == CraftDownloadResultType.Success)
				{
					throw;
				}
				Debug.LogException(ex);
				Debug.LogError($"An error occurred while processing the craft download failure result ({result}): {ex.Message}");
			}
		}

		private void UpdateProgressBar(float percentage)
		{
			_progressBar.Value = percentage;
			_progressBarText.Text = $"{percentage * 100f:n0}%";
		}
	}
}
