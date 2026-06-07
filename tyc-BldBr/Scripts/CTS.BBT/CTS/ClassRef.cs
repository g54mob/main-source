using System;

namespace CTS
{
	[Serializable]
	public readonly struct ClassRef<T> where T : class
	{
		public readonly Guid Ref;

		public static implicit operator ClassRef<T>(T obj)
		{
			return new ClassRef<T>(obj);
		}

		public T GetClass()
		{
			return ClassReferenceManager.GetClass<T>(Ref);
		}

		public ClassRef(T obj)
		{
			Ref = ClassReferenceManager.GetOrCreateRef(obj);
		}
	}
}
