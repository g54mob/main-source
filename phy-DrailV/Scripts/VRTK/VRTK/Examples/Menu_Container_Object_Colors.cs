using UnityEngine;

namespace VRTK.Examples
{
	public class Menu_Container_Object_Colors : VRTK_InteractableObject
	{
		public void SetSelectedColor(Color color)
		{
			Menu_Object_Spawner[] componentsInChildren = base.gameObject.GetComponentsInChildren<Menu_Object_Spawner>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].SetSelectedColor(color);
			}
		}

		protected void Start()
		{
			SetSelectedColor(Color.red);
			SaveCurrentState();
		}
	}
}
