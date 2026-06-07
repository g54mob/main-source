using Data.Buildings;
using Events;
using Presentation.FactoryFloor.Toolbar;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Data.Quests.Validators.ButtonReference
{
	public class ButtonHoveredValidatorWidget : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
	{
		[SerializeField]
		private BaseEvent _buttonHoveredEvent;

		[SerializeField]
		private PlaceBuildingButton _placeBuildingButton;

		[SerializeField]
		private BuildingObjectData _wantedBuildingObjectData;

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (_wantedBuildingObjectData != null && _placeBuildingButton.BuildingObjectData == _wantedBuildingObjectData)
			{
				_buttonHoveredEvent.Fire();
			}
		}
	}
}
