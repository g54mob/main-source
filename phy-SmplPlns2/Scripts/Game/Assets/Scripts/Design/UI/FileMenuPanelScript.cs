using System;
using System.IO;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.UI.Variables;
using Assets.Scripts.Flight;
using Assets.Scripts.Storage;
using Assets.Scripts.UI;
using Jundroo.Common.Platform;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class FileMenuPanelScript : DesignerPanelScript
	{
		public void OnExitClicked(Widget widget)
		{
			string text = FlightSceneScript.Instance?.FlightUI?.GetExitConfirmationMessage();
			if (text != null)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, text);
				messageDialogScript.Title = "Exit In-Flight Designer";
				messageDialogScript.UseDangerButtonStyle = true;
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					base.DesignerUI.ExitDesigner();
				};
			}
			else
			{
				base.DesignerUI.ExitDesigner();
			}
		}

		private void ExportCurrentDesignAsObj()
		{
			try
			{
				AircraftScript aircraft = Designer.Instance.Aircraft;
				string path = $"{aircraft.Aircraft.Name}_export.obj";
				string text = aircraft.Aircraft.Name + "_model";
				bool isMobileBuild = Game.Instance.Device.IsMobileBuild;
				string text2 = Path.Combine(isMobileBuild ? GameData.PersistentDataPath : System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), text);
				Debug.Log("Exporting to folder: " + text2);
				string fullName = Directory.CreateDirectory(text2).FullName;
				string fullyQualifiedExportLocation = Path.Combine(fullName, path);
				HideScriptsManager hideScriptsManager = HideScriptsManager.HideForScreenshot(aircraft.transform);
				LabelScript[] componentsInChildren = aircraft.transform.GetComponentsInChildren<LabelScript>();
				LabelScript[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].gameObject.SetActive(value: false);
				}
				OBJExporter.ExportObj(fullyQualifiedExportLocation, aircraft.gameObject, generateMaterials: true, exportTextures: true, splitObjects: true, applyScale: true, applyRotation: true, applyPosition: true);
				array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].gameObject.SetActive(value: true);
				}
				hideScriptsManager.Restore();
				if (isMobileBuild)
				{
					base.DesignerUI.ShowMessage("Exported to: '" + fullName + "'", 60f);
				}
				else
				{
					base.DesignerUI.ShowMessage("Design exported to desktop under folder: '" + text + "'", 60f);
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Failed to export design. " + ex.ToString());
			}
		}

		private void OnCraftInstructionsClicked(Widget widget)
		{
			InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.Title = "Craft Instructions";
			inputDialogScript.InputDialogStyle = InputDialogStyle.Large;
			inputDialogScript.SelectTextOnStart = false;
			inputDialogScript.InputPlaceholderText = "Craft instructions can be viewed during flight.";
			inputDialogScript.InputText = base.DesignerUI.DesignerScript.Aircraft.Aircraft.Instructions;
			inputDialogScript.OkayClicked += delegate(InputDialogScript d)
			{
				base.DesignerUI.DesignerScript.Aircraft.Aircraft.Instructions = d.InputText;
				d.Close();
			};
			base.Flyout.Close();
		}

		private void OnCraftPropertiesClicked(Widget widget)
		{
			base.DesignerUI.Flyouts.Selected = base.DesignerUI.Flyouts.CraftProperties;
		}

		private void OnDownloadClicked(Widget widget)
		{
			Game.Instance.UserInterface.OpenDownloadCraftsUrl();
		}

		private void OnEnvironmentClicked(Widget widget)
		{
			base.DesignerUI.Flyouts.Selected = base.DesignerUI.Flyouts.Environment;
		}

		private void OnExportClicked(Widget widget)
		{
			if (Device.IsDemoBuild)
			{
				Game.Instance.UserInterface.CreateMessageDialog("Exporting crafts is not available in the demo version of the game.", "Not Available In Demo");
				return;
			}
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.Title = "Export Aircraft Model";
			messageDialogScript.MessageText = "Export the aircract as an .OBJ file where you can 3D print it yourself or open it up in a 3D modeling program like Blender.";
			messageDialogScript.OkayButtonText = "Export";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				ExportCurrentDesignAsObj();
				d.Close();
			};
		}

		private void OnFlyClicked(Widget widget)
		{
			base.DesignerUI.StartFlight();
		}

		private void OnLoadCraftClicked(Widget widget)
		{
			if (base.Designer.DesignerScript.EnsureTutorialIsNotRunning())
			{
				base.DesignerUI.Flyouts.Selected = base.DesignerUI.Flyouts.LoadCraft;
			}
		}

		private void OnNewClicked(Widget widget)
		{
			if (Device.IsDemoBuild)
			{
				Game.Instance.UserInterface.CreateMessageDialog("Creating new crafts is not available in the demo version of the game.", "Not Available In Demo");
			}
			else if (base.Designer.DesignerScript.EnsureTutorialIsNotRunning())
			{
				base.Flyout.Close();
				MessageDialogScript dialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				dialog.Title = "New Craft";
				dialog.MessageText = "Are you sure you want to create a new craft?";
				dialog.OkayClicked += delegate
				{
					base.DesignerUI.DesignerScript.CreateNewAircraft();
					dialog.Close();
				};
			}
		}

		private void OnSaveClicked(Widget widget)
		{
			base.Designer.DesignerScript.SaveAircraft();
			base.Flyout.Close();
		}

		private void OnSettingsClicked(Widget widget)
		{
			Game.Instance.UserInterface.CreateSettingsDialog();
		}

		private void OnShowDragClicked(Widget widget)
		{
			base.DesignerUI.Flyouts.Selected = base.DesignerUI.Flyouts.DragVisualizer;
		}

		private void OnToggleCenterIndicatorsClicked(Widget widget)
		{
			base.DesignerUI.ToggleCenterOfIndicators();
		}

		private void OnTutorialsClicked(Widget widget)
		{
			base.DesignerUI.Flyouts.Selected = base.DesignerUI.Flyouts.Tutorials;
		}

		private void OnUndoHistoryClicked(Widget widget)
		{
			if (base.DesignerUI.DesignerScript.EnsureTutorialIsNotRunning())
			{
				base.DesignerUI.Flyouts.Selected = base.DesignerUI.Flyouts.UndoHistory;
			}
		}

		private void OnUploadCraftClicked(Widget widget)
		{
			if (base.Designer.DesignerScript.EnsureTutorialIsNotRunning())
			{
				if (Device.IsDemoBuild)
				{
					Game.Instance.UserInterface.CreateMessageDialog("Sharing crafts is not available in the demo version of the game. This is used for uploading your designs the the SimplePlanes.com website where the entire community can download, fly, upvote, and discuss your creations.", "Not Available In Demo");
				}
				else
				{
					Game.Instance.UserInterface.CreateUploadCraftDialog(base.Designer.Aircraft, base.DesignerUI);
				}
			}
		}

		private void OnVariableSettersButtonClicked(Widget widget)
		{
			if (Device.IsDemoBuild)
			{
				Game.Instance.UserInterface.CreateMessageDialog("The variable setters dialog is not available in the demo version of the game.", "Not Available In Demo");
			}
			else if (base.Designer.DesignerScript.EnsureTutorialIsNotRunning())
			{
				Game.Instance.UserInterface.CreateDialog<VariableSettersDialogScript>("Xml/Design/VariableSettersDialog").Initialize(base.Designer.Aircraft.VariableSystem);
			}
		}
	}
}
