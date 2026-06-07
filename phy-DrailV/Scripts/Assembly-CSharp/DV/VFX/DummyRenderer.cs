using System.Collections.Generic;
using UnityEngine;

namespace DV.VFX
{
	public class DummyRenderer : MonoBehaviour
	{
		private Transform rootTransform;

		private readonly Dictionary<Renderer, Renderer> templateToReplicated = new Dictionary<Renderer, Renderer>();

		private readonly List<Renderer> lodRenderersBuilder = new List<Renderer>();

		public void Recreate(Transform template)
		{
			Clear();
			if (!(template == null))
			{
				Build(template, out rootTransform);
				rootTransform.SetParent(base.transform);
				rootTransform.localScale = template.localScale;
				rootTransform.localRotation = Quaternion.identity;
				rootTransform.localPosition = Vector3.zero;
				templateToReplicated.Clear();
			}
		}

		public void Clear()
		{
			templateToReplicated.Clear();
			if (rootTransform != null)
			{
				Object.Destroy(rootTransform.gameObject);
			}
			rootTransform = null;
		}

		private bool Build(Transform template, out Transform created)
		{
			GameObject me = null;
			foreach (Transform item in template)
			{
				if (item.gameObject.activeSelf && Build(item, out var created2))
				{
					Create();
					created2.SetParent(me.transform);
					created2.localScale = item.localScale;
					created2.localRotation = item.localRotation;
					created2.localPosition = item.localPosition;
				}
			}
			if (template.TryGetComponent<MeshRenderer>(out var component))
			{
				Create();
				me.AddComponent<MeshFilter>().sharedMesh = template.GetComponent<MeshFilter>().sharedMesh;
				MeshRenderer meshRenderer = me.AddComponent<MeshRenderer>();
				meshRenderer.sharedMaterials = component.sharedMaterials;
				meshRenderer.shadowCastingMode = component.shadowCastingMode;
				meshRenderer.receiveShadows = component.receiveShadows;
				templateToReplicated.Add(component, meshRenderer);
			}
			if (template.TryGetComponent<LODGroup>(out var component2))
			{
				LODGroup lODGroup = me.AddComponent<LODGroup>();
				lODGroup.animateCrossFading = component2.animateCrossFading;
				lODGroup.fadeMode = component2.fadeMode;
				LOD[] lODs = component2.GetLODs();
				for (int i = 0; i < lODs.Length; i++)
				{
					lodRenderersBuilder.Clear();
					for (int j = 0; j < lODs[i].renderers.Length; j++)
					{
						if (templateToReplicated.TryGetValue(lODs[i].renderers[j], out var value))
						{
							lodRenderersBuilder.Add(value);
						}
					}
					lODs[i].renderers = lodRenderersBuilder.ToArray();
					lodRenderersBuilder.Clear();
				}
				lODGroup.SetLODs(lODs);
			}
			created = ((me != null) ? me.transform : null);
			return created != null;
			void Create()
			{
				if (me == null)
				{
					me = new GameObject(template.gameObject.name);
				}
			}
		}
	}
}
