using System;

namespace Sirenix.Serialization
{
	public class WeakUnityEventFormatter : WeakReflectionFormatter
	{
		public WeakUnityEventFormatter(Type serializedType)
			: base(null)
		{
		}

		protected override object GetUninitializedObject()
		{
			return null;
		}
	}
}
