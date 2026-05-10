using System.Runtime.CompilerServices;
using UnityEngine;

namespace Components.Audio
{
	[RequireComponent(typeof(AudioSource))]
	public class LerpSound : MonoBehaviour
	{
		[SerializeField]
		private float m_maxVolume;

		[SerializeField]
		private float m_minVolume;

		[SerializeField]
		private float m_maxPitch;

		[SerializeField]
		private float m_minPitch;

		[SerializeField]
		private float m_activateSpeed;

		[SerializeField]
		private float m_deactivateSpeed;

		[SerializeField]
		private bool m_useUnscaledTime;

		[SerializeField]
		private AudioSource m_audioSource;

		private float tfw;

		private float tfx;

		private float tfy;

		private float tfz;

		private float tga;

		public bool tgb
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void jgw()
		{
		}

		public void jgx()
		{
		}

		public void jgy(float a, float b)
		{
		}

		public void jgz(float a, float b, float c, float d)
		{
		}
	}
}
