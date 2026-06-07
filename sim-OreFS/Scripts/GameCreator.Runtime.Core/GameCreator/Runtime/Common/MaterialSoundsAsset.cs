using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[CreateAssetMenu(fileName = "Material Sounds", menuName = "Game Creator/Common/Material Sounds", order = 50)]
	public class MaterialSoundsAsset : ScriptableObject
	{
		private const string MAIN_TEXTURE = "_MainTex";

		[SerializeField]
		private string m_TextureName = "_MainTex";

		[SerializeField]
		private MaterialSoundsData m_MaterialSounds = new MaterialSoundsData();

		[NonSerialized]
		private int m_TextureID;

		public int TextureID
		{
			get
			{
				if (m_TextureID == 0)
				{
					m_TextureID = ((!string.IsNullOrEmpty(m_TextureName)) ? Shader.PropertyToID(m_TextureName) : Shader.PropertyToID("_MainTex"));
				}
				return m_TextureID;
			}
		}

		public MaterialSoundsData MaterialSounds => m_MaterialSounds;
	}
}
