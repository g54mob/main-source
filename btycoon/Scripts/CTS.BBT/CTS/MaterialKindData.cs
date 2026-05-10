using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "MaterialKindData", menuName = "MaterialData/MaterialKindData")]
	public class MaterialKindData : ScriptableObject
	{
		public Material material;

		public CustomColor[] color_1;

		public CustomColor[] color_2;

		public CustomColor[] color_3;
	}
}
