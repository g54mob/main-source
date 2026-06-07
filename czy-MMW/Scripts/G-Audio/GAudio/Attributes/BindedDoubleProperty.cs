using System;
using System.Reflection;

namespace GAudio.Attributes
{
	public class BindedDoubleProperty : BindedValueProperty
	{
		public BindedDoubleProperty(string propertyPath, Type outerType, string toggleName = null)
			: base(propertyPath, outerType, toggleName)
		{
		}

		public override void SetValue(object owner, object value)
		{
			object targetObj = GetTargetObj(owner);
			double num = (float)value;
			if (_fieldFlags[_fieldFlags.Length - 1])
			{
				((FieldInfo)_memberInfos[_memberInfos.Length - 1]).SetValue(targetObj, num);
			}
			else
			{
				((PropertyInfo)_memberInfos[_memberInfos.Length - 1]).SetValue(targetObj, num, null);
			}
		}
	}
}
