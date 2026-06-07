using UnityEngine;

namespace UMA
{
	public class UMABoneVisualizer : MonoBehaviour
	{
		public Transform rootNode;

		public bool DrawAsBones;

		public bool DrawAdjustBones;

		public bool AlwaysDrawGizmos;

		public Mesh BoneMesh;

		public string Filter;

		private string lastFilter;

		private Transform[] childNodes;

		private Vector3 Scale;

		private void Start()
		{
		}

		private void Setup()
		{
		}

		private Transform RecursiveFindBone(Transform bone, string boneName)
		{
			return null;
		}

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void DrawBoneGizmos()
		{
		}

		public void PopulateChildren()
		{
		}
	}
}
