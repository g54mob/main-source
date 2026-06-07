using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Watercraft
{
	public abstract class Control : CustomBehaviour
	{
		public abstract Vector3 Input { get; }
	}
}
