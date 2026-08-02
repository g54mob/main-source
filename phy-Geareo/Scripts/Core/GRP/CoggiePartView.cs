using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	public class CoggiePartView : PartView<CoggiePartViewable>
	{
		public PoolObject boxShapePrefab;

		public PoolObject sphereShapePrefab;

		public Transform snap;

		private PoolObject shape;

		protected override void OnRender()
		{
		}
	}
}
