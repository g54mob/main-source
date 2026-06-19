using System;
using Pug.RP;
using UnityEngine;

namespace PugMod
{
	public class ModAPIRendering : IRendering
	{
		public Vector3 RenderOffset => -Manager.camera.RenderOrigo;

		public PugCamera GameCamera => Manager.camera.gameCamera.GetComponent<PugCamera>();

		public PugCamera UICamera => Manager.camera.uiCamera.GetComponent<PugCamera>();

		public Material GetMaterial(string name)
		{
			MaterialSwapTable materialSwapTable = Resources.Load<MaterialSwapTable>("ModSDK/MaterialSwapTable");
			if (materialSwapTable == null)
			{
				return null;
			}
			foreach (MaterialSwapTable.SwapEntry material in materialSwapTable.materials)
			{
				if (material.materialName.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return material.materialToSwapTo;
				}
			}
			return null;
		}
	}
}
