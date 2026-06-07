using System;

namespace Factory.FieldData
{
	public struct ExtBlendKey : IEquatable<ExtBlendKey>
	{
		private eLuggage blend_source1;

		private eLuggage blend_source2;

		private eLuggage blend_source3;

		private eLuggage blend_source4;

		private eLuggage blend_source5;

		private eLuggage blend_source6;

		public ExtBlendKey(MstBlendDataEntities mstBlendDataEntities)
		{
			blend_source1 = default(eLuggage);
			blend_source2 = default(eLuggage);
			blend_source3 = default(eLuggage);
			blend_source4 = default(eLuggage);
			blend_source5 = default(eLuggage);
			blend_source6 = default(eLuggage);
		}

		public ExtBlendKey(params eLuggage[] args)
		{
			blend_source1 = default(eLuggage);
			blend_source2 = default(eLuggage);
			blend_source3 = default(eLuggage);
			blend_source4 = default(eLuggage);
			blend_source5 = default(eLuggage);
			blend_source6 = default(eLuggage);
		}

		public override bool Equals(object? obj)
		{
			return false;
		}

		public bool Equals(ExtBlendKey other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		private static int GetMediumValue(int top, int mid, int bottom)
		{
			return 0;
		}

		private static void QuickSortDescending(ref eLuggage[] array, int left, int right)
		{
		}

		public int GetMaterialCount()
		{
			return 0;
		}
	}
}
