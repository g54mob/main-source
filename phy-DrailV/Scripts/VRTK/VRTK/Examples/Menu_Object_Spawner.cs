using UnityEngine;

namespace VRTK.Examples
{
	public class Menu_Object_Spawner : VRTK_InteractableObject
	{
		public enum PrimitiveTypes
		{
			Cube = 0,
			Sphere = 1
		}

		public PrimitiveTypes shape;

		private Color selectedColor;

		public void SetSelectedColor(Color color)
		{
			selectedColor = color;
			base.gameObject.GetComponent<MeshRenderer>().material.color = color;
		}

		public override void StartUsing(VRTK_InteractUse usingObject)
		{
			base.StartUsing(usingObject);
			if (shape == PrimitiveTypes.Cube)
			{
				CreateShape(PrimitiveType.Cube, selectedColor);
			}
			else if (shape == PrimitiveTypes.Sphere)
			{
				CreateShape(PrimitiveType.Sphere, selectedColor);
			}
			ResetMenuItems();
		}

		private void CreateShape(PrimitiveType shape, Color color)
		{
			GameObject obj = GameObject.CreatePrimitive(shape);
			obj.transform.position = base.transform.position;
			obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			obj.GetComponent<MeshRenderer>().material.color = color;
			obj.AddComponent<Rigidbody>();
		}

		private void ResetMenuItems()
		{
			Menu_Object_Spawner[] array = Object.FindObjectsOfType<Menu_Object_Spawner>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].StopUsing();
			}
		}
	}
}
