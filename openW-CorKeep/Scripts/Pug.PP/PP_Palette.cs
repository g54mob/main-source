using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class PP_Palette : PP_Base
{
	private static readonly int SHADER_VARIABLE_ID_TEXTURE3D = Shader.PropertyToID("_PaletteTex");

	[Header("Must be cubic:")]
	public List<Texture2D> slices;

	private bool dirtyPalette;

	private Texture3D _palette;

	private Texture3D palette
	{
		get
		{
			return _palette;
		}
		set
		{
			_palette = value;
			dirtyPalette = true;
		}
	}

	private void Awake()
	{
		palette = UnityUtility.SlicesToCubicTexture3D(slices);
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (dirtyPalette)
		{
			base.material.SetTexture(SHADER_VARIABLE_ID_TEXTURE3D, _palette);
		}
		Graphics.Blit(source, destination, base.material);
	}
}
