using System;

namespace VoxelBusters.CoreLibrary
{
	public class DefaultValueAttribute : Attribute
	{
		private bool? m_boolValue;

		private int? m_int32Value;

		private float? m_singleValue;

		private string m_stringValue;

		public bool BoolValue => false;

		public int Int32Value => 0;

		public float SingleValue => 0f;

		public string StringValue => null;

		public DefaultValueAttribute(bool value)
		{
		}

		public DefaultValueAttribute(int value)
		{
		}

		public DefaultValueAttribute(float value)
		{
		}

		public DefaultValueAttribute(string value)
		{
		}

		public T GetValue<T>()
		{
			return default(T);
		}

		public object GetValue(Type type)
		{
			return null;
		}
	}
}
