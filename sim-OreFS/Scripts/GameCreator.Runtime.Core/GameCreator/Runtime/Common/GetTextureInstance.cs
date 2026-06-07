using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Texture")]
	[Category("Texture")]
	[Image(typeof(IconTexture), ColorTheme.Type.Blue)]
	[Description("A reference to a Texture asset")]
	[HideLabelsInEditor(true)]
	public class GetTextureInstance : PropertyTypeGetTexture
	{
		[SerializeField]
		protected Texture m_Texture;

		public override string String
		{
			get
			{
				if (!(m_Texture != null))
				{
					return "(none)";
				}
				return m_Texture.name;
			}
		}

		public override Texture EditorValue => m_Texture;

		public override Texture Get(Args args)
		{
			return m_Texture;
		}

		public override Texture Get(GameObject gameObject)
		{
			return m_Texture;
		}

		public static PropertyGetTexture Create(Texture texture = null)
		{
			return new PropertyGetTexture(new GetTextureInstance
			{
				m_Texture = texture
			});
		}
	}
}
