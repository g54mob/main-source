using System;
using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	public class ShapeGroup : MonoBehaviour
	{
		public static int shapeGroupsInScene;

		[ShapesColorField(true)]
		[SerializeField]
		private Color color = Color.white;

		[NonSerialized]
		private bool isEnabled;

		public bool IsEnabled => isEnabled;

		public Color Color
		{
			get
			{
				return color;
			}
			set
			{
				color = value;
				UpdateChildShapes();
			}
		}

		private void OnEnable()
		{
			shapeGroupsInScene++;
			isEnabled = true;
			UpdateChildShapes();
		}

		private void OnDisable()
		{
			shapeGroupsInScene--;
			isEnabled = false;
			UpdateChildShapes();
		}

		private void OnValidate()
		{
			UpdateChildShapes();
		}

		private void UpdateChildShapes()
		{
			ShapeRenderer[] componentsInChildren = GetComponentsInChildren<ShapeRenderer>();
			if (componentsInChildren != null)
			{
				ShapeRenderer[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].UpdateAllMaterialProperties();
				}
			}
		}
	}
}
