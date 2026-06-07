using System;
using System.Text.RegularExpressions;
using Assets.Scripts.Mods;
using Assets.Scripts.Net;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI
{
	public class LoginDialogScript : PanelDialogScript
	{
		public enum LoginDialogState
		{
			LoggedOut = 0,
			LoggedIn = 1,
			Loading = 2,
			Disabled = 3
		}

		private InputWidget _inputPassword;

		private InputWidget _inputUsername;

		private bool _loggedIn;

		private TextWidget _loggedInUsername;

		private ButtonWidget _okayButton;

		private TextWidget _okayLabel;

		private LoginDialogState _state;

		private WebRequest _webRequest;

		public override void Close()
		{
			base.Close();
			if (_webRequest != null)
			{
				_webRequest.IsCanceled = true;
				_webRequest = null;
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_okayButton = widget.FindWidget<ButtonWidget>("okay-button");
			_okayLabel = widget.FindWidget<TextWidget>("okay-button-text");
			_loggedInUsername = widget.FindWidget<TextWidget>("logged-in-username");
			_inputUsername = widget.FindWidget<InputWidget>("input-username");
			_inputPassword = widget.FindWidget<InputWidget>("input-password");
			bool flag = false;
			foreach (ILoadedMod loadedMod in Game.Instance.ModManager.LoadedMods)
			{
				if (!loadedMod.ModInfo.IsBundledMod)
				{
					flag = true;
				}
			}
			if (flag)
			{
				SetState(LoginDialogState.Disabled);
			}
			else if (!string.IsNullOrEmpty(Game.Instance.Settings.App.UserName))
			{
				SetState(LoginDialogState.LoggedIn);
			}
			else
			{
				SetState(LoginDialogState.LoggedOut);
			}
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this)
			{
				if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
				{
					OnCloseClicked(null);
				}
				else if ((UnityEngine.Input.GetKeyDown(KeyCode.Return) || UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter)) && !_loggedIn)
				{
					OnLogInClicked(null);
				}
			}
		}

		private static bool IsValidEmail(string email)
		{
			return new Regex("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$").Match(email).Success;
		}

		private void OnCloseClicked(Widget widget)
		{
			Close();
		}

		private void OnLinkClicked(Widget widget)
		{
			base.Widget.Context.LinkHandler.OpenUrl(widget.Data);
		}

		private void OnLogInClicked(Widget widget)
		{
			_inputUsername.Validate();
			_inputPassword.Validate();
			if (!_inputUsername.HasError && !_inputPassword.HasError)
			{
				string value = _inputUsername.Text.Trim();
				string text = _inputPassword.Text;
				string url = Game.SimplePlanesWebsiteUrl + "/Account/ClientLogin";
				WWWForm wWWForm = new WWWForm();
				wWWForm.AddField("UserName", value);
				wWWForm.AddField("Password", text);
				wWWForm.AddField("DeviceId", Game.Instance.Device.DeviceId);
				wWWForm.AddField("DeviceModel", Game.Instance.Device.DeviceModel);
				wWWForm.AddField("DeviceName", Game.Instance.Device.DeviceName);
				_webRequest = WebRequest.Post(url, wWWForm);
				_webRequest.Complete += delegate(WebRequest r)
				{
					ProcessRequest(r);
					_webRequest = null;
				};
				SetState(LoginDialogState.Loading);
			}
		}

		private void OnLogOutClicked(Widget widget)
		{
			Game.Instance.Settings.App.UserLogOut();
			SetState(LoginDialogState.LoggedOut);
		}

		private void ProcessRequest(WebRequest request)
		{
			if (!base.IsClosed)
			{
				LoginDialogState state = LoginDialogState.LoggedOut;
				if (!request.HasError)
				{
					if (request.Text.Length > 1 && request.Text[0] == '1')
					{
						string[] array = request.Text.Split(new char[1] { ';' });
						if (array.Length >= 3)
						{
							string userName = array[1];
							string clientToken = array[2];
							Game.Instance.Settings.App.UserName = userName;
							Game.Instance.Settings.App.ClientToken = clientToken;
							Game.Instance.Settings.App.Save();
							_inputPassword.Text = string.Empty;
							state = LoginDialogState.LoggedIn;
						}
						else
						{
							Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, request.Text);
						}
					}
					else
					{
						Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, request.Text);
					}
				}
				else if (!request.IsCanceled)
				{
					Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "The request failed. Please ensure you have internet access and try again.");
				}
				SetState(state);
			}
			else
			{
				Debug.Log("Dialog was closed before web request completed");
			}
		}

		private void SetState(LoginDialogState state)
		{
			_state = state;
			base.Panel.FindWidgetsByClass("state").ForEach(delegate(Widget x)
			{
				x.Visible = false;
			});
			string className = state switch
			{
				LoginDialogState.LoggedIn => "state-logged-in", 
				LoginDialogState.LoggedOut => "state-logged-out", 
				LoginDialogState.Loading => "state-loading", 
				LoginDialogState.Disabled => "state-disabled", 
				_ => throw new NotImplementedException(), 
			};
			base.Panel.FindWidgetsByClass(className).ForEach(delegate(Widget x)
			{
				x.Visible = true;
			});
			_loggedInUsername.Text = ((state == LoginDialogState.LoggedIn) ? Game.Instance.Settings.App.UserName : string.Empty);
		}
	}
}
