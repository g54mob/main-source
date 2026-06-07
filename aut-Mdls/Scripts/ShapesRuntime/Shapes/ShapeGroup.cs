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

		[field: NonSerialized]
		internal bool IsEnabled { get; private set; }

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
			IsEnabled = true;
			UpdateChildShapes();
		}

		private void OnDisable()
		{
			shapeGroupsInScene--;
			IsEnabled = false;
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
