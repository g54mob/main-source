using Assets.Scripts.Flight.GameView;
using ModApi;
using ModApi.Flight.UI;
using ModApi.Math;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class TargetBox
	{
		private bool _active = true;

		private XmlElement _element;

		private FlightSceneUiController _flightSceneUiController;

		private bool _flipText;

		private GameViewScript _gameView;

		private RectTransform _parentTransform;

		private RectTransform _targetArrow;

		private GameObject _targetBox;

		private TextMeshProUGUI _targetName;

		private XmlElement _targetNameElement;

		private bool FlipText
		{
			get
			{
				return _flipText;
			}
			set
			{
				if (_flipText != value)
				{
					_flipText = value;
					if (value)
					{
						_targetNameElement.AddClass("target-text-flipped");
					}
					else
					{
						_targetNameElement.RemoveClass("target-text-flipped");
					}
				}
			}
		}

		public TargetBox(XmlElement element, FlightSceneUiController flightSceneUiController)
		{
			_element = element;
			_flightSceneUiController = flightSceneUiController;
			_targetNameElement = element.GetElementByInternalId("target-name");
			_targetName = _targetNameElement.GetComponent<TextMeshProUGUI>();
			_targetArrow = element.GetElementByInternalId("target-arrow").GetComponent<RectTransform>();
			_targetBox = element.GetElementByInternalId("target-box").gameObject;
			_gameView = FlightSceneScript.Instance.ViewManager.GameView;
			_parentTransform = flightSceneUiController.GetComponent<RectTransform>();
		}

		public void Hide()
		{
			if (_active)
			{
				_active = false;
				_element.SetActive(active: false);
			}
		}

		public void Update(INavSphereTarget target)
		{
			if (target != null)
			{
				if (!_active)
				{
					_active = true;
					_element.SetActive(active: true);
				}
				Vector3d vector3d = target.Position;
				if (target.Parent != _flightSceneUiController.CraftNode.Parent)
				{
					vector3d = target.SolarPosition - _flightSceneUiController.CraftNode.Parent.SolarPosition;
				}
				Vector3 position = _gameView.ReferenceFrame.PlanetToFramePosition(vector3d);
				Vector3 vector = Utilities.GameWorldToScreenPoint(_gameView.GameCamera.NearCamera, position);
				double magnitude = (vector3d - _flightSceneUiController.CraftNode.Position).magnitude;
				_targetName.text = $"{target.Name}\n{Units.GetDistanceString((float)magnitude)}";
				RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentTransform, vector, null, out var localPoint);
				_element.rectTransform.localPosition = localPoint;
				float num = 18f;
				float num2 = _parentTransform.rect.width / 2f - num;
				float num3 = _parentTransform.rect.height / 2f - num;
				if (localPoint.x < 0f - num2 || localPoint.x >= num2 || localPoint.y < 0f - num3 || localPoint.y >= num3 || vector.z < 0f)
				{
					Vector2 vector2 = localPoint;
					if (vector.z < 0f)
					{
						vector2 = -vector2;
					}
					Vector2 normalized = vector2.normalized;
					float a = float.MaxValue;
					if (normalized.x != 0f)
					{
						a = num2 / Mathf.Abs(normalized.x);
					}
					float b = float.MaxValue;
					if (normalized.y != 0f)
					{
						b = num3 / Mathf.Abs(normalized.y);
					}
					localPoint = Mathf.Min(a, b) * normalized;
					_targetBox.SetActive(value: false);
					float z = Mathf.Atan2(vector2.y, vector2.x) * 57.29578f;
					_targetArrow.gameObject.SetActive(value: true);
					_targetArrow.localEulerAngles = new Vector3(0f, 0f, z);
				}
				else
				{
					_targetBox.SetActive(value: true);
					_targetArrow.gameObject.SetActive(value: false);
				}
				FlipText = localPoint.y < 0f - (num3 - 50f);
				_element.rectTransform.localPosition = localPoint;
			}
			else
			{
				FlipText = false;
				Hide();
			}
		}
	}
}
