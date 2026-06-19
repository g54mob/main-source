using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class AmbulancePin : UIMapPin, iRenderStateChangeable
	{
		[SerializeField]
		private ScaleElementOnMouseOver _mouseOverComponent;

		[SerializeField]
		private Image _pinImage;

		[SerializeField]
		private Image _outLineImage;

		[SerializeField]
		private Image _notificationImage;

		[SerializeField]
		private TMP_Text _notificationText;

		private Ambulance _ambulance;

		private AmbulanceRouteRenderer _ambulanceRouteRenderer;

		private FoundationStyleDefinition _foundationStyle;

		private float _previousXPosition;

		public Ambulance Ambulance => _ambulance;

		public void Setup(EmergencyDispatchMap dispatchMap, Ambulance ambulance, AmbulanceRouteRenderer routeRenderer)
		{
			_ambulance = ambulance;
			_ambulanceRouteRenderer = routeRenderer;
			_pinImage.overrideSprite = _ambulance.Config.UISprite;
			_outLineImage.overrideSprite = _ambulance.Config.UIOutlineSprite;
			_foundationStyle = _ambulance.Owner.FoundationStyle;
			Setup(dispatchMap, _ambulance.Owner.BaseConfig.Location);
			_mapLayer = ((_ambulance.AmbulanceType == AmbulanceConfig.Type.Air) ? MapLayerParent.EMapLayer.AirPins : MapLayerParent.EMapLayer.RoadPins);
			if (_foundationStyle != null)
			{
				bool flag = false;
				if (DispatchMap.SelectedPin != null && DispatchMap.SelectedPin is EmergencyPin emergencyPin)
				{
					flag = emergencyPin.AmbulanceEmergency?.EmergencyID == _ambulance?.AmbulanceEmergency?.EmergencyID;
				}
				SetRenderState(flag ? ERenderState.Emphasised : ERenderState.Neutral);
			}
			RectTransform obj = base.transform as RectTransform;
			float uISpriteSize = _ambulance.Config.UISpriteSize;
			obj.sizeDelta = new Vector2(uISpriteSize, uISpriteSize);
			if (_mouseOverComponent != null)
			{
				_mouseOverComponent.enabled = true;
			}
			_previousXPosition = _mapPosition.x;
			SetSpriteDirection();
		}

		public override void UpdatePin(EmergencyDispatchMap map)
		{
			if (!_ambulance.IsActive || _ambulanceRouteRenderer == null)
			{
				return;
			}
			Vector2 positionAlongRoute = _ambulanceRouteRenderer.GetPositionAlongRoute(_ambulance.Progress);
			base.transform.localPosition = positionAlongRoute;
			_mapPosition = positionAlongRoute;
			_notificationImage.enabled = false;
			_notificationText.gameObject.SetActive(value: false);
			SetSpriteDirection();
			if (_ambulance.ShouldHighlight)
			{
				TriggerScaleComponent(active: true);
				_outLineImage.color = Color.white;
				_outLineImage.enabled = true;
			}
			else
			{
				TriggerScaleComponent(active: false);
				map.RefreshRenderStateChangeable(_ambulance, this);
			}
			if (_ambulance.CurrentState == Ambulance.State.ReturningToBase && !_ambulance.AmbulanceEmergency.IsRescue)
			{
				_notificationImage.enabled = true;
				_notificationText.gameObject.SetActive(value: true);
				if (_ambulance is PlayerAmbulance playerAmbulance)
				{
					_notificationText.text = playerAmbulance.PatientsCollected.Count.ToString();
				}
				else if (_ambulance is RivalAmbulance rivalAmbulance)
				{
					_notificationText.text = rivalAmbulance.NumPatientsOnboard.ToString();
				}
			}
		}

		public void SetRenderState(ERenderState renderState)
		{
			if (_foundationStyle != null)
			{
				FoundationStyleDefinition.StyleState style = _foundationStyle.GetStyle(renderState);
				_outLineImage.enabled = style.AmbulanceOutlineVisible;
				if (_outLineImage.enabled)
				{
					_outLineImage.color = style.AmbulanceOutlineColour;
				}
			}
		}

		public override void Select()
		{
		}

		private void SetSpriteDirection()
		{
			if (!(Math.Abs(_previousXPosition - _mapPosition.x) < Mathf.Epsilon))
			{
				Vector3 localScale = base.transform.localScale;
				if ((_previousXPosition < _mapPosition.x && localScale.x > 0f) | (_previousXPosition > _mapPosition.x && localScale.x < 0f))
				{
					FlipSprite();
				}
				_previousXPosition = _mapPosition.x;
			}
		}

		private void FlipSprite()
		{
			Vector2 vector = base.transform.localScale;
			vector.x *= -1f;
			base.transform.localScale = vector;
			_notificationText.transform.localScale = vector;
		}
	}
}
