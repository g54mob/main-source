using UnityEngine;

namespace VRTK.Examples
{
	public class Menu_Color_Changer : VRTK_InteractableObject
	{
		public Color newMenuColor = Color.black;

		public override void StartUsing(VRTK_InteractUse usingObject)
		{
			base.StartUsing(usingObject);
			base.transform.parent.gameObject.GetComponent<Menu_Container_Object_Colors>().SetSelectedColor(newMenuColor);
			ResetMenuItems();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			base.gameObject.GetComponent<MeshRenderer>().material.color = newMenuColor;
		}

		private void ResetMenuItems()
		{
			Menu_Color_Changer[] array = Object.FindObjectsOfType<Menu_Color_Changer>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].StopUsing();
			}
		}
	}
}
