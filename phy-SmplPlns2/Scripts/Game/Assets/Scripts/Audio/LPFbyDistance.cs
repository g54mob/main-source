using System;
using UnityEngine;

namespace Assets.Scripts.Audio
{
	public class LPFbyDistance : MonoBehaviour
	{
		private static AudioListener _activeAudioListener;

		[SerializeField]
		private AudioLowPassFilter _filter;

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

		public Vector3 Distance { get; private set; }

		public float Limit { get; set; } = 22000f;

		public AudioLowPassFilter Filter
		{
			get
			{
				return _filter;
			}
			set
			{
				_filter = value;
			}
		}

		protected void Update()
		{
			Distance = ActiveAudioListener.gameObject.transform.position - base.transform.position;
			float b = 1300000f / (Distance.magnitude + 60f);
			_filter.cutoffFrequency = Mathf.Min(Limit, b);
		}
	}
}
