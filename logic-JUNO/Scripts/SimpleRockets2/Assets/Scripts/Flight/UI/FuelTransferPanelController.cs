using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Flight.UI;
using ModApi.Math;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.UI
{
	public class FuelTransferPanelController : FlightPanelController
	{
		private class FuelStatus
		{
			public bool Active { get; set; }

			public IFuelSource FuelSource { get; private set; }

			public Image ProgressImage { get; private set; }

			public RectTransform RectTransform { get; private set; }

			public TextMeshProUGUI Text { get; private set; }

			public XmlElement XmlElement { get; private set; }

			public FuelStatus(XmlElement xmlElement, IFuelSource fuelSource)
			{
				RectTransform = xmlElement.GetComponent<RectTransform>();
				FuelSource = fuelSource;
				Text = xmlElement.GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
				ProgressImage = xmlElement.GetElementByInternalId<Image>("transfer-progress");
				XmlElement = xmlElement;
			}
		}

		private IFlightSceneUI _flightSceneUi;

		private List<FuelStatus> _fuelStatuses = new List<FuelStatus>();

		private GameObject _fuelStatusTemplate;

		public override bool Active => true;

		public override void Initialize(FlightSceneUiController flightSceneUiController)
		{
			base.Initialize(flightSceneUiController);
			_flightSceneUi = FlightSceneScript.Instance.FlightSceneUI;
		}

		public override void LateUpdatePanel(CraftNode craftNode)
		{
			if (_flightSceneUi.FlightScene.ViewManager.MapViewManager.IsInForeground)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			base.gameObject.SetActive(value: true);
			CraftScript craftScript = craftNode.CraftScript as CraftScript;
			if (_fuelStatuses.Count <= 0 && craftScript.FuelTransfer.FuelSources.Count <= 0)
			{
				return;
			}
			foreach (FuelStatus fuelStatus2 in _fuelStatuses)
			{
				fuelStatus2.Active = false;
			}
			foreach (IFuelSource fuelSource in craftScript.FuelTransfer.FuelSources)
			{
				FuelStatus fuelStatus = GetFuelStatus(fuelSource);
				if (fuelStatus == null)
				{
					fuelStatus = CreateFuelStatus(fuelSource);
				}
				fuelStatus.Active = true;
				UpdateFuelStatus(fuelStatus);
			}
			for (int num = _fuelStatuses.Count - 1; num >= 0; num--)
			{
				if (!_fuelStatuses[num].Active || _fuelStatuses[num].FuelSource.IsDestroyed)
				{
					Object.Destroy(_fuelStatuses[num].RectTransform.gameObject);
					_fuelStatuses.RemoveAt(num);
				}
			}
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			_fuelStatusTemplate = base.xmlLayout.GetElementById("template").gameObject;
			if (Application.isPlaying)
			{
				_fuelStatusTemplate.gameObject.SetActive(value: false);
			}
			_fuelStatuses.Clear();
		}

		private FuelStatus CreateFuelStatus(IFuelSource fuelSource)
		{
			GameObject obj = Object.Instantiate(_fuelStatusTemplate);
			obj.transform.SetParent(_fuelStatusTemplate.transform.parent, worldPositionStays: false);
			obj.SetActive(value: true);
			FuelStatus fuelStatus = new FuelStatus(obj.GetComponent<XmlElement>(), fuelSource);
			_fuelStatuses.Add(fuelStatus);
			return fuelStatus;
		}

		private FuelStatus GetFuelStatus(IFuelSource fuelSource)
		{
			foreach (FuelStatus fuelStatus in _fuelStatuses)
			{
				if (fuelStatus.FuelSource == fuelSource)
				{
					return fuelStatus;
				}
			}
			return null;
		}

		private void UpdateFuelStatus(FuelStatus fuelStatus)
		{
			IFuelSource fuelSource = fuelStatus.FuelSource;
			Vector3 vector = Utilities.GameWorldToScreenPoint(_flightSceneUi.FlightScene.ViewManager.GameView.GameCamera.FarCamera, fuelSource.Position);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), vector, null, out var localPoint);
			fuelStatus.RectTransform.anchoredPosition = localPoint;
			float remainingPercentage = fuelSource.GetRemainingPercentage();
			fuelStatus.Text.text = Units.GetPercentageString(remainingPercentage);
			fuelStatus.ProgressImage.fillAmount = remainingPercentage;
			if (fuelSource.FuelTransferMode == FuelTransferMode.Fill)
			{
				fuelStatus.XmlElement.RemoveClass("fuel-tank-drain");
			}
			else if (fuelSource.FuelTransferMode == FuelTransferMode.Drain)
			{
				fuelStatus.XmlElement.AddClass("fuel-tank-drain");
			}
		}
	}
}
