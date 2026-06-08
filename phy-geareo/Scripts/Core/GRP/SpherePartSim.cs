using System;

namespace GRP
{
	public class SpherePartSim : PartSim<SpherePart>
	{
		public SphereVisual visual;

		public override Type GetPartType()
		{
			return null;
		}

		protected override void OnCreated()
		{
		}

		protected override void Setup()
		{
		}
	}
}
