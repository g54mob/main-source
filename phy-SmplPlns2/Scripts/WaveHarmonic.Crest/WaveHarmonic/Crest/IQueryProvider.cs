using System;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	public interface IQueryProvider
	{
		internal static int Query(int hash, float minimumLength, Vector3[] points, int layer, Vector3? center)
		{
			throw new NotImplementedException("Crest: this method is for documentation reuse only. Do not invoke.");
		}

		bool RetrieveSucceeded(int status)
		{
			return (status & 1) == 0;
		}
	}
}
