using System.Collections.Generic;
using UnityEngine;

namespace Gh
{
	public class BoxColliderResizer : MonoBehaviour
	{
		[Header("Required")]
		public BoxCollider boxCollider;

		public Transform renderersParent;

		[Header("Options")]
		public List<Renderer> ignoreRenderers;

		public bool includeParticleSystems;

		public bool resizeToChildColliders;

		[ContextMenu("Resize")]
		public void Resize()
		{
		}
	}
}
