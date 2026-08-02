using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate
{
	public class MaterialChanger : MonoBehaviour
	{
		protected struct RendererSetup
		{
			public MeshRenderer Renderer;

			public int Id;
		}

		protected struct MaterialSetup
		{
			public Material[] DefaultMaterials;

			public Material[] MaterialsWithEffects;
		}

		[SerializeField]
		private bool m_EnableOutline;

		[SerializeField]
		private bool m_EnableHighlight;

		[Space]
		[SerializeField]
		private string m_OutlineWidthProperty = "_ASEOutlineWidth";

		[SerializeField]
		[Range(-1f, 1f)]
		private float m_OutlineWidth = 0.0065f;

		[SerializeField]
		private string m_HighlightStrengthProperty = "_LineTransparency";

		private static Dictionary<int, MaterialSetup> m_Materials = new Dictionary<int, MaterialSetup>();

		private RendererSetup[] m_Renderers;

		public void SetDefaultMaterial()
		{
			SetMaterials(withEffects: false);
		}

		public void SetMaterialWithEffects()
		{
			SetMaterials(withEffects: true);
		}

		private void Awake()
		{
			SetupMaterials();
			SetMaterials(withEffects: false);
		}

		private void SetMaterials(bool withEffects)
		{
			if (m_Renderers == null)
			{
				return;
			}
			RendererSetup[] renderers = m_Renderers;
			for (int i = 0; i < renderers.Length; i++)
			{
				RendererSetup rendererSetup = renderers[i];
				if (m_Materials.TryGetValue(rendererSetup.Id, out var value))
				{
					rendererSetup.Renderer.materials = (withEffects ? value.MaterialsWithEffects : value.DefaultMaterials);
				}
			}
		}

		private void SetupMaterials()
		{
			MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			if (componentsInChildren.Length == 0)
			{
				return;
			}
			m_Renderers = new RendererSetup[componentsInChildren.Length];
			int num = 0;
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				int num2 = CalculateRendererId(meshRenderer);
				if (!m_Materials.ContainsKey(num2))
				{
					Material[] array2 = new Material[meshRenderer.sharedMaterials.Length];
					Material[] array3 = new Material[meshRenderer.sharedMaterials.Length];
					int num3 = 0;
					Material[] sharedMaterials = meshRenderer.sharedMaterials;
					for (int j = 0; j < sharedMaterials.Length; j++)
					{
						Material material = (array2[num3] = sharedMaterials[j]);
						if (m_EnableOutline || m_EnableHighlight)
						{
							Material material2 = new Material(material);
							material2.name += "_WithEffects";
							material2.SetFloat(m_OutlineWidthProperty, m_EnableOutline ? m_OutlineWidth : 0f);
							material2.SetFloat(m_HighlightStrengthProperty, m_EnableHighlight ? 1f : 0f);
							array3[num3] = material2;
						}
						else
						{
							array3[num3] = material;
						}
						num3++;
					}
					m_Materials.Add(num2, new MaterialSetup
					{
						DefaultMaterials = array2,
						MaterialsWithEffects = array3
					});
				}
				m_Renderers[num] = new RendererSetup
				{
					Renderer = meshRenderer,
					Id = num2
				};
				num++;
			}
		}

		private int CalculateRendererId(Renderer renderer)
		{
			int num = 0;
			Material[] sharedMaterials = renderer.sharedMaterials;
			foreach (Material material in sharedMaterials)
			{
				if (!(material == null))
				{
					num += material.GetHashCode() / 2;
				}
			}
			return num;
		}
	}
}
