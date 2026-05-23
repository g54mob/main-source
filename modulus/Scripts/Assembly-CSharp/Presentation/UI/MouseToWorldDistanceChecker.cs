using System.Collections.Generic;
using Events.WorldMap;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.UI
{
	public class MouseToWorldDistanceChecker : MonoBehaviour
	{
		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private InteractableWorldAreaEvent _interactableAreasInitializedEvent;

		private List<ScreenInteractableWorldArea> _areasToCheck = new List<ScreenInteractableWorldArea>();

		private ScreenInteractableWorldArea _lastHoveredArea;

		private void Awake()
		{
			_interactableAreasInitializedEvent.Register(AddInteractableArea);
		}

		private void OnDestroy()
		{
			_interactableAreasInitializedEvent.UnRegister(AddInteractableArea);
		}

		private void AddInteractableArea(ScreenInteractableWorldArea interactableAreaEventDto)
		{
			if (!_areasToCheck.Contains(interactableAreaEventDto))
			{
				_areasToCheck.Add(interactableAreaEventDto);
			}
		}

		private void Update()
		{
			float num = float.MaxValue;
			ScreenInteractableWorldArea screenInteractableWorldArea = null;
			foreach (ScreenInteractableWorldArea item in _areasToCheck)
			{
				Vector2 vector = _cameraLocator.Camera.WorldToScreenPoint(item.CenterPoint.position);
				Vector2 vector2 = Input.mousePosition;
				float num2 = Vector2.SqrMagnitude(vector - vector2);
				if (num2 <= item.SqrRadius && num2 < num)
				{
					screenInteractableWorldArea = item;
					num = num2;
				}
			}
			if (screenInteractableWorldArea == null)
			{
				if ((bool)_lastHoveredArea)
				{
					_lastHoveredArea.OnAreaStopHover();
					_lastHoveredArea = null;
				}
			}
			else if (Input.GetMouseButtonDown(0))
			{
				screenInteractableWorldArea.OnAreaIsClicked();
			}
			else if (_lastHoveredArea != screenInteractableWorldArea)
			{
				if ((bool)_lastHoveredArea)
				{
					_lastHoveredArea.OnAreaStopHover();
				}
				screenInteractableWorldArea.OnAreaIsHoveredOver();
				_lastHoveredArea = screenInteractableWorldArea;
			}
		}
	}
}
