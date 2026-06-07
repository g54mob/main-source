using UnityEngine;

namespace App.Data
{
	public class QuestCondition : BaseCondition
	{
		public int Accuracy = -1;

		public float Time = -1f;

		public int Blocks = -1;

		public int CustomBlocks = -1;

		public int Servers = -1;

		public bool Check(SchemeBlock sch)
		{
			if (Blocks >= 0 && sch.GetFullBlocksCou() > Blocks)
			{
				return false;
			}
			if (CustomBlocks >= 0 && sch.GetCustomBlocksCou() > CustomBlocks)
			{
				return false;
			}
			if (Servers >= 0 && sch.GetServersCost() > Servers)
			{
				return false;
			}
			return true;
		}

		public bool Check(Construction construction)
		{
			if (Blocks >= 0 && construction.GetBlocksCou() > Blocks)
			{
				return false;
			}
			if (CustomBlocks >= 0 && construction.GetCustomBlocksCou() > CustomBlocks)
			{
				return false;
			}
			if (Time > 0f && (int)(10f * construction.timer) > Mathf.FloorToInt(10f * Time))
			{
				return false;
			}
			if (Servers >= 0 && construction.GetServersCouInSheme() > Servers)
			{
				return false;
			}
			return true;
		}
	}
}
