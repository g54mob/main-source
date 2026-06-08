using System.Reflection;
using UnityEngine;

public class Utils : MonoBehaviour
{
	public static void DestroyAllChildrenIn(GameObject obj, bool recurse)
	{
		for (int num = obj.transform.childCount - 1; num >= 0; num--)
		{
			if (recurse)
			{
				DestroyAllChildrenIn(obj.transform.GetChild(num).gameObject, true);
			}
			Object.Destroy(obj.transform.GetChild(num).gameObject);
		}
	}

	public static void MoveComponent(Component c, GameObject moveTo)
	{
		Component obj = moveTo.AddComponent(c.GetType());
		FieldInfo[] fields = c.GetType().GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			fieldInfo.SetValue(obj, fieldInfo.GetValue(c));
		}
		Object.DestroyImmediate(c);
	}
}
