using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public abstract class RendererUpdater : VFXUpdater
	{
		[SerializeField]
		protected Renderer Renderer;

		private Material[] _materials;

		protected IEnumerable<Material> Materials
		{
			get
			{
				if (_materials == null)
				{
					_materials = Renderer.materials;
				}
				return _materials;
			}
		}

		protected void MaterialLoop()
		{
			foreach (Material material in Materials)
			{
				ForEachMaterial(material);
			}
		}

		protected virtual void ForEachMaterial(Material material)
		{
		}
	}
}
