using System.Collections.Immutable;
using Timberborn.Common;
using Timberborn.TerrainSystem;
using UnityEngine;

namespace Timberborn.BlockSystem
{
	internal class NoTerrainRemoverBelowValidator : IBlockObjectValidator
	{
		private readonly IBlockService _blockService;

		public NoTerrainRemoverBelowValidator(IBlockService blockService)
		{
			_blockService = blockService;
		}

		public bool IsValid(BlockObject blockObject, out string errorMessage)
		{
			errorMessage = null;
			ImmutableArray<Block> allBlocks = blockObject.PositionedBlocks.GetAllBlocks();
			if (blockObject.GetComponent<IGroundMatterBelowInvalidator>() == null && !allBlocks.FastAll((Block block) => block.MatterBelow != MatterBelow.Ground))
			{
				ImmutableArray<Block>.Enumerator enumerator = allBlocks.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Block current = enumerator.Current;
					if (ConflictsWithTerrainRemover(current))
					{
						return false;
					}
				}
			}
			return true;
		}

		private bool ConflictsWithTerrainRemover(Block block)
		{
			if (block.MatterBelow == MatterBelow.Ground)
			{
				Vector3Int coordinates = block.Coordinates.Below();
				foreach (ITerrainRemovingEntity item in _blockService.GetObjectsWithComponentAt<ITerrainRemovingEntity>(coordinates))
				{
					if (item.RemovesTerrainAt(coordinates))
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
