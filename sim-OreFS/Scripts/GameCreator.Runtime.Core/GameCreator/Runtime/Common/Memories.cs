using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class Memories : TPolymorphicList<Memory>
	{
		[SerializeReference]
		private Memory[] m_Memories = new Memory[3]
		{
			new MemoryPosition(),
			new MemoryRotation(),
			new MemoryScale()
		};

		public override int Length => m_Memories.Length;

		public Type SaveType => typeof(Tokens);

		public Tokens GetTokens(GameObject target)
		{
			return new Tokens(target, m_Memories);
		}

		public void OnRemember(GameObject target, Tokens tokens)
		{
			if (tokens == null)
			{
				return;
			}
			for (int i = 0; i < Length; i++)
			{
				Token token = tokens.Get(i);
				if (m_Memories[i].IsEnabled)
				{
					m_Memories[i].OnRemember(target, token);
				}
			}
		}
	}
}
