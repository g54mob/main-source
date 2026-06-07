using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ToggleFreeCamButton : MonoBehaviour
	{
		private UIButtonColor _button;

		private bool _toggled;

		private bool _hover;

		public void Awake()
		{
			_button = GetComponent<UIButtonColor>();
			base.gameObject.SetActive(RuntimeGlobals.GameMode == EGameMode.Campaign && SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects != null && SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects.OfType<NoInputAllowed>().Any());
		}

		public void OnClick()
		{
			_toggled = !_toggled;
			RuntimeGlobals.Camera.ToggleFreeCam(_toggled);
		}

		public void Update()
		{
			_button.SetState(_hover ? UIButtonColor.State.Hover : (_toggled ? UIButtonColor.State.Pressed : UIButtonColor.State.Normal), false);
		}

		public void OnHover(bool over)
		{
			_hover = over;
		}

		public virtual void OnTooltip(bool show)
		{
			if (show)
			{
				NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("MainScene/FreeCamera"));
			}
		}
	}
}
