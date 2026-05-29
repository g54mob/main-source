using CTS.Core;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class AlertHandlers : MonoSingleton<AlertHandlers>
	{
		[Header("Base Settings")]
		[SerializeField]
		private GameObject _container;

		[SerializeField]
		private TextMeshProUGUI[] _texts;

		[SerializeField]
		private GameObject[] _infoTextGameObject;

		[Header("Audio Settings")]
		[SerializeField]
		private AudioSource _uiAudioSource;

		[SerializeField]
		private AudioClip _uiPushAudioClip;

		[Header("Debug Values")]
		[SerializeField]
		private string _debugTitle;

		[SerializeField]
		private string _debugText;

		[SerializeField]
		private string _debugTextInfo1;

		[SerializeField]
		private string _debugTextInfo2;

		private bool _isDisplayed;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void DisplayOrHideAlert(string p_Title, string p_Text, string p_Info_1 = null, string p_Info_2 = null)
		{
			if (!_isDisplayed)
			{
				_texts[0].text = p_Title;
				_texts[1].text = p_Text;
				if (!string.IsNullOrEmpty(p_Info_1))
				{
					_infoTextGameObject[0].SetActive(value: true);
					_texts[2].text = p_Info_1;
					if (!string.IsNullOrEmpty(p_Info_2))
					{
						_infoTextGameObject[1].SetActive(value: true);
						_texts[3].text = p_Info_2;
					}
				}
				else
				{
					_infoTextGameObject[0].SetActive(value: false);
					_infoTextGameObject[1].SetActive(value: false);
				}
				_container.SetActive(value: true);
				if ((bool)_uiAudioSource)
				{
					_uiAudioSource.clip = _uiPushAudioClip;
					_uiAudioSource.Play();
				}
			}
			else
			{
				_container.SetActive(value: false);
			}
		}

		public void HideAlert()
		{
			_container.SetActive(value: false);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void DebugDisplayAnAlert()
		{
			DisplayOrHideAlert(_debugTitle, _debugText, _debugTextInfo1, _debugTextInfo2);
		}
	}
}
