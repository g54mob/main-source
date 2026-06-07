using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DV.VFX
{
	public class EmissionToggler : MonoBehaviour
	{
		[Header("Components")]
		public MeshRenderer[] renderers;

		public Material[] materials;

		[Header("Material settings")]
		public string keyword = "_EMISSION";

		public bool setInitialState;

		public bool initialState;

		private Material[][] instantiatedMaterials;

		private void Awake()
		{
			instantiatedMaterials = new Material[renderers.Length][];
			for (int r = 0; r < instantiatedMaterials.Length; r++)
			{
				List<Material> list = new List<Material>();
				int m;
				for (m = 0; m < renderers[r].materials.Length; m++)
				{
					if (materials.Any((Material mat) => (mat.name == renderers[r].materials[m].name || mat.name + " (Instance)" == renderers[r].materials[m].name) && mat.shader.name == renderers[r].materials[m].shader.name))
					{
						list.Add(renderers[r].materials[m]);
					}
				}
				instantiatedMaterials[r] = list.ToArray();
			}
			if (setInitialState)
			{
				SetEmissionEnabled(initialState);
			}
		}

		public void SetEmissionEnabled(bool on)
		{
			for (int i = 0; i < renderers.Length; i++)
			{
				for (int j = 0; j < instantiatedMaterials[i].Length; j++)
				{
					if (on)
					{
						instantiatedMaterials[i][j].EnableKeyword(keyword);
					}
					else
					{
						instantiatedMaterials[i][j].DisableKeyword(keyword);
					}
				}
			}
		}

		public void EnableEmission()
		{
			SetEmissionEnabled(on: true);
		}

		public void DisableEmission()
		{
			SetEmissionEnabled(on: false);
		}
	}
}
