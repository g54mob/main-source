using System.Collections;
using System.Xml.Linq;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft;
using Assets.Scripts.Design;
using Assets.Scripts.Design.UI;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class InFlightDesignerScene
	{
		private XElement _craftXmlToLoadUponEnteringDesigner;

		private DesignerScript _designerScript;

		private DesignerUIScript _designerUI;

		private FlightSceneScript _flightScene;

		public bool Active { get; private set; }

		public DesignerScript DesignerScript => _designerScript;

		public bool Loaded { get; private set; }

		public InFlightDesignerScene(FlightSceneScript flightScene)
		{
			_flightScene = flightScene;
		}

		public void Enter()
		{
			if (Active)
			{
				Debug.LogError("Unable to enter the in-flight designer scene because it is already active");
				return;
			}
			AircraftScript aircraft = _flightScene.LocalPlayer.Aircraft;
			AircraftScript aircraftScript = _designerScript?.Designer.Aircraft;
			bool flag = aircraftScript == null || (aircraft != null && aircraft.Aircraft.Name != aircraftScript.Aircraft.Name);
			_craftXmlToLoadUponEnteringDesigner = ((!flag) ? null : aircraft?.NetworkAircraft?.CraftXml);
			_flightScene.LocalPlayer.DespawnAircraft();
			_flightScene.LocalPlayer.OnEnteredInFlightDesigner();
			AudioMixing.IsInDesigner = true;
			if (Loaded)
			{
				SetVisible(visible: true);
			}
			else
			{
				Load(showAfterLoading: true);
			}
			DesignerScript.OnEnteredFromFlight();
		}

		public void Exit()
		{
			if (!Active)
			{
				Debug.LogError("Unable to exit the in-flight designer scene because it is not active");
				return;
			}
			if (!Loaded)
			{
				Debug.LogError("Unable to exit the in-flight designer scene. The scene is marked as active but is not marked as loaded. Something is wrong.");
				return;
			}
			SetVisible(visible: false);
			_flightScene.LocalPlayer.OnExitedInFlightDesigner();
			AudioMixing.IsInDesigner = false;
		}

		public void Load()
		{
			Load(showAfterLoading: false);
		}

		public void Unload()
		{
			Loaded = false;
			Active = false;
			if (_designerScript != null)
			{
				Object.Destroy(_designerScript.gameObject);
				_designerScript = null;
			}
			if (_designerUI != null)
			{
				Object.Destroy(_designerUI.gameObject);
				_designerUI = null;
			}
		}

		private void Load(bool showAfterLoading)
		{
			if (Loaded)
			{
				Debug.LogError("Unable to load the in-flight designer scene because it is already loaded.");
				return;
			}
			FlightUIScript flightUIScript = Object.FindAnyObjectByType<FlightUIScript>(FindObjectsInactive.Include);
			_designerUI = Game.Instance.ResourceLoader.InstantiatePrefab<DesignerUIScript>("Designer/DesignerUI");
			_designerUI.transform.SetParent(_flightScene.FlightUI.transform.parent, worldPositionStays: false);
			_designerUI.transform.SetSiblingIndex(flightUIScript.transform.GetSiblingIndex() + 1);
			_designerScript = Game.Instance.ResourceLoader.InstantiatePrefab<DesignerScript>("Designer/Designer");
			Loaded = true;
			SetVisible(showAfterLoading);
		}

		private IEnumerator LoadDesignerCraftAtEndOfFrame(XElement craftXml)
		{
			yield return new WaitForEndOfFrame();
			if (_designerScript.Aircraft != null)
			{
				_designerScript.Designer.CreateUndoStep("Load craft");
			}
			_designerScript.Designer.LoadXml(craftXml, isNewAircraft: true);
		}

		private void SetVisible(bool visible)
		{
			Active = visible;
			InputWrapper.ApplySceneControls();
			Vector3 globalPosition = _flightScene.LocalPlayer.GlobalPosition;
			if (visible)
			{
				globalPosition.y = -20000f;
			}
			GameWorld.Instance.RepositionWorld(globalPosition, 0f, visible);
			_designerUI.gameObject.SetActive(visible);
			_designerScript.gameObject.SetActive(visible);
			_flightScene.FlightUI.gameObject.SetActive(!visible);
			_flightScene.RenderingManager.gameObject.SetActive(!visible);
			XElement craftXmlToLoadUponEnteringDesigner = _craftXmlToLoadUponEnteringDesigner;
			if (visible && craftXmlToLoadUponEnteringDesigner != null)
			{
				_craftXmlToLoadUponEnteringDesigner = null;
				_flightScene.StartCoroutine(LoadDesignerCraftAtEndOfFrame(craftXmlToLoadUponEnteringDesigner));
			}
			Game.Instance.Settings.SaveIfNecessary();
			if (visible)
			{
				FlightSceneScript.Instance?.UnloadUnusedAssets(force: false);
			}
		}
	}
}
