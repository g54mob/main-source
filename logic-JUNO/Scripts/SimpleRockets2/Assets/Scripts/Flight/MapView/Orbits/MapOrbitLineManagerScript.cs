using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Dev.Philip.UiTesting.Scripts;
using Assets.Scripts.Flight.MapView.Orbits.DrawModes;
using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using Assets.Scripts.Flight.MapView.Orbits.Interfaces;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits
{
	public class MapOrbitLineManagerScript : MonoBehaviour, IOrbitLineManager
	{
		private bool _craftOnlyWhenSwitchingModes;

		private InfoPanel _infoPanel;

		private IOrbitLineManager _orbitLineManager;

		private bool _showApsidesInfo;

		ModeType IOrbitLineManager.Drawmode => MapViewScript.DrawMode.Mode;

		bool IOrbitLineManager.ShowApsidesInfo => _showApsidesInfo;

		private MapViewScript MapViewScript { get; set; }

		public static MapOrbitLineManagerScript Create(MapViewScript mapViewScript)
		{
			MapOrbitLineManagerScript mapOrbitLineManagerScript = mapViewScript.gameObject.AddComponent<MapOrbitLineManagerScript>();
			mapOrbitLineManagerScript.Initialize(mapViewScript);
			return mapOrbitLineManagerScript;
		}

		void IOrbitLineManager.SetOrbitDrawMode(ModeType newMode, bool craftOnly)
		{
			_craftOnlyWhenSwitchingModes = craftOnly;
			IDrawMode drawMode = null;
			switch (newMode)
			{
			case ModeType.ParentAtReferenceTime:
				drawMode = new ParentAtReferenceTime();
				break;
			case ModeType.ParentAtPointTime:
				drawMode = new ParentAtPointTime();
				break;
			case ModeType.ParentAtCurrentTime:
				drawMode = new ParentAtCurrentTime();
				break;
			case ModeType.SiblingAtPointTime:
				drawMode = new SiblingAtPointTime();
				break;
			case ModeType.HybridTime:
				drawMode = new HybridTime();
				break;
			case ModeType.EncounterNodeAtExitTime:
				drawMode = new EncounterNodeAtExitTime();
				break;
			case ModeType.Basic:
				drawMode = new BasicDrawMode();
				break;
			}
			if (drawMode != null)
			{
				MapViewScript.SetOrbitDrawMode(drawMode);
			}
		}

		public void Start()
		{
			_infoPanel = InfoPanel.Create<InfoPanel>("Orbit Line Options", delegate
			{
				Debug.Log("Orbit Line Header");
			});
			List<string> items = Enum.GetValues(typeof(ModeType)).Cast<ModeType>().ToList()
				.ConvertAll((ModeType x) => Utilities.Enums.GetDisplayName(x).ToLower());
			_infoPanel.AddDropdown("orbit mode", "draw orbit relative to...", delegate(int x)
			{
				_orbitLineManager.SetOrbitDrawMode((ModeType)x, _craftOnlyWhenSwitchingModes);
			}, null, items, rebuildUi: false);
			_infoPanel.AddToggleButton("show apsides", initialValue: false, delegate(bool x)
			{
				_showApsidesInfo = x;
			});
			_infoPanel.RebuildUi();
		}

		private void Initialize(MapViewScript mapViewScript)
		{
			_orbitLineManager = this;
			MapViewScript = mapViewScript;
			_orbitLineManager.SetOrbitDrawMode((!Game.InFlightScene) ? ModeType.ParentAtReferenceTime : ModeType.HybridTime, craftOnly: false);
		}

		private void OnDestroy()
		{
			if (_infoPanel != null)
			{
				UnityEngine.Object.Destroy(_infoPanel.gameObject);
			}
		}
	}
}
