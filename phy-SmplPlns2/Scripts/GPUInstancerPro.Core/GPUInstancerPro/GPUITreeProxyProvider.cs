using UnityEngine;
using UnityEngine.Rendering;

namespace GPUInstancerPro
{
	public class GPUITreeProxyProvider : GPUIDataProvider<int, MeshRenderer>
	{
		private Transform _treeProxyParent;

		public override void Dispose()
		{
			if (_dataDict != null)
			{
				foreach (MeshRenderer value in base.Values)
				{
					if (!(value != null))
					{
						continue;
					}
					Material sharedMaterial = value.sharedMaterial;
					if (sharedMaterial != null)
					{
						sharedMaterial.DestroyGeneric();
					}
					if (value.gameObject.TryGetComponent<MeshFilter>(out var component))
					{
						Mesh sharedMesh = component.sharedMesh;
						if (sharedMesh != null)
						{
							sharedMesh.DestroyGeneric();
						}
					}
					value.gameObject.DestroyGeneric();
				}
			}
			_treeProxyParent.DestroyGeneric();
			base.Dispose();
		}

		public void SetTreeProxyPosition(Vector3 position)
		{
			if (_treeProxyParent != null)
			{
				_treeProxyParent.position = position;
			}
		}

		public void GetMaterialPropertyBlock(GPUILODGroupData lgd, MaterialPropertyBlock mpb)
		{
			MeshRenderer meshRenderer = AddOrGetTreeProxy(lgd.prototype.prefabObject);
			if (!(meshRenderer == null))
			{
				meshRenderer.GetPropertyBlock(mpb);
			}
		}

		private MeshRenderer AddOrGetTreeProxy(GameObject treePrefab)
		{
			if (!Application.isPlaying)
			{
				return null;
			}
			int key = GPUIUtility.GenerateHash(treePrefab.GetInstanceID());
			if (!_dataDict.TryGetValue(key, out var value) || value == null)
			{
				if (_treeProxyParent == null)
				{
					_treeProxyParent = new GameObject("GPUI Tree Proxy").transform;
				}
				value = AddTreeProxy(treePrefab, _treeProxyParent);
				if (value != null)
				{
					AddOrSet(key, value);
				}
			}
			return value;
		}

		private static MeshRenderer AddTreeProxy(GameObject treePrefab, Transform parentTransform)
		{
			Shader shader = GPUIUtility.FindShader("Hidden/GPUInstancerPro/Nature/TreeProxy");
			if (shader == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find GPUI Pro Tree Proxy shader! Make sure the shader is included in build: Hidden/GPUInstancerPro/Nature/TreeProxy");
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
				LOD[] lODs = component.GetLODs();
				for (int i = 0; i < lODs.Length; i++)
				{
					for (int j = 0; j < lODs[i].renderers.Length; j++)
					{
						GameObject gameObject = lODs[i].renderers[j].gameObject;
						if (gameObject.HasComponent<Tree>() && gameObject.HasComponent<MeshRenderer>() && gameObject.HasComponent<MeshFilter>())
						{
							return InstantiateTreeProxyObject(gameObject, parentTransform, proxyMaterials, mesh);
						}
					}
				}
			}
			Tree componentInChildren = treePrefab.GetComponentInChildren<Tree>();
			if (componentInChildren != null)
			{
				return InstantiateTreeProxyObject(componentInChildren.gameObject, parentTransform, proxyMaterials, mesh);
			}
			MeshRenderer componentInChildren2 = treePrefab.GetComponentInChildren<MeshRenderer>();
			if (componentInChildren2 != null)
			{
				return InstantiateTreeProxyObject(componentInChildren2.gameObject, parentTransform, proxyMaterials, mesh);
			}
			return null;
		}

		private static MeshRenderer InstantiateTreeProxyObject(GameObject treePrefab, Transform parentTransform, Material[] proxyMaterials, Mesh proxyMesh)
		{
			if (!treePrefab.HasComponent<MeshFilter>() || !treePrefab.HasComponent<MeshRenderer>())
			{
				return null;
			}
			GameObject gameObject = Object.Instantiate(treePrefab, parentTransform);
			gameObject.hideFlags = HideFlags.DontSave;
			gameObject.name = treePrefab.name + "_GPUITreeProxy";
			gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			gameObject.transform.localScale = Vector3.one;
			proxyMesh.bounds = gameObject.GetComponent<MeshFilter>().sharedMesh.bounds;
			MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
			component.shadowCastingMode = ShadowCastingMode.Off;
			component.receiveShadows = false;
			component.lightProbeUsage = LightProbeUsage.Off;
			component.enabled = true;
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
			foreach (Transform item in go.transform)
			{
				item.gameObject.DestroyGeneric();
			}
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
