using CTS.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CTS
{
	public class CTSButtonSoundDiscussion : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
	{
		[SerializeField]
		private AudioAsset _hoverSound;

		public void OnPointerEnter(PointerEventData eventData)
		{
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_hoverSound);
		}
	}
}
