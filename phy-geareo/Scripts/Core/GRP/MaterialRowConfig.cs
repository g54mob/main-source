using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/MaterialRowConfig", fileName = "MaterialRowConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class MaterialRowConfig : ScriptableObject
	{
		public string key;

		public string title;

		public Material material;

		public Material magicMaterial;

		public Material motorMaterial;

		public float density;

		public PhysicsMaterial physicsMaterial;
	}
}
