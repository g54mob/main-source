using System;
using System.Reflection;
using UnityEngine;

namespace GAudio.Attributes
{
	public abstract class BindedValueProperty : PropertyAttribute
	{
		protected MemberInfo[] _memberInfos;

		protected bool[] _fieldFlags;

		protected string[] _pathComponents;

		protected FieldInfo _toggleInfo;

		public BindedValueProperty(string propertyPath, Type outerType, string toggleField = null)
		{
			_pathComponents = propertyPath.Split('.');
			_memberInfos = new MemberInfo[_pathComponents.Length];
			_fieldFlags = new bool[_pathComponents.Length];
			if (toggleField != null)
			{
				_toggleInfo = outerType.GetField(toggleField, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			}
			for (int i = 0; i < _pathComponents.Length; i++)
			{
				PropertyInfo property = outerType.GetProperty(_pathComponents[i], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (property == null)
				{
					FieldInfo field = outerType.GetField(_pathComponents[i], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					_fieldFlags[i] = true;
					_memberInfos[i] = field;
					outerType = field.FieldType;
				}
				else
				{
					_memberInfos[i] = property;
					outerType = property.PropertyType;
				}
			}
		}

		public virtual void SetValue(object owner, object value)
		{
			object targetObj = GetTargetObj(owner);
			if (_fieldFlags[_fieldFlags.Length - 1])
			{
				((FieldInfo)_memberInfos[_memberInfos.Length - 1]).SetValue(targetObj, value);
			}
			else
			{
				((PropertyInfo)_memberInfos[_memberInfos.Length - 1]).SetValue(targetObj, value, null);
			}
		}

		public object GetValue(object owner)
		{
			object targetObj = GetTargetObj(owner);
			if (_fieldFlags[_fieldFlags.Length - 1])
			{
				return ((FieldInfo)_memberInfos[_memberInfos.Length - 1]).GetValue(targetObj);
			}
			return ((PropertyInfo)_memberInfos[_memberInfos.Length - 1]).GetValue(targetObj, null);
		}

		public object GetTargetObj(object outerObj)
		{
			for (int i = 0; i < _memberInfos.Length - 1; i++)
			{
				outerObj = ((!_fieldFlags[i]) ? ((PropertyInfo)_memberInfos[i]).GetValue(outerObj, null) : ((FieldInfo)_memberInfos[i]).GetValue(outerObj));
			}
			return outerObj;
		}

		public bool CheckToggle(object owner)
		{
			if (_toggleInfo == null)
			{
				return true;
			}
			return (bool)_toggleInfo.GetValue(owner);
		}
	}
}
