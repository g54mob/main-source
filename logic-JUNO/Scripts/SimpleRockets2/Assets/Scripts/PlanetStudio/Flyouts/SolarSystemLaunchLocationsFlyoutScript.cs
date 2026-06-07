using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Ui;
using ModApi.Planet;
using ModApi.State;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class SolarSystemLaunchLocationsFlyoutScript : PlanetStudioFlyoutScript
	{
		public class LaunchLocationElement
		{
			public LaunchLocation LaunchLocation { get; }

			public TextMeshProUGUI NameText { get; set; }

			public XmlElement RowElement { get; set; }

			public LaunchLocationElement(LaunchLocation launchLocation)
			{
				LaunchLocation = launchLocation;
			}
		}

		private bool _changed;

		private PlanetarySystemDesignerScript _designer;

		public List<LaunchLocationElement> LaunchLocations { get; private set; } = new List<LaunchLocationElement>();

		protected override void OnFlyoutClosed()
		{
			base.OnFlyoutClosed();
			List<LaunchLocation> list = new List<LaunchLocation>();
			foreach (LaunchLocationElement launchLocation in LaunchLocations)
			{
				list.Add(launchLocation.LaunchLocation);
			}
			_designer.CurrentPlanetarySystem.SetLaunchLocations(list);
			if (_changed)
			{
				_changed = false;
				_designer.RaisePlanetarySystemModifiedEvent();
			}
		}

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
			_designer = base.PlanetStudioUI.PlanetStudioScript.PlanetarySystemDesignerScript;
		}

		protected override void RefreshUI()
		{
			base.RefreshUI();
			foreach (LaunchLocationElement launchLocation in LaunchLocations)
			{
				Object.Destroy(launchLocation.RowElement.gameObject);
			}
			LaunchLocations.Clear();
			foreach (LaunchLocation defaultLaunchLocation in _designer.CurrentPlanetarySystem.GetDefaultLaunchLocations())
			{
				LaunchLocations.Add(CreateElement(defaultLaunchLocation));
			}
		}

		private LaunchLocationElement CreateElement(LaunchLocation launchLocation)
		{
			LaunchLocationElement launchLocationElement = new LaunchLocationElement(launchLocation);
			XmlElement elementById = base.xmlLayout.GetElementById("row-template");
			launchLocationElement.RowElement = UiUtilities.CloneTemplate(elementById, elementById.parentElement);
			launchLocationElement.RowElement.GetElementByInternalId<TextMeshProUGUI>("planet").text = launchLocation.PlanetName;
			launchLocationElement.NameText = launchLocationElement.RowElement.GetElementByInternalId<TextMeshProUGUI>("name");
			launchLocationElement.NameText.text = launchLocationElement.LaunchLocation.Name;
			return launchLocationElement;
		}

		private void OnDeleteItemClicked(XmlElement deleteButtonElement)
		{
			if (LaunchLocations.Count > 1)
			{
				XmlElement rowElement = deleteButtonElement.GetParentElementWithClass("list-item");
				LaunchLocationElement launchLocationElement = LaunchLocations.Where((LaunchLocationElement x) => x.RowElement == rowElement).FirstOrDefault();
				if (launchLocationElement != null)
				{
					LaunchLocations.Remove(launchLocationElement);
				}
				Object.Destroy(rowElement.gameObject);
				_changed = true;
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog("A planetary system must have at least one launch location.");
			}
		}

		private void OnResetButtonClicked()
		{
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.MessageText = "This will restore launch locations from all celestial bodies in the planetary system.";
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				List<LaunchLocation> list = new List<LaunchLocation>();
				foreach (PlanetDataScript planet in _designer.CurrentPlanetarySystem.Planets)
				{
					foreach (LaunchLocation defaultLaunchLocation in planet.DefaultLaunchLocations)
					{
						defaultLaunchLocation.PlanetName = planet.Name;
						list.Add(defaultLaunchLocation);
					}
				}
				_designer.CurrentPlanetarySystem.SetLaunchLocations(list);
				_changed = true;
				RefreshUI();
			};
		}
	}
}
