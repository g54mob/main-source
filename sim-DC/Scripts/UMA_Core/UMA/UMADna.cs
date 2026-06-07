using System;

namespace UMA
{
	public abstract class UMADna : UMADnaBase
	{
		public static string[] GetNames(Type dnaType)
		{
			return null;
		}

		public static Type GetType(string className)
		{
			return null;
		}

		public static Type[] GetTypes()
		{
			return null;
		}

		public static UMADnaBase LoadInstance(Type dnaType, string data)
		{
			return null;
		}

		public static string SaveInstance(UMADnaBase instance)
		{
			return null;
		}
	}
}
