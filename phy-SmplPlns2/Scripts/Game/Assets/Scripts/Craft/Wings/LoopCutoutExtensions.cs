using Unity.Collections;

namespace Assets.Scripts.Craft.Wings
{
	public static class LoopCutoutExtensions
	{
		public static NativeSlice<Point> Add(this NativeList<Point> list, LoopCutout cutout, bool includeEnds = true, bool resetMeshRefs = true, short startPointId = -1, short endPointId = -1)
		{
			int num = (includeEnds ? (cutout.Length + 2) : cutout.Length);
			int length = list.Length;
			list.Resize(list.Length + num, NativeArrayOptions.UninitializedMemory);
			NativeSlice<Point> nativeSlice = list.AsArray().Slice(length);
			int num2 = 0;
			if (includeEnds)
			{
				Point startPoint = cutout.StartPoint;
				startPoint.SharedPointID = startPointId;
				nativeSlice[0] = startPoint;
				startPoint = cutout.EndPoint;
				startPoint.SharedPointID = endPointId;
				nativeSlice[nativeSlice.Length - 1] = startPoint;
				num2++;
			}
			nativeSlice.Slice(num2, cutout.Slice1.Length).CopyFrom(cutout.Slice1);
			if (cutout.Length > cutout.Slice1.Length)
			{
				nativeSlice.Slice(num2 + cutout.Slice1.Length, cutout.Slice2.Length).CopyFrom(cutout.Slice2);
			}
			if (resetMeshRefs)
			{
				for (int i = 0; i < nativeSlice.Length; i++)
				{
					Point value = nativeSlice[i];
					value.ResetMeshReferences();
					nativeSlice[i] = value;
				}
			}
			return nativeSlice;
		}

		public static NativeSlice<Point> Insert(this NativeList<Point> list, int targetIndex, LoopCutout cutout, bool includeEnds = true, bool resetMeshRefs = true)
		{
			int num = (includeEnds ? (cutout.Length + 2) : cutout.Length);
			list.InsertRangeWithBeginEnd(targetIndex, targetIndex + num);
			if (includeEnds)
			{
				list[targetIndex] = cutout.StartPoint;
				targetIndex++;
				list[targetIndex + cutout.Length] = cutout.EndPoint;
			}
			NativeArray<Point> thisArray = list.AsArray();
			thisArray.Slice(targetIndex, cutout.Slice1.Length).CopyFrom(cutout.Slice1);
			if (cutout.Length > cutout.Slice1.Length)
			{
				thisArray.Slice(targetIndex + cutout.Slice1.Length, cutout.Slice2.Length).CopyFrom(cutout.Slice2);
			}
			NativeSlice<Point> result = thisArray.Slice(targetIndex, num);
			if (resetMeshRefs)
			{
				for (int i = 0; i < result.Length; i++)
				{
					Point value = result[i];
					value.ResetMeshReferences();
					result[i] = value;
				}
			}
			return result;
		}
	}
}
