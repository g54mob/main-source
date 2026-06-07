using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Net;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using Web.Client.Models;

namespace Assets.Scripts.UI.Sharing
{
	public abstract class UploadDialogScript : PanelDialogScript
	{
		private const int MaxScreenshots = 3;

		private TextWidget _accountLabel;

		private ButtonWidget _addScreenshotButton;

		private float _percentage;

		private ImageWidget _progressBarImage;

		private TextWidget _progressLabel;

		private IScreenshotDialogHandler _screenshotDialogHandler;

		private Widget _screenshotsParent;

		private WebRequest _uploadRequest;

		private TextWidget _visibilityLabel;

		public bool UploadVisibilityPublic { get; set; }

		protected InputWidget DescriptionInput { get; private set; }

		protected InputWidget NameInput { get; private set; }

		protected List<ScreenshotListItemScript> UserScreenshots { get; private set; } = new List<ScreenshotListItemScript>();

		public override void Close()
		{
			base.Close();
		}

		public void OnAccountButtonClicked(Widget widget)
		{
			Game.Instance.UserInterface.CreateLoginDialog().Closed += OnLoginDialogClosed;
		}

		public void OnAddScreenshotButtonClicked(Widget widget)
		{
			base.Widget.Visible = false;
			Game.Instance.UserInterface.CreateScreenshotDialog(_screenshotDialogHandler).OnScreenshotComplete = delegate(Texture2D texture)
			{
				base.Widget.Visible = true;
				if (texture != null)
				{
					ScreenshotListItemScript component = base.Widget.Context.CreateWidgetFromTemplate("screenshot", _screenshotsParent).GetComponent<ScreenshotListItemScript>();
					component.Texture = texture;
					component.Widget.Height = (float)texture.height / (float)texture.width * _addScreenshotButton.Rect.sizeDelta.x;
					RefreshUserScreenshotsList();
					UpdateAddScreenshotButton();
				}
			};
		}

		public void OnCancelClicked(Widget widget)
		{
			Close();
		}

		public void OnDeleteScreenshotClicked(Widget widget)
		{
			widget.GetComponentInParent<ScreenshotListItemScript>().Widget.Destroy();
			RefreshUserScreenshotsList();
			UpdateAddScreenshotButton();
		}

		public void OnMoveScreenshotDownClicked(Widget widget)
		{
			ScreenshotListItemScript componentInParent = widget.GetComponentInParent<ScreenshotListItemScript>();
			componentInParent.Widget.SetIndex(Mathf.Clamp(componentInParent.Widget.Index + 1, 0, 3));
			RefreshUserScreenshotsList();
			UpdateAddScreenshotButton();
		}

		public void OnMoveScreenshotUpClicked(Widget widget)
		{
			ScreenshotListItemScript componentInParent = widget.GetComponentInParent<ScreenshotListItemScript>();
			componentInParent.Widget.SetIndex(Mathf.Clamp(componentInParent.Widget.Index - 1, 0, 3));
			_addScreenshotButton.SetIndex(-1);
			RefreshUserScreenshotsList();
			UpdateAddScreenshotButton();
		}

		public void OnShareButtonClicked(Widget widget)
		{
			List<string> list = new List<string>();
			ValidateForm(list);
			if (list.Count > 0)
			{
				string messageText = string.Join("\n\n", list);
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, messageText, "Review Before Submitting");
				return;
			}
			Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, "Please confirm that you are ready to upload.", "Confirm Upload", delegate(MessageDialogScript d)
			{
				d.Close();
				EnableForm(enable: false);
				StartCoroutine(SubmitRequestAsync());
			}).OkayButtonText = "Upload";
		}

		public void OnVisibilityButtonClicked(Widget widget)
		{
			UploadVisibilityPublic = !UploadVisibilityPublic;
			UpdateVisibilityLabel();
		}

		protected void Initialize(IScreenshotDialogHandler handler)
		{
			_screenshotDialogHandler = handler;
			NameInput = base.Widget.FindWidget<InputWidget>("craft-name-input");
			DescriptionInput = base.Widget.FindWidget<InputWidget>("craft-description-input");
			_accountLabel = base.Widget.FindWidget<TextWidget>("account-text");
			UpdateAccountLabel();
			_visibilityLabel = base.Widget.FindWidget<TextWidget>("visibility-text");
			UploadVisibilityPublic = false;
			UpdateVisibilityLabel();
			_screenshotsParent = base.Widget.FindWidget("screenshots-parent");
			_addScreenshotButton = base.Widget.FindWidget<ButtonWidget>("add-screenshot-button");
			_progressLabel = base.Widget.FindWidget<TextWidget>("progress-text");
			_progressBarImage = base.Widget.FindWidget<ImageWidget>("upload-progress-bar");
		}

		protected virtual IEnumerator OnPrepareFormAsync()
		{
			yield return null;
		}

		protected abstract WebRequest OnSubmitRequest();

		protected abstract void OnSuccessfulResponse(ClientResponse response);

		protected virtual void Update()
		{
			if (_uploadRequest != null)
			{
				UpdateProgress(_uploadRequest.Progress);
			}
			if (_uploadRequest == null || !_uploadRequest.IsDone)
			{
				return;
			}
			Debug.Log("Server returned text: " + _uploadRequest.Text + ", error: " + _uploadRequest.Error);
			if (!string.IsNullOrEmpty(_uploadRequest.Error))
			{
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "The upload failed. Please verify your internet connection and try again.");
				EnableForm(enable: true);
			}
			else
			{
				ClientResponse clientResponse = WebUtility.CreateClientResponse(_uploadRequest.Text);
				if (!clientResponse.Succeeded)
				{
					Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, clientResponse.Error);
					if (clientResponse.GetValue("ForceLogOff") == "true")
					{
						Game.Instance.Settings.App.UserLogOut();
						UpdateAccountLabel();
					}
					EnableForm(enable: true);
				}
				else
				{
					_screenshotDialogHandler?.ShowMessage("Upload Complete", 5f);
					OnSuccessfulResponse(clientResponse);
					Close();
				}
			}
			_uploadRequest = null;
		}

		protected virtual void ValidateForm(List<string> errorMessages)
		{
			if (string.IsNullOrEmpty(Game.Instance.Settings.App.UserName))
			{
				errorMessages.Add("You need to log in before you can upload.");
			}
			if (string.IsNullOrEmpty(NameInput.Text.Trim()))
			{
				errorMessages.Add("Please, provide a title.");
			}
			if (UserScreenshots.Count == 0)
			{
				errorMessages.Add("You need to include at least one screenshot.");
			}
		}

		private void EnableForm(bool enable)
		{
			base.Widget.EnableClass("form-disabled", !enable);
		}

		private void OnLoginDialogClosed(IDialog dialog)
		{
			UpdateAccountLabel();
		}

		private void RefreshUserScreenshotsList()
		{
			UserScreenshots.Clear();
			UserScreenshots.AddRange(_screenshotsParent.GetComponentsInChildren<ScreenshotListItemScript>());
		}

		private IEnumerator SubmitRequestAsync()
		{
			yield return null;
			UpdateProgress(0f, animate: false);
			yield return new WaitForEndOfFrame();
			yield return OnPrepareFormAsync();
			_uploadRequest = OnSubmitRequest();
		}

		private void UpdateAccountLabel()
		{
			if (!string.IsNullOrEmpty(Game.Instance.Settings.App.UserName))
			{
				_accountLabel.Text = Game.Instance.Settings.App.UserName;
			}
			else
			{
				_accountLabel.Text = "Log In";
			}
		}

		private void UpdateAddScreenshotButton()
		{
			_addScreenshotButton.SetIndex(-1);
			_addScreenshotButton.Visible = UserScreenshots.Count < 3;
		}

		private void UpdateProgress(float percentage, bool animate = true)
		{
			if (animate)
			{
				_percentage = Jundroo.Common.Utils.Utilities.StepTowards(_percentage, Time.deltaTime * 2f, percentage);
			}
			else
			{
				_percentage = percentage;
			}
			_progressBarImage.Rect.anchorMax = new Vector2(_percentage, 1f);
			if (_percentage < 1f)
			{
				_progressLabel.Text = $"Uploading: {(int)(_percentage * 100f)}%";
			}
			else
			{
				_progressLabel.Text = "Upload finished. Waiting for reply...";
			}
		}

		private void UpdateVisibilityLabel()
		{
			if (UploadVisibilityPublic)
			{
				_visibilityLabel.Text = "Public";
			}
			else
			{
				_visibilityLabel.Text = "Unlisted";
			}
		}
	}
}
