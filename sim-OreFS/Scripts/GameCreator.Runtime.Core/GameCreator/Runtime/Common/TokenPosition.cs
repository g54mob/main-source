using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TokenPosition : Token
	{
		[SerializeField]
		private Vector3 m_Position;

		public Vector3 Position => m_Position;

		public TokenPosition(GameObject target)
		{
			Character character = target.Get<Character>();
			m_Position = ((character != null) ? character.Feet : target.transform.position);
		}
	}
}
