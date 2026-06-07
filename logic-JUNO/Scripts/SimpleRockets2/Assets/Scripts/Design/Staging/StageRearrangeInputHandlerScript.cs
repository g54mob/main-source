using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Design.Staging
{
	public class StageRearrangeInputHandlerScript : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public bool PointerInside { get; set; }

		public void OnPointerEnter(PointerEventData eventData)
		{
			PointerInside = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			PointerInside = false;
		}
	}
}
