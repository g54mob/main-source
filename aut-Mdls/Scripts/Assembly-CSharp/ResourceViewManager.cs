using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Data.Variables;
using Presentation.FactoryFloor;
using UnityEngine;
using Utils;

public class ResourceViewManager : MonoBehaviour
{
	[SerializeField]
	private ResourceView _resourceViewPrefab;

	[SerializeField]
	private Material _shapeMaterial;

	[SerializeField]
	private IntVariableSO _globalUpdateMultiplier;

	private static ResourceViewManager _instance;

	private ComponentPool<ResourceView> _resourceViewPool;

	private readonly Dictionary<NonShapeResourceDataSO, ColorToMultipleMaterialLookup> _recolorableMaterialCache = new Dictionary<NonShapeResourceDataSO, ColorToMultipleMaterialLookup>();

	public static ResourceViewManager Instance => _instance;

	private void Awake()
	{
		if (_instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		_instance = this;
		_resourceViewPool = new ComponentPool<ResourceView>(500, _resourceViewPrefab, base.transform, Quaternion.identity);
	}

	public ResourceView CreateNewResourceView(Resource resource)
	{
		ResourceView component = _resourceViewPool.GetComponent();
		if (resource is ShapeResource shapeResource)
		{
			component.SetShapeResource(shapeResource, _shapeMaterial);
		}
		else
		{
			component.SetNonShapeResource(resource);
		}
		component.transform.localScale = Vector3.zero;
		return component;
	}

	public void ReturnResourceToPool(ResourceView resourceView)
	{
		if (!(resourceView == null))
		{
			resourceView.Reset();
			_resourceViewPool.ReturnMono(resourceView);
		}
	}

	public List<Material> GetSharedMaterialListForResourceColor(NonShapeResourceDataSO resourceData, Color color)
	{
		if (!_recolorableMaterialCache.ContainsKey(resourceData))
		{
			_recolorableMaterialCache.Add(resourceData, new ColorToMultipleMaterialLookup());
		}
		if (!_recolorableMaterialCache[resourceData].ContainsKey(color))
		{
			List<Material> list = new List<Material>();
			foreach (ResourceViewMeshData.ResourceMeshData meshData in resourceData.MeshData.MeshDatas)
			{
				for (int i = 0; i < meshData.ChangeColorOfMaterials.Count; i++)
				{
					if (meshData.ChangeColorOfMaterials[i])
					{
						Material material = new Material(meshData.Materials[i]);
						material.SetColor("_BaseColor", color);
						list.Add(material);
					}
					else
					{
						list.Add(meshData.Materials[i]);
					}
				}
			}
			_recolorableMaterialCache[resourceData].Add(color, list);
		}
		return _recolorableMaterialCache[resourceData][color];
	}
}
