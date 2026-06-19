using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Aggro.Core
{
	public class AggroSettingSelectedColorUI : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
	{
		public Graphic graphic;

		public Color selectedColor = Color.magenta;

		public Color unselectedColor = Color.white;

		private void OnEnable()
		{
			graphic.color = unselectedColor;
		}

		public void OnSelect(BaseEventData eventData)
		{
			graphic.color = selectedColor;
		}

		public void OnDeselect(BaseEventData eventData)
		{
			graphic.color = unselectedColor;
		}
	}
}
