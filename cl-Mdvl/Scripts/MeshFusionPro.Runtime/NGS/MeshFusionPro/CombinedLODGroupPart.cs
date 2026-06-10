using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class CombinedLODGroupPart : ICombinedObjectPart<CombinedLODGroup>, ICombinedObjectPart
	{
		private List<CombinedObjectPart> _baseParts;

		private Bounds _localBounds;

		ICombinedObject ICombinedObjectPart.Root => Root;

		public CombinedLODGroup Root { get; private set; }

		public Bounds LocalBounds => _localBounds;

		public Bounds Bounds
		{
			get
			{
				Bounds localBounds = _localBounds;
				localBounds.center += Root.transform.position;
				return localBounds;
			}
		}

		public CombinedLODGroupPart(CombinedLODGroup root, List<CombinedObjectPart> baseParts)
		{
			Root = root;
			_baseParts = baseParts;
			CalculateLocalBounds();
		}

		public void Destroy()
		{
			Root.Destroy(this, _baseParts);
		}

		private void CalculateLocalBounds()
		{
			_localBounds = _baseParts[0].Bounds;
			for (int i = 1; i < _baseParts.Count; i++)
			{
				_localBounds.Encapsulate(_baseParts[i].Bounds);
			}
			_localBounds.center -= Root.transform.position;
		}
	}
}
