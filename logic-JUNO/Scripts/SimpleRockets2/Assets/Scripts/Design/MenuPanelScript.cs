using Assets.Scripts.Menu;
using Assets.Scripts.Menu.ListView.Career;
using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Settings;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using Assets.Scripts.Ui.Sharing.Upload;
using Assets.Scripts.Ui.Sharing.Upload.BugReport;
using Assets.Scripts.Ui.Sharing.Upload.Craft;
using Assets.Scripts.Web;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Ui;
using UI.Xml;

namespace Assets.Scripts.Design
{
	public class MenuPanelScript : DesignerFlyoutPanelScript
	{
		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			foreach (XmlElement item in base.xmlLayout.GetElementsByClass("career-mode"))
			{
				item.SetActive(Game.IsCareer);
			}
			foreach (XmlElement item2 in base.xmlLayout.GetElementsByClass("sandbox-mode"))
			{
				item2.SetActive(!Game.IsCareer);
			}
			bool isFreemiumEnabled = GameMenuScript.IsFreemiumEnabled;
			foreach (XmlElement item3 in base.xmlLayout.GetElementsByClass("freemium-only"))
			{
				item3.SetActive(isFreemiumEnabled);
			}
		}

		private bool EnsureNoTutorial()
		{
			if (base.DesignerUi.Designer.IsTutorialRunning)
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "This button is disabled while the tutorial is in progress.";
				return false;
			}
			return true;
		}

		private void OnBugReportButtonClicked()
		{
			base.DesignerUi.Designer.SaveCraft(CraftDesigns.EditorCraftId);
			UploadBugReportViewModel viewModel = new UploadBugReportViewModel();
			UploadContentDialogScript.Create(base.DesignerUi.Transform, viewModel);
		}

		private void OnCareerButtonClicked()
		{
			if (!EnsureNoTutorial())
			{
				return;
			}
			base.Flyout.Close();
			UserInterface userInterface = Game.Instance.UserInterface as UserInterface;
			CareerDialogScript dialog = userInterface.CreateCareerDialog();
			dialog.Closed += delegate
			{
				if (dialog.RequiresSceneReload)
				{
					base.DesignerUi.Designer.Exit("Design");
				}
			};
		}

		private void OnDownloadCraftButtonClicked()
		{
			if (EnsureNoTutorial())
			{
				base.Flyout.Close();
				WebUtility.OpenUrl(string.Format($"{Game.SimpleRocketsWebsiteUrl}/Crafts/Game?mobile={0}", Device.IsMobileBuild));
			}
		}

		private void OnExitButtonClicked()
		{
			base.DesignerUi.Designer.Exit();
		}

		private void OnLoadCraftButtonClicked()
		{
			if (EnsureNoTutorial())
			{
				base.Flyout.Close();
				base.DesignerUi.ToggleFlyout(base.DesignerUi.Flyouts.LoadCraft);
			}
		}

		private void OnNewCraftButtonClicked()
		{
			if (!EnsureNoTutorial())
			{
				return;
			}
			base.Flyout.Close();
			if (Game.Instance.GameState.Validator.IsCareerMode)
			{
				base.DesignerUi.Designer.CreateNewCraft(CrafConfigurationType.Rocket, delegate(ICraftScript craftScript)
				{
					CraftData data = craftScript.Data;
					if (data.Assembly.Parts.Count == 1)
					{
						PartData partData = data.Assembly.Parts[0];
						data.Assembly.Parts[0].OnDesignerPullout(partData.Name, data.Assembly, skipStartPartScale: false);
					}
				});
				return;
			}
			ModApi.Ui.MessageDialogScript messageDialogScript = base.DesignerUi.Designer.UserInterface.CreateMessageDialog(MessageDialogType.ThreeButtons);
			messageDialogScript.MiddleButtonText = "AIRPLANE";
			messageDialogScript.OkayButtonText = "ROCKET";
			messageDialogScript.MessageText = "Do want to create a rocket or an airplane? This can be changed later by updating the command pod's configuration type.";
			messageDialogScript.MiddleClicked += delegate(ModApi.Ui.MessageDialogScript dialog)
			{
				base.DesignerUi.Designer.CreateNewCraft(CrafConfigurationType.Plane);
				dialog.Close();
			};
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript dialog)
			{
				base.DesignerUi.Designer.CreateNewCraft(CrafConfigurationType.Rocket);
				dialog.Close();
			};
		}

		private void OnPhotoLibraryButtonClicked()
		{
			PhotoLibraryDialogScript.Create(Game.Instance.UserInterface.Transform);
		}

		private void OnPurchaseButtonClicked()
		{
			Game.Instance.InAppPurchases.CreatePurchaseDialog(null);
		}

		private void OnSaveCraftButtonClicked()
		{
			if (EnsureNoTutorial())
			{
				base.Flyout.Close();
				base.DesignerUi.Designer.DialogSave();
			}
		}

		private void OnSettingsButtonClicked()
		{
			SettingsDialogScript.Create();
		}

		private void OnShareCraftButtonClicked()
		{
			if (EnsureNoTutorial())
			{
				UploadCraftViewModel viewModel = new UploadCraftViewModel(base.DesignerUi.Designer.CraftScript, base.DesignerUi.Designer);
				UploadContentDialogScript.Create(base.DesignerUi.Transform, viewModel);
				base.Flyout.Close();
			}
		}

		private void OnTechTreeButtonClicked()
		{
			if (EnsureNoTutorial())
			{
				base.DesignerUi.Designer.Exit("TechTree");
			}
		}
	}
}
