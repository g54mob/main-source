using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TokenExists : Token
	{
		[SerializeField]
		private bool m_Exists;

		public bool Exists => m_Exists;

		public TokenExists(GameObject target)
		{
			if (target == null)
			{
				m_Exists = false;
				return;
			}
			Remember remember = target.Get<Remember>();
			if (remember == null)
			{
				m_Exists = false;
			}
			else
			{
				m_Exists = !remember.IsSceneLoaded || !remember.IsDestroying;
			}
		}
	}
}
