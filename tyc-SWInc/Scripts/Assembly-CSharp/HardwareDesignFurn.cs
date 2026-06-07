using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityMeshSimplifier;

public class HardwareDesignFurn : MonoBehaviour, IFurnitureSerialization
{
	public class HardwareFurnInstance
	{
		private static MeshSimplifier _simplifier = new MeshSimplifier();

		public uint ProductID;

		public uint AddonID;

		public float WorldScale;

		public float Price;

		public string Name;

		[NonSerialized]
		public Mesh Mesh;

		[NonSerialized]
		public Mesh LODMesh;

		[NonSerialized]
		public Mesh LOD2Mesh;

		[NonSerialized]
		public Material Mat;

		public byte[] Data;

		[NonSerialized]
		public int Count;

		public HardwareFurnInstance()
		{
		}

		public HardwareFurnInstance(uint productId, uint addonId, float price, string name, byte[] data)
		{
			Data = data;
			ProductID = productId;
			AddonID = addonId;
			Price = price;
			Name = name;
		}

		public bool LoadData()
		{
			HardwareDesignInstance hardwareDesignInstance = HardwareDesignInstance.Deserialize(Data, 9);
			if (hardwareDesignInstance == null)
			{
				return false;
			}
			WorldScale = hardwareDesignInstance.Design.WorldScale;
			Mat = hardwareDesignInstance.Mat;
			List<Mesh> list = new List<Mesh>();
			List<CombineInstance> list2 = new List<CombineInstance>();
			bool flag = true;
			Mesh mesh = null;
			Renderer rend = null;
			Matrix4x4 value = Matrix4x4.identity;
			int num = 0;
			MeshFilter[] componentsInChildren = hardwareDesignInstance.GetComponentsInChildren<MeshFilter>();
			foreach (MeshFilter meshFilter in componentsInChildren)
			{
				MeshRenderer component = meshFilter.GetComponent<MeshRenderer>();
				if (flag)
				{
					mesh = meshFilter.sharedMesh;
					rend = component;
					value = meshFilter.transform.localToWorldMatrix;
				}
				flag = false;
				list2.Add(new CombineInstance
				{
					mesh = FixMesh(meshFilter.sharedMesh, component, list, null, false),
					transform = meshFilter.transform.localToWorldMatrix
				});
				num++;
			}
			SkinnedMeshRenderer[] componentsInChildren2 = hardwareDesignInstance.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
			{
				Mesh mesh2 = new Mesh();
				skinnedMeshRenderer.BakeMesh(mesh2);
				if (flag)
				{
					mesh = mesh2;
					value = skinnedMeshRenderer.transform.localToWorldMatrix;
				}
				flag = false;
				FixMesh(mesh2, skinnedMeshRenderer, list, null, true);
				list2.Add(new CombineInstance
				{
					mesh = mesh2,
					transform = skinnedMeshRenderer.transform.localToWorldMatrix
				});
				list.Add(mesh2);
				num++;
			}
			Mesh = new Mesh();
			Mesh.CombineMeshes(list2.ToArray());
			_simplifier.Initialize(Mesh);
			_simplifier.SimplifyMeshLossless();
			Mesh mesh3 = _simplifier.ToMesh();
			UnityEngine.Object.Destroy(Mesh);
			Mesh = mesh3;
			if (num == 1)
			{
				_simplifier.Initialize(Mesh);
				_simplifier.SimplifyMesh(0.5f);
				LODMesh = _simplifier.ToMesh();
				_simplifier.Initialize(LODMesh);
				_simplifier.SimplifyMesh(0.25f);
				LOD2Mesh = ((_simplifier.Vertices.Length >= LODMesh.vertexCount) ? LODMesh : _simplifier.ToMesh());
			}
			else
			{
				Mesh mesh4 = FixMesh(mesh, rend, list, value, false);
				_simplifier.Initialize(mesh4);
				_simplifier.SimplifyMeshLossless();
				LODMesh = _simplifier.ToMesh();
				_simplifier.Initialize(LODMesh);
				_simplifier.SimplifyMesh(0.25f);
				LOD2Mesh = _simplifier.ToMesh();
			}
			Mesh.name = "Main";
			LOD2Mesh.name = "LOD2";
			LODMesh.name = "LOD1";
			list.ForEach(delegate(Mesh x)
			{
				UnityEngine.Object.Destroy(x);
			});
			UnityEngine.Object.Destroy(hardwareDesignInstance.gameObject);
			return true;
		}

		public void Clear()
		{
			UnityEngine.Object.Destroy(Mesh);
			if (LODMesh != null)
			{
				UnityEngine.Object.Destroy(LODMesh);
			}
			if (LOD2Mesh != null)
			{
				UnityEngine.Object.Destroy(LOD2Mesh);
			}
			UnityEngine.Object.Destroy(Mat);
		}

		private Mesh FixMesh(Mesh mesh, Renderer rend, List<Mesh> tempMesh, Matrix4x4? transform, bool isNew)
		{
			bool flag = false;
			if (rend != null && rend.HasPropertyBlock())
			{
				flag = true;
				if (!isNew)
				{
					mesh = mesh.Duplicate();
					if (tempMesh != null)
					{
						tempMesh.Add(mesh);
					}
				}
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				rend.GetPropertyBlock(materialPropertyBlock);
				Vector4 vector = materialPropertyBlock.GetVector("_MainTex_ST");
				mesh.uv = mesh.uv.SelectInPlace((Vector2 x) => new Vector2(x.x + vector.z, x.y + vector.w));
			}
			if (transform.HasValue)
			{
				if (!flag && !isNew)
				{
					mesh = mesh.Duplicate();
					if (tempMesh != null)
					{
						tempMesh.Add(mesh);
					}
				}
				mesh.vertices = mesh.vertices.SelectInPlace((Vector3 x) => transform.Value.MultiplyPoint(x));
				mesh.normals = mesh.normals.SelectInPlace((Vector3 x) => transform.Value.MultiplyVector(x));
				mesh.tangents = mesh.tangents.SelectInPlace((Vector4 x) => transform.Value.MultiplyVector(x.ToVector3()).ToVector4(x.w));
				mesh.RecalculateBounds();
			}
			return mesh;
		}
	}

	public Furniture Furn;

	public MeshRenderer Renderer;

	public MeshFilter Filter;

	public Transform Stand;

	public LODFurn LOD;

	public BoxCollider Coll;

	[NonSerialized]
	public uint ProductID;

	[NonSerialized]
	public uint AddonID;

	private void Start()
	{
		if (ProductID == 0)
		{
			List<IDisplayable> display = new List<IDisplayable>();
			display.AddRange(from x in MarketSimulation.Active.GetAllProducts(false)
				where x.HardwareDesign != null
				select x);
			display.AddRange(MarketSimulation.Active.AddOnProducts.Where((AddOnProduct x) => x.HardwareDesign != null));
			if (display.Count == 0)
			{
				Furn.DestroyGO();
				return;
			}
			WindowManager.Instance.MultiWindow.Show("HardwareDesign", display.Select((IDisplayable x) => x.GetName() + " (" + x.Manufacturing.GetPrettyName() + ")"), delegate(int x)
			{
				Init(display[x]);
			}, false, true, true, false, null, null, delegate
			{
				Furn.DestroyGO();
			}, false);
		}
		else if (Filter.sharedMesh == null)
		{
			HardwareFurnInstance hardwareFurnInstance = GameSettings.Instance.GetHardwareFurnInstance(ProductID, AddonID, null);
			if (hardwareFurnInstance != null)
			{
				SetInstance(hardwareFurnInstance);
				Furn.UpdateLOD();
			}
			else
			{
				Furn.DestroyGO();
			}
		}
	}

	public void Serialize(WriteDictionary dict)
	{
		dict["HardwareDesignFurnProduct"] = ProductID;
		dict["HardwareDesignFurnAddon"] = AddonID;
	}

	public void Deserialize(WriteDictionary dict, bool loading)
	{
		ProductID = dict.Get("HardwareDesignFurnProduct", 0u);
		AddonID = dict.Get("HardwareDesignFurnAddon", 0u);
	}

	private void OnDestroy()
	{
		if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.GetHardwareFurnInstance(ProductID, AddonID, null) != null)
		{
			GameSettings.Instance.CountHardwareFurnInstance(ProductID, AddonID, false);
		}
	}

	private void FixFurniture(HardwareFurnInstance instance)
	{
		Furn.NameOverride = instance.Name;
		Filter.sharedMesh = instance.Mesh;
		Renderer.sharedMaterial = instance.Mat;
		LOD.LOD0 = instance.Mesh;
		LOD.LOD1 = instance.LODMesh;
		LOD.LOD2 = instance.LOD2Mesh;
		Bounds bounds = Filter.sharedMesh.bounds;
		float num = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
		float num2 = 1f / num * instance.WorldScale;
		Filter.transform.localScale = Vector3.one * num2;
		Filter.transform.localPosition = -bounds.center * num2;
		Quaternion quaternion = Quaternion.identity;
		float num3 = num2 * bounds.size.z;
		if ((double)bounds.size.z > (double)bounds.size.y * 1.5)
		{
			quaternion = Quaternion.Euler(-90f, 0f, 0f) * quaternion;
			num3 = num2 * bounds.size.y;
		}
		else if ((double)bounds.size.z > (double)bounds.size.x * 1.5)
		{
			quaternion = Quaternion.Euler(0f, 90f, 0f) * quaternion;
			num3 = num2 * bounds.size.x;
		}
		quaternion = Quaternion.Euler(25f, 180f, 0f) * quaternion;
		Filter.transform.localRotation = quaternion;
		float num4 = Renderer.bounds.size.y * 0.5f;
		Filter.transform.localPosition += Vector3.up * num4;
		Stand.localScale = Vector3.one * instance.WorldScale * 0.5f;
		Stand.localPosition = new Vector3(0f, 0f, (0f - num3) / 4f);
		float worldScale = instance.WorldScale;
		Coll.size = Vector3.one * worldScale;
		Furn.Height2 = worldScale;
		worldScale /= 2f;
		Coll.center = new Vector3(0f, worldScale, 0f);
		Furn.SurfaceSnapRadius = worldScale;
		Furn.BuildBoundary = new Vector2[4]
		{
			new Vector2(worldScale, 0f - worldScale),
			new Vector2(worldScale, worldScale),
			new Vector2(0f - worldScale, worldScale),
			new Vector2(0f - worldScale, 0f - worldScale)
		};
		Furn.UpdateBoundaryPoints();
		Furn.Cost = instance.Price;
	}

	public void Init(IDisplayable display)
	{
		SoftwareProduct softwareProduct;
		AddOnProduct addOnProduct;
		if ((softwareProduct = display as SoftwareProduct) != null)
		{
			ProductID = softwareProduct.ID;
			AddonID = 0u;
		}
		else if ((addOnProduct = display as AddOnProduct) != null)
		{
			ProductID = addOnProduct.Parent.ID;
			AddonID = addOnProduct.ID;
		}
		SetInstance(GameSettings.Instance.GetHardwareFurnInstance(ProductID, AddonID, display));
	}

	public void SetInstance(HardwareFurnInstance instance)
	{
		GameSettings.Instance.CountHardwareFurnInstance(ProductID, AddonID, true);
		FixFurniture(instance);
	}

	public void PostDeserialize()
	{
	}
}
