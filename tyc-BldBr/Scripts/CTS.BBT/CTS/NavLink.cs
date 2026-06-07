using System;
using CTS.Core;
using Unity.AI.Navigation;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(NavMeshLink))]
	[DisallowMultipleComponent]
	[Constructor("Constructor")]
	public class NavLink : CTSBehaviour
	{
		[Inject(false)]
		private NavMeshLink _link;

		private BoxCollider _boxCollider;

		private void Constructor(NavMeshLink link, BoxCollider boxCollider)
		{
			base.gameObject.layer = LayerMask.NameToLayer("NavMesh");
			if (!boxCollider)
			{
				boxCollider = base.gameObject.AddComponent<BoxCollider>();
			}
			Vector3 vector = Vector3.right * link.width;
			Vector3 a = link.startPoint + vector;
			Vector3 b = link.endPoint - vector;
			Vector3 center = Vector3.Lerp(a, b, 0.5f);
			float y = Math.Max(Math.Abs(a.y - b.y), 0.25f);
			float x = Math.Abs(a.x - b.x) * 0.5f;
			float z = Math.Abs(a.z - b.z);
			boxCollider.center = center;
			boxCollider.size = new Vector3(x, y, z);
		}
	}
}
