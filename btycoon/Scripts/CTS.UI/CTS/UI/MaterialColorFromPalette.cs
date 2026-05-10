using System;
using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	public class MaterialColorFromPalette : CTSBehaviour
	{
		[Serializable]
		private struct ColorData
		{
			public ShaderVariable VariableName;

			public PaletteData Color;
		}

		[SerializeField]
		[Inject(false)]
		private MaterialReference _materialInstance;

		[SerializeField]
		private ColorData[] _colorChanges;

		protected override void OnAwake()
		{
			base.OnAwake();
			ColorData[] colorChanges = _colorChanges;
			for (int i = 0; i < colorChanges.Length; i++)
			{
				ColorData colorData = colorChanges[i];
				_materialInstance.MaterialInstance.SetColor((int)colorData.VariableName, colorData.Color.GetColor());
			}
		}
	}
}
