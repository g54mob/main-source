using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class Tokens
	{
		[SerializeReference]
		private Token[] m_Tokens = Array.Empty<Token>();

		public Tokens()
		{
		}

		public Tokens(GameObject target, Memory[] memories)
			: this()
		{
			List<Token> list = new List<Token>();
			foreach (Memory memory in memories)
			{
				if (memory.IsEnabled)
				{
					list.Add(memory.GetToken(target));
				}
			}
			m_Tokens = list.ToArray();
		}

		public Token Get(int i)
		{
			if (i < 0)
			{
				return null;
			}
			if (i >= m_Tokens.Length)
			{
				return null;
			}
			return m_Tokens[i];
		}
	}
}
