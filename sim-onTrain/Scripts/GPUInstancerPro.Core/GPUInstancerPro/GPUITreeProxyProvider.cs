using UnityEngine;
using UnityEngine.Rendering;

namespace GPUInstancerPro
{
	public class GPUITreeProxyProvider : GPUIDataProvider<int, MeshRenderer>
	{
		public override void Dispose()
		{
			if (_dataDict != null)
			{
				foreach (MeshRenderer value in base.Values)
				{
					if (value != null)
					{
						value.gameObject.DestroyGeneric();
					}
				}
			}
			base.Dispose();
		}

		public void GetMaterialPropertyBlock(GPUILODGroupData lgd, GPUICameraData cameraData, MaterialPropertyBlock mpb)
		{
			MeshRenderer meshRenderer = AddOrGetTreeProxy(lgd.prototype.prefabObject, cameraData);
			if (!(meshRenderer == null))
			{
				meshRenderer.GetPropertyBlock(mpb);
			}
		}

		private MeshRenderer AddOrGetTreeProxy(GameObject treePrefab, GPUICameraData cameraData)
		{
			if (!Application.isPlaying)
			{
				return null;
			}
			int key = GPUIUtility.GenerateHash(treePrefab.GetInstanceID(), cameraData.ActiveCamera.GetInstanceID());
			if (!_dataDict.ContainsKey(key) || _dataDict[key] == null)
			{
				MeshRenderer meshRenderer = AddTreeProxy(treePrefab, cameraData.ActiveCamera.transform);
				if (meshRenderer != null)
				{
					AddOrSet(key, meshRenderer);
				}
				return meshRenderer;
			}
			return _dataDict[key];
		}

		private static MeshRenderer AddTreeProxy(GameObject treePrefab, Transform parentTransform)
		{
			Shader shader = GPUIUtility.FindShader("Hidden/GPUInstancerPro/Nature/TreeProxy");
			if (shader == null)
			{
				Debug.LogError("Can not find GPUI Pro Tree Proxy shader! Make sure the shader is included in build: Hidden/GPUInstancerPro/Nature/TreeProxy");
				return null;
			}
			Mesh mesh = new Mesh();
			mesh.name = "TreeProxyMesh";
			Material[] proxyMaterials = new Material[1]
			{
				new Material(shader)
			};
			LODGroup component = treePrefab.GetComponent<LODGroup>();
			if (component != null)
			{
				return InstantiateTreeProxyObject(component.GetLODs()[0].renderers[0].gameObject, parentTransform, proxyMaterials, mesh);
			}
			return InstantiateTreeProxyObject(treePrefab.GetComponent<Tree>().gameObject, parentTransform, proxyMaterials, mesh);
		}

		private static MeshRenderer InstantiateTreeProxyObject(GameObject treePrefab, Transform parentTransform, Material[] proxyMaterials, Mesh proxyMesh)
		{
			GameObject gameObject = Object.Instantiate(treePrefab, parentTransform);
			gameObject.hideFlags = HideFlags.DontSave;
			gameObject.name = treePrefab.name + "_GPUITreeProxy";
			proxyMesh.bounds = gameObject.GetComponent<MeshFilter>().sharedMesh.bounds;
			MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
			component.shadowCastingMode = ShadowCastingMode.Off;
			component.receiveShadows = false;
			component.lightProbeUsage = LightProbeUsage.Off;
			for (int i = 0; i < proxyMaterials.Length; i++)
			{
				proxyMaterials[i].CopyPropertiesFromMaterial(component.sharedMaterials[i]);
				proxyMaterials[i].enableInstancing = true;
			}
			component.sharedMaterials = proxyMaterials;
			component.GetComponent<MeshFilter>().sharedMesh = proxyMesh;
			StripComponents(gameObject);
			return component;
		}

		private static void StripComponents(GameObject go)
		{
			Component[] components = go.GetComponents(typeof(Component));
			foreach (Component component in components)
			{
				if (!(component is Transform) && !(component is MeshFilter) && !(component is MeshRenderer) && !(component is Tree))
				{
					component.DestroyGeneric();
				}
			}
		}
	}
}
