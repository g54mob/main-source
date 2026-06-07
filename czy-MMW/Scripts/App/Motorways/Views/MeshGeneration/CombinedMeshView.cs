using System;
using System.Collections.Generic;
using Client;
using Factory;
using Factory.Pools;
using Motorways.Constants;
using UnityEngine;

namespace Motorways.Views.MeshGeneration
{
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	public class CombinedMeshView : MonoBehaviour, IView, IReusable
	{
		public enum CombinedMeshType
		{
			Carpark = 0,
			House = 1
		}

		public class Handle
		{
			public readonly CombinedMeshType type;

			public readonly Mesh mesh;

			public readonly Matrix4x4 localToWorldMatrix;

			public readonly MeshFilter meshFilterOfCombinedMesh;

			public Handle(CombinedMeshType type, Mesh mesh, Matrix4x4 localToWorldMatrix, MeshFilter meshFilterOfCombinedMesh)
			{
				this.type = type;
				this.mesh = mesh;
				this.localToWorldMatrix = localToWorldMatrix;
				this.meshFilterOfCombinedMesh = meshFilterOfCombinedMesh;
			}
		}

		private const int MaxVertexCountPerMesh = 65535;

		[Dependency]
		private CombinedMeshMaterials _combinedMeshMaterials;

		private readonly Dictionary<CombinedMeshType, GameObject> _combinedMeshesForType = new Dictionary<CombinedMeshType, GameObject>();

		private readonly Dictionary<CombinedMeshType, MeshFilter> _currentMeshFilters = new Dictionary<CombinedMeshType, MeshFilter>();

		private MaterialPropertyBlock _materialPropertyBlock;

		private readonly Dictionary<CombinedMeshType, List<Handle>> _combinedMeshHandles = new Dictionary<CombinedMeshType, List<Handle>>();

		private int SortingLayerForMeshType(CombinedMeshType type)
		{
			return type switch
			{
				CombinedMeshType.Carpark => SortingLayer.NameToID("CarparkOutline"), 
				CombinedMeshType.House => SortingLayer.NameToID("BuildingLower"), 
				_ => SortingLayer.NameToID("Default"), 
			};
		}

		private int LayerForMeshType(CombinedMeshType type)
		{
			return type switch
			{
				CombinedMeshType.Carpark => LayerConstants.DefaultLayerId, 
				CombinedMeshType.House => LayerConstants.HeadlightOcclusionLayerId, 
				_ => LayerConstants.DefaultLayerId, 
			};
		}

		private void Awake()
		{
			foreach (CombinedMeshType value in Enum.GetValues(typeof(CombinedMeshType)))
			{
				GameObject gameObject = new GameObject($"Combined {value} Meshes");
				gameObject.gameObject.transform.parent = base.transform;
				_combinedMeshesForType.Add(value, gameObject);
			}
			_materialPropertyBlock = new MaterialPropertyBlock();
		}

		public Handle AddMesh(CombinedMeshType combinedMeshType, Mesh mesh, Matrix4x4 localToWorldMatrix)
		{
			GameObject parent = _combinedMeshesForType[combinedMeshType];
			MeshFilter meshFilter = null;
			if (_currentMeshFilters.ContainsKey(combinedMeshType))
			{
				meshFilter = _currentMeshFilters[combinedMeshType];
			}
			else
			{
				_currentMeshFilters.Add(combinedMeshType, null);
			}
			CombineInstance combineInstance = new CombineInstance
			{
				mesh = mesh,
				transform = localToWorldMatrix
			};
			CombineInstance[] combine;
			if (meshFilter == null || meshFilter.mesh.vertexCount + mesh.vertexCount > 65535)
			{
				meshFilter = CreateGameObjectForCombinedMesh(parent, combinedMeshType);
				combine = new CombineInstance[1] { combineInstance };
				_currentMeshFilters[combinedMeshType] = meshFilter;
			}
			else
			{
				CombineInstance combineInstance2 = new CombineInstance
				{
					mesh = meshFilter.mesh,
					transform = meshFilter.transform.localToWorldMatrix
				};
				combine = new CombineInstance[2] { combineInstance2, combineInstance };
			}
			Mesh mesh2 = new Mesh();
			mesh2.CombineMeshes(combine);
			meshFilter.mesh = mesh2;
			if (!_combinedMeshHandles.ContainsKey(combinedMeshType))
			{
				_combinedMeshHandles[combinedMeshType] = new List<Handle>();
			}
			Handle handle = new Handle(combinedMeshType, mesh, localToWorldMatrix, meshFilter);
			_combinedMeshHandles[combinedMeshType].Add(handle);
			return handle;
		}

		private MeshFilter CreateGameObjectForCombinedMesh(GameObject parent, CombinedMeshType combinedMeshType)
		{
			GameObject obj = new GameObject($"Combined {combinedMeshType} Mesh");
			obj.transform.parent = parent.transform;
			MeshFilter result = obj.AddComponent<MeshFilter>();
			MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
			meshRenderer.sharedMaterial = _combinedMeshMaterials.vertexColorMaterial;
			meshRenderer.sortingLayerID = SortingLayerForMeshType(combinedMeshType);
			meshRenderer.gameObject.layer = LayerForMeshType(combinedMeshType);
			if (combinedMeshType == CombinedMeshType.House)
			{
				meshRenderer.GetPropertyBlock(_materialPropertyBlock);
				_materialPropertyBlock.SetFloat(ShaderConstants.MotorwayIdShaderId, 0f);
				_materialPropertyBlock.SetFloat(ShaderConstants.HeadlightOcclusionTypeId, ShaderConstants.HeadlightNonVehicleOcclusionTypeId);
				meshRenderer.SetPropertyBlock(_materialPropertyBlock);
			}
			return result;
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void Reset()
		{
			foreach (GameObject value in _combinedMeshesForType.Values)
			{
				foreach (Transform item in value.transform)
				{
					GameObject obj = item.gameObject;
					obj.SetActive(value: false);
					UnityEngine.Object.Destroy(obj);
				}
			}
			_currentMeshFilters.Clear();
			_combinedMeshHandles.Clear();
		}

		public void RemoveMesh(Handle meshToRemove)
		{
			if (meshToRemove == null || !_combinedMeshHandles.TryGetValue(meshToRemove.type, out var value))
			{
				return;
			}
			value.Remove(meshToRemove);
			if (value.Count == 0)
			{
				GameObject obj = meshToRemove.meshFilterOfCombinedMesh.gameObject;
				obj.SetActive(value: false);
				UnityEngine.Object.Destroy(obj);
				return;
			}
			Mesh mesh = new Mesh();
			CombineInstance[] array = new CombineInstance[value.Count];
			int num = 0;
			foreach (Handle item in value)
			{
				CombineInstance combineInstance = new CombineInstance
				{
					mesh = item.mesh,
					transform = item.localToWorldMatrix
				};
				array[num] = combineInstance;
				num++;
			}
			mesh.CombineMeshes(array);
			meshToRemove.meshFilterOfCombinedMesh.mesh = mesh;
		}
	}
}
