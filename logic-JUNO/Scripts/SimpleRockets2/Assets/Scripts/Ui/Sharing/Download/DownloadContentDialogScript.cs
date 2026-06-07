using System;
using System.Collections;
using ModApi.Common.Extensions;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.Sharing.Download
{
	public class DownloadContentDialogScript : DialogScript
	{
		private XmlElement _cancelButton;

		private bool _canceled;

		private XmlElement _panel;

		private RectTransform _progressBar;

		private TextMeshProUGUI _statusLabel;

		public DownloadContentViewModel ViewModel { get; private set; }

		public static DownloadContentDialogScript Create(Transform parent, DownloadContentViewModel viewModel)
		{
			IUserInterface userInterface = Game.Instance.UserInterface;
			return userInterface.CreateDialog("Ui/Xml/Sharing/DownloadContentDialog", parent ?? userInterface.Transform, delegate(DownloadContentDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			}, delegate(DownloadContentDialogScript d)
			{
				d.ViewModel = viewModel;
			});
		}

		public override void Close()
		{
			base.Close();
			ViewModel.OnDialogClosed();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}

		public void OnCancelButtonClicked()
		{
			if (!_canceled)
			{
				_canceled = true;
				_cancelButton.gameObject.SetActive(value: false);
				ViewModel.Cancel();
			}
		}

		protected override void Start()
		{
			base.Start();
			_panel.Show(recursiveCall: false, delegate
			{
				StartDownload();
			});
		}

		private IEnumerator DownloadCoroutine()
		{
			yield return ViewModel.Download(OnDownloadProgressed, OnDownloadCompleted);
		}

		private void OnDownloadCompleted(DownloadContentResult result)
		{
			Close();
			if (result.Result == DownloadContentResultType.Success)
			{
				Debug.Log("Download successful.");
				ViewModel.OnDownloadSucceeded();
				return;
			}
			if (result.Result == DownloadContentResultType.Canceled)
			{
				Debug.Log("Download Canceled");
				return;
			}
			if (result.Result == DownloadContentResultType.CommunicationFailure)
			{
				Debug.LogError("Download failed (communication): " + (result.WebRequest?.Error ?? result.Message));
			}
			else if (result.Result == DownloadContentResultType.ServerFailure)
			{
				Debug.LogError("Download failed (server-side): " + (result.WebRequest?.Response?.Error ?? result.Message));
			}
			else
			{
				Debug.LogError("Download failed: " + result.Message);
			}
			if (!string.IsNullOrEmpty(result.Message))
			{
				Game.Instance.UserInterface.CreateErrorDialog(result.Message);
			}
		}

		private void OnDownloadProgressed(float progress, Func<float, string> progressLabel = null)
		{
			_progressBar.localScale = new Vector3(progress, 1f, 1f);
			_statusLabel.text = progressLabel?.Invoke(progress) ?? ((progress < 1f) ? $"Downloading: {(int)(progress * 100f)}%" : "Processing...");
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_statusLabel = xmlLayout.GetElementById<TextMeshProUGUI>("status-text");
			_progressBar = xmlLayout.GetElementById<RectTransform>("progress");
			_cancelButton = xmlLayout.GetElementById("cancel-button");
			_panel.SetAttribute("active", "false");
		}

		private void StartDownload()
		{
			this.StartThrowingCoroutine(DownloadCoroutine(), delegate(Exception ex)
			{
				Debug.LogException(ex);
				Close();
				Game.Instance.UserInterface.CreateErrorDialog("An unexpected failure occurred: " + ex.Message);
			});
		}
	}
}
