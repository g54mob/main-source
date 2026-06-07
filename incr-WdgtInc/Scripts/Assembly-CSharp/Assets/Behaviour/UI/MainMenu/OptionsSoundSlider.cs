using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Behaviour.UI.MainMenu
{
	public class OptionsSoundSlider : MonoBehaviour, IPointerUpHandler, IEventSystemHandler
	{
		public void OnPointerUp(PointerEventData eventData)
		{
			UISounds.PreviewVolume(GetComponent<Slider>().value);
			UISounds.TurnPage();
		}
	}
}
