using AwesomeTechnologies.Vegetation.Masks;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Vegetation
{
	public class VegetationItemInstanceInfo : MonoBehaviour
	{
		public string VegetationItemInstanceID;

		public Vector3 Position;

		public Vector3 Scale;

		public Quaternion Rotation;

		public string VegetationItemID;

		public VegetationType VegetationType;

		public void MaskVegetationItem()
		{
			GameObject obj = new GameObject();
			obj.name = "VegetationItemMask - " + base.name;
			obj.transform.position = Position;
			obj.AddComponent<VegetationItemMask>().SetVegetationItemInstanceInfo(this);
		}
	}
}
