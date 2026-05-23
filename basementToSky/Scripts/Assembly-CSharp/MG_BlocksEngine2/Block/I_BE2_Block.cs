using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.DragDrop;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public interface I_BE2_Block
	{
		Transform Transform { get; }

		BlockTypeEnum Type { get; set; }

		I_BE2_BlockLayout Layout { get; }

		I_BE2_Instruction Instruction { get; set; }

		I_BE2_BlockSection ParentSection { get; set; }

		I_BE2_Block ParentBlock { get; set; }

		I_BE2_Drag Drag { get; }

		void SetShadowActive(bool value);
	}
}
