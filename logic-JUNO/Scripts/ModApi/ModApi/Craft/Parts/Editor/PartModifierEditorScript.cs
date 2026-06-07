using System;
using System.Reflection;
using ModApi.Craft.Parts.Attributes;
using UnityEngine;

namespace ModApi.Craft.Parts.Editor
{
	public abstract class PartModifierEditorScript : PartEditorScriptBase
	{
		public abstract PartModifierData GetPartModifier();

		public abstract void SetPartModifier(PartModifierData partModifier);
	}
	public abstract class PartModifierEditorScript<T> : PartModifierEditorScript where T : PartModifierData
	{
		public T Data;

		public override PartModifierData GetPartModifier()
		{
			return Data;
		}

		public override void SetPartModifier(PartModifierData modifier)
		{
			Data = (T)modifier;
		}

		public override bool Validate()
		{
			if (Data == null)
			{
				Debug.LogError("The part modifier data to validate is null", this);
				return false;
			}
			Type typeFromHandle = typeof(T);
			if (!Attribute.IsDefined(typeFromHandle, typeof(SerializableAttribute), inherit: false))
			{
				Debug.LogError("Part Modifier Validation: Part modifier '" + typeFromHandle.FullName + "' is not marked as serializable", this);
				return false;
			}
			if (typeFromHandle.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null) == null)
			{
				Debug.LogError("Part Modifier Validation: Type '" + typeFromHandle.FullName + "' does not have a public parameterless constructor.", this);
				return false;
			}
			FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				bool flag = Attribute.IsDefined(fieldInfo, typeof(PartModifierPropertyAttribute), inherit: true);
				bool flag2 = Attribute.IsDefined(fieldInfo, typeof(SerializeField));
				if (fieldInfo.IsPublic)
				{
					if (!flag)
					{
						Debug.LogWarningFormat("Part Modifier Validation: Field '{0}' on type '{1}' is serializable but does not have a part modifier property attribute.", fieldInfo.Name, typeFromHandle.FullName);
					}
				}
				else if (flag)
				{
					if (!flag2 && !((PartModifierPropertyAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(PartModifierPropertyAttribute), inherit: true)).NeverSerialize)
					{
						Debug.LogWarningFormat("Part Modifier Validation: Field '{0}' on type '{1}' has a part modifier property attribute but does not have a SerializeField attribute.", fieldInfo.Name, typeFromHandle.FullName);
					}
				}
				else if (flag2)
				{
					Debug.LogWarningFormat("Part Modifier Validation: Field '{0}' on type '{1}' is serializable but does not have a part modifier property attribute.", fieldInfo.Name, typeFromHandle.FullName);
				}
			}
			return true;
		}
	}
}
