using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TokenLightIntensity : Token
	{
		[SerializeField]
		private float m_Intensity;

		public float Intensity => m_Intensity;

		public TokenLightIntensity(Light light)
		{
			m_Intensity = ((light != null) ? light.intensity : 0f);
		}
	}
}
