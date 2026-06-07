using System;
using System.Collections;
using System.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Menu;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.Mods;
using ModApi.CelestialData;
using ModApi.Common.Extensions;
using ModApi.Mods;
using ModApi.Planet;
using ModApi.PlanetStudio;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.UI
{
	public class CelestialBodyListViewModel : ListViewModel
	{
		private CelestialBodyDesignerScript _celestialBodyDesigner;

		private ContextMenuItemScript _cloneMenuItem;

		private bool _create;

		private CelestialBodyListViewModelDetails _details;

		private bool _loadCelestialBodyDesigner;

		private PlanetDataScript _planetData;

		private string _primaryButtonText;

		public CelestialFile SelectedFile => (CelestialFile)(base.ListView.SelectedItem?.ItemModel);

		public event ListViewDelegate ItemSelected;

		public CelestialBodyListViewModel(CelestialBodyDesignerScript celestialBodyDesigner, string primaryButtonText, bool create = false, bool useGrid = false)
		{
			_celestialBodyDesigner = celestialBodyDesigner;
			_loadCelestialBodyDesigner = _celestialBodyDesigner != null;
			_primaryButtonText = primaryButtonText;
			_create = create;
			base.UseGrid = useGrid;
		}

		public override IEnumerator LoadItems()
		{
			CelestialDatabase db = Game.Instance.CelestialDatabase;
			foreach (var item in (from x in db.GetAllFiles(includingDuplicates: true, CelestialFileType.CelestialBody)
				where !x.Path.FileName.StartsWith("__")
				select new
				{
					File = x,
					Info = db.GetCelestialBody(x.Id)
				} into x
				where x.Info != null
				where x.Info.IsTemplate == _create
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
				if (_create)
				{
					subtitle = item.Info.Description;
				}
				ListViewItemScript listViewItemScript = base.ListView.CreateItem(item.Info.Name, subtitle, item.File, null, ListViewScript.SpriteLoadLocation.Resources);
				if (_create)
				{
					listViewItemScript.SpriteResourcePath = "Ui/Sprites/PlanetStudio/PlanetTemplates/" + item.Info.Name;
				}
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
			yield return new WaitForEndOfFrame();
		}

		public override void OnClosed()
		{
			base.OnClosed();
			DestroyPlanetData();
		}

		public override void OnDeleteButtonClicked(ListViewItemScript selectedItem)
		{
			CelestialFile file = (CelestialFile)selectedItem.ItemModel;
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.OkayButtonText = "DELETE";
			messageDialogScript.MessageText = "Confirm that you want to delete the celestial body '" + file.Path.RelativePath + "'";
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

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			_details = new CelestialBodyListViewModelDetails(listView.ListViewDetails, _create);
			listView.CanDelete = true;
			listView.PrimaryButtonText = _primaryButtonText;
			listView.DisplayType = ListViewScript.ListViewDisplayType.ObjectPreview;
			if (_create)
			{
				listView.Title = "Create Planet";
				return;
			}
			listView.Title = "Celestial Bodies";
			listView.CreateFilter(true, "Stock", "The search filter for stock celestial bodies", ListViewFilterType.Include, false, "Stock");
			listView.CreateFilter(true, "Community", "The search filter for celestial bodies created by the community", ListViewFilterType.Include, false, "Community");
			listView.CreateFilter(true, "Planet Studio", "The search filter for celestial bodies created in planet studio", ListViewFilterType.Include, false, "PlanetStudio");
			listView.CreateFilter(false, "Previous Versions", "The search filter that hides celestial bodies which for which there are newer versions installed.", ListViewFilterType.Exclude, true, "PreviousVersion");
			if (_celestialBodyDesigner != null)
			{
				_cloneMenuItem = listView.CreateContextMenuItem("Clone", OnCloneSelected);
				_cloneMenuItem.Visible = SelectedFile != null;
			}
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			CelestialFile file = (CelestialFile)selectedItem.ItemModel;
			CelestialBodyFileData celestialBody = Game.Instance.CelestialDatabase.GetCelestialBody(file.Id);
			Action<string> loadPlanet = delegate(string createName)
			{
				PlanetStudioScript.LoadAndViewCelestialBody(file, createName);
				_celestialBodyDesigner.HasUnsavedChanges = false;
			};
			Action completeDialog = delegate
			{
				if (_loadCelestialBodyDesigner)
				{
					if (_create)
					{
						InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
						inputDialogScript.MessageText = "Provide a name for the new planet.";
						inputDialogScript.OkayClicked += delegate(InputDialogScript d)
						{
							if (!string.IsNullOrWhiteSpace(d.InputText))
							{
								loadPlanet(d.InputText);
								d.Close();
								Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.PlanetStudioCreateNewCelestialBody);
							}
						};
					}
					else
					{
						loadPlanet(null);
					}
				}
				base.ListView.Close();
			};
			RequiredModsCheck requiredModsCheck = new RequiredModsCheck(celestialBody.RequiredMods);
			if (requiredModsCheck.AllRequirementsMet)
			{
				completeDialog();
			}
			else
			{
				RequiredModsDialogScript.Create(requiredModsCheck).OkayClicked += delegate
				{
					completeDialog();
				};
			}
			this.ItemSelected?.Invoke(this);
		}

		public override void OnSelectedItemChanged(ListViewItemScript item)
		{
			if (_cloneMenuItem != null)
			{
				_cloneMenuItem.Visible = SelectedFile != null;
			}
			base.ListView.CanDelete = SelectedFile != null && !Game.Instance.CelestialDatabase.StockFileIds.Contains(SelectedFile.Id);
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			_details.UpdateDetails((CelestialFile)item.ItemModel);
			completeCallback?.Invoke();
		}

		public override void UpdatePreview(ListViewItemScript item, IListViewObjectViewer objectViewer, Action completeCallback)
		{
			if (SelectedFile != null)
			{
				GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("PlanetStudio/Prefabs/PreviewPlanet");
				MenuPlanetScript component = gameObject.GetComponent<MenuPlanetScript>();
				component.RotationSpeed = 0f;
				DestroyPlanetData();
				_planetData = PlanetDataScript.CreateFromFile(SelectedFile, null, null, null, createTerrainData: true, applyScaleAndOverrides: false);
				component.Eclipse = 0f;
				gameObject.gameObject.SetActive(value: true);
				ObjectViewerScript objectViewerScript = objectViewer as ObjectViewerScript;
				component.Initialize(objectViewerScript.Light, objectViewerScript.Camera);
				component.SetPlanetData(_planetData);
				objectViewerScript.PreviewObject(gameObject);
			}
			else
			{
				objectViewer.PreviewObject(null);
			}
			completeCallback?.Invoke();
		}

		protected override bool MatchesSearchCriteria(ListViewItemScript item, string searchTextLower)
		{
			string subtitle = item.Subtitle;
			string text = ((subtitle != null && subtitle.StartsWith("Filename: ", StringComparison.Ordinal)) ? item.Subtitle.Replace("Filename: ").ToLower() : string.Empty);
			if (!base.MatchesSearchCriteria(item, searchTextLower))
			{
				return text.Contains(searchTextLower);
			}
			return true;
		}

		private void DestroyPlanetData()
		{
			if (_planetData != null)
			{
				UnityEngine.Object.Destroy(_planetData.gameObject);
				_planetData = null;
			}
		}

		private void OnCloneSelected(ContextMenuItemScript obj)
		{
			IUserInterface ui = Game.Instance.UserInterface;
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			CelestialFile file = SelectedFile;
			if (file == null)
			{
				ui.CreateErrorDialog("No celestial body selected.");
				return;
			}
			CelestialBodyFileData celestialBody = celestialDatabase.GetCelestialBody(file.Id);
			if (celestialBody == null)
			{
				ui.CreateErrorDialog("Celestial body info could not be found for the selected item.");
				return;
			}
			InputDialogScript inputDialogScript = ui.CreateInputDialog();
			inputDialogScript.MessageText = "Celestial body Name";
			inputDialogScript.InputText = celestialBody.Name;
			inputDialogScript.OkayClicked += delegate(InputDialogScript d)
			{
				d.Close();
				string celestialBodyName = d.InputText;
				InputDialogScript inputDialogScript2 = ui.CreateInputDialog();
				inputDialogScript2.MessageText = "File Name";
				inputDialogScript2.InputText = celestialBodyName;
				inputDialogScript2.OkayClicked += delegate(InputDialogScript inputDialogScript3)
				{
					inputDialogScript3.Close();
					base.ListView.Close();
					string inputText = inputDialogScript3.InputText;
					OperationResult operationResult = _celestialBodyDesigner.CloneCelestialBody(file, celestialBodyName, inputText, useFilePaths: true);
					operationResult.Log();
					if (operationResult.IsSuccess)
					{
						ui.CreateMessageDialog("New celestial body created.");
					}
					else
					{
						ui.CreateErrorDialog(operationResult.ErrorMessage);
					}
				};
			};
		}

		private void RefreshItem(ListViewItemScript item)
		{
			item.StatusIcon = ListViewItemScript.StatusIconType.None;
			item.StatusIconColor = "White";
			item.StatusIconTooltip = string.Empty;
		}
	}
}
