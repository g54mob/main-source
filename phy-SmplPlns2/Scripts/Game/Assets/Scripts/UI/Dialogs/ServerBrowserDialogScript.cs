using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Multiplayer.Lobbies;
using Assets.Scripts.Multiplayer.Lobbies.Events;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Dialogs
{
	public class ServerBrowserDialogScript : PanelDialogScript
	{
		private static List<ulong> _reportedServers = new List<ulong>();

		private ListControl<LobbyData> _listControl;

		private ILobbyManager _lobbyManager;

		private bool _worldWide;

		private ILobbyManager LobbyManager
		{
			get
			{
				return _lobbyManager;
			}
			set
			{
				if (_lobbyManager != null)
				{
					_lobbyManager.LobbyListReceived -= OnLobbyListReceived;
				}
				_lobbyManager = value;
				if (_lobbyManager != null)
				{
					_lobbyManager.LobbyListReceived += OnLobbyListReceived;
				}
			}
		}

		private bool Refreshing
		{
			get
			{
				return base.Widget.HasClass("refreshing");
			}
			set
			{
				base.Widget.EnableClass("refreshing", value);
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			Game.Instance.NetworkGameManager.InitializeSteamIfNecessary();
			ScrollViewWidget scrollView = base.Widget.FindWidget<ScrollViewWidget>("scroll-view");
			_listControl = new ListControl<LobbyData>(scrollView);
			_listControl.CreateListItem = delegate(Widget widget2, ListItem<LobbyData> item)
			{
				widget2.FindWidget<TextWidget>("item-name").Text = item.Name;
				widget2.FindWidget<TextWidget>("num-players").Text = $"{item.Item.Players} / {item.Item.MaxPlayers}";
				widget2.FindWidget<TextWidget>("max-craft-parts").Text = string.Format("{0}", (item.Item.MaxCraftPartCount == 0) ? "-" : ((object)item.Item.MaxCraftPartCount));
				widget2.FindWidget<TextWidget>("latency").Text = ((item.Item.Latency < 0) ? "-" : $"{item.Item.Latency}ms");
				widget2.FindWidget<ImageWidget>("password-protected").Visible = item.Item.PasswordProtected;
			};
			_listControl.SelectListItem = delegate(ListItem<LobbyData> item)
			{
				UpdateSelectedStatus(item);
			};
			_listControl.DeselectListItem = delegate
			{
				UpdateSelectedStatus(null);
			};
			_listControl.ListItemAction = delegate(ListItem<LobbyData> item, Widget widget2, string action)
			{
				if (action == "Report")
				{
					OnReportButtonClicked(item);
				}
			};
			base.Widget.FindWidget<InputWidget>("search-input").Input.onValueChanged.AddListener(delegate(string s)
			{
				OnSearchChanged(s);
			});
			LobbyManager = Game.Instance.NetworkGameManager.SteamLobbyManager;
			Refresh();
		}

		protected virtual void OnDestroy()
		{
			LobbyManager = null;
		}

		protected virtual void Update()
		{
			_listControl.Update();
		}

		private bool IsValidServer(LobbyData lobby)
		{
			return !_reportedServers.Contains(lobby.Id);
		}

		private void OnCloseClicked(Widget widget)
		{
			Close();
		}

		private void OnCreateServerClicked(Widget widget)
		{
			Close();
			Game.Instance.UserInterface.CreateCreateServerDialog();
		}

		private void OnJoinClicked(Widget widget)
		{
			LobbyData lobby = _listControl.SelectedItem?.Item;
			if (lobby == null)
			{
				return;
			}
			if (lobby.PasswordProtected)
			{
				InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
				inputDialogScript.Title = "Enter Server Password";
				inputDialogScript.InputPlaceholderText = string.Empty;
				inputDialogScript.InputField.Input.contentType = TMP_InputField.ContentType.Password;
				inputDialogScript.OkayClicked += delegate(InputDialogScript dialog)
				{
					dialog.Close();
					Close();
					LobbyManager.JoinLobby(lobby.Id, autoLoadScene: true, dialog.InputText);
				};
			}
			else
			{
				Close();
				LobbyManager.JoinLobby(lobby.Id, autoLoadScene: true, null);
			}
		}

		private void OnLobbyListReceived(object sender, LobbyListEventArgs e)
		{
			StartCoroutine(ResetRefreshFlag());
			if (e.Lobbies.Count > 0)
			{
				ShowMessage(null);
				RefreshListControl(e.Lobbies);
			}
			else
			{
				ShowMessage("No servers available. Try again later or start your own server.");
			}
		}

		private void OnRefreshClicked(Widget widget)
		{
			Refresh();
		}

		private void OnReportButtonClicked(ListItem<LobbyData> item)
		{
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, "Please confirm that you would like to report this server's name as offensive.");
			messageDialogScript.Title = "Report Server";
			messageDialogScript.OkayButtonText = "Report";
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				_reportedServers.Add(item.Item.Id);
				Game.Instance.NetworkGameManager.SteamLobbyManager.ReportServer(item.Item.OwnerId);
				Refresh();
			};
		}

		private void OnSearchChanged(string searchFilter)
		{
			_listControl.SearchFilter = searchFilter;
		}

		private void OnWorldWideClicked(Widget widget)
		{
			if (!Refreshing)
			{
				_worldWide = !_worldWide;
				Refresh();
			}
		}

		private void Refresh()
		{
			if (!Refreshing)
			{
				_listControl.SelectedItem = null;
				UpdateSelectedStatus(null);
				base.Widget.FindWidget<TextWidget>("worldwide-text").Text = (_worldWide ? "World Wide" : "Regional");
				_listControl.Items.Clear();
				if (LobbyManager != null)
				{
					Refreshing = true;
					ShowMessage("Refreshing server list...");
					LobbyManager.GetLobbyList(100, _worldWide, null);
				}
				else
				{
					ShowMessage("Could not initialize Steam Lobby Manager.\n\nEnsure you are logged into Steam and try restarting the game.");
				}
			}
		}

		private void RefreshListControl(IEnumerable<LobbyData> lobbies)
		{
			_listControl.Items.Clear();
			foreach (LobbyData item in (from x in lobbies
				where x.MaxPlayers <= 10
				where x.Name.Length < 50
				orderby x.Players == x.MaxPlayers, x.Latency
				group x by x.OwnerId into g
				select g.First()).ToList())
			{
				if (IsValidServer(item))
				{
					string text = (string.IsNullOrWhiteSpace(item.Name) ? "Unknown Server" : item.Name);
					_listControl.Items.Add(new ListItem<LobbyData>(text, item)
					{
						CanRename = false,
						CanDelete = false
					});
				}
			}
		}

		private IEnumerator ResetRefreshFlag()
		{
			yield return new WaitForSeconds(1f);
			Refreshing = false;
		}

		private void ShowMessage(string message)
		{
			TextWidget textWidget = base.Widget.FindWidget<TextWidget>("status-message");
			if (!string.IsNullOrWhiteSpace(message))
			{
				textWidget.Visible = true;
				textWidget.Text = message;
			}
			else
			{
				textWidget.Visible = false;
			}
		}

		private void UpdateSelectedStatus(ListItem<LobbyData> item)
		{
			base.Widget.EnableClass("server-selected", item != null);
			base.Widget.EnableClass("server-full", item != null && item.Item.Players >= item.Item.MaxPlayers);
		}
	}
}
