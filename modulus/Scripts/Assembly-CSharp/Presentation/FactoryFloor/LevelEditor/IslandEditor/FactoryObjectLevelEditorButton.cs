using Data.FactoryFloor.Islands;
using Events.Generic;
using Presentation.FactoryFloor.Toolbar;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class FactoryObjectLevelEditorButton : MonoBehaviour
	{
		[SerializeField]
		private SelectObjectToPlaceButton _selectObjectToPlaceButton;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private IntEvent _placeAreaToolEvent;

		[SerializeField]
		private BarInfoContent _barInfoContent;

		public void SetItem(EnvironmentObjectsDatabase.Item item)
		{
			_icon.sprite = item.Sprite;
			_icon.color = item.SpriteColour;
			if (item.FactoryObjectData.UIData != null)
			{
				_barInfoContent.SetBarInfo(item.FactoryObjectData.UIData);
			}
			else
			{
				_barInfoContent.SetBarInfo(item.FactoryObjectData.name, null, item.Sprite);
			}
			_selectObjectToPlaceButton.SetItem(item.FactoryObjectData);
			if (item.FactoryObjectData.name.Contains("Area"))
			{
				_selectObjectToPlaceButton.SwitchToAreaEvent(_placeAreaToolEvent);
			}
		}
	}
}
