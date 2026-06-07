using System;
using System.Collections;
using System.IO;
using Assets.Scripts.Net;
using Assets.Scripts.UI;
using Jundroo.Common.Cache;
using Jundroo.Common.Coroutines;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Web.Client.Models;

namespace Assets.Scripts.Menu.LevelMenuVR
{
	internal class AccountDialogScript : MonoBehaviour
	{
		public delegate void DialogDelegate(AccountDialogScript dialog);

		[SerializeField]
		private Button _buttonComplete;

		[SerializeField]
		private Button _buttonLogin;

		[SerializeField]
		private TextMeshProUGUI _errorMessageCode;

		[SerializeField]
		private TextMeshProUGUI _errorMessageStart;

		private DateTime? _expirationDateTime;

		[SerializeField]
		private TextMeshProUGUI _expirationText;

		private bool _initialized;

		private string _loginCode;

		[SerializeField]
		private TextMeshProUGUI _loginCodeText;

		[SerializeField]
		private RawImage _profileImage;

		[SerializeField]
		private GameObject _sectionCode;

		[SerializeField]
		private GameObject _sectionLoggedOn;

		[SerializeField]
		private GameObject _sectionStart;

		[SerializeField]
		private TextMeshProUGUI _userNameText;

		private WebCacheScript _webCache;

		private string BaseUrl => Game.SimplePlanesWebsiteUrl + "/Device";

		public event DialogDelegate Closed;

		public static AccountDialogScript CreateDialog(RectTransform parent = null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("Menu/VR/AccountDialog")) as GameObject;
			if (parent != null)
			{
				gameObject.transform.SetParent(parent, worldPositionStays: false);
			}
			else
			{
				Canvas canvas = UnityEngine.Object.FindFirstObjectByType<Canvas>();
				gameObject.transform.SetParent(canvas.transform, worldPositionStays: false);
			}
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			return gameObject.GetComponent<AccountDialogScript>();
		}

		public void Close()
		{
			Game.Instance.Settings.App.Save();
			this?.Closed(this);
			base.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void OnCancelButtonClicked()
		{
			Close();
		}

		public void OnCompleteButtonClicked()
		{
			StartCoroutine(CompleteRoutine());
		}

		public void OnLoginButtonClicked()
		{
			StartCoroutine(LoginRoutine());
		}

		public void OnLogOutButtonClicked()
		{
			Game.Instance.Settings.App.UserLogOut();
			Close();
		}

		protected virtual void Start()
		{
			_webCache = Game.Instance.WebCache;
			if (Game.Instance.Settings.App.IsLoggedIn)
			{
				ShowLoggedInPanel();
				return;
			}
			_sectionStart.SetActive(value: true);
			_sectionCode.SetActive(value: false);
			_sectionLoggedOn.SetActive(value: false);
			RefreshLayout();
		}

		protected virtual void Update()
		{
			if (_expirationDateTime.HasValue)
			{
				TimeSpan timeSpan = _expirationDateTime.Value - DateTime.UtcNow;
				_expirationText.text = $"Expires in {timeSpan.TotalMinutes:n1} minutes";
			}
		}

		private void CancelClicked()
		{
			Game.Instance.UserInterface.Sound.PlaySound(UISound.ButtonClick);
			Close();
		}

		private IEnumerator CompleteRoutine()
		{
			yield return SubmitDeviceRequest(_loginCode, "ClientCompleteLogin", _buttonComplete, _errorMessageCode, delegate(ClientResponse response)
			{
				if (Utilities.ParseBool(response.GetValue("Verified")))
				{
					Game.Instance.Settings.App.UserName = response.GetValue("UserName");
					Game.Instance.Settings.App.ClientToken = response.GetValue("ClientToken");
					Game.Instance.Settings.App.UserIsCurator = Utilities.ParseBool(response.GetValue("Curator"));
					Game.Instance.Settings.App.Save();
					ShowLoggedInPanel();
					return (string)null;
				}
				return "It looks like you have not verified the code yet on your mobile device or computer.";
			});
		}

		private IEnumerator LoginRoutine()
		{
			yield return SubmitDeviceRequest(null, "ClientLoginRequest", _buttonLogin, _errorMessageStart, delegate(ClientResponse response)
			{
				_loginCode = response.GetValue("LoginCode");
				if (DateTime.TryParse(response.GetValue("ExpirationDate"), out var result))
				{
					_expirationDateTime = result;
				}
				_loginCodeText.text = _loginCode;
				_sectionStart.SetActive(value: false);
				_sectionCode.SetActive(value: true);
				RefreshLayout();
				return (string)null;
			});
		}

		private void RefreshLayout()
		{
			StartCoroutine(RefreshLayoutRoutine());
		}

		private IEnumerator RefreshLayoutRoutine()
		{
			yield return new WaitForEndOfFrame();
			foreach (Transform item in base.transform)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(item.GetComponent<RectTransform>());
			}
		}

		private void ShowLoggedInPanel()
		{
			_sectionStart.SetActive(value: false);
			_sectionCode.SetActive(value: false);
			_sectionLoggedOn.SetActive(value: true);
			RefreshLayout();
			string userName = Game.Instance.Settings.App.UserName;
			_userNameText.text = userName;
			string url = string.Format(Game.SimplePlanesWebsiteUrl + "/Api/ProfileImage?userName={0}&size={1}", userName, 256);
			_webCache.GetBinary(url, 0, delegate(WebYieldRequest<byte[]> request)
			{
				if (request.Success)
				{
					Texture2D texture2D = new Texture2D(256, 256);
					texture2D.LoadImage(request.Data);
					texture2D.wrapMode = TextureWrapMode.Clamp;
					_profileImage.texture = texture2D;
				}
			});
		}

		private IEnumerator SubmitDeviceRequest(string loginCode, string urlAction, Button button, TextMeshProUGUI errorText, Func<ClientResponse, string> successAction)
		{
			button.interactable = false;
			TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
			string initialButtonText = text.text;
			text.text = "WORKING...";
			string uri = Path.Combine(BaseUrl, urlAction);
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("DeviceId", Game.Instance.Device.DeviceId);
			wWWForm.AddField("DeviceModel", Game.Instance.Device.DeviceModel);
			wWWForm.AddField("DeviceName", Game.Instance.Device.DeviceName);
			if (loginCode != null)
			{
				wWWForm.AddField("LoginCode", loginCode);
			}
			using UnityWebRequest request = UnityWebRequest.Post(uri, wWWForm);
			yield return request.SendWebRequest();
			string text2;
			if (request.result == UnityWebRequest.Result.Success)
			{
				ClientResponse clientResponse = WebUtility.CreateClientResponse(request.downloadHandler.text);
				if (clientResponse.Succeeded)
				{
					try
					{
						text2 = successAction(clientResponse);
					}
					catch (Exception ex)
					{
						text2 = ex.ToString();
					}
				}
				else
				{
					text2 = clientResponse.Error;
				}
			}
			else
			{
				text2 = request.error;
			}
			if (text2 != null)
			{
				errorText.text = text2;
				errorText.gameObject.SetActive(value: true);
				button.interactable = true;
				text.text = initialButtonText;
			}
		}
	}
}
