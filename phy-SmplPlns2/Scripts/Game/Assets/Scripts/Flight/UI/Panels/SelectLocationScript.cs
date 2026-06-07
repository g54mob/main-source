using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.Discoverables;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Cysharp.Threading.Tasks;
using Jundroo.Juicy.Widgets;
using Jundroo.SocialPlatforms;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class SelectLocationScript : FlightPanelScript
	{
		private List<StartLocationData> _callbackLocations;

		private Action _callbackOnClosed;

		private Action<StartLocationData> _callbackOnSelected;

		private ListControl<StartLocationData> _listControl;

		private InputWidget _searchInput;

		private bool IsCallbackMode => _callbackLocations != null;

		public override void InitializeFlightPanel(FlightUIScript flightUI)
		{
			base.InitializeFlightPanel(flightUI);
			_searchInput = base.Widget.FindWidget<InputWidget>("search-input");
			_searchInput.Input.onValueChanged.AddListener(delegate(string s)
			{
				OnSearchChanged(s);
			});
			_listControl = new ListControl<StartLocationData>(base.Widget.FindWidget<ScrollViewWidget>("scroll-view"), "location-list-item");
			_listControl.CreateListItem = delegate(Widget widget, ListItem<StartLocationData> item)
			{
				widget.FindWidget<TextWidget>("name").Text = item.Item.DisplayName;
				widget.FindWidget<TextWidget>("area").Text = item.Item.AreaName;
				ImageWidget imageWidget = widget.FindWidget<ImageWidget>("icon");
				imageWidget.EnableClass("type-default", item.Item.LocationType == StartLocationType.Default);
				imageWidget.EnableClass("type-custom", item.Item.LocationType == StartLocationType.Custom);
				imageWidget.EnableClass("type-discovered", item.Item.LocationType == StartLocationType.Discoverable);
			};
			_listControl.SelectListItem = delegate(ListItem<StartLocationData> x)
			{
				if (x != null && !IsCallbackMode)
				{
					TeleportToLocation(x.Item);
				}
			};
			_listControl.FilterListItem = (ListItem<StartLocationData> listItem, string searchFilter) => string.IsNullOrEmpty(searchFilter) || listItem.Item.DisplayName.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) || (listItem.Item.AreaName?.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) ?? false);
			_listControl.DeleteListItem = delegate(ListItem<StartLocationData> x)
			{
				if (x.Item.LocationType == StartLocationType.Custom)
				{
					FlightSceneScript.Instance.StartLocationManager.RemoveCustomStartingLocation(x.Item.Id);
					BuildLocationList();
				}
			};
			base.Flyout.Opened += delegate
			{
				base.Widget.ExecuteOnWidgetsOfClass("normal-mode", delegate(Widget w)
				{
					w.Visible = !IsCallbackMode;
				});
				base.Widget.ExecuteOnWidgetsOfClass("callback-mode", delegate(Widget w)
				{
					w.Visible = IsCallbackMode;
				});
				BuildLocationList();
				if (!SocialExt.IsSteamDeckOrBigPicture)
				{
					_searchInput.Input.Select();
				}
			};
			base.Flyout.Closed += delegate
			{
				if (IsCallbackMode)
				{
					_callbackOnClosed?.Invoke();
					_callbackLocations = null;
					_callbackOnClosed = null;
					_callbackOnSelected = null;
				}
			};
		}

		public void OnLocationDoubleClicked()
		{
			if (IsCallbackMode)
			{
				OnExecuteCallbackClicked(null);
			}
			else
			{
				base.Flyout.Close();
			}
		}

		public void SelectLocation(List<StartLocationData> locations, Action<StartLocationData> onSelected, Action onClosed)
		{
			_callbackLocations = locations;
			_callbackOnSelected = onSelected;
			_callbackOnClosed = onClosed;
		}

		protected void Update()
		{
			_listControl.Update();
		}

		private void BuildLocationList()
		{
			IReadOnlyList<StartLocationData> callbackLocations = _callbackLocations;
			List<StartLocationData> list = (callbackLocations ?? FlightSceneScript.Instance.StartLocationManager.Locations).OrderBy((StartLocationData x) => x.DisplayName).ToList();
			_listControl.Items.Clear();
			bool flag = base.Widget.FindWidget("filter-default").HasClass("btn-primary");
			bool flag2 = base.Widget.FindWidget("filter-discovered").HasClass("btn-primary");
			bool flag3 = base.Widget.FindWidget("filter-custom").HasClass("btn-primary");
			foreach (StartLocationData item in list)
			{
				if ((flag || item.LocationType != StartLocationType.Default) && (flag3 || item.LocationType != StartLocationType.Custom) && (flag2 || item.LocationType != StartLocationType.Discoverable))
				{
					_listControl.Items.Add(new ListItem<StartLocationData>(item.Id, item)
					{
						CanRename = false,
						CanDelete = (item.LocationType == StartLocationType.Custom && _callbackLocations == null)
					});
				}
			}
		}

		private void OnAddCurrentLocationClicked(Widget widget)
		{
			InputDialogScript dialog = Game.Instance.UserInterface.CreateInputDialog();
			dialog.Title = "Add Current Location";
			dialog.InputText = _searchInput.Text;
			dialog.MessageText = "Enter a name for the location.";
			dialog.OkayClicked += delegate
			{
				FlightScenePlayer player = FlightSceneScript.Instance.LocalPlayer;
				if (player == null)
				{
					Debug.LogError("Unable to add a location when the local player is not loaded.");
					dialog.Close();
				}
				else
				{
					string inputText = dialog.InputText;
					StartLocationManagerScript manager = FlightSceneScript.Instance.StartLocationManager;
					Action saveLocation = delegate
					{
						bool startGrounded = Physics.Raycast(new Ray(player.FramePosition, Vector3.down), 15f, 9437184);
						manager.CreateCustomStartingLocation(dialog.InputText, AreaNameScript.FindClosestAreaName(player.FramePosition, mustBeWithinArea: true) ?? "Unknown", player.GlobalPosition, player.Rotation, player.Aircraft?.Velocity ?? Vector3.zero, startGrounded);
						BuildLocationList();
					};
					StartLocationData startLocation = manager.GetStartLocation(inputText, includeUndiscoveredLocations: true);
					if (startLocation != null)
					{
						if (startLocation.LocationType == StartLocationType.Custom)
						{
							MessageDialogScript overwriteDialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
							overwriteDialog.MessageText = "A location with that name already exists. Do you wish to overwrite it?";
							overwriteDialog.CancelButtonText = "Cancel";
							overwriteDialog.OkayButtonText = "Overwrite";
							overwriteDialog.CancelClicked += delegate
							{
								overwriteDialog.Close();
							};
							overwriteDialog.OkayClicked += delegate(MessageDialogScript od)
							{
								saveLocation();
								od.Close();
							};
						}
					}
					else
					{
						saveLocation();
					}
					dialog.Close();
				}
			};
		}

		private void OnExecuteCallbackClicked(Widget widget)
		{
			_callbackOnSelected?.Invoke(_listControl.SelectedItem?.Item);
			base.Flyout.Show(show: false);
		}

		private void OnFilterClicked(Widget widget)
		{
			widget.ToggleClass("btn-primary");
			BuildLocationList();
		}

		private void OnSearchChanged(string s)
		{
			if (s == "cheater")
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "All Locations Unlocked";
				Game.Instance.Settings.Cloud.Locations.UnlockAllDiscoverableLocations();
				_searchInput.Text = string.Empty;
				BuildLocationList();
			}
			else
			{
				_listControl.SearchFilter = s;
			}
		}

		private void TeleportToLocation(StartLocationData startingLocation)
		{
			if (FlightSceneScript.Instance.LocalPlayer.IsRepositioning)
			{
				Debug.LogWarning("Unable to reposition the local player because the player is already being repositioned.");
				return;
			}
			UniTask.Void(async delegate
			{
				try
				{
					GameState.Instance.RaiseMapLocationChanging(startingLocation.Id, startingLocation.DisplayName);
					PositionResult positionResult = await PositionUtility.PositionAtLocation(startingLocation, FlightSceneScript.Instance.LocalPlayer, allowRepositioning: true, floatOriginToLocation: true);
					if (positionResult == PositionResult.Success)
					{
						FlightSceneScript.Instance.StartLocationManager.SetCurrentLocation(startingLocation);
						GameState.Instance.RaiseMapLocationChanged(startingLocation.Id, startingLocation.DisplayName);
					}
					else
					{
						PositionUtility.ShowPositionResultErrorDialog(positionResult, startingLocation.DisplayName);
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "An error occurred attempting to reposition to location '" + startingLocation.DisplayName + "'");
				}
			});
		}
	}
}
