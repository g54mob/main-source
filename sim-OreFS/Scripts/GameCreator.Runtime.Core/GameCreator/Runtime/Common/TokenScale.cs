using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TokenScale : Token
	{
		[SerializeField]
		private Vector3 m_Scale;

		public Vector3 Scale => m_Scale;

		public TokenScale(GameObject target)
		{
			m_Scale = target.transform.localScale;
		}
	}
}
