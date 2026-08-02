using System;
using UnityEngine;
using UnityEngine.Events;

namespace GPUInstancerPro
{
	[Serializable]
	public class GPUIPrototype : IEquatable<GPUIPrototype>
	{
		[SerializeField]
		public GPUIPrototypeType prototypeType;

		[SerializeField]
		public GPUIProfile profile;

		[SerializeField]
		public GameObject prefabObject;

		[SerializeField]
		public GPUILODGroupData gpuiLODGroupData;

		[SerializeField]
		public Mesh prototypeMesh;

		[SerializeField]
		public Material[] prototypeMaterials;

		[SerializeField]
		public int layer;

		[SerializeField]
		public bool isGenerateBillboard;

		[SerializeField]
		public bool isBillboardReplaceLODCulled = true;

		[SerializeField]
		[Range(0f, 1f)]
		public float billboardDistance = 0.9f;

		[SerializeField]
		public GPUIBillboard billboardAsset;

		[SerializeField]
		public bool isEnabled = true;

		[SerializeField]
		[HideInInspector]
		public bool enableSkinnedMeshRendering;

		[SerializeField]
		public string name;

		[NonSerialized]
		public int errorCode;

		[NonSerialized]
		public UnityAction errorFixAction;

		private const int ERROR_CODE_ADDITION = 1000;

		private const string DEFAULT_PROTOTYPE_NAME = "[GPUIPrototype]";

		public GPUIPrototype(GameObject prefabObject, GPUIProfile profile)
		{
			prototypeType = GPUIPrototypeType.Prefab;
			this.prefabObject = prefabObject;
			this.profile = profile;
		}

		public GPUIPrototype(GPUILODGroupData gpuiLODGroupData, GPUIProfile profile)
		{
			prototypeType = GPUIPrototypeType.LODGroupData;
			this.gpuiLODGroupData = gpuiLODGroupData;
			this.profile = profile;
		}

		public GPUIPrototype(Mesh mesh, Material[] materials, GPUIProfile profile)
		{
			prototypeType = GPUIPrototypeType.MeshAndMaterial;
			prototypeMesh = mesh;
			prototypeMaterials = materials;
			this.profile = profile;
		}

		public bool IsValid(bool logError)
		{
			errorCode = 0;
			errorFixAction = null;
			if (profile == null)
			{
				profile = GPUIProfile.DefaultProfile;
			}
			switch (prototypeType)
			{
			case GPUIPrototypeType.Prefab:
				if (prefabObject == null)
				{
					if (logError)
					{
						Debug.LogError(this?.ToString() + " prefabObject is null.");
					}
					errorCode = 1001;
					return false;
				}
				break;
			case GPUIPrototypeType.LODGroupData:
				if (gpuiLODGroupData == null)
				{
					if (logError)
					{
						Debug.LogError(this?.ToString() + " gpuiLODGroupData is null.");
					}
					errorCode = 1002;
					return false;
				}
				break;
			case GPUIPrototypeType.MeshAndMaterial:
				if (prototypeMesh == null)
				{
					if (logError)
					{
						Debug.LogError(this?.ToString() + " mesh is null.");
					}
					errorCode = 1003;
					return false;
				}
				if (prototypeMaterials == null)
				{
					if (logError)
					{
						Debug.LogError(this?.ToString() + " materials is null.");
					}
					errorCode = 1004;
					return false;
				}
				break;
			}
			return true;
		}

		public bool Equals(GPUIPrototype other)
		{
			if (base.Equals(other))
			{
				return true;
			}
			if (prototypeType == GPUIPrototypeType.Prefab && other.prototypeType == GPUIPrototypeType.Prefab && prefabObject != null)
			{
				return prefabObject.Equals(other.prefabObject);
			}
			if (prototypeType == GPUIPrototypeType.LODGroupData && other.prototypeType == GPUIPrototypeType.LODGroupData && gpuiLODGroupData != null)
			{
				return gpuiLODGroupData.Equals(other.gpuiLODGroupData);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is GPUIPrototype other)
			{
				return Equals(other);
			}
			return base.Equals(obj);
		}

		public void GenerateBillboard(bool forceNew = true)
		{
			if (!isGenerateBillboard || !(prefabObject != null))
			{
				return;
			}
			if (billboardAsset == null)
			{
				billboardAsset = GPUIBillboardUtility.FindBillboardAsset(prefabObject);
				if (Application.isPlaying)
				{
					return;
				}
				if (billboardAsset == null)
				{
					billboardAsset = GPUIBillboardUtility.GenerateBillboardData(prefabObject);
				}
			}
			if (forceNew || billboardAsset.albedoAtlasTexture == null)
			{
				GPUIBillboardUtility.GenerateBillboard(billboardAsset, saveAsAsset: true);
			}
		}

		public int GetLODCount()
		{
			int num = 0;
			if (prototypeType == GPUIPrototypeType.Prefab && prefabObject != null)
			{
				num = prefabObject.GetLODCount();
				if (isGenerateBillboard)
				{
					if (billboardAsset == null)
					{
						billboardAsset = GPUIBillboardUtility.FindBillboardAsset(prefabObject);
					}
					if (billboardAsset != null)
					{
						num++;
					}
				}
			}
			else if (prototypeType == GPUIPrototypeType.LODGroupData && gpuiLODGroupData != null)
			{
				num = gpuiLODGroupData.Length;
			}
			else if (prototypeType == GPUIPrototypeType.MeshAndMaterial && prototypeMesh != null && prototypeMaterials != null && prototypeMaterials[0] != null)
			{
				num = 1;
			}
			return num;
		}

		public override int GetHashCode()
		{
			if (prototypeType == GPUIPrototypeType.Prefab && prefabObject != null)
			{
				return prefabObject.GetHashCode();
			}
			if (prototypeType == GPUIPrototypeType.LODGroupData && gpuiLODGroupData != null)
			{
				return gpuiLODGroupData.GetHashCode();
			}
			if (prototypeType == GPUIPrototypeType.MeshAndMaterial && prototypeMesh != null && prototypeMaterials != null && prototypeMaterials[0] != null)
			{
				return GPUIUtility.GenerateHash(prototypeMesh.GetHashCode(), prototypeMaterials[0].GetHashCode());
			}
			return base.GetHashCode();
		}

		public int GetKey()
		{
			if (prototypeType == GPUIPrototypeType.Prefab && prefabObject != null)
			{
				return prefabObject.GetInstanceID();
			}
			if (prototypeType == GPUIPrototypeType.LODGroupData && gpuiLODGroupData != null)
			{
				return gpuiLODGroupData.GetInstanceID();
			}
			if (prototypeType == GPUIPrototypeType.MeshAndMaterial && prototypeMesh != null && prototypeMaterials != null && prototypeMaterials[0] != null)
			{
				return GPUIUtility.GenerateHash(prototypeMesh.GetInstanceID(), prototypeMaterials[0].GetInstanceID());
			}
			return GetHashCode();
		}

		public Bounds GetBounds()
		{
			if (prototypeType == GPUIPrototypeType.Prefab && prefabObject != null)
			{
				return prefabObject.GetBounds();
			}
			if (prototypeType == GPUIPrototypeType.LODGroupData && gpuiLODGroupData != null)
			{
				return gpuiLODGroupData.bounds;
			}
			if (prototypeType == GPUIPrototypeType.MeshAndMaterial && prototypeMesh != null && prototypeMaterials != null && prototypeMaterials[0] != null)
			{
				return prototypeMesh.bounds;
			}
			return new Bounds(Vector3.zero, Vector3.one);
		}

		public override string ToString()
		{
			if (!string.IsNullOrEmpty(name))
			{
				return name;
			}
			switch (prototypeType)
			{
			case GPUIPrototypeType.Prefab:
				if (prefabObject != null)
				{
					name = prefabObject.name;
					return name;
				}
				break;
			case GPUIPrototypeType.LODGroupData:
				if (gpuiLODGroupData != null)
				{
					name = gpuiLODGroupData.ToString();
					return name;
				}
				break;
			case GPUIPrototypeType.MeshAndMaterial:
				if (prototypeMesh != null)
				{
					name = prototypeMesh.name;
					return name;
				}
				break;
			}
			return "[GPUIPrototype]";
		}
	}
}
