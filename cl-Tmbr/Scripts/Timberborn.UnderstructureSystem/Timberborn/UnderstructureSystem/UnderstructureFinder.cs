using Timberborn.BlockSystem;

namespace Timberborn.UnderstructureSystem
{
	internal class UnderstructureFinder
	{
		private readonly IBlockService _blockService;

		public UnderstructureFinder(IBlockService blockService)
		{
			_blockService = blockService;
		}

		public BlockObject FindNonStrict(BlockObject blockObject)
		{
			foreach (Block foundationBlock in blockObject.PositionedBlocks.GetFoundationBlocks())
			{
				if (BlockShouldBeOnUnderstructure(foundationBlock))
				{
					return GetUnderlyingObject(foundationBlock);
				}
			}
			return null;
		}

		public BlockObject FindStrict(BlockObject blockObject)
		{
			BlockObject blockObject2 = null;
			foreach (Block foundationBlock in blockObject.PositionedBlocks.GetFoundationBlocks())
			{
				if (BlockShouldBeOnUnderstructure(foundationBlock))
				{
					BlockObject underlyingObject = GetUnderlyingObject(foundationBlock);
					if (underlyingObject == null)
					{
						return null;
					}
					if (blockObject2 == null)
					{
						blockObject2 = underlyingObject;
					}
					else if (blockObject2 != underlyingObject)
					{
						return null;
					}
				}
			}
			return blockObject2;
		}

		private BlockObject GetUnderlyingObject(Block foundationBlock)
		{
			return _blockService.GetBottomObjectComponentAt<BlockObject>(foundationBlock.Coordinates);
		}

		private static bool BlockShouldBeOnUnderstructure(Block foundationBlock)
		{
			return foundationBlock.Occupation.IsTopOrCornersOrBoth();
		}
	}
}
