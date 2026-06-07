using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetItemSpecificMaterialApplier : MonoBehaviour
	{
		public int materialIndex;

		private void Start()
		{
			GadgetBase componentInParent = GetComponentInParent<GadgetBase>();
			if (componentInParent != null)
			{
				MeshRenderer component = GetComponent<MeshRenderer>();
				Material[] sharedMaterials = component.sharedMaterials;
				sharedMaterials[materialIndex] = componentInParent.GadgetItem.SpecificMaterial;
				component.sharedMaterials = sharedMaterials;
			}
		}
	}
}
