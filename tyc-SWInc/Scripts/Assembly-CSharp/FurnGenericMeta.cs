using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Tyd;
using UnityEngine;

public class FurnGenericMeta : FurnModMeta
{
	public override string MetaName
	{
		get
		{
			return Target.GetType().Name;
		}
	}

	public FurnGenericMeta(Component target)
		: base(target)
	{
		Meta.Clear();
		FieldInfo[] fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (!fieldInfo.IsNotSerialized)
			{
				ValueTuple<FurnModAttr.VariableType, bool, bool, Type>? type = GetType(fieldInfo);
				if (type.HasValue)
				{
					Meta.Add(fieldInfo, new FurnModAttr(fieldInfo.Name, type.Value.Item1)
					{
						IsArray = type.Value.Item2,
						IsList = type.Value.Item3,
						ComponentType = type.Value.Item4
					});
				}
			}
		}
		fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo2 in fields)
		{
			if (!fieldInfo2.IsNotSerialized && fieldInfo2.GetCustomAttribute<SerializeField>() != null)
			{
				ValueTuple<FurnModAttr.VariableType, bool, bool, Type>? type2 = GetType(fieldInfo2);
				if (type2.HasValue)
				{
					Meta.Add(fieldInfo2, new FurnModAttr(fieldInfo2.Name, type2.Value.Item1)
					{
						IsArray = type2.Value.Item2,
						IsList = type2.Value.Item3,
						ComponentType = type2.Value.Item4
					});
				}
			}
		}
	}

	public ValueTuple<FurnModAttr.VariableType, bool, bool, Type>? GetType(FieldInfo info)
	{
		Type fieldType = info.FieldType;
		Type type = fieldType;
		bool isArray = fieldType.IsArray;
		if (isArray)
		{
			type = fieldType.GetElementType();
		}
		bool flag = !isArray && fieldType.IsGenericType && fieldType.GetGenericTypeDefinition() == typeof(List<>);
		if (flag)
		{
			type = fieldType.GetGenericArguments()[0];
		}
		if (type == typeof(string))
		{
			if (info.GetCustomAttribute<TextAreaAttribute>() != null)
			{
				return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.BigString, isArray, flag, null);
			}
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.String, isArray, flag, null);
		}
		if (type == typeof(bool))
		{
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.Bool, isArray, flag, null);
		}
		if (type == typeof(int))
		{
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.Integer, isArray, flag, null);
		}
		if (type == typeof(float))
		{
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.Float, isArray, flag, null);
		}
		if (type == typeof(Mesh))
		{
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.Mesh, isArray, flag, null);
		}
		if (type == typeof(Material))
		{
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.Material, isArray, flag, null);
		}
		if (type == typeof(Color))
		{
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.Color, isArray, flag, null);
		}
		if (type.IsEnum)
		{
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.Enum, isArray, flag, null);
		}
		if (type == typeof(Vector2))
		{
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.Vector2, isArray, flag, null);
		}
		if (type == typeof(Vector3))
		{
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.Vector3, isArray, flag, null);
		}
		if (type.IsSubclassOf(typeof(Component)))
		{
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.ExternalComponent, isArray, flag, type);
		}
		if (type == typeof(GameObject))
		{
			return new ValueTuple<FurnModAttr.VariableType, bool, bool, Type>(FurnModAttr.VariableType.ExternalComponent, isArray, flag, typeof(Transform));
		}
		return null;
	}

	public override string GetMetaGroup()
	{
		return null;
	}

	private static TydNode NodeFromValue(object value, FurnModAttr.VariableType type, string name)
	{
		switch (type)
		{
		case FurnModAttr.VariableType.String:
		case FurnModAttr.VariableType.BigString:
		case FurnModAttr.VariableType.Integer:
		case FurnModAttr.VariableType.Float:
		case FurnModAttr.VariableType.PercentSlider:
		case FurnModAttr.VariableType.Combo:
		case FurnModAttr.VariableType.Bool:
		case FurnModAttr.VariableType.Enum:
			return new TydString(name, value.ToString());
		case FurnModAttr.VariableType.TransformParent:
		case FurnModAttr.VariableType.SubComponent:
		case FurnModAttr.VariableType.ExternalComponent:
		case FurnModAttr.VariableType.ExternalMeta:
		{
			UnityEngine.Object obj2;
			return new TydString(name, ((object)(obj2 = value as UnityEngine.Object) != null) ? obj2.name : null);
		}
		case FurnModAttr.VariableType.Mesh:
		{
			Mesh mesh;
			return new TydString(name, ((object)(mesh = value as Mesh) != null) ? mesh.name : null);
		}
		case FurnModAttr.VariableType.Material:
		{
			Material material;
			return new TydString(name, ((object)(material = value as Material) != null) ? material.name : null);
		}
		case FurnModAttr.VariableType.Color:
		{
			object obj;
			object val;
			if ((obj = value) is Color)
			{
				Color color = (Color)obj;
				val = ColorUtility.ToHtmlStringRGBA(color);
			}
			else
			{
				val = "#000000";
			}
			return new TydString(name, (string)val);
		}
		case FurnModAttr.VariableType.Vector2:
		{
			object obj;
			object children2;
			if (!((obj = value) is Vector2))
			{
				children2 = new string[2] { "0", "0" };
			}
			else
			{
				Vector2 vector2 = (Vector2)obj;
				children2 = new string[2]
				{
					vector2.x.ToString(),
					vector2.y.ToString()
				};
			}
			return new TydList(name, (string[])children2);
		}
		case FurnModAttr.VariableType.Vector3:
		{
			object obj;
			object children;
			if (!((obj = value) is Vector3))
			{
				children = new string[3] { "0", "0", "0" };
			}
			else
			{
				Vector3 vector = (Vector3)obj;
				children = new string[3]
				{
					vector.x.ToString(),
					vector.y.ToString(),
					vector.z.ToString()
				};
			}
			return new TydList(name, (string[])children);
		}
		default:
			return new TydString(name, null);
		}
	}

	public override void WriteToTyD(TydTable root)
	{
		TydTable tydTable = root.FindNode(MetaName, true) as TydTable;
		foreach (KeyValuePair<FieldInfo, FurnModAttr> metum in Meta)
		{
			object value = metum.Key.GetValue(Target);
			tydTable.RemoveNode(metum.Key.Name);
			if (value == null)
			{
				tydTable.AddChild(new TydString(metum.Key.Name, null));
			}
			else if (metum.Value.IsList || metum.Value.IsArray)
			{
				TydList tydList = new TydList(metum.Key.Name);
				foreach (object item in (IEnumerable)value)
				{
					tydList.AddChild(NodeFromValue(item, metum.Value.Type, null));
				}
			}
			else
			{
				tydTable.AddChild(NodeFromValue(value, metum.Value.Type, metum.Key.Name));
			}
		}
	}
}
