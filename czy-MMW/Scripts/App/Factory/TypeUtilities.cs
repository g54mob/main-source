using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Factory
{
	public static class TypeUtilities
	{
		public static int GetTypeId<T>()
		{
			return GetTypeId(typeof(T));
		}

		public static int GetTypeId(Type type)
		{
			return CalculateMD5(type.FullName);
		}

		public static int CalculateMD5(string name)
		{
			return BitConverter.ToInt32(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(name)), 0);
		}

		public static T GetCustomAttribute<T>(Type type) where T : Attribute
		{
			T customAttribute = type.GetCustomAttribute<T>(inherit: true);
			if (customAttribute != null)
			{
				return customAttribute;
			}
			Type[] interfaces = type.GetInterfaces();
			for (int i = 0; i < interfaces.Length; i++)
			{
				customAttribute = interfaces[i].GetCustomAttribute<T>(inherit: true);
				if (customAttribute != null)
				{
					return customAttribute;
				}
			}
			return null;
		}
	}
}
