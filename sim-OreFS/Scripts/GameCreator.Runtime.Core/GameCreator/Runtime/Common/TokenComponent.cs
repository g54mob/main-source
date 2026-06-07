using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TokenComponent : Token
	{
		[SerializeField]
		private bool m_Enabled;

		public bool Enabled => m_Enabled;

		public TokenComponent(Behaviour behaviour)
		{
			m_Enabled = behaviour == null || behaviour.enabled;
		}
	}
}
