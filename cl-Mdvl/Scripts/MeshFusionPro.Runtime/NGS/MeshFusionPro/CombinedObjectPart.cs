using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class CombinedObjectPart : ICombinedObjectPart<CombinedObject>, ICombinedObjectPart
	{
		private bool _destroyed;

		ICombinedObject ICombinedObjectPart.Root => Root;

		public CombinedObject Root { get; private set; }

		public CombinedMeshPart MeshPart { get; private set; }

		public Bounds LocalBounds => Root.GetLocalBounds(this);

		public Bounds Bounds => Root.GetBounds(this);

		public CombinedObjectPart(CombinedObject root, CombinedMeshPart meshPart)
		{
			Root = root;
			MeshPart = meshPart;
		}

		public void Destroy()
		{
			if (_destroyed)
			{
				Debug.Log("CombinedPart already destroyed");
				return;
			}
			Root.Destroy(this);
			_destroyed = true;
		}
	}
}
