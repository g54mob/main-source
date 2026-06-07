using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class ReactionList : TPolymorphicList<ReactionItem>
	{
		[SerializeReference]
		private ReactionItem[] m_List = Array.Empty<ReactionItem>();

		public override int Length => m_List.Length;

		public ReactionList()
		{
		}

		public ReactionList(params ReactionItem[] reactions)
			: this()
		{
			m_List = reactions;
		}

		public ReactionItem Get(Args args, Vector3 direction, float power)
		{
			ReactionItem[] list = m_List;
			foreach (ReactionItem reactionItem in list)
			{
				if (reactionItem.CheckDirection(direction) && reactionItem.CheckPower(power) && reactionItem.CheckConditions(args))
				{
					return reactionItem;
				}
			}
			return null;
		}
	}
}
