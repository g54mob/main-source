using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Splines
{
	public abstract class SplinePointData : ManagedBehaviour<WaterRenderer>
	{
		internal abstract Vector4 GetData(Vector4 data);
	}
}
