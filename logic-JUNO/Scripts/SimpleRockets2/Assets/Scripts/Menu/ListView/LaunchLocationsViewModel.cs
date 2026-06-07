using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.State;
using ModApi.Craft;
using ModApi.Math;
using ModApi.Services.Purchasing;
using ModApi.State;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class LaunchLocationsViewModel : ListViewModel
	{
		private float _craftMass;

		private long _craftPrice;

		private LaunchLocationsDetails _details;

		private GameMenuScript _gameMenuScript;

		private List<LaunchLocation> _launchLocations;

		private LaunchLocation _selected;

		private bool _usingGameState;

		public Action<LaunchLocation> LaunchLocationSelected { get; set; }

		public string PrimaryButtonText { get; set; } = "SELECT";

		public string Title { get; set; } = "Launch Location";

		public LaunchLocationsViewModel(List<LaunchLocation> launchLocations, LaunchLocation selected)
		{
			if (launchLocations != null)
			{
				_launchLocations = launchLocations;
				_selected = selected;
				return;
			}
			_usingGameState = true;
			_launchLocations = Game.Instance.GameState.LaunchLocations.OrderBy((LaunchLocation x) => (!IsLocked(x)) ? (0.0 - x.LaunchCostPerKG) : x.LaunchCostPerKG).ToList();
			_selected = Game.Instance.GameState.SelectedLaunchLocation;
		}

		public LaunchLocationsViewModel(ICraftScript craftScript = null)
			: this(null, null)
		{
			if (craftScript != null)
			{
				_craftMass = craftScript.Mass;
				_craftPrice = craftScript.Data.Price;
			}
		}

		public override IEnumerator LoadItems()
		{
			_details = new LaunchLocationsDetails(base.ListView.ListViewDetails);
			ListViewItemScript selectedItem = null;
			foreach (LaunchLocation launchLocation in _launchLocations)
			{
				string text = launchLocation.PlanetName;
				if (Game.IsCareer)
				{
					text = text + " | Launch Fee: " + Units.GetMoneyString(launchLocation.CalculateLaunchCost(0f, _craftMass));
				}
				ListViewItemScript listViewItemScript = base.ListView.CreateItem(launchLocation.Name, text, launchLocation, null, ListViewScript.SpriteLoadLocation.Resources);
				listViewItemScript.InAppFeature = GetAssociatedInAppFeature(launchLocation);
				if (listViewItemScript.InAppFeature != null)
				{
					listViewItemScript.StatusIcon = ListViewItemScript.StatusIconType.Locked;
					listViewItemScript.StatusIconTooltip = "Requires upgrading to " + listViewItemScript.InAppFeature.ProductName;
					listViewItemScript.StatusIconColor = "ButtonText";
				}
				else if (Game.Instance.GameState.Validator.IsLaunchLocationLocked(launchLocation.Name))
				{
					listViewItemScript.StatusIcon = ListViewItemScript.StatusIconType.Locked;
					listViewItemScript.StatusIconTooltip = "Locked";
					listViewItemScript.StatusIconColor = "ButtonText";
				}
				if (_selected == launchLocation)
				{
					selectedItem = listViewItemScript;
				}
			}
			yield return new WaitForEndOfFrame();
			base.ListView.SelectedItem = selectedItem;
		}

		public override void OnDeleteButtonClicked(ListViewItemScript selectedItem)
		{
			base.OnDeleteButtonClicked(selectedItem);
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.OkayButtonText = "DELETE";
			LaunchLocation launchLocation = selectedItem.ItemModel as LaunchLocation;
			messageDialogScript.MessageText = $"Confirm that you want to delete the launch location '{launchLocation.Name}'";
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayClicked += OnConfirmDelete;
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.Title = Title;
			listView.CanDelete = _usingGameState;
			listView.PrimaryButtonText = PrimaryButtonText;
			listView.DisplayType = ListViewScript.ListViewDisplayType.SmallDialog;
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			if (selectedItem.InAppFeature != null)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = "You must upgrade to the " + selectedItem.InAppFeature.ProductName + " to unlock this launch location.";
				messageDialogScript.OkayButtonText = "UPGRADE";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					Game.Instance.InAppPurchases.CreatePurchaseDialog(selectedItem.InAppFeature.ProductId);
					base.ListView.Close();
				};
				return;
			}
			LaunchLocation launchLocation = selectedItem?.ItemModel as LaunchLocation;
			if (launchLocation != null && (!IsLocked(launchLocation) || CareerState.IsDebugMode))
			{
				if (_usingGameState)
				{
					Game.Instance.GameState.SelectedLaunchLocation = launchLocation;
					Game.Instance.GameState.SaveLaunchLocations();
				}
				LaunchLocationSelected?.Invoke(launchLocation);
				base.ListView.Close();
			}
			else if (IsLocked(launchLocation))
			{
				Game.Instance.UserInterface.CreateMessageDialog("This location is currently unavailable, but it can be unlocked in the future by completing a specific contract.");
			}
		}

		public override void OnSelectedItemChanged(ListViewItemScript item)
		{
			base.OnSelectedItemChanged(item);
			if (item != null)
			{
				LaunchLocation launchLocation = item.ItemModel as LaunchLocation;
				base.ListView.CanDelete = _usingGameState && (launchLocation?.UserCreated ?? false);
				if (item.InAppFeature != null)
				{
					base.ListView.PrimaryButtonText = "UPGRADE";
				}
				else
				{
					base.ListView.PrimaryButtonText = (IsLocked(launchLocation) ? "LOCKED" : PrimaryButtonText);
				}
			}
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				LaunchLocation launchLocation = item.ItemModel as LaunchLocation;
				_details.UpdateDetails(launchLocation);
			}
			completeCallback?.Invoke();
		}

		private static bool IsLocked(LaunchLocation location)
		{
			if (location != null)
			{
				return Game.Instance.GameState.Validator.IsLaunchLocationLocked(location.Name);
			}
			return false;
		}

		private IInAppPurchaseFeature GetAssociatedInAppFeature(LaunchLocation launchLocation)
		{
			if (Game.Instance.GameState.Mode == GameStateMode.Sandbox && !launchLocation.UserCreated)
			{
				if (launchLocation.Name.Contains("Ali") && !Game.Instance.InAppPurchases.Features.LaunchLocationsAli.Unlocked)
				{
					return Game.Instance.InAppPurchases.Features.LaunchLocationsAli;
				}
				if (launchLocation.Name.Contains("Luna") && !Game.Instance.InAppPurchases.Features.LaunchLocationsLuna.Unlocked)
				{
					return Game.Instance.InAppPurchases.Features.LaunchLocationsLuna;
				}
			}
			return null;
		}

		private void OnConfirmDelete(MessageDialogScript messageDialog)
		{
			messageDialog.Close();
			ListViewItemScript selectedItem = base.ListView.SelectedItem;
			LaunchLocation item = selectedItem.ItemModel as LaunchLocation;
			Game.Instance.GameState.LaunchLocations.Remove(item);
			Game.Instance.GameState.SaveLaunchLocations();
			base.ListView.DeleteItem(selectedItem);
			Items.Remove(selectedItem);
			base.ListView.SelectedItem = null;
		}
	}
}
