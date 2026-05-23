using System.Collections.Generic;
using MG_BlocksEngine2.Block;
using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
	public interface I_BE2_ProgrammingEnv
	{
		Transform Transform { get; }

		List<I_BE2_Block> BlocksList { get; }

		I_BE2_TargetObject TargetObject { get; }

		bool Visible { get; set; }

		void UpdateBlocksList();

		void ClearBlocks();
	}
}
