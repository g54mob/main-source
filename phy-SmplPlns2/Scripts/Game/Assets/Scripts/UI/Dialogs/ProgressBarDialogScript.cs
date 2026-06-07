using System;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Dialogs
{
	public class ProgressBarDialogScript : PanelDialogScript
	{
		private Widget _buttonRowSpacer;

		private ButtonWidget _cancelButton;

		private ProgressBarWidget _progressBar;

		private TextWidget _progressBarText;

		public float Progress { get; private set; }

		public string ProgressText
		{
			get
			{
				return _progressBarText.Text;
			}
			set
			{
				_progressBarText.Text = value;
			}
		}

		public bool ShowCancelButton
		{
			get
			{
				return _cancelButton.Visible;
			}
			set
			{
				_cancelButton.Visible = value;
				_buttonRowSpacer.Visible = value;
			}
		}

		public event EventHandler<EventArgs> CancelClicked;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_progressBar = widget.FindWidget<ProgressBarWidget>("progress-bar");
			_progressBarText = widget.FindWidget<TextWidget>("progress-bar-text");
			_cancelButton = widget.FindWidget<ButtonWidget>("cancel-button");
			_buttonRowSpacer = widget.FindWidget("content-bottom-spacer");
			_cancelButton.Clicked += OnCancelClicked;
			SetProgress(0f);
		}

		public void SetProgress(float progress)
		{
			Progress = progress;
			_progressBar.Value = progress;
			_progressBarText.Text = $"{progress * 100f:n0}%";
		}

		private void OnCancelClicked(Widget widget)
		{
			this.CancelClicked?.Invoke(this, EventArgs.Empty);
		}
	}
}
