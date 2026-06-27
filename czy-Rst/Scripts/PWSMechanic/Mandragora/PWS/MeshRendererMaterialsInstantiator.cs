using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Mandragora.PWS
{
	public class MeshRendererMaterialsInstantiator : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer meshRenderer;

		private Material[] materialInstances;

		public IReadOnlyList<Material> MaterialInstances
		{
			get
			{
				InstantiateMaterialsIfNeeded();
				return materialInstances ?? Array.Empty<Material>();
			}
		}

		private void Reset()
		{
			meshRenderer = GetComponentInChildren<MeshRenderer>();
		}

		private void InstantiateMaterialsIfNeeded()
		{
			if (materialInstances != null)
			{
				return;
			}
			List<Material> value;
			using (CollectionPool<List<Material>, Material>.Get(out value))
			{
				meshRenderer.GetSharedMaterials(value);
				for (int i = 0; i < value.Count; i++)
				{
					value[i] = new Material(value[i]);
				}
				materialInstances = value.ToArray();
				meshRenderer.sharedMaterials = materialInstances;
			}
		}

		private void OnDestroy()
		{
			if (materialInstances == null)
			{
				return;
			}
			Material[] array = materialInstances;
			foreach (Material material in array)
			{
				if ((bool)material)
				{
					UnityEngine.Object.Destroy(material);
				}
			}
			materialInstances = null;
		}
	}
}
