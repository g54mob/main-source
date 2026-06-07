using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class SwayRootBone : SwayBone
	{
		[Tooltip("For debugging purposes. forces changes on all bones")]
		public bool UpdateChangesEachFrame;

		[Tooltip("Bones that you want to ignore - these and their children are not processed")]
		public List<Transform> Exclusions;

		private List<SwayBone> SwayBones;

		private float step;

		private void Start()
		{
		}

		public void SetupBoneChains()
		{
		}

		private void AddChildBones(Transform transform, bool toplevel)
		{
		}

		public void FixedUpdate()
		{
		}
	}
}
