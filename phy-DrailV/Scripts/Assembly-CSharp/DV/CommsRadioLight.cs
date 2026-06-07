using UnityEngine;

namespace DV
{
	public class CommsRadioLight : MonoBehaviour, ICommsRadioMode
	{
		public CommsRadioDisplay display;

		public AudioClip switchSound;

		public Light light;

		public ButtonBehaviourType ButtonBehaviour => ButtonBehaviourType.Regular;

		public bool ButtonACustomAction()
		{
			return false;
		}

		public bool ButtonBCustomAction()
		{
			return false;
		}

		public Color GetLaserBeamColor()
		{
			return Color.clear;
		}

		private void Awake()
		{
			if (switchSound == null)
			{
				Debug.LogError("switchSound not set, can't function properly!", this);
			}
			if (display == null)
			{
				Debug.LogError("display not set, can't function properly!", this);
			}
			if (light == null)
			{
				Debug.LogError("light not set, can't function properly!", this);
			}
		}

		public void OnUse()
		{
			light.gameObject.SetActive(!light.gameObject.activeSelf);
			UpdateDisplay();
			CommsRadioController.PlayAudioFromRadio(switchSound, base.transform);
		}

		public void SetStartingDisplay()
		{
			UpdateDisplay();
		}

		private void UpdateDisplay()
		{
			display.SetDisplay(CommsRadioLocalization.MODE_LED, light.gameObject.activeSelf ? CommsRadioLocalization.DISABLE_LED : CommsRadioLocalization.ENABLE_LED);
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public void OverrideSignalOrigin(Transform signalOrigin)
		{
		}

		public void OnUpdate()
		{
		}
	}
}
