using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TokenLightColor : Token
	{
		[SerializeField]
		private Color m_Color;

		public Color Color => m_Color;

		public TokenLightColor(Light light)
		{
			m_Color = ((light != null) ? light.color : Color.white);
		}
	}
}
