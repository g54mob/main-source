using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.State.Validation;
using ModApi.Craft;
using ModApi.Levels;
using ModApi.Scenes.Parameters;
using ModApi.Scripts.State.Validation;
using ModApi.Services.Purchasing;
using ModApi.State;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class PlayViewModel : ListViewModel
	{
		public class PlayItemViewModel
		{
			public Action ClickAction { get; set; }

			public string Description { get; set; }

			public string Id { get; internal set; }

			public bool IsCompleted { get; internal set; }

			public bool LaunchCraft { get; internal set; }

			public ILevelData Level { get; set; }

			public string Name { get; set; }

			public string PrimaryButtonText { get; set; }

			public string Sprite { get; internal set; }

			public string Subtitle { get; set; }
		}

		private PlayDetails _details;

		private MenuScript _menu;

		private PlayViewModelType _type;

		public PlayViewModel(ICraftScript launchCraft, MenuScript menu, PlayViewModelType type)
		{
			_menu = menu;
			_type = type;
		}

		public static bool CheckSandboxActiveCrafts()
		{
			bool result = true;
			IInAppPurchaseFeature feature = Game.Instance.InAppPurchases.Features.UnlimitedCraftInFlight;
			if (!feature.Unlocked && Game.Instance.GameState.Mode == GameStateMode.Sandbox && CareerValidator.GetNumberOfActiveCrafts(Game.Instance.GameState, 2) >= 2)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.ThreeButtons);
				messageDialogScript.MessageText = "You must upgrade to the " + feature.ProductName + " to launch another craft.\n\nOtherwise, you can remove some of the crafts currently active in your sandbox.";
				messageDialogScript.OkayButtonText = "UPGRADE";
				messageDialogScript.MiddleButtonText = "REMOVE CRAFT";
				messageDialogScript.ExtraWide = true;
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					Game.Instance.InAppPurchases.CreatePurchaseDialog(feature.ProductId);
				};
				messageDialogScript.MiddleClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					Game.Instance.SceneManager.LoadMenu(new MenuSceneLoadParameters
					{
						OpenResumeCraftsListView = true
					});
				};
				result = false;
			}
			return result;
		}

		public static void LaunchNewCraft(ICraftScript craftScript, string flightName)
		{
			ValidationResult result = Game.Instance.GameState.Validator.ValidateCraft(craftScript, Game.Instance.GameState.SelectedLaunchLocation);
			Action launchAction = delegate
			{
				string text = flightName;
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (!Game.Instance.CraftDesigns.HasCraft(Game.Instance.GameState.SelectedCraftDesignId))
					{
						Game.Instance.GameState.SelectedCraftDesignId = CraftDesigns.NewCraftId;
					}
					Game.Instance.GameState.Save();
					Game.Instance.BeginFlight(Game.Instance.GameState.SelectedCraftDesignId, text, "Menu", result.LaunchCost);
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Please, provide a flight name for this craft.";
				}
			};
			if (result.ErrorCount == 0)
			{
				if (result.WarningCount > 0)
				{
					MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
					messageDialogScript.ExtraWide = true;
					messageDialogScript.MessageText = "<b>One or more potential issues have been found. Would you like to continue with the launch? Attempt to launch this craft from the designer to view the complete list of issues</b>.\n\n" + result.GetShortErrorMessage();
					messageDialogScript.OkayButtonText = "Launch Anyway";
					messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
					{
						launchAction();
						d.Close();
					};
				}
				else if (CheckSandboxActiveCrafts())
				{
					launchAction();
				}
			}
			else
			{
				MessageDialogScript messageDialogScript2 = Game.Instance.UserInterface.CreateMessageDialog();
				messageDialogScript2.ExtraWide = true;
				messageDialogScript2.MessageText = "<b>This craft has one or more issues and cannot be launched at this time. Attempt to launch this craft from the designer to view the complete list of issues.</b>\n\n" + result.GetShortErrorMessage();
			}
		}

		public override IEnumerator LoadItems()
		{
			_details = new PlayDetails(base.ListView.ListViewDetails, _menu.Craft);
			_details.FlightName = _menu.Craft.Data.Name;
			List<PlayItemViewModel> list = new List<PlayItemViewModel>();
			string text = null;
			if (_type == PlayViewModelType.Default)
			{
				PlayItemViewModel playItemViewModel = new PlayItemViewModel
				{
					Id = "PlayLaunchCraft",
					Name = "Launch Craft",
					Subtitle = null,
					PrimaryButtonText = "LAUNCH",
					Sprite = "SandboxLaunch",
					LaunchCraft = true,
					Level = null,
					Description = $"Ready to launch? Give this craft a flight name and click LAUNCH!",
					ClickAction = delegate
					{
						base.ListView.Close();
						LaunchLocationsViewModel launchLocationsViewModel = new LaunchLocationsViewModel(_menu.Craft)
						{
							PrimaryButtonText = "LAUNCH"
						};
						string flightName = _details.FlightName;
						launchLocationsViewModel.LaunchLocationSelected = delegate
						{
							LaunchNewCraft(_menu.Craft, flightName);
						};
						_menu.ShowListView(launchLocationsViewModel);
					}
				};
				list.Add(playItemViewModel);
				PlayItemViewModel item = new PlayItemViewModel
				{
					Id = "PlayBuildCraft",
					Name = "Build Craft",
					Subtitle = null,
					PrimaryButtonText = "BUILD",
					Sprite = "SandboxBuild",
					Level = null,
					Description = $"Build a craft by snapping parts together. You can build rockets, rovers, airplanes, or anything you want.",
					ClickAction = delegate
					{
						OnBuildClicked();
					}
				};
				list.Add(item);
				PlayItemViewModel item2 = new PlayItemViewModel
				{
					Id = "PlayTutorials",
					Name = "Tutorials",
					Subtitle = null,
					PrimaryButtonText = "View Tutorials",
					Sprite = "LevelFlightTutorial",
					Level = null,
					Description = "View the list of tutorials available to play.",
					ClickAction = delegate
					{
						OnTutorialsClicked();
					}
				};
				list.Add(item2);
				PlayItemViewModel item3 = new PlayItemViewModel
				{
					Id = "PlayChallenges",
					Name = "Challenges",
					Subtitle = null,
					PrimaryButtonText = "View Challenges",
					Sprite = "ShuttleLanding",
					Level = null,
					Description = "View the list of challenges and practice missions available to play.",
					ClickAction = delegate
					{
						OnChallengesClicked();
					}
				};
				list.Add(item3);
				text = playItemViewModel.Id;
			}
			else
			{
				bool isTutorial = _type == PlayViewModelType.Tutorials;
				foreach (ILevelData item4 in Game.Instance.LevelManager.Levels.Where((ILevelData x) => isTutorial == (x.Category == "Tutorial")))
				{
					PlayItemViewModel playItemViewModel2 = new PlayItemViewModel
					{
						Id = item4.Id,
						Name = item4.DisplayName,
						Subtitle = ((isTutorial && !string.IsNullOrEmpty(item4.ContractId)) ? "Career Contract Tutorial" : item4.Category),
						Description = item4.Description,
						PrimaryButtonText = (isTutorial ? "START TUTORIAL" : "START LEVEL"),
						Level = item4,
						IsCompleted = (item4.ScoreData.Scores.Count > 0)
					};
					if (!string.IsNullOrEmpty(item4.Icon))
					{
						playItemViewModel2.Sprite = item4.Icon;
					}
					else
					{
						playItemViewModel2.Sprite = item4.Id;
					}
					if (string.IsNullOrWhiteSpace(playItemViewModel2.Sprite))
					{
						playItemViewModel2.Sprite = "LevelDefault";
					}
					list.Add(playItemViewModel2);
				}
			}
			ListViewItemScript launchCraftListItem = null;
			foreach (PlayItemViewModel item5 in list)
			{
				ListViewItemScript listViewItemScript = base.ListView.CreateItem(item5.Name, item5.Subtitle, item5, "Ui/Sprites/Menu/LevelIcons/" + item5.Sprite, ListViewScript.SpriteLoadLocation.Resources);
				if (item5.IsCompleted)
				{
					listViewItemScript.StatusIcon = ListViewItemScript.StatusIconType.Checkmark;
					listViewItemScript.StatusIconTooltip = "Completed";
					listViewItemScript.StatusIconColor = "White";
				}
				if (item5.Id == text)
				{
					launchCraftListItem = listViewItemScript;
				}
			}
			yield return new WaitForEndOfFrame();
			base.ListView.SelectedItem = launchCraftListItem;
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			switch (_type)
			{
			case PlayViewModelType.Tutorials:
				listView.Title = "Tutorials";
				break;
			case PlayViewModelType.Challenges:
				listView.Title = "Challenges";
				break;
			default:
				listView.Title = "Play";
				break;
			}
			listView.CanDelete = false;
			listView.PrimaryButtonText = "SELECT";
			listView.DisplayType = ListViewScript.ListViewDisplayType.SmallDialog;
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			if (selectedItem != null)
			{
				PlayItemViewModel playItemViewModel = selectedItem.ItemModel as PlayItemViewModel;
				if (playItemViewModel.Level != null)
				{
					Game.Instance.LevelManager.StartLevel(playItemViewModel.Level);
					return;
				}
				Game.Instance.Settings.AddNotification(playItemViewModel.Id);
				Game.Instance.Settings.Save();
				playItemViewModel.ClickAction();
			}
		}

		public override void OnSelectedItemChanged(ListViewItemScript item)
		{
			base.OnSelectedItemChanged(item);
			if (item != null)
			{
				PlayItemViewModel playItemViewModel = item.ItemModel as PlayItemViewModel;
				base.ListView.PrimaryButtonText = playItemViewModel.PrimaryButtonText;
			}
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				PlayItemViewModel item2 = item.ItemModel as PlayItemViewModel;
				_details.UpdateDetails(item2);
			}
			completeCallback?.Invoke();
		}

		private void OnBuildClicked()
		{
			Game.Instance.BeginDesign(saveGameState: true);
		}

		private void OnChallengesClicked()
		{
			base.ListView.Close();
			PlayViewModel viewModel = new PlayViewModel(_menu.Craft, _menu, PlayViewModelType.Challenges);
			_menu.ShowListView(viewModel);
		}

		private void OnTutorialsClicked()
		{
			base.ListView.Close();
			PlayViewModel viewModel = new PlayViewModel(_menu.Craft, _menu, PlayViewModelType.Tutorials);
			_menu.ShowListView(viewModel);
		}
	}
}
