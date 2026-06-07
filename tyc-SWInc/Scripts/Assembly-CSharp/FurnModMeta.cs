using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tyd;
using UnityEngine;

public abstract class FurnModMeta
{
	public Component Target;

	public bool Changed;

	[NonSerialized]
	public Dictionary<FieldInfo, FurnModAttr> Meta;

	public abstract string MetaName { get; }

	public virtual bool UseGizmo()
	{
		return true;
	}

	public static FurnModMeta CreateMeta(Component target, Type type)
	{
		ConstructorInfo constructor = type.GetConstructor(new Type[1] { typeof(Component) });
		object[] parameters = new Component[1] { target };
		return constructor.Invoke(parameters) as FurnModMeta;
	}

	public FurnModMeta(Component target)
	{
		Target = target;
		InitMeta(GetType());
		OnActivate();
		InitFields();
	}

	public static bool IsGameObjectField(Type t)
	{
		Type typeFromHandle = typeof(GameObject);
		if (t == typeFromHandle)
		{
			return true;
		}
		if (t.IsArray)
		{
			return IsGameObjectField(t.GetElementType());
		}
		if (t.IsGenericType)
		{
			return t.GenericTypeArguments.Any(IsGameObjectField);
		}
		return false;
	}

	public void InitFields()
	{
		Type type = Target.GetType();
		foreach (KeyValuePair<FieldInfo, FurnModAttr> metum in Meta)
		{
			switch (metum.Value.Type)
			{
			case FurnModAttr.VariableType.TransformPosition:
				metum.Key.SetValue(this, Target.transform.localPosition);
				break;
			case FurnModAttr.VariableType.TransformRotation:
				metum.Key.SetValue(this, Target.transform.localRotation.eulerAngles);
				break;
			case FurnModAttr.VariableType.TransformScale:
				metum.Key.SetValue(this, Target.transform.localScale);
				break;
			case FurnModAttr.VariableType.TransformParent:
				metum.Key.SetValue(this, Target.transform.parent.gameObject);
				break;
			case FurnModAttr.VariableType.Material:
			{
				if (metum.Value.VarName != null)
				{
					InitField(metum.Key, metum.Value, type);
					break;
				}
				Renderer component8 = Target.GetComponent<Renderer>();
				if (component8 != null)
				{
					metum.Key.SetValue(this, component8.sharedMaterial);
				}
				break;
			}
			case FurnModAttr.VariableType.Mesh:
			{
				if (metum.Value.VarName != null)
				{
					InitField(metum.Key, metum.Value, type);
					break;
				}
				MeshFilter component7 = Target.GetComponent<MeshFilter>();
				if (component7 != null)
				{
					metum.Key.SetValue(this, component7.sharedMesh);
				}
				break;
			}
			case FurnModAttr.VariableType.SubComponent:
			{
				Component component6 = Target.GetComponent(metum.Value.ComponentType);
				if (component6 != null)
				{
					metum.Key.SetValue(this, CreateMeta(component6, metum.Key.FieldType));
				}
				break;
			}
			case FurnModAttr.VariableType.ExternalComponent:
			{
				if (IsGameObjectField(metum.Key.FieldType))
				{
					object field = GetField(metum.Value, type);
					if (metum.Value.IsArray)
					{
						IList list = field as IList;
						GameObject[] array = ((list != null) ? new GameObject[list.Count] : Array.Empty<GameObject>());
						metum.Key.SetValue(this, array);
						if (list == null)
						{
							break;
						}
						for (int i = 0; i < list.Count; i++)
						{
							Component component;
							GameObject gameObject;
							if ((object)(component = list[i] as Component) != null)
							{
								array[i] = component.gameObject;
							}
							else if ((object)(gameObject = list[i] as GameObject) != null)
							{
								array[i] = gameObject;
							}
						}
					}
					else if (metum.Value.IsList)
					{
						List<GameObject> list2 = new List<GameObject>();
						metum.Key.SetValue(this, list2);
						IList list3;
						if ((list3 = field as IList) == null)
						{
							break;
						}
						for (int j = 0; j < list3.Count; j++)
						{
							Component component2;
							GameObject item;
							if ((object)(component2 = list3[j] as Component) != null)
							{
								list2.Add(component2.gameObject);
							}
							else if ((object)(item = list3[j] as GameObject) != null)
							{
								list2.Add(item);
							}
						}
					}
					else
					{
						Component component3 = field as Component;
						GameObject value;
						if (component3 != null)
						{
							metum.Key.SetValue(this, component3.gameObject);
						}
						else if ((object)(value = field as GameObject) != null)
						{
							metum.Key.SetValue(this, value);
						}
					}
					break;
				}
				Component component4 = GetField(metum.Value, type) as Component;
				if (component4 != null)
				{
					Component component5 = component4.GetComponent(metum.Value.ComponentType);
					if (component5 != null)
					{
						metum.Key.SetValue(this, CreateMeta(component5, metum.Key.FieldType));
					}
				}
				break;
			}
			default:
				InitField(metum.Key, metum.Value, type);
				break;
			}
		}
	}

	public void SetTargetField(FieldInfo metaField, FurnModAttr atr, int idx)
	{
		if (atr.ArrayIndex > -1)
		{
			Debug.LogError("Can't set value of array index variable: " + metaField.Name);
			return;
		}
		Type type = Target.GetType();
		FieldInfo field = type.GetField(atr.VarName);
		if (field != null)
		{
			if ((idx > -1 && atr.IsArray) || atr.IsList)
			{
				IList obj = field.GetValue(Target) as IList;
				IList list = metaField.GetValue(this) as IList;
				obj[idx] = list[idx];
			}
			else
			{
				field.SetValue(Target, CheckComponent(metaField.GetValue(this), atr, field.FieldType));
			}
			return;
		}
		PropertyInfo property = type.GetProperty(atr.VarName);
		if (property != null)
		{
			if ((idx > -1 && atr.IsArray) || atr.IsList)
			{
				IList obj2 = property.GetValue(Target) as IList;
				IList list2 = metaField.GetValue(this) as IList;
				obj2[idx] = list2[idx];
			}
			else
			{
				property.SetValue(Target, CheckComponent(metaField.GetValue(this), atr, property.PropertyType));
			}
		}
	}

	private static object CheckComponent(object o, FurnModAttr atr, Type varType)
	{
		GameObject gameObject;
		if (atr.Type == FurnModAttr.VariableType.ExternalComponent && varType != typeof(GameObject) && (object)(gameObject = o as GameObject) != null)
		{
			o = gameObject.GetComponent(varType);
		}
		return o;
	}

	private void InitField(FieldInfo metaField, FurnModAttr atr, Type type)
	{
		if (atr.VarName == null || atr.MetaLocal)
		{
			return;
		}
		try
		{
			FieldInfo field = type.GetField(atr.VarName);
			if (field != null)
			{
				if (atr.ArrayIndex > -1)
				{
					Array array;
					if ((array = field.GetValue(Target) as Array) != null && atr.ArrayIndex < array.Length)
					{
						metaField.SetValue(this, array.GetValue(atr.ArrayIndex));
					}
				}
				else
				{
					metaField.SetValue(this, field.GetValue(Target));
				}
				return;
			}
			PropertyInfo property = type.GetProperty(atr.VarName);
			if (property != null)
			{
				if (atr.ArrayIndex > -1)
				{
					Array array2;
					if ((array2 = property.GetValue(Target) as Array) != null && atr.ArrayIndex < array2.Length)
					{
						metaField.SetValue(this, array2.GetValue(atr.ArrayIndex));
					}
				}
				else
				{
					metaField.SetValue(this, property.GetValue(Target));
				}
			}
			else
			{
				Debug.LogError("Failed setting field: " + metaField.Name);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Failed setting field: " + metaField.Name + "\n" + ex.Message);
		}
	}

	private object GetField(FurnModAttr atr, Type type)
	{
		if (atr.VarName != null)
		{
			FieldInfo field = type.GetField(atr.VarName);
			if (field != null)
			{
				if (atr.ArrayIndex <= -1)
				{
					return field.GetValue(Target);
				}
				Array array;
				if ((array = field.GetValue(Target) as Array) != null && atr.ArrayIndex < array.Length)
				{
					return array.GetValue(atr.ArrayIndex);
				}
			}
			else
			{
				PropertyInfo property = type.GetProperty(atr.VarName);
				if (property != null)
				{
					if (atr.ArrayIndex <= -1)
					{
						return property.GetValue(Target);
					}
					Array array2;
					if ((array2 = property.GetValue(Target) as Array) != null && atr.ArrayIndex < array2.Length)
					{
						return array2.GetValue(atr.ArrayIndex);
					}
				}
			}
		}
		return null;
	}

	private void InitMeta(Type self)
	{
		if (Meta != null)
		{
			return;
		}
		Meta = new Dictionary<FieldInfo, FurnModAttr>();
		FieldInfo[] fields = self.GetFields(BindingFlags.Instance | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			FurnModAttr customAttribute = fieldInfo.GetCustomAttribute<FurnModAttr>();
			if (customAttribute != null)
			{
				Meta[fieldInfo] = customAttribute;
			}
		}
	}

	protected void SaveIfChanged<T>(TydCollection parent, string name, T value, T def)
	{
		if (!value.Equals(def))
		{
			parent.AddChild(new TydString(name, value.ToString()));
		}
	}

	protected bool CheckIfChanged(string field, out string varName)
	{
		return CheckIfChanged(field, FurnitureModdingTool.Instance.ActivePrefab.BaseObject, out varName);
	}

	protected void SetIfChanged(string field, TydNode f, TydNode value)
	{
		string varName;
		if (CheckIfChanged(field, out varName))
		{
			f.SetNode(varName, value);
		}
		else if (varName != null)
		{
			f.RemoveNode(varName);
		}
	}

	protected void SetIfChanged(string targetName, object tValue, object fValue, TydNode f, TydNode value)
	{
		if (CheckIfChanged(tValue, fValue))
		{
			f.SetNode(targetName, value);
		}
		else
		{
			f.RemoveNode(targetName);
		}
	}

	protected void SetIfChanged(FieldInfo field, FurnModAttr atr, TydNode f, string value, WallSnap target)
	{
		target = target ?? FurnitureModdingTool.Instance.ActivePrefab.BaseObject;
		object value2;
		if (!GetTargetValue(atr.VarName, target, out value2) || CheckIfChanged(field.GetValue(this), value2))
		{
			f.SetNode(atr.VarName, value, true);
		}
		else
		{
			f.RemoveNode(atr.VarName);
		}
	}

	protected void SetIfChanged(FieldInfo field, FurnModAttr atr, TydNode f, TydNode value, WallSnap target)
	{
		target = target ?? FurnitureModdingTool.Instance.ActivePrefab.BaseObject;
		object value2;
		if (!GetTargetValue(atr.VarName, target, out value2) || CheckIfChanged(field.GetValue(this), value2, atr.Type == FurnModAttr.VariableType.ExternalComponent))
		{
			f.SetNode(atr.VarName, value);
		}
		else
		{
			f.RemoveNode(atr.VarName);
		}
	}

	protected void SetIfChanged(string field, TydNode f, string value)
	{
		string varName;
		if (CheckIfChanged(field, out varName))
		{
			f.SetNode(varName, value, true);
		}
		else if (varName != null)
		{
			f.RemoveNode(varName);
		}
	}

	protected void SetIfChanged(string field, object target, TydNode f, string value)
	{
		string varName;
		if (CheckIfChanged(field, target, out varName))
		{
			f.SetNode(varName, value, true);
		}
		else if (varName != null)
		{
			f.RemoveNode(varName);
		}
	}

	protected void SetIfChanged(string targetName, object tValue, object fValue, TydNode f, string value)
	{
		if (CheckIfChanged(tValue, fValue))
		{
			f.SetNode(targetName, value, true);
		}
		else
		{
			f.RemoveNode(targetName);
		}
	}

	protected bool CheckIfChanged(string field, object target, out string varName)
	{
		varName = null;
		if (target == null)
		{
			foreach (KeyValuePair<FieldInfo, FurnModAttr> metum in Meta)
			{
				if (metum.Key.Name.Equals(field))
				{
					varName = metum.Value.VarName;
					break;
				}
			}
			return true;
		}
		foreach (KeyValuePair<FieldInfo, FurnModAttr> metum2 in Meta)
		{
			FieldInfo key = metum2.Key;
			if (key.Name.Equals(field))
			{
				FurnModAttr value = metum2.Value;
				varName = value.VarName;
				object value2;
				if (!GetTargetValue(value.VarName, target, out value2))
				{
					return true;
				}
				object value3 = key.GetValue(this);
				return CheckIfChanged(value2, value3);
			}
		}
		return true;
	}

	private bool GetTargetValue(string varName, object target, out object value)
	{
		value = null;
		if (target == null)
		{
			return false;
		}
		Type type = target.GetType();
		FieldInfo field = type.GetField(varName);
		if (field != null)
		{
			value = field.GetValue(target);
			return true;
		}
		PropertyInfo property = type.GetProperty(varName);
		if (property != null)
		{
			value = property.GetValue(target);
			return true;
		}
		return false;
	}

	protected bool CheckIfChanged(object target, string targetVar, object fValue)
	{
		if (target == null)
		{
			return true;
		}
		Type type = target.GetType();
		FieldInfo field = type.GetField(targetVar);
		object value;
		if (field != null)
		{
			value = field.GetValue(target);
		}
		else
		{
			PropertyInfo property = type.GetProperty(targetVar);
			if (!(property != null))
			{
				return true;
			}
			value = property.GetValue(target);
		}
		return CheckIfChanged(value, fValue);
	}

	protected bool CheckIfChanged(object value, object fValue, bool go = false)
	{
		if (value is IList || fValue is IList)
		{
			IList list = value as IList;
			IList list2 = fValue as IList;
			if (list2 == null != (list == null))
			{
				if (list2 == null)
				{
					return list.Count > 0;
				}
				return list2.Count > 0;
			}
			if (list == null)
			{
				return false;
			}
			if (list.Count != list2.Count)
			{
				return true;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (!AreEqual(list[i], list2[i], go))
				{
					return true;
				}
			}
			return false;
		}
		return !AreEqual(value, fValue, go);
	}

	private bool IsNullString(object o)
	{
		if (o != null)
		{
			string value;
			if ((value = o as string) != null)
			{
				return string.IsNullOrEmpty(value);
			}
			return false;
		}
		return true;
	}

	private bool AreEqual(object o1, object o2, bool go)
	{
		if (go || o1 is GameObject || o2 is GameObject)
		{
			o1 = GetGameObject(o1);
			o2 = GetGameObject(o2);
		}
		else if (IsNullString(o1) && IsNullString(o2))
		{
			return true;
		}
		UnityEngine.Object obj;
		if ((object)(obj = o1 as UnityEngine.Object) != null && obj == null)
		{
			o1 = null;
		}
		UnityEngine.Object obj2;
		if ((object)(obj2 = o2 as UnityEngine.Object) != null && obj2 == null)
		{
			o2 = null;
		}
		if (o1 == null)
		{
			if (o2 == null)
			{
				return true;
			}
			return false;
		}
		if (o2 != null)
		{
			return o1.Equals(o2);
		}
		return false;
	}

	private GameObject GetGameObject(object o)
	{
		GameObject gameObject = o as GameObject;
		if (gameObject != null)
		{
			return gameObject;
		}
		Component component = o as Component;
		if (!(component != null))
		{
			return null;
		}
		return component.gameObject;
	}

	protected void WriteTransform(TydNode root, string name, Transform tr, GameObject parent)
	{
		TydList tydList;
		if ((tydList = root.FindNode("Transforms", true, false) as TydList) != null)
		{
			TydTable root2 = tydList.Nodes.OfType<TydTable>().FirstOrDefault((TydTable x) => name.Equals(x.GetChildValue("Name", false))) ?? tydList.AddChild(new TydTable(null));
			root2.SetNode("Name", name, true);
			if (parent != null && parent != FurnitureModdingTool.Instance.ActiveObject)
			{
				root2.SetNode("TransformParent", parent.name, true);
			}
			else
			{
				root2.RemoveNode("TransformParent");
			}
			root2.SetNode("Position", tr.localPosition.ToTyd("Position"));
			root2.SetNode("Rotation", tr.localRotation.eulerAngles.ToTyd("Rotation"));
			root2.SetNode("Scale", tr.localScale.ToTyd("Scale"));
		}
	}

	protected void WriteTransform(TydNode root, string name)
	{
		TydList tydList;
		if ((tydList = root.FindNode("Transforms", true, false) as TydList) != null)
		{
			TydTable root2 = tydList.Nodes.OfType<TydTable>().FirstOrDefault((TydTable x) => name.Equals(x.GetChildValue("Name", false))) ?? tydList.AddChild(new TydTable(null));
			root2.SetNode("Name", name, true);
			root2.RemoveNode("TransformParent");
			root2.SetNode("Position", Vector3.zero.ToTyd("Position"));
			root2.SetNode("Rotation", Vector3.zero.ToTyd("Rotation"));
		}
	}

	public virtual void WriteToTyD(TydTable root)
	{
	}

	public virtual void OnSelect()
	{
	}

	public virtual void OnDeselect()
	{
	}

	public virtual void OnActivate()
	{
	}

	public virtual void OnDeactivate()
	{
	}

	public virtual void OnCreateNew()
	{
	}

	public void WriteDirects(string parent, TydCollection root, WallSnap target)
	{
		foreach (KeyValuePair<FieldInfo, FurnModAttr> metum in Meta)
		{
			if (parent.Equals(metum.Value.WriteDirectParent))
			{
				SetIfChanged(metum.Key, metum.Value, root, CreateNode(metum.Key.GetValue(this), metum.Value.VarName, metum.Key, metum.Value, false), target);
			}
		}
	}

	private TydNode CreateNode(object o, string varName, FieldInfo field, FurnModAttr m, bool sub)
	{
		if (!sub && (m.IsArray || m.IsList))
		{
			IList list;
			if ((list = o as IList) != null)
			{
				TydList tydList = new TydList(varName);
				for (int i = 0; i < list.Count; i++)
				{
					tydList.AddChild(CreateNode(list[i], null, field, m, true));
				}
				return tydList;
			}
			return new TydString(varName, null);
		}
		switch (m.Type)
		{
		case FurnModAttr.VariableType.TransformPosition:
		case FurnModAttr.VariableType.TransformRotation:
		case FurnModAttr.VariableType.TransformScale:
		case FurnModAttr.VariableType.TransformParent:
		case FurnModAttr.VariableType.Material:
		case FurnModAttr.VariableType.SubComponent:
		case FurnModAttr.VariableType.ExternalMeta:
			throw new Exception("Tried to auto write non supported node:" + m.Type);
		case FurnModAttr.VariableType.ExternalComponent:
		{
			if (IsGameObjectField(field.FieldType))
			{
				GameObject gameObject = (GameObject)o;
				return new TydString(varName, (gameObject != null) ? gameObject.name : null);
			}
			FurnModMeta furnModMeta = (FurnModMeta)o;
			return new TydString(varName, (furnModMeta != null) ? furnModMeta.Target.name : null);
		}
		case FurnModAttr.VariableType.Mesh:
		{
			string val = null;
			Mesh mesh;
			if ((object)(mesh = o as Mesh) != null && mesh != null)
			{
				val = mesh.name;
			}
			return new TydString(varName, val);
		}
		case FurnModAttr.VariableType.Color:
			return new TydString(varName, ColorUtility.ToHtmlStringRGBA((Color)o));
		case FurnModAttr.VariableType.Vector2:
			return ((Vector2)o).ToTyd(varName);
		case FurnModAttr.VariableType.Vector3:
			return ((Vector3)o).ToTyd(varName);
		case FurnModAttr.VariableType.String:
		case FurnModAttr.VariableType.BigString:
		case FurnModAttr.VariableType.Integer:
		case FurnModAttr.VariableType.Float:
		case FurnModAttr.VariableType.PercentSlider:
		case FurnModAttr.VariableType.Bool:
		case FurnModAttr.VariableType.Enum:
			return new TydString(varName, o.ToString());
		default:
			throw new Exception("Tried to auto write unwritten node:" + m.Type);
		}
	}

	public abstract string GetMetaGroup();
}
