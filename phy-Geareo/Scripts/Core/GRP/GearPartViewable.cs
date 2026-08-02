using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class GearPartViewable : PartViewable<GearPart>
	{
		public StateSelector<Vector3> visualSize;

		public StateSelector<Vector3> shapeSize;

		protected override void Setup()
		{
		}
	}
}
