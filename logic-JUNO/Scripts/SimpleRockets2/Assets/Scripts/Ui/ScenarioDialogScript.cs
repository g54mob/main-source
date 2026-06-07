using System.IO;
using Assets.Scripts.Flight;
using ModApi.Flight;
using ModApi.Scenes.Parameters;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui
{
	public class ScenarioDialogScript : DialogScript
	{
		private XmlElement _panel;

		private XmlElement _templateRow;

		public static ScenarioDialogScript Create(Transform parent)
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/ScenarioDialog", parent, delegate(ScenarioDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
		}

		public override void Close()
		{
			base.Close();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				Object.Destroy(base.gameObject);
			});
		}

		protected override void Start()
		{
			base.Start();
			_panel.Show();
			string[] directories = Directory.GetDirectories(Path.Combine(Game.Instance.GameStateManager.GetGameStateTagPath(Game.Instance.GameState.Id), ".."));
			for (int i = 0; i < directories.Length; i++)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(directories[i]);
				if (directoryInfo.Name.StartsWith("Scenario."))
				{
					string text = directoryInfo.Name.Replace("Scenario.", string.Empty);
					XmlElement xmlElement = UiUtilities.CloneTemplate(_templateRow, _templateRow.parentElement);
					xmlElement.SetAttribute("scenario", directoryInfo.Name);
					xmlElement.GetElementByInternalId<TextMeshProUGUI>("name").text = text;
				}
			}
		}

		private void OnCancelClicked()
		{
			Close();
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_templateRow = xmlLayout.GetElementById("template-row");
			_templateRow.SetActive(active: false);
			_panel.SetAttribute("active", "false");
		}

		private void OnScenarioClicked(XmlElement element)
		{
			string attribute = element.GetAttribute("scenario");
			Game.Instance.GameStateManager.RestoreGameStateTag(Game.Instance.GameState.Id, attribute);
			Game.Instance.GameStateManager.CopyGameStateTag(Game.Instance.GameState.Id, "Active", "PreFlight");
			FlightSceneLoadParameters flightSceneLoadParameters = FlightSceneLoadParameters.ResumeCraft();
			if (Game.InFlightScene)
			{
				FlightSceneScript.Instance.ReloadFlightScene(saveFlightState: false, flightSceneLoadParameters, FlightSceneExitReason.LoadScenario);
			}
			else
			{
				Game.Instance.SceneManager.LoadFlight(flightSceneLoadParameters);
			}
			_panel.Hide();
		}
	}
}
