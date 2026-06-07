using UI;

namespace Factory.FieldData
{
	public class BlendState
	{
		public readonly MstBlendDataEntities Recipe;

		public readonly eLuggage[] SourceIds;

		private int[] NeedCounts { get; set; }

		public int CraftCount { get; private set; }

		public int OmakeCount { get; private set; }

		public BlendState(MstBlendDataEntities recipe, int materialCount, PlayUnlockData playUnlockData)
		{
		}

		public (MstBlendDataEntities, int, int) Craft(Structure[] stocks)
		{
			return default((MstBlendDataEntities, int, int));
		}

		public int GetNeedCount(eLuggage sourceId)
		{
			return 0;
		}

		public void MulNeedCount(eLuggage sourceId, int mul)
		{
		}

		public bool MulNeedInkBottleCount(int mul)
		{
			return false;
		}

		public bool UseInk()
		{
			return false;
		}

		public void IncCraftCount()
		{
		}

		public int DecCraftCount()
		{
			return 0;
		}

		public void MulCraftCount(float mul)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
