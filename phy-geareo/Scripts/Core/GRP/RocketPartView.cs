using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	public class RocketPartView : PartView<RocketPartViewable>
	{
		public PoolObject cylinderBodyPrefab;

		public PoolObject boxBodyPrefab;

		public Transform bottomVisual;

		public Transform tailCollider;

		public Renderer fireRenderer;

		public GameObject tailColliderCylinder;

		public GameObject tailColliderBox;

		public Transform right;

		public Transform left;

		public Transform top;

		public Transform forward;

		public Transform back;

		public float minSize;

		public float maxSize;

		private PoolObject shapeObject;

		private ISizedVisual shapeVisual;

		private MagicController magicController;

		private MaterialPropertyBlock fireMaterialBlock;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}
	}
}
