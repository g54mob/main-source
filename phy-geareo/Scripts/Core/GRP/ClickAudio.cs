using UnityEngine;
using UnityEngine.EventSystems;

namespace GRP
{
	public class ClickAudio : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public AudioClipConfig clip;

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
