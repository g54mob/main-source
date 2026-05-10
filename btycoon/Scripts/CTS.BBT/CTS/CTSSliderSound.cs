using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class CTSSliderSound : MonoBehaviour
	{
		private CTSSlider _slider;

		[SerializeField]
		private AudioAsset _moveSound;

		[SerializeField]
		private int _multiplerToMakeThesound;

		[SerializeField]
		private bool _sliderSoundWhenMoving;

		private void Awake()
		{
			_slider = GetComponent<CTSSlider>();
		}

		private void Start()
		{
			_slider.onValueChanged.AddListener(delegate(float k)
			{
				Sound(k);
			});
		}

		private void Sound(float value)
		{
			int num = Mathf.RoundToInt(value);
			if (_sliderSoundWhenMoving && num % _multiplerToMakeThesound == 0)
			{
				MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_moveSound);
			}
		}

		private void OnDestroy()
		{
			_slider.onValueChanged.RemoveAllListeners();
		}
	}
}
