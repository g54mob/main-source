using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TokenTag : Token
	{
		[SerializeField]
		private string m_Tag;

		public string Tag => m_Tag;

		public TokenTag(GameObject target)
		{
			m_Tag = target.tag;
		}
	}
}
