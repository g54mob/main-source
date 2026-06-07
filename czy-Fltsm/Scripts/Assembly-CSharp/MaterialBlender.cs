using System;
using UnityEngine;

[Serializable]
public class MaterialBlender : Blender<Material, BlenableMaterial>
{
	[SerializeField]
	private Renderer _renderer;

	[SerializeField]
	[Tooltip("List of textures that should set when the Blender is activated. Names are prefixed with '_' and PascalCase (e.g. 'Surface 1' becomes '_Surface1', 'Normal Map 1' becomes '_NormalMap1')")]
	private string[] _texturesToSwap;

	public void Enable()
	{
		if (!base.Blendables.IsNullOrEmpty() && !_texturesToSwap.IsNullOrEmpty())
		{
			Material target = base.Blendables[0].Target;
			string[] texturesToSwap = _texturesToSwap;
			foreach (string name in texturesToSwap)
			{
				_renderer.material.SetTexture(name, target.GetTexture(name));
			}
		}
	}

	protected override void Blend(Material from, Material to, float blendProgress)
	{
		_renderer.material.Lerp(from, to, blendProgress);
	}
}
