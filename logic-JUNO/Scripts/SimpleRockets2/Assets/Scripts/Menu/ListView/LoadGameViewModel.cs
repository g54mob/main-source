using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Mods;
using Assets.Scripts.State;
using Assets.Scripts.Tools;
using ModApi;
using ModApi.Mods;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class LoadGameViewModel : ListViewModel
	{
		private LoadGameDetails _details;

		public override IEnumerator LoadItems()
		{
			_details = new LoadGameDetails(base.ListView.ListViewDetails);
			List<string> gameStateIds = Game.Instance.GameStateManager.GetGameStateIds();
			List<GameStateInfo> list = new List<GameStateInfo>(gameStateIds.Count);
			foreach (string item in gameStateIds)
			{
				GameStateInfo gameStateInfo;
				try
				{
					gameStateInfo = GameStateInfo.Load(item);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("An error occurred reading game state info for game state '" + item + "'");
					continue;
				}
				if (gameStateInfo == null)
				{
					Debug.LogError("Unable to find game state " + item + ".");
				}
				else
				{
					list.Add(gameStateInfo);
				}
			}
			foreach (GameStateInfo item2 in list.OrderByDescending((GameStateInfo x) => x.LastModifiedDateTime))
			{
				string subtitle = (item2.LastModifiedDateTime.HasValue ? Utilities.RelativeDate(DateTime.Now, item2.LastModifiedDateTime.Value) : string.Empty);
				ListViewItemScript listViewItemScript = base.ListView.CreateItem(item2.CompanyName ?? "Unknown", subtitle, item2, null, ListViewScript.SpriteLoadLocation.Resources);
				if (item2.GameStateId == Game.Instance.GameState.Id)
				{
					listViewItemScript.StatusIcon = ListViewItemScript.StatusIconType.Checkmark;
					listViewItemScript.StatusIconTooltip = "Currently Loaded";
					listViewItemScript.StatusIconColor = "White";
				}
			}
			yield return new WaitForEndOfFrame();
		}

		public override void OnDeleteButtonClicked(ListViewItemScript selectedItem)
		{
			GameStateInfo gameStateInfo = selectedItem.ItemModel as GameStateInfo;
			if (gameStateInfo.GameStateId != Game.Instance.GameState.Id)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.OkayButtonText = "DELETE";
				messageDialogScript.MessageText = string.Format("Confirm that you want to delete the game '{0}'", gameStateInfo.CompanyName ?? "Unknown");
				messageDialogScript.UseDangerButtonStyle = true;
				messageDialogScript.OkayClicked += OnConfirmDelete;
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You cannot delete this game since it is currently loaded.";
			}
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.Title = "Load Game";
			listView.CanDelete = true;
			listView.PrimaryButtonText = "LOAD";
			listView.DisplayType = ListViewScript.ListViewDisplayType.SmallDialog;
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			try
			{
				GameStateInfo gameStateInfo = selectedItem.ItemModel as GameStateInfo;
				GameState gameState = Game.Instance.GameStateManager.LoadGameState(gameStateInfo.GameStateId);
				if (gameState == null)
				{
					Game.Instance.UserInterface.CreateErrorDialog("Loading the save failed!\nCheck the log for more info");
					return;
				}
				RequiredModsCheck requiredModsCheck = new RequiredModsCheck(gameState.LoadFlightStateData().FlightStateRequiredMods);
				if (requiredModsCheck.AllRequirementsMet)
				{
					LoadGame(gameState);
					return;
				}
				RequiredModsDialogScript.Create(requiredModsCheck).OkayClicked += delegate
				{
					LoadGame(gameState);
				};
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Game.Instance.UserInterface.CreateErrorDialog("Loading the save failed!\nCheck the log for more info");
			}
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				GameStateInfo gameState = item.ItemModel as GameStateInfo;
				_details.UpdateDetails(gameState);
			}
			completeCallback?.Invoke();
		}

		private void LoadGame(GameState gameState)
		{
			Game.Instance.GameState = gameState;
			PartViewerScript.RegeneratePartIcons = true;
			Game.Instance.SceneManager.LoadMenu();
		}

		private void OnConfirmDelete(MessageDialogScript messageDialog)
		{
			messageDialog.Close();
			ListViewItemScript selectedItem = base.ListView.SelectedItem;
			GameStateInfo gameStateInfo = selectedItem.ItemModel as GameStateInfo;
			Game.Instance.GameStateManager.DeleteGameStateSet(gameStateInfo.GameStateId);
			Items.Remove(selectedItem);
			selectedItem.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(selectedItem.gameObject);
			base.ListView.SelectedItem = null;
		}
	}
}
