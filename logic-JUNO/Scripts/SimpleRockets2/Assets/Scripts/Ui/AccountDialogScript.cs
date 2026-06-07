using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.Web;
using Jundroo.ModTools;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Web.Client.Models;

namespace Assets.Scripts.Ui
{
	public class AccountDialogScript : DialogScript
	{
		private Button _cancelButton;

		private XmlElement _form;

		private Button _logoutButton;

		private XmlElement _lostPassword;

		private Button _okayButton;

		private TextMeshProUGUI _okayButtonLabel;

		private XmlElement _panel;

		private TMP_InputField _passwordInput;

		private RawImage _profileImage;

		private XmlElement _profilePanel;

		private TextMeshProUGUI _profileUsername;

		private TMP_InputField _usernameInput;

		private WebRequest _webRequest;

		public static AccountDialogScript Create(Transform parent)
		{
			if (string.IsNullOrWhiteSpace(Game.Instance.Settings.UserName) && Game.Instance.ModManager.KnownMods.Any((ModInfo x) => x.Enabled || x.PendingDisable))
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "All mods must be disabled and the game must be restarted in order to log into an account. After logging in, mods can be re-enabled and you should remain logged in.";
				return null;
			}
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/AccountDialog", parent, delegate(AccountDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
		}

		public override void Close()
		{
			base.Close();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				Object.Destroy(base.gameObject);
			});
		}

		public void OnLogoutButtonClicked()
		{
			_form.gameObject.SetActive(value: true);
			_profilePanel.gameObject.SetActive(value: false);
			_okayButton.gameObject.SetActive(value: true);
			_logoutButton.gameObject.SetActive(value: false);
			Game.Instance.Settings.UserName = string.Empty;
			Game.Instance.Settings.ClientToken = string.Empty;
			Game.Instance.Settings.Save();
			if (Game.Instance.ModManager.KnownMods.Any((ModInfo x) => x.Enabled || x.PendingDisable))
			{
				Close();
			}
		}

		public void ShowError(string message)
		{
			Game.Instance.UserInterface.CreateMessageDialog().MessageText = message;
		}

		protected virtual void OnDestroy()
		{
			if (_profileImage != null && _profileImage.texture != null)
			{
				Object.Destroy(_profileImage.texture);
				_profileImage.texture = null;
			}
		}

		protected override void Start()
		{
			base.Start();
			_panel.Show();
		}

		private static bool IsValidEmail(string email)
		{
			return new Regex("^([\\w\\.\\-\\+]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$").Match(email).Success;
		}

		private static bool IsValidPassword(string password)
		{
			if (!string.IsNullOrWhiteSpace(password))
			{
				return password.Length >= 6;
			}
			return false;
		}

		private static bool IsValidUsername(string username)
		{
			if (!string.IsNullOrWhiteSpace(username))
			{
				return username.Length >= 3;
			}
			return false;
		}

		private void ChangeElementVisibility(GameObject g, bool visible)
		{
			XmlElement parentElementWithClass = g.GetComponent<XmlElement>().GetParentElementWithClass("hide-row");
			LayoutElementAnimator layoutElementAnimator = parentElementWithClass.GetComponent<LayoutElementAnimator>();
			if (layoutElementAnimator == null)
			{
				layoutElementAnimator = parentElementWithClass.gameObject.AddComponent<LayoutElementAnimator>();
			}
			if (visible)
			{
				layoutElementAnimator.ShowVertical();
			}
			else
			{
				layoutElementAnimator.HideVertical();
			}
		}

		private IEnumerator DownloadProfileImage()
		{
			string uri = string.Format(Game.SimpleRocketsWebsiteUrl + "/Api/ProfileImage?userName={0}&size={1}", Game.Instance.Settings.UserName, 256);
			UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri, nonReadable: true);
			yield return request.SendWebRequest();
			_profileImage.texture = DownloadHandlerTexture.GetContent(request);
			if (_profileImage.texture != null)
			{
				_profileImage.gameObject.SetActive(value: true);
				_profileImage.texture.name = "UserProfileImage";
			}
		}

		private void OnCancelClicked()
		{
			Close();
		}

		private void OnDeleteProfileClicked()
		{
			WebUtility.OpenUrl(Game.SimpleRocketsWebsiteUrl + "/Account/DeleteAccount");
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_profilePanel = xmlLayout.GetElementById("profile");
			_cancelButton = xmlLayout.GetElementById<Button>("cancel-button");
			_okayButton = xmlLayout.GetElementById<Button>("okay-button");
			_logoutButton = xmlLayout.GetElementById<Button>("logout-button");
			_usernameInput = xmlLayout.GetElementById<TMP_InputField>("username-input");
			_passwordInput = xmlLayout.GetElementById<TMP_InputField>("password-input");
			_lostPassword = xmlLayout.GetElementById("lost-password");
			_form = xmlLayout.GetElementById("form");
			_okayButtonLabel = _okayButton.GetComponentInChildren<TextMeshProUGUI>();
			_cancelButton.onClick.AddListener(delegate
			{
				OnCancelClicked();
			});
			_okayButton.onClick.AddListener(delegate
			{
				OnOkayClicked();
			});
			_logoutButton.onClick.AddListener(delegate
			{
				OnLogoutButtonClicked();
			});
			_profileUsername = xmlLayout.GetElementById<TextMeshProUGUI>("profile-username");
			_profileImage = xmlLayout.GetElementById<RawImage>("profile-image");
			_profileImage.gameObject.SetActive(value: false);
			if (!string.IsNullOrWhiteSpace(Game.Instance.Settings.UserName))
			{
				StartCoroutine(DownloadProfileImage());
				_form.gameObject.SetActive(value: false);
				_profilePanel.gameObject.SetActive(value: true);
				_okayButton.gameObject.SetActive(value: false);
				_logoutButton.gameObject.SetActive(value: true);
				_profileUsername.text = Game.Instance.Settings.UserName;
			}
			else
			{
				_form.gameObject.SetActive(value: true);
				_profilePanel.gameObject.SetActive(value: false);
			}
			_panel.SetAttribute("active", "false");
		}

		private void OnLostPasswordClicked()
		{
			WebUtility.OpenUrl(Game.SimpleRocketsWebsiteUrl + "/Account/ForgotPassword");
		}

		private void OnOkayClicked()
		{
			if (_webRequest == null)
			{
				string value = _usernameInput.text.Trim();
				string text = _passwordInput.text;
				bool flag = true;
				if (!IsValidPassword(text))
				{
					ShowError("Password must be at least 6 characters long.");
					flag = false;
				}
				if (flag)
				{
					WWWForm wWWForm = new WWWForm();
					wWWForm.AddField("UserName", value);
					wWWForm.AddField("Password", text);
					wWWForm.AddField("DeviceId", Game.Instance.Device.DeviceId);
					wWWForm.AddField("DeviceModel", Game.Instance.Device.DeviceModel);
					wWWForm.AddField("DeviceName", Game.Instance.Device.DeviceName);
					string simpleRocketsWebsiteUrl = Game.SimpleRocketsWebsiteUrl;
					simpleRocketsWebsiteUrl += "/Account/ClientLogin";
					_webRequest = WebRequest.Create(simpleRocketsWebsiteUrl, wWWForm);
					_okayButtonLabel.text = "SENDING...";
					_form.SetAndApplyAttribute("opacity", "0.25");
				}
			}
		}

		private void OnRegisterHereClicked()
		{
			WebUtility.OpenUrl(Game.SimpleRocketsWebsiteUrl + "/Account/Register");
		}

		private void OnTermsOfUseClicked()
		{
			WebUtility.OpenUrl(Game.SimpleRocketsWebsiteUrl + "/About/Terms");
		}

		private void OnViewProfileClicked()
		{
			WebUtility.OpenUrl(Game.SimpleRocketsWebsiteUrl + "/u/" + Game.Instance.Settings.UserName);
		}

		private void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this && (UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter) || UnityEngine.Input.GetKeyDown(KeyCode.Return)))
			{
				OnOkayClicked();
			}
			if (_webRequest == null || !_webRequest.IsDone)
			{
				return;
			}
			_okayButtonLabel.text = "OKAY";
			_form.SetAndApplyAttribute("opacity", "1.0");
			if (string.IsNullOrEmpty(_webRequest.Error))
			{
				ClientResponse clientResponse = WebUtility.CreateClientResponse(_webRequest.Text);
				if (clientResponse.Succeeded)
				{
					Game.Instance.Settings.UserName = clientResponse.GetValue("UserName");
					Game.Instance.Settings.ClientToken = clientResponse.GetValue("ClientToken");
					Game.Instance.Settings.Save();
					Close();
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = clientResponse.Error;
				}
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "The request failed. Please ensure you have Internet access and try again.";
			}
			_webRequest = null;
		}
	}
}
