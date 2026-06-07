using System;
using System.Collections;
using System.Linq;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.Mods;
using Assets.Scripts.State;
using ModApi.CelestialData;
using ModApi.Common.Extensions;
using ModApi.Mods;
using ModApi.PlanetStudio;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.UI
{
	public class PlanetarySystemListViewModel : ListViewModel
	{
		private ContextMenuItemScript _cloneMenuItem;

		private XmlElement _contextMenuSeparator;

		private PlanetarySystemListViewModelDetails _details;

		private PlanetarySystemDesignerScript _planetarySystemDesignerScript;

		private CelestialFile _selectedOnLoad;

		private ContextMenuItemScript _setAsCurrentSystemMenuItem;

		public CelestialFile SelectedFile => (CelestialFile)(base.ListView.SelectedItem?.ItemModel);

		public PlanetarySystemListViewModel(PlanetarySystemDesignerScript planetarySystemDesignerScript)
		{
			_planetarySystemDesignerScript = planetarySystemDesignerScript;
		}

		public PlanetarySystemListViewModel()
		{
		}

		public PlanetarySystemListViewModel(CelestialFile selectedFile)
		{
			_selectedOnLoad = selectedFile;
		}

		public override IEnumerator LoadItems()
		{
			CelestialDatabase db = Game.Instance.CelestialDatabase;
			foreach (var item in (from x in db.GetAllFiles(includingDuplicates: true, CelestialFileType.PlanetarySystem)
				where !x.Path.FileName.StartsWith("__")
				select new
				{
					File = x,
					Info = db.GetPlanetarySystem(x.Id)
				} into x
				where x.Info != null
				select new
				{
					x.File,
					x.Info,
					x.File.Path.FileName,
					x.File.Path.InUserData,
					x.Info.Author,
					x.Info.Version
				} into x
				orderby x.Info.Name, x.InUserData, (!x.InUserData) ? x.Author : x.FileName, x.Version
				select x).ToList())
			{
				string subtitle = (item.File.Path.InGameData ? ("Author: " + item.Info.Author + " - Version: " + item.Info.Version) : ("Filename: " + item.FileName));
				ListViewItemScript listViewItemScript = base.ListView.CreateItem(item.Info.Name, subtitle, item.File, null, ListViewScript.SpriteLoadLocation.Resources);
				if (item.File.Path.InGameData)
				{
					listViewItemScript.FilterKeywords.Add((item.Info.Author == "Jundroo") ? "Stock" : "Community");
				}
				else
				{
					listViewItemScript.FilterKeywords.Add("PlanetStudio");
				}
				if (!item.Info.IsLatestVersion)
				{
					listViewItemScript.FilterKeywords.Add("PreviousVersion");
				}
				RefreshItem(listViewItemScript);
			}
			OnFiltersChanged(string.Empty, base.ListView.Filters);
			yield return new WaitForEndOfFrame();
		}

		public override void OnCanceled()
		{
			base.OnCanceled();
			base.ListView.SelectedItem = null;
		}

		public override void OnDeleteButtonClicked(ListViewItemScript selectedItem)
		{
			CelestialFile file = (CelestialFile)selectedItem.ItemModel;
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.OkayButtonText = "DELETE";
			messageDialogScript.MessageText = "Confirm that you want to delete the planetary system '" + file.Path.RelativePath + "'";
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				Game.Instance.CelestialDatabase.DeleteFile(file, refreshDatabase: true);
				base.ListView.DeleteItem(selectedItem);
				Items.Remove(selectedItem);
				base.ListView.SelectedItem = null;
			};
		}

		public override void OnItemsLoaded()
		{
			base.OnItemsLoaded();
			base.ListView.SelectedItem = Items.FirstOrDefault((ListViewItemScript x) => x.gameObject.activeSelf && (CelestialFile)x.ItemModel == _selectedOnLoad);
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			_details = new PlanetarySystemListViewModelDetails(listView.ListViewDetails);
			bool inPlanetStudioScene = Game.InPlanetStudioScene;
			listView.Title = "Planetary Systems";
			listView.CanDelete = true;
			listView.PrimaryButtonText = (inPlanetStudioScene ? "Load" : "Select");
			listView.DisplayType = ListViewScript.ListViewDisplayType.LargeDialog;
			listView.CreateFilter(true, "Stock", "The search filter for stock planetary systems", ListViewFilterType.Include, false, "Stock");
			listView.CreateFilter(true, "Community", "The search filter for planetary systems created by the community", ListViewFilterType.Include, false, "Community");
			listView.CreateFilter(true, "Planet Studio", "The search filter for planetary systems created in planet studio", ListViewFilterType.Include, false, "PlanetStudio");
			listView.CreateFilter(false, "Previous Versions", "The search filter that hides planetary systems which for which there are newer versions installed.", ListViewFilterType.Exclude, true, "PreviousVersion");
			if (inPlanetStudioScene)
			{
				_contextMenuSeparator = listView.CreateContextMenuSeparator();
				_contextMenuSeparator.SetActive(SelectedFile != null);
				_setAsCurrentSystemMenuItem = listView.CreateContextMenuItem("Set As Current System", OnSetAsCurrentSystemSelected);
				_setAsCurrentSystemMenuItem.Visible = SelectedFile != null;
				_cloneMenuItem = listView.CreateContextMenuItem("Clone", OnCloneSelected);
				_cloneMenuItem.Visible = SelectedFile != null;
			}
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			CelestialFile file = (CelestialFile)selectedItem.ItemModel;
			PlanetarySystemFileData planetarySystem = Game.Instance.CelestialDatabase.GetPlanetarySystem(file.Id);
			Action completeDialog = delegate
			{
				if (Game.InPlanetStudioScene)
				{
					IPlanetarySystemDesigner planetarySystemDesigner = PlanetStudioScript.Instance.PlanetarySystemDesigner;
					OperationResult operationResult = planetarySystemDesigner.LoadPlanetarySystem(file);
					if (!operationResult.IsSuccess)
					{
						operationResult.Log();
						Game.Instance.UserInterface.CreateErrorDialog($"Unable to load planetary system with ID '{file.Id}': {operationResult.ErrorMessage}", ErrorDialogOptions.LongError);
					}
					else
					{
						if (!string.IsNullOrEmpty(operationResult.WarningMessage))
						{
							operationResult.Log();
							Game.Instance.UserInterface.CreateErrorDialog("The planetary system was loaded with warnings: " + operationResult.WarningMessage, ErrorDialogOptions.LongError);
						}
						PlanetStudioScript.Instance.PlanetStudioUI.EditMode = PlanetStudioEditMode.PlanetarySystem;
						operationResult = planetarySystemDesigner.ViewPlanetarySystem(cleanGeneratedData: false, true);
						if (!operationResult.IsSuccess)
						{
							operationResult.Log();
							Game.Instance.UserInterface.CreateErrorDialog($"Unable to view planetary system with ID '{file.Id}': {operationResult.ErrorMessage}", ErrorDialogOptions.LongError);
						}
						else
						{
							base.ListView.Close();
						}
					}
				}
				else if (file.Path.InUserData)
				{
					MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
					messageDialogScript.MessageText = "The selected planetary system appears to have been saved from Planet Studio. Any further changes to this system or its celestial bodies could result in an immediate impact to saved games using this system. This could break existing craft in flight and possibly other things. Proceed with caution.";
					messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
					{
						d.Close();
						base.ListView.Close();
					};
				}
				else
				{
					base.ListView.Close();
				}
			};
			RequiredModsCheck requiredModsCheck = new RequiredModsCheck(planetarySystem.RequiredMods);
			if (requiredModsCheck.AllRequirementsMet)
			{
				completeDialog();
				return;
			}
			RequiredModsDialogScript.Create(requiredModsCheck).OkayClicked += delegate
			{
				completeDialog();
			};
		}

		public override void OnSelectedItemChanged(ListViewItemScript item)
		{
			if (Game.InPlanetStudioScene)
			{
				_setAsCurrentSystemMenuItem.Visible = SelectedFile != null;
				_cloneMenuItem.Visible = SelectedFile != null;
				_contextMenuSeparator.SetActive(_setAsCurrentSystemMenuItem.Visible || _cloneMenuItem.Visible);
			}
			base.ListView.CanDelete = SelectedFile != null && !Game.Instance.CelestialDatabase.StockFileIds.Contains(SelectedFile.Id);
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			_details.UpdateDetails((CelestialFile)item.ItemModel);
			completeCallback?.Invoke();
		}

		protected override bool MatchesSearchCriteria(ListViewItemScript item, string searchTextLower)
		{
			string text = (item.Subtitle.StartsWith("Filename: ", StringComparison.Ordinal) ? item.Subtitle.Replace("Filename: ").ToLower() : string.Empty);
			if (!base.MatchesSearchCriteria(item, searchTextLower))
			{
				return text.Contains(searchTextLower);
			}
			return true;
		}

		private void OnCloneSelected(ContextMenuItemScript obj)
		{
			IUserInterface ui = Game.Instance.UserInterface;
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			CelestialFile file = SelectedFile;
			if (file == null)
			{
				ui.CreateErrorDialog("No planetary system selected.");
				return;
			}
			PlanetarySystemFileData planetarySystem = celestialDatabase.GetPlanetarySystem(file.Id);
			if (planetarySystem == null)
			{
				ui.CreateErrorDialog("Planetary system info could not be found for the selected item.");
				return;
			}
			InputDialogScript inputDialogScript = ui.CreateInputDialog();
			inputDialogScript.MessageText = "Planetary System Name";
			inputDialogScript.InputText = planetarySystem.Name;
			inputDialogScript.OkayClicked += delegate(InputDialogScript d)
			{
				d.Close();
				string planetarySystemName = d.InputText;
				InputDialogScript inputDialogScript2 = ui.CreateInputDialog();
				inputDialogScript2.MessageText = "File Name";
				inputDialogScript2.InputText = planetarySystemName;
				inputDialogScript2.OkayClicked += delegate(InputDialogScript inputDialogScript3)
				{
					inputDialogScript3.Close();
					base.ListView.Close();
					string inputText = inputDialogScript3.InputText;
					OperationResult operationResult = _planetarySystemDesignerScript.ClonePlanetarySystem(file, planetarySystemName, inputText, useFilePaths: true);
					operationResult.Log();
					if (operationResult.IsSuccess)
					{
						ui.CreateMessageDialog("New planetary system created.");
					}
					else
					{
						ui.CreateErrorDialog(operationResult.ErrorMessage);
					}
				};
			};
		}

		private void OnSetAsCurrentSystemSelected(ContextMenuItemScript contextMenuItem)
		{
			CelestialFile selectedFile = SelectedFile;
			if (selectedFile == null)
			{
				Game.Instance.UserInterface.CreateErrorDialog("No planetary system selected.");
				return;
			}
			GameState gameState = Game.Instance.GameState;
			if (gameState == null)
			{
				Game.Instance.UserInterface.CreateErrorDialog("Unable to set as the current planetary system. The game state is null.");
				return;
			}
			FlightStateData flightStateData = gameState.LoadFlightStateData();
			flightStateData.ChangePlanetarySystem(selectedFile, useFilePath: true);
			flightStateData.Save();
			Game.Instance.UserInterface.CreateMessageDialog("The flight state for your current save game has been updated to use the selected planetary system.");
		}

		private void RefreshItem(ListViewItemScript item)
		{
			item.StatusIcon = ListViewItemScript.StatusIconType.None;
			item.StatusIconColor = "White";
			item.StatusIconTooltip = string.Empty;
		}
	}
}
