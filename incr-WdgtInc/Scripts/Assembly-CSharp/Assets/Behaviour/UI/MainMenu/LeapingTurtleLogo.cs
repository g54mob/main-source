using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Behaviour.UI.MainMenu
{
	public class LeapingTurtleLogo : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private GameObject _highlight;

		public void OnPointerEnter(PointerEventData eventData)
		{
			_highlight.SetActive(value: true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_highlight.SetActive(value: false);
		}
	}
}
