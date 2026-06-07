using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Design.UI;
using Assets.Scripts.Flight;
using Assets.Scripts.Net;
using Assets.Scripts.UI.Sharing;
using Jundroo.Common.Platform;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI
{
	public class PlaytestPanelScript : WidgetScript
	{
		private static bool _showIntroDialog = true;

		public static void OpenDiscordUrl()
		{
			WebUtility.OpenUrl("https://www.simplerockets.com/r/SP2Discord", useInGameOverlayIfAvailable: false);
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			if (Device.IsDemoBuild && Game.Instance.SceneManager.InDesigner && !Game.Instance.Settings.App.SeenNotifications.Contains("DemoDesignerInfo"))
			{
				Game.Instance.Settings.App.AddNotification("DemoDesignerInfo");
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog("The full game will let you build planes, cars, and just about anything you can imagine, all from the ground up.\n\nIn this Open Playtest, the designer is locked down, but you can still load and paint crafts to make them your own.");
				messageDialogScript.ExtraWide = true;
				messageDialogScript.Title = "Welcome to the Designer";
			}
			if (Game.Instance.SceneManager.InMenuScene)
			{
				InitializeMainMenu();
			}
		}

		protected void Start()
		{
			if (!Device.IsDemoBuild)
			{
				base.Widget.Visible = false;
			}
		}

		private void InitializeMainMenu()
		{
			if (_showIntroDialog)
			{
				_showIntroDialog = false;
			}
			else
			{
				base.Widget.Visible = false;
			}
		}

		private void OnAddToWishlistButtonClicked(Widget widget)
		{
			Game.Instance.UserInterface.OpenUrl("https://store.steampowered.com/app/2840470/SimplePlanes_2/");
		}

		private void OnClosePlaytestDialogClicked(Widget widget)
		{
			StopAllCoroutines();
			base.Widget.Hide(null, force: true);
		}

		private void OnDiscordButtonClicked(Widget widget)
		{
			OpenDiscordUrl();
		}

		private void OnSubmitBugButtonClicked(Widget widget)
		{
			XElement xElement = null;
			IScreenshotDialogHandler screenshotDialogHandler = null;
			if (FlightSceneScript.Instance != null)
			{
				InFlightDesignerScene designer = FlightSceneScript.Instance.Designer;
				if (designer != null && designer.Active)
				{
					screenshotDialogHandler = FlightSceneScript.Instance.Designer.DesignerScript.DesignerUI;
					xElement = FlightSceneScript.Instance.Designer.DesignerScript.Aircraft.Aircraft.GenerateXml(createRigidBodyGroups: true);
				}
				else
				{
					screenshotDialogHandler = FlightSceneScript.Instance.FlightUI;
					xElement = FlightSceneScript.Instance.LocalPlayer.CurrentOrPreviousAircraft.NetworkAircraft.CraftXml;
				}
			}
			else if (Game.Instance.SceneManager.InDesignerScene)
			{
				xElement = ((DesignerUIScript)(screenshotDialogHandler = Object.FindFirstObjectByType<DesignerUIScript>())).DesignerScript.Aircraft.Aircraft.GenerateXml(createRigidBodyGroups: true);
			}
			else
			{
				xElement = Game.Instance.CraftDatabase.LoadCraftXml("__editor__.xml", showErrorDialogs: false);
				screenshotDialogHandler = null;
			}
			Game.Instance.UserInterface.CreateUploadBugReportDialog(xElement, screenshotDialogHandler);
		}
	}
}
