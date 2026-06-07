using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TokenRotation : Token
	{
		[SerializeField]
		private Quaternion m_Rotation;

		public Quaternion Rotation => m_Rotation;

		public TokenRotation(GameObject target)
		{
			m_Rotation = target.transform.rotation;
		}
	}
}
