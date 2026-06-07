using System;
using Assets.Scripts.Net;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Dialogs
{
	public class ContentDownloadDialogScript : PanelDialogScript
	{
		private ProgressBarWidget _progressBar;

		private TextWidget _progressBarText;

		private WebRequest _request;

		public string DownloadUrl { get; set; }

		public event Action<WebRequest> DownloadComplete;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_progressBar = widget.FindWidget<ProgressBarWidget>("progress-bar");
			_progressBarText = widget.FindWidget<TextWidget>("progress-bar-text");
		}

		protected override void Start()
		{
			base.Start();
			if (!string.IsNullOrEmpty(DownloadUrl))
			{
				_request = WebRequest.Get(DownloadUrl);
				return;
			}
			throw new ArgumentException("No download URL was provided");
		}

		protected virtual void Update()
		{
			if (_request == null)
			{
				return;
			}
			if (_request.IsDone)
			{
				if (!string.IsNullOrEmpty(_request.Error))
				{
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "The download failed. Please check your internet connection and try again.";
					Debug.LogError(_request.Error);
				}
				else
				{
					try
					{
						UpdateProgressBar(1f);
						this.DownloadComplete?.Invoke(_request);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						Game.Instance.UserInterface.CreateMessageDialog().MessageText = "The download failed. Please make sure you have the latest version of the game.";
					}
				}
				_request = null;
				Close();
			}
			else
			{
				UpdateProgressBar(_request.Progress);
			}
		}

		private void OnCancelClicked(Widget widget)
		{
			if (_request != null)
			{
				_request.IsCanceled = true;
			}
		}

		private void UpdateProgressBar(float percentage)
		{
			_progressBar.Value = percentage;
			_progressBarText.Text = $"{percentage * 100f:n0}%";
		}
	}
}
