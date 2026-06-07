using System.Collections.Generic;
using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Inspector;
using ModApi;
using ModApi.PlanetStudio;
using ModApi.PlanetStudio.Events;
using ModApi.Ui;
using ModApi.Ui.Inspector;
using UI.Xml;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class PlanetStudioFlyoutScript : XmlLayoutController, IPlanetStudioInitialized
	{
		private InspectorPanel _inspectorPanel;

		public List<ItemElement> Elements { get; private set; }

		public IFlyout Flyout { get; private set; }

		public PlanetStudioUIScript PlanetStudioUI { get; private set; }

		void IPlanetStudioInitialized.OnInitialized(IPlanetStudioUI planetStudioUI)
		{
			PlanetStudioUI = planetStudioUI as PlanetStudioUIScript;
			OnInitialized(PlanetStudioUI);
			planetStudioUI.PlanetStudio.CelestialBodyDesigner.CelestialBodyLoaded += OnCelestialBodyLoaded;
			planetStudioUI.PlanetStudio.CelestialBodyDesigner.CelestialBodyViewRefreshed += OnCelestialBodyViewRefreshed;
			planetStudioUI.PlanetStudio.PlanetarySystemDesigner.PlanetarySystemLoaded += OnPlanetarySystemLoaded;
			planetStudioUI.PlanetStudio.PlanetarySystemDesigner.PlanetarySystemModified += OnPlanetarySystemModified;
		}

		protected void BuildFromModel(InspectorModel model)
		{
			PlanetStudioUI.PrepareInspectorModel(model);
			XmlElement elementById = base.xmlLayout.GetElementById("content");
			_inspectorPanel = new InspectorPanel(model, PlanetStudioUI.ElementBuilder, elementById);
			_inspectorPanel.RebuildModelElements();
		}

		protected void ClearModelElements()
		{
			_inspectorPanel?.ClearModelElements();
		}

		protected virtual void OnCelestialBodyLoaded()
		{
			if (Flyout.IsOpen)
			{
				RefreshUI();
			}
		}

		protected virtual void OnCelestialBodyViewRefreshed()
		{
		}

		protected virtual void OnDestroy()
		{
			ICelestialBodyDesigner celestialBodyDesigner = PlanetStudioUI?.PlanetStudio?.CelestialBodyDesigner;
			if (celestialBodyDesigner != null)
			{
				celestialBodyDesigner.CelestialBodyLoaded -= OnCelestialBodyLoaded;
				celestialBodyDesigner.CelestialBodyViewRefreshed -= OnCelestialBodyViewRefreshed;
			}
			IPlanetarySystemDesigner planetarySystemDesigner = PlanetStudioUI?.PlanetStudio?.PlanetarySystemDesigner;
			if (planetarySystemDesigner != null)
			{
				planetarySystemDesigner.PlanetarySystemLoaded -= OnPlanetarySystemLoaded;
				planetarySystemDesigner.PlanetarySystemModified -= OnPlanetarySystemModified;
			}
			_inspectorPanel?.Destroy();
			_inspectorPanel = null;
		}

		protected virtual void OnFlyoutClosed()
		{
			ClearModelElements();
		}

		protected virtual void OnFlyoutOpened()
		{
			RefreshUI();
		}

		protected virtual void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			Flyout = Utilities.GetComponentInParent<FlyoutScript>(base.transform);
			Flyout.Opened += delegate
			{
				OnFlyoutOpened();
			};
			Flyout.Closed += delegate
			{
				OnFlyoutClosed();
			};
			PlanetStudioUI = planetStudioUI;
		}

		protected virtual void RefreshUI()
		{
			ClearModelElements();
		}

		protected virtual void Update()
		{
			_inspectorPanel?.Update();
		}

		private void OnCelestialBodyLoaded(object sender, CelestialBodyLoadedEventArgs e)
		{
			OnCelestialBodyLoaded();
		}

		private void OnCelestialBodyViewRefreshed(object sender, CelestialBodyViewRefreshedEventArgs e)
		{
			OnCelestialBodyViewRefreshed();
		}

		private void OnPlanetarySystemLoaded()
		{
			if (Flyout.IsOpen)
			{
				RefreshUI();
			}
		}

		private void OnPlanetarySystemModified()
		{
			if (Flyout.IsOpen)
			{
				RefreshUI();
			}
		}
	}
}
