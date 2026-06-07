using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class MaterialSoundDefault : IMaterialSound
	{
		private const float DEFAULT_VOLUME = 0.25f;

		[SerializeField]
		private float m_Volume = 0.25f;

		[SerializeField]
		private AudioClip[] m_Variations = Array.Empty<AudioClip>();

		[SerializeField]
		private PoolField m_Impact = new PoolField();

		private int variationIndex;

		public float Volume => m_Volume;

		public AudioClip Audio
		{
			get
			{
				if (m_Variations.Length == 0)
				{
					return null;
				}
				int num = UnityEngine.Random.Range(0, m_Variations.Length - 1);
				num = (variationIndex = num + ((m_Variations.Length > 1 && num == variationIndex) ? 1 : 0));
				return m_Variations[num];
			}
		}

		public PoolField Impact => m_Impact;

		public static MaterialSoundDefault Create()
		{
			return new MaterialSoundDefault
			{
				m_Variations = new AudioClip[1],
				m_Volume = 0.25f
			};
		}
	}
}
