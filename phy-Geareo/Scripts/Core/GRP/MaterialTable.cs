using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.ImUI;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/MaterialTable", fileName = "MaterialTable")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class MaterialTable : ScriptableObject
	{
		public List<MaterialRowConfig> _rows;

		public List<string> GetNames()
		{
			return null;
		}

		public MaterialRowConfig GetMaterial(string key)
		{
			return null;
		}

		public void MaterialField(ImUIBuilder ui, Part part, string material, string key = null)
		{
		}
	}
}
