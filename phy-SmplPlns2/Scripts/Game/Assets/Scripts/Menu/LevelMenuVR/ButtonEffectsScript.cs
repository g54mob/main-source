using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Menu.LevelMenuVR
{
	public class ButtonEffectsScript : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerClickHandler
	{
		public enum ButtonSoundEffectType
		{
			Normal = 0,
			Success = 1
		}

		[SerializeField]
		private ButtonSoundEffectType _soundEffect;

		public ButtonSoundEffectType SoundEffect
		{
			get
			{
				return _soundEffect;
			}
			set
			{
				_soundEffect = value;
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			UISound sound = ((_soundEffect == ButtonSoundEffectType.Success) ? UISound.DesignerStep : UISound.ButtonClick);
			Game.Instance.UserInterface.Sound.PlaySound(sound);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerSelectPart);
		}
	}
}
