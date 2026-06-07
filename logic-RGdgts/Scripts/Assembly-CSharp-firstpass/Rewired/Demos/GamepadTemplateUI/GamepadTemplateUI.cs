using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Demos.GamepadTemplateUI
{
	public class GamepadTemplateUI : MonoBehaviour
	{
		private class Stick
		{
			private RectTransform _transform;

			private Vector2 _origPosition;

			private int _xAxisElementId;

			private int _yAxisElementId;

			public Vector2 position
			{
				get
				{
					return default(Vector2);
				}
				set
				{
				}
			}

			public Stick(RectTransform transform, int xAxisElementId, int yAxisElementId)
			{
			}

			public void Reset()
			{
			}

			public bool ContainsElement(int elementId)
			{
				return false;
			}

			public void SetAxisPosition(int elementId, float value)
			{
			}
		}

		private class UIElement
		{
			public int id;

			public ControllerUIElement element;

			public UIElement(int id, ControllerUIElement element)
			{
			}
		}

		private const float stickRadius = 20f;

		public int playerId;

		[SerializeField]
		private RectTransform leftStick;

		[SerializeField]
		private RectTransform rightStick;

		[SerializeField]
		private ControllerUIElement leftStickX;

		[SerializeField]
		private ControllerUIElement leftStickY;

		[SerializeField]
		private ControllerUIElement leftStickButton;

		[SerializeField]
		private ControllerUIElement rightStickX;

		[SerializeField]
		private ControllerUIElement rightStickY;

		[SerializeField]
		private ControllerUIElement rightStickButton;

		[SerializeField]
		private ControllerUIElement actionBottomRow1;

		[SerializeField]
		private ControllerUIElement actionBottomRow2;

		[SerializeField]
		private ControllerUIElement actionBottomRow3;

		[SerializeField]
		private ControllerUIElement actionTopRow1;

		[SerializeField]
		private ControllerUIElement actionTopRow2;

		[SerializeField]
		private ControllerUIElement actionTopRow3;

		[SerializeField]
		private ControllerUIElement leftShoulder;

		[SerializeField]
		private ControllerUIElement leftTrigger;

		[SerializeField]
		private ControllerUIElement rightShoulder;

		[SerializeField]
		private ControllerUIElement rightTrigger;

		[SerializeField]
		private ControllerUIElement center1;

		[SerializeField]
		private ControllerUIElement center2;

		[SerializeField]
		private ControllerUIElement center3;

		[SerializeField]
		private ControllerUIElement dPadUp;

		[SerializeField]
		private ControllerUIElement dPadRight;

		[SerializeField]
		private ControllerUIElement dPadDown;

		[SerializeField]
		private ControllerUIElement dPadLeft;

		private UIElement[] _uiElementsArray;

		private Dictionary<int, ControllerUIElement> _uiElements;

		private IList<ControllerTemplateElementTarget> _tempTargetList;

		private Stick[] _sticks;

		private Player player => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void DrawActiveElements()
		{
		}

		private void ActivateElements(Player player, int actionId)
		{
		}

		private void DrawLabels()
		{
		}

		private void DrawLabels(Player player, InputAction action)
		{
		}

		private void DrawLabel(ControllerUIElement uiElement, InputAction action, ControllerMap controllerMap, IControllerTemplate template, IControllerTemplateElement element)
		{
		}

		private Stick GetStick(int elementId)
		{
			return null;
		}

		private void OnControllerConnected(ControllerStatusChangedEventArgs args)
		{
		}

		private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
		{
		}
	}
}
