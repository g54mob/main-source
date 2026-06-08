using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dorfromantik.UI.Components
{
	public class UiToggle : Toggle
	{
		private UiRippleCreator uiRippleCreator;

		private UiAudioPlayer uiAudioPlayer;

		protected override void Awake()
		{
			base.Awake();
			uiRippleCreator = GetComponent<UiRippleCreator>();
			uiAudioPlayer = GetComponent<UiAudioPlayer>();
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			uiAudioPlayer.PlayAudio(uiAudioPlayer.hoverSound);
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			uiAudioPlayer.PlayAudio(uiAudioPlayer.clickSound);
			if ((bool)uiRippleCreator)
			{
				uiRippleCreator.CreateRipple(eventData.position);
			}
		}
	}
}
