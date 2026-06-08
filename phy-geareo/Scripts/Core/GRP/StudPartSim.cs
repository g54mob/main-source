using UnityEngine;

namespace GRP
{
	public class StudPartSim : PartSim<StudPart>
	{
		public SphereVisual bodyVisual;

		public CylinderVisual shaftVisual;

		public SphereShape bodyShape;

		public CylinderShape shaftShape;

		public float spacing;

		public ConfigurableJoint joint { get; private set; }

		protected override void OnCreated()
		{
		}

		protected override void Setup()
		{
		}

		protected override void BodiesReady()
		{
		}
	}
}
