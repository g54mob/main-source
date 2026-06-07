using System;
using System.Collections;
using Assets.Scripts.Ui.Sharing.Screenshot;
using Assets.Scripts.Web;
using ModApi.Common.Extensions;
using ModApi.Services.Purchasing;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Sharing.Upload
{
	public class UploadContentDialogScript : DialogScript
	{
		private XmlElement _accountLabel;

		private TMP_InputField _descriptionInput;

		private GameObject _formPanel;

		private TMP_InputField _nameInput;

		private XmlElement _panel;

		private Toggle _publicToggleButton;

		private ScreenshotListController _screenshotList;

		private XmlElement _uploadCancelButton;

		private GameObject _uploadingPanel;

		private RectTransform _uploadProgressBar;

		private TextMeshProUGUI _uploadStatusLabel;

		public UploadContentViewModel ViewModel { get; private set; }

		protected bool IsClosed { get; private set; }

		public static UploadContentDialogScript Create(Transform parent, UploadContentViewModel viewModel)
		{
			IUserInterface userInterface = Game.Instance.UserInterface;
			return userInterface.CreateDialog("Ui/Xml/Sharing/UploadContentDialog", parent ?? userInterface.Transform, delegate(UploadContentDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			}, delegate(UploadContentDialogScript d)
			{
				d.ViewModel = viewModel;
			});
		}

		public override void Close()
		{
			base.Close();
			IsClosed = true;
			ViewModel.OnDialogClosed();
			_screenshotList.OnDialogClosed();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}

		public void ShowError(string message)
		{
			Game.Instance.UserInterface.CreateErrorDialog(message);
		}

		protected void OnAccountButtonClicked()
		{
			AccountDialogScript accountDialogScript = AccountDialogScript.Create(base.transform.parent);
			if (accountDialogScript != null)
			{
				accountDialogScript.Closed += OnAccountDialogClosed;
			}
		}

		protected void OnCancelButtonClicked()
		{
			Close();
		}

		protected void OnCancelUploadButtonClicked()
		{
			ViewModel.Cancel();
			_uploadCancelButton.gameObject.SetActive(value: false);
		}

		protected void OnUploadButtonClicked()
		{
			UploadContentModel uploadContentModel = new UploadContentModel();
			uploadContentModel.Name = _nameInput.text.Trim();
			uploadContentModel.Description = _descriptionInput.text.Trim();
			uploadContentModel.IsPublic = _publicToggleButton.isOn;
			uploadContentModel.Screenshots.AddRange(_screenshotList.GetTextures());
			uploadContentModel.ValidPhotoChecksums = _screenshotList.ValidChecksums;
			if (string.IsNullOrWhiteSpace(uploadContentModel.Name))
			{
				ShowError("Please enter a name for the upload.");
				return;
			}
			if (uploadContentModel.Description.Length < ViewModel.MinDescriptionLength)
			{
				ShowError($"Your description must be at least {ViewModel.MinDescriptionLength} characters long.");
				return;
			}
			if (!_screenshotList.HasPrimaryThumbnail)
			{
				ShowError("You must provide the required screenshot.");
				return;
			}
			if (string.IsNullOrEmpty(Game.Instance.Settings.UserName) || string.IsNullOrEmpty(Game.Instance.Settings.ClientToken))
			{
				ShowError("You need to login and/or create an account.");
				return;
			}
			_formPanel.SetActive(value: false);
			_uploadingPanel.SetActive(value: true);
			_uploadCancelButton.gameObject.SetActive(value: true);
			OnUploadProgressed(0f);
			this.StartThrowingCoroutine(UploadContent(uploadContentModel), delegate(Exception ex)
			{
				Debug.LogException(ex);
				OnUploadCompleted(new UploadContentResult(UploadContentResultType.Failure, "An unexpected failure occurred: " + ex.Message));
			});
		}

		protected override void Start()
		{
			base.Start();
			_nameInput.text = ViewModel.DefaultName;
			_descriptionInput.text = ViewModel.DefaultDescription;
			_panel.Show();
			this.StartThrowingCoroutine(DialogCreatedCoroutine(), delegate(Exception ex)
			{
				Debug.LogException(ex);
				Close();
				Game.Instance.UserInterface.CreateErrorDialog("An unexpected failure occurred: " + ex.Message);
			});
		}

		private IEnumerator DialogCreatedCoroutine()
		{
			yield return null;
			_formPanel.SetActive(value: false);
			yield return ViewModel.DialogCreated(Close, delegate(float progress, Func<float, string> progressLabel)
			{
				_uploadingPanel.SetActive(value: true);
				OnUploadProgressed(progress, progressLabel);
			});
			if (!IsClosed)
			{
				_formPanel.SetActive(value: true);
				_uploadingPanel.SetActive(value: false);
			}
		}

		private void OnAccountDialogClosed(IDialog dialog)
		{
			UpdateAccountLabel();
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_accountLabel = xmlLayout.GetElementById("account-label");
			_descriptionInput = xmlLayout.GetElementById<TMP_InputField>("description-input");
			_nameInput = xmlLayout.GetElementById<TMP_InputField>("name-input");
			_formPanel = xmlLayout.GetElementById("form").gameObject;
			_publicToggleButton = xmlLayout.GetElementById<Toggle>("public-toggle");
			XmlElement elementById = xmlLayout.GetElementById("screenshot-panel");
			_screenshotList = elementById.GetComponentInChildren<ScreenshotListController>();
			IInAppPurchaseFeature feature = Game.Instance.InAppPurchases.Features.RemoveAds;
			if (!feature.Unlocked)
			{
				foreach (XmlElement item in xmlLayout.GetElementsByClass("post-visibility-toggle"))
				{
					item.AddOnClickEvent(delegate
					{
						ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
						messageDialogScript.OkayButtonText = "UPGRADE";
						messageDialogScript.MessageText = "Upgrade to the " + feature.ProductName + " to unlock the ability upload content as unlisted.";
						messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
						{
							d.Close();
							Game.Instance.InAppPurchases.CreatePurchaseDialog(feature.ProductId);
						};
						_publicToggleButton.isOn = true;
					});
				}
			}
			_uploadingPanel = xmlLayout.GetElementById("uploading-panel").gameObject;
			_uploadProgressBar = xmlLayout.GetElementById<RectTransform>("upload-progress");
			_uploadStatusLabel = xmlLayout.GetElementById<TextMeshProUGUI>("upload-status-label");
			_uploadCancelButton = xmlLayout.GetElementById("upload-cancel-button");
			UpdateAccountLabel();
			if (ViewModel != null)
			{
				_screenshotList.Initialize(base.transform, ViewModel.MaxOptionalScreenshots);
				_screenshotList.PreventTakeScreenshot = ViewModel.PreventTakeScreenshot;
				xmlLayout.GetElementById("content-title").SetText(ViewModel.Title);
				xmlLayout.GetElementById("name-input-placeholder").SetText(ViewModel.NameLabel);
				xmlLayout.GetElementById("description-input-placeholder").SetText(ViewModel.DescriptionLabel);
			}
			_panel.SetAttribute("active", "false");
		}

		private void OnUploadCompleted(UploadContentResult result)
		{
			if (result.Result == UploadContentResultType.Success)
			{
				Debug.Log("Upload successful. Opening URL: " + result.Message);
				WebUtility.OpenUrl(result.Message);
				Close();
				return;
			}
			if (result.Result == UploadContentResultType.Canceled)
			{
				Debug.Log("Upload Canceled");
				_formPanel.gameObject.SetActive(value: true);
				_uploadingPanel.gameObject.SetActive(value: false);
				return;
			}
			if (result.Result == UploadContentResultType.CommunicationFailure)
			{
				Debug.LogError("\"" + ViewModel.Title + "\" upload failed (communication): " + (result.WebRequest?.Error ?? result.Message));
			}
			else if (result.Result == UploadContentResultType.ServerFailure || result.Result == UploadContentResultType.ServerFailureForceLogOff)
			{
				Debug.LogError("\"" + ViewModel.Title + "\" upload failed (server-side): " + (result.WebRequest?.Response?.Error ?? result.Message));
				if (result.Result == UploadContentResultType.ServerFailureForceLogOff)
				{
					Game.Instance.Settings.UserName = null;
					Game.Instance.Settings.ClientToken = null;
					Game.Instance.Settings.Save();
					UpdateAccountLabel();
				}
			}
			else
			{
				Debug.LogError("\"" + ViewModel.Title + "\" upload failed: " + result.Message);
			}
			Game.Instance.UserInterface.CreateErrorDialog(result.Message);
			Close();
		}

		private void OnUploadProgressed(float progress, Func<float, string> progressLabel = null)
		{
			_uploadProgressBar.localScale = new Vector3(progress, 1f, 1f);
			_uploadStatusLabel.text = progressLabel?.Invoke(progress) ?? ((progress < 1f) ? $"Uploading: {(int)(progress * 100f)}%" : "Processing...");
		}

		private void UpdateAccountLabel()
		{
			if (!string.IsNullOrEmpty(Game.Instance.Settings.UserName))
			{
				_accountLabel.SetAndApplyAttribute("text", Game.Instance.Settings.UserName);
			}
			else
			{
				_accountLabel.SetAndApplyAttribute("text", "Login / Register");
			}
		}

		private IEnumerator UploadContent(UploadContentModel model)
		{
			yield return new WaitForEndOfFrame();
			yield return ViewModel.PrepareToSend();
			yield return ViewModel.Upload(model, OnUploadProgressed, OnUploadCompleted);
		}
	}
}
