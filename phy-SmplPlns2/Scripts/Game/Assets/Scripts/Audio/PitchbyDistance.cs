using System;
using UnityEngine;

namespace Assets.Scripts.Audio
{
	public class PitchbyDistance : MonoBehaviour
	{
		private static AudioListener _activeAudioListener;

		[SerializeField]
		private AudioSource _source;

		public static AudioListener ActiveAudioListener
		{
			get
			{
				if (!_activeAudioListener || !_activeAudioListener.isActiveAndEnabled)
				{
					_activeAudioListener = Array.Find(UnityEngine.Object.FindObjectsByType<AudioListener>(FindObjectsSortMode.None), (AudioListener audioListener) => audioListener.enabled);
				}
				return _activeAudioListener;
			}
		}

		protected void Update()
		{
			_source.pitch = Mathf.Min(10f, 100f / (ActiveAudioListener.gameObject.transform.position - base.transform.position).magnitude);
		}
	}
}
