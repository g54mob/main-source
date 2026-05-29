using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Photon.Pun.UtilityScripts
{
	[RequireComponent(typeof(Graphic))]
	public class GraphicToggleIsOnTransition : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public Toggle toggle;

		private Graphic _graphic;

		public Color NormalOnColor;

		public Color NormalOffColor;

		public Color HoverOnColor;

		public Color HoverOffColor;

		private bool isHover;

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void OnValueChanged(bool isOn)
		{
		}
	}
}
