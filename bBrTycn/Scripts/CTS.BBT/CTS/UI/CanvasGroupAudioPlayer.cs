using System;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.UI
{
	public class CanvasGroupAudioPlayer : MonoBehaviour
	{
		private CanvasGroupController _controller;

		[SerializeField]
		[HideIf("_playDefautlSound")]
		private AudioAsset _showedSound;

		[SerializeField]
		[HideIf("_playDefautlSound")]
		private AudioAsset _hidedSound;

		[SerializeField]
		private bool _playDefaultSound = true;

		public static event Action CanvasShow;

		public static event Action CanvasHidden;

		private void Awake()
		{
			_controller = GetComponent<CanvasGroupController>();
			_controller.CanvasShowned += Controller_CanvasShowned;
		}

		private void Controller_CanvasShowned(bool show)
		{
			if (!_playDefaultSound)
			{
				MonoSingleton<SoundManager>.Instance.PlayAudioAsset(show ? _showedSound : _hidedSound);
			}
			else if (show)
			{
				CanvasGroupAudioPlayer.CanvasShow?.Invoke();
			}
			else
			{
				CanvasGroupAudioPlayer.CanvasHidden?.Invoke();
			}
		}

		private void OnDestroy()
		{
			_controller.CanvasShowned -= Controller_CanvasShowned;
		}
	}
}
