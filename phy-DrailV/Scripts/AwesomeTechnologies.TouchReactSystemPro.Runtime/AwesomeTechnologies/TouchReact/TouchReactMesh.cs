using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.TouchReact
{
	[ExecuteInEditMode]
	public class TouchReactMesh : MonoBehaviour
	{
		public List<MeshFilter> MeshFilterList = new List<MeshFilter>();

		private void Awake()
		{
			MeshFilterList.Clear();
		}

		private void Start()
		{
			AddMeshToManager();
		}

		private void OnEnable()
		{
			AddMeshToManager();
		}

		private void OnDisable()
		{
			RemoveMeshFromManager();
		}

		private void AddMeshToManager()
		{
			MeshFilter[] componentsInChildren = base.gameObject.GetComponentsInChildren<MeshFilter>();
			foreach (MeshFilter meshFilter in componentsInChildren)
			{
				MeshFilterList.Add(meshFilter);
				TouchReactSystem.AddMeshFilter(meshFilter);
			}
		}

		private void RemoveMeshFromManager()
		{
			for (int i = 0; i <= MeshFilterList.Count - 1; i++)
			{
				TouchReactSystem.RemoveMeshFilter(MeshFilterList[i]);
			}
			MeshFilterList.Clear();
		}
	}
}
