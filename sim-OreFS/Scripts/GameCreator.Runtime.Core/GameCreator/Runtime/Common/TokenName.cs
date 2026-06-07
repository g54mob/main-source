using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TokenName : Token
	{
		[SerializeField]
		private string m_Name;

		public string Name => m_Name;

		public TokenName(GameObject target)
		{
			m_Name = target.name;
		}
	}
}
