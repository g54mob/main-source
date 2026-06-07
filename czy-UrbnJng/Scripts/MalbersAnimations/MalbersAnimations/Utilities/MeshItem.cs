using System;
using MalbersAnimations.Reactions;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class MeshItem
	{
		public string ItemName = "";

		[Tooltip("Main Transform mesh")]
		public Transform Mesh;

		[Tooltip("Name of the transform to parent the mesh. (Optional)")]
		public Transform Parent;

		[Tooltip("Hides  another ActiveMesh Set when this Item is Active. Works only in Play Mode")]
		public string HideSet;

		[Tooltip("New Set of Materials to change the mesh")]
		public Material[] materials;

		[Tooltip("LODs Included in the Mesh Item")]
		public Renderer[] Renderers;

		[SerializeReference]
		[SubclassSelector]
		public Reaction MeshOn;

		[SerializeReference]
		[SubclassSelector]
		public Reaction MeshOff;

		[SerializeField]
		[HideInInspector]
		private int EditorTab;

		[HideInInspector]
		public Renderer MainRenderer;

		internal void UpdateMaterials()
		{
			if (materials == null || materials.Length == 0)
			{
				return;
			}
			if (MainRenderer == null)
			{
				MainRenderer = Mesh.GetComponentInChildren<Renderer>();
			}
			if ((bool)MainRenderer)
			{
				MainRenderer.sharedMaterials = materials;
			}
			if (Renderers == null || Renderers.Length == 0)
			{
				return;
			}
			for (int i = 0; i < Renderers.Length; i++)
			{
				Renderer renderer = Renderers[i];
				if (renderer != null && renderer.transform != Mesh)
				{
					renderer.sharedMaterials = materials;
				}
			}
		}

		internal bool SetParameters()
		{
			bool result = false;
			if (string.IsNullOrEmpty(ItemName))
			{
				ItemName = ((Mesh != null) ? Mesh.name : "Empty");
				result = true;
			}
			if ((bool)Mesh && (Renderers == null || Renderers.Length == 0))
			{
				Renderers = Mesh.GetComponentsInChildren<Renderer>();
				result = true;
			}
			return result;
		}

		internal void SetParent()
		{
			if (Mesh != null && Parent != null && Mesh.parent != Parent)
			{
				Mesh.SetParent(Parent);
				Mesh.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			}
		}
	}
}
