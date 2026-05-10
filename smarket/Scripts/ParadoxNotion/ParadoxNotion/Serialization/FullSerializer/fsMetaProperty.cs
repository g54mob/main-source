using System;
using System.Reflection;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public class fsMetaProperty
	{
		public FieldInfo Field { get; private set; }

		public string JsonName { get; private set; }

		public Type StorageType => null;

		public string MemberName => null;

		public bool ReadOnly { get; private set; }

		public bool WriteOnly { get; private set; }

		public bool AutoInstance { get; private set; }

		public bool AsReference { get; private set; }

		internal fsMetaProperty(FieldInfo field)
		{
		}

		public object Read(object context)
		{
			return null;
		}

		public void Write(object context, object value)
		{
		}
	}
}
