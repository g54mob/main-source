using System;
using Jundroo.Common.DataTypes.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class PartLodDataScript : MonoBehaviour
	{
		[Serializable]
		private class LodEntry
		{
			public float Lod;

			public string Path = "Meshes/";
		}

		[SerializeField]
		private LodEntry[] _colliderLodModels;

		[SerializeField]
		private MeshCollider _colliderMesh;

		private LodEntry _currentColliderLod;

		private LodEntry _currentMeshLod;

		[SerializeField]
		private LodEntry[] _meshLodModels;

		[SerializeField]
		private MeshFilter _renderMeshFilter;

		public void UpdateColliderLod(float lod)
		{
			if (!_colliderMesh.enabled)
			{
				return;
			}
			LodEntry lodEntry = null;
			for (int i = 0; i < _colliderLodModels.Length; i++)
			{
				if (lod < _colliderLodModels[i].Lod)
				{
					lodEntry = _colliderLodModels[i];
					break;
				}
			}
			if (lodEntry == null)
			{
				lodEntry = _colliderLodModels[_colliderLodModels.Length - 1];
			}
			if (_currentColliderLod != lodEntry)
			{
				_currentColliderLod = lodEntry;
				_colliderMesh.sharedMesh = null;
				UnityEngine.Object obj = Resources.Load(_currentColliderLod.Path);
				if (obj is Mesh sharedMesh)
				{
					_colliderMesh.sharedMesh = sharedMesh;
				}
				else if (obj is AssetRefMesh assetRefMesh)
				{
					_colliderMesh.sharedMesh = assetRefMesh.GetMeshShared();
				}
				else if (obj == null)
				{
					Debug.LogError("The asset at path '" + _currentColliderLod.Path + "' does not exist.");
				}
				else
				{
					Debug.LogError("The asset at path '" + _currentColliderLod.Path + "' exists but it is not a mesh asset or mesh reference asset.");
				}
			}
		}

		public void UpdateLod(float lod)
		{
			UpdateMeshLod(lod);
			UpdateColliderLod(lod);
		}

		public void UpdateMeshLod(float lod)
		{
			LodEntry lodEntry = null;
			for (int i = 0; i < _meshLodModels.Length; i++)
			{
				if (lod < _meshLodModels[i].Lod)
				{
					lodEntry = _meshLodModels[i];
					break;
				}
			}
			if (lodEntry == null)
			{
				lodEntry = _meshLodModels[_meshLodModels.Length - 1];
			}
			if (_currentMeshLod != lodEntry)
			{
				_currentMeshLod = lodEntry;
				if (_renderMeshFilter.mesh != null)
				{
					UnityEngine.Object.Destroy(_renderMeshFilter.mesh);
					_renderMeshFilter.mesh = null;
				}
				UnityEngine.Object obj = Resources.Load(_currentMeshLod.Path);
				if (obj is Mesh mesh)
				{
					_renderMeshFilter.mesh = mesh;
				}
				else if (obj is AssetRefMesh assetRefMesh)
				{
					_renderMeshFilter.mesh = assetRefMesh.GetMeshInstance();
				}
				else if (obj == null)
				{
					Debug.LogError("The asset at path '" + _currentMeshLod.Path + "' does not exist.");
				}
				else
				{
					Debug.LogError("The asset at path '" + _currentMeshLod.Path + "' exists but it is not a mesh asset or mesh reference asset.");
				}
				GetComponent<PartScript>().PartMaterialScript.InitializeMaterial();
			}
		}
	}
}
