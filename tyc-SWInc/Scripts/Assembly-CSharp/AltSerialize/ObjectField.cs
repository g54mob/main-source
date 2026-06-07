using System;
using System.Reflection;

namespace AltSerialize
{
	internal class ObjectField
	{
		private FieldInfo _fieldInfo;

		public Type FieldType
		{
			get
			{
				return FieldInfo.FieldType;
			}
		}

		public FieldInfo FieldInfo
		{
			get
			{
				return _fieldInfo;
			}
			set
			{
				_fieldInfo = value;
			}
		}
	}
}
