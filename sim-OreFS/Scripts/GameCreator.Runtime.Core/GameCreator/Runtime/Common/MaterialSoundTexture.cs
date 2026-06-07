using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class MaterialSoundTexture : TPolymorphicItem<MaterialSoundTexture>, IMaterialSound
	{
		private const float DEFAULT_VOLUME = 0.25f;

		[SerializeField]
		private string m_Name = "My Ground Type";

		[SerializeField]
		private Texture m_Texture;

		[SerializeField]
		private PoolField m_Impact = new PoolField();

		[SerializeField]
		private float m_Volume = 0.25f;

		[SerializeField]
		private AudioClip[] m_Variations = new AudioClip[1];

		private int variationIndex;

		public override string Title => $"{m_Name} ({m_Variations.Length})";

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

		public Texture Texture => m_Texture;

		public PoolField Impact => m_Impact;

		public static MaterialSoundTexture Create()
		{
			return new MaterialSoundTexture
			{
				m_Variations = new AudioClip[1],
				m_Volume = 0.25f
			};
		}
	}
}
