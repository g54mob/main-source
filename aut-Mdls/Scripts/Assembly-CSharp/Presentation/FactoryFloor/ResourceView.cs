using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using Unity.Mathematics;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor
{
	public class ResourceView : MonoBehaviour, IPoolableComponent
	{
		[SerializeField]
		private MeshFilter _meshFilter;

		[SerializeField]
		private MeshRenderer _meshRenderer;

		[SerializeField]
		private ShapeMeshLibrary _shapeMeshLibrary;

		private static List<Material> _emptyList = new List<Material>();

		public Resource Resource { get; private set; }

		public void SetNonShapeResource(Resource resource)
		{
			Resource = resource;
			NonShapeResourceDataSO nonShapeResourceDataSO = resource.Data as NonShapeResourceDataSO;
			int index = UnityEngine.Random.Range(0, nonShapeResourceDataSO.MeshData.Meshes.Count);
			_meshFilter.sharedMesh = nonShapeResourceDataSO.MeshData.Meshes[index];
			_meshRenderer.SetSharedMaterials(nonShapeResourceDataSO.MeshData.MeshDatas[index].Materials);
			if (resource is IColorResource colorResource)
			{
				_meshRenderer.SetSharedMaterials(ResourceViewManager.Instance.GetSharedMaterialListForResourceColor(nonShapeResourceDataSO, colorResource.GetColor()));
			}
		}

		public void SetShapeResource(ShapeResource shapeResource, Material material)
		{
			Resource = shapeResource;
			_meshFilter.sharedMesh = _shapeMeshLibrary.GetOrCreate(shapeResource.ShapeData);
			_meshRenderer.SetSharedMaterials(_emptyList);
			_meshRenderer.sharedMaterial = material;
		}

		public void Show(bool show)
		{
			_meshRenderer.forceRenderingOff = !show;
		}

		public void Reset()
		{
			base.transform.SetPositionAndRotation(Vector3.zero, quaternion.identity);
			base.transform.localScale = Vector3.one;
			Resource = null;
		}

		public void OnReturnToPool()
		{
			_meshRenderer.forceRenderingOff = true;
		}

		public void OnRetrieveFromPool()
		{
			_meshRenderer.forceRenderingOff = false;
		}
	}
}
