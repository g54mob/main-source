using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TokenIsActive : Token
	{
		[SerializeField]
		private bool m_IsActive;

		public bool IsActive => m_IsActive;

		public TokenIsActive(GameObject target)
		{
			m_IsActive = target.activeSelf;
		}
	}
}
