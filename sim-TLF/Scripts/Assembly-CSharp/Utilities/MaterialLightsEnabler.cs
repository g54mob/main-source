using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities
{
	public class MaterialLightsEnabler : MonoBehaviour
	{
		[SerializeField]
		private List<MeshRenderer> _meshRenderers = new List<MeshRenderer>();

		private List<Material> _materials = new List<Material>();

		private void Awake()
		{
			foreach (MeshRenderer meshRenderer in _meshRenderers)
			{
				foreach (Material item in meshRenderer.materials.Where((Material x) => x.shader.name == "LazyEti/URP/SpotLight" || x.shader.name == "LazyEti/BIRP/SpotLight"))
				{
					_materials.Add(item);
				}
			}
		}

		public void EnabledMaterialLights(bool value)
		{
			foreach (Material material in _materials)
			{
				material.SetFloat("_TurnOff", (!value) ? 1 : 0);
			}
		}
	}
}
