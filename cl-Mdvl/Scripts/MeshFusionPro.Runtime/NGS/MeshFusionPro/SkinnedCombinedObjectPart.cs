using System;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class SkinnedCombinedObjectPart : ICombinedObjectPart<SkinnedCombinedObject>, ICombinedObjectPart
	{
		private bool _destroyed;

		ICombinedObject ICombinedObjectPart.Root => Root;

		public SkinnedCombinedObject Root { get; private set; }

		public CombinedMeshPart MeshPart { get; private set; }

		public Bounds Bounds
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public Bounds LocalBounds
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public SkinnedCombinedObjectPart(SkinnedCombinedObject root, CombinedMeshPart meshPart)
		{
			Root = root;
			MeshPart = meshPart;
		}

		public void Destroy()
		{
			if (_destroyed)
			{
				Debug.Log("SkinnedCombinedObjectPart already destroyed!");
				return;
			}
			Root.Destroy(this);
			_destroyed = true;
		}
	}
}
