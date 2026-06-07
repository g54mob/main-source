using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal interface IQueryableSimple : IQueryable
	{
		int Query(int hash, float minimumLength, Vector3[] queries, Vector3[] results, Vector3? center);
	}
}
