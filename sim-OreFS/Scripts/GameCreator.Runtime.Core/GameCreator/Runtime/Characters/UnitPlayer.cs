using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class UnitPlayer
	{
		[SerializeReference]
		private TUnitPlayer m_Player = new UnitPlayerDirectional();

		public TUnitPlayer Wrapper => m_Player;

		public UnitPlayer()
		{
		}

		public UnitPlayer(TUnitPlayer unit)
		{
			m_Player = unit;
		}

		public override string ToString()
		{
			if (m_Player == null)
			{
				return "(none)";
			}
			return m_Player.ToString();
		}
	}
}
