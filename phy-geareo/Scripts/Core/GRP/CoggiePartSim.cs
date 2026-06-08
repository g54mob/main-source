using Rhizomatic.Pooling;

namespace GRP
{
	public class CoggiePartSim : PartSim<CoggiePart>
	{
		public PoolObject boxShapePrefab;

		public PoolObject sphereShapePrefab;

		public CustomShape bodyShape;

		public BoxShape boxShape;

		public SphereShape sphereShape;

		private PoolObject shapeObject;

		protected override void Setup()
		{
		}

		protected override void Begin()
		{
		}
	}
}
