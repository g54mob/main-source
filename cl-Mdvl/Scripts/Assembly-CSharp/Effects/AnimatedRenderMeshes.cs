using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
	public class AnimatedRenderMeshes : MonoBehaviour
	{
		[SerializeField]
		private List<MeshRenderer> animatedMeshes = new List<MeshRenderer>();

		public List<MeshRenderer> AnimatedMeshes => animatedMeshes;
	}
}
