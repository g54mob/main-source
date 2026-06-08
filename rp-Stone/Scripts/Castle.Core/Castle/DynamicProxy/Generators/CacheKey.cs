using System;
using System.ComponentModel;
using System.Reflection;

namespace Castle.DynamicProxy.Generators
{
	[Serializable]
	[Obsolete("Intended for internal use only.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CacheKey
	{
		private readonly MemberInfo target;

		private readonly Type[] interfaces;

		private readonly ProxyGenerationOptions options;

		private readonly Type type;

		public CacheKey(MemberInfo target, Type type, Type[] interfaces, ProxyGenerationOptions options)
		{
			this.target = target;
			this.type = type;
			this.interfaces = interfaces ?? Type.EmptyTypes;
			this.options = options;
		}

		public CacheKey(Type target, Type[] interfaces, ProxyGenerationOptions options)
			: this(target.GetTypeInfo(), null, interfaces, options)
		{
		}

		public override int GetHashCode()
		{
			int num = target.GetHashCode();
			Type[] array = interfaces;
			foreach (Type type in array)
			{
				num = 29 * num + type.GetHashCode();
			}
			if (options != null)
			{
				num = 29 * num + options.GetHashCode();
			}
			if (this.type != null)
			{
				num = 29 * num + this.type.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is CacheKey cacheKey))
			{
				return false;
			}
			if (!object.Equals(type, cacheKey.type))
			{
				return false;
			}
			if (!object.Equals(target, cacheKey.target))
			{
				return false;
			}
			if (interfaces.Length != cacheKey.interfaces.Length)
			{
				return false;
			}
			for (int i = 0; i < interfaces.Length; i++)
			{
				if (!object.Equals(interfaces[i], cacheKey.interfaces[i]))
				{
					return false;
				}
			}
			if (!object.Equals(options, cacheKey.options))
			{
				return false;
			}
			return true;
		}
	}
}
