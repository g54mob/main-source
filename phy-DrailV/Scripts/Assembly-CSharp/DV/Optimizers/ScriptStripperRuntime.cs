using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Optimizers
{
	public static class ScriptStripperRuntime
	{
		private static readonly HashSet<Type> stripIgnoreTypes = new HashSet<Type>
		{
			typeof(Transform),
			typeof(Renderer),
			typeof(MeshFilter),
			typeof(LODGroup)
		};

		public static void Strip(GameObject goToStrip)
		{
			MonoBehaviour[] componentsInChildren = goToStrip.GetComponentsInChildren<MonoBehaviour>();
			Joint[] componentsInChildren2 = goToStrip.GetComponentsInChildren<Joint>();
			Rigidbody[] componentsInChildren3 = goToStrip.GetComponentsInChildren<Rigidbody>();
			Collider[] componentsInChildren4 = goToStrip.GetComponentsInChildren<Collider>();
			Joint[] array = componentsInChildren2;
			for (int i = 0; i < array.Length; i++)
			{
				UnityEngine.Object.Destroy(array[i]);
			}
			Rigidbody[] array2 = componentsInChildren3;
			for (int i = 0; i < array2.Length; i++)
			{
				UnityEngine.Object.Destroy(array2[i]);
			}
			Collider[] array3 = componentsInChildren4;
			for (int i = 0; i < array3.Length; i++)
			{
				UnityEngine.Object.Destroy(array3[i]);
			}
			MonoBehaviour[] array4 = componentsInChildren;
			for (int i = 0; i < array4.Length; i++)
			{
				UnityEngine.Object.Destroy(array4[i]);
			}
		}

		public static void Strip2(GameObject goToStrip)
		{
			Component[] componentsInChildren = goToStrip.GetComponentsInChildren<Component>();
			for (int num = componentsInChildren.Length - 1; num >= 0; num--)
			{
				Component component = componentsInChildren[num];
				if (!(component == null))
				{
					Type type = component.GetType();
					if (!stripIgnoreTypes.Contains(type))
					{
						UnityEngine.Object.Destroy(component);
					}
				}
			}
		}
	}
}
