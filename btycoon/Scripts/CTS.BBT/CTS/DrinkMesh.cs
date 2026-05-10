using CTS.Core;
using CTS.Core.Pooling;
using UnityEngine;

namespace CTS
{
	[Constructor("Construct")]
	public class DrinkMesh : CTSBehaviour, IPoolable
	{
		private Material[] _originalMaterials;

		[field: InjectScope(EGetScope.Children)]
		[field: SerializeField]
		[field: Inject(false)]
		public MeshRenderer Renderer { get; private set; }

		PoolGuid IPoolable.PoolGuid { get; set; }

		public bool IsMaterialOverriden { get; private set; }

		private void Construct([InjectScope(EGetScope.Children)] MeshRenderer rend)
		{
			_originalMaterials = rend.materials;
			rend.materials = _originalMaterials;
		}

		public void SetOverrideMaterial(Material material)
		{
			if (material == null)
			{
				if (IsMaterialOverriden)
				{
					IsMaterialOverriden = false;
					Renderer.materials = _originalMaterials;
				}
				return;
			}
			IsMaterialOverriden = true;
			Material[] materials = Renderer.materials;
			for (int i = 0; i < materials.Length; i++)
			{
				materials[i] = material;
			}
			Renderer.materials = materials;
		}
	}
}
