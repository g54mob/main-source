using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectsAndMatricesData
{
	public int ID;

	public GameObject PrefabRef;

	public Material Material;

	public Mesh Mesh;

	public List<Matrix4x4> TransformMatrices;

	public ComputeBuffer TransformBuffer;

	public int LayerMask;

	[SerializeField]
	private RenderParams _renderParams;

	public RenderParams RenderParams
	{
		get
		{
			if (_renderParams.material == null)
			{
				_renderParams = new RenderParams(Material);
				_renderParams.layer = LayerMask;
			}
			return _renderParams;
		}
		set
		{
			_renderParams = value;
		}
	}

	public ObjectsAndMatricesData(GameObject prefab, Material mat, Mesh mesh, LayerMask layerMask, int id)
	{
		PrefabRef = prefab;
		Material = new Material(mat);
		Mesh = mesh;
		LayerMask = layerMask;
		ID = id;
	}

	public ObjectsAndMatricesData(ObjectsAndMatricesData data, int id)
	{
		PrefabRef = data.PrefabRef;
		Material = new Material(data.Material);
		Mesh = data.Mesh;
		LayerMask = data.LayerMask;
		ID = id;
		TransformMatrices = new List<Matrix4x4>();
	}

	public override bool Equals(object obj)
	{
		return ID == ((ObjectsAndMatricesData)obj).ID;
	}

	public override int GetHashCode()
	{
		return ID;
	}
}
