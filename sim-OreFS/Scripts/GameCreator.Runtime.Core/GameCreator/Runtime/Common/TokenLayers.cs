using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TokenLayers : Token
	{
		[SerializeField]
		private int m_Layers;

		public int Layers => m_Layers;

		public TokenLayers(GameObject target)
		{
			m_Layers = target.layer;
		}
	}
}
