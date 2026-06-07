using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal abstract class QueryBaseSimple : QueryBase, IQueryableSimple, IQueryable
	{
		protected QueryBaseSimple(IQueryableLod<IQueryProvider> lod)
			: base(lod)
		{
		}

		public virtual int Query(int ownerHash, float minSpatialLength, Vector3[] queryPoints, Vector3[] results, Vector3? center)
		{
			int num = 0;
			if (!UpdateQueryPoints(ownerHash, minSpatialLength, queryPoints, null))
			{
				num |= 2;
			}
			if (!RetrieveResults(ownerHash, results, null, null))
			{
				num |= 1;
			}
			return num;
		}
	}
}
