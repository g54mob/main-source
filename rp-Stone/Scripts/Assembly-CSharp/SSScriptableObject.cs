using System.Collections.Generic;
using System.Reflection;
using Stonescript;
using UnityEngine;

public class SSScriptableObject : MonoBehaviour
{
	private StonescriptObject target = new StonescriptObject("");

	private bool loaded;

	public StonescriptObject Target => target;

	public Character Character => GetComponent<Character>();

	private void Awake()
	{
		Load();
	}

	public void LoadComponent(Component component)
	{
		Bind(component, target);
	}

	private void Load()
	{
		if (loaded)
		{
			return;
		}
		loaded = true;
		Component[] components = GetComponents<Component>();
		List<NativeFunction.Callback> list = new List<NativeFunction.Callback>();
		List<StonescriptObject.Getter> list2 = new List<StonescriptObject.Getter>();
		List<StonescriptObject.Setter> list3 = new List<StonescriptObject.Setter>();
		Component[] array = components;
		foreach (Component component in array)
		{
			MethodInfo[] methods = component.GetType().GetMethods();
			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.IsDefined(typeof(StonescriptNativeMethod)))
				{
					list.Add(methodInfo.CreateDelegate(typeof(NativeFunction.Callback), component) as NativeFunction.Callback);
				}
				if (methodInfo.IsDefined(typeof(StonescriptNativeGetter)))
				{
					list2.Add(methodInfo.CreateDelegate(typeof(StonescriptObject.Getter), component) as StonescriptObject.Getter);
				}
				if (methodInfo.IsDefined(typeof(StonescriptNativeSetter)))
				{
					list3.Add(methodInfo.CreateDelegate(typeof(StonescriptObject.Setter), component) as StonescriptObject.Setter);
				}
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			NativeFunction.Callback callback = list[k];
			StonescriptNativeMethod customAttribute = callback.Method.GetCustomAttribute<StonescriptNativeMethod>();
			string funcName = ((customAttribute.name != null) ? customAttribute.name : callback.Method.Name);
			target.DeclareFunction(funcName, callback);
		}
		for (int l = 0; l < list2.Count; l++)
		{
			StonescriptObject.Getter getter = list2[l];
			StonescriptNativeGetter customAttribute2 = getter.Method.GetCustomAttribute<StonescriptNativeGetter>();
			string varId = ((customAttribute2.name != null) ? customAttribute2.name : getter.Method.Name);
			target.DeclareGetter(varId, getter);
		}
		for (int m = 0; m < list3.Count; m++)
		{
			StonescriptObject.Setter setter = list3[m];
			StonescriptNativeSetter customAttribute3 = setter.Method.GetCustomAttribute<StonescriptNativeSetter>();
			string varId2 = ((customAttribute3.name != null) ? customAttribute3.name : setter.Method.Name);
			target.DeclareSetter(varId2, setter);
		}
		target.SetNative("scriptable", this);
	}

	public static void Bind(object obj, StonescriptObject target)
	{
		List<NativeFunction.Callback> list = new List<NativeFunction.Callback>();
		List<StonescriptObject.Getter> list2 = new List<StonescriptObject.Getter>();
		List<StonescriptObject.Setter> list3 = new List<StonescriptObject.Setter>();
		MethodInfo[] methods = obj.GetType().GetMethods();
		foreach (MethodInfo methodInfo in methods)
		{
			if (methodInfo.IsDefined(typeof(StonescriptNativeMethod)))
			{
				list.Add(methodInfo.CreateDelegate(typeof(NativeFunction.Callback), obj) as NativeFunction.Callback);
			}
			if (methodInfo.IsDefined(typeof(StonescriptNativeGetter)))
			{
				list2.Add(methodInfo.CreateDelegate(typeof(StonescriptObject.Getter), obj) as StonescriptObject.Getter);
			}
			if (methodInfo.IsDefined(typeof(StonescriptNativeSetter)))
			{
				list3.Add(methodInfo.CreateDelegate(typeof(StonescriptObject.Setter), obj) as StonescriptObject.Setter);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			NativeFunction.Callback callback = list[j];
			StonescriptNativeMethod customAttribute = callback.Method.GetCustomAttribute<StonescriptNativeMethod>();
			string funcName = ((customAttribute.name != null) ? customAttribute.name : callback.Method.Name);
			target.DeclareFunction(funcName, callback);
		}
		for (int k = 0; k < list2.Count; k++)
		{
			StonescriptObject.Getter getter = list2[k];
			StonescriptNativeGetter customAttribute2 = getter.Method.GetCustomAttribute<StonescriptNativeGetter>();
			string varId = ((customAttribute2.name != null) ? customAttribute2.name : getter.Method.Name);
			target.DeclareGetter(varId, getter);
		}
		for (int l = 0; l < list3.Count; l++)
		{
			StonescriptObject.Setter setter = list3[l];
			StonescriptNativeSetter customAttribute3 = setter.Method.GetCustomAttribute<StonescriptNativeSetter>();
			string varId2 = ((customAttribute3.name != null) ? customAttribute3.name : setter.Method.Name);
			target.DeclareSetter(varId2, setter);
		}
	}

	private void OnDestroy()
	{
		target.destroyed = true;
	}
}
