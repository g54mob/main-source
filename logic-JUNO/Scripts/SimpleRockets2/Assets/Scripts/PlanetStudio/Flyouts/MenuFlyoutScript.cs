using System;
using System.Collections.Generic;
using Assets.Scripts.PlanetStudio.UI;
using Assets.Scripts.Ui.Settings;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using Assets.Scripts.Ui.Sharing.Upload;
using Assets.Scripts.Ui.Sharing.Upload.BugReport;
using Assets.Scripts.Ui.Sharing.Upload.CelestialBody;
using Assets.Scripts.Ui.Sharing.Upload.PlanetarySystem;
using ModApi.CelestialData;
using ModApi.Common.Events;
using ModApi.Math;
using ModApi.PlanetStudio;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class MenuFlyoutScript : PlanetStudioFlyoutScript
	{
		private HelpDialogScript _helpDialog;

		private bool HasUnsavedChanges
		{
			get
			{
				if (base.PlanetStudioUI.EditMode == PlanetStudioEditMode.CelestialBody)
				{
					return base.PlanetStudioUI.PlanetStudioScript.CelestialBodyDesignerScript.HasUnsavedChanges;
				}
				return base.PlanetStudioUI.PlanetStudioScript.PlanetarySystemDesignerScript.HasUnsavedChanges;
			}
		}

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
			planetStudioUI.EditModeChanged += OnPlanetStudioEditModeChanged;
		}

		private void ExecuteAfterCheckingForUnsavedChanges(Action action)
		{
			if (HasUnsavedChanges)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.UseDangerButtonStyle = true;
				messageDialogScript.MessageText = "You have unsaved changes that will be lost if you continue.";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					action();
				};
			}
			else
			{
				action();
			}
		}

		private void OnBugReportButtonClicked()
		{
			UploadBugReportViewModel uploadBugReportViewModel = new UploadBugReportViewModel();
			uploadBugReportViewModel.VerifyPlanetarySystemExistsOnServer = false;
			uploadBugReportViewModel.IncludeSandbox = false;
			UploadContentDialogScript.Create(base.PlanetStudioUI.Transform, uploadBugReportViewModel);
		}

		private void OnCreatePlanetButtonClicked()
		{
			Action action = delegate
			{
				base.Flyout.Close();
				PlanetStudioScript planetStudioScript = base.PlanetStudioUI.PlanetStudio as PlanetStudioScript;
				base.PlanetStudioUI.CreateListView(new CelestialBodyListViewModel(planetStudioScript.CelestialBodyDesignerScript, "Create", create: true, useGrid: true));
			};
			ExecuteAfterCheckingForUnsavedChanges(action);
		}

		private void OnCreateSystem()
		{
			if (!LoadSystem(Game.Instance.CelestialDatabase.NewPlanetarySystemPath, Game.Instance.CelestialDatabase.NewPlanetarySystemId))
			{
				return;
			}
			PlanetStudioScript.Instance.PlanetarySystemDesignerScript.StartCoroutine(PlanetStudioScript.Instance.PlanetarySystemDesignerScript.SavePlanetarySystemInteractive(null, updateSystemNameToMatchFile: true, delegate(OperationResult x)
			{
				x.Log();
				if (x.IsSuccess)
				{
					LoadSystem(PlanetStudioScript.Instance.PlanetarySystemDesignerScript.LastSaveFilePath.FullPath, null);
				}
			}));
			static bool LoadSystem(string fullPath, Guid? guid)
			{
				CelestialFile celestialFile = CelestialFile.Create(CelestialFilePath.FromFullPath(fullPath), guid);
				IPlanetarySystemDesigner planetarySystemDesigner = PlanetStudioScript.Instance.PlanetarySystemDesigner;
				OperationResult operationResult = planetarySystemDesigner.LoadPlanetarySystem(celestialFile);
				if (!operationResult.IsSuccess)
				{
					operationResult.Log();
					Game.Instance.UserInterface.CreateErrorDialog($"Unable to load planetary system with ID '{celestialFile.Id}': {operationResult.ErrorMessage}", ErrorDialogOptions.LongError);
					return false;
				}
				if (!string.IsNullOrEmpty(operationResult.WarningMessage))
				{
					operationResult.Log();
					Game.Instance.UserInterface.CreateErrorDialog("The planetary systsem was loaded with warnings: " + operationResult.WarningMessage, ErrorDialogOptions.LongError);
				}
				PlanetStudioScript.Instance.PlanetStudioUI.EditMode = PlanetStudioEditMode.PlanetarySystem;
				operationResult = planetarySystemDesigner.ViewPlanetarySystem(cleanGeneratedData: false, true);
				if (!operationResult.IsSuccess)
				{
					operationResult.Log();
					Game.Instance.UserInterface.CreateErrorDialog($"Unable to view planetary system with ID '{celestialFile.Id}': {operationResult.ErrorMessage}", ErrorDialogOptions.LongError);
					return false;
				}
				return true;
			}
		}

		private void OnCreateSystemButtonClicked()
		{
			Action action = delegate
			{
				base.Flyout.Close();
				OnCreateSystem();
			};
			ExecuteAfterCheckingForUnsavedChanges(action);
		}

		private void OnExitButtonClicked()
		{
			Action action = delegate
			{
				Game.Instance.SceneManager.LoadMenu();
			};
			ExecuteAfterCheckingForUnsavedChanges(action);
		}

		private void OnHelpButtonClicked()
		{
			if (_helpDialog == null)
			{
				_helpDialog = HelpDialogScript.Create(null);
				_helpDialog.Closed += delegate
				{
					_helpDialog = null;
				};
			}
		}

		private void OnLoadPlanetButtonClicked()
		{
			Action action = delegate
			{
				base.Flyout.Close();
				CelestialBodyListViewModel viewModel = new CelestialBodyListViewModel((base.PlanetStudioUI.PlanetStudio as PlanetStudioScript).CelestialBodyDesignerScript, "Load");
				base.PlanetStudioUI.CreateListView(viewModel);
			};
			ExecuteAfterCheckingForUnsavedChanges(action);
		}

		private void OnLoadSystemButtonClicked()
		{
			Action action = delegate
			{
				base.Flyout.Close();
				PlanetStudioScript planetStudioScript = base.PlanetStudioUI.PlanetStudio as PlanetStudioScript;
				Game.Instance.UserInterface.CreateListView(new PlanetarySystemListViewModel(planetStudioScript.PlanetarySystemDesignerScript));
			};
			ExecuteAfterCheckingForUnsavedChanges(action);
		}

		private void OnPhotoLibraryButtonClicked()
		{
			base.Flyout.Close();
			PhotoLibraryDialogScript.Create(base.PlanetStudioUI.Transform);
		}

		private void OnPlanetStudioEditModeChanged(object sender, EventArgs e)
		{
			List<XmlElement> elementsByClass = base.xmlLayout.GetElementsByClass("ps-only");
			foreach (XmlElement item in base.xmlLayout.GetElementsByClass("cb-only"))
			{
				item.SetActive(base.PlanetStudioUI.EditMode == PlanetStudioEditMode.CelestialBody);
			}
			foreach (XmlElement item2 in elementsByClass)
			{
				item2.SetActive(base.PlanetStudioUI.EditMode == PlanetStudioEditMode.PlanetarySystem);
			}
		}

		private void OnSavePlanetButtonClicked()
		{
			StartCoroutine(PlanetStudioScript.Instance.CelestialBodyDesignerScript.SaveCelestialBodyInteractive(null, delegate(OperationResult x)
			{
				x.Log();
			}));
		}

		private void OnSaveSystemButtonClicked()
		{
			StartCoroutine(PlanetStudioScript.Instance.PlanetarySystemDesignerScript.SavePlanetarySystemInteractive(null, updateSystemNameToMatchFile: false, delegate(OperationResult x)
			{
				x.Log();
			}));
		}

		private void OnSettingsButtonClicked()
		{
			base.Flyout.Close();
			SettingsDialogScript.Create();
		}

		private void OnShareButtonClicked()
		{
			base.Flyout.Close();
			if (base.PlanetStudioUI.EditMode == PlanetStudioEditMode.CelestialBody)
			{
				UploadContentDialogScript.Create(null, new UploadCelestialBodyViewModel());
			}
			else
			{
				if (base.PlanetStudioUI.EditMode != PlanetStudioEditMode.PlanetarySystem)
				{
					return;
				}
				float maxValidationTime = PlanetarySystemDesignerScript.Instance.GetMaxValidationTime();
				MessageDialogScript timeWarningDialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.NoButtons, null, fadeIn: false);
				timeWarningDialog.MessageText = "Validating planetary system. Depending on the configuration, and how many planets there are this can take a while.  Planets which have a high probability of having an encounter, will take longer to validate.  It should take a maximum of " + Units.GetRelativeTimeString(maxValidationTime);
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate(int? x)
				{
					if (x == 0)
					{
						bool num = PlanetarySystemDesignerScript.Instance.ValidatePlanetOrbits();
						timeWarningDialog.Close();
						if (!num)
						{
							OperationResult operationResult = OperationResult.Failure("There is a problem with one or more orbits.  Check the following items.\n\nPlanets cannot...\n* Leave their parent's SOI.\n* Be a duplicate of another planet.\n* Have encounters w/other planets.\n* Have their SOI intersect their parent's surface\n\nPlease check the orbits colored red and address the issue(s).");
							Game.Instance.UserInterface.CreateErrorDialog(operationResult.ErrorMessage);
						}
						else
						{
							UploadContentDialogScript.Create(null, new UploadPlanetarySystemViewModel());
						}
					}
				}, 2);
			}
		}
	}
}
