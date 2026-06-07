using System.Collections;
using System.Globalization;
using System.Text;

namespace I18N.Common
{
	public class Manager
	{
		private const string hex = "0123456789abcdef";

		private static Manager manager;

		private Hashtable handlers;

		private Hashtable active;

		private Hashtable assemblies;

		private static readonly object lockobj;

		public static Manager PrimaryManager => null;

		private Manager()
		{
		}

		private static string Normalize(string name)
		{
			return null;
		}

		public Encoding GetEncoding(int codePage)
		{
			return null;
		}

		public Encoding GetEncoding(string name)
		{
			return null;
		}

		public CultureInfo GetCulture(int culture, bool useUserOverride)
		{
			return null;
		}

		public CultureInfo GetCulture(string name, bool useUserOverride)
		{
			return null;
		}

		internal object Instantiate(string name)
		{
			return null;
		}

		private void LoadClassList()
		{
		}

		private void LoadInternalClasses()
		{
		}
	}
}
