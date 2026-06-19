using System;

namespace Loxodon.Framework.Localizations
{
	public class VersionTypeConverter : ITypeConverter
	{
		public bool Support(string typeName)
		{
			if (typeName == "version")
			{
				return true;
			}
			return false;
		}

		public Type GetType(string typeName)
		{
			if (typeName == "version")
			{
				return typeof(Version);
			}
			throw new NotSupportedException();
		}

		public object Convert(Type type, object value)
		{
			if (type == null)
			{
				throw new NotSupportedException();
			}
			string text = (string)value;
			if (string.IsNullOrEmpty(text))
			{
				return new Version("0.0.0");
			}
			return new Version(text.Trim());
		}
	}
}
